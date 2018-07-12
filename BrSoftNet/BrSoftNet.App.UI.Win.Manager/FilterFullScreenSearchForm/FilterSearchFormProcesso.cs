using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormProcesso : Form
    {
        public int CodigoProcesso { get; set; }

        public string DescricaoProcesso { get; set; }

        public int CodigoTipoProcesso { get; set; }

        public int CodigoAplicacao { get; set; }

        public string Ativo { get; set; }

        public string Form { get; set; }

        public int SequenciaProcesso { get; set; }

        public int SearchType { get; set; }

        public FilterSearchFormProcesso()
        {
            InitializeComponent();

            this.txtBxCodigoProcesso.GotFocus += txtBxCodigoProcesso_GotFocus;
            this.txtBxCodigoProcesso.LostFocus += txtBxCodigoProcesso_LostFocus;

            this.txtBxDescricaoProcesso.GotFocus += txtBxDescricaoProcesso_GotFocus;
            this.txtBxDescricaoProcesso.LostFocus += txtBxDescricaoProcesso_LostFocus;

            this.txtBxCodigoTipoProcesso.GotFocus += txtBxCodigoTipoProcesso_GotFocus;
            this.txtBxCodigoTipoProcesso.LostFocus += txtBxCodigoTipoProcesso_LostFocus;

            this.txtBxCodigoAplicacao.GotFocus += txtBxCodigoAplicacao_GotFocus;
            this.txtBxCodigoAplicacao.LostFocus += txtBxCodigoAplicacao_LostFocus;

            this.txtBxForm.GotFocus += txtBxForm_GotFocus;
            this.txtBxForm.LostFocus += txtBxForm_LostFocus;
        }

        void txtBxCodigoProcesso_LostFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoProcesso.BackColor = Color.White;
        }

        void txtBxCodigoProcesso_GotFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoProcesso.BackColor = Color.LightYellow;
        }

        void txtBxDescricaoProcesso_LostFocus(object sender, EventArgs e)
        {
            this.txtBxDescricaoProcesso.BackColor = Color.White;
        }

        void txtBxDescricaoProcesso_GotFocus(object sender, EventArgs e)
        {
            this.txtBxDescricaoProcesso.BackColor = Color.LightYellow;
        }

        void txtBxCodigoTipoProcesso_LostFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoTipoProcesso.BackColor = Color.White;
        }

        void txtBxCodigoTipoProcesso_GotFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoTipoProcesso.BackColor = Color.LightYellow;
        }

        void txtBxCodigoAplicacao_LostFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoAplicacao.BackColor = Color.White;
        }

        void txtBxCodigoAplicacao_GotFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoAplicacao.BackColor = Color.LightYellow;
        }

        void txtBxForm_LostFocus(object sender, EventArgs e)
        {
            this.txtBxForm.BackColor = Color.White;
        }

        void txtBxForm_GotFocus(object sender, EventArgs e)
        {
            this.txtBxForm.BackColor = Color.LightYellow;
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {
            if (tbControlProcesso.SelectedIndex.Equals(0))
            {
                CodigoProcesso = int.Parse(txtBxCodigoProcesso.Text);
            }

            if (tbControlProcesso.SelectedIndex.Equals(1))
            {
                DescricaoProcesso = txtBxDescricaoProcesso.Text;
            }

            if (tbControlProcesso.SelectedIndex.Equals(2))
            {
                CodigoTipoProcesso = int.Parse(txtBxCodigoTipoProcesso.Text);
            }

            if (tbControlProcesso.SelectedIndex.Equals(3))
            {
                CodigoAplicacao = int.Parse(txtBxCodigoAplicacao.Text);
            }

            if (tbControlProcesso.SelectedIndex.Equals(4))
            {
                Ativo = (ckBxAtiva.Checked) ? "S" : "N";
            }

            if (tbControlProcesso.SelectedIndex.Equals(5))
            {
                Form = txtBxForm.Text;
            }

            if (tbControlProcesso.SelectedIndex.Equals(6))
            {
                SequenciaProcesso = 0;
            }

            SearchType = tbControlProcesso.SelectedIndex;

            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
