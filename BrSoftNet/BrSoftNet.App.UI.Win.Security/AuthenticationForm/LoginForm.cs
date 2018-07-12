using BrSoftNet.App.Business.Processes.Security.Entities;
using BrSoftNet.App.Business.Processes.Security.Tasks;
using BrSoftNet.Library.Messages;
using BrSoftNet.App.UI.Win.Main.State;
using BrSoftNet.App.UI.Win.Security.State;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Main.AuthenticationForm
{
    public partial class LoginForm : Form
    {
        public string Usuario { get; set; }
        public string Nome { get; set; }
        public List<EmpresaLogin> EmpresaLoginCollection { get; set; }
        public LoginForm()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();

            this.txtUser.GotFocus += txtUser_GotFocus;
            this.txtUser.LostFocus += txtUser_LostFocus;

            this.txtPassword.GotFocus += txtPassword_GotFocus;
            this.txtPassword.LostFocus += txtPassword_LostFocus;
        }

        void txtPassword_GotFocus(object sender, EventArgs e)
        {
            this.txtPassword.BackColor = Color.LightYellow;
        }

        void txtUser_LostFocus(object sender, EventArgs e)
        {
            this.txtUser.BackColor = Color.White;
        }

        void txtPassword_LostFocus(object sender, EventArgs e)
        {
            this.txtPassword.BackColor = Color.White;
        }

        void txtUser_GotFocus(object sender, EventArgs e)
        {
            this.txtUser.BackColor = Color.LightYellow;
        }

        private void InicialiazeUpdateForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, EventArgs e)
        {
            DataSet _dsLogin = null;
            UsuarioLogin _UsuarioLogin = null;
            List<EmpresaLogin> _EmpresaLoginCollection = new List<EmpresaLogin>();

            AppStateSecurity.Senha = txtPassword.Text;

            _dsLogin = AccessTask.CreateInstance.GetLoginTask(txtUser.Text, txtPassword.Text);

            if ((_dsLogin.Tables[0].Rows.Count > 0) && (_dsLogin.Tables[1].Rows.Count > 0))
            {
                if (_dsLogin.Tables[0].Rows.Count.Equals(1))
                {
                    _UsuarioLogin = new UsuarioLogin(_dsLogin.Tables[0].Rows[0]);

                    AppStateSecurity.Usuario = _UsuarioLogin.Usuario;
                    AppStateSecurity.Nome = _UsuarioLogin.Nome;

                    Usuario = AppStateSecurity.Usuario;
                    Nome = AppStateSecurity.Nome;
                }

                if (_dsLogin.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow _Row in _dsLogin.Tables[1].Rows)
                    {
                        _EmpresaLoginCollection.Add(new EmpresaLogin(_Row));
                    }

                    AppStateSecurity.EmpresaLoginCollection = _EmpresaLoginCollection;

                    EmpresaLoginCollection = AppStateSecurity.EmpresaLoginCollection;
                }

                this.Close();
            }
            else 
            {
                AppStateSession.LogonNumber++;

                switch (AppStateSession.LogonNumber)
                {
                    case 1:
                        MessageBox.Show(string.Format(FormsMessages.NroTentativasLogin, AppStateSession.LogonNumber), 
                                        FormsMessages.LoginDoSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    case 2:
                        MessageBox.Show(string.Format(FormsMessages.NroTentativasLogin, AppStateSession.LogonNumber),
                                        FormsMessages.LoginDoSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    case 3:
                        MessageBox.Show(string.Format(FormsMessages.NroTentativasLogoff, AppStateSession.LogonNumber),
                                        FormsMessages.LoginDoSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        Application.Exit();
                        break;
                    default:
                        break;
                }
            }
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tlstrpActionMenuBtnConfirm_Click(sender, e);
            }
        }
    }
}
