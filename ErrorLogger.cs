﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;

namespace RConControl {
    public class ErrorLogger {
        public static void Log(Exception ex) {
            // get all exceptions recursive
            //if (ex.InnerException != null) Log(ex.InnerException);

            StackTrace st = new StackTrace(ex);
            StackFrame frame = st.GetFrame(0);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format("Log Entry: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            if (frame != null) {
                sb.AppendLine(String.Format("  Class   : {0}", frame.GetMethod().DeclaringType));
                sb.AppendLine(String.Format("  Method  : {0}", frame.GetMethod().Name));
            }

            // get details
            sb.AppendLine(String.Format("  Messsage: {0}", ex.Message));
            if (ex.Data.Count > 0) {
                sb.AppendLine("  Details:");
                foreach (DictionaryEntry entry in ex.Data) {
                    sb.AppendLine(String.Format("    Key: {0,-20}      Value: {1}", entry.Key, entry.Value));
                }
            }

            string pathFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), GlobalConstants.PATH_APPDATA);
            string pathFile = GlobalConstants.PATH_ERRORLOG;
            try {
                Directory.CreateDirectory(pathFolder);
                using (StreamWriter file = File.AppendText(Path.Combine(pathFolder, pathFile))) {
                    file.WriteLine(sb.ToString());
                }
            } catch (Exception exception) {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
