using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormUsuarioGrupo : Form
    {
        public int CodigoEmpresa { get; set; }

        public int CodigoGrupo { get; set; }

        public string Usuario { get; set; }

        public int SearchType { get; set; }

        public FilterSearchFormUsuarioGrupo()
        {
            InitializeComponent();

            this.txtBxCodigoEmpresa.GotFocus += txtBxCodigoEmpresa_GotFocus;
            this.txtBxCodigoEmpresa.LostFocus += txtBxCodigoEmpresa_LostFocus;

            this.txtBxUsuario.GotFocus += txtBxUsuario_GotFocus;
            this.txtBxUsuario.LostFocus += txtBxUsuario_LostFocus;

            this.txtBxCodigoGrupo.GotFocus += txtBxCodigoGrupo_GotFocus;
            this.txtBxCodigoGrupo.LostFocus += txtBxCodigoGrupo_LostFocus;
        }

        void txtBxCodigoEmpresa_LostFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoEmpresa.BackColor = Color.White;
        }

        void txtBxCodigoEmpresa_GotFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoEmpresa.BackColor = Color.LightYellow;
        }

        void txtBxUsuario_LostFocus(object sender, EventArgs e)
        {
            this.txtBxUsuario.BackColor = Color.White;
        }

        void txtBxUsuario_GotFocus(object sender, EventArgs e)
        {
            this.txtBxUsuario.BackColor = Color.LightYellow;
        }

        void txtBxCodigoGrupo_LostFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoGrupo.BackColor = Color.White;
        }

        void txtBxCodigoGrupo_GotFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoGrupo.BackColor = Color.LightYellow;
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
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
                Usuario = txtBxUsuario.Text;
            }

            SearchType = tbControlUsuarioGrupo.SelectedIndex;

            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
