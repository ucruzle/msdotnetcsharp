using System;
using System.Drawing;
using System.Windows.Forms;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Library.Messages;

namespace BrSoftNet.App.UI.Win.OverallRecord.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormRegiao : Form
    {
        public string Sigla { get; set; }

        public string Descricao { get; set; }

        public int SearchType { get; set; }

        public FilterSearchFormRegiao()
        {
            InitializeComponent();

            this.txtBxSigla.GotFocus += txtBxSigla_GotFocus;
            this.txtBxSigla.LostFocus += txtBxSigla_LostFocus;

            this.txtBxDescricao.GotFocus += txtBxDescricao_GotFocus;
            this.txtBxDescricao.LostFocus += txtBxDescricao_LostFocus;
        }

        void txtBxSigla_LostFocus(object sender, EventArgs e)
        {
            this.txtBxSigla.BackColor = Color.White;
        }

        void txtBxSigla_GotFocus(object sender, EventArgs e)
        {
            this.txtBxSigla.BackColor = Color.LightYellow;
        }

        void txtBxDescricao_LostFocus(object sender, EventArgs e)
        {
            this.txtBxDescricao.BackColor = Color.White;
        }

        void txtBxDescricao_GotFocus(object sender, EventArgs e)
        {
            this.txtBxDescricao.BackColor = Color.LightYellow;
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {
            if (tbControlRegiao.SelectedIndex.Equals(0))
            {
                Sigla = txtBxSigla.Text;
            }

            if (tbControlRegiao.SelectedIndex.Equals(1))
            {
                Descricao = txtBxDescricao.Text;
            }

            SearchType = tbControlRegiao.SelectedIndex;

            this.Close();
        }

        /* -------------------------------------- INICIO BLOCO DE VALIDAÇÕES -------------------------------------- */
        private void txtBxSigla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBxSigla.Text == string.Empty)
            {
                ErrPrvdrRegiao.SetError(txtBxSigla, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrRegiao.SetError(txtBxSigla, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaAceiteSomenteCaracteres(txtBxSigla.Text))
                {
                    ErrPrvdrRegiao.SetError(txtBxSigla, ValidationsMessages.VALIDA_SIGLA);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrRegiao.SetError(txtBxSigla, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrRegiao.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrRegiao.SetError(txtBxDescricao, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }
    }
}
