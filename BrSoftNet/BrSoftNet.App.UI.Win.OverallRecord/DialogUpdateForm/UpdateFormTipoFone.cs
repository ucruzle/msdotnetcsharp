using BrSoftNet.App.Business.Processes.OverallRecord.Enumerators;
using BrSoftNet.App.Business.Processes.OverallRecord.Tasks;
using System;
using System.Drawing;
using System.Windows.Forms;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Library.Messages;
using BrSoftNet.Log.Structures;
using System.Collections.Generic;
using BrSoftNet.Log.Actions;
using BrSoftNet.Log.Helpers;

namespace BrSoftNet.App.UI.Win.OverallRecord.DialogUpdateForm
{
    public partial class UpdateFormTipoFone : Form
    {
        #region ...::: Private Variable :::...

        private string _TipoModificacao = string.Empty;

        private int _IdExecute = 0;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpr { get; set; }
        public int IdRg { get; set; }
        public string UsuarioLogin { get; set; }
        public ModificaTipoFoneType ModificaTipoFoneType { get; set; }
        public int IdTipoFone { get; set; }
        public string DescrTipoFone { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;

        private ChangeItem _LogIdTipoFone = null;
        private ChangeItem _LogDescrTipoFone = null;

        private List<ChangeItem> _ChangeItems = null;

        private ThrowingException _ThrowingException = null;

        private string _IdExcepitionLog = string.Empty;
        private string _MenssageLogError = string.Empty;

        #endregion

        public UpdateFormTipoFone()
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
            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrTipoFone.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxDescricao.Focus();
                return;
            }
            ExecuteModifyTipoFone();
            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void ExecuteModifyTipoFone()
        {
            switch (ModificaTipoFoneType)
            {
                case ModificaTipoFoneType.TipoFoneAdicionar:
                    ExecuteAddTipoFone();
                    break;
                case ModificaTipoFoneType.TipoFoneAlterar:
                    ExecuteUpdateTipoFone();
                    break;
            }
        }

        private void ExecuteUpdateTipoFone()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteUpdateTipoFone";

            int _IdTipoFone = 0;
            string _DescrTipoFone = string.Empty;
            string _TipoModificacao = string.Empty;

            _IdTipoFone = Convert.ToInt32(txtBxCodTipoFone.Text);
            _DescrTipoFone = txtBxDescricao.Text;
            _TipoModificacao = TipoFoneProcess.CreateInstance.FromToModificaTipoFone(ModificaTipoFoneType.TipoFoneAlterar);

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }  
                _IdExecute = TipoFoneProcess.CreateInstance.TaskModifyProcessTipoFone(_IdTipoFone, _DescrTipoFone, _TipoModificacao);
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

                if (_LogIdTipoFone != null) { _LogIdTipoFone.ValorNovo = _IdTipoFone; }
                if (_LogDescrTipoFone != null) { _LogDescrTipoFone.ValorNovo = _DescrTipoFone; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogIdTipoFone);
                _ChangeItems.Add(_LogDescrTipoFone);

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

                    if (_LogIdTipoFone != null) { _LogIdTipoFone.ValorNovo = _IdTipoFone; }
                    if (_LogDescrTipoFone != null) { _LogDescrTipoFone.ValorNovo = _DescrTipoFone; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogIdTipoFone);
                    _ChangeItems.Add(_LogDescrTipoFone);

                    #endregion

