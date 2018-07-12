using BrSoftNet.App.Business.Processes.Manager.Enumerators;
using BrSoftNet.App.Business.Processes.Manager.Tasks;
using System;
using System.Drawing;
using System.Windows.Forms;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Library.Messages;
using BrSoftNet.Log.Helpers;
using BrSoftNet.Log.Structures;
using System.Collections.Generic;
using BrSoftNet.Log.Actions;

namespace BrSoftNet.App.UI.Win.Manager.DialogUpdateForm
{
    public partial class UpdateFormEmpresaConsolidada : Form
    {
        #region ...::: Private Variable :::...

        private string _TipoModificacao = string.Empty;

        private int _IdExecute = 0;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpr { get; set; }
        public int IdRg { get; set; }
        public string UsuarioLogin { get; set; }
        public ModificaEmpresaConsolidadaType ModificaEmpresaConsolidadaType { get; set; }
        public int CodigoEmpresaConsolidada { get; set; }
        public string DescricaoEmpresaConsolidada { get; set; }
        public string AtivaEmpresaConsolidada { get; set; }
        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;

        private ChangeItem _LogCodigoEmpresaConsolidada = null;
        private ChangeItem _LogDescricaoEmpresaConsolidada = null;
        private ChangeItem _LogAtivaEmpresaConsolidada = null;

        private List<ChangeItem> _ChangeItems = null;
        private ThrowingException _ThrowingException = null;

        private string _IdExcepitionLog = string.Empty;
        private string _MenssageLogError = string.Empty;

        #endregion

        public UpdateFormEmpresaConsolidada()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();

            this.txtBxDescricao.GotFocus += txtBxDescricao_GotFocus;
            this.txtBxDescricao.LostFocus += txtBxDescricao_LostFocus;
        }

        void txtBxDescricao_LostFocus(object sender, EventArgs e)
        {
            this.txtBxDescricao.BackColor = Color.White;
        }

        void txtBxDescricao_GotFocus(object sender, EventArgs e)
        {
            this.txtBxDescricao.BackColor = Color.LightYellow;
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
            ExecuteModifyEmpresaConsolidada();

            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrEmpresaConsolidada.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxDescricao.Focus();
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

        private void ExecuteModifyEmpresaConsolidada()
        {
            switch (ModificaEmpresaConsolidadaType)
            {
                case ModificaEmpresaConsolidadaType.EmpresaConsolidadaAdicionar:
                    ExecuteAddEmpresaConsolidada();
                    break;
                case ModificaEmpresaConsolidadaType.EmpresaConsolidadaAlterar:
                    ExecuteUpdateEmpresaConsolidada();
                    break;
            }
        }

        private void ExecuteUpdateEmpresaConsolidada()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteUpdateEmpresaConsolidada";

            int _CodigoEmpresaConsolidada = 0;
            string _DescricaoEmpresaConsolidada = string.Empty;
            string _AtivaEmpresaConsolidada = string.Empty;
            string _TipoModificacao = string.Empty;

            _CodigoEmpresaConsolidada = Convert.ToInt32(txtBxCodEmpresa.Text);
            _DescricaoEmpresaConsolidada = txtBxDescricao.Text;
            _TipoModificacao = EmpresaConsolidadaProcess.CreateInstance.FromToModificaEmpresaConsolidada(ModificaEmpresaConsolidadaType.EmpresaConsolidadaAlterar);

            AtivaEmpresaConsolidada = ckBxAtiva.Checked ? "S" : "N";
            
            try
            {
                _IdExecute = EmpresaConsolidadaProcess.CreateInstance.TaskModifyProcessEmpresaConsolidada(_CodigoEmpresaConsolidada, _DescricaoEmpresaConsolidada, AtivaEmpresaConsolidada, _TipoModificacao);
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

                #endregion

                #region ...::: Atualiza os Itens do Log de Modificações :::...

                if (_LogCodigoEmpresaConsolidada != null) { _LogCodigoEmpresaConsolidada.ValorNovo = _CodigoEmpresaConsolidada; }
                if (_LogDescricaoEmpresaConsolidada != null) { _LogDescricaoEmpresaConsolidada.ValorNovo = _DescricaoEmpresaConsolidada; }
                if (_LogAtivaEmpresaConsolidada != null) { _LogAtivaEmpresaConsolidada.ValorNovo = _AtivaEmpresaConsolidada; }


                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogCodigoEmpresaConsolidada);
                _ChangeItems.Add(_LogDescricaoEmpresaConsolidada);
                _ChangeItems.Add(_LogAtivaEmpresaConsolidada);
                #endregion

                ExecuteModifyExceptionLogEmpresaConsolidada(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogCodigoEmpresaConsolidada != null) { _LogCodigoEmpresaConsolidada.ValorNovo = _CodigoEmpresaConsolidada; }
                    if (_LogDescricaoEmpresaConsolidada != null) { _LogDescricaoEmpresaConsolidada.ValorNovo = _DescricaoEmpresaConsolidada; }
                    if (_LogAtivaEmpresaConsolidada != null)
                    {
                        _LogAtivaEmpresaConsolidada.ValorNovo = _AtivaEmpresaConsolidada
                            ;
                    }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogCodigoEmpresaConsolidada);
                    _ChangeItems.Add(_LogDescricaoEmpresaConsolidada);
                    _ChangeItems.Add(_LogAtivaEmpresaConsolidada);
                    #endregion

