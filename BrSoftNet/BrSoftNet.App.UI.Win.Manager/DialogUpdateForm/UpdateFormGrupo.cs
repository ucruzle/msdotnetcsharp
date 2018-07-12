using BrSoftNet.App.Business.Processes.Manager.Enumerators;
using BrSoftNet.App.Business.Processes.Manager.Tasks;
using System;
using System.Drawing;
using System.Windows.Forms;
using BrSoftNet.Library.Messages;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Log.Actions;
using BrSoftNet.Log.Helpers;
using BrSoftNet.Log.Structures;
using System.Collections.Generic;

namespace BrSoftNet.App.UI.Win.Manager.DialogUpdateForm
{
    public partial class UpdateFormGrupo : Form
    {
        #region ...::: Private Variable :::...

        private string _TipoModificacao = string.Empty;

        private int _IdExecute = 0;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpr { get; set; }
        public int IdRg { get; set; }
        public string UsuarioLogin { get; set; }
        public ModificaGrupoType ModificaGrupoType { get; set; }
        public int CodigoGrupo { get; set; }
        public string DescricaoGrupo { get; set; }
        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;

        private ChangeItem _LogCodigoGrupo = null;
        private ChangeItem _LogDescricaoGrupo = null;

        private List<ChangeItem> _ChangeItems = null;
        private ThrowingException _ThrowingException = null;

        private string _IdExcepitionLog = string.Empty;
        private string _MenssageLogError = string.Empty;

        #endregion

        public UpdateFormGrupo()
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
            ExecuteModifyGrupo();

            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrGrupo.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
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

        private void ExecuteModifyGrupo()
        {
            switch (ModificaGrupoType)
            {
                case ModificaGrupoType.GrupoAdicionar:
                    ExecuteAddGrupo();
                    break;
                case ModificaGrupoType.GrupoAlterar:
                    ExecuteUpdateGrupo();
                    break;
            }
        }

        private void ExecuteUpdateGrupo()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteUpdateGrupo";

            int _CodigoGrupo = 0;
            string _DescricaoGrupo = string.Empty;
            string _TipoModificacao = string.Empty;

            _CodigoGrupo = Convert.ToInt32(txtBxCodigoGrupo.Text);
            _DescricaoGrupo = txtBxDescricao.Text;
            _TipoModificacao = GrupoProcess.CreateInstance.FromToModificaGrupo(ModificaGrupoType.GrupoAlterar);

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }
                _IdExecute = GrupoProcess.CreateInstance.TaskModifyProcessGrupo(_CodigoGrupo, _DescricaoGrupo, _TipoModificacao);
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

                if (_LogCodigoGrupo != null) { _LogCodigoGrupo.ValorNovo = _CodigoGrupo; }
                if (_LogDescricaoGrupo != null) { _LogDescricaoGrupo.ValorNovo = _DescricaoGrupo; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogCodigoGrupo);
                _ChangeItems.Add(_LogDescricaoGrupo);

                #endregion

