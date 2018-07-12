using System;
using System.Drawing;
using System.Windows.Forms;
using BrSoftNet.Library.Messages;
using BrSoftNet.Library.Utilities;

namespace BrSoftNet.App.UI.Win.OverallRecord.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormEstado : Form
    {
        public string SiglaEstado { get; set; }

        public string Descricao { get; set; }

        public string SiglaRegiao { get; set; }

        public int SearchType { get; set; }

        public FilterSearchFormEstado()
        {
            InitializeComponent();

            this.txtBxSiglaEstado.GotFocus += txtBxSiglaEstado_GotFocus;
            this.txtBxSiglaEstado.LostFocus += txtBxSiglaEstado_LostFocus;

            this.txtBxDescricao.GotFocus += txtBxDescricao_GotFocus;
            this.txtBxDescricao.LostFocus += txtBxDescricao_LostFocus;

            this.txtBxSiglaRegiao.GotFocus += txtBxSiglaRegiao_GotFocus;
            this.txtBxSiglaRegiao.LostFocus += txtBxSiglaRegiao_LostFocus;
        }

        void txtBxSiglaEstado_LostFocus(object sender, EventArgs e)
        {
            this.txtBxSiglaEstado.BackColor = Color.White;
        }

        void txtBxSiglaEstado_GotFocus(object sender, EventArgs e)
        {
            this.txtBxSiglaEstado.BackColor = Color.LightYellow;
        }

        void txtBxDescricao_LostFocus(object sender, EventArgs e)
        {
            this.txtBxDescricao.BackColor = Color.White;
        }

        void txtBxDescricao_GotFocus(object sender, EventArgs e)
        {
            this.txtBxDescricao.BackColor = Color.LightYellow;
        }

        void txtBxSiglaRegiao_LostFocus(object sender, EventArgs e)
        {
            this.txtBxSiglaRegiao.BackColor = Color.White;
        }

        void txtBxSiglaRegiao_GotFocus(object sender, EventArgs e)
        {
            this.txtBxSiglaRegiao.BackColor = Color.LightYellow;
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {
            if (tbControlEstado.SelectedIndex.Equals(0))
            {
                SiglaEstado = txtBxSiglaEstado.Text;
            }

            if (tbControlEstado.SelectedIndex.Equals(1))
            {
                Descricao = txtBxDescricao.Text;
            }

            if (tbControlEstado.SelectedIndex.Equals(2))
            {
                SiglaRegiao = txtBxSiglaRegiao.Text;
            }

            SearchType = tbControlEstado.SelectedIndex;

            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /*------------------------------------ INICIO DAS VALIDAÇÕES ------------------------------------ */
        private void txtBxSiglaEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!ValidationData.CreateInstance.ValidaAceiteSomenteCaracteres(txtBxSiglaEstado.Text))
            {
                ErrPrvdrSiglaUf.SetError(txtBxSiglaEstado, ValidationsMessages.VALIDA_UF);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrSiglaUf.SetError(txtBxSiglaEstado, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxSiglaRegiao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBxSiglaRegiao.Text == string.Empty)
            {
                ErrPrvdrSiglaUf.SetError(txtBxSiglaRegiao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrSiglaUf.SetError(txtBxSiglaRegiao, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaAceiteSomenteCaracteres(txtBxSiglaRegiao.Text))
                {
                    ErrPrvdrSiglaUf.SetError(txtBxSiglaRegiao, ValidationsMessages.VALIDA_UF);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrSiglaUf.SetError(txtBxSiglaRegiao, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }
    }
}
