using BrSoftNet.App.Business.Processes.Manager.Enumerators;
using BrSoftNet.App.Business.Processes.Manager.Tasks;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using BrSoftNet.App.Business.Processes.Manager.Entities;
using BrSoftNet.App.UI.Win.Manager.State;
using System.Data;
using BrSoftNet.Library.Messages;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Log.Structures;
using BrSoftNet.Log.Helpers;
using BrSoftNet.Log.Actions;
namespace BrSoftNet.App.UI.Win.Manager.DialogUpdateForm
{
    public partial class UpdateFormEmpresa : Form
    {
        #region ...::: Private Variable :::...

        private string _TipoModificacao = string.Empty;

        private int _IdExecute = 0;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpr { get; set; }
        public int IdRg { get; set; }
        public string UsuarioLogin { get; set; }
        public ModificaEmpresaType ModificaEmpresaType { get; set; }
        public int CodigoEmpresa { get; set; }
        public string DescricaoEmpresa { get; set; }
        public string DescricaoEmpresaRed { get; set; }
        public int CodigoEmpresaConsolidada { get; set; }
        public string Ativa { get; set; }
        public int CodigoRg { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string EnderecoBanco { get; set; }
        public string Versao { get; set; }
        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Properties :::...
        public List<GeEmpresaConsolidada> GeEmpresaConsolidada { get; set; }
        private List<IntegracaoRegGeral> IntegracaoRegGeralCollection { get; set; }

        #endregion

        #region ...::: Private Fields :::...

        private List<GeEmpresaConsolidada> _GeEmpresaConsolidadaCollection = null;
        private List<IntegracaoRegGeral> _IntegracaoRegGeralCollection = null;
        private DataSet _DataSetEmpresaConsolidadRegistroGeralPorVinculo = null;

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;

        private ChangeItem _LogCodigoEmpresa = null;
        private ChangeItem _LogDescricaoEmpresa = null;
        private ChangeItem _LogDescricaoEmpresaRed = null;
        private ChangeItem _LogCodigoEmpresaConsolidada = null;
        private ChangeItem _LogAtiva = null;
        private ChangeItem _LogCodigoRg = null;
        private ChangeItem _LogHost = null;
        private ChangeItem _LogPort = null;
        private ChangeItem _LogUsername = null;
        private ChangeItem _LogSenha = null;
        private ChangeItem _LogEmail = null;
        private ChangeItem _LogEnderecoBanco = null;
        private ChangeItem _LogVersao = null;

        private List<ChangeItem> _ChangeItems = null;
        private ThrowingException _ThrowingException = null;

        private string _IdExcepitionLog = string.Empty;
        private string _MenssageLogError = string.Empty;

        #endregion
        public UpdateFormEmpresa()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();

            this.txtBxDescricaoEmpresa.GotFocus += txtBxDescricaoEmpresa_GotFocus;
            this.txtBxDescricaoEmpresa.LostFocus += txtBxDescricaoEmpresa_LostFocus;

            this.txtBxDescricaoEmpresaRed.GotFocus += txtBxDescricaoEmpresaRed_GotFocus;
            this.txtBxDescricaoEmpresaRed.LostFocus += txtBxDescricaoEmpresaRed_LostFocus;

            this.cmbBxCodigoRg.GotFocus += cmbBxCodigoRg_GotFocus;
            this.cmbBxCodigoRg.LostFocus += cmbBxCodigoRg_LostFocus;

            this.cmbBxEmpresaConsolidada.GotFocus += cmbBxEmpresaConsolidada_GotFocus;
            this.cmbBxEmpresaConsolidada.LostFocus += cmbBxEmpresaConsolidada_LostFocus;

            this.txtBxHost.GotFocus += txtBxHost_GotFocus;
            this.txtBxHost.LostFocus += txtBxHost_LostFocus;

            this.txtBxPort.GotFocus += txtBxPort_GotFocus;
            this.txtBxPort.LostFocus += txtBxPort_LostFocus;

            this.txtBxUsername.GotFocus += txtBxUsername_GotFocus;
            this.txtBxUsername.LostFocus += txtBxUsername_LostFocus;

            this.txtBxSenha.GotFocus += txtBxSenha_GotFocus;
            this.txtBxSenha.LostFocus += txtBxSenha_LostFocus;

            this.txtBxEmail.GotFocus += txtBxEmail_GotFocus;
            this.txtBxEmail.LostFocus += txtBxEmail_LostFocus;

            this.txtBxEnderecoBanco.GotFocus += txtBxEnderecoBanco_GotFocus;
            this.txtBxEnderecoBanco.LostFocus += txtBxEnderecoBanco_LostFocus;

            this.txtBxVersao.GotFocus += txtBxVersao_GotFocus;
            this.txtBxVersao.LostFocus += txtBxVersao_LostFocus;
        }

        void cmbBxEmpresaConsolidada_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxEmpresaConsolidada.BackColor = Color.White;
        }

