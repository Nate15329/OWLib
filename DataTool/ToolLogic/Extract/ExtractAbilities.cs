﻿using System;
using System.Collections.Generic;
using System.IO;
using DataTool.FindLogic;
using DataTool.Flag;
using OWLib;
using STULib.Types;
using static DataTool.Helper.IO;
using static DataTool.Program;
using static DataTool.Helper.STUHelper;

namespace DataTool.ToolLogic.Extract {
    [Tool("extract-abilities", Description = "Extract abilities", TrackTypes = new ushort[] {0x9E}, CustomFlags = typeof(ExtractFlags))]
    public class ExtractAbilities : ITool {
        public void IntegrateView(object sender) {
            throw new NotImplementedException();
        }

        public void Parse(ICLIFlags toolFlags) {
            SaveAbilities(toolFlags);
        }

        public static void SaveAbilities(ICLIFlags toolFlags) {
            string basePath;
            if (toolFlags is ExtractFlags flags) {
                basePath = flags.OutputPath;
            } else {
                throw new Exception("no output path");
            }
            
            
            foreach (ulong key in TrackedFiles[0x9E]) {
                STULoadout loadout = GetInstance<STULoadout>(key);
                if (loadout == null) continue;
                
                string name = GetValidFilename(GetString(loadout.Name).TrimEnd().Replace(".", "_")) ?? $"Unknown{GUID.Index(key):X}";
                
                Dictionary<ulong, List<TextureInfo>> textures = new Dictionary<ulong, List<TextureInfo>>();
                textures = FindLogic.Texture.FindTextures(textures, loadout.Texture);

                using (Stream videoStream = OpenFile(loadout.InfoMovie)) {
                    if (videoStream != null) {
                        videoStream.Position = 128;  // wrapped in "MOVI" for some reason
                        WriteFile(videoStream, Path.Combine(basePath, name, "video.bk2"));
                    }
                }

                SaveLogic.Texture.Save(flags, Path.Combine(basePath, name), textures);
            }
        }
    }
}