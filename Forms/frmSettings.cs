using RCONManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace RCONManager {
    public partial class frmSettings : Form {

        //*****************************
        // Variables
        //*****************************
        private Language langMan = Language.Instance;

        //*****************************
        // Initialization
        //*****************************
        public frmSettings() {
            InitializeComponent();
        }
    
        private void frmSettings_Load(object sender, EventArgs e) {
            List<CultureInfo> availableLanguages = langMan.AvailableLanguages();
            foreach (CultureInfo culture in availableLanguages) comboBoxLanguage.Items.Add(culture.NativeName);
            comboBoxLanguage.SelectedItem = Tools.GetCultureByTwoLetterISO(Settings.Default.Language).NativeName;

            checkBoxAutorun.Checked       = Settings.Default.Autorun;
            checkBoxStartMin.Checked      = Settings.Default.StartMinimized;
            textBoxServerIp.Text          = Settings.Default.RconIP;
            textBoxServerPort.Text        = Settings.Default.RconPort.ToString();
            textBoxRconPw.Text            = Settings.Default.RconPW;
        }

        //*****************************
        // Event receivers
        //*****************************
        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            if (!Regex.IsMatch(textBoxServerIp.Text, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")) {
                MessageBox.Show(langMan.GetString("Settings_WrongIP"), langMan.GetString("MessageBoxErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            } else if (!Regex.IsMatch(textBoxServerPort.Text, @"\d{2,5}")) {
                MessageBox.Show(langMan.GetString("Settings_WrongPort"), langMan.GetString("MessageBoxErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            } else if (String.IsNullOrEmpty(textBoxRconPw.Text)) {
                MessageBox.Show(langMan.GetString("Settings_WrongRconPW"), langMan.GetString("MessageBoxErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            } else {
                Settings.Default.Language       = Tools.GetCultureByNativeName((string)comboBoxLanguage.SelectedItem).TwoLetterISOLanguageName;
                Settings.Default.Autorun        = checkBoxAutorun.Checked;
                Settings.Default.StartMinimized = checkBoxStartMin.Checked;
                Settings.Default.RconIP         = textBoxServerIp.Text;
                Settings.Default.RconPort       = Convert.ToInt32(textBoxServerPort.Text);
                Settings.Default.RconPW         = textBoxRconPw.Text;
                Settings.Default.Save();

                langMan.SwitchLang();
                Tools.SetAutorun(checkBoxAutorun.Checked);

                this.Close();
            }               
        }
    }
}