                    ExecuteModifyLogEmpresaConsolidada(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void ExecuteAddEmpresaConsolidada()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteAddEmpresaConsolidada";

            txtBxCodEmpresa.Text = "0";
            int _CodigoEmpresaConsolidada = 0;
            string _DescricaoEmpresaConsolidada = string.Empty;
            string _AtivaEmpresaConsolidada = string.Empty;
            string _TipoModificacao = string.Empty;

            _CodigoEmpresaConsolidada = Convert.ToInt32(txtBxCodEmpresa.Text);
            _DescricaoEmpresaConsolidada = txtBxDescricao.Text;
            _TipoModificacao = EmpresaConsolidadaProcess.CreateInstance.FromToModificaEmpresaConsolidada(ModificaEmpresaConsolidadaType.EmpresaConsolidadaAdicionar);
            
            AtivaEmpresaConsolidada = ckBxAtiva.Checked ? "S" : "N";

            try
            {
                _IdExecute = EmpresaConsolidadaProcess.CreateInstance.TaskModifyProcessEmpresaConsolidada(_CodigoEmpresaConsolidada, _DescricaoEmpresaConsolidada, AtivaEmpresaConsolidada, _TipoModificacao);
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

                #endregion

                #region ...::: Atualiza os Itens do Log de Modificações :::...

                if (_LogCodigoEmpresaConsolidada != null) { _LogCodigoEmpresaConsolidada.ValorNovo = _CodigoEmpresaConsolidada; }
                if (_LogDescricaoEmpresaConsolidada != null) { _LogDescricaoEmpresaConsolidada.ValorNovo = _DescricaoEmpresaConsolidada; }
                if (_LogAtivaEmpresaConsolidada != null) { _LogAtivaEmpresaConsolidada.ValorNovo = _AtivaEmpresaConsolidada; }


                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogCodigoEmpresaConsolidada);
                _ChangeItems.Add(_LogDescricaoEmpresaConsolidada);
                _ChangeItems.Add(_LogAtivaEmpresaConsolidada);
                #endregion

                ExecuteModifyExceptionLogEmpresaConsolidada(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogCodigoEmpresaConsolidada != null) { _LogCodigoEmpresaConsolidada.ValorNovo = _CodigoEmpresaConsolidada; }
                    if (_LogDescricaoEmpresaConsolidada != null) { _LogDescricaoEmpresaConsolidada.ValorNovo = _DescricaoEmpresaConsolidada; }
                    if (_LogAtivaEmpresaConsolidada != null)
                    {
                        _LogAtivaEmpresaConsolidada.ValorNovo = _AtivaEmpresaConsolidada
                            ;
                    }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogCodigoEmpresaConsolidada);
                    _ChangeItems.Add(_LogDescricaoEmpresaConsolidada);
                    _ChangeItems.Add(_LogAtivaEmpresaConsolidada);
                    #endregion