                ExecuteModifyExceptionLogGrupo(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                        if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                        #endregion

                        #region ...::: Atualiza os Itens do Log de Modificações :::...

                        if (_LogCodigoGrupo != null) { _LogCodigoGrupo.ValorNovo = _CodigoGrupo; }
                        if (_LogDescricaoGrupo != null) { _LogDescricaoGrupo.ValorNovo = _DescricaoGrupo; }

                        _ChangeItems = new List<ChangeItem>();
                        _ChangeItems.Add(_LogCodigoGrupo);
                        _ChangeItems.Add(_LogDescricaoGrupo);

                        #endregion

                        ExecuteModifyLogGrupo(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void ExecuteAddGrupo()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteAddGrupo";

            txtBxCodigoGrupo.Text = "0";
            int _CodigoGrupo = 0;
            string _DescricaoGrupo = string.Empty;
            string _TipoModificacao = string.Empty;

            _CodigoGrupo = Convert.ToInt32(txtBxCodigoGrupo.Text);
            _DescricaoGrupo = txtBxDescricao.Text;
            _TipoModificacao = GrupoProcess.CreateInstance.FromToModificaGrupo(ModificaGrupoType.GrupoAdicionar);

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }
                _IdExecute = GrupoProcess.CreateInstance.TaskModifyProcessGrupo(_CodigoGrupo, _DescricaoGrupo, _TipoModificacao);
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

                if (_LogCodigoGrupo != null) { _LogCodigoGrupo.ValorNovo = _CodigoGrupo; }
                if (_LogDescricaoGrupo != null) { _LogDescricaoGrupo.ValorNovo = _DescricaoGrupo; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogCodigoGrupo);
                _ChangeItems.Add(_LogDescricaoGrupo);

                #endregion

                ExecuteModifyExceptionLogGrupo(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogCodigoGrupo != null) { _LogCodigoGrupo.ValorNovo = _CodigoGrupo; }
                    if (_LogDescricaoGrupo != null) { _LogDescricaoGrupo.ValorNovo = _DescricaoGrupo; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogCodigoGrupo);
                    _ChangeItems.Add(_LogDescricaoGrupo);

                    #endregion

                    ExecuteModifyLogGrupo(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void ExecuteModifyLogGrupo(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }

        private void ExecuteModifyExceptionLogGrupo(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void FillLogHeaderFromAddModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboGeGrupo.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.CodigoGrupo;
            _ChangesHeader.TipoModificacao = GrupoProcess.CreateInstance.FromToModificaGrupo(ModificaGrupoType.GrupoAdicionar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Grupo
            _LogCodigoGrupo = new ChangeItem();
            _LogCodigoGrupo.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoGrupo.IdItem = 1;
            _LogCodigoGrupo.NomeTabela = DboGeGrupo.NomeTabela;
            _LogCodigoGrupo.NomeCampo = DboGeGrupo.NomeCodigoGrupo;
            //_LogCodigoGrupo.ValorAntigo = CodigoGrupo;

            //Descrição Grupo
            _LogDescricaoGrupo = new ChangeItem();
            _LogDescricaoGrupo.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricaoGrupo.IdItem = 2;
            _LogDescricaoGrupo.NomeTabela = DboGeGrupo.NomeTabela;
            _LogDescricaoGrupo.NomeCampo = DboGeGrupo.NomeDescricaoGrupo;
            //_LogDescricaoGrupo.ValorAntigo = DescricaoGrupo;

            #endregion
        }

        private void FillLogHeaderFromUpdateModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboGeGrupo.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.CodigoGrupo;
            _ChangesHeader.TipoModificacao = GrupoProcess.CreateInstance.FromToModificaGrupo(ModificaGrupoType.GrupoAlterar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Grupo
            _LogCodigoGrupo = new ChangeItem();
            _LogCodigoGrupo.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoGrupo.IdItem = 1;
            _LogCodigoGrupo.NomeTabela = DboGeGrupo.NomeTabela;
            _LogCodigoGrupo.NomeCampo = DboGeGrupo.NomeCodigoGrupo;
            _LogCodigoGrupo.ValorAntigo = CodigoGrupo;

            //Descrição Grupo
            _LogDescricaoGrupo = new ChangeItem();
            _LogDescricaoGrupo.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricaoGrupo.IdItem = 2;
            _LogDescricaoGrupo.NomeTabela = DboGeGrupo.NomeTabela;
            _LogDescricaoGrupo.NomeCampo = DboGeGrupo.NomeDescricaoGrupo;
            _LogDescricaoGrupo.ValorAntigo = DescricaoGrupo;

            #endregion
        }

        private void UpdateFormGrupo_Load(object sender, System.EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;

            if (ModificaGrupoType == ModificaGrupoType.GrupoAlterar)
            {
                FillLogHeaderFromUpdateModify();
                FillDataParametersToExecuteUpdateModify();
            }

            if (ModificaGrupoType == ModificaGrupoType.GrupoAdicionar)
            {
                FillLogHeaderFromAddModify();
            }
        }

        private void FillDataParametersToExecuteUpdateModify()
        {
            txtBxCodigoGrupo.Text = CodigoGrupo.ToString();
            txtBxDescricao.Text = DescricaoGrupo;
        }

        // ...::: INICIO VALIDAÇÕES :::...
        private void txtBxDescricao_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrGrupo.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrGrupo.SetError(txtBxDescricao, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrGrupo.SetError(txtBxDescricao, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }
    }
    internal static class DboGeGrupo
    {
        #region ...::: Private Constantes :::...

        private const string _NomeCodigoGrupo = "cod_grupo";
        private const string _NomeDescricaoGrupo = "descr_grupo";
        private const string _NomeTabela = "ge_grupo";
        private const string _NomeProcesso = "Grupo";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeCodigoGrupo { get { return _NomeCodigoGrupo; } }
        public static string NomeDescricaoGrupo { get { return _NomeDescricaoGrupo; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