                    ExecuteModifyLogStatus(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void ExecuteAddTipoFone()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteAddTipoFone";

            txtBxCodTipoFone.Text = "0";
            int _IdTipoFone = 0;
            string _DescrTipoFone = string.Empty;
            string _TipoModificacao = string.Empty;

            _IdTipoFone = Convert.ToInt32(txtBxCodTipoFone.Text);
            _DescrTipoFone = txtBxDescricao.Text;
            _TipoModificacao = TipoFoneProcess.CreateInstance.FromToModificaTipoFone(ModificaTipoFoneType.TipoFoneAdicionar);

            try
            {
                _IdExecute = TipoFoneProcess.CreateInstance.TaskModifyProcessTipoFone(_IdTipoFone, _DescrTipoFone, _TipoModificacao);
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

                if (_LogIdTipoFone != null) { _LogIdTipoFone.ValorNovo = _IdTipoFone; }
                if (_LogDescrTipoFone != null) { _LogDescrTipoFone.ValorNovo = _DescrTipoFone; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogIdTipoFone);
                _ChangeItems.Add(_LogDescrTipoFone);

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

                    if (_LogIdTipoFone != null) { _LogIdTipoFone.ValorNovo = _IdTipoFone; }
                    if (_LogDescrTipoFone != null) { _LogDescrTipoFone.ValorNovo = _DescrTipoFone; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogIdTipoFone);
                    _ChangeItems.Add(_LogDescrTipoFone);

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
            _ChangesHeader.NomeProcesso = DboRgTipoFone.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdTipoFone;
            _ChangesHeader.TipoModificacao = TipoFoneProcess.CreateInstance.FromToModificaTipoFone(ModificaTipoFoneType.TipoFoneAlterar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Tipo Fone
            _LogIdTipoFone = new ChangeItem();
            _LogIdTipoFone.IdChangeHeader = _ChangesHeader.Id;
            _LogIdTipoFone.IdItem = 1;
            _LogIdTipoFone.NomeTabela = DboRgTipoFone.NomeTabela;
            _LogIdTipoFone.NomeCampo = DboRgTipoFone.NomeIdTipoFone;
            _LogIdTipoFone.ValorAntigo = IdTipoFone;

            //Descrição Tipo Fone
            _LogDescrTipoFone = new ChangeItem();
            _LogDescrTipoFone.IdChangeHeader = _ChangesHeader.Id;
            _LogDescrTipoFone.IdItem = 2;
            _LogDescrTipoFone.NomeTabela = DboRgTipoFone.NomeTabela;
            _LogDescrTipoFone.NomeCampo = DboRgTipoFone.NomeDescrTipoFone;
            _LogDescrTipoFone.ValorAntigo = DescrTipoFone;

            #endregion
        }

        private void FillLogHeaderFromAddModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgTipoFone.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdTipoFone;
            _ChangesHeader.TipoModificacao = TipoFoneProcess.CreateInstance.FromToModificaTipoFone(ModificaTipoFoneType.TipoFoneAdicionar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Tipo Fone
            _LogIdTipoFone = new ChangeItem();
            _LogIdTipoFone.IdChangeHeader = _ChangesHeader.Id;
            _LogIdTipoFone.IdItem = 1;
            _LogIdTipoFone.NomeTabela = DboRgTipoFone.NomeTabela;
            _LogIdTipoFone.NomeCampo = DboRgTipoFone.NomeIdTipoFone;
            //_LogIdTipoFone.ValorAntigo = IdTipoFone;

            //Descrição Tipo Fone
            _LogDescrTipoFone = new ChangeItem();
            _LogDescrTipoFone.IdChangeHeader = _ChangesHeader.Id;
            _LogDescrTipoFone.IdItem = 2;
            _LogDescrTipoFone.NomeTabela = DboRgTipoFone.NomeTabela;
            _LogDescrTipoFone.NomeCampo = DboRgTipoFone.NomeDescrTipoFone;
            //_LogDescrTipoFone.ValorAntigo = DescrTipoFone;

            #endregion
        }

        private void UpdateFormTipoFone_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;

            if (ModificaTipoFoneType == ModificaTipoFoneType.TipoFoneAdicionar)
            {
                FillLogHeaderFromAddModify();
            }
            if (ModificaTipoFoneType == ModificaTipoFoneType.TipoFoneAlterar)
            {
                FillLogHeaderFromUpdateModify();
                FillDataParametersToExecuteUpdateModify();
            }
        }

        private void FillDataParametersToExecuteUpdateModify()
        {
            txtBxCodTipoFone.Text = IdTipoFone.ToString();
            txtBxDescricao.Text = DescrTipoFone;
        }

        // ...::: INICIO VALIDAÇÕES :::...
        private void txtBxDescricao_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void txtBxDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrTipoFone.SetError(txtBxDescricao, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }
    }

    internal static class DboRgTipoFone
    {
        #region ...::: Private Constantes :::...

        private const string _NomeIdTipoFone = "cod_tipo_fone";
        private const string _NomeDescrTipoFone = "descr_tipo_fone";
        private const string _NomeTabela = "rg_tipo_fone";
        private const string _NomeProcesso = "Tipo Fone";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeIdTipoFone { get { return _NomeIdTipoFone; } }
        public static string NomeDescrTipoFone { get { return _NomeDescrTipoFone; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
