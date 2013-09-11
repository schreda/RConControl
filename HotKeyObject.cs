using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RConControl {
    public class HotKeyObject {

        //*************************************************
        // Variables
        //*************************************************
        [XmlElement(ElementName = "Hotkey")]
        public Keys HotKey { get; set; }
        [XmlElement(ElementName = "Modifier")]
        public HotKeyClass.MODKEY Modifier { get; set; }
        [XmlElement(ElementName = "HotkeyID")]
        public string HotKeyID { get; set; }
        
        //*************************************************
        // CTor
        //*************************************************
        public HotKeyObject() { Clear(); }
        public HotKeyObject(HotKeyObject obj) {
            HotKey = obj.HotKey;
            Modifier = obj.Modifier;
            HotKeyID = obj.HotKeyID;
        }

        //*************************************************
        // Methods
        //*************************************************
        public void Clear() {
            Modifier = HotKeyClass.MODKEY.MOD_NONE;
            HotKey = Keys.None;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            if ((Modifier & HotKeyClass.MODKEY.MOD_CONTROL) == HotKeyClass.MODKEY.MOD_CONTROL) {
                sb.Append(Keys.Control.ToString());
                sb.Append(" + ");
            }
            if ((Modifier & HotKeyClass.MODKEY.MOD_ALT) == HotKeyClass.MODKEY.MOD_ALT) {
                sb.Append(Keys.Alt.ToString());
                sb.Append(" + ");
            }
            if ((Modifier & HotKeyClass.MODKEY.MOD_SHIFT) == HotKeyClass.MODKEY.MOD_SHIFT) {
                sb.Append(Keys.Shift.ToString());
                sb.Append(" + ");
            }
            if (HotKey != Keys.None) sb.Append(HotKey.ToString());
            return sb.ToString().Trim().TrimEnd('+');
        }
    }
}
