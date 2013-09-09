using RCONManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RCONManager.Forms {
    public partial class frmHotKeys : Form {

        //*************************************************
        // Variables
        //*************************************************
        private Language mLangMan = Language.Instance;

        private EditMode mCurrentEdit = EditMode.None;
        enum EditMode {
            None,
            LoadCfg,
            Restart
        };

        private HotKeyObject mHkeyLoadCfg = new HotKeyObject();
        private HotKeyObject mHkeyRestart = new HotKeyObject();

        //*************************************************
        // Initialization
        //*************************************************
        public frmHotKeys() {
            InitializeComponent();
            LoadLanguage();
        }

        private void frmHotKeys_Load(object sender, EventArgs e) {
            if (Settings.Default.HKey_LoadCFG != null) {
                mHkeyLoadCfg = new HotKeyObject(Settings.Default.HKey_LoadCFG);
            }
            if (Settings.Default.HKey_Restart != null) {
                mHkeyRestart = new HotKeyObject(Settings.Default.HKey_Restart);
            }

            lblHkeyLoadCfg.Text = mHkeyLoadCfg.ToString();
            lblHkeyRestart.Text = mHkeyRestart.ToString();
        }

        //*************************************************
        // Event receivers
        //*************************************************
        private void btnHkeySetLoadCfg_Click(object sender, EventArgs e) {
            if (mCurrentEdit == EditMode.None) {
                BeginEdit(btnHkeyLoadCfg, lblHkeyLoadCfg, mHkeyLoadCfg, EditMode.LoadCfg);
            } else if (mCurrentEdit == EditMode.LoadCfg) {
                if (mHkeyLoadCfg.HotKey != Keys.None) {
                    frmRconLoadConfig formLoadConfig = new frmRconLoadConfig();
                    if (formLoadConfig.ShowDialog() == DialogResult.OK) {
                        Settings.Default.HKey_LoadCFG_Config = new ConfigFile(formLoadConfig.ReturnValue);
                        Settings.Default.HKey_LoadCFG        = new HotKeyObject(mHkeyLoadCfg);
                    } else {
                        lblHkeyLoadCfg.Text = Settings.Default.HKey_LoadCFG.ToString();
                    }
                } else {
                    Settings.Default.HKey_LoadCFG_Config = new ConfigFile();
                    Settings.Default.HKey_LoadCFG        = new HotKeyObject();
                }
                EndEdit(btnHkeyLoadCfg);
            }
        }
        private void btnHkeyRestart_Click(object sender, EventArgs e) {
            if (mCurrentEdit == EditMode.None) {
                BeginEdit(btnHkeyRestart, lblHkeyRestart, mHkeyRestart, EditMode.Restart);
            } else if (mCurrentEdit == EditMode.Restart) {
                Settings.Default.HKey_Restart = new HotKeyObject(mHkeyRestart);
                EndEdit(btnHkeyRestart);
            }
        }
        private void frmHotKeys_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                if (mCurrentEdit == EditMode.LoadCfg) {
                    mHkeyLoadCfg = new HotKeyObject(Settings.Default.HKey_LoadCFG);
                    lblHkeyLoadCfg.Text = mHkeyLoadCfg.ToString();
                    EndEdit(btnHkeyLoadCfg);
                } else if (mCurrentEdit == EditMode.Restart) {
                    mHkeyRestart = new HotKeyObject(Settings.Default.HKey_Restart);
                    lblHkeyRestart.Text = mHkeyRestart.ToString();
                    EndEdit(btnHkeyRestart);
                }

            } else {
                HotKeyObject hkey = new HotKeyObject();

                if (e.Control) hkey.Modifier |= HotKeyClass.MODKEY.MOD_CONTROL;
                if (e.Alt) hkey.Modifier     |= HotKeyClass.MODKEY.MOD_ALT;
                if (e.Shift) hkey.Modifier   |= HotKeyClass.MODKEY.MOD_SHIFT;

                if (e.KeyCode != Keys.ShiftKey
                    && e.KeyCode != Keys.ControlKey
                    && e.KeyCode != Keys.Menu) {
                    hkey.HotKey = e.KeyCode;
                }

                string text = hkey.ToString();

                if (mCurrentEdit == EditMode.LoadCfg) {
                    mHkeyLoadCfg = hkey;
                    mHkeyRestart.HotKeyID = GlobalConstants.HOTKEYID_LOADCFG;
                    lblHkeyLoadCfg.Text = text;
                } else if (mCurrentEdit == EditMode.Restart) {
                    mHkeyRestart = hkey;
                    mHkeyRestart.HotKeyID = GlobalConstants.HOTKEYID_RESTART;
                    lblHkeyRestart.Text = text;
                }
            }
        }

        //*************************************************
        // Methods
        //*************************************************
        private void LoadLanguage() {
            this.Text           = mLangMan.GetString("Hotkeys_FormTitle");
            lblLoadCfg.Text     = mLangMan.GetString("Hotkeys_LabelLoadCfg") + ":";
            lblRestart.Text     = mLangMan.GetString("Hotkeys_LabelRestart") + ":";
            lblInfo.Text        = mLangMan.GetString("Hotkeys_LabelInfo");
            btnHkeyLoadCfg.Text = mLangMan.GetString("Hotkeys_ButtonSet");
            btnHkeyRestart.Text = mLangMan.GetString("Hotkeys_ButtonSet");
            btnOk.Text          = mLangMan.GetString("Button_OK");
            btnCancel.Text      = mLangMan.GetString("Button_Cancel");
        }

        private void BeginEdit(Button button, Label label, HotKeyObject hkey, EditMode mode) {
            lblInfo.Visible = true;
            hkey.Clear();
            label.Text = hkey.ToString();
            button.Text = mLangMan.GetString("Hotkeys_ButtonOK");
            mCurrentEdit = mode;
        }
        private void EndEdit(Button button) {
            lblInfo.Visible = false;
            button.Text = mLangMan.GetString("Hotkeys_ButtonSet");
            mCurrentEdit = EditMode.None;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            if (mCurrentEdit == EditMode.None) {
                Settings.Default.Save();
                this.Close();
            }
        }
    }
}
