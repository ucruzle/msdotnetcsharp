using BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects;
using BrSoftNet.App.Business.Processes.OverallRecord.Enumerators;
using BrSoftNet.App.Business.Processes.OverallRecord.Tasks;
using BrSoftNet.App.UI.Win.OverallRecord.State;
using BrSoftNet.Library.Messages;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Log.Actions;
using BrSoftNet.Log.Helpers;
using BrSoftNet.Log.Structures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.OverallRecord.DialogUpdateForm
{
    public partial class UpdateFormEstado : Form
    {
        #region ...::: Private Variable :::...

        private string _TipoModificacao = string.Empty;

        private int _IdExecute = 0;

        private RgRegiao _RgRegiao = null;

        private List<RgRegiao> _RgRegiaoCollection = null;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpr { get; set; }
        public int IdRg { get; set; }
        public string UsuarioLogin { get; set; }
        public ModificaEstadoType ModificaEstadoType { get; set; }
        public string SiglaEstado { get; set; }
        public string Descricao { get; set; }
        public string SiglaRegiao { get; set; }
        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;
        
        private ChangeItem _LogSiglaEstado = null;
        private ChangeItem _LogDescricao = null;
        private ChangeItem _LogSiglaRegiao = null;
        
        private List<ChangeItem> _ChangeItems = null;
        
        private ThrowingException _ThrowingException = null;

        private string _IdExcepitionLog = string.Empty;
        private string _MenssageLogError = string.Empty;

        #endregion

        public UpdateFormEstado()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();

            this.txtBxSigla.GotFocus += txtBxSigla_GotFocus;
            this.txtBxSigla.LostFocus += txtBxSigla_LostFocus;

            this.txtBxDescricao.GotFocus += txtBxDescricao_GotFocus;
            this.txtBxDescricao.LostFocus += txtBxDescricao_LostFocus;

            this.cbBxRegiao.GotFocus += cbBxRegiao_GotFocus;
            this.cbBxRegiao.LostFocus += cbBxRegiao_LostFocus;
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

        void cbBxRegiao_LostFocus(object sender, EventArgs e)
        {
            this.cbBxRegiao.BackColor = Color.White;
        }

        void cbBxRegiao_GotFocus(object sender, EventArgs e)
        {
            this.cbBxRegiao.BackColor = Color.LightYellow;
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
            this.ExecuteModifyEstado();

            if (txtBxSigla.Text == string.Empty)
            {
                ErrPrvdrEstado.SetError(txtBxSigla, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxSigla.Focus();
                return;
            }

            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrEstado.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
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

        private void ExecuteModifyEstado()
        {
            switch (ModificaEstadoType)
            {
                case ModificaEstadoType.EstadoAdicionar:
                    ExecuteAddEstado();
                    break;
                case ModificaEstadoType.EstadoAlterar:
                    ExecuteUpdateEstado();
                    break;
            }
        }

        private void ExecuteUpdateEstado()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteUpdateEstado";
            
            string _SiglaEstado = string.Empty;
            string _DescrEstado = string.Empty;
            string _SiglaRegiao = string.Empty;
            string _TipoModificacao = string.Empty;

            _SiglaEstado = txtBxSigla.Text;
            _DescrEstado = txtBxDescricao.Text;
            _SiglaRegiao = Convert.ToString(cbBxRegiao.SelectedValue);
            _TipoModificacao = EstadoProcess.CreateInstance.FromToModificaEstado(ModificaEstadoType.EstadoAlterar);

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }   
                _IdExecute = EstadoProcess.CreateInstance.TaskModifyProcessEstado(_SiglaEstado, _DescrEstado, _SiglaRegiao, _TipoModificacao);
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

                if (_LogSiglaEstado != null) { _LogSiglaEstado.ValorNovo = _SiglaEstado; }
                if (_LogDescricao != null) { _LogDescricao.ValorNovo = _DescrEstado; }
                if (_LogSiglaRegiao != null) { _LogSiglaRegiao.ValorNovo = _SiglaRegiao; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogSiglaEstado);
                _ChangeItems.Add(_LogDescricao);
                _ChangeItems.Add(_LogSiglaRegiao);

                #endregion

                ExecuteModifyExceptionLogEstado(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogSiglaEstado != null) { _LogSiglaEstado.ValorNovo = _SiglaEstado; }
                    if (_LogDescricao != null) { _LogDescricao.ValorNovo = _DescrEstado; }
                    if (_LogSiglaRegiao != null) { _LogSiglaRegiao.ValorNovo = _SiglaRegiao; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogSiglaEstado);
                    _ChangeItems.Add(_LogDescricao);
                    _ChangeItems.Add(_LogSiglaRegiao);

                    #endregion

                    ExecuteModifyLogEstado(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void ExecuteModifyExceptionLogEstado(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void ExecuteModifyLogEstado(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }

        private void ExecuteAddEstado()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteAddEstado";

            string _SiglaEstado = string.Empty;
            string _DescrEstado = string.Empty;
            string _SiglaRegiao = string.Empty;
            string _TipoModificacao = string.Empty;

            _SiglaEstado = txtBxSigla.Text;
            _DescrEstado = txtBxDescricao.Text;
            _SiglaRegiao = Convert.ToString(cbBxRegiao.SelectedValue);
            _TipoModificacao = EstadoProcess.CreateInstance.FromToModificaEstado(ModificaEstadoType.EstadoAdicionar);

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }   
                _IdExecute = EstadoProcess.CreateInstance.TaskModifyProcessEstado(_SiglaEstado, _DescrEstado, _SiglaRegiao, _TipoModificacao);
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

                if (_LogSiglaEstado != null) { _LogSiglaEstado.ValorNovo = _SiglaEstado; }
                if (_LogDescricao != null) { _LogDescricao.ValorNovo = _DescrEstado; }
                if (_LogSiglaRegiao != null) { _LogSiglaRegiao.ValorNovo = _SiglaRegiao; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogSiglaEstado);
                _ChangeItems.Add(_LogDescricao);
                _ChangeItems.Add(_LogSiglaRegiao);

                #endregion

                ExecuteModifyExceptionLogEstado(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogSiglaEstado != null) { _LogSiglaEstado.ValorNovo = _SiglaEstado; }
                    if (_LogDescricao != null) { _LogDescricao.ValorNovo = _DescrEstado; }
                    if (_LogSiglaRegiao != null) { _LogSiglaRegiao.ValorNovo = _SiglaRegiao; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogSiglaEstado);
                    _ChangeItems.Add(_LogDescricao);
                    _ChangeItems.Add(_LogSiglaRegiao);

                    #endregion

                    ExecuteModifyLogEstado(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void UpdateFormEstado_Load(object sender, EventArgs e)
        {
            this.lblActionModuleTitle.Text = TextoDoTilutoDoFormulario;

            if (ModificaEstadoType == ModificaEstadoType.EstadoAlterar)
            {
                FillLogHeaderFromUpdateModify();
                FillDataParametersToExecuteUpdateModify();
            }

            if (ModificaEstadoType == ModificaEstadoType.EstadoAdicionar)
            {
                FillLogHeaderFromAddModify();
                FillDataParametersToExecuteAddModify();
            }
        }

        private void FillLogHeaderFromAddModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgEstado.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdEmpr;
            _ChangesHeader.TipoModificacao = EstadoProcess.CreateInstance.FromToModificaEstado(ModificaEstadoType.EstadoAdicionar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Sigla Estado
            _LogSiglaEstado = new ChangeItem();
            _LogSiglaEstado.IdChangeHeader = _ChangesHeader.Id;
            _LogSiglaEstado.IdItem = 1;
            _LogSiglaEstado.NomeTabela = DboRgEstado.NomeTabela;
            _LogSiglaEstado.NomeCampo = DboRgEstado.NomeSiglaEstado;
            //_LogSiglaEstado.ValorAntigo = this.SiglaEstado;

            //Descrição Estado
            _LogDescricao = new ChangeItem();
            _LogDescricao.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricao.IdItem = 2;
            _LogDescricao.NomeTabela = DboRgEstado.NomeTabela;
            _LogDescricao.NomeCampo = DboRgEstado.NomeDescrEstado;
            //_LogDescricao.ValorAntigo = this.Descricao;

            //Sigla Região
            _LogSiglaRegiao = new ChangeItem();
            _LogSiglaRegiao.IdChangeHeader = _ChangesHeader.Id;
            _LogSiglaRegiao.IdItem = 3;
            _LogSiglaRegiao.NomeTabela = DboRgEstado.NomeTabela;
            _LogSiglaRegiao.NomeCampo = DboRgEstado.NomeSiglaRegiao;
            //_LogSiglaRegiao.ValorAntigo = this.SiglaRegiao;

            #endregion
        }

        private void FillLogHeaderFromUpdateModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgEstado.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdEmpr;
            _ChangesHeader.TipoModificacao = EstadoProcess.CreateInstance.FromToModificaEstado(ModificaEstadoType.EstadoAlterar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Sigla Estado
            _LogSiglaEstado = new ChangeItem();
            _LogSiglaEstado.IdChangeHeader = _ChangesHeader.Id;
            _LogSiglaEstado.IdItem = 1;
            _LogSiglaEstado.NomeTabela = DboRgEstado.NomeTabela;
            _LogSiglaEstado.NomeCampo = DboRgEstado.NomeSiglaEstado;
            _LogSiglaEstado.ValorAntigo = this.SiglaEstado;

            //Descrição Estado
            _LogDescricao = new ChangeItem();
            _LogDescricao.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricao.IdItem = 2;
            _LogDescricao.NomeTabela = DboRgEstado.NomeTabela;
            _LogDescricao.NomeCampo = DboRgEstado.NomeDescrEstado;
            _LogDescricao.ValorAntigo = this.Descricao;

            //Sigla Região
            _LogSiglaRegiao = new ChangeItem();
            _LogSiglaRegiao.IdChangeHeader = _ChangesHeader.Id;
            _LogSiglaRegiao.IdItem = 3;
            _LogSiglaRegiao.NomeTabela = DboRgEstado.NomeTabela;
            _LogSiglaRegiao.NomeCampo = DboRgEstado.NomeSiglaRegiao;
            _LogSiglaRegiao.ValorAntigo = this.SiglaRegiao;                        

            #endregion

        }

        private void FillDataParametersToExecuteUpdateModify()
        {
            if ((_RgRegiaoCollection == null))
            {
                _RgRegiaoCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgRegiao();
            }

            _RgRegiao = AppStateOverallRecord.RgRegiaoModifyProcess;

            cbBxRegiao.DataSource = _RgRegiaoCollection;
            cbBxRegiao.ValueMember = "SiglaRegiao";
            cbBxRegiao.DisplayMember = "DescrRegiao";

            txtBxSigla.Text = SiglaEstado;
            txtBxDescricao.Text = Descricao;
            cbBxRegiao.SelectedValue = SiglaRegiao;
        }

        private void FillDataParametersToExecuteAddModify()
        {
            if ((_RgRegiaoCollection == null))
            {
                _RgRegiaoCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgRegiao();
            }

            _RgRegiao = AppStateOverallRecord.RgRegiaoModifyProcess;

            cbBxRegiao.DataSource = _RgRegiaoCollection;
            cbBxRegiao.ValueMember = "SiglaRegiao";
            cbBxRegiao.DisplayMember = "DescrRegiao";
        }

        private void tlstrBtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ...::: INICIO VALIDAÇÕES :::...
        private void txtBxSigla_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ValidationData.CreateInstance.ValidaAceiteSomenteCaracteres(txtBxSigla.Text))
            {
                ErrPrvdrEstado.SetError(txtBxSigla, ValidationsMessages.VALIDA_UF);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrEstado.SetError(txtBxSigla, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }   
        }

        private void txtBxDescricao_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrEstado.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrEstado.SetError(txtBxDescricao, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrEstado.SetError(txtBxDescricao, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxSigla_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrEstado.SetError(txtBxSigla, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }
    }

    internal static class DboRgEstado
    {
        #region ...::: Private Constantes :::...

        private const string _NomeSiglaEstado = "sigla_estado";
        private const string _NomeDescrEstado = "descr_estado";
        private const string _NomeSiglaRegiao = "sigla_regiao";
        private const string _NomeTabela = "rg_estado";
        private const string _NomeProcesso = "Estado";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeSiglaEstado { get { return _NomeSiglaEstado; } }
        public static string NomeDescrEstado { get { return _NomeDescrEstado; } }
        public static string NomeSiglaRegiao { get { return _NomeSiglaRegiao; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
