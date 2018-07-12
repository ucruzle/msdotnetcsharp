using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormEmpresa : Form
    {
        public int CodigoEmpresa { get; set; }

        public string DescricaoEmpresa { get; set; }

        public int SearchType { get; set; }

        public FilterSearchFormEmpresa()
        {
            InitializeComponent();

            this.txtBxCodigoEmpresa.GotFocus += txtBxCodigoEmpresa_GotFocus;
            this.txtBxCodigoEmpresa.LostFocus += txtBxCodigoEmpresa_LostFocus;

            this.txtBxDescricao.GotFocus += txtBxDescricao_GotFocus;
            this.txtBxDescricao.LostFocus += txtBxDescricao_LostFocus;
        }

        void txtBxCodigoEmpresa_LostFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoEmpresa.BackColor = Color.White;
        }

        void txtBxCodigoEmpresa_GotFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoEmpresa.BackColor = Color.LightYellow;
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
            if (tbControlEmpresa.SelectedIndex.Equals(0))
            {
                CodigoEmpresa = int.Parse(txtBxCodigoEmpresa.Text);
            }

            if (tbControlEmpresa.SelectedIndex.Equals(1))
            {
                DescricaoEmpresa = txtBxDescricao.Text;
            }

            SearchType = tbControlEmpresa.SelectedIndex;

            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
