using BrSoftNet.Log.App.UI.Win.MonitorChanges;
using System;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Security.SplashForm
{
    public partial class frmSplashMain : Form
    {
        public frmSplashMain()
        {
            InitializeComponent();
        }

        private void tmrFormSplash_Tick(object sender, EventArgs e)
        {
            if (prgBarFormSplash.Value >= 100)
            {
                tmrFormSplash.Enabled = false;
                frmDashboard _frmMain = new frmDashboard();
                this.Hide();
                _frmMain.ShowDialog();
                this.Close();
            }
            else 
            {
                prgBarFormSplash.Value += 10;
                prgBarFormSplash.PerformStep();
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}
