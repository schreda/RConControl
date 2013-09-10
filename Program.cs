using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace RConControl {
    class Program {

        [STAThread]
        static void Main() {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(HandleUnhandledExceptions);

            if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)).Count() > 1) return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.frmRconUI());
        }

        static void HandleUnhandledExceptions(object sender, UnhandledExceptionEventArgs args) {
            ErrorLogger.Log((Exception)args.ExceptionObject);
        }
    }
}
