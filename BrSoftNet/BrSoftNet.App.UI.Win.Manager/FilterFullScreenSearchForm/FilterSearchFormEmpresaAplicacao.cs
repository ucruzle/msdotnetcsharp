using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormEmpresaAplicacao : Form
    {
        public int CodigoEmpresa { get; set; }

        public int CodigoAplicacao { get; set; }

        public int SearchType { get; set; }

        public FilterSearchFormEmpresaAplicacao()
        {
            InitializeComponent();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {
            ActionMenuBtnConfirm();
        }

        private void ActionMenuBtnConfirm()
        {
            if (tbControlEmpresaAplicacao.SelectedIndex.Equals(0))
            {
                CodigoEmpresa = int.Parse(txtBxCodigoEmpresa.Text);
            }

            if (tbControlEmpresaAplicacao.SelectedIndex.Equals(1))
            {
                CodigoAplicacao = int.Parse(txtBxCodigoAplicacao.Text);
            }

            SearchType = tbControlEmpresaAplicacao.SelectedIndex;

            this.Close();
        }
    }
}
