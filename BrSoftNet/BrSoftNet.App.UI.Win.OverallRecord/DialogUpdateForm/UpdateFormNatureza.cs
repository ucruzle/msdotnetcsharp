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
    public partial class UpdateFormNatureza : Form
    {
        #region ...::: Private Variable :::...

        private string _TipoModificacao = string.Empty;

        private int _IdExecute = 0;

        private int _IdNatureza = 0;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpr { get; set; }
        public int IdRg { get; set; }
        public string UsuarioLogin { get; set; }
        public ModificaNaturezaType ModificaNaturezaType { get; set; }
        public int IdNatureza { get; set; }
        public string DescrNatureza { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;
        private ChangeItem _LogIdNatureza = null;
        private ChangeItem _LogDescricao = null;
        private List<ChangeItem> _ChangeItems = null;
        private ThrowingException _ThrowingException = null;

        private string _IdExcepitionLog = string.Empty;
        private string _MenssageLogError = string.Empty;

        #endregion

        public UpdateFormNatureza()
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
            ExecuteModifyNatureza();

            if(txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrNatureza.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
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
        private void ExecuteModifyNatureza()
        {
            switch (ModificaNaturezaType)
            {
                case ModificaNaturezaType.NaturezaAdicionar:
                    ExecuteAddNatureza();
                    break;
                case ModificaNaturezaType.NaturezaAlterar:
                    ExecuteUpdateNatureza();
                    break;
            }
        }

        private void ExecuteUpdateNatureza()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteUpdateNatureza";

            int _IdNatureza = 0;
            string _DescrNatureza = string.Empty;
            string _TipoModificacao = string.Empty;

            _IdNatureza = Convert.ToInt32(txtBxCodNatureza.Text);
            _DescrNatureza = txtBxDescricao.Text;
            _TipoModificacao = NaturezaProcess.CreateInstance.FromToModificaNatureza(ModificaNaturezaType.NaturezaAlterar);

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }   
                _IdExecute = NaturezaProcess.CreateInstance.TaskModifyProcessNatureza(_IdNatureza, _DescrNatureza, _TipoModificacao);
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

                if (_LogIdNatureza != null) { _LogIdNatureza.ValorNovo = _IdNatureza; }
                if (_LogDescricao != null) { _LogDescricao.ValorNovo = _DescrNatureza; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogIdNatureza);
                _ChangeItems.Add(_LogDescricao);

                #endregion

                ExecuteModifyExceptionLogNatureza(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogIdNatureza != null) { _LogIdNatureza.ValorNovo = _IdNatureza; }
                    if (_LogDescricao != null) { _LogDescricao.ValorNovo = _DescrNatureza; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogIdNatureza);
                    _ChangeItems.Add(_LogDescricao);

                    #endregion

                    ExecuteModifyLogNatureza(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void ExecuteAddNatureza()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteAddNatureza";

            txtBxCodNatureza.Text = "0";
            int _IdNatureza = 0;
            string _DescrNatureza = string.Empty;
            string _TipoModificacao = string.Empty;

            _IdNatureza = Convert.ToInt32(txtBxCodNatureza.Text);
            _DescrNatureza = txtBxDescricao.Text;
            _TipoModificacao = NaturezaProcess.CreateInstance.FromToModificaNatureza(ModificaNaturezaType.NaturezaAdicionar);

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }   
                _IdExecute = NaturezaProcess.CreateInstance.TaskModifyProcessNatureza(_IdNatureza, _DescrNatureza, _TipoModificacao);
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

                if (_LogIdNatureza != null) { _LogIdNatureza.ValorNovo = _IdNatureza; }
                if (_LogDescricao != null) { _LogDescricao.ValorNovo = _DescrNatureza; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogIdNatureza);
                _ChangeItems.Add(_LogDescricao);

                #endregion

                ExecuteModifyExceptionLogNatureza(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogIdNatureza != null) { _LogIdNatureza.ValorNovo = _IdNatureza; }
                    if (_LogDescricao != null) { _LogDescricao.ValorNovo = _DescrNatureza; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogIdNatureza);
                    _ChangeItems.Add(_LogDescricao);

                    #endregion

                    ExecuteModifyLogNatureza(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void ExecuteModifyExceptionLogNatureza(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void ExecuteModifyLogNatureza(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }

        private void FillLogHeaderFromAddModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgNatureza.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdNatureza;
            _ChangesHeader.TipoModificacao = NaturezaProcess.CreateInstance.FromToModificaNatureza(ModificaNaturezaType.NaturezaAdicionar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Código Natureza
            _LogIdNatureza = new ChangeItem();
            _LogIdNatureza.IdChangeHeader = _ChangesHeader.Id;
            _LogIdNatureza.IdItem = 1;
            _LogIdNatureza.NomeTabela = DboRgNatureza.NomeTabela;
            _LogIdNatureza.NomeCampo = DboRgNatureza.NomeIdNatureza;

            //Descrição Natureza    
            _LogDescricao = new ChangeItem();
            _LogDescricao.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricao.IdItem = 2;
            _LogDescricao.NomeTabela = DboRgNatureza.NomeTabela;
            _LogDescricao.NomeCampo = DboRgNatureza.NomeDescrNatureza;

            #endregion
        }

        private void FillLogHeaderFromUpdateModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgNatureza.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdNatureza;
            _ChangesHeader.TipoModificacao = NaturezaProcess.CreateInstance.FromToModificaNatureza(ModificaNaturezaType.NaturezaAlterar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Código Natureza
            _LogIdNatureza = new ChangeItem();
            _LogIdNatureza.IdChangeHeader = _ChangesHeader.Id;
            _LogIdNatureza.IdItem = 1;
            _LogIdNatureza.NomeTabela = DboRgNatureza.NomeTabela;
            _LogIdNatureza.NomeCampo = DboRgNatureza.NomeIdNatureza;
            _LogIdNatureza.ValorAntigo = this.IdNatureza;

            //Descrição Natureza    
            _LogDescricao = new ChangeItem();
            _LogDescricao.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricao.IdItem = 2;
            _LogDescricao.NomeTabela = DboRgNatureza.NomeTabela;
            _LogDescricao.NomeCampo = DboRgNatureza.NomeDescrNatureza;
            _LogDescricao.ValorAntigo = this.DescrNatureza;

            #endregion
        }

        private void UpdateFormNatureza_Load(object sender, EventArgs e)
        {
            this.lblActionModuleTitle.Text = TextoDoTilutoDoFormulario;

            if (ModificaNaturezaType == ModificaNaturezaType.NaturezaAdicionar)
            {
                FillLogHeaderFromAddModify();
            }
            if (ModificaNaturezaType == ModificaNaturezaType.NaturezaAlterar)
            {
                FillLogHeaderFromUpdateModify();
                FillDataParametersToExecuteUpdateModify();
            }
        }

        private void FillDataParametersToExecuteUpdateModify()
        {
            txtBxCodNatureza.Text = IdNatureza.ToString();
            txtBxDescricao.Text = DescrNatureza;
        }

        // ...::: INICIO VALIDAÇÕES :::...
        private void txtBxDescricao_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrNatureza.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrNatureza.SetError(txtBxDescricao, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrNatureza.SetError(txtBxDescricao, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }
    }

    internal static class DboRgNatureza
    {
        #region ...::: Private Constantes :::...

        private const string _NomeIdNatureza = "cod_natureza";
        private const string _NomeDescrNatureza = "descr_natureza";
        private const string _NomeTabela = "rg_natureza";
        private const string _NomeProcesso = "Natureza";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeIdNatureza { get { return _NomeIdNatureza; } }
        public static string NomeDescrNatureza { get { return _NomeDescrNatureza; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
