using RCONManager.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;

namespace RCONManager {
    public class Language {

        // Singleton
        private static Language instance;
        public static Language Instance {
            get {
                if (instance == null) {
                    instance = new Language();
                }
                return instance;
            }
        }

        //*************************************************
        // Variables
        //*************************************************
        private static ResourceManager res_man;
        private static CultureInfo cul;

        public delegate void VoidHandler();
        public event VoidHandler SwitchLangEvent;

        //*************************************************
        // CTor
        //*************************************************
        private Language() {
            res_man = new ResourceManager("RCONManager.Resources.Language.lang", typeof(frmRconUI).Assembly);
            InitLang();
        }

        //*************************************************
        // Methods
        //*************************************************
        public List<CultureInfo> AvailableLanguages() {
            List<CultureInfo> resultList = new List<CultureInfo>();
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures);
            foreach (CultureInfo culture in cultures) {
                ResourceSet rs = res_man.GetResourceSet(culture, true, false);
                if (rs != null) resultList.Add(culture);
            }
            return resultList;
        }

        public string GetString(string key) {
            if (String.IsNullOrEmpty(key)) return "";
            return res_man.GetString(key, cul);
        }

        private void InitLang() {
            if (String.IsNullOrEmpty(Settings.Default.Language)) {
                if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "de") {
                    cul = CultureInfo.CreateSpecificCulture("de");
                    Settings.Default.Language = "de";
                } else {
                    cul = CultureInfo.CreateSpecificCulture("en");
                    Settings.Default.Language = "en";
                }
            } else {
                cul = CultureInfo.CreateSpecificCulture(Settings.Default.Language);
            }
        }

        public void SwitchLang() {
            InitLang();
            SwitchLangEvent();
        }
    }
}