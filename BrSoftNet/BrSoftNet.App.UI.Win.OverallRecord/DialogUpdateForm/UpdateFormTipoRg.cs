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
    public partial class UpdateFormTipoRg : Form
    {
        #region ...::: Private Variable :::...

        private string _TipoModificacao = string.Empty;

        private int _IdExecute = 0;

        private string _IdExcepitionLog = string.Empty;
        private string _MenssageLogError = string.Empty;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpr { get; set; }
        public int IdTipoRg { get; set; }
        public string UsuarioLogin { get; set; }
        public ModificaTipoRgType ModificaTipoRgType { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;

        private ChangeItem _LogIdTipoRg = null;
        private ChangeItem _LogDescrTipoRg = null;

        private List<ChangeItem> _ChangeItems = null;

        private ThrowingException _ThrowingException = null;

        #endregion
        public UpdateFormTipoRg()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();

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

        private void InicialiazeUpdateForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {
            this.ExecuteModifyTipoRg();

            if (txtBxTipo.Text == string.Empty)
            {
                ErrPrvdrTipoRg.SetError(txtBxTipo, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxTipo.Focus();
                return;
            }

            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrTipoRg.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
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

        private void ExecuteModifyTipoRg()
        {
            switch (ModificaTipoRgType)
            {
                case ModificaTipoRgType.TipoRgAdicionar:
                    ExecuteAddTipoRg();
                    break;
                case ModificaTipoRgType.TipoRgAlterar:
                    ExecuteUpdateTipoRg();
                    break;
            }
        }

        private void ExecuteUpdateTipoRg()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteUpdateTipoRg";

            string _TipoRg = string.Empty;
            string _DescrTipo = string.Empty;
            string _TipoModificacao = string.Empty;

            _TipoRg = txtBxTipo.Text;
            _DescrTipo = txtBxDescricao.Text;
            _TipoModificacao = TipoRgProcess.CreateInstance.FromToModificaTipoRg(ModificaTipoRgType.TipoRgAlterar);

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }   
                _IdExecute = TipoRgProcess.CreateInstance.TaskModifyProcessTipoRg(_TipoRg, _DescrTipo, _TipoModificacao);
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

                if (_LogIdTipoRg != null) { _LogIdTipoRg.ValorNovo = _TipoRg; }
                if (_LogDescrTipoRg != null) { _LogDescrTipoRg.ValorNovo = _DescrTipo; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogIdTipoRg);
                _ChangeItems.Add(_LogDescrTipoRg);

                #endregion

                ExecuteModifyExceptionLogTipoRg(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogIdTipoRg != null) { _LogIdTipoRg.ValorNovo = _TipoRg; }
                    if (_LogDescrTipoRg != null) { _LogDescrTipoRg.ValorNovo = _DescrTipo; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogIdTipoRg);
                    _ChangeItems.Add(_LogDescrTipoRg);

                    #endregion

                    ExecuteModifyLogTipoRg(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void ExecuteAddTipoRg()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteAddTipoRg";

            string _TipoRg = string.Empty;
            string _DescrTipo = string.Empty;
            string _TipoModificacao = string.Empty;

            _TipoRg = txtBxTipo.Text;
            _DescrTipo = txtBxDescricao.Text;
            _TipoModificacao = TipoRgProcess.CreateInstance.FromToModificaTipoRg(ModificaTipoRgType.TipoRgAdicionar);

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }   
                _IdExecute = TipoRgProcess.CreateInstance.TaskModifyProcessTipoRg(_TipoRg, _DescrTipo, _TipoModificacao);
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

                if (_LogIdTipoRg != null) { _LogIdTipoRg.ValorNovo = _TipoRg; }
                if (_LogDescrTipoRg != null) { _LogDescrTipoRg.ValorNovo = _DescrTipo; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogIdTipoRg);
                _ChangeItems.Add(_LogDescrTipoRg);

                #endregion

                ExecuteModifyExceptionLogTipoRg(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogIdTipoRg != null) { _LogIdTipoRg.ValorNovo = _TipoRg; }
                    if (_LogDescrTipoRg != null) { _LogDescrTipoRg.ValorNovo = _DescrTipo; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogIdTipoRg);
                    _ChangeItems.Add(_LogDescrTipoRg);

                    #endregion

                    ExecuteModifyLogTipoRg(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }

        }

        private void ExecuteModifyLogTipoRg(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }

        private void ExecuteModifyExceptionLogTipoRg(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void FillLogHeaderFromUpdateModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgTipoRg.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdTipoRg;
            _ChangesHeader.TipoModificacao = TipoRgProcess.CreateInstance.FromToModificaTipoRg(ModificaTipoRgType.TipoRgAlterar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Tipo Rg
            _LogIdTipoRg = new ChangeItem();
            _LogIdTipoRg.IdChangeHeader = _ChangesHeader.Id;
            _LogIdTipoRg.IdItem = 1;
            _LogIdTipoRg.NomeTabela = DboRgTipoRg.NomeTabela;
            _LogIdTipoRg.NomeCampo = DboRgTipoRg.NomeTipoRg;
            _LogIdTipoRg.ValorAntigo = this.IdTipoRg;

            //Descrição Tipo Rg
            _LogDescrTipoRg = new ChangeItem();
            _LogDescrTipoRg.IdChangeHeader = _ChangesHeader.Id;
            _LogDescrTipoRg.IdItem = 2;
            _LogDescrTipoRg.NomeTabela = DboRgTipoRg.NomeTabela;
            _LogDescrTipoRg.NomeCampo = DboRgTipoRg.NomeDescrTipoRg;
            _LogDescrTipoRg.ValorAntigo = this.Descricao;

            #endregion
        }

        private void FillLogHeaderFromAddModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgTipoRg.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdTipoRg;
            _ChangesHeader.TipoModificacao = TipoRgProcess.CreateInstance.FromToModificaTipoRg(ModificaTipoRgType.TipoRgAdicionar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Tipo Rg
            _LogIdTipoRg = new ChangeItem();
            _LogIdTipoRg.IdChangeHeader = _ChangesHeader.Id;
            _LogIdTipoRg.IdItem = 1;
            _LogIdTipoRg.NomeTabela = DboRgTipoRg.NomeTabela;
            _LogIdTipoRg.NomeCampo = DboRgTipoRg.NomeTipoRg;
            //_LogIdTipoRg.ValorAntigo = this.IdTipoRg;

            //Descrição Tipo Rg
            _LogDescrTipoRg = new ChangeItem();
            _LogDescrTipoRg.IdChangeHeader = _ChangesHeader.Id;
            _LogDescrTipoRg.IdItem = 2;
            _LogDescrTipoRg.NomeTabela = DboRgTipoRg.NomeTabela;
            _LogDescrTipoRg.NomeCampo = DboRgTipoRg.NomeDescrTipoRg;
            //_LogDescrTipoRg.ValorAntigo = this.Descricao;

            #endregion
        }

        private void UpdateFormTipoRg_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;

            if (ModificaTipoRgType == ModificaTipoRgType.TipoRgAlterar)
            {
                FillLogHeaderFromUpdateModify();
                FillDataParametersToExecuteUpdateModify();
            }

            if (ModificaTipoRgType == ModificaTipoRgType.TipoRgAdicionar)
            {
                FillLogHeaderFromAddModify();
                FillDataParametersToExecuteAddModify();
            }
        }

        private void FillDataParametersToExecuteUpdateModify()
        {
            txtBxTipo.Text = Sigla;
            txtBxDescricao.Text = Descricao;
            txtBxTipo.ReadOnly = true;
        }

        private void FillDataParametersToExecuteAddModify()
        {
            if (txtBxTipo.ReadOnly)
            {
                txtBxTipo.ReadOnly = false;
            }
        }

        // ...::: INICIO VALIDAÇÕES :::...
        private void txtBxTipo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void txtBxDescricao_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void txtBxTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrTipoRg.SetError(txtBxTipo, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrTipoRg.SetError(txtBxDescricao, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

    }
    internal static class DboRgTipoRg
    {
        #region ...::: Private Constantes :::...

        private const string _NomeTipoRg = "tipo_rg";
        private const string _NomeDescrTipoRg = "descr_tipo_rg";
        private const string _NomeTabela = "rg_tipo_rg";
        private const string _NomeProcesso = "Tipo Rg";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeTipoRg { get { return _NomeTipoRg; } }
        public static string NomeDescrTipoRg { get { return _NomeDescrTipoRg; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
