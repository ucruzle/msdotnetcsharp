using BrSoftNet.App.Business.Processes.OverallRecord.Enumerators;
using BrSoftNet.App.Business.Processes.OverallRecord.Tasks;
using System;
using System.Drawing;
using System.Windows.Forms;
using BrSoftNet.Library.Messages;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Log.Structures;
using System.Collections.Generic;
using BrSoftNet.Log.Helpers;
using BrSoftNet.Log.Actions;

namespace BrSoftNet.App.UI.Win.OverallRecord.DialogUpdateForm
{
    public partial class UpdateFormStatus : Form
    {
        #region ...::: Private Variable :::...

        private string _TipoModificacao = string.Empty;

        private int _IdExecute = 0;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpr { get; set; }
        public int IdRg { get; set; }
        public string UsuarioLogin { get; set; }
        public ModificaStatusType ModificaStatusType { get; set; }
        public int IdRgStatus { get; set; }
        public string DescrStatus { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;

        private ChangeItem _LogIdStatus = null;
        private ChangeItem _LogDescrStatus = null;

        private List<ChangeItem> _ChangeItems = null;

        private ThrowingException _ThrowingException = null;

        private string _IdExcepitionLog = string.Empty;
        private string _MenssageLogError = string.Empty;

        #endregion

        public UpdateFormStatus()
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
            ExecuteModifyStatus();

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

        private void ExecuteModifyStatus()
        {
            switch (ModificaStatusType)
            {
                case ModificaStatusType.StatusAdicionar:
                    ExecuteAddStatus();
                    break;
                case ModificaStatusType.StatusAlterar:
                    ExecuteUpdateStatus();
                    break;
            }
        }

        private void ExecuteUpdateStatus()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteUpdateStatus";

            int _IdRgStatus = 0;
            string _DescrStatus = string.Empty;
            string _TipoModificacao = string.Empty;

            _IdRgStatus = Convert.ToInt32(txtBxCodStatus.Text);
            _DescrStatus = txtBxDescricao.Text;
            _TipoModificacao = StatusProcess.CreateInstance.FromToModificaStatus(ModificaStatusType.StatusAlterar);

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }  
                _IdExecute = StatusProcess.CreateInstance.TaskModifyProcessStatus(_IdRgStatus, _DescrStatus, _TipoModificacao);
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

                if (_LogIdStatus != null) { _LogIdStatus.ValorNovo = _IdRgStatus; }
                if (_LogDescrStatus != null) { _LogDescrStatus.ValorNovo = _DescrStatus; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogIdStatus);
                _ChangeItems.Add(_LogDescrStatus);

                #endregion

                ExecuteModifyExceptionLogStatus(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogIdStatus != null) { _LogIdStatus.ValorNovo = _IdRgStatus; }
                    if (_LogDescrStatus != null) { _LogDescrStatus.ValorNovo = _DescrStatus; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogIdStatus);
                    _ChangeItems.Add(_LogDescrStatus);

                    #endregion

