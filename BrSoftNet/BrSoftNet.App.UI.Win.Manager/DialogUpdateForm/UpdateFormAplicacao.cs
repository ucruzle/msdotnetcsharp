using BrSoftNet.App.Business.Processes.Manager.Enumerators;
using BrSoftNet.App.Business.Processes.Manager.Tasks;
using System;
using System.Drawing;
using System.Windows.Forms;
using BrSoftNet.Library.Messages;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Log.Structures;
using System.Collections.Generic;
using BrSoftNet.Log.Helpers;
using BrSoftNet.Log.Actions;

namespace BrSoftNet.App.UI.Win.Manager.DialogUpdateForm
{
    public partial class UpdateFormAplicacao : Form
    {
        #region ...::: Private Variable :::...

        private string _TipoModificacao = string.Empty;

        private int _IdExecute = 0;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpr { get; set; }
        public int IdRg { get; set; }
        public string UsuarioLogin { get; set; }
        public ModificaAplicacaoType ModificaAplicacaoType { get; set; }
        public int CodigoAplicacao { get; set; }
        public string DescricaoAplicacao { get; set; }
        public string SiglaAplicacao { get; set; }
        public int SequenciaAplicacao { get; set; }
        public string AtivaAplicacao { get; set; }
        public string FormAplicacao { get; set; }
        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;
        private ChangeItem _LogCodigoAplicacao = null;
        private ChangeItem _LogDescricaoAplicacao = null;
        private ChangeItem _LogSiglaAplicacao = null;
        private ChangeItem _LogSequenciaAplicacao = null;
        private ChangeItem _LogAtivaAplicacao = null;
        private ChangeItem _LogFormAplicacao = null;
        private List<ChangeItem> _ChangeItems = null;
        private ThrowingException _ThrowingException = null;

        private string _IdExcepitionLog = string.Empty;
        private string _MenssageLogError = string.Empty;

        #endregion

        public UpdateFormAplicacao()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();

            this.txtBxDescricao.GotFocus += txtBxDescricao_GotFocus;
            this.txtBxDescricao.LostFocus += txtBxDescricao_LostFocus;

            this.txtBxSigla.GotFocus += txtBxSigla_GotFocus;
            this.txtBxSigla.LostFocus += txtBxSigla_LostFocus;

            this.txtBxSequencia.GotFocus += txtBxSequencia_GotFocus;
            this.txtBxSequencia.LostFocus += txtBxSequencia_LostFocus;

            this.txtBxForm.GotFocus += txtBxForm_GotFocus;
            this.txtBxForm.LostFocus += txtBxForm_LostFocus;
        }

        void txtBxDescricao_LostFocus(object sender, EventArgs e)
        {
            this.txtBxDescricao.BackColor = Color.White;
        }

        void txtBxDescricao_GotFocus(object sender, EventArgs e)
        {
            this.txtBxDescricao.BackColor = Color.LightYellow;
        }

        void txtBxSigla_LostFocus(object sender, EventArgs e)
        {
            this.txtBxSigla.BackColor = Color.White;
        }

        void txtBxSigla_GotFocus(object sender, EventArgs e)
        {
            this.txtBxSigla.BackColor = Color.LightYellow;
        }

        void txtBxSequencia_LostFocus(object sender, EventArgs e)
        {
            this.txtBxSequencia.BackColor = Color.White;
        }

        void txtBxSequencia_GotFocus(object sender, EventArgs e)
        {
            this.txtBxSequencia.BackColor = Color.LightYellow;
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
            ExecuteModifyAplicacao();

            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrAplicacao.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxDescricao.Focus();
                return;
            }

