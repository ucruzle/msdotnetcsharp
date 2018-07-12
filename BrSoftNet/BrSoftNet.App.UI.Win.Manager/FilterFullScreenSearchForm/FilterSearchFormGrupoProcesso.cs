using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormGrupoProcesso : Form
    {
        public int CodigoEmpresa { get; set; }

        public int CodigoGrupo { get; set; }

        public int CodigoProcesso { get; set; }

        public int SearchType { get; set; }

        public FilterSearchFormGrupoProcesso()
        {
            InitializeComponent();

            this.txtBxCodigoEmpresa.GotFocus += txtBxCodigoEmpresa_GotFocus;
            this.txtBxCodigoEmpresa.LostFocus += txtBxCodigoEmpresa_LostFocus;

            this.txtBxCodigoGrupo.GotFocus += txtBxCodigoGrupo_GotFocus;
            this.txtBxCodigoGrupo.LostFocus += txtBxCodigoGrupo_LostFocus;

            this.txtBxCodigoProcesso.GotFocus += txtBxCodigoProcesso_GotFocus;
            this.txtBxCodigoProcesso.LostFocus += txtBxCodigoProcesso_LostFocus;
        }

        void txtBxCodigoEmpresa_LostFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoEmpresa.BackColor = Color.White;
        }

        void txtBxCodigoEmpresa_GotFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoEmpresa.BackColor = Color.LightYellow;
        }

        void txtBxCodigoGrupo_LostFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoGrupo.BackColor = Color.White;
        }

        void txtBxCodigoGrupo_GotFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoGrupo.BackColor = Color.LightYellow;
        }

        void txtBxCodigoProcesso_LostFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoProcesso.BackColor = Color.White;
        }

        void txtBxCodigoProcesso_GotFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoProcesso.BackColor = Color.LightYellow;
        }

        private void tlstrpActionMenuBtnConfirm_Click_1(object sender, EventArgs e)
        {
            if (tbControlUsuarioGrupo.SelectedIndex.Equals(0))
            {
                CodigoEmpresa = int.Parse(txtBxCodigoEmpresa.Text);
            }

            if (tbControlUsuarioGrupo.SelectedIndex.Equals(1))
            {
                CodigoGrupo = int.Parse(txtBxCodigoGrupo.Text);
            }

            if (tbControlUsuarioGrupo.SelectedIndex.Equals(2))
            {
                CodigoProcesso = int.Parse(txtBxCodigoProcesso.Text);
            }

            SearchType = tbControlUsuarioGrupo.SelectedIndex;

            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
