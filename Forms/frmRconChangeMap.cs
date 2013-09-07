using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RCONManager {
    public partial class frmRconChangeMap : Form {

        //*************************************************
        // Variables
        //*************************************************
        private RconConnection rcon = RconConnection.Instance;
        private Language langMan = Language.Instance;

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
                comboBoxMaps.DataSource = RconTools.GetAllMaps(rcon);
            } catch {
                ExceptionEvent(langMan.GetString("Rcon_WrongAnswer"), true);
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
            this.Text      = langMan.GetString("Changemap_FormTitle");
            lblMap.Text    = langMan.GetString("Changemap_LabelMap") + ":";
            btnOk.Text     = langMan.GetString("Button_OK");
            btnCancel.Text = langMan.GetString("Button_Cancel");
        }
    }
}
