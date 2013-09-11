using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RConControl {
    public class ConfigFile {

        //*************************************************
        // Variables
        //*************************************************
        [XmlElement(ElementName = "Name")]
        public string name { get; set; }
        [XmlElement(ElementName = "Content")]
        public string content { get; set; }

        //*************************************************
        // CTor
        //*************************************************
        public ConfigFile() { }
        public ConfigFile(ConfigFile obj) {
            name = obj.name;
            content = obj.content;
        }

        //*************************************************
        // Methods
        //*************************************************
        public override string ToString() {
            return name;
        }
    }
}
