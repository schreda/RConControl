using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RCONManager {
    /// <summary>
    /// Class for config files
    /// </summary>
    public class ConfigFile {
        [XmlElement(ElementName = "Name")]
        public string name { get; set; }
        [XmlElement(ElementName = "Content")]
        public string content { get; set; }

        public ConfigFile() { }
        public ConfigFile(ConfigFile obj) {
            name = obj.name;
            content = obj.content;
        }

        public override string ToString() {
            return name;
        }
    }
}
