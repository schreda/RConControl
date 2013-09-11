using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RConControl.Forms {
    public partial class frmRconLoadConfig : Form {

        //*************************************************
        // Variables
        //*************************************************
        public ConfigFile ReturnValue { get; set; }
        public delegate void StringHandler(string str);
        public event StringHandler ExceptionEvent;

        private Language mLangMan = Language.Instance;

        //*************************************************
        // Initialization
        //*************************************************
        public frmRconLoadConfig() {
            InitializeComponent();
            LoadLanguage();
        }

        private void RconLoadConfigUI_Load(object sender, EventArgs e) {
            try {
                comboBoxConfigs.DataSource = Tools.GetAllConfigFiles();
            } catch (Exception ex) {
                ErrorLogger.Log(ex);
                ExceptionEvent(mLangMan.GetString("Error_LoadConfigs"));
                this.Close();
            }
            
        }

        //*************************************************
        // Event receivers
        //*************************************************
        private void frmRconLoadConfig_FormClosing(object sender, FormClosingEventArgs e) {
            if (this.DialogResult == DialogResult.OK) {
                ReturnValue = (ConfigFile)comboBoxConfigs.SelectedItem;
            }
        }

        //*************************************************
        // private helper methods
        //*************************************************
        private void LoadLanguage() {
            this.Text      = mLangMan.GetString("LoadCfg_FormTitle");
            lblConfig.Text = mLangMan.GetString("LoadCfg_LabelConfig") + ":";
            btnOk.Text     = mLangMan.GetString("Button_OK");
            btnCancel.Text = mLangMan.GetString("Button_Cancel");
        }
    }
}
