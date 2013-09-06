using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCONManager {
    public class ConfigFile {

        //*****************************
        // Variables
        //*****************************
        public string name { get; set; }
        public string content { get; set; }

        //*****************************
        // CTor
        //*****************************
        public ConfigFile() {
            name    = "";
            content = "";
        }
        public ConfigFile(string inName, string inContent) {
            name    = inName;
            content = inContent;
        }
        public ConfigFile(ConfigFile obj) {
            name    = obj.name;
            content = obj.content;
        }

        //*****************************
        // Methods
        //*****************************
        public override string ToString() {
            return name;
        }
    }
}
