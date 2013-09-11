using RConControl.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;

namespace RConControl {
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
            res_man = new ResourceManager("RConControl.Resources.Language.lang", Assembly.GetExecutingAssembly());
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
            string result = "";
            if (!String.IsNullOrEmpty(key)) {
                try {
                    result = res_man.GetString(key, cul);
                } catch (Exception ex) {
                    ex.Data.Add("key", key);
                    ErrorLogger.Log(ex);
                }
            }
            return result;
        }

        // Private helper methods
        private void InitLang() {
            if (String.IsNullOrEmpty(Settings.Default.Language)) {
                CultureInfo systemCulture = (CultureInfo.CurrentUICulture.IsNeutralCulture ? CultureInfo.CurrentUICulture : CultureInfo.CurrentUICulture.Parent);
                Settings.Default.Language = (AvailableLanguages().Contains(systemCulture) ? systemCulture.TwoLetterISOLanguageName : new CultureInfo("en").TwoLetterISOLanguageName);
                Settings.Default.Save();
            }
            cul = Tools.GetCultureByTwoLetterISO(Settings.Default.Language);
        }

        public void SwitchLang() {
            InitLang();
            SwitchLangEvent();
        }
    }
}