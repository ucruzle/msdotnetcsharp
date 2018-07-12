using BrSoftNet.App.Business.Processes.Manager.Enumerators;
using BrSoftNet.App.Business.Processes.Manager.Tasks;
using BrSoftNet.App.Business.Processes.Manager.Entities;
using BrSoftNet.App.UI.Win.Manager.State;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Library.Messages;

namespace BrSoftNet.App.UI.Win.Manager.DialogUpdateForm
{
    public partial class UpdateFormProcesso : Form
    {
        #region ...::: Private Variable :::...

        private string _TipoModificacao = string.Empty;

        private int _IdExecute = 0;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpr { get; set; }
        public int IdRg { get; set; }
        public string UsuarioLogin { get; set; }
        public ModificaProcessoType ModificaProcessoType { get; set; }
        public int CodigoProcesso { get; set; }
        public string DescricaoProcesso { get; set; }
        public int CodigoTipoProcesso { get; set; }
        public int CodigoAplicacao { get; set; }
        public string Ativo { get; set; }
        public string Form { get; set; }
        public int SequenciaProcesso { get; set; }
        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Properties :::...
        private List<GeTipoProcesso> GeTipoProcessoCollection { get; set; }
        private List<GeAplicacao> GeAplicacaoCollection { get; set; }

        #endregion

        #region ...::: Private Fields :::...

        private List<GeTipoProcesso> _GeTipoProcessoCollection = null;
        private List<GeAplicacao> _GeAplicacaoCollection = null;
        private DataSet _DataSetTipoProcessoAplicacaoPorVinculo = null;

        #endregion

        public UpdateFormProcesso()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();

            this.txtBxDescricaoProcesso.GotFocus += txtBxDescricaoProcesso_GotFocus;
            this.txtBxDescricaoProcesso.LostFocus += txtBxDescricaoProcesso_LostFocus;

            this.cmbBxAplicacao.GotFocus += cmbBxAplicacao_GotFocus;
            this.cmbBxAplicacao.LostFocus += cmbBxAplicacao_LostFocus;

            this.cmbBxTipoProcesso.GotFocus += cmbBxTipoProcesso_GotFocus;
            this.cmbBxTipoProcesso.LostFocus += cmbBxTipoProcesso_LostFocus;

            this.txtBxForm.GotFocus += txtBxForm_GotFocus;
            this.txtBxForm.LostFocus += txtBxForm_LostFocus;
        }

