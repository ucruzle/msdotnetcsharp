using BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects;
using BrSoftNet.App.Business.Processes.OverallRecord.Enumerators;
using BrSoftNet.App.Business.Processes.OverallRecord.Tasks;
using BrSoftNet.App.UI.Win.OverallRecord.State;
using System;
using System.Drawing;
using System.Windows.Forms;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Library.Messages;
using BrSoftNet.Log.Structures;
using System.Collections.Generic;
using BrSoftNet.Log.Helpers;
using BrSoftNet.Log.Actions;

namespace BrSoftNet.App.UI.Win.OverallRecord.DialogUpdateForm
{
    public partial class UpdateFormRegiao : Form
    {
        #region ...::: Private Variable :::...

        private string _TipoModificacao = string.Empty;

        private int _IdExecute = 0;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpr { get; set; }
        public int IdRg { get; set; }
        public string UsuarioLogin { get; set; }
        public ModificaRegiaoType ModificaRegiaoType { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }
        
        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;
        private ChangeItem _LogSiglaRegiao = null;
        private ChangeItem _LogDescricaoRegiao = null;
        private List<ChangeItem> _ChangeItems = null;
        private ThrowingException _ThrowingException = null;

        private string _IdExcepitionLog = string.Empty;
        private string _MenssageLogError = string.Empty;

        #endregion

        public UpdateFormRegiao()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();

            this.txtBxSigla.GotFocus += txtBxSigla_GotFocus;
            this.txtBxSigla.LostFocus += txtBxSigla_LostFocus;

            this.txtBxDescricao.GotFocus += txtBxDescricao_GotFocus;
            this.txtBxDescricao.LostFocus += txtBxDescricao_LostFocus;
        }

        void txtBxSigla_LostFocus(object sender, EventArgs e)
        {
            this.txtBxSigla.BackColor = Color.White;
        }

