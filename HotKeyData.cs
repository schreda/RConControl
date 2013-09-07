using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RCONManager {
    public class HotKeyData {

        //*************************************************
        // Variables
        //*************************************************
        public HotKeyClass.MODKEY modKey { get; set; }
        public Keys key { get; set; }

        //*************************************************
        // CTor
        //*************************************************
        public HotKeyData() { Clear(); }
        public HotKeyData(HotKeyClass.MODKEY inModKey, Keys inKey) {
            modKey = inModKey;
            key    = inKey;
        }
        public HotKeyData(HotKeyData obj) {
            key    = obj.key;
            modKey = obj.modKey;
        }

        //*************************************************
        // Methods
        //*************************************************
        public void Clear() {
            modKey = HotKeyClass.MODKEY.MOD_NONE;
            key    = Keys.None;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            if ((modKey & HotKeyClass.MODKEY.MOD_CONTROL)== HotKeyClass.MODKEY.MOD_CONTROL) {
                sb.Append(Keys.Control.ToString());
                sb.Append(" + ");
            }
            if ((modKey & HotKeyClass.MODKEY.MOD_ALT) == HotKeyClass.MODKEY.MOD_ALT) {
                sb.Append(Keys.Alt.ToString());
                sb.Append(" + ");
            }
            if ((modKey & HotKeyClass.MODKEY.MOD_SHIFT) == HotKeyClass.MODKEY.MOD_SHIFT) {
                sb.Append(Keys.Shift.ToString());
                sb.Append(" + ");
            }
            if (key != Keys.None) sb.Append(key.ToString());
            return sb.ToString().Trim().TrimEnd('+');
        }

    }
}
