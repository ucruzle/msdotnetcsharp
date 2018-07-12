using System;
using System.Drawing;
using System.Windows.Forms;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Library.Messages;

namespace BrSoftNet.App.UI.Win.OverallRecord.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormNatureza : Form
    {
        public int IdNatureza { get; set; }

        public string DescrNatureza { get; set; }

        public int SearchType { get; set; }

        public FilterSearchFormNatureza()
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
            if (tbControlStatus.SelectedIndex.Equals(0))
            {
                IdNatureza = int.Parse(txtBxCodigo.Text);
            }

            if (tbControlStatus.SelectedIndex.Equals(1))
            {
                DescrNatureza = txtBxDescricao.Text;
            }

            SearchType = tbControlStatus.SelectedIndex;

            this.Close(); 
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /* -------------------------------------- INICIO BLOCO DE VALIDAÇÕES -------------------------------------- */
        private void txtBxCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBxCodigo.Text == string.Empty)
            {
                ErrPrvdrNatureza.SetError(txtBxCodigo, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrNatureza.SetError(txtBxCodigo, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaAceiteSomenteNumeros(txtBxCodigo.Text))
                {
                    ErrPrvdrNatureza.SetError(txtBxCodigo, ValidationsMessages.VALIDA_CODIGO);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrNatureza.SetError(txtBxCodigo, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrNatureza.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrNatureza.SetError(txtBxDescricao, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }
    }
}