        void cmbBxTipoProcesso_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxTipoProcesso.BackColor = Color.White;
        }

        void cmbBxTipoProcesso_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxTipoProcesso.BackColor = Color.LightYellow;
        }

        void cmbBxAplicacao_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxAplicacao.BackColor = Color.White;
        }

        void cmbBxAplicacao_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxAplicacao.BackColor = Color.LightYellow;
        }

        void txtBxDescricaoProcesso_LostFocus(object sender, EventArgs e)
        {
            this.txtBxDescricaoProcesso.BackColor = Color.White;
        }

        void txtBxDescricaoProcesso_GotFocus(object sender, EventArgs e)
        {
            this.txtBxDescricaoProcesso.BackColor = Color.LightYellow;
        }

        void txtBxForm_LostFocus(object sender, EventArgs e)
        {
            this.txtBxForm.BackColor = Color.White;
        }

        void txtBxForm_GotFocus(object sender, EventArgs e)
        {
            this.txtBxForm.BackColor = Color.LightYellow;
        }

        private void InicialiazeUpdateForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {
            if (txtBxDescricaoProcesso.Text == string.Empty)
            {
                ErrPrvdrProcesso.SetError(txtBxDescricaoProcesso, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxDescricaoProcesso.Focus();
                return;
            }

            if (txtBxForm.Text == string.Empty)
            {
                ErrPrvdrProcesso.SetError(txtBxForm, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxForm.Focus();
                return;
            }
            ExecuteModifyProcesso();
            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void ExecuteModifyProcesso()
        {
            switch (ModificaProcessoType)
            {
                case ModificaProcessoType.ProcessoAdicionar:
                    ExecuteAddProcesso();
                    break;
                case ModificaProcessoType.ProcessoAlterar:
                    ExecuteUpdateProcesso();
                    break;
            }
        }

        private void ExecuteUpdateProcesso()
        {
            string _Ativo = (ckBxAtiva.Checked) ? "S" : "N";
            string _DescricaoProcesso = txtBxDescricaoProcesso.Text;
            string _Form = txtBxForm.Text;
            int _CodigoTipoProcesso = 0;
            int _CodigoAplicacao = 0;
            int _CodigoProcesso = 0;
            int _SequenciaProcesso = 0;

            _CodigoTipoProcesso = Convert.ToInt32(cmbBxTipoProcesso.SelectedValue);
            _CodigoAplicacao = Convert.ToInt32(cmbBxAplicacao.SelectedValue);
            _CodigoProcesso = Convert.ToInt32(txtBxCodigoProcesso.Text);
            _TipoModificacao = ProcessoProcess.CreateInstance.FromToModificaProcesso(ModificaProcessoType.ProcessoAlterar);

            try
            {
                _IdExecute = ProcessoProcess.CreateInstance.TaskModifyProcessProcesso(_CodigoProcesso, _DescricaoProcesso, _CodigoTipoProcesso, _CodigoAplicacao, _Ativo, _Form, _SequenciaProcesso, _TipoModificacao);
            }
            catch (Exception _Exception)
            {
                throw _Exception;
            }
            finally
            {

            }
        }

        private void ExecuteAddProcesso()
        {
            txtBxCodigoProcesso.Text = "0";
            string _Ativo = (ckBxAtiva.Checked) ? "S" : "N";
            string _DescricaoProcesso = txtBxDescricaoProcesso.Text;
            string _Form = txtBxForm.Text;
            int _CodigoTipoProcesso = 0;
            int _CodigoAplicacao = 0;
            int _CodigoProcesso = 0;
            int _SequenciaProcesso = 0;

            _CodigoTipoProcesso = Convert.ToInt32(cmbBxTipoProcesso.SelectedValue);
            _CodigoAplicacao = Convert.ToInt32(cmbBxAplicacao.SelectedValue);
            _CodigoProcesso = Convert.ToInt32(txtBxCodigoProcesso.Text);
            _TipoModificacao = ProcessoProcess.CreateInstance.FromToModificaProcesso(ModificaProcessoType.ProcessoAdicionar);

            try
            {
                _IdExecute = ProcessoProcess.CreateInstance.TaskModifyProcessProcesso(_CodigoProcesso, _DescricaoProcesso, _CodigoTipoProcesso, _CodigoAplicacao, _Ativo, _Form, _SequenciaProcesso, _TipoModificacao);
            }
            catch (Exception _Exception)
            {
                throw _Exception;
            }
            finally
            {

            }
        }

        private void UpdateFormProcesso_Load(object sender, System.EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;

            _DataSetTipoProcessoAplicacaoPorVinculo = ProcessoProcess.CreateInstance.TaskGeCollectionGeTipoProcessoAplicacaoPorVinculo();

            FillTipoProcessoCollection();
            FillAplicacaoCollection();

            switch (ModificaProcessoType)
            {
                case ModificaProcessoType.ProcessoAdicionar:
                    FillDataParametersToExecuteAddModify();
                    FillProcessoToAddModify();
                    break;

                case ModificaProcessoType.ProcessoAlterar:
                    FillDataParametersToExecuteUpdateModify();
                    FillProcessoToUpdateModify();
                    break;
                default:
                    break;
            }
        }

        private void FillDataParametersToExecuteAddModify()
        {
            if (txtBxCodigoProcesso.ReadOnly)
            {
                txtBxCodigoProcesso.ReadOnly = true;
            }
        }

        private void FillDataParametersToExecuteUpdateModify()
        {
            txtBxCodigoProcesso.Text = CodigoProcesso.ToString();
            txtBxDescricaoProcesso.Text = DescricaoProcesso;
            cmbBxTipoProcesso.SelectedValue = CodigoTipoProcesso.ToString();
            cmbBxAplicacao.SelectedValue = CodigoAplicacao.ToString();
            txtBxForm.Text = Form.ToString();

            ckBxAtiva.Checked = (Ativo == "S" ? true : false);

            txtBxCodigoProcesso.ReadOnly = true;
        }

        private void FillProcessoToAddModify()
        {
            cmbBxTipoProcesso.DataSource = GeTipoProcessoCollection;
            cmbBxTipoProcesso.ValueMember = "CodigoTipoProcesso";
            cmbBxTipoProcesso.DisplayMember = "DescricaoTipoProcesso";

            cmbBxAplicacao.DataSource = GeAplicacaoCollection;
            cmbBxAplicacao.ValueMember = "CodigoAplicacao";
            cmbBxAplicacao.DisplayMember = "DescricaoAplicacao";

            AppStateManager.CodigoTipoProcessoPorVinculo = Convert.ToInt32(cmbBxTipoProcesso.SelectedValue);
            AppStateManager.CodigoApicacaoProcessoPorVinculo = Convert.ToInt32(cmbBxAplicacao.SelectedValue);
        }

        private void FillProcessoToUpdateModify()
        {
            cmbBxTipoProcesso.DataSource = GeTipoProcessoCollection;
            cmbBxTipoProcesso.ValueMember = "CodigoTipoProcesso";
            cmbBxTipoProcesso.DisplayMember = "DescricaoTipoProcesso";
            cmbBxTipoProcesso.SelectedValue = this.CodigoTipoProcesso;

            cmbBxAplicacao.DataSource = GeAplicacaoCollection;
            cmbBxAplicacao.ValueMember = "CodigoAplicacao";
            cmbBxAplicacao.DisplayMember = "DescricaoAplicacao";
            cmbBxAplicacao.SelectedValue = this.CodigoAplicacao;

            AppStateManager.CodigoTipoProcessoPorVinculo = Convert.ToInt32(cmbBxTipoProcesso.SelectedValue);
            AppStateManager.CodigoApicacaoProcessoPorVinculo = Convert.ToInt32(cmbBxAplicacao.SelectedValue);
        }

        private void FillTipoProcessoCollection()
        {
            if (_GeTipoProcessoCollection == null)
            {
                _GeTipoProcessoCollection = new List<GeTipoProcesso>();
            }

            foreach (DataRow _Row in _DataSetTipoProcessoAplicacaoPorVinculo.Tables[0].Rows)
            {
                _GeTipoProcessoCollection.Add(new GeTipoProcesso(_Row));
            }

            GeTipoProcessoCollection = _GeTipoProcessoCollection;
        }
        private void FillAplicacaoCollection()
        {
            if (_GeAplicacaoCollection == null)
            {
                _GeAplicacaoCollection = new List<GeAplicacao>();
            }

            foreach (DataRow _Row in _DataSetTipoProcessoAplicacaoPorVinculo.Tables[1].Rows)
            {
                _GeAplicacaoCollection.Add(new GeAplicacao(_Row));
            }

            GeAplicacaoCollection = _GeAplicacaoCollection;
        }

        private void txtBxDescricaoProcesso_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxDescricaoProcesso.Text == string.Empty)
            {
                ErrPrvdrProcesso.SetError(txtBxDescricaoProcesso, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrProcesso.SetError(txtBxDescricaoProcesso, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxForm_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxForm.Text == string.Empty)
            {
                ErrPrvdrProcesso.SetError(txtBxForm, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrProcesso.SetError(txtBxForm, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxDescricaoProcesso_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrProcesso.SetError(txtBxDescricaoProcesso, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrProcesso.SetError(txtBxForm, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }
    }
}