                    ExecuteModifyLogStatus(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void ExecuteModifyLogStatus(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }
        private void ExecuteModifyExceptionLogStatus(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void FillLogHeaderFromUpdateModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgStatus.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdRgStatus;
            _ChangesHeader.TipoModificacao = StatusProcess.CreateInstance.FromToModificaStatus(ModificaStatusType.StatusAlterar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Status
            _LogIdStatus = new ChangeItem();
            _LogIdStatus.IdChangeHeader = _ChangesHeader.Id;
            _LogIdStatus.IdItem = 1;
            _LogIdStatus.NomeTabela = DboRgStatus.NomeTabela;
            _LogIdStatus.NomeCampo = DboRgStatus.NomeIdStatus;
            _LogIdStatus.ValorAntigo = IdRgStatus;

            //Descrição Status
            _LogDescrStatus = new ChangeItem();
            _LogDescrStatus.IdChangeHeader = _ChangesHeader.Id;
            _LogDescrStatus.IdItem = 2;
            _LogDescrStatus.NomeTabela = DboRgStatus.NomeTabela;
            _LogDescrStatus.NomeCampo = DboRgStatus.NomeDescrStatus;
            _LogDescrStatus.ValorAntigo = DescrStatus;

            #endregion
        }

        private void FillLogHeaderFromAddModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgStatus.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdRgStatus;
            _ChangesHeader.TipoModificacao = StatusProcess.CreateInstance.FromToModificaStatus(ModificaStatusType.StatusAdicionar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Status
            _LogIdStatus = new ChangeItem();
            _LogIdStatus.IdChangeHeader = _ChangesHeader.Id;
            _LogIdStatus.IdItem = 1;
            _LogIdStatus.NomeTabela = DboRgStatus.NomeTabela;
            _LogIdStatus.NomeCampo = DboRgStatus.NomeIdStatus;
            //_LogIdStatus.ValorAntigo = IdRgStatus;

            //Descrição Status
            _LogDescrStatus = new ChangeItem();
            _LogDescrStatus.IdChangeHeader = _ChangesHeader.Id;
            _LogDescrStatus.IdItem = 2;
            _LogDescrStatus.NomeTabela = DboRgStatus.NomeTabela;
            _LogDescrStatus.NomeCampo = DboRgStatus.NomeDescrStatus;
            //_LogDescrStatus.ValorAntigo = DescrStatus;

            #endregion
        }

        private void ExecuteAddStatus()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteAddStatus";

            txtBxCodStatus.Text = "0";
            int _IdRgStatus = 0;
            string _DescrStatus = string.Empty;
            string _TipoModificacao = string.Empty;

            _IdRgStatus = Convert.ToInt32(txtBxCodStatus.Text);
            _DescrStatus = txtBxDescricao.Text;
            _TipoModificacao = StatusProcess.CreateInstance.FromToModificaStatus(ModificaStatusType.StatusAdicionar);

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }  
                _IdExecute = StatusProcess.CreateInstance.TaskModifyProcessStatus(_IdRgStatus, _DescrStatus, _TipoModificacao);
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

                if (_LogIdStatus != null) { _LogIdStatus.ValorNovo = _IdRgStatus; }
                if (_LogDescrStatus != null) { _LogDescrStatus.ValorNovo = _DescrStatus; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogIdStatus);
                _ChangeItems.Add(_LogDescrStatus);

                #endregion

                ExecuteModifyExceptionLogStatus(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogIdStatus != null) { _LogIdStatus.ValorNovo = _IdRgStatus; }
                    if (_LogDescrStatus != null) { _LogDescrStatus.ValorNovo = _DescrStatus; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogIdStatus);
                    _ChangeItems.Add(_LogDescrStatus);

                    #endregion

                    ExecuteModifyLogStatus(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void UpdateFormStatus_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;

            if (ModificaStatusType == ModificaStatusType.StatusAdicionar)
	        {
                FillLogHeaderFromAddModify();
	        }
            if (ModificaStatusType == ModificaStatusType.StatusAlterar)
            {
                FillLogHeaderFromAddModify();
                FillDataParametersToExecuteUpdateModify();
            }
        }

        private void FillDataParametersToExecuteUpdateModify()
        {
            txtBxCodStatus.Text = IdRgStatus.ToString();
            txtBxDescricao.Text = DescrStatus;
        }

        // ...::: INICIO VALIDAÇÕES :::...
        private void txtBxDescricao_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrStatusRg.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrStatusRg.SetError(txtBxDescricao, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }
    }
    internal static class DboRgStatus
    {
        #region ...::: Private Constantes :::...

        private const string _NomeIdStatus = "cod_status";
        private const string _NomeDescrStatus = "descr_status";
        private const string _NomeTabela = "rg_status";
        private const string _NomeProcesso = "Status";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeIdStatus { get { return _NomeIdStatus; } }
        public static string NomeDescrStatus { get { return _NomeDescrStatus; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
