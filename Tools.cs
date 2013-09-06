using Microsoft.Win32;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Collections;
using System.Reflection;
using System.IO;

namespace RCONManager {
    public class Tools {

        public static CultureInfo GetCultureByTwoLetterISO(String twoLetter) {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures);
            var culture = cultures.FirstOrDefault(c =>
                c.TwoLetterISOLanguageName.Equals(twoLetter, StringComparison.InvariantCultureIgnoreCase));
            return culture;
        }

        public static CultureInfo GetCultureByNativeName(String nativeName) {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures);
            var culture = cultures.FirstOrDefault(c =>
                c.NativeName.Equals(nativeName, StringComparison.InvariantCultureIgnoreCase));
            return culture;
        }

        public static void SetAutorun(bool state) {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey(GlobalConstants.AUTORUN_REGKEY, true);

            if (state) rkApp.SetValue(Application.ProductName, Application.ExecutablePath.ToString());
            else rkApp.DeleteValue(Application.ProductName, false);
        }

        public static List<ConfigFile> GetAllConfigFiles() {
            List<ConfigFile> resultList = new List<ConfigFile>();
            string[] fileList = Directory.GetFiles(GlobalConstants.PATH_CONFIGS, "*.cfg");
            foreach (string file in fileList) {
                string[] readFile = File.ReadAllLines(file);

                if (readFile.Length > 0) {
                    string name = null;
                    StringBuilder fileContent = new StringBuilder();

                    foreach (string readLine in readFile) {
                        string line = readLine.Trim();

                        if (line.IndexOf("//") == 0 && line.Contains("Name:")) {
                            int startIdx = line.IndexOf(':') + 1;
                            name = line.Substring(startIdx, line.Length - startIdx);
                        } else if (name == null) {
                            name = file;
                        }
                        if (line.IndexOf("//") != 0 && !String.IsNullOrEmpty(line)) {
                            fileContent.AppendLine(line);
                        }

                    }
                    if (name != null && fileContent.Length > 0) {
                        resultList.Add(new ConfigFile(name, fileContent.ToString().TrimEnd('\r', '\n')));
                    }
                }
            }
            return resultList;
        }

    }
}
