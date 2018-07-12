using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormAplicacao : Form
    {
        public int CodigoAplicacao { get; set; }

        public string DescricaoAplicacao { get; set; }

        public string SiglaAplicacao { get; set; }

        public int SequenciaAplicacao { get; set; }

        public string AtivaAplicacao { get; set; }

        public string FormAplicacao { get; set; }

        public int SearchType { get; set; }
        
        public FilterSearchFormAplicacao()
        {
            InitializeComponent();
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {
            if (tbControlAplicacao.SelectedIndex.Equals(0))
            {
                CodigoAplicacao = int.Parse(txtBxCodigo.Text);
            }

            if (tbControlAplicacao.SelectedIndex.Equals(1))
            {
                DescricaoAplicacao = txtBxDescricao.Text;
            }

            if (tbControlAplicacao.SelectedIndex.Equals(2))
            {
                SiglaAplicacao = txtBxSigla.Text;
            }
            if (tbControlAplicacao.SelectedIndex.Equals(3))
            {
                SequenciaAplicacao = int.Parse(txtBxSequencia.Text);
            }

            if (tbControlAplicacao.SelectedIndex.Equals(4))
            {
                AtivaAplicacao = (ckBxAtiva.Checked) ? "S" : "N";
            }

            if (tbControlAplicacao.SelectedIndex.Equals(5))
            {
                FormAplicacao = txtBxForm.Text;
            }

            SearchType = tbControlAplicacao.SelectedIndex;

            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