        void cmbBxEmpresaConsolidada_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxEmpresaConsolidada.BackColor = Color.LightYellow;
        }

        void cmbBxCodigoRg_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoRg.BackColor = Color.White;
        }

        void cmbBxCodigoRg_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoRg.BackColor = Color.LightYellow;
        }

        void txtBxDescricaoEmpresa_LostFocus(object sender, EventArgs e)
        {
            this.txtBxDescricaoEmpresa.BackColor = Color.White;
        }

        void txtBxDescricaoEmpresa_GotFocus(object sender, EventArgs e)
        {
            this.txtBxDescricaoEmpresa.BackColor = Color.LightYellow;
        }

        void txtBxDescricaoEmpresaRed_LostFocus(object sender, EventArgs e)
        {
            this.txtBxDescricaoEmpresaRed.BackColor = Color.White;
        }

        void txtBxDescricaoEmpresaRed_GotFocus(object sender, EventArgs e)
        {
            this.txtBxDescricaoEmpresaRed.BackColor = Color.LightYellow;
        }

        void txtBxHost_LostFocus(object sender, EventArgs e)
        {
            this.txtBxHost.BackColor = Color.White;
        }

        void txtBxHost_GotFocus(object sender, EventArgs e)
        {
            this.txtBxHost.BackColor = Color.LightYellow;
        }

        void txtBxPort_LostFocus(object sender, EventArgs e)
        {
            this.txtBxPort.BackColor = Color.White;
        }

        void txtBxPort_GotFocus(object sender, EventArgs e)
        {
            this.txtBxPort.BackColor = Color.LightYellow;
        }

        void txtBxUsername_LostFocus(object sender, EventArgs e)
        {
            this.txtBxUsername.BackColor = Color.White;
        }

        void txtBxUsername_GotFocus(object sender, EventArgs e)
        {
            this.txtBxUsername.BackColor = Color.LightYellow;
        }

        void txtBxSenha_LostFocus(object sender, EventArgs e)
        {
            this.txtBxSenha.BackColor = Color.White;
        }

        void txtBxSenha_GotFocus(object sender, EventArgs e)
        {
            this.txtBxSenha.BackColor = Color.LightYellow;
        }

        void txtBxEmail_LostFocus(object sender, EventArgs e)
        {
            this.txtBxEmail.BackColor = Color.White;
        }

        void txtBxEmail_GotFocus(object sender, EventArgs e)
        {
            this.txtBxEmail.BackColor = Color.LightYellow;
        }

        void txtBxEnderecoBanco_LostFocus(object sender, EventArgs e)
        {
            this.txtBxEnderecoBanco.BackColor = Color.White;
        }

        void txtBxEnderecoBanco_GotFocus(object sender, EventArgs e)
        {
            this.txtBxEnderecoBanco.BackColor = Color.LightYellow;
        }

        void txtBxVersao_LostFocus(object sender, EventArgs e)
        {
            this.txtBxVersao.BackColor = Color.White;
        }

        void txtBxVersao_GotFocus(object sender, EventArgs e)
        {
            this.txtBxVersao.BackColor = Color.LightYellow;
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
            ExecuteModifyEmpresa();

            if (txtBxDescricaoEmpresa.Text == string.Empty)
            {
                ErrPrvdrEmpresa.SetError(txtBxDescricaoEmpresa, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxDescricaoEmpresa.Focus();
                return;
            }

            if (txtBxDescricaoEmpresaRed.Text == string.Empty)
            {
                ErrPrvdrEmpresa.SetError(txtBxDescricaoEmpresaRed, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxDescricaoEmpresaRed.Focus();
                return;
            }

            if (txtBxVersao.Text == string.Empty)
            {
                ErrPrvdrEmpresa.SetError(txtBxVersao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxVersao.Focus();
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

        private void ExecuteModifyEmpresa()
        {
            switch (ModificaEmpresaType)
            {
                case ModificaEmpresaType.EmpresaAdicionar:
                    ExecuteAddEmpresa();
                    break;
                case ModificaEmpresaType.EmpresaAlterar:
                    ExecuteUpdateEmpresa();
                    break;
            }
        }

        private void ExecuteUpdateEmpresa()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteUpdateEmpresa";

            int _CodigoEmpresa = 0;
            string _DescricaoEmpresa = txtBxDescricaoEmpresa.Text;
            string _DescricaoEmpresaRed = txtBxDescricaoEmpresaRed.Text;
            int _CodigoEmpresaConsolidada = 0;
            int _CodigoRg = 0;
            string _Host = txtBxHost.Text;
            int _Port = 0;
            string _Username = txtBxUsername.Text;
            string _Senha = txtBxSenha.Text;
            string _Email = txtBxEmail.Text;
            string _EnderecoBanco = txtBxEnderecoBanco.Text;
            string _Versao = txtBxVersao.Text;
            string _TipoModificacao = string.Empty;
            
            _CodigoEmpresa = Convert.ToInt32(txtBxCodigoEmpresa.Text);
            _Port = Convert.ToInt32(txtBxPort.Text);
            _CodigoEmpresaConsolidada = Convert.ToInt32(cmbBxEmpresaConsolidada.SelectedValue);
            _TipoModificacao = EmpresaProcess.CreateInstance.FromToModificaEmpresa(ModificaEmpresaType.EmpresaAlterar);

            Ativa = ckBxAtiva.Checked ? "S" : "N";

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }
                _IdExecute = EmpresaProcess.CreateInstance.TaskModifyProcessEmpresa(_CodigoEmpresa, _DescricaoEmpresa, _DescricaoEmpresaRed, _CodigoEmpresaConsolidada, Ativa, _CodigoRg, _Host, _Port, _Username, _Senha, _Email, _EnderecoBanco, _Versao, _TipoModificacao);
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

                if (_LogCodigoEmpresa != null) { _LogCodigoEmpresa.ValorNovo = _CodigoEmpresa; }
                if (_LogDescricaoEmpresa != null) { _LogDescricaoEmpresa.ValorNovo = _DescricaoEmpresa; }
                if (_LogDescricaoEmpresaRed != null) { _LogDescricaoEmpresaRed.ValorNovo = _DescricaoEmpresaRed; }
                if (_LogCodigoEmpresaConsolidada != null) { _LogCodigoEmpresaConsolidada.ValorNovo = _CodigoEmpresaConsolidada; }
                if (_LogAtiva != null) { _LogAtiva.ValorNovo = Ativa; }
                if (_LogCodigoRg != null) { _LogCodigoRg.ValorNovo = _CodigoRg; }
                if (_LogHost != null) { _LogHost.ValorNovo = _Host; }
                if (_LogPort != null) { _LogPort.ValorNovo = _Port; }
                if (_LogUsername != null) { _LogUsername.ValorNovo = _Username; }
                if (_LogSenha != null) { _LogSenha.ValorNovo = _Senha; }
                if (_LogEmail != null) { _LogEmail.ValorNovo = _Email; }
                if (_LogEnderecoBanco != null) { _LogEnderecoBanco.ValorNovo = _EnderecoBanco; }
                if (_LogVersao != null) { _LogVersao.ValorNovo = _Versao; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogCodigoEmpresa);
                _ChangeItems.Add(_LogDescricaoEmpresa);
                _ChangeItems.Add(_LogDescricaoEmpresaRed);
                _ChangeItems.Add(_LogCodigoEmpresaConsolidada);
                _ChangeItems.Add(_LogAtiva);
                _ChangeItems.Add(_LogCodigoRg);
                _ChangeItems.Add(_LogHost);
                _ChangeItems.Add(_LogPort);
                _ChangeItems.Add(_LogUsername);
                _ChangeItems.Add(_LogSenha);
                _ChangeItems.Add(_LogEmail);
                _ChangeItems.Add(_LogEnderecoBanco);
                _ChangeItems.Add(_LogVersao);

                #endregion

                ExecuteModifyExceptionLogEmpresa(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogCodigoEmpresa != null) { _LogCodigoEmpresa.ValorNovo = _CodigoEmpresa; }
                    if (_LogDescricaoEmpresa != null) { _LogDescricaoEmpresa.ValorNovo = _DescricaoEmpresa; }
                    if (_LogDescricaoEmpresaRed != null) { _LogDescricaoEmpresaRed.ValorNovo = _DescricaoEmpresaRed; }
                    if (_LogCodigoEmpresaConsolidada != null) { _LogCodigoEmpresaConsolidada.ValorNovo = _CodigoEmpresaConsolidada; }
                    if (_LogAtiva != null) { _LogAtiva.ValorNovo = Ativa; }
                    if (_LogCodigoRg != null) { _LogCodigoRg.ValorNovo = _CodigoRg; }
                    if (_LogHost != null) { _LogHost.ValorNovo = _Host; }
                    if (_LogPort != null) { _LogPort.ValorNovo = _Port; }
                    if (_LogUsername != null) { _LogUsername.ValorNovo = _Username; }
                    if (_LogSenha != null) { _LogSenha.ValorNovo = _Senha; }
                    if (_LogEmail != null) { _LogEmail.ValorNovo = _Email; }
                    if (_LogEnderecoBanco != null) { _LogEnderecoBanco.ValorNovo = _EnderecoBanco; }
                    if (_LogVersao != null) { _LogVersao.ValorNovo = _Versao; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogCodigoEmpresa);
                    _ChangeItems.Add(_LogDescricaoEmpresa);
                    _ChangeItems.Add(_LogDescricaoEmpresaRed);
                    _ChangeItems.Add(_LogCodigoEmpresaConsolidada);
                    _ChangeItems.Add(_LogAtiva);
                    _ChangeItems.Add(_LogCodigoRg);
                    _ChangeItems.Add(_LogHost);
                    _ChangeItems.Add(_LogPort);
                    _ChangeItems.Add(_LogUsername);
                    _ChangeItems.Add(_LogSenha);
                    _ChangeItems.Add(_LogEmail);
                    _ChangeItems.Add(_LogEnderecoBanco);
                    _ChangeItems.Add(_LogVersao);

                    #endregion

                    ExecuteModifyLogEmpresa(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void ExecuteAddEmpresa()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteAddEmpresa";

            int _CodigoEmpresa = 0;
            string _DescricaoEmpresa = txtBxDescricaoEmpresa.Text;
            string _DescricaoEmpresaRed = txtBxDescricaoEmpresaRed.Text;
            int _CodigoEmpresaConsolidada = 0;
            int _CodigoRg = 0;
            string _Host = txtBxHost.Text;
            int _Port = 0;
            string _Username = txtBxUsername.Text;
            string _Senha = txtBxSenha.Text;
            string _Email = txtBxEmail.Text;
            string _EnderecoBanco = txtBxEnderecoBanco.Text;
            string _Versao = txtBxVersao.Text;
            string _TipoModificacao = string.Empty;

            _CodigoEmpresa = Convert.ToInt32(txtBxCodigoEmpresa.Text);
            _Port = Convert.ToInt32(txtBxPort.Text);
            _CodigoEmpresaConsolidada = Convert.ToInt32(cmbBxEmpresaConsolidada.SelectedValue);
            _TipoModificacao = EmpresaProcess.CreateInstance.FromToModificaEmpresa(ModificaEmpresaType.EmpresaAdicionar);

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }
                _IdExecute = EmpresaProcess.CreateInstance.TaskModifyProcessEmpresa(_CodigoEmpresa, _DescricaoEmpresa, _DescricaoEmpresaRed, _CodigoEmpresaConsolidada, Ativa, _CodigoRg, _Host, _Port, _Username, _Senha, _Email, _EnderecoBanco, _Versao, _TipoModificacao);
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

                if (_LogCodigoEmpresa != null) { _LogCodigoEmpresa.ValorNovo = _CodigoEmpresa; }
                if (_LogDescricaoEmpresa != null) { _LogDescricaoEmpresa.ValorNovo = _DescricaoEmpresa; }
                if (_LogDescricaoEmpresaRed != null) { _LogDescricaoEmpresaRed.ValorNovo = _DescricaoEmpresaRed; }
                if (_LogCodigoEmpresaConsolidada != null) { _LogCodigoEmpresaConsolidada.ValorNovo = _CodigoEmpresaConsolidada; }
                if (_LogAtiva != null) { _LogAtiva.ValorNovo = Ativa; }
                if (_LogCodigoRg != null) { _LogCodigoRg.ValorNovo = _CodigoRg; }
                if (_LogHost != null) { _LogHost.ValorNovo = _Host; }
                if (_LogPort != null) { _LogPort.ValorNovo = _Port; }
                if (_LogUsername != null) { _LogUsername.ValorNovo = _Username; }
                if (_LogSenha != null) { _LogSenha.ValorNovo = _Senha; }
                if (_LogEmail != null) { _LogEmail.ValorNovo = _Email; }
                if (_LogEnderecoBanco != null) { _LogEnderecoBanco.ValorNovo = _EnderecoBanco; }
                if (_LogVersao != null) { _LogVersao.ValorNovo = _Versao; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogCodigoEmpresa);
                _ChangeItems.Add(_LogDescricaoEmpresa);
                _ChangeItems.Add(_LogDescricaoEmpresaRed);
                _ChangeItems.Add(_LogCodigoEmpresaConsolidada);
                _ChangeItems.Add(_LogAtiva);
                _ChangeItems.Add(_LogCodigoRg);
                _ChangeItems.Add(_LogHost);
                _ChangeItems.Add(_LogPort);
                _ChangeItems.Add(_LogUsername);
                _ChangeItems.Add(_LogSenha);
                _ChangeItems.Add(_LogEmail);
                _ChangeItems.Add(_LogEnderecoBanco);
                _ChangeItems.Add(_LogVersao);

                #endregion

                ExecuteModifyExceptionLogEmpresa(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogCodigoEmpresa != null) { _LogCodigoEmpresa.ValorNovo = _CodigoEmpresa; }
                    if (_LogDescricaoEmpresa != null) { _LogDescricaoEmpresa.ValorNovo = _DescricaoEmpresa; }
                    if (_LogDescricaoEmpresaRed != null) { _LogDescricaoEmpresaRed.ValorNovo = _DescricaoEmpresaRed; }
                    if (_LogCodigoEmpresaConsolidada != null) { _LogCodigoEmpresaConsolidada.ValorNovo = _CodigoEmpresaConsolidada; }
                    if (_LogAtiva != null) { _LogAtiva.ValorNovo = Ativa; }
                    if (_LogCodigoRg != null) { _LogCodigoRg.ValorNovo = _CodigoRg; }
                    if (_LogHost != null) { _LogHost.ValorNovo = _Host; }
                    if (_LogPort != null) { _LogPort.ValorNovo = _Port; }
                    if (_LogUsername != null) { _LogUsername.ValorNovo = _Username; }
                    if (_LogSenha != null) { _LogSenha.ValorNovo = _Senha; }
                    if (_LogEmail != null) { _LogEmail.ValorNovo = _Email; }
                    if (_LogEnderecoBanco != null) { _LogEnderecoBanco.ValorNovo = _EnderecoBanco; }
                    if (_LogVersao != null) { _LogVersao.ValorNovo = _Versao; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogCodigoEmpresa);
                    _ChangeItems.Add(_LogDescricaoEmpresa);
                    _ChangeItems.Add(_LogDescricaoEmpresaRed);
                    _ChangeItems.Add(_LogCodigoEmpresaConsolidada);
                    _ChangeItems.Add(_LogAtiva);
                    _ChangeItems.Add(_LogCodigoRg);
                    _ChangeItems.Add(_LogHost);
                    _ChangeItems.Add(_LogPort);
                    _ChangeItems.Add(_LogUsername);
                    _ChangeItems.Add(_LogSenha);
                    _ChangeItems.Add(_LogEmail);
                    _ChangeItems.Add(_LogEnderecoBanco);
                    _ChangeItems.Add(_LogVersao);

                    #endregion

                    ExecuteModifyLogEmpresa(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void ExecuteModifyLogEmpresa(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }

        private void ExecuteModifyExceptionLogEmpresa(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void FillLogHeaderFromUpdateModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboGeEmpresa.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdEmpr;
            _ChangesHeader.TipoModificacao = EmpresaProcess.CreateInstance.FromToModificaEmpresa(ModificaEmpresaType.EmpresaExcluir);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Empresa
            _LogCodigoEmpresa = new ChangeItem();
            _LogCodigoEmpresa.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoEmpresa.IdItem = 1;
            _LogCodigoEmpresa.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogCodigoEmpresa.NomeCampo = DboGeEmpresa.NomeCodigoEmpresa;
            _LogCodigoEmpresa.ValorAntigo = CodigoEmpresa;

            //Descrição Empresa
            _LogDescricaoEmpresa = new ChangeItem();
            _LogDescricaoEmpresa.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricaoEmpresa.IdItem = 2;
            _LogDescricaoEmpresa.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogDescricaoEmpresa.NomeCampo = DboGeEmpresa.NomeDescricaoEmpresa;
            _LogDescricaoEmpresa.ValorAntigo = DescricaoEmpresa;

            //Descrição Empresa Reduzida
            _LogDescricaoEmpresaRed = new ChangeItem();
            _LogDescricaoEmpresaRed.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricaoEmpresaRed.IdItem = 3;
            _LogDescricaoEmpresaRed.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogDescricaoEmpresaRed.NomeCampo = DboGeEmpresa.NomeDescricaoEmpresaRed;
            _LogDescricaoEmpresaRed.ValorAntigo = DescricaoEmpresaRed;

            //Sequencia Aplicação
            _LogCodigoEmpresaConsolidada = new ChangeItem();
            _LogCodigoEmpresaConsolidada.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoEmpresaConsolidada.IdItem = 4;
            _LogCodigoEmpresaConsolidada.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogCodigoEmpresaConsolidada.NomeCampo = DboGeEmpresa.NomeCodigoEmpresaConsolidada;
            _LogCodigoEmpresaConsolidada.ValorAntigo = CodigoEmpresaConsolidada;

            //Ativa 
            _LogAtiva = new ChangeItem();
            _LogAtiva.IdChangeHeader = _ChangesHeader.Id;
            _LogAtiva.IdItem = 5;
            _LogAtiva.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogAtiva.NomeCampo = DboGeEmpresa.NomeAtiva;
            _LogAtiva.ValorAntigo = Ativa;

            //Codigo Rg
            _LogCodigoRg = new ChangeItem();
            _LogCodigoRg.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoRg.IdItem = 6;
            _LogCodigoRg.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogCodigoRg.NomeCampo = DboGeEmpresa.NomeCodigoRg;
            _LogCodigoRg.ValorAntigo = CodigoRg;

            //Host
            _LogHost = new ChangeItem();
            _LogHost.IdChangeHeader = _ChangesHeader.Id;
            _LogHost.IdItem = 7;
            _LogHost.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogHost.NomeCampo = DboGeEmpresa.NomeHost;
            _LogHost.ValorAntigo = Host;

            //Port
            _LogPort = new ChangeItem();
            _LogPort.IdChangeHeader = _ChangesHeader.Id;
            _LogPort.IdItem = 8;
            _LogPort.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogPort.NomeCampo = DboGeEmpresa.NomePort;
            _LogPort.ValorAntigo = Port;

            //User Name
            _LogUsername = new ChangeItem();
            _LogUsername.IdChangeHeader = _ChangesHeader.Id;
            _LogUsername.IdItem = 9;
            _LogUsername.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogUsername.NomeCampo = DboGeEmpresa.NomeUsername;
            _LogUsername.ValorAntigo = Username;

            //Senha
            _LogSenha = new ChangeItem();
            _LogSenha.IdChangeHeader = _ChangesHeader.Id;
            _LogSenha.IdItem = 10;
            _LogSenha.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogSenha.NomeCampo = DboGeEmpresa.NomeSenha;
            _LogSenha.ValorAntigo = Senha;

            //Email
            _LogEmail = new ChangeItem();
            _LogEmail.IdChangeHeader = _ChangesHeader.Id;
            _LogEmail.IdItem = 11;
            _LogEmail.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogEmail.NomeCampo = DboGeEmpresa.NomeEmail;
            _LogEmail.ValorAntigo = Email;

            //Endereço Banco
            _LogEnderecoBanco = new ChangeItem();
            _LogEnderecoBanco.IdChangeHeader = _ChangesHeader.Id;
            _LogEnderecoBanco.IdItem = 12;
            _LogEnderecoBanco.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogEnderecoBanco.NomeCampo = DboGeEmpresa.NomeEnderecoBanco;
            _LogEnderecoBanco.ValorAntigo = EnderecoBanco;

            //Versão
            _LogVersao = new ChangeItem();
            _LogVersao.IdChangeHeader = _ChangesHeader.Id;
            _LogVersao.IdItem = 13;
            _LogVersao.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogVersao.NomeCampo = DboGeEmpresa.NomeVersao;
            _LogVersao.ValorAntigo = Versao;

            #endregion
        }

        private void FillLogHeaderFromAddModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboGeEmpresa.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdEmpr;
            _ChangesHeader.TipoModificacao = EmpresaProcess.CreateInstance.FromToModificaEmpresa(ModificaEmpresaType.EmpresaExcluir);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Empresa
            _LogCodigoEmpresa = new ChangeItem();
            _LogCodigoEmpresa.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoEmpresa.IdItem = 1;
            _LogCodigoEmpresa.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogCodigoEmpresa.NomeCampo = DboGeEmpresa.NomeCodigoEmpresa;
            //_LogCodigoEmpresa.ValorAntigo = CodigoEmpresa;

            //Descrição Empresa
            _LogDescricaoEmpresa = new ChangeItem();
            _LogDescricaoEmpresa.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricaoEmpresa.IdItem = 2;
            _LogDescricaoEmpresa.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogDescricaoEmpresa.NomeCampo = DboGeEmpresa.NomeDescricaoEmpresa;
            //_LogDescricaoEmpresa.ValorAntigo = DescricaoEmpresa;

            //Descrição Empresa Reduzida
            _LogDescricaoEmpresaRed = new ChangeItem();
            _LogDescricaoEmpresaRed.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricaoEmpresaRed.IdItem = 3;
            _LogDescricaoEmpresaRed.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogDescricaoEmpresaRed.NomeCampo = DboGeEmpresa.NomeDescricaoEmpresaRed;
            //_LogDescricaoEmpresaRed.ValorAntigo = DescricaoEmpresaRed;

            //Sequencia Aplicação
            _LogCodigoEmpresaConsolidada = new ChangeItem();
            _LogCodigoEmpresaConsolidada.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoEmpresaConsolidada.IdItem = 4;
            _LogCodigoEmpresaConsolidada.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogCodigoEmpresaConsolidada.NomeCampo = DboGeEmpresa.NomeCodigoEmpresaConsolidada;
            //_LogCodigoEmpresaConsolidada.ValorAntigo = CodigoEmpresaConsolidada;

            //Ativa 
            _LogAtiva = new ChangeItem();
            _LogAtiva.IdChangeHeader = _ChangesHeader.Id;
            _LogAtiva.IdItem = 5;
            _LogAtiva.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogAtiva.NomeCampo = DboGeEmpresa.NomeAtiva;
            //_LogAtiva.ValorAntigo = Ativa;

            //Codigo Rg
            _LogCodigoRg = new ChangeItem();
            _LogCodigoRg.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoRg.IdItem = 6;
            _LogCodigoRg.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogCodigoRg.NomeCampo = DboGeEmpresa.NomeCodigoRg;
            //_LogCodigoRg.ValorAntigo = CodigoRg;

            //Host
            _LogHost = new ChangeItem();
            _LogHost.IdChangeHeader = _ChangesHeader.Id;
            _LogHost.IdItem = 7;
            _LogHost.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogHost.NomeCampo = DboGeEmpresa.NomeHost;
            //_LogHost.ValorAntigo = Host;

            //Port
            _LogPort = new ChangeItem();
            _LogPort.IdChangeHeader = _ChangesHeader.Id;
            _LogPort.IdItem = 8;
            _LogPort.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogPort.NomeCampo = DboGeEmpresa.NomePort;
            //_LogPort.ValorAntigo = Port;

            //User Name
            _LogUsername = new ChangeItem();
            _LogUsername.IdChangeHeader = _ChangesHeader.Id;
            _LogUsername.IdItem = 9;
            _LogUsername.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogUsername.NomeCampo = DboGeEmpresa.NomeUsername;
            //_LogUsername.ValorAntigo = Username;

            //Senha
            _LogSenha = new ChangeItem();
            _LogSenha.IdChangeHeader = _ChangesHeader.Id;
            _LogSenha.IdItem = 10;
            _LogSenha.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogSenha.NomeCampo = DboGeEmpresa.NomeSenha;
            //_LogSenha.ValorAntigo = Senha;

            //Email
            _LogEmail = new ChangeItem();
            _LogEmail.IdChangeHeader = _ChangesHeader.Id;
            _LogEmail.IdItem = 11;
            _LogEmail.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogEmail.NomeCampo = DboGeEmpresa.NomeEmail;
            //_LogEmail.ValorAntigo = Email;

            //Endereço Banco
            _LogEnderecoBanco = new ChangeItem();
            _LogEnderecoBanco.IdChangeHeader = _ChangesHeader.Id;
            _LogEnderecoBanco.IdItem = 12;
            _LogEnderecoBanco.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogEnderecoBanco.NomeCampo = DboGeEmpresa.NomeEnderecoBanco;
            //_LogEnderecoBanco.ValorAntigo = EnderecoBanco;

            //Versão
            _LogVersao = new ChangeItem();
            _LogVersao.IdChangeHeader = _ChangesHeader.Id;
            _LogVersao.IdItem = 13;
            _LogVersao.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogVersao.NomeCampo = DboGeEmpresa.NomeVersao;
            //_LogVersao.ValorAntigo = Versao;

            #endregion
        }
        private void UpdateFormEmpresa_Load(object sender, System.EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;

            _DataSetEmpresaConsolidadRegistroGeralPorVinculo = EmpresaProcess.CreateInstance.TaskGeCollectionGeRetornaEmpresaConsolidadaRegistroGeralPorVinculo();

            FillEmpresaConsolidadaCollection();
            FillIntegracaoRegGeralCollection();

            switch (ModificaEmpresaType)
            {
                case ModificaEmpresaType.EmpresaAdicionar:
                    FillLogHeaderFromAddModify();
                    FillProcessoToAddModify();
                    break;
                case ModificaEmpresaType.EmpresaAlterar:
                    FillLogHeaderFromUpdateModify();
                    FillDataParametersToExecuteUpdateModify();
                    FillProcessoToUpdateModify();
                    break;
                case ModificaEmpresaType.EmpresaExcluir:
                    break;
                default:
                    break;
            }
        }

        private void FillProcessoToAddModify()
        {
            cmbBxEmpresaConsolidada.DataSource = GeEmpresaConsolidada;
            cmbBxEmpresaConsolidada.ValueMember = "CodigoEmpresaConsolidada";
            cmbBxEmpresaConsolidada.DisplayMember = "DescricaoEmpresaConsolidada";

            cmbBxCodigoRg.DataSource = IntegracaoRegGeralCollection;
            cmbBxCodigoRg.ValueMember = "IdRg";
            cmbBxCodigoRg.DisplayMember = "RazaoSocial";

            AppStateManager.CodigoEmpresaConsolidadaRegGeralPorVinculo = Convert.ToInt32(cmbBxEmpresaConsolidada.SelectedValue);
            AppStateManager.CodigoEmpresaConsolidadaRegGeralPorVinculo = Convert.ToInt32(cmbBxCodigoRg.SelectedValue);
        }

        private void FillProcessoToUpdateModify()
        {
            cmbBxEmpresaConsolidada.DataSource = GeEmpresaConsolidada;
            cmbBxEmpresaConsolidada.ValueMember = "CodigoEmpresaConsolidada";
            cmbBxEmpresaConsolidada.DisplayMember = "DescricaoEmpresaConsolidada";
            cmbBxEmpresaConsolidada.SelectedValue = this.CodigoEmpresaConsolidada;

            cmbBxCodigoRg.DataSource = IntegracaoRegGeralCollection;
            cmbBxCodigoRg.ValueMember = "IdRg";
            cmbBxCodigoRg.DisplayMember = "RazaoSocial";
            cmbBxCodigoRg.SelectedValue = this.CodigoRg;

            AppStateManager.CodigoEmpresaConsolidadaRegGeralPorVinculo = Convert.ToInt32(cmbBxEmpresaConsolidada.SelectedValue);
            AppStateManager.CodigoEmpresaConsolidadaRegGeralPorVinculo = Convert.ToInt32(cmbBxCodigoRg.SelectedValue);
        }

        private void FillEmpresaConsolidadaCollection()
        {
            if (_GeEmpresaConsolidadaCollection == null)
            {
                _GeEmpresaConsolidadaCollection = new List<GeEmpresaConsolidada>();
            }

            foreach (DataRow _Row in _DataSetEmpresaConsolidadRegistroGeralPorVinculo.Tables[0].Rows)
            {
                _GeEmpresaConsolidadaCollection.Add(new GeEmpresaConsolidada(_Row));
            }

            GeEmpresaConsolidada = _GeEmpresaConsolidadaCollection;
        }

        private void FillIntegracaoRegGeralCollection()
        {
            if (_IntegracaoRegGeralCollection == null)
            {
                _IntegracaoRegGeralCollection = new List<IntegracaoRegGeral>();
            }

            foreach (DataRow _Row in _DataSetEmpresaConsolidadRegistroGeralPorVinculo.Tables[1].Rows)
            {
                _IntegracaoRegGeralCollection.Add(new IntegracaoRegGeral(_Row));
            }

            IntegracaoRegGeralCollection = _IntegracaoRegGeralCollection;
        }

        private void FillDataParametersToExecuteUpdateModify()
        {
            txtBxCodigoEmpresa.Text = CodigoEmpresa.ToString();
            txtBxDescricaoEmpresa.Text = DescricaoEmpresa;

            txtBxCodigoEmpresa.Text = CodigoEmpresa.ToString();
            txtBxDescricaoEmpresa.Text = DescricaoEmpresa;
            txtBxDescricaoEmpresaRed.Text = DescricaoEmpresaRed;
            cmbBxEmpresaConsolidada.SelectedValue = CodigoEmpresaConsolidada.ToString();
            cmbBxCodigoRg.SelectedValue = CodigoRg.ToString();
            
            ckBxAtiva.Checked = (Ativa == "S" ? true : false);

            txtBxHost.Text = Host;
            txtBxPort.Text = Port.ToString();
            txtBxUsername.Text = Username;
            txtBxSenha.Text = Senha;
            txtBxEmail.Text = Email;
            txtBxEnderecoBanco.Text = EnderecoBanco;
            txtBxVersao.Text = Versao;
        }

        private void tlstrpActionMenuBtnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        // ...::: INICIO VALIDAÇÕES :::...
        private void txtBxDescricaoEmpresa_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxDescricaoEmpresa.Text == string.Empty)
            {
                ErrPrvdrEmpresa.SetError(txtBxDescricaoEmpresa, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrEmpresa.SetError(txtBxDescricaoEmpresa, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxDescricaoEmpresaRed_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxDescricaoEmpresaRed.Text == string.Empty)
            {
                ErrPrvdrEmpresa.SetError(txtBxDescricaoEmpresaRed, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrEmpresa.SetError(txtBxDescricaoEmpresaRed, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxSenha_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ValidationData.CreateInstance.ValidaSenha(txtBxSenha.Text))
            {
                ErrPrvdrEmpresa.SetError(txtBxSenha, ValidationsMessages.VALIDA_SENHA);
            }
            else
            {
                ErrPrvdrEmpresa.SetError(txtBxSenha, string.Empty);
            }               
        }

        private void txtBxEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ValidationData.CreateInstance.ValidaEMail(txtBxEmail.Text))
            {
                ErrPrvdrEmpresa.SetError(txtBxEmail, ValidationsMessages.VALIDA_EMAIL);
            }
            else
            {
                ErrPrvdrEmpresa.SetError(txtBxEmail, string.Empty);
            }   
        }

        private void txtBxVersao_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxVersao.Text == string.Empty)
            {
                ErrPrvdrEmpresa.SetError(txtBxVersao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrEmpresa.SetError(txtBxVersao, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxDescricaoEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrEmpresa.SetError(txtBxDescricaoEmpresa, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxDescricaoEmpresaRed_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrEmpresa.SetError(txtBxDescricaoEmpresaRed, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxVersao_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrEmpresa.SetError(txtBxVersao, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }
    }

    internal static class DboGeEmpresa
    {
        #region ...::: Private Constantes :::...

        private const string _NomeCodigoEmpresa = "cod_empr";
        private const string _NomeDescricaoEmpresa = "descr_empr";
        private const string _NomeDescricaoEmpresaRed = "descr_empr_red";
        private const string _NomeCodigoEmpresaConsolidada = "cod_empr_consol";
        private const string _NomeAtiva = "ativa";
        private const string _NomeCodigoRg = "cod_rg";
        private const string _NomeHost = "host";
        private const string _NomePort = "port";
        private const string _NomeUsername = "username";
        private const string _NomeSenha = "senha";
        private const string _NomeEmail = "e_mail";
        private const string _NomeEnderecoBanco = "endereco_banco";
        private const string _NomeVersao = "versao";

        private const string _NomeTabela = "ge_empresa";
        private const string _NomeProcesso = "Empresa";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeCodigoEmpresa { get { return _NomeCodigoEmpresa; } }
        public static string NomeDescricaoEmpresa { get { return _NomeDescricaoEmpresa; } }
        public static string NomeDescricaoEmpresaRed { get { return _NomeDescricaoEmpresaRed; } }
        public static string NomeCodigoEmpresaConsolidada { get { return _NomeCodigoEmpresaConsolidada; } }
        public static string NomeAtiva { get { return _NomeAtiva; } }
        public static string NomeCodigoRg { get { return _NomeCodigoRg; } }
        public static string NomeHost { get { return _NomeHost; } }
        public static string NomePort { get { return _NomePort; } }
        public static string NomeUsername { get { return _NomeUsername; } }
        public static string NomeSenha { get { return _NomeSenha; } }
        public static string NomeEmail { get { return _NomeEmail; } }
        public static string NomeEnderecoBanco { get { return _NomeEnderecoBanco; } }
        public static string NomeVersao { get { return _NomeVersao; } }


        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
