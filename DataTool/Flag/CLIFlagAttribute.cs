﻿using System;

namespace DataTool.Flag {
    [AttributeUsage(AttributeTargets.Field)]
    public class CLIFlagAttribute : Attribute {
        public string Flag = null;
        public string Help = null;
        public bool Required = false;
        public int Positional = -1;
        public object Default = null;
        public bool NeedsValue = false;
        public string[] Parser = null;
        public string[] Valid = null;

        public new string ToString() {
            return Flag;
        }
    }
}
