using System;
using System.Drawing;
using System.Windows.Forms;
using BrSoftNet.Library.Messages;
using BrSoftNet.Library.Utilities;

namespace BrSoftNet.App.UI.Win.OverallRecord.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormMunicipio : Form
    {
        public int CodigoMunicipio { get; set; }

        public string Descricao { get; set; }

        public string SiglaEstado { get; set; }

        public int SearchType { get; set; }

        public FilterSearchFormMunicipio()
        {
            InitializeComponent();

            this.txtBxCodigoMunicipio.GotFocus += txtBxCodigoMunicipio_GotFocus;
            this.txtBxCodigoMunicipio.LostFocus += txtBxCodigoMunicipio_LostFocus;

            this.txtBxDescricao.GotFocus += txtBxDescricao_GotFocus;
            this.txtBxDescricao.LostFocus += txtBxDescricao_LostFocus;

            this.txtBxEstado.GotFocus += txtBxEstado_GotFocus;
            this.txtBxEstado.LostFocus += txtBxEstado_LostFocus;
        }

        void txtBxCodigoMunicipio_LostFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoMunicipio.BackColor = Color.White;
        }

        void txtBxCodigoMunicipio_GotFocus(object sender, EventArgs e)
        {
            this.txtBxCodigoMunicipio.BackColor = Color.LightYellow;
        }

        void txtBxDescricao_LostFocus(object sender, EventArgs e)
        {
            this.txtBxDescricao.BackColor = Color.White;
        }

        void txtBxDescricao_GotFocus(object sender, EventArgs e)
        {
            this.txtBxDescricao.BackColor = Color.LightYellow;
        }

        void txtBxEstado_LostFocus(object sender, EventArgs e)
        {
            this.txtBxEstado.BackColor = Color.White;
        }

        void txtBxEstado_GotFocus(object sender, EventArgs e)
        {
            this.txtBxEstado.BackColor = Color.LightYellow;
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {
            if (tbControlMunicipio.SelectedIndex.Equals(0))
            {
                CodigoMunicipio = int.Parse(txtBxCodigoMunicipio.Text);
            }

            if (tbControlMunicipio.SelectedIndex.Equals(1))
            {
                Descricao = txtBxDescricao.Text;
            }

            if (tbControlMunicipio.SelectedIndex.Equals(2))
            {
                SiglaEstado = txtBxEstado.Text;
            }

            SearchType = tbControlMunicipio.SelectedIndex;

            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /* -------------------------------------- INICIO BLOCO DE VALIDAÇÕES -------------------------------------- */
        private void txtBxCodigoMunicipio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBxCodigoMunicipio.Text == string.Empty)
            {
                ErrPrvdrMunicipio.SetError(txtBxCodigoMunicipio, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrMunicipio.SetError(txtBxCodigoMunicipio, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaAceiteSomenteNumeros(txtBxCodigoMunicipio.Text))
                {
                    ErrPrvdrMunicipio.SetError(txtBxCodigoMunicipio, ValidationsMessages.VALIDA_CODIGO);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrMunicipio.SetError(txtBxCodigoMunicipio, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrMunicipio.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrMunicipio.SetError(txtBxDescricao, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBxEstado.Text == string.Empty)
            {
                ErrPrvdrMunicipio.SetError(txtBxEstado, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrMunicipio.SetError(txtBxEstado, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaAceiteSomenteCaracteres(txtBxEstado.Text))
                {
                    ErrPrvdrMunicipio.SetError(txtBxEstado, ValidationsMessages.VALIDA_SIGLA_REGIAO);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrMunicipio.SetError(txtBxEstado, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }
    }
}
