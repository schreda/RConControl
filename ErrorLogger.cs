using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace RConControl {
    public class ErrorLogger {
        public static void Log(Exception ex) {
            StackTrace st = new StackTrace(ex);
            var frame = st.GetFrame(0);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("Log Entry: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            sb.AppendLine(String.Format("  Class   : {0}", frame.GetMethod().DeclaringType));
            sb.AppendLine(String.Format("  Method  : {0}", frame.GetMethod().Name));
            sb.AppendLine(String.Format("  Messsage: {0}", ex.Message));
            if (ex.Data.Count > 0) {
                sb.AppendLine("  Details:");
                foreach (DictionaryEntry entry in ex.Data) {
                    sb.AppendLine(String.Format("    Key: {0,-20}      Value: {1}", entry.Key, entry.Value));
                }
            }
            StreamWriter file = File.AppendText(GlobalConstants.PATH_ERRORLOG);
            file.WriteLine(sb.ToString());
            file.Close();
        }
    }
}
