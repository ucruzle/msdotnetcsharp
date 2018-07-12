using System;
using System.Drawing;
using System.Windows.Forms;
using BrSoftNet.Library.Messages;
using BrSoftNet.Library.Utilities;

namespace BrSoftNet.App.UI.Win.OverallRecord.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormTipoFone : Form
    {
        public int IdTipoFone { get; set; }

        public string DescrTipoFone { get; set; }

        public int SearchType { get; set; }

        public FilterSearchFormTipoFone()
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
            if (tbControlTipoFone.SelectedIndex.Equals(0))
            {
                IdTipoFone = int.Parse(txtBxCodigo.Text);
            }

            if (tbControlTipoFone.SelectedIndex.Equals(1))
            {
                DescrTipoFone = txtBxDescricao.Text;
            }

            SearchType = tbControlTipoFone.SelectedIndex;

            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void txtBxCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!ValidationData.CreateInstance.ValidaAceiteSomenteNumeros(txtBxCodigo.Text))
            {
                ErrPrvdrTipoFone.SetError(txtBxCodigo, ValidationsMessages.VALIDA_CODIGO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrTipoFone.SetError(txtBxCodigo, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }      
        }

        private void txtBxDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrTipoFone.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrTipoFone.SetError(txtBxDescricao, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }
    }
}
