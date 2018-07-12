using System;
using System.Drawing;
using System.Windows.Forms;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Library.Messages;

namespace BrSoftNet.App.UI.Win.OverallRecord.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormStatus : Form
    {
        public int IdRgStatus { get; set; }

        public string DescrStatus { get; set; }

        public int SearchType { get; set; }

        public FilterSearchFormStatus()
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
                IdRgStatus = int.Parse(txtBxCodigo.Text);
            }

            if (tbControlStatus.SelectedIndex.Equals(1))
            {
                DescrStatus = txtBxDescricao.Text;
            }

            SearchType = tbControlStatus.SelectedIndex;

            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void txtBxCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBxCodigo.Text == string.Empty)
            {
                ErrPrvdrStatus.SetError(txtBxCodigo, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrStatus.SetError(txtBxCodigo, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaAceiteSomenteNumeros(txtBxCodigo.Text))
                {
                    ErrPrvdrStatus.SetError(txtBxCodigo, ValidationsMessages.VALIDA_CODIGO);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrStatus.SetError(txtBxCodigo, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrStatus.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrStatus.SetError(txtBxDescricao, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }

        }
    }
}
