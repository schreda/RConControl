using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RCONManager.Forms {
    public partial class frmRconLoadConfig : Form {

        //*************************************************
        // Variables
        //*************************************************
        private Language mLangMan = Language.Instance;
        public ConfigFile ReturnValue { get; set; }

        //*************************************************
        // Initialization
        //*************************************************
        public frmRconLoadConfig() {
            InitializeComponent();
            LoadLanguage();
        }

        private void RconLoadConfigUI_Load(object sender, EventArgs e) {
            comboBoxConfigs.DataSource = Tools.GetAllConfigFiles();
        }

        //*************************************************
        // Event receivers
        //*************************************************
        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            ReturnValue = (ConfigFile)comboBoxConfigs.SelectedItem;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        //*************************************************
        // Methods
        //*************************************************
        private void LoadLanguage() {
            this.Text      = mLangMan.GetString("LoadCfg_FormTitle");
            lblConfig.Text = mLangMan.GetString("LoadCfg_LabelConfig") + ":";
            btnOk.Text     = mLangMan.GetString("Button_OK");
            btnCancel.Text = mLangMan.GetString("Button_Cancel");
        }
    }
}
