using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace RCONManager {
    public class HotKeyClass : IMessageFilter {

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int RegisterHotKey(IntPtr Hwnd, int ID, int Modifiers, int Key);

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int UnregisterHotKey(IntPtr Hwnd, int ID);

        [DllImport("kernel32", EntryPoint = "GlobalAddAtomA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern short GlobalAddAtom(string IDString);

        [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern short GlobalDeleteAtom(short Atom);

        public Form OwnerForm {
            get { return mForm; }
            set { mForm = value; }
        }

        private Form mForm;
        private const int WM_HOTKEY = 786;
        private System.Collections.Generic.Dictionary<short, HotKeyObject> mHotKeyList = new System.Collections.Generic.Dictionary<short, HotKeyObject>();
        private System.Collections.Generic.Dictionary<string, short> mHotKeyIDList = new System.Collections.Generic.Dictionary<string, short>();

        public event HotKeyPressedEventHandler HotKeyPressed;
        public delegate void HotKeyPressedEventHandler(string HotKeyID);

        public enum MODKEY : int {
            MOD_NONE    = 0,
            MOD_ALT     = 1,
            MOD_CONTROL = 2,
            MOD_SHIFT   = 4,
            MOD_WIN     = 8
        }

        public HotKeyClass() {
            Application.AddMessageFilter(this);
        }

        /// <summary>
        /// Add an register a hotkey
        /// </summary>
        /// <param name="hkeyObj">hotkey object</param>
        public void AddHotKey(HotKeyObject hkeyObj) {
            if (!mHotKeyIDList.ContainsKey(hkeyObj.HotKeyID)) {
                short ID = GlobalAddAtom(hkeyObj.HotKeyID);
                mHotKeyIDList.Add(hkeyObj.HotKeyID, ID);
                mHotKeyList.Add(ID, hkeyObj);
                RegisterHotKey(mForm.Handle, (int)ID, (int)mHotKeyList[ID].Modifier, (int)mHotKeyList[ID].HotKey);
            }
        }

        /// <summary>
        /// Remove and unregister a hotkey
        /// </summary>
        /// <param name="HotKeyID">ID where hotkey has to be removed</param>
        public void RemoveHotKey(string HotKeyID) {
            if (mHotKeyIDList.ContainsKey(HotKeyID) == false) return; // TODO: might not be correct. Was : Exit Sub

            short ID = mHotKeyIDList[HotKeyID];
            mHotKeyIDList.Remove(HotKeyID);
            mHotKeyList.Remove(ID);
            UnregisterHotKey(mForm.Handle, (int)ID);
            GlobalDeleteAtom(ID);
        }

        /// <summary>
        /// Remove all hotkeys
        /// </summary>
        public void RemoveAllHotKeys() {
            List<string> IDList = new List<string>();
            foreach (KeyValuePair<string, short> KVP in mHotKeyIDList) {
                IDList.Add(KVP.Key);
            }

            for (int i = 0; i <= IDList.Count - 1; i++) {
                RemoveHotKey(IDList[i]);
            }
        }

        public bool PreFilterMessage(ref Message m) {
            if (m.Msg == WM_HOTKEY) {
                if (HotKeyPressed != null) {
                    HotKeyPressed(mHotKeyList[(short)m.WParam].HotKeyID);
                }
            }
            return false;
        }
    }
}