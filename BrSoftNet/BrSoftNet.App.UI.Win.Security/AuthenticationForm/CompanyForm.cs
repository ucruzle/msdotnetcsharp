using BrSoftNet.App.Business.Processes.Security.Entities;
using BrSoftNet.App.Business.Processes.Security.Tasks;
using BrSoftNet.App.UI.Win.Main.State;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Main.AuthenticationForm
{
    public partial class CompanyForm : Form
    {        
        public int CodigoEmpresa { get; set; }
        public string NomeFantasia { get; set; }
        public List<AplicacaoLogin> AplicacaoLoginCollection { get; set; }

        public CompanyForm()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();
            this.cmbxNomeFantasia.GotFocus +=cmbxNomeFantasia_GotFocus;
            this.cmbxNomeFantasia.LostFocus += cmbxNomeFantasia_LostFocus;
        }

        void cmbxNomeFantasia_LostFocus(object sender, EventArgs e)
        {
            this.cmbxNomeFantasia.BackColor = Color.White;
        }

        void cmbxNomeFantasia_GotFocus(object sender, EventArgs e)
        {
            this.cmbxNomeFantasia.BackColor = Color.LightYellow;
        }

        private void InicialiazeUpdateForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (AppStateSecurity.EmpresaLoginCollection != null)
            {
                cmbxNomeFantasia.DataSource = AppStateSecurity.EmpresaLoginCollection;
                cmbxNomeFantasia.ValueMember = "CodigoEmpresa";
                cmbxNomeFantasia.DisplayMember = "NomeFantasia";

                AppStateSecurity.CodigoEmpresa = Convert.ToInt32(cmbxNomeFantasia.SelectedValue);

                txtRazaoSocial.Text = AccessTask.CreateInstance.GetRazaoSocialTask(AppStateSecurity.CodigoEmpresa).RazaoSocial;

                if ((!string.IsNullOrEmpty(AppStateSecurity.Usuario)) && (AppStateSecurity.CodigoEmpresa > 0))
                {
                    AppStateSecurity.AplicacaoLoginCollection = AccessTask.CreateInstance.GetAplicacaoLoginTask(AppStateSecurity.Usuario, AppStateSecurity.CodigoEmpresa);
                }

                if (AppStateSecurity.CodigoEmpresa > 0)
                {
                    AppStateSecurity.NomeFantasia = AccessTask.CreateInstance.GetNomeFantasiaTask(AppStateSecurity.CodigoEmpresa).NomeFantasia;
                }             
                
                CodigoEmpresa = AppStateSecurity.CodigoEmpresa;
                NomeFantasia = AppStateSecurity.NomeFantasia;
                AplicacaoLoginCollection = AppStateSecurity.AplicacaoLoginCollection;
            }
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, EventArgs e)
        {
            this.InicialiazeUpdateForm();

            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CompanyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tlstrpActionMenuBtnConfirm_Click(sender, e);
            }
        }
    }
}
