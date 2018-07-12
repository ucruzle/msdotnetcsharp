using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormEmpresaConsolidada : Form
    {
        public int CodigoEmpresaConsolidada { get; set; }

        public string DescricaoEmpresaConsolidada { get; set; }

        public string AtivaEmpresaConsolidada { get; set; }

        public int SearchType { get; set; }    

        public FilterSearchFormEmpresaConsolidada()
        {
            InitializeComponent();

            this.txtBxCodEmpresa.GotFocus += txtBxCodEmpresa_GotFocus;
            this.txtBxCodEmpresa.LostFocus += txtBxCodEmpresa_LostFocus;

            this.txtBxDescricao.GotFocus += txtBxDescricao_GotFocus;
            this.txtBxDescricao.LostFocus += txtBxDescricao_LostFocus;
        }

        void txtBxCodEmpresa_LostFocus(object sender, EventArgs e)
        {
            this.txtBxCodEmpresa.BackColor = Color.White;
        }

        void txtBxCodEmpresa_GotFocus(object sender, EventArgs e)
        {
            this.txtBxCodEmpresa.BackColor = Color.LightYellow;
        }

        void txtBxDescricao_LostFocus(object sender, EventArgs e)
        {
            this.txtBxDescricao.BackColor = Color.White;
        }

        void txtBxDescricao_GotFocus(object sender, EventArgs e)
        {
            this.txtBxDescricao.BackColor = Color.LightYellow;
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {
            if (tbControlEmpresaConsolidada.SelectedIndex.Equals(0))
            {
                CodigoEmpresaConsolidada = int.Parse(txtBxCodEmpresa.Text);
            }

            if (tbControlEmpresaConsolidada.SelectedIndex.Equals(1))
            {
                DescricaoEmpresaConsolidada = txtBxDescricao.Text;
            }

            if (tbControlEmpresaConsolidada.SelectedIndex.Equals(2))
            {
                AtivaEmpresaConsolidada = (ckBxAtiva.Checked) ? "S" : "N";
            }

            SearchType = tbControlEmpresaConsolidada.SelectedIndex;

            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
