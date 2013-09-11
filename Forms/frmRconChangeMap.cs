using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RConControl.Forms {
    public partial class frmRconChangeMap : Form {

        //*************************************************
        // Variables
        //*************************************************
        public string ReturnValue { get; set; }
        public delegate void StringHandler(string str);
        public event StringHandler ExceptionEvent;

        private Language mLangMan = Language.Instance;

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
                ExceptionEvent(mLangMan.GetString("Rcon_WrongAnswer"));
                this.Close();
            }
            
        }

        //*************************************************
        // Event receivers
        //*************************************************
        private void frmRconChangeMap_FormClosing(object sender, FormClosingEventArgs e) {
            if (this.DialogResult == DialogResult.OK) {
                ReturnValue = (string)comboBoxMaps.SelectedItem;
            }
        }

        //*************************************************
        // private helper methods
        //*************************************************
        private void LoadLanguage() {
            this.Text      = mLangMan.GetString("Changemap_FormTitle");
            lblMap.Text    = mLangMan.GetString("Changemap_LabelMap") + ":";
            btnOk.Text     = mLangMan.GetString("Button_OK");
            btnCancel.Text = mLangMan.GetString("Button_Cancel");
        }
    }
}
