using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormUsuario : Form
    {
        public string Usuario { get; set; }

        public string Nome { get; set; }

        public int CodigoEmpresa { get; set; }

        public int CodigoRG { get; set; }

        public string StatusDBA { get; set; }

        public DateTime DataCadastro { get; set; }

        public string Ativo { get; set; }

        public int SearchType { get; set; }

        public FilterSearchFormUsuario()
        {
            InitializeComponent();

            this.txtBxUsuario.GotFocus += txtBxUsuario_GotFocus;
            this.txtBxUsuario.LostFocus += txtBxUsuario_LostFocus;

            this.txtBxNome.GotFocus += txtBxNome_GotFocus;
            this.txtBxNome.LostFocus += txtBxNome_LostFocus;

            this.txtBxCodigoEmpresa.GotFocus += txtBxCodigoEmpresa_GotFocus;
            this.txtBxCodigoEmpresa.LostFocus += txtBxCodigoEmpresa_LostFocus;

            this.txtBxCodigoRG.GotFocus += txtBxCodigoRG_GotFocus;
            this.txtBxCodigoRG.LostFocus += txtBxCodigoRG_LostFocus;

            this.txtBxStatusDBA.GotFocus += txtBxStatusDBA_GotFocus;
            this.txtBxStatusDBA.LostFocus += txtBxStatusDBA_LostFocus;

            this.txtBxDataCadastro.GotFocus += txtBxDataCadastro_GotFocus;
            this.txtBxDataCadastro.LostFocus += txtBxDataCadastro_LostFocus;
        }

        void txtBxUsuario_LostFocus(object sender, EventArgs e)
        {
            this.txtBxUsuario.BackColor = Color.White;
        }

        void txtBxUsuario_GotFocus(object sender, EventArgs e)
        {
            this.txtBxUsuario.BackColor = Color.LightYellow;
        }

        void txtBxNome_LostFocus(object sender, EventArgs e)
        {
            this.txtBxNome.BackColor = Color.White;
        }

        void txtBxNome_GotFocus(object sender, EventArgs e)
        {
            this.txtBxNome.BackColor = Color.LightYellow;
        }

        void txtBxCodigoEmpresa_LostFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoEmpresa.BackColor = Color.White;
        }

        void txtBxCodigoEmpresa_GotFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoEmpresa.BackColor = Color.LightYellow;
        }

        void txtBxCodigoRG_LostFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoRG.BackColor = Color.White;
        }

        void txtBxCodigoRG_GotFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoRG.BackColor = Color.LightYellow;
        }

        void txtBxStatusDBA_LostFocus(object sender, EventArgs e)
        {
            this.txtBxStatusDBA.BackColor = Color.White;
        }

        void txtBxStatusDBA_GotFocus(object sender, EventArgs e)
        {
            this.txtBxStatusDBA.BackColor = Color.LightYellow;
        }

        void txtBxDataCadastro_LostFocus(object sender, EventArgs e)
        {
            this.txtBxDataCadastro.BackColor = Color.White;
        }

        void txtBxDataCadastro_GotFocus(object sender, EventArgs e)
        {
            this.txtBxDataCadastro.BackColor = Color.LightYellow;
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {
            if (tbControlUsuario.SelectedIndex.Equals(0))
            {
                Usuario = txtBxUsuario.Text;
            }

            if (tbControlUsuario.SelectedIndex.Equals(1))
            {
                Nome = txtBxNome.Text;
            }

            if (tbControlUsuario.SelectedIndex.Equals(2))
            {
                CodigoEmpresa = int.Parse(txtBxCodigoEmpresa.Text);
            }

            if (tbControlUsuario.SelectedIndex.Equals(3))
            {
                CodigoRG = int.Parse(txtBxCodigoRG.Text);
            }

            if (tbControlUsuario.SelectedIndex.Equals(4))
            {
                Ativo = (ckBxAtiva.Checked) ? "S" : "N";
            }

            if (tbControlUsuario.SelectedIndex.Equals(5))
            {
                DataCadastro = DateTime.Parse(txtBxCodigoRG.Text);
            }

            if (tbControlUsuario.SelectedIndex.Equals(6))
            {
                StatusDBA = txtBxStatusDBA.Text;
            }

            SearchType = tbControlUsuario.SelectedIndex;

            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
