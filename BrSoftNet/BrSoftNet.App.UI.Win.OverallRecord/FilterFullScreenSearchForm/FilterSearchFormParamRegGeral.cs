using System.Windows.Forms;
using BrSoftNet.Library.Messages;
using BrSoftNet.Library.Utilities;

namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormParamRegGeral : Form
    {
        public int CodigoEmpresa { get; set; }

        public int SearchType { get; set; }

        public FilterSearchFormParamRegGeral()
        {
            InitializeComponent();
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {
            if (tbControlParmRegGeral.SelectedIndex.Equals(0))
            {
                CodigoEmpresa = int.Parse(txtBxCodigoEmpresa.Text);
            }

            SearchType = tbControlParmRegGeral.SelectedIndex;

            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /* -------------------------------------- INICIO BLOCO DE VALIDAÇÕES -------------------------------------- */
        private void txtBxCodigoEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBxCodigoEmpresa.Text == string.Empty)
            {
                ErrPrvdrParametroRegistroGeral.SetError(txtBxCodigoEmpresa, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrParametroRegistroGeral.SetError(txtBxCodigoEmpresa, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaAceiteSomenteNumeros(txtBxCodigoEmpresa.Text))
                {
                    ErrPrvdrParametroRegistroGeral.SetError(txtBxCodigoEmpresa, ValidationsMessages.VALIDA_CODIGO);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrParametroRegistroGeral.SetError(txtBxCodigoEmpresa, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }
    }
}