            if (txtBxSigla.Text == string.Empty)
            {
                ErrPrvdrAplicacao.SetError(txtBxSigla, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxSigla.Focus();
                return;
            }

            if (txtBxSequencia.Text == string.Empty)
            {
                ErrPrvdrAplicacao.SetError(txtBxSequencia, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxSequencia.Focus();
                return;
            }

            if (txtBxForm.Text == string.Empty)
            {
                ErrPrvdrAplicacao.SetError(txtBxForm, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxForm.Focus();
                return;
            }

            if (_IdExcepitionLog != string.Empty)
            {
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblExcecao.Text = _MenssageLogError;
                tlstrpLblExcecao.Visible = true;
                return;
            }
            
            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void ExecuteModifyAplicacao()
        {
            switch (ModificaAplicacaoType)
            {
                case ModificaAplicacaoType.AplicacaoAdicionar:
                    ExecuteAddAplicacao();
                    break;
                case ModificaAplicacaoType.AplicacaoAlterar:
                    ExecuteUpdateAplicacao();
                    break;
            }
        }

        private void ExecuteUpdateAplicacao()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteUpdateAplicação";

            int _CodigoAplicacao = 0;
            string _DescricaoAplicacao = string.Empty;
            string _SiglaAplicacao = string.Empty;
            int _SequenciaAplicacao = 0;
            string _FormAplicacao = string.Empty;
            string _TipoModificacao = string.Empty;

            _CodigoAplicacao = Convert.ToInt32(txtBxCodAplicacao.Text);
            _DescricaoAplicacao = txtBxDescricao.Text;
            _SiglaAplicacao = txtBxSigla.Text;
            _SequenciaAplicacao = Convert.ToInt32(txtBxSequencia.Text);
            _FormAplicacao = txtBxForm.Text;
            _TipoModificacao = AplicacaoProcess.CreateInstance.FromToModificaAplicacao(ModificaAplicacaoType.AplicacaoAlterar);

            AtivaAplicacao = ckBxAtiva.Checked ? "S" : "N";

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }
                _IdExecute = AplicacaoProcess.CreateInstance.TaskModifyProcessAplicacao(_CodigoAplicacao, _DescricaoAplicacao, _SiglaAplicacao, _SequenciaAplicacao, AtivaAplicacao, _FormAplicacao, _TipoModificacao);
            }
            catch (Exception _Exception)
            {
                #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "E"; }

                #endregion

                #region ...::: Atualiza o cabeçalho do Log de Exceções :::...

                _ThrowingException = new ThrowingException();
                _ThrowingException.Id = ServiceHelper.CreateInstance.GetIDExceptions();
                _ThrowingException.IdChangeHeader = _ChangesHeader.Id;
                _ThrowingException.Formulario = this.Name;
                _ThrowingException.FuncaoDisparador = _FUNCAO_DISPARADOR;
                _ThrowingException.Tarefa = _Exception.TargetSite.ToString();
                _ThrowingException.TipoExcecao = _Exception.GetType().ToString();
                _ThrowingException.MensagemExcecao = _Exception.Message;

                _IdExcepitionLog = _ThrowingException.Id;

                #endregion

                #region ...::: Atualiza os Itens do Log de Modificações :::...

                if (_LogCodigoAplicacao != null) { _LogCodigoAplicacao.ValorNovo = _CodigoAplicacao; }
                if (_LogDescricaoAplicacao != null) { _LogDescricaoAplicacao.ValorNovo = _DescricaoAplicacao; }
                if (_LogSiglaAplicacao != null) { _LogSiglaAplicacao.ValorNovo = _SiglaAplicacao; }
                if (_LogSequenciaAplicacao != null) { _LogSequenciaAplicacao.ValorNovo = _SequenciaAplicacao; }
                if (_LogAtivaAplicacao != null) { _LogAtivaAplicacao.ValorNovo = AtivaAplicacao; }
                if (_LogFormAplicacao != null) { _LogFormAplicacao.ValorNovo = _FormAplicacao; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogCodigoAplicacao);
                _ChangeItems.Add(_LogDescricaoAplicacao);
                _ChangeItems.Add(_LogSiglaAplicacao);
                _ChangeItems.Add(_LogSequenciaAplicacao);
                _ChangeItems.Add(_LogAtivaAplicacao);
                _ChangeItems.Add(_LogFormAplicacao);

                #endregion

                ExecuteModifyExceptionLogAplicacao(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {

                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogCodigoAplicacao != null) { _LogCodigoAplicacao.ValorNovo = _CodigoAplicacao; }
                    if (_LogDescricaoAplicacao != null) { _LogDescricaoAplicacao.ValorNovo = _DescricaoAplicacao; }
                    if (_LogSiglaAplicacao != null) { _LogSiglaAplicacao.ValorNovo = _SiglaAplicacao; }
                    if (_LogSequenciaAplicacao != null) { _LogSequenciaAplicacao.ValorNovo = _SequenciaAplicacao; }
                    if (_LogAtivaAplicacao != null) { _LogAtivaAplicacao.ValorNovo = AtivaAplicacao; }
                    if (_LogFormAplicacao != null) { _LogFormAplicacao.ValorNovo = _FormAplicacao; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogCodigoAplicacao);
                    _ChangeItems.Add(_LogDescricaoAplicacao);
                    _ChangeItems.Add(_LogSiglaAplicacao);
                    _ChangeItems.Add(_LogSequenciaAplicacao);
                    _ChangeItems.Add(_LogAtivaAplicacao);
                    _ChangeItems.Add(_LogFormAplicacao);

                    #endregion

                    ExecuteModifyLogAplicacao(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void ExecuteAddAplicacao()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteAddAplicação";

            txtBxCodAplicacao.Text = "0";
            int _CodigoAplicacao = 0;
            string _DescricaoAplicacao = string.Empty;
            string _SiglaAplicacao = string.Empty;
            int _SequenciaAplicacao = 0;
            string _FormAplicacao = string.Empty;
            string _TipoModificacao = string.Empty;

            _CodigoAplicacao = Convert.ToInt32(txtBxCodAplicacao.Text);
            _DescricaoAplicacao = txtBxDescricao.Text;
            _SiglaAplicacao = txtBxSigla.Text;
            _SequenciaAplicacao = Convert.ToInt32(txtBxSequencia.Text);
            _FormAplicacao = txtBxForm.Text;
            _TipoModificacao = AplicacaoProcess.CreateInstance.FromToModificaAplicacao(ModificaAplicacaoType.AplicacaoAdicionar);

            AtivaAplicacao = ckBxAtiva.Checked ? "S" : "N";

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }
                _IdExecute = AplicacaoProcess.CreateInstance.TaskModifyProcessAplicacao(_CodigoAplicacao, _DescricaoAplicacao, _SiglaAplicacao, _SequenciaAplicacao, AtivaAplicacao, _FormAplicacao, _TipoModificacao);
            }
            catch (Exception _Exception)
            {
                #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "E"; }

                #endregion

                #region ...::: Atualiza o cabeçalho do Log de Exceções :::...

                _ThrowingException = new ThrowingException();
                _ThrowingException.Id = ServiceHelper.CreateInstance.GetIDExceptions();
                _ThrowingException.IdChangeHeader = _ChangesHeader.Id;
                _ThrowingException.Formulario = this.Name;
                _ThrowingException.FuncaoDisparador = _FUNCAO_DISPARADOR;
                _ThrowingException.Tarefa = _Exception.TargetSite.ToString();
                _ThrowingException.TipoExcecao = _Exception.GetType().ToString();
                _ThrowingException.MensagemExcecao = _Exception.Message;

                _IdExcepitionLog = _ThrowingException.Id;

                #endregion

                #region ...::: Atualiza os Itens do Log de Modificações :::...

                if (_LogCodigoAplicacao != null) { _LogCodigoAplicacao.ValorNovo = _CodigoAplicacao; }
                if (_LogDescricaoAplicacao != null) { _LogDescricaoAplicacao.ValorNovo = _DescricaoAplicacao; }
                if (_LogSiglaAplicacao != null) { _LogSiglaAplicacao.ValorNovo = _SiglaAplicacao; }
                if (_LogSequenciaAplicacao != null) { _LogSequenciaAplicacao.ValorNovo = _SequenciaAplicacao; }
                if (_LogAtivaAplicacao != null) { _LogAtivaAplicacao.ValorNovo = AtivaAplicacao; }
                if (_LogFormAplicacao != null) { _LogFormAplicacao.ValorNovo = _FormAplicacao; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogCodigoAplicacao);
                _ChangeItems.Add(_LogDescricaoAplicacao);
                _ChangeItems.Add(_LogSiglaAplicacao);
                _ChangeItems.Add(_LogSequenciaAplicacao);
                _ChangeItems.Add(_LogAtivaAplicacao);
                _ChangeItems.Add(_LogFormAplicacao);

                #endregion

                ExecuteModifyExceptionLogAplicacao(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogCodigoAplicacao != null) { _LogCodigoAplicacao.ValorNovo = _CodigoAplicacao; }
                    if (_LogDescricaoAplicacao != null) { _LogDescricaoAplicacao.ValorNovo = _DescricaoAplicacao; }
                    if (_LogSiglaAplicacao != null) { _LogSiglaAplicacao.ValorNovo = _SiglaAplicacao; }
                    if (_LogSequenciaAplicacao != null) { _LogSequenciaAplicacao.ValorNovo = _SequenciaAplicacao; }
                    if (_LogAtivaAplicacao != null) { _LogAtivaAplicacao.ValorNovo = AtivaAplicacao; }
                    if (_LogFormAplicacao != null) { _LogFormAplicacao.ValorNovo = _FormAplicacao; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogCodigoAplicacao);
                    _ChangeItems.Add(_LogDescricaoAplicacao);
                    _ChangeItems.Add(_LogSiglaAplicacao);
                    _ChangeItems.Add(_LogSequenciaAplicacao);
                    _ChangeItems.Add(_LogAtivaAplicacao);
                    _ChangeItems.Add(_LogFormAplicacao);

                    #endregion

                    ExecuteModifyLogAplicacao(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }
        private void ExecuteModifyLogAplicacao(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }

        private void ExecuteModifyExceptionLogAplicacao(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void FillLogHeaderFromUpdateModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboGeAplicacao.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.CodigoAplicacao;
            _ChangesHeader.TipoModificacao = AplicacaoProcess.CreateInstance.FromToModificaAplicacao(ModificaAplicacaoType.AplicacaoAlterar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Aplicação
            _LogCodigoAplicacao = new ChangeItem();
            _LogCodigoAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoAplicacao.IdItem = 1;
            _LogCodigoAplicacao.NomeTabela = DboGeAplicacao.NomeTabela;
            _LogCodigoAplicacao.NomeCampo = DboGeAplicacao.NomeCodigoAplicacao;
            _LogCodigoAplicacao.ValorAntigo = CodigoAplicacao;

            //Descrição Aplicação
            _LogDescricaoAplicacao = new ChangeItem();
            _LogDescricaoAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricaoAplicacao.IdItem = 2;
            _LogDescricaoAplicacao.NomeTabela = DboGeAplicacao.NomeTabela;
            _LogDescricaoAplicacao.NomeCampo = DboGeAplicacao.NomeDescrAplicacao;
            _LogDescricaoAplicacao.ValorAntigo = DescricaoAplicacao;

            //Sigla Aplicação
            _LogSiglaAplicacao = new ChangeItem();
            _LogSiglaAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogSiglaAplicacao.IdItem = 3;
            _LogSiglaAplicacao.NomeTabela = DboGeAplicacao.NomeTabela;
            _LogSiglaAplicacao.NomeCampo = DboGeAplicacao.NomeSiglaAplicacao;
            _LogSiglaAplicacao.ValorAntigo = SiglaAplicacao;

            //Sequencia Aplicação
            _LogSequenciaAplicacao = new ChangeItem();
            _LogSequenciaAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogSequenciaAplicacao.IdItem = 4;
            _LogSequenciaAplicacao.NomeTabela = DboGeAplicacao.NomeTabela;
            _LogSequenciaAplicacao.NomeCampo = DboGeAplicacao.NomeSequenciaAplicacao;
            _LogSequenciaAplicacao.ValorAntigo = SequenciaAplicacao;

            //Ativa Aplicação
            _LogAtivaAplicacao = new ChangeItem();
            _LogAtivaAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogAtivaAplicacao.IdItem = 5;
            _LogAtivaAplicacao.NomeTabela = DboGeAplicacao.NomeTabela;
            _LogAtivaAplicacao.NomeCampo = DboGeAplicacao.NomeAtivaAplicacao;
            _LogAtivaAplicacao.ValorAntigo = AtivaAplicacao;

            //Form Aplicação
            _LogFormAplicacao = new ChangeItem();
            _LogFormAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogFormAplicacao.IdItem = 6;
            _LogFormAplicacao.NomeTabela = DboGeAplicacao.NomeTabela;
            _LogFormAplicacao.NomeCampo = DboGeAplicacao.NomeFormAplicacao;
            _LogFormAplicacao.ValorAntigo = FormAplicacao;

            #endregion
        }

        private void FillLogHeaderFromAddModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboGeAplicacao.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.CodigoAplicacao;
            _ChangesHeader.TipoModificacao = AplicacaoProcess.CreateInstance.FromToModificaAplicacao(ModificaAplicacaoType.AplicacaoAdicionar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Aplicação
            _LogCodigoAplicacao = new ChangeItem();
            _LogCodigoAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoAplicacao.IdItem = 1;
            _LogCodigoAplicacao.NomeTabela = DboGeAplicacao.NomeTabela;
            _LogCodigoAplicacao.NomeCampo = DboGeAplicacao.NomeCodigoAplicacao;
            //_LogCodigoAplicacao.ValorAntigo = CodigoAplicacao;

            //Descrição Aplicação
            _LogDescricaoAplicacao = new ChangeItem();
            _LogDescricaoAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricaoAplicacao.IdItem = 2;
            _LogDescricaoAplicacao.NomeTabela = DboGeAplicacao.NomeTabela;
            _LogDescricaoAplicacao.NomeCampo = DboGeAplicacao.NomeDescrAplicacao;
            //_LogDescricaoAplicacao.ValorAntigo = DescricaoAplicacao;

            //Sigla Aplicação
            _LogSiglaAplicacao = new ChangeItem();
            _LogSiglaAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogSiglaAplicacao.IdItem = 3;
            _LogSiglaAplicacao.NomeTabela = DboGeAplicacao.NomeTabela;
            _LogSiglaAplicacao.NomeCampo = DboGeAplicacao.NomeSiglaAplicacao;
            //_LogSiglaAplicacao.ValorAntigo = SiglaAplicacao;

            //Sequencia Aplicação
            _LogSequenciaAplicacao = new ChangeItem();
            _LogSequenciaAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogSequenciaAplicacao.IdItem = 4;
            _LogSequenciaAplicacao.NomeTabela = DboGeAplicacao.NomeTabela;
            _LogSequenciaAplicacao.NomeCampo = DboGeAplicacao.NomeSequenciaAplicacao;
            //_LogSequenciaAplicacao.ValorAntigo = SequenciaAplicacao;

            //Ativa Aplicação
            _LogAtivaAplicacao = new ChangeItem();
            _LogAtivaAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogAtivaAplicacao.IdItem = 5;
            _LogAtivaAplicacao.NomeTabela = DboGeAplicacao.NomeTabela;
            _LogAtivaAplicacao.NomeCampo = DboGeAplicacao.NomeAtivaAplicacao;
            //_LogAtivaAplicacao.ValorAntigo = AtivaAplicacao;

            //Form Aplicação
            _LogFormAplicacao = new ChangeItem();
            _LogFormAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogFormAplicacao.IdItem = 6;
            _LogFormAplicacao.NomeTabela = DboGeAplicacao.NomeTabela;
            _LogFormAplicacao.NomeCampo = DboGeAplicacao.NomeFormAplicacao;
            //_LogFormAplicacao.ValorAntigo = FormAplicacao;

            #endregion
        }

        private void UpdateFormAplicacao_Load(object sender, System.EventArgs e)
        {
            this.lblActionModuleTitle.Text = TextoDoTilutoDoFormulario;

            if (ModificaAplicacaoType == ModificaAplicacaoType.AplicacaoAlterar)
            {
                FillLogHeaderFromUpdateModify();
                FillDataParametersToExecuteUpdateModify();
            }
            if (ModificaAplicacaoType == ModificaAplicacaoType.AplicacaoAdicionar)
            {
                FillLogHeaderFromAddModify();
            }
        }

        private void FillDataParametersToExecuteUpdateModify()
        {
            ckBxAtiva.Checked = (AtivaAplicacao == "S" ? true : false);

            txtBxCodAplicacao.Text = CodigoAplicacao.ToString();
            txtBxDescricao.Text = DescricaoAplicacao;
            txtBxSigla.Text = SiglaAplicacao;
            txtBxSequencia.Text = SequenciaAplicacao.ToString();
            txtBxForm.Text = FormAplicacao;
        }

        private void txtBxDescricao_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrAplicacao.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrAplicacao.SetError(txtBxDescricao, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxSigla_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxSigla.Text == string.Empty)
            {
                ErrPrvdrAplicacao.SetError(txtBxSigla, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
	        {
                ErrPrvdrAplicacao.SetError(txtBxSigla, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaAceiteSomenteCaracteres(txtBxSigla.Text))
	            {
                    ErrPrvdrAplicacao.SetError(txtBxSigla, ValidationsMessages.VALIDA_SIGLA);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
	            }
                else
                {
                    ErrPrvdrAplicacao.SetError(txtBxSigla, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
	        }
        }

        private void txtBxSequencia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxSequencia.Text == string.Empty)
            {
                ErrPrvdrAplicacao.SetError(txtBxSequencia, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrAplicacao.SetError(txtBxSequencia, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaAceiteSomenteNumeros(txtBxSequencia.Text))
                {
                    ErrPrvdrAplicacao.SetError(txtBxSequencia, ValidationsMessages.VALIDA_NUMERO);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrAplicacao.SetError(txtBxSequencia, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxForm_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxForm.Text == string.Empty)
            {
                ErrPrvdrAplicacao.SetError(txtBxForm, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrAplicacao.SetError(txtBxForm, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrAplicacao.SetError(txtBxDescricao, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxSigla_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrAplicacao.SetError(txtBxSigla, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxSequencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrAplicacao.SetError(txtBxSequencia, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrAplicacao.SetError(txtBxForm, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        internal static class DboGeAplicacao
        {
            #region ...::: Private Constantes :::...

            private const string _NomeCodigoAplicacao = "cod_aplic";
            private const string _NomeDescrAplicacao = "descr_aplic";
            private const string _NomeSiglaAplicacao = "sigla_aplic";
            private const string _NomeSequenciaAplicacao = "sequ_aplic";
            private const string _NomeAtivaAplicacao = "ativa";
            private const string _NomeFormAplicacao = "form_aplic";
            private const string _NomeTabela = "ge_aplicacao";
            private const string _NomeProcesso = "Aplicação";

            #endregion

            #region ...::: Public Properties :::...

            public static string NomeCodigoAplicacao { get { return _NomeCodigoAplicacao; } }
            public static string NomeDescrAplicacao { get { return _NomeDescrAplicacao; } }
            public static string NomeSiglaAplicacao { get { return _NomeSiglaAplicacao; } }
            public static string NomeSequenciaAplicacao { get { return _NomeSequenciaAplicacao; } }
            public static string NomeAtivaAplicacao { get { return _NomeAtivaAplicacao; } }
            public static string NomeFormAplicacao { get { return _NomeFormAplicacao; } }
            public static string NomeTabela { get { return _NomeTabela; } }
            public static string NomeProcesso { get { return _NomeProcesso; } }

            #endregion
        }
    }
}
