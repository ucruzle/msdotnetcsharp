using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormGrupo : Form
    {
        public int CodigoGrupo { get; set; }

        public string DescricaoGrupo { get; set; }

        public int SearchType { get; set; }

        public FilterSearchFormGrupo()
        {
            InitializeComponent();

            this.txtBxCodigo.GotFocus += txtBxCodigo_GotFocus;
            this.txtBxCodigo.LostFocus += txtBxCodigo_LostFocus;

            this.txtBxDescricao.GotFocus += txtBxDescricao_GotFocus;
            this.txtBxDescricao.LostFocus += txtBxDescricao_LostFocus;
        }

        void txtBxCodigo_LostFocus(object sender, EventArgs e)
        {
            this.txtBxCodigo.BackColor = Color.White;
        }

        void txtBxCodigo_GotFocus(object sender, EventArgs e)
        {
            this.txtBxCodigo.BackColor = Color.LightYellow;
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
            if (tbControlGrupo.SelectedIndex.Equals(0))
            {
                CodigoGrupo = int.Parse(txtBxCodigo.Text);
            }

            if (tbControlGrupo.SelectedIndex.Equals(1))
            {
                DescricaoGrupo = txtBxDescricao.Text;
            }

            SearchType = tbControlGrupo.SelectedIndex;

            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
