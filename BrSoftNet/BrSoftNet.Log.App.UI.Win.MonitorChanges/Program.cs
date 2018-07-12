using BrSoftNet.App.UI.Win.Security.SplashForm;
using System;
using System.Windows.Forms;

namespace BrSoftNet.Log.App.UI.Win.MonitorChanges
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSplashMain());
        }
    }
}
