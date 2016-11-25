﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CASCExplorer;
using OWLib;
using OWLib.Types.STUD;

namespace OverTool {
  public struct Record {
    public APMPackage package;
    public PackageIndex index;
    public PackageIndexRecord record;
  }

  class Program {
    static void Main(string[] args) {
      Console.OutputEncoding = Encoding.UTF8;
      if(args.Length < 2) {
        Console.Out.WriteLine("Usage: OverTool.exe [-LLang] \"overwatch path\" mode [mode opts]");
        Console.Out.WriteLine("Modes:");
        Console.Out.WriteLine("\tt - List Cosmetics");
        Console.Out.WriteLine("\tx - Extract Cosmetics");
        Console.Out.WriteLine("\tm - List Maps");
        Console.Out.WriteLine("\tM - Extract Maps");
        Console.Out.WriteLine("\tn - List NPCs");
        Console.Out.WriteLine("\tN - Extract NPCs");
        Console.Out.WriteLine("\ta - List Achievements");
        Console.Out.WriteLine("\tA - Extract Achievement Rewards and Icons");
        Console.Out.WriteLine("\tv - Extract Hero Sounds");
        Console.Out.WriteLine("\ts - Extract Strings");
        Console.Out.WriteLine("\tZ - List Keys");
        Console.Out.WriteLine("\tT - List Textures for Model");
        return;
      }

      string[] validLangs = new string[] { "deDE", "enUS", "esES", "esMX", "frFR", "itIT", "jaJP", "koKR", "plPL", "ptBR", "ruRU", "zhCN", "zhTW" };
      if(args[0][0] == '-' && args[0][1] == 'L') {
        string lang = args[0].Substring(2);
        if(!validLangs.Contains(lang)) {
          Console.Out.WriteLine("Language {0} is not supported!", lang);
          foreach(string validLang in validLangs) {
            if(validLang.ToLowerInvariant().Contains(lang.ToLowerInvariant())) {
              lang = validLang;
              Console.Out.WriteLine("Autocorrecting selected lanuage to {0}", lang);
              break;
            }
          }
        }
        if(!validLangs.Contains(lang)) {
          return;
        }
        Console.Out.WriteLine("Set language to {0}", lang);
        OwRootHandler.LanguageScan = lang;
        args = args.Skip(1).ToArray();
      }

      string root = args[0];
      char opt = args[1][0];
      Action<Dictionary<ushort, List<ulong>>, Dictionary<ulong, Record>, CASCHandler, string[]> optfn = null;
      if(opt == 't') {
        optfn = ListInventory.Parse;
      } else if(opt == 'x') {
        optfn = Extract.Parse;
      } else if(opt == 'm') {
        optfn = ListMap.Parse;
      } else if(opt == 'M') {
        optfn = ExtractMap.Parse;
      } else if(opt == 'v') {
        optfn = DumpVoice.Parse;
      } else if(opt == 's') {
        optfn = DumpString.Parse;
      } else if(opt == 'Z') {
        optfn = DumpKey.Parse;
      } else if(opt == 'T') {
        optfn = DumpTex.Parse;
      } else if(opt == 'n') {
        optfn = ListNPC.Parse;
      } else if(opt == 'N') {
        optfn = DumpNPC.Parse;
      } else if(opt == 'a') {
        optfn = ListAchievement.Parse;
      } else if(opt == 'A') {
        optfn = DumpAchievement.Parse;
      } else {
        Console.Error.WriteLine("UNSUPPORTED OPT {0}", opt);
        return;
      }

      Dictionary<ushort, List<ulong>> track = new Dictionary<ushort, List<ulong>>();
      track.Add(0x75, new List<ulong>());
      track.Add(0x9F, new List<ulong>());
      track.Add(0x7C, new List<ulong>());
      track.Add(0xA9, new List<ulong>());
      track.Add(0x90, new List<ulong>());
      track.Add(0x3, new List<ulong>());
      track.Add(0x68, new List<ulong>());

      Dictionary<ulong, Record> map = new Dictionary<ulong, Record>();

      Console.Out.WriteLine("{0} v{1}", Assembly.GetExecutingAssembly().GetName().Name, Assembly.GetExecutingAssembly().GetName().Version.ToString());
      Console.Out.WriteLine("Initializing CASC...");
      CASCConfig config = CASCConfig.LoadLocalStorageConfig(root);
      CASCHandler handler = CASCHandler.OpenStorage(config);
      OwRootHandler ow = handler.Root as OwRootHandler;
      if(ow == null) {
        Console.Error.WriteLine("Not a valid overwatch installation");
        return;
      }

      // Fail when trying to extract data from a specified language with 2 or less files found.
      if(ow.APMFiles.Count() == 0) {
        Console.Error.WriteLine("Could not find the files for language {0}. Please confirm that you have that language installed, and are using the names from the target language.", OwRootHandler.LanguageScan);
        return;
      }

      Console.Out.WriteLine("Mapping...");
      foreach(APMFile apm in ow.APMFiles) {
        if(!apm.Name.ToLowerInvariant().Contains("rdev")) {
          continue; // skip
        }
        for(int i = 0; i < apm.Packages.Length; ++i) {
          APMPackage package = apm.Packages[i];
          PackageIndex index = apm.Indexes[i];
          PackageIndexRecord[] records = apm.Records[i];
          for(long j = 0; j < records.LongLength; ++j) {
            PackageIndexRecord record = records[j];
            if(map.ContainsKey(record.Key)) {
              continue;
            }

            Record rec = new Record {
              package = package,
              index = index,
              record = record,
            };
            map.Add(record.Key, rec);

            ushort id = (ushort)APM.keyToTypeID(record.Key);
            if(track.ContainsKey(id)) {
              track[id].Add(record.Key);
            }
          }
        }
      }

      Console.Out.WriteLine("Adding Encryption Keys...");

      foreach(ulong key in track[0x90]) {
        if(!map.ContainsKey(key)) {
          continue;
        }
        using(Stream stream = Util.OpenFile(map[key], handler)) {
          if(stream == null) {
            continue;
          }
          STUD stud = new STUD(stream);
          if(stud.Instances[0].Name != stud.Manager.GetName(typeof(EncryptionKey))) {
            continue;
          }
          EncryptionKey ek = (EncryptionKey)stud.Instances[0];
          if(!KeyService.keys.ContainsKey(ek.KeyNameLong)) {
            KeyService.keys.Add(ek.KeyNameLong, ek.KeyValueText.ToByteArray());
            Console.Out.WriteLine("Added Encryption Key {0}", ek.KeyNameText);
          }
        }
      }
      Console.Out.WriteLine("Tooling...");

      optfn(track, map, handler, args.Skip(2).ToArray());
      if(System.Diagnostics.Debugger.IsAttached) {
        System.Diagnostics.Debugger.Break();
      }
    }
  }
}