using RCONManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RCONManager {
    public partial class frmHotKeys : Form {

        //*************************************************
        // Variables
        //*************************************************
        private Language langMan = Language.Instance;

        private EditMode currentEdit = EditMode.None;
        enum EditMode {
            None,
            LoadCfg,
            Restart
        };

        private HotKeyData HkeyLoadCfg = new HotKeyData();
        private HotKeyData HkeyRestart = new HotKeyData();

        //*************************************************
        // Initialization
        //*************************************************
        public frmHotKeys() {
            InitializeComponent();
            LoadLanguage();
        }

        private void frmHotKeys_Load(object sender, EventArgs e) {
            if (Settings.Default.Hkey_LoadCfg != null) {
                HkeyLoadCfg = new HotKeyData(Settings.Default.Hkey_LoadCfg);
            }
            if (Settings.Default.Hkey_Restart != null) {
                HkeyRestart = new HotKeyData(Settings.Default.Hkey_Restart);
            }

            lblHkeyLoadCfg.Text = HkeyLoadCfg.ToString();
            lblHkeyRestart.Text = HkeyRestart.ToString();
        }

        //*************************************************
        // Event receivers
        //*************************************************
        private void btnHkeySetLoadCfg_Click(object sender, EventArgs e) {
            if (currentEdit == EditMode.None) {
                BeginEdit(btnHkeyLoadCfg, lblHkeyLoadCfg, HkeyLoadCfg, EditMode.LoadCfg);
            } else if (currentEdit == EditMode.LoadCfg) {
                if (HkeyLoadCfg.key != Keys.None) {
                    frmRconLoadConfig formLoadConfig = new frmRconLoadConfig();
                    if (formLoadConfig.ShowDialog() == DialogResult.OK) {
                        Settings.Default.Hkey_LoadCfg_Config = new ConfigFile(formLoadConfig.ReturnValue);
                        Settings.Default.Hkey_LoadCfg        = new HotKeyData(HkeyLoadCfg);
                    } else {
                        lblHkeyLoadCfg.Text = Settings.Default.Hkey_LoadCfg.ToString();
                    }
                } else {
                    Settings.Default.Hkey_LoadCfg_Config = new ConfigFile();
                    Settings.Default.Hkey_LoadCfg        = new HotKeyData();
                }
                EndEdit(btnHkeyLoadCfg);
            }
        }
        private void btnHkeyRestart_Click(object sender, EventArgs e) {
            if (currentEdit == EditMode.None) {
                BeginEdit(btnHkeyRestart, lblHkeyRestart, HkeyRestart, EditMode.Restart);
            } else if (currentEdit == EditMode.Restart) {
                Settings.Default.Hkey_Restart = new HotKeyData(HkeyRestart);
                EndEdit(btnHkeyRestart);
            }
        }
        private void frmHotKeys_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                if (currentEdit == EditMode.LoadCfg) {
                    HkeyLoadCfg = new HotKeyData(Settings.Default.Hkey_LoadCfg);
                    lblHkeyLoadCfg.Text = HkeyLoadCfg.ToString();
                    EndEdit(btnHkeyLoadCfg);
                } else if (currentEdit == EditMode.Restart) {
                    HkeyRestart = new HotKeyData(Settings.Default.Hkey_Restart);
                    lblHkeyRestart.Text = HkeyRestart.ToString();
                    EndEdit(btnHkeyRestart);
                }

            } else {
                HotKeyData hkey = new HotKeyData();

                if (e.Control) hkey.modKey |= HotKeyClass.MODKEY.MOD_CONTROL;
                if (e.Alt) hkey.modKey     |= HotKeyClass.MODKEY.MOD_ALT;
                if (e.Shift) hkey.modKey   |= HotKeyClass.MODKEY.MOD_SHIFT;

                if (e.KeyCode != Keys.ShiftKey
                    && e.KeyCode != Keys.ControlKey
                    && e.KeyCode != Keys.Menu) {
                    hkey.key = e.KeyCode;
                }

                string text = hkey.ToString();

                if (currentEdit == EditMode.LoadCfg) {
                    HkeyLoadCfg = hkey;
                    lblHkeyLoadCfg.Text = text;
                } else if (currentEdit == EditMode.Restart) {
                    HkeyRestart = hkey;
                    lblHkeyRestart.Text = text;
                }
            }
        }

        //*************************************************
        // Methods
        //*************************************************
        private void LoadLanguage() {
            this.Text           = langMan.GetString("Hotkeys_FormTitle");
            lblLoadCfg.Text     = langMan.GetString("Hotkeys_LabelLoadCfg") + ":";
            lblRestart.Text     = langMan.GetString("Hotkeys_LabelRestart") + ":";
            lblInfo.Text        = langMan.GetString("Hotkeys_LabelInfo");
            btnHkeyLoadCfg.Text = langMan.GetString("Hotkeys_ButtonSet");
            btnHkeyRestart.Text = langMan.GetString("Hotkeys_ButtonSet");
            btnOk.Text          = langMan.GetString("Button_OK");
            btnCancel.Text      = langMan.GetString("Button_Cancel");
        }

        private void BeginEdit(Button button, Label label, HotKeyData hkey, EditMode mode) {
            lblInfo.Visible = true;
            hkey.Clear();
            label.Text = hkey.ToString();
            button.Text = langMan.GetString("Hotkeys_ButtonOK");
            currentEdit = mode;
        }
        private void EndEdit(Button button) {
            lblInfo.Visible = false;
            button.Text = langMan.GetString("Hotkeys_ButtonSet");
            currentEdit = EditMode.None;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            if (currentEdit == EditMode.None) {
                Settings.Default.Save();
                this.Close();
            }
        }
    }
}