        void txtBxSigla_GotFocus(object sender, EventArgs e)
        {
            this.txtBxSigla.BackColor = Color.LightYellow;
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

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {
            ExecuteModifyRegiao();

            if (txtBxSigla.Text == string.Empty)
            {
                ErrPrvdrRegiao.SetError(txtBxSigla, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxSigla.Focus();
                return;
            }

            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrRegiao.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
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

        private void ExecuteModifyRegiao()
        {
            switch (ModificaRegiaoType)
            {
                case ModificaRegiaoType.RegiaoAdicionar:
                    ExecuteAddRegiao();
                    break;
                case ModificaRegiaoType.RegiaoAlterar:
                    ExecuteUpdateRegiao();
                    break;
            }
        }

        private void ExecuteUpdateRegiao()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteUpdateRegiao";

            string _SiglaRegiao = string.Empty;
            string _DescrRegiao = string.Empty;
            string _TipoModificacao = string.Empty;

            _SiglaRegiao = txtBxSigla.Text;
            _DescrRegiao = txtBxDescricao.Text;
            _TipoModificacao = RegionProcess.CreateInstance.FromToModificaRegiao(ModificaRegiaoType.RegiaoAlterar);

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }
                _IdExecute = RegionProcess.CreateInstance.TaskModifyProcessRegiao(_SiglaRegiao, _DescrRegiao, _TipoModificacao);
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

                if (_LogSiglaRegiao != null) { _LogSiglaRegiao.ValorNovo = _SiglaRegiao; }
                if (_LogDescricaoRegiao != null) { _LogDescricaoRegiao.ValorNovo = _DescrRegiao; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogSiglaRegiao);
                _ChangeItems.Add(_LogDescricaoRegiao);

                #endregion

                ExecuteModifyExceptionLogRegiao(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogSiglaRegiao != null) { _LogSiglaRegiao.ValorNovo = _SiglaRegiao; }
                    if (_LogDescricaoRegiao != null) { _LogDescricaoRegiao.ValorNovo = _DescrRegiao; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogSiglaRegiao);
                    _ChangeItems.Add(_LogDescricaoRegiao);

                    #endregion

                    ExecuteModifyLogRegiao(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void ExecuteAddRegiao()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteAddRegiao";

            string _SiglaRegiao = string.Empty;
            string _DescrRegiao = string.Empty;
            string _TipoModificacao = string.Empty;

            _SiglaRegiao = txtBxSigla.Text;
            _DescrRegiao = txtBxDescricao.Text;
            _TipoModificacao = RegionProcess.CreateInstance.FromToModificaRegiao(ModificaRegiaoType.RegiaoAdicionar);

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }
                _IdExecute = RegionProcess.CreateInstance.TaskModifyProcessRegiao(_SiglaRegiao, _DescrRegiao, _TipoModificacao);
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

                if (_LogSiglaRegiao != null) { _LogSiglaRegiao.ValorNovo = _SiglaRegiao; }
                if (_LogDescricaoRegiao != null) { _LogDescricaoRegiao.ValorNovo = _DescrRegiao; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogSiglaRegiao);
                _ChangeItems.Add(_LogDescricaoRegiao);

                #endregion

                ExecuteModifyExceptionLogRegiao(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogSiglaRegiao != null) { _LogSiglaRegiao.ValorNovo = _SiglaRegiao; }
                    if (_LogDescricaoRegiao != null) { _LogDescricaoRegiao.ValorNovo = _DescrRegiao; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogSiglaRegiao);
                    _ChangeItems.Add(_LogDescricaoRegiao);

                    #endregion

                    ExecuteModifyLogRegiao(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }

        }

        private void ExecuteModifyLogRegiao(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }

        private void ExecuteModifyExceptionLogRegiao(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void FillLogHeaderFromAddModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgRegiao.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdEmpr;
            _ChangesHeader.TipoModificacao = RegionProcess.CreateInstance.FromToModificaRegiao(ModificaRegiaoType.RegiaoAdicionar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Sigla Região
            _LogSiglaRegiao = new ChangeItem();
            _LogSiglaRegiao.IdChangeHeader = _ChangesHeader.Id;
            _LogSiglaRegiao.IdItem = 1;
            _LogSiglaRegiao.NomeTabela = DboRgRegiao.NomeTabela;
            _LogSiglaRegiao.NomeCampo = DboRgRegiao.NomeSiglaRegiao;
            //_LogSiglaRegiao.ValorAntigo = Sigla;

            //Descrição Região
            _LogDescricaoRegiao = new ChangeItem();
            _LogDescricaoRegiao.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricaoRegiao.IdItem = 2;
            _LogDescricaoRegiao.NomeTabela = DboRgRegiao.NomeTabela;
            _LogDescricaoRegiao.NomeCampo = DboRgRegiao.NomeDescrRegiao;
            //_LogDescricaoRegiao.ValorAntigo = Descricao;

            #endregion
        }
        private void FillLogHeaderFromUpdateModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgRegiao.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdEmpr;
            _ChangesHeader.TipoModificacao = RegionProcess.CreateInstance.FromToModificaRegiao(ModificaRegiaoType.RegiaoAlterar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Sigla Região
            _LogSiglaRegiao = new ChangeItem();
            _LogSiglaRegiao.IdChangeHeader = _ChangesHeader.Id;
            _LogSiglaRegiao.IdItem = 1;
            _LogSiglaRegiao.NomeTabela = DboRgRegiao.NomeTabela;
            _LogSiglaRegiao.NomeCampo = DboRgRegiao.NomeSiglaRegiao;
            _LogSiglaRegiao.ValorAntigo = Sigla;

            //Descrição Região
            _LogDescricaoRegiao = new ChangeItem();
            _LogDescricaoRegiao.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricaoRegiao.IdItem = 2;
            _LogDescricaoRegiao.NomeTabela = DboRgRegiao.NomeTabela;
            _LogDescricaoRegiao.NomeCampo = DboRgRegiao.NomeDescrRegiao;
            _LogDescricaoRegiao.ValorAntigo = Descricao;

            #endregion
        }

        private void UpdateFormRegiao_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;

            if (ModificaRegiaoType == ModificaRegiaoType.RegiaoAlterar)
            {
                FillLogHeaderFromUpdateModify();
                FillDataParametersToExecuteUpdateModify();
            }

            if (ModificaRegiaoType == ModificaRegiaoType.RegiaoAdicionar)
            {
                FillLogHeaderFromAddModify();
                FillDataParametersToExecuteAddModify();
            }
        }

        private void FillDataParametersToExecuteUpdateModify()
        {
            txtBxSigla.Text = Sigla;
            txtBxDescricao.Text = Descricao;
            txtBxSigla.ReadOnly = true;
        }

        private void FillDataParametersToExecuteAddModify()
        {
            if (txtBxSigla.ReadOnly)
            {
                txtBxSigla.ReadOnly = false;
            }
        }

        // ...::: INICIO VALIDAÇÕES :::...
        private void txtBxSigla_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxSigla.Text == string.Empty)
            {
                ErrPrvdrRegiao.SetError(txtBxSigla, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrRegiao.SetError(txtBxSigla, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaAceiteSomenteCaracteres(txtBxSigla.Text))
                {
                    ErrPrvdrRegiao.SetError(txtBxSigla, ValidationsMessages.VALIDA_SIGLA_REGIAO);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrRegiao.SetError(txtBxSigla, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxDescricao_TextChanged(object sender, EventArgs e)
        {
            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrRegiao.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrRegiao.SetError(txtBxDescricao, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxSigla_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrRegiao.SetError(txtBxSigla, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrRegiao.SetError(txtBxDescricao, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }
    }

    internal static class DboRgRegiao
    {
        #region ...::: Private Constantes :::...

        private const string _NomeSiglaRegiao = "sigla_regiao";
        private const string _NomeDescrRegiao = "descr_regiao";
        private const string _NomeTabela = "rg_regiao";
        private const string _NomeProcesso = "Regiao";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeSiglaRegiao { get { return _NomeSiglaRegiao; } }
        public static string NomeDescrRegiao { get { return _NomeDescrRegiao; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
