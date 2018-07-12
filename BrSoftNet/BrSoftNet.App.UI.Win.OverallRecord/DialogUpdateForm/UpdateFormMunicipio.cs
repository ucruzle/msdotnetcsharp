using BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects;
using BrSoftNet.App.Business.Processes.OverallRecord.Enumerators;
using BrSoftNet.App.Business.Processes.OverallRecord.Tasks;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using BrSoftNet.App.UI.Win.OverallRecord.State;
using BrSoftNet.Library.Messages;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Log.Structures;
using BrSoftNet.Log.Actions;
using BrSoftNet.Log.Helpers;

namespace BrSoftNet.App.UI.Win.OverallRecord.DialogUpdateForm
{
    public partial class UpdateFormMunicipio : Form
    {
        #region ...::: Private Variable :::...

        private string _TipoModificacao = string.Empty;

        private int _IdExecute = 0;

        private RgEstado _RgEstado = null;

        private List<RgEstado> _RgEstadoCollection = null;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpr { get; set; }
        public int IdRg { get; set; }
        public string UsuarioLogin { get; set; }
        public ModificaMunicipioType ModificaMunicipioType { get; set; }
        public int IdMunicipio { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variables :::...

        public List<RgEstado> RgEstadoCollection { get; set; }
        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;
        private ChangeItem _LogIdMunicipio = null;
        private ChangeItem _LogMunicipio = null;
        private ChangeItem _LogUF = null;
        private List<ChangeItem> _ChangeItems = null;
        private ThrowingException _ThrowingException = null;

        private string _IdExcepitionLog = string.Empty;
        private string _MenssageLogError = string.Empty;

        #endregion

        public UpdateFormMunicipio()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();

            this.txtBxDescricao.GotFocus += txtBxDescricao_GotFocus;
            this.txtBxDescricao.LostFocus += txtBxDescricao_LostFocus;

            this.cmbBxEstado.GotFocus += cmbBxEstado_GotFocus;
            this.cmbBxEstado.LostFocus += cmbBxEstado_LostFocus;
        }

        void cmbBxEstado_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxEstado.BackColor = Color.White;
        }

        void cmbBxEstado_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxEstado.BackColor = Color.LightYellow;
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
            this.ExecuteModifyMunicipio();

            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrMunicipio.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
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

        private void ExecuteModifyMunicipio()
        {
            switch (ModificaMunicipioType)
            {
                case ModificaMunicipioType.MunicipioAdicionar:
                    ExecuteAddMunicipio();
                    break;
                case ModificaMunicipioType.MunicipioAlterar:
                    ExecuteUpdateMunicipio();
                    break;
            }
        }

        private void ExecuteUpdateMunicipio()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteUpdateMunicipio";

            int _CodigoMunicipio = 0;
            string _Municipio = txtBxDescricao.Text;
            string _SiglaEstado = string.Empty;
            string _TipoModificacao = string.Empty;

            _CodigoMunicipio = Convert.ToInt32(txtBxMunicipio.Text);
            _SiglaEstado = Convert.ToString(cmbBxEstado.SelectedValue);
            