                    ExecuteModifyLogEmpresaConsolidada(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void ExecuteModifyLogEmpresaConsolidada(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }

        private void ExecuteModifyExceptionLogEmpresaConsolidada(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void FillLogHeaderFromAddModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboGeEmpresaConsolidada.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdEmpr;
            _ChangesHeader.TipoModificacao = EmpresaConsolidadaProcess.CreateInstance.FromToModificaEmpresaConsolidada(ModificaEmpresaConsolidadaType.EmpresaConsolidadaAdicionar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Aplicação
            _LogCodigoEmpresaConsolidada = new ChangeItem();
            _LogCodigoEmpresaConsolidada.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoEmpresaConsolidada.IdItem = 1;
            _LogCodigoEmpresaConsolidada.NomeTabela = DboGeEmpresaConsolidada.NomeTabela;
            _LogCodigoEmpresaConsolidada.NomeCampo = DboGeEmpresaConsolidada.NomeCodigoEmpresaConsolidada;
            //_LogCodigoEmpresaConsolidada.ValorAntigo = CodigoEmpresaConsolidada;

            //Descrição Aplicação
            _LogDescricaoEmpresaConsolidada = new ChangeItem();
            _LogDescricaoEmpresaConsolidada.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricaoEmpresaConsolidada.IdItem = 2;
            _LogDescricaoEmpresaConsolidada.NomeTabela = DboGeEmpresaConsolidada.NomeTabela;
            _LogDescricaoEmpresaConsolidada.NomeCampo = DboGeEmpresaConsolidada.NomeDescrEmpresaConolidada;
            //_LogDescricaoEmpresaConsolidada.ValorAntigo = DescricaoEmpresaConsolidada;

            //Sigla Aplicação
            _LogAtivaEmpresaConsolidada = new ChangeItem();
            _LogAtivaEmpresaConsolidada.IdChangeHeader = _ChangesHeader.Id;
            _LogAtivaEmpresaConsolidada.IdItem = 3;
            _LogAtivaEmpresaConsolidada.NomeTabela = DboGeEmpresaConsolidada.NomeTabela;
            _LogAtivaEmpresaConsolidada.NomeCampo = DboGeEmpresaConsolidada.NomeAtivaEmpresaConsolidada;
            //_LogAtivaEmpresaConsolidada.ValorAntigo = AtivaEmpresaConsolidada;

            #endregion
        }
        private void FillLogHeaderFromUpdateModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboGeEmpresaConsolidada.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdEmpr;
            _ChangesHeader.TipoModificacao = EmpresaConsolidadaProcess.CreateInstance.FromToModificaEmpresaConsolidada(ModificaEmpresaConsolidadaType.EmpresaConsolidadaAlterar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Aplicação
            _LogCodigoEmpresaConsolidada = new ChangeItem();
            _LogCodigoEmpresaConsolidada.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoEmpresaConsolidada.IdItem = 1;
            _LogCodigoEmpresaConsolidada.NomeTabela = DboGeEmpresaConsolidada.NomeTabela;
            _LogCodigoEmpresaConsolidada.NomeCampo = DboGeEmpresaConsolidada.NomeCodigoEmpresaConsolidada;
            _LogCodigoEmpresaConsolidada.ValorAntigo = CodigoEmpresaConsolidada;

            //Descrição Aplicação
            _LogDescricaoEmpresaConsolidada = new ChangeItem();
            _LogDescricaoEmpresaConsolidada.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricaoEmpresaConsolidada.IdItem = 2;
            _LogDescricaoEmpresaConsolidada.NomeTabela = DboGeEmpresaConsolidada.NomeTabela;
            _LogDescricaoEmpresaConsolidada.NomeCampo = DboGeEmpresaConsolidada.NomeDescrEmpresaConolidada;
            _LogDescricaoEmpresaConsolidada.ValorAntigo = DescricaoEmpresaConsolidada;

            //Sigla Aplicação
            _LogAtivaEmpresaConsolidada = new ChangeItem();
            _LogAtivaEmpresaConsolidada.IdChangeHeader = _ChangesHeader.Id;
            _LogAtivaEmpresaConsolidada.IdItem = 3;
            _LogAtivaEmpresaConsolidada.NomeTabela = DboGeEmpresaConsolidada.NomeTabela;
            _LogAtivaEmpresaConsolidada.NomeCampo = DboGeEmpresaConsolidada.NomeAtivaEmpresaConsolidada;
            _LogAtivaEmpresaConsolidada.ValorAntigo = AtivaEmpresaConsolidada;

            #endregion
        }
        private void UpdateFormEmpresaConsolidada_Load(object sender, System.EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;

            if (ModificaEmpresaConsolidadaType == ModificaEmpresaConsolidadaType.EmpresaConsolidadaAlterar)
            {
                FillLogHeaderFromUpdateModify();
                FillDataParametersToExecuteUpdateModify();
            }

            if (ModificaEmpresaConsolidadaType == ModificaEmpresaConsolidadaType.EmpresaConsolidadaAdicionar)
            {
                FillLogHeaderFromAddModify();
                FillDataParametersToExecuteAddModify();
            }
        }

        private void FillDataParametersToExecuteAddModify()
        {
            if (txtBxCodEmpresa.ReadOnly)
            {
                txtBxCodEmpresa.ReadOnly = false;
            }
        }

        private void FillDataParametersToExecuteUpdateModify()
        {
            ckBxAtiva.Checked = (AtivaEmpresaConsolidada == "S" ? true : false);

            txtBxCodEmpresa.Text = CodigoEmpresaConsolidada.ToString();
            txtBxDescricao.Text = DescricaoEmpresaConsolidada;
            txtBxCodEmpresa.ReadOnly = true;
        }

        // ...::: INICIO VALIDAÇÕES :::...
        private void txtBxDescricao_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrEmpresaConsolidada.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrEmpresaConsolidada.SetError(txtBxDescricao, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrEmpresaConsolidada.SetError(txtBxDescricao, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }
    }

    internal static class DboGeEmpresaConsolidada
    {
        #region ...::: Private Constantes :::...

        private const string _NomeCodigoEmpresaConsolidada = "cod_empr_consol";
        private const string _NomeDescrEmpresaConolidada = "descr_empr_consol";
        private const string _NomeAtivaEmpresaConsolidada = "sigla_aplic";
        private const string _NomeTabela = "ge_empresa_consol";
        private const string _NomeProcesso = "Empresa Consolidada";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeCodigoEmpresaConsolidada { get { return _NomeCodigoEmpresaConsolidada; } }
        public static string NomeDescrEmpresaConolidada { get { return _NomeDescrEmpresaConolidada; } }
        public static string NomeAtivaEmpresaConsolidada { get { return _NomeAtivaEmpresaConsolidada; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
