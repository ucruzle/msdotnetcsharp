using BrSoftNet.App.Business.Processes.Manager.Entities;
using BrSoftNet.App.Business.Processes.Manager.Enumerators;
using BrSoftNet.App.Business.Processes.Manager.Tasks;
using BrSoftNet.App.UI.Win.Manager.State;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Log.Actions;
using BrSoftNet.Log.Helpers;
using BrSoftNet.Log.Structures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Manager.DialogUpdateForm
{
    public partial class UpdateFormParametroGerenciador : Form
    {
        public int IdEmpr { get; set; }
        public string UsuarioLogin { get; set; }
        public int IdTipoProcesso { get; set; }
        public int IdTabela { get; set; }
        public string DirLogoEmpresa { get; set; }
        public string DirPgmRelatorio { get; set; }
        public string DirRelatorio { get; set; }
        public string DirBackup { get; set; }
        public string DirScript { get; set; }
        public string DirImportacao { get; set; }
        public string DirExportacaoExcel { get; set; }
        public int IdTipoProcEsp { get; set; }
        public int IdTipoProcInt { get; set; }
        public string MostraFormMenu { get; set; }
        public string DirFoto { get; set; }
        public string DirServidor { get; set; }
        public ModificaParametroGerenciadorType ModificaParametroGerenciadorType { get; set; }
        public string TextoDoTilutoDoFormulario { get; set; }

        private List<ProcessoGerenciador> _ProcessoEspecialCollection = null;

        private List<ProcessoGerenciador> _ProcessoInternetCollection = null;


        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;

        private ChangeItem _LogIdTabela = null;
        private ChangeItem _LogDirLogoEmpresa = null;
        private ChangeItem _LogDirPmgRelatorio = null;
        private ChangeItem _LogDirRelatorio = null;
        private ChangeItem _LogDirBackup = null;
        private ChangeItem _LogDirScript = null;
        private ChangeItem _LogDirImportacao = null;
        private ChangeItem _LogDirExportacaoExcel = null;
        private ChangeItem _LogCodTipoProcessoEsp = null;
        private ChangeItem _LogCodTipoProcessoInt = null;
        private ChangeItem _LogMostraFormMenu = null;
        private ChangeItem _LogDirFoto = null;
        private ChangeItem _LogServidor = null;

        private List<ChangeItem> _ChangeItems = null;
        private ThrowingException _ThrowingException = null;

        private string _IdExcepitionLog = string.Empty;
        private string _MenssageLogError = string.Empty;

        #endregion
        
        public UpdateFormParametroGerenciador()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();

            this.txtLogEmp.GotFocus += txtLogEmp_GotFocus;
            this.txtLogEmp.LostFocus += txtLogEmp_LostFocus;

            this.txtDirPGMRel.GotFocus += txtDirPGMRel_GotFocus;
            this.txtDirPGMRel.LostFocus += txtDirPGMRel_LostFocus;

            this.txtRelServ.GotFocus += txtRelServ_GotFocus;
            this.txtRelServ.LostFocus += txtRelServ_LostFocus;

            this.txtlDirRel.GotFocus += txtlDirRel_GotFocus;
            this.txtlDirRel.LostFocus += txtlDirRel_LostFocus;

            this.txtlDirBackup.GotFocus += txtlDirBackup_GotFocus;
            this.txtlDirBackup.LostFocus += txtlDirBackup_LostFocus;

            this.txtDirScript.GotFocus += txtDirScript_GotFocus;
            this.txtDirScript.LostFocus += txtDirScript_LostFocus;

            this.txtDirImport.GotFocus += txtDirImport_GotFocus;
            this.txtDirImport.LostFocus += txtDirImport_LostFocus;

            this.txtDirExportExcel.GotFocus += txtDirExportExcel_GotFocus;
            this.txtDirExportExcel.LostFocus += txtDirExportExcel_LostFocus;

            this.txtDirFoto.GotFocus += txtDirFoto_GotFocus;
            this.txtDirFoto.LostFocus += txtDirFoto_LostFocus;

            this.cmbBoxTpProcEsp.GotFocus += cmbBoxTpProcEsp_GotFocus;
            this.cmbBoxTpProcEsp.LostFocus += cmbBoxTpProcEsp_LostFocus;

            this.cmbBoxTpOpcInt.GotFocus += cmbBoxTpOpcInt_GotFocus;
            this.cmbBoxTpOpcInt.LostFocus += cmbBoxTpOpcInt_LostFocus;
        }

        private void InicialiazeUpdateForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void FillDataParametersToExecuteUpdateModify()
        {
            if ((_ProcessoEspecialCollection == null) || (_ProcessoInternetCollection == null))
            {
                _ProcessoEspecialCollection = ManagementParameterProcess.CreateInstance.TaskGetProcessesAll();
                _ProcessoInternetCollection = ManagementParameterProcess.CreateInstance.TaskGetProcessesAll();
            }

            txtLogEmp.Text = DirLogoEmpresa;
            txtDirPGMRel.Text = DirPgmRelatorio;
            txtlDirRel.Text = DirRelatorio;
            txtlDirBackup.Text = DirBackup;
            txtRelServ.Text = DirServidor;
            txtDirScript.Text = DirScript;
            txtDirImport.Text = DirImportacao;
            txtDirExportExcel.Text = DirExportacaoExcel;
            txtDirFoto.Text = DirFoto;

            cmbBoxTpProcEsp.DataSource = _ProcessoEspecialCollection;
            cmbBoxTpProcEsp.ValueMember = "CodigoProcesso";
            cmbBoxTpProcEsp.DisplayMember = "DescricaoProcesso";
            cmbBoxTpProcEsp.SelectedValue = IdTipoProcEsp;

            cmbBoxTpOpcInt.DataSource = _ProcessoInternetCollection;
            cmbBoxTpOpcInt.ValueMember = "CodigoProcesso";
            cmbBoxTpOpcInt.DisplayMember = "DescricaoProcesso";
            cmbBoxTpOpcInt.SelectedValue = IdTipoProcInt;

            chkMstrOpcMenu.Checked = (MostraFormMenu == "S" ? true : false);
        }

        private void FillDataParametersToExecuteAddModify()
        {
            if ((_ProcessoEspecialCollection == null) || (_ProcessoInternetCollection == null))
            {
                _ProcessoEspecialCollection = ManagementParameterProcess.CreateInstance.TaskGetProcessesAll();
                _ProcessoInternetCollection = ManagementParameterProcess.CreateInstance.TaskGetProcessesAll();
            }

            cmbBoxTpProcEsp.DataSource = _ProcessoEspecialCollection;
            cmbBoxTpProcEsp.ValueMember = "CodigoProcesso";
            cmbBoxTpProcEsp.DisplayMember = "DescricaoProcesso";

            cmbBoxTpOpcInt.DataSource = _ProcessoInternetCollection;
            cmbBoxTpOpcInt.ValueMember = "CodigoProcesso";
            cmbBoxTpOpcInt.DisplayMember = "DescricaoProcesso";

            AppStateManager.IdTipoProcEsp = Convert.ToInt32(cmbBoxTpProcEsp.SelectedValue);
            AppStateManager.IdTipoProcInt = Convert.ToInt32(cmbBoxTpOpcInt.SelectedValue);
        }

        void txtlDirBackup_LostFocus(object sender, EventArgs e)
        {
            this.txtlDirBackup.BackColor = Color.White;
        }

        void txtlDirBackup_GotFocus(object sender, EventArgs e)
        {
            this.txtlDirBackup.BackColor = Color.LightYellow;
        }

        void txtDirFoto_LostFocus(object sender, EventArgs e)
        {
            this.txtDirFoto.BackColor = Color.White;
        }

        void txtDirFoto_GotFocus(object sender, EventArgs e)
        {
            this.txtDirFoto.BackColor = Color.LightYellow;
        }

        void txtDirExportExcel_LostFocus(object sender, EventArgs e)
        {
            this.txtDirExportExcel.BackColor = Color.White;
        }

        void txtDirExportExcel_GotFocus(object sender, EventArgs e)
        {
            this.txtDirExportExcel.BackColor = Color.LightYellow;
        }

        void txtDirImport_LostFocus(object sender, EventArgs e)
        {
            this.txtDirImport.BackColor = Color.White;
        }

        void txtDirImport_GotFocus(object sender, EventArgs e)
        {
            this.txtDirImport.BackColor = Color.LightYellow;
        }

        void txtDirScript_LostFocus(object sender, EventArgs e)
        {
            this.txtDirScript.BackColor = Color.White;
        }

        void txtDirScript_GotFocus(object sender, EventArgs e)
        {
            this.txtDirScript.BackColor = Color.LightYellow;
        }

        void txtRelServ_LostFocus(object sender, EventArgs e)
        {
            this.txtRelServ.BackColor = Color.White;
        }

        void txtRelServ_GotFocus(object sender, EventArgs e)
        {
            this.txtRelServ.BackColor = Color.LightYellow;
        }

        void txtlDirRel_LostFocus(object sender, EventArgs e)
        {
            this.txtlDirRel.BackColor = Color.White;
        }

        void txtlDirRel_GotFocus(object sender, EventArgs e)
        {
            this.txtlDirRel.BackColor = Color.LightYellow;
        }

        void cmbBoxTpOpcInt_LostFocus(object sender, EventArgs e)
        {
            this.cmbBoxTpOpcInt.BackColor = Color.White;
        }

        void cmbBoxTpOpcInt_GotFocus(object sender, EventArgs e)
        {
            this.cmbBoxTpOpcInt.BackColor = Color.LightYellow;
        }

        void cmbBoxTpProcEsp_LostFocus(object sender, EventArgs e)
        {
            this.cmbBoxTpProcEsp.BackColor = Color.White;
        }

        void cmbBoxTpProcEsp_GotFocus(object sender, EventArgs e)
        {
            this.cmbBoxTpProcEsp.BackColor = Color.LightYellow;
        }

        void txtDirPGMRel_LostFocus(object sender, EventArgs e)
        {
            this.txtDirPGMRel.BackColor = Color.White;
        }

        void txtDirPGMRel_GotFocus(object sender, EventArgs e)
        {
            this.txtDirPGMRel.BackColor = Color.LightYellow;
        }

        void txtLogEmp_LostFocus(object sender, EventArgs e)
        {
            this.txtLogEmp.BackColor = Color.White;
        }

        void txtLogEmp_GotFocus(object sender, EventArgs e)
        {
            this.txtLogEmp.BackColor = Color.LightYellow;
        }

        private void btnDirLogEmp_Click(object sender, EventArgs e)
        {
            this.txtLogEmp.Text = UserInterfaceWin.CreateInstance.SaveDirectoryPath();
        }

        private void btnDirPgmRel_Click(object sender, EventArgs e)
        {
            this.txtDirPGMRel.Text = UserInterfaceWin.CreateInstance.SaveDirectoryPath();
        }

        private void btnDirRel_Click(object sender, EventArgs e)
        {
            this.txtlDirRel.Text = UserInterfaceWin.CreateInstance.SaveDirectoryPath();
        }

        private void btnDirServ_Click(object sender, EventArgs e)
        {
            this.txtRelServ.Text = UserInterfaceWin.CreateInstance.SaveDirectoryPath();
        }

        private void btnDirScript_Click(object sender, EventArgs e)
        {
            this.txtDirScript.Text = UserInterfaceWin.CreateInstance.SaveDirectoryPath();
        }

        private void btnDirImprt_Click(object sender, EventArgs e)
        {
            this.txtDirImport.Text = UserInterfaceWin.CreateInstance.SaveDirectoryPath();
        }

        private void btnDirExprt_Click(object sender, EventArgs e)
        {
            this.txtDirExportExcel.Text = UserInterfaceWin.CreateInstance.SaveDirectoryPath();
        }

        private void btnDirFoto_Click(object sender, EventArgs e)
        {
            this.txtDirFoto.Text = UserInterfaceWin.CreateInstance.SaveDirectoryPath();
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, EventArgs e)
        {
            ExecuteModifyParametroGerenciador();

            if (_IdExcepitionLog != string.Empty)
            {
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblExcecao.Text = _MenssageLogError;
                tlstrpLblExcecao.Visible = true;
                return;
            }

            this.Close();
        }

        private void ExecuteModifyParametroGerenciador()
        {
            switch (ModificaParametroGerenciadorType)
            {
                case ModificaParametroGerenciadorType.ParametroGerenciadorAdicionar:
                    ExecuteAddDataParametroGerenciador();
                    break;
                case ModificaParametroGerenciadorType.ParametroGerenciadorAlterar:
                    ExecuteUpdateDataParametroGerenciador();
                    break;
            }
        }

        private void ExecuteAddDataParametroGerenciador() 
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnAdd_Click";
            int _IdTipoProcessoInt = 0;
            int _IdTabela = 0;
            int _IdTipoProcEsp = 0;
            string _DirLogoEmpresa = string.Empty;
            string _DirPgmRelatorio = string.Empty;
            string _DirRelatorio = string.Empty;
            string _DirBackup = string.Empty;
            string _DirScript = string.Empty;
            string _DirImportacao = string.Empty;
            string _DirExportacaoExcel = string.Empty;
            string _MostraFormMenu = string.Empty;
            string _DirFoto = string.Empty;
            string _DirServidor = string.Empty;

            string _ModifyType = string.Empty;
            string _MostraMenu = string.Empty;
            int _IdTipoProcInt = 0;

            try
            {
                _ModifyType = ManagementParameterProcess.CreateInstance.FromToModificaParametroGerenciador(ModificaParametroGerenciadorType.ParametroGerenciadorAdicionar);
                _MostraMenu = chkMstrOpcMenu.Checked ? "S" : "N";
                _IdTipoProcEsp = Convert.ToInt32(cmbBoxTpProcEsp.SelectedValue);
                _IdTipoProcInt = Convert.ToInt32(cmbBoxTpOpcInt.SelectedValue);

                IdTabela = Convert.ToInt32(ManagementParameterProcess.CreateInstance.TaskModifyDataProcesses(0, txtLogEmp.Text, txtDirPGMRel.Text, txtlDirRel.Text, txtlDirBackup.Text, txtDirScript.Text, txtDirImport.Text, txtDirExportExcel.Text, _IdTipoProcEsp, _IdTipoProcInt, _MostraMenu, txtDirFoto.Text, txtRelServ.Text, _ModifyType));
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

                if (_LogIdTabela != null) { _LogIdTabela.ValorNovo = _IdTabela; }
                if (_LogDirLogoEmpresa != null) { _LogDirLogoEmpresa.ValorNovo = _DirLogoEmpresa; }
                if (_LogDirPmgRelatorio != null) { _LogDirPmgRelatorio.ValorNovo = _DirPgmRelatorio; }
                if (_LogDirRelatorio != null) { _LogDirRelatorio.ValorNovo = _DirRelatorio; }
                if (_LogDirBackup != null) { _LogDirBackup.ValorNovo = _DirBackup; }
                if (_LogDirScript != null) { _LogDirScript.ValorNovo = _DirScript; }
                if (_LogDirImportacao != null) { _LogDirImportacao.ValorNovo = _DirImportacao; }
                if (_LogDirExportacaoExcel != null) { _LogDirExportacaoExcel.ValorNovo = _DirExportacaoExcel; }
                if (_LogCodTipoProcessoEsp != null) { _LogCodTipoProcessoEsp.ValorNovo = _IdTipoProcEsp; }
                if (_LogCodTipoProcessoInt != null) { _LogCodTipoProcessoInt.ValorNovo = _IdTipoProcessoInt; }
                if (_LogMostraFormMenu != null) { _LogMostraFormMenu.ValorNovo = _MostraFormMenu; }
                if (_LogDirFoto != null) { _LogDirFoto.ValorNovo = _DirFoto; }
                if (_LogServidor != null) { _LogServidor.ValorNovo = _DirServidor; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogIdTabela);
                _ChangeItems.Add(_LogDirLogoEmpresa);
                _ChangeItems.Add(_LogDirPmgRelatorio);
                _ChangeItems.Add(_LogDirRelatorio);
                _ChangeItems.Add(_LogDirBackup);
                _ChangeItems.Add(_LogDirScript);
                _ChangeItems.Add(_LogDirImportacao);
                _ChangeItems.Add(_LogCodTipoProcessoEsp);
                _ChangeItems.Add(_LogCodTipoProcessoInt);
                _ChangeItems.Add(_LogDirExportacaoExcel);
                _ChangeItems.Add(_LogMostraFormMenu);
                _ChangeItems.Add(_LogDirFoto);
                _ChangeItems.Add(_LogServidor);

                #endregion

                ExecuteModifyExceptionLogParametrosGerenciador(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally 
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogIdTabela != null) { _LogIdTabela.ValorNovo = _IdTabela; }
                    if (_LogDirLogoEmpresa != null) { _LogDirLogoEmpresa.ValorNovo = _DirLogoEmpresa; }
                    if (_LogDirPmgRelatorio != null) { _LogDirPmgRelatorio.ValorNovo = _DirPgmRelatorio; }
                    if (_LogDirRelatorio != null) { _LogDirRelatorio.ValorNovo = _DirRelatorio; }
                    if (_LogDirBackup != null) { _LogDirBackup.ValorNovo = _DirBackup; }
                    if (_LogDirScript != null) { _LogDirScript.ValorNovo = _DirScript; }
                    if (_LogDirImportacao != null) { _LogDirImportacao.ValorNovo = _DirImportacao; }
                    if (_LogDirExportacaoExcel != null) { _LogDirExportacaoExcel.ValorNovo = _DirExportacaoExcel; }
                    if (_LogCodTipoProcessoEsp != null) { _LogCodTipoProcessoEsp.ValorNovo = _IdTipoProcEsp; }
                    if (_LogCodTipoProcessoInt != null) { _LogCodTipoProcessoInt.ValorNovo = _IdTipoProcessoInt; }
                    if (_LogMostraFormMenu != null) { _LogMostraFormMenu.ValorNovo = _MostraFormMenu; }
                    if (_LogDirFoto != null) { _LogDirFoto.ValorNovo = _DirFoto; }
                    if (_LogServidor != null) { _LogServidor.ValorNovo = _DirServidor; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogIdTabela);
                    _ChangeItems.Add(_LogDirLogoEmpresa);
                    _ChangeItems.Add(_LogDirPmgRelatorio);
                    _ChangeItems.Add(_LogDirRelatorio);
                    _ChangeItems.Add(_LogDirBackup);
                    _ChangeItems.Add(_LogDirScript);
                    _ChangeItems.Add(_LogDirImportacao);
                    _ChangeItems.Add(_LogCodTipoProcessoEsp);
                    _ChangeItems.Add(_LogCodTipoProcessoInt);
                    _ChangeItems.Add(_LogDirExportacaoExcel);
                    _ChangeItems.Add(_LogMostraFormMenu);
                    _ChangeItems.Add(_LogDirFoto);
                    _ChangeItems.Add(_LogServidor);

                    #endregion

                    ExecuteModifyLogParametrosGerenciador(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void ExecuteUpdateDataParametroGerenciador() 
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnUpdate_Click";
            int _IdTipoProcessoInt = 0;
            int _IdTabela = 0;
            int _IdTipoProcEsp = 0;
            string _DirLogoEmpresa = string.Empty;
            string _DirPgmRelatorio = string.Empty;
            string _DirRelatorio = string.Empty;
            string _DirBackup = string.Empty;
            string _DirScript = string.Empty;
            string _DirImportacao = string.Empty;
            string _DirExportacaoExcel = string.Empty;
            string _MostraFormMenu = string.Empty;
            string _DirFoto = string.Empty;
            string _DirServidor = string.Empty;

            string _ModifyType = string.Empty;
            string _MostraMenu = string.Empty;
            int _IdTipoProcInt = 0;

            try
            {
                _ModifyType = ManagementParameterProcess.CreateInstance.FromToModificaParametroGerenciador(ModificaParametroGerenciadorType.ParametroGerenciadorAlterar);
                _MostraMenu = chkMstrOpcMenu.Checked ? "S" : "N";
                _IdTipoProcEsp = Convert.ToInt32(cmbBoxTpProcEsp.SelectedValue);
                _IdTipoProcInt = Convert.ToInt32(cmbBoxTpOpcInt.SelectedValue);

                ManagementParameterProcess.CreateInstance.TaskModifyDataProcesses(IdTabela, txtLogEmp.Text, txtDirPGMRel.Text, txtlDirRel.Text, txtlDirBackup.Text, txtDirScript.Text, txtDirImport.Text, txtDirExportExcel.Text, _IdTipoProcEsp, _IdTipoProcInt, _MostraMenu, txtDirFoto.Text, txtRelServ.Text, _ModifyType);
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

                if (_LogIdTabela != null) { _LogIdTabela.ValorNovo = _IdTabela; }
                if (_LogDirLogoEmpresa != null) { _LogDirLogoEmpresa.ValorNovo = _DirLogoEmpresa; }
                if (_LogDirPmgRelatorio != null) { _LogDirPmgRelatorio.ValorNovo = _DirPgmRelatorio; }
                if (_LogDirRelatorio != null) { _LogDirRelatorio.ValorNovo = _DirRelatorio; }
                if (_LogDirBackup != null) { _LogDirBackup.ValorNovo = _DirBackup; }
                if (_LogDirScript != null) { _LogDirScript.ValorNovo = _DirScript; }
                if (_LogDirImportacao != null) { _LogDirImportacao.ValorNovo = _DirImportacao; }
                if (_LogDirExportacaoExcel != null) { _LogDirExportacaoExcel.ValorNovo = _DirExportacaoExcel; }
                if (_LogCodTipoProcessoEsp != null) { _LogCodTipoProcessoEsp.ValorNovo = _IdTipoProcEsp; }
                if (_LogCodTipoProcessoInt != null) { _LogCodTipoProcessoInt.ValorNovo = _IdTipoProcessoInt; }
                if (_LogMostraFormMenu != null) { _LogMostraFormMenu.ValorNovo = _MostraFormMenu; }
                if (_LogDirFoto != null) { _LogDirFoto.ValorNovo = _DirFoto; }
                if (_LogServidor != null) { _LogServidor.ValorNovo = _DirServidor; }

                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogIdTabela);
                _ChangeItems.Add(_LogDirLogoEmpresa);
                _ChangeItems.Add(_LogDirPmgRelatorio);
                _ChangeItems.Add(_LogDirRelatorio);
                _ChangeItems.Add(_LogDirBackup);
                _ChangeItems.Add(_LogDirScript);
                _ChangeItems.Add(_LogDirImportacao);
                _ChangeItems.Add(_LogCodTipoProcessoEsp);
                _ChangeItems.Add(_LogCodTipoProcessoInt);
                _ChangeItems.Add(_LogDirExportacaoExcel);
                _ChangeItems.Add(_LogMostraFormMenu);
                _ChangeItems.Add(_LogDirFoto);
                _ChangeItems.Add(_LogServidor);

                #endregion

                ExecuteModifyExceptionLogParametrosGerenciador(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {
                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogIdTabela != null) { _LogIdTabela.ValorNovo = _IdTabela; }
                    if (_LogDirLogoEmpresa != null) { _LogDirLogoEmpresa.ValorNovo = _DirLogoEmpresa; }
                    if (_LogDirPmgRelatorio != null) { _LogDirPmgRelatorio.ValorNovo = _DirPgmRelatorio; }
                    if (_LogDirRelatorio != null) { _LogDirRelatorio.ValorNovo = _DirRelatorio; }
                    if (_LogDirBackup != null) { _LogDirBackup.ValorNovo = _DirBackup; }
                    if (_LogDirScript != null) { _LogDirScript.ValorNovo = _DirScript; }
                    if (_LogDirImportacao != null) { _LogDirImportacao.ValorNovo = _DirImportacao; }
                    if (_LogDirExportacaoExcel != null) { _LogDirExportacaoExcel.ValorNovo = _DirExportacaoExcel; }
                    if (_LogCodTipoProcessoEsp != null) { _LogCodTipoProcessoEsp.ValorNovo = _IdTipoProcEsp; }
                    if (_LogCodTipoProcessoInt != null) { _LogCodTipoProcessoInt.ValorNovo = _IdTipoProcessoInt; }
                    if (_LogMostraFormMenu != null) { _LogMostraFormMenu.ValorNovo = _MostraFormMenu; }
                    if (_LogDirFoto != null) { _LogDirFoto.ValorNovo = _DirFoto; }
                    if (_LogServidor != null) { _LogServidor.ValorNovo = _DirServidor; }

                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogIdTabela);
                    _ChangeItems.Add(_LogDirLogoEmpresa);
                    _ChangeItems.Add(_LogDirPmgRelatorio);
                    _ChangeItems.Add(_LogDirRelatorio);
                    _ChangeItems.Add(_LogDirBackup);
                    _ChangeItems.Add(_LogDirScript);
                    _ChangeItems.Add(_LogDirImportacao);
                    _ChangeItems.Add(_LogCodTipoProcessoEsp);
                    _ChangeItems.Add(_LogCodTipoProcessoInt);
                    _ChangeItems.Add(_LogDirExportacaoExcel);
                    _ChangeItems.Add(_LogMostraFormMenu);
                    _ChangeItems.Add(_LogDirFoto);
                    _ChangeItems.Add(_LogServidor);

                    #endregion

                    ExecuteModifyLogParametrosGerenciador(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void ExecuteModifyLogParametrosGerenciador(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }

        private void ExecuteModifyExceptionLogParametrosGerenciador(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void FillLogHeaderFromUpdateModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboGeParametroGerenciador.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdEmpr;
            _ChangesHeader.TipoModificacao = ManagementParameterProcess.CreateInstance.FromToModificaParametroGerenciador(ModificaParametroGerenciadorType.ParametroGerenciadorAlterar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Id Tabela
            _LogIdTabela = new ChangeItem();
            _LogIdTabela.IdChangeHeader = _ChangesHeader.Id;
            _LogIdTabela.IdItem = 1;
            _LogIdTabela.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogIdTabela.NomeCampo = DboGeParametroGerenciador.NomeIdTabela;
            _LogIdTabela.ValorAntigo = IdTabela;

            //Logo Empresa
            _LogDirLogoEmpresa = new ChangeItem();
            _LogDirLogoEmpresa.IdChangeHeader = _ChangesHeader.Id;
            _LogDirLogoEmpresa.IdItem = 2;
            _LogDirLogoEmpresa.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirLogoEmpresa.NomeCampo = DboGeParametroGerenciador.NomeDirLogoEmpresa;
            _LogDirLogoEmpresa.ValorAntigo = DirLogoEmpresa;

            //Diretorio Pgm Relatório
            _LogDirPmgRelatorio = new ChangeItem();
            _LogDirPmgRelatorio.IdChangeHeader = _ChangesHeader.Id;
            _LogDirPmgRelatorio.IdItem = 3;
            _LogDirPmgRelatorio.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirPmgRelatorio.NomeCampo = DboGeParametroGerenciador.NomeDirPgmRelatorio;
            _LogDirPmgRelatorio.ValorAntigo = DirPgmRelatorio;

            //Diretorio Relatorio
            _LogDirRelatorio = new ChangeItem();
            _LogDirRelatorio.IdChangeHeader = _ChangesHeader.Id;
            _LogDirRelatorio.IdItem = 4;
            _LogDirRelatorio.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirRelatorio.NomeCampo = DboGeParametroGerenciador.NomeDirRelatorio;
            _LogDirRelatorio.ValorAntigo = DirRelatorio;

            //Diretório Backup
            _LogDirBackup = new ChangeItem();
            _LogDirBackup.IdChangeHeader = _ChangesHeader.Id;
            _LogDirBackup.IdItem = 5;
            _LogDirBackup.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirBackup.NomeCampo = DboGeParametroGerenciador.NomeDirBackup;
            _LogDirBackup.ValorAntigo = DirBackup;

            //Diretório Script
            _LogDirScript = new ChangeItem();
            _LogDirScript.IdChangeHeader = _ChangesHeader.Id;
            _LogDirScript.IdItem = 6;
            _LogDirScript.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirScript.NomeCampo = DboGeParametroGerenciador.NomeDirScript;
            _LogDirScript.ValorAntigo = DirScript;

            //Diretório Importação
            _LogDirImportacao = new ChangeItem();
            _LogDirImportacao.IdChangeHeader = _ChangesHeader.Id;
            _LogDirImportacao.IdItem = 7;
            _LogDirImportacao.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirImportacao.NomeCampo = DboGeParametroGerenciador.NomeDirImportacao;
            _LogDirImportacao.ValorAntigo = DirImportacao;

            //Codigo Tipo Processo Esp
            _LogCodTipoProcessoEsp = new ChangeItem();
            _LogCodTipoProcessoEsp.IdChangeHeader = _ChangesHeader.Id;
            _LogCodTipoProcessoEsp.IdItem = 8;
            _LogCodTipoProcessoEsp.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogCodTipoProcessoEsp.NomeCampo = DboGeParametroGerenciador.NomeCodTipoProcessoEsp;
            _LogCodTipoProcessoEsp.ValorAntigo = IdTipoProcEsp;

            //Codigo Tipo Processo Int
            _LogCodTipoProcessoInt = new ChangeItem();
            _LogCodTipoProcessoInt.IdChangeHeader = _ChangesHeader.Id;
            _LogCodTipoProcessoInt.IdItem = 9;
            _LogCodTipoProcessoInt.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogCodTipoProcessoInt.NomeCampo = DboGeParametroGerenciador.NomeCodTipoProcessoInt;
            _LogCodTipoProcessoInt.ValorAntigo = IdTipoProcInt;

            //Dirretorio Excel Exportação
            _LogDirExportacaoExcel = new ChangeItem();
            _LogDirExportacaoExcel.IdChangeHeader = _ChangesHeader.Id;
            _LogDirExportacaoExcel.IdItem = 10;
            _LogDirExportacaoExcel.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirExportacaoExcel.NomeCampo = DboGeParametroGerenciador.NomeDirExportacaoExcel;
            _LogDirExportacaoExcel.ValorAntigo = DirExportacaoExcel;

            //Mostra Formulario Menu
            _LogMostraFormMenu = new ChangeItem();
            _LogMostraFormMenu.IdChangeHeader = _ChangesHeader.Id;
            _LogMostraFormMenu.IdItem = 11;
            _LogMostraFormMenu.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogMostraFormMenu.NomeCampo = DboGeParametroGerenciador.NomeMostraFormMenu;
            _LogMostraFormMenu.ValorAntigo = MostraFormMenu;

            //Diretório Foto
            _LogDirFoto = new ChangeItem();
            _LogDirFoto.IdChangeHeader = _ChangesHeader.Id;
            _LogDirFoto.IdItem = 12;
            _LogDirFoto.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirFoto.NomeCampo = DboGeParametroGerenciador.NomeDirFoto;
            _LogDirFoto.ValorAntigo = DirFoto;

            //Diretório Servidor
            _LogServidor = new ChangeItem();
            _LogServidor.IdChangeHeader = _ChangesHeader.Id;
            _LogServidor.IdItem = 13;
            _LogServidor.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogServidor.NomeCampo = DboGeParametroGerenciador.NomeDirServidor;
            _LogServidor.ValorAntigo = DirServidor;

            #endregion
        }

        private void FillLogHeaderFromAddModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboGeParametroGerenciador.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdEmpr;
            _ChangesHeader.TipoModificacao = ManagementParameterProcess.CreateInstance.FromToModificaParametroGerenciador(ModificaParametroGerenciadorType.ParametroGerenciadorAlterar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Id Tabela
            _LogIdTabela = new ChangeItem();
            _LogIdTabela.IdChangeHeader = _ChangesHeader.Id;
            _LogIdTabela.IdItem = 1;
            _LogIdTabela.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogIdTabela.NomeCampo = DboGeParametroGerenciador.NomeIdTabela;
            //_LogIdTabela.ValorAntigo = IdTabela;

            //Logo Empresa
            _LogDirLogoEmpresa = new ChangeItem();
            _LogDirLogoEmpresa.IdChangeHeader = _ChangesHeader.Id;
            _LogDirLogoEmpresa.IdItem = 2;
            _LogDirLogoEmpresa.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirLogoEmpresa.NomeCampo = DboGeParametroGerenciador.NomeDirLogoEmpresa;
            //_LogDirLogoEmpresa.ValorAntigo = DirLogoEmpresa;

            //Diretorio Pgm Relatório
            _LogDirPmgRelatorio = new ChangeItem();
            _LogDirPmgRelatorio.IdChangeHeader = _ChangesHeader.Id;
            _LogDirPmgRelatorio.IdItem = 3;
            _LogDirPmgRelatorio.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirPmgRelatorio.NomeCampo = DboGeParametroGerenciador.NomeDirPgmRelatorio;
            //_LogDirPmgRelatorio.ValorAntigo = DirPgmRelatorio;

            //Diretorio Relatorio
            _LogDirRelatorio = new ChangeItem();
            _LogDirRelatorio.IdChangeHeader = _ChangesHeader.Id;
            _LogDirRelatorio.IdItem = 4;
            _LogDirRelatorio.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirRelatorio.NomeCampo = DboGeParametroGerenciador.NomeDirRelatorio;
            //_LogDirRelatorio.ValorAntigo = DirRelatorio;

            //Diretório Backup
            _LogDirBackup = new ChangeItem();
            _LogDirBackup.IdChangeHeader = _ChangesHeader.Id;
            _LogDirBackup.IdItem = 5;
            _LogDirBackup.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirBackup.NomeCampo = DboGeParametroGerenciador.NomeDirBackup;
            _LogDirBackup.ValorAntigo = DirBackup;

            //Diretório Script
            _LogDirScript = new ChangeItem();
            _LogDirScript.IdChangeHeader = _ChangesHeader.Id;
            _LogDirScript.IdItem = 6;
            _LogDirScript.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirScript.NomeCampo = DboGeParametroGerenciador.NomeDirScript;
            //_LogDirScript.ValorAntigo = DirScript;

            //Diretório Importação
            _LogDirImportacao = new ChangeItem();
            _LogDirImportacao.IdChangeHeader = _ChangesHeader.Id;
            _LogDirImportacao.IdItem = 7;
            _LogDirImportacao.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirImportacao.NomeCampo = DboGeParametroGerenciador.NomeDirImportacao;
            //_LogDirImportacao.ValorAntigo = DirImportacao;

            //Codigo Tipo Processo Esp
            _LogCodTipoProcessoEsp = new ChangeItem();
            _LogCodTipoProcessoEsp.IdChangeHeader = _ChangesHeader.Id;
            _LogCodTipoProcessoEsp.IdItem = 8;
            _LogCodTipoProcessoEsp.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogCodTipoProcessoEsp.NomeCampo = DboGeParametroGerenciador.NomeCodTipoProcessoEsp;
            //_LogCodTipoProcessoEsp.ValorAntigo = IdTipoProcEsp;

            //Codigo Tipo Processo Int
            _LogCodTipoProcessoInt = new ChangeItem();
            _LogCodTipoProcessoInt.IdChangeHeader = _ChangesHeader.Id;
            _LogCodTipoProcessoInt.IdItem = 9;
            _LogCodTipoProcessoInt.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogCodTipoProcessoInt.NomeCampo = DboGeParametroGerenciador.NomeCodTipoProcessoInt;
            //_LogCodTipoProcessoInt.ValorAntigo = IdTipoProcInt;

            //Dirretorio Excel Exportação
            _LogDirExportacaoExcel = new ChangeItem();
            _LogDirExportacaoExcel.IdChangeHeader = _ChangesHeader.Id;
            _LogDirExportacaoExcel.IdItem = 10;
            _LogDirExportacaoExcel.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirExportacaoExcel.NomeCampo = DboGeParametroGerenciador.NomeDirExportacaoExcel;
            //_LogDirExportacaoExcel.ValorAntigo = DirExportacaoExcel;

            //Mostra Formulario Menu
            _LogMostraFormMenu = new ChangeItem();
            _LogMostraFormMenu.IdChangeHeader = _ChangesHeader.Id;
            _LogMostraFormMenu.IdItem = 11;
            _LogMostraFormMenu.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogMostraFormMenu.NomeCampo = DboGeParametroGerenciador.NomeMostraFormMenu;
            //_LogMostraFormMenu.ValorAntigo = MostraFormMenu;

            //Diretório Foto
            _LogDirFoto = new ChangeItem();
            _LogDirFoto.IdChangeHeader = _ChangesHeader.Id;
            _LogDirFoto.IdItem = 12;
            _LogDirFoto.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirFoto.NomeCampo = DboGeParametroGerenciador.NomeDirFoto;
            //_LogDirFoto.ValorAntigo = DirFoto;

            //Diretório Servidor
            _LogServidor = new ChangeItem();
            _LogServidor.IdChangeHeader = _ChangesHeader.Id;
            _LogServidor.IdItem = 13;
            _LogServidor.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogServidor.NomeCampo = DboGeParametroGerenciador.NomeDirServidor;
            //_LogServidor.ValorAntigo = DirServidor;
            
            #endregion
        }
        private void tlstrpActionMenuBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateFormParametroGerenciador_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;

            if (ModificaParametroGerenciadorType == ModificaParametroGerenciadorType.ParametroGerenciadorAlterar)
            {
                FillLogHeaderFromUpdateModify();
                FillDataParametersToExecuteUpdateModify();
            }

            if (ModificaParametroGerenciadorType == ModificaParametroGerenciadorType.ParametroGerenciadorAdicionar) 
            {
                FillLogHeaderFromAddModify();
                FillDataParametersToExecuteAddModify();
            }
        }

        private void btnDirBackup_Click(object sender, EventArgs e)
        {
            this.txtlDirBackup.Text = UserInterfaceWin.CreateInstance.SaveDirectoryPath();
        }
    }

    internal static class DboGeParametroGerenciador
    {
        #region ...::: Private Constantes :::...

        private const string _NomeIdTabela = "id_tabela";
        private const string _NomeDirLogoEmpresa = "dir_logo_empresa";
        private const string _NomeDirPgmRelatorio = "dir_pgm_relatorio";
        private const string _NomeDirRelatorio = "dir_relatorio";
        private const string _NomeDirBackup = "dir_backup";
        private const string _NomeDirScript = "dir_script";
        private const string _NomeDirImportacao = "dir_importacao";
        private const string _NomeDirExportacaoExcel = "dir_exportacao_excel";
        private const string _NomeCodTipoProcessoEsp = "cod_tipo_proc_esp";
        private const string _NomeCodTipoProcessoInt = "cod_tipo_proc_int";
        private const string _NomeMostraFormMenu = "mostra_form_menu";
        private const string _NomeDirFoto = "dir_foto";
        private const string _NomeDirServidor = "dir_servidor";

        private const string _NomeTabela = "ge_parametro";
        private const string _NomeProcesso = "Parametros Gerenciador";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeIdTabela { get { return _NomeIdTabela; } }
        public static string NomeDirLogoEmpresa { get { return _NomeDirLogoEmpresa; } }
        public static string NomeDirPgmRelatorio { get { return _NomeDirPgmRelatorio; } }
        public static string NomeDirRelatorio { get { return _NomeDirRelatorio; } }
        public static string NomeDirBackup { get { return _NomeDirBackup; } }
        public static string NomeDirScript { get { return _NomeDirScript; } }
        public static string NomeDirImportacao { get { return _NomeDirImportacao; } }
        public static string NomeDirExportacaoExcel { get { return _NomeDirExportacaoExcel; } }
        public static string NomeCodTipoProcessoEsp { get { return _NomeCodTipoProcessoEsp; } }
        public static string NomeCodTipoProcessoInt { get { return _NomeCodTipoProcessoInt; } }
        public static string NomeMostraFormMenu { get { return _NomeMostraFormMenu; } }
        public static string NomeDirFoto { get { return _NomeDirFoto; } }
        public static string NomeDirServidor { get { return _NomeDirServidor; } }


        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