            _TipoModificacao = MunicipioProcess.CreateInstance.FromToModificaMunicipio(ModificaMunicipioType.MunicipioAlterar);

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }   
                _IdExecute = MunicipioProcess.CreateInstance.TaskModifyProcessMunicipio(_CodigoMunicipio, _Municipio, _SiglaEstado, _TipoModificacao);
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

                if (_LogIdMunicipio!= null) { _LogIdMunicipio.ValorNovo = _CodigoMunicipio; }
                if (_LogMunicipio != null) { _LogMunicipio.ValorNovo = _Municipio; }
                if (_LogUF != null) { _LogUF.ValorNovo = _SiglaEstado; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogIdMunicipio);
                _ChangeItems.Add(_LogMunicipio);
                _ChangeItems.Add(_LogUF);

                #endregion

                ExecuteModifyExceptionLogMunicipio(_ChangesHeader, _ChangeItems, _ThrowingException);
                
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogIdMunicipio != null) { _LogIdMunicipio.ValorNovo = _CodigoMunicipio; }
                    if (_LogMunicipio != null) { _LogMunicipio.ValorNovo = _Municipio; }
                    if (_LogUF != null) { _LogUF.ValorNovo = _SiglaEstado; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogIdMunicipio);
                    _ChangeItems.Add(_LogMunicipio);
                    _ChangeItems.Add(_LogUF);

                    #endregion

                    ExecuteModifyLogMunicipio(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void ExecuteModifyExceptionLogMunicipio(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }
         private void ExecuteModifyLogMunicipio(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }

        private void ExecuteAddMunicipio()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteAddMunicipio";

            txtBxMunicipio.Text = "0";
            int _CodigoMunicipio = 0;
            string _Municipio = txtBxDescricao.Text;
            string _SiglaEstado = string.Empty;
            string _TipoModificacao = string.Empty;
            

            _CodigoMunicipio = Convert.ToInt32(txtBxMunicipio.Text);
            _SiglaEstado = Convert.ToString(cmbBxEstado.SelectedValue);
            
            _TipoModificacao = MunicipioProcess.CreateInstance.FromToModificaMunicipio(ModificaMunicipioType.MunicipioAdicionar);

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }   
                _IdExecute = MunicipioProcess.CreateInstance.TaskModifyProcessMunicipio(_CodigoMunicipio, _Municipio, _SiglaEstado, _TipoModificacao);
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

                if (_LogIdMunicipio != null) { _LogIdMunicipio.ValorNovo = _CodigoMunicipio; }
                if (_LogMunicipio != null) { _LogMunicipio.ValorNovo = _Municipio; }
                if (_LogUF != null) { _LogUF.ValorNovo = _SiglaEstado; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogIdMunicipio);
                _ChangeItems.Add(_LogMunicipio);
                _ChangeItems.Add(_LogUF);

                #endregion

                ExecuteModifyExceptionLogMunicipio(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogIdMunicipio != null) { _LogIdMunicipio.ValorNovo = _CodigoMunicipio; }
                    if (_LogMunicipio != null) { _LogMunicipio.ValorNovo = _Municipio; }
                    if (_LogUF != null) { _LogUF.ValorNovo = _SiglaEstado; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogIdMunicipio);
                    _ChangeItems.Add(_LogMunicipio);
                    _ChangeItems.Add(_LogUF);

                    #endregion

                    ExecuteModifyLogMunicipio(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void UpdateFormMunicipio_Load(object sender, EventArgs e)
        {
            this.lblActionModuleTitle.Text = TextoDoTilutoDoFormulario;

            switch (ModificaMunicipioType)
            {
                case ModificaMunicipioType.MunicipioAdicionar:
                    FillLogHeaderFromAddModify();
                    FillDataParametersToAddModify();
                    break;
                case ModificaMunicipioType.MunicipioAlterar:
                    FillLogHeaderFromUpdateModify();
                    FillDataParametersToExecuteUpdateModify();
                    break;
                case ModificaMunicipioType.MunicipioExcluir:
                    break;
                default:
                    break;
            }
        }

        private void FillLogHeaderFromAddModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgMunicipio.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdMunicipio;
            _ChangesHeader.TipoModificacao = MunicipioProcess.CreateInstance.FromToModificaMunicipio(ModificaMunicipioType.MunicipioAdicionar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Municipio
            _LogIdMunicipio = new ChangeItem();
            _LogIdMunicipio.IdChangeHeader = _ChangesHeader.Id;
            _LogIdMunicipio.IdItem = 1;
            _LogIdMunicipio.NomeTabela = DboRgMunicipio.NomeTabela;
            _LogIdMunicipio.NomeCampo = DboRgMunicipio.NomeIdMunicipio;
            //_LogIdMunicipio.ValorAntigo = this.IdMunicipio;

            //Descrição Municipio
            _LogMunicipio = new ChangeItem();
            _LogMunicipio.IdChangeHeader = _ChangesHeader.Id;
            _LogMunicipio.IdItem = 2;
            _LogMunicipio.NomeTabela = DboRgMunicipio.NomeTabela;
            _LogMunicipio.NomeCampo = DboRgMunicipio.NomeDescrMunicipio;
            //_LogMunicipio.ValorAntigo = this.Municipio;

            //Sigla Região
            _LogUF = new ChangeItem();
            _LogUF.IdChangeHeader = _ChangesHeader.Id;
            _LogUF.IdItem = 3;
            _LogUF.NomeTabela = DboRgMunicipio.NomeTabela;
            _LogUF.NomeCampo = DboRgMunicipio.NomeSiglaMunicipio;
            //_LogUF.ValorAntigo = this.UF;

            #endregion
        }

        private void FillLogHeaderFromUpdateModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgMunicipio.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdMunicipio;
            _ChangesHeader.TipoModificacao = MunicipioProcess.CreateInstance.FromToModificaMunicipio(ModificaMunicipioType.MunicipioAlterar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Municipio
            _LogIdMunicipio = new ChangeItem();
            _LogIdMunicipio.IdChangeHeader = _ChangesHeader.Id;
            _LogIdMunicipio.IdItem = 1;
            _LogIdMunicipio.NomeTabela = DboRgMunicipio.NomeTabela;
            _LogIdMunicipio.NomeCampo = DboRgMunicipio.NomeIdMunicipio;
            _LogIdMunicipio.ValorAntigo = this.IdMunicipio;

            //Descrição Municipio
            _LogMunicipio = new ChangeItem();
            _LogMunicipio.IdChangeHeader = _ChangesHeader.Id;
            _LogMunicipio.IdItem = 2;
            _LogMunicipio.NomeTabela = DboRgMunicipio.NomeTabela;
            _LogMunicipio.NomeCampo = DboRgMunicipio.NomeDescrMunicipio;
            _LogMunicipio.ValorAntigo = this.Municipio;

            //Sigla Região
            _LogUF = new ChangeItem();
            _LogUF.IdChangeHeader = _ChangesHeader.Id;
            _LogUF.IdItem = 3;
            _LogUF.NomeTabela = DboRgMunicipio.NomeTabela;
            _LogUF.NomeCampo = DboRgMunicipio.NomeSiglaMunicipio;
            _LogUF.ValorAntigo = this.UF;

            #endregion
        }

        private void FillDataParametersToExecuteUpdateModify()
        {
            if (_RgEstadoCollection == null)
            {
                _RgEstadoCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgEstado();
            }

            _RgEstado = AppStateOverallRecord.RgEstadoModifyProcess;

            cmbBxEstado.DataSource = _RgEstadoCollection;
            cmbBxEstado.ValueMember = "UF";
            cmbBxEstado.DisplayMember = "DescrEstado";

            txtBxMunicipio.Text = IdMunicipio.ToString();
            txtBxDescricao.Text = Municipio;
            cmbBxEstado.SelectedValue = UF;
        }

        private void FillDataParametersToAddModify()
        {
            if (_RgEstadoCollection == null)
            {
                _RgEstadoCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgEstado();
            }

            _RgEstado = AppStateOverallRecord.RgEstadoModifyProcess;

            cmbBxEstado.DataSource = _RgEstadoCollection;
            cmbBxEstado.ValueMember = "UF";
            cmbBxEstado.DisplayMember = "DescrEstado";
        }

        // ...::: INICIO VALIDAÇÕES :::...
        private void txtBxDescricao_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxDescricao.Text == string.Empty)
            {
                ErrPrvdrMunicipio.SetError(txtBxDescricao, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrMunicipio.SetError(txtBxDescricao, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrMunicipio.SetError(txtBxDescricao, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }
    }

    internal static class DboRgMunicipio
    {
        #region ...::: Private Constantes :::...

        private const string _NomeIdMunicipio = "cod_municipio";
        private const string _NomeDescrMunicipio = "municipio";
        private const string _NomeSiglaMunicipio = "sigla_estado";
        private const string _NomeTabela = "rg_municipio";
        private const string _NomeProcesso = "Municipio";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeIdMunicipio { get { return _NomeIdMunicipio; } }
        public static string NomeDescrMunicipio { get { return _NomeDescrMunicipio; } }
        public static string NomeSiglaMunicipio { get { return _NomeSiglaMunicipio; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
