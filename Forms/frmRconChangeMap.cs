using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RCONManager.Forms {
    public partial class frmRconChangeMap : Form {

        //*************************************************
        // Variables
        //*************************************************
        private Language mLangMan = Language.Instance;

        public string ReturnValue { get; set; }

        public delegate void StringBool(string str, bool b = false);
        public event StringBool ExceptionEvent;

        //*************************************************
        // Initialization
        //*************************************************
        public frmRconChangeMap() {
            InitializeComponent();
            LoadLanguage();
        }

        private void RconLoadConfigUI_Load(object sender, EventArgs e) {
            try {
                comboBoxMaps.DataSource = SourceRconTools.GetAllMaps();
            } catch (Exception ex) {
                ErrorLogger.Log(ex);
                ExceptionEvent(mLangMan.GetString("Rcon_WrongAnswer"), true);
                this.Close();
            }
            
        }

        //*************************************************
        // Event receivers
        //*************************************************
        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            ReturnValue = (string)comboBoxMaps.SelectedItem;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        //*************************************************
        // Methods
        //*************************************************
        private void LoadLanguage() {
            this.Text      = mLangMan.GetString("Changemap_FormTitle");
            lblMap.Text    = mLangMan.GetString("Changemap_LabelMap") + ":";
            btnOk.Text     = mLangMan.GetString("Button_OK");
            btnCancel.Text = mLangMan.GetString("Button_Cancel");
        }
    }
}
