using BrSoftNet.App.Business.Processes.Manager.Tasks;
using BrSoftNet.App.UI.Win.Manager.State;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormParametroGerenciador : Form
    {
        public int IdTipoProcesso { get; set; }

        public int IdTipoProcessoEspecial { get; set; }

        public int IdTipoProcessoInternet { get; set; }

        public int IdTabela { get; set; }

        public int SearchType { get; set; }

        public FilterSearchFormParametroGerenciador()
        {
            InitializeComponent();
            FillComboBoxComponentsFormFilter();

            this.txtCodParamGer.GotFocus += txtCodParamGer_GotFocus;
            this.txtCodParamGer.LostFocus += txtCodParamGer_LostFocus;

            this.cmbBoxTpProcEspCons.GotFocus += cmbBoxTpProcEspCons_GotFocus;
            this.cmbBoxTpProcEspCons.LostFocus += cmbBoxTpProcEspCons_LostFocus;

            this.cmbBoxTpProcIntCons.GotFocus += cmbBoxTpProcIntCons_GotFocus;
            this.cmbBoxTpProcIntCons.LostFocus += cmbBoxTpProcIntCons_LostFocus;
        }

        void cmbBoxTpProcIntCons_LostFocus(object sender, EventArgs e)
        {
            this.cmbBoxTpProcIntCons.BackColor = Color.White;
        }

        void cmbBoxTpProcIntCons_GotFocus(object sender, EventArgs e)
        {
            this.cmbBoxTpProcIntCons.BackColor = Color.LightYellow;
        }

        void cmbBoxTpProcEspCons_LostFocus(object sender, EventArgs e)
        {
            this.cmbBoxTpProcEspCons.BackColor = Color.White;
        }

        void cmbBoxTpProcEspCons_GotFocus(object sender, EventArgs e)
        {
            this.cmbBoxTpProcEspCons.BackColor = Color.LightYellow;
        }

        void txtCodParamGer_LostFocus(object sender, EventArgs e)
        {
            this.txtCodParamGer.BackColor = Color.White;
        }

        void txtCodParamGer_GotFocus(object sender, EventArgs e)
        {
            this.txtCodParamGer.BackColor = Color.LightYellow;
        }

        private void FillComboBoxComponentsFormFilter()
        {
            if (AppStateManager.ProcessoGerenciadorCollection == null)
            {
                IdTipoProcesso = 3;
                AppStateManager.IdTipoProcesso = IdTipoProcesso;
                AppStateManager.ProcessoGerenciadorCollection = ManagementParameterProcess.CreateInstance.TaskGetProcessesByIdProcessType(AppStateManager.IdTipoProcesso);
            }

            cmbBoxTpProcEspCons.DataSource = AppStateManager.ProcessoGerenciadorCollection;
            cmbBoxTpProcEspCons.ValueMember = "CodigoProcesso";
            cmbBoxTpProcEspCons.DisplayMember = "DescricaoProcesso";

            cmbBoxTpProcIntCons.DataSource = AppStateManager.ProcessoGerenciadorCollection;
            cmbBoxTpProcIntCons.ValueMember = "CodigoProcesso";
            cmbBoxTpProcIntCons.DisplayMember = "DescricaoProcesso";
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {
            if (tbcntrlFiltrParamRegGeral.SelectedIndex.Equals(0))
            {
                IdTabela = Convert.ToInt32(txtCodParamGer.Text);
            }

            if (tbcntrlFiltrParamRegGeral.SelectedIndex.Equals(1))
            {
                IdTipoProcessoInternet = Convert.ToInt32(cmbBoxTpProcEspCons.SelectedValue);
            }

            if (tbcntrlFiltrParamRegGeral.SelectedIndex.Equals(2))
            {
                IdTipoProcessoInternet = Convert.ToInt32(cmbBoxTpProcIntCons.SelectedValue); 
            }

            SearchType = tbcntrlFiltrParamRegGeral.SelectedIndex;
            
            this.Close();
        }
    }
}
