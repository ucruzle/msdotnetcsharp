using System;
using System.Drawing;
using System.Windows.Forms;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Library.Messages;

namespace BrSoftNet.App.UI.Win.OverallRecord.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormTipoRg : Form
    {
        public string TipoRg { get; set; }

        public string Descricao { get; set; }

        public int SearchType { get; set; }

        public FilterSearchFormTipoRg()
        {
            InitializeComponent();

            this.txtBxTipo.GotFocus += txtBxTipo_GotFocus;
            this.txtBxTipo.LostFocus += txtBxTipo_LostFocus;

            this.txtBxDescricao.GotFocus += txtBxDescricao_GotFocus;
            this.txtBxDescricao.LostFocus += txtBxDescricao_LostFocus;
        }

        void txtBxTipo_LostFocus(object sender, EventArgs e)
        {
            this.txtBxTipo.BackColor = Color.White;
        }

        void txtBxTipo_GotFocus(object sender, EventArgs e)
        {
            this.txtBxTipo.BackColor = Color.LightYellow;
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
            if (tbControlTipoRg.SelectedIndex.Equals(0))
            {
                TipoRg = txtBxTipo.Text;
            }

            if (tbControlTipoRg.SelectedIndex.Equals(1))
            {
                Descricao = txtBxDescricao.Text;
            }

            SearchType = tbControlTipoRg.SelectedIndex;

            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void txtBxTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBxTipo.Text == string.Empty)
            {
                ErrPrvdrTipoRg.SetError(txtBxTipo, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrTipoRg.SetError(txtBxTipo, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaAceiteSomenteCaracteres(txtBxTipo.Text))
                {
                    ErrPrvdrTipoRg.SetError(txtBxTipo, ValidationsMessages.VALIDA_TIPO_RG);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrTipoRg.SetError(txtBxTipo, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrTipoRg.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrTipoRg.SetError(txtBxDescricao, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }

        }
    }
}
