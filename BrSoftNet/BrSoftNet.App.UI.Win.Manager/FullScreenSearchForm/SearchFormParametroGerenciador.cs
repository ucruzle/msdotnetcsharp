using BrSoftNet.App.Business.Processes.Manager.Entities;
using BrSoftNet.App.Business.Processes.Manager.Enumerators;
using BrSoftNet.App.Business.Processes.Manager.Tasks;
using BrSoftNet.App.UI.Win.Manager.DialogUpdateForm;
using BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm;
using BrSoftNet.App.UI.Win.Manager.State;
using BrSoftNet.Library.Messages;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Log.Actions;
using BrSoftNet.Log.Helpers;
using BrSoftNet.Log.Structures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Manager.FullScreenSearchForm
{
    public partial class SearchFormParametroGerenciador : Form
    {
        public int IdTipoProcesso { get; set; }
        public int IdTabela { get; set; }
        public string  DirLogoEmpresa { get; set; }
        public string DirPgmRelatorio { get; set; }
        public string DirRelatorio { get; set; }
        public string DirBackup { get; set; }
        public string DirScript { get; set; }
        public string DirImportacao { get; set; }
        public string DirExportacaoExcel { get; set; }
        public int  IdTipoProcEsp { get; set; }
        public int  IdTipoProcInt { get; set; }
        public string MostraFormMenu { get; set; }
        public string DirFoto { get; set; }
        public string DirServidor { get; set; }

        #region ...::: Public Properties Dashboard :::...

        public int IdEmpresaFromDashboard { get; set; }

        public string UsuarioLoginDashboard { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;

        private ChangeItem _LogIdTabela = null;
        private ChangeItem _LogDirLogoEmpresa = null;
        private ChangeItem _LogDirPmgRelatorio = null;
        private ChangeItem _LogDirRelatorio = null;
        private ChangeItem _LogDirBackup = null;
        private ChangeItem _LogDirScript = null;
        private ChangeItem _LogDirImportacao = null;
        private ChangeItem _LogDirExportacaoExcel= null;
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

        public SearchFormParametroGerenciador()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(ManagementParameterProcess.CreateInstance.TaskGetDataProcessesByFilter(0, 0, 0, "N"));
            //Call IdTipoProcesso
        }

        private void FillDataGrid(List<ParametroGerenciador> _ParametroGerenciadorCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateManager.ParametroGerenciadorCollection = _ParametroGerenciadorCollection;

                bsParametroGerenciador.DataSource = AppStateManager.ParametroGerenciadorCollection;
                bsParametroGerenciador.AllowNew = false;

                dataGridSearchModule.DataSource = bsParametroGerenciador;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["IdTabela"].HeaderText = "ID";
                dataGridSearchModule.Columns["IdTabela"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DirLogoEmpresa"].HeaderText = "Logo Empresa";
                dataGridSearchModule.Columns["DirLogoEmpresa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DirPgmRelatorio"].HeaderText = "Diretório PMG Relatório";
                dataGridSearchModule.Columns["DirPgmRelatorio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DirRelatorio"].HeaderText = "Diretório Relatório";
                dataGridSearchModule.Columns["DirRelatorio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DirBackup"].HeaderText = "Diretório Backup";
                dataGridSearchModule.Columns["DirBackup"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DirImportacao"].HeaderText = "Diretório Importação";
                dataGridSearchModule.Columns["DirImportacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DirExportacaoExcel"].HeaderText = "Diretório Exportação Excel";
                dataGridSearchModule.Columns["DirExportacaoExcel"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["IdTipoProcEsp"].HeaderText = "Tipo Processo Especial";
                dataGridSearchModule.Columns["IdTipoProcEsp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["IdTipoProcInt"].HeaderText = "Tipo Processo Internet";
                dataGridSearchModule.Columns["IdTipoProcInt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["MostraFormMenu"].HeaderText = "Mostra Menu Formulário";
                dataGridSearchModule.Columns["MostraFormMenu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DirFoto"].HeaderText = "Diretório Foto";
                dataGridSearchModule.Columns["DirFoto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DirServidor"].HeaderText = "Diretório Servidor";
                dataGridSearchModule.Columns["DirServidor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DirScript"].HeaderText = "Diretório Script";
                dataGridSearchModule.Columns["DirScript"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AdicionaParametroGerenciador();
        }

        private void AdicionaParametroGerenciador()
        {
            UpdateFormParametroGerenciador _UpdateFormParametroGerenciador = new UpdateFormParametroGerenciador();
            _UpdateFormParametroGerenciador.ModificaParametroGerenciadorType = ModificaParametroGerenciadorType.ParametroGerenciadorAdicionar;
            _UpdateFormParametroGerenciador.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoParametroGerenciador, FormsMessages.TituloProcessoAcaoParametroGerenciadorInclusao);

            try
            {
                _UpdateFormParametroGerenciador.ShowDialog();
            }
            finally
            {
                AppStateManager.IdTabela = _UpdateFormParametroGerenciador.IdTabela;

                _UpdateFormParametroGerenciador = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(ManagementParameterProcess.CreateInstance.TaskGetDataProcessesByFilter(0, 0, 0, "N"));
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, System.EventArgs e)
        {
            AlteraParametroGerenciador();
        }

        private void AlteraParametroGerenciador()
        {
            if (dataGridSearchModule.CurrentRow.Cells["IdTabela"].Value != null)
            {
                UpdateFormParametroGerenciador _UpdateFormParametroGerenciador = new UpdateFormParametroGerenciador();
                _UpdateFormParametroGerenciador.ModificaParametroGerenciadorType = ModificaParametroGerenciadorType.ParametroGerenciadorAlterar;
                _UpdateFormParametroGerenciador.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoParametroGerenciador, FormsMessages.TituloProcessoAcaoParametroGerenciadorAlteracao);

                _UpdateFormParametroGerenciador.IdTabela = (int)dataGridSearchModule.CurrentRow.Cells["IdTabela"].Value;
                _UpdateFormParametroGerenciador.DirLogoEmpresa = (string)dataGridSearchModule.CurrentRow.Cells["DirLogoEmpresa"].Value;
                _UpdateFormParametroGerenciador.DirPgmRelatorio = (string)dataGridSearchModule.CurrentRow.Cells["DirPgmRelatorio"].Value;
                _UpdateFormParametroGerenciador.DirRelatorio = (string)dataGridSearchModule.CurrentRow.Cells["DirRelatorio"].Value;
                _UpdateFormParametroGerenciador.DirBackup = (string)dataGridSearchModule.CurrentRow.Cells["DirBackup"].Value;
                _UpdateFormParametroGerenciador.DirImportacao = (string)dataGridSearchModule.CurrentRow.Cells["DirImportacao"].Value;
                _UpdateFormParametroGerenciador.DirExportacaoExcel = (string)dataGridSearchModule.CurrentRow.Cells["DirExportacaoExcel"].Value;
                _UpdateFormParametroGerenciador.IdTipoProcEsp = (int)dataGridSearchModule.CurrentRow.Cells["IdTipoProcEsp"].Value;
                _UpdateFormParametroGerenciador.IdTipoProcInt = (int)dataGridSearchModule.CurrentRow.Cells["IdTipoProcInt"].Value;
                _UpdateFormParametroGerenciador.MostraFormMenu = (string)dataGridSearchModule.CurrentRow.Cells["MostraFormMenu"].Value;
                _UpdateFormParametroGerenciador.DirFoto = (string)dataGridSearchModule.CurrentRow.Cells["DirFoto"].Value;
                _UpdateFormParametroGerenciador.DirServidor = (string)dataGridSearchModule.CurrentRow.Cells["DirServidor"].Value;
                _UpdateFormParametroGerenciador.DirScript = (string)dataGridSearchModule.CurrentRow.Cells["DirScript"].Value;

                try
                {
                    _UpdateFormParametroGerenciador.ShowDialog();
                }
                finally
                {
                    AppStateManager.IdTabela = _UpdateFormParametroGerenciador.IdTabela;

                    _UpdateFormParametroGerenciador = null;

                    dataGridSearchModule.DataSource = null;

                    FillDataGrid(ManagementParameterProcess.CreateInstance.TaskGetDataProcessesByFilter(0, 0, 0, "N"));
                }
            }
        }

        private void tlstrpBtnDelete_Click(object sender, System.EventArgs e)
        {
            ExcluiParametroGerenciador();
        }

        private void ExcluiParametroGerenciador()
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnDelete_Click";
            int _IdTipoProcessoInt = 0;
            int _IdTabela = 0;
            int _IdTipoProcEsp = 0;
            string _DirLogoEmpresa = string.Empty;
            string _DirPgmRelatorio =string.Empty;
            string _DirRelatorio = string.Empty;
            string _DirBackup = string.Empty;
            string _DirScript = string.Empty;
            string _DirImportacao = string.Empty;
            string _DirExportacaoExcel = string.Empty;
            string _MostraFormMenu = string.Empty;
            string _DirFoto = string.Empty;
            string _DirServidor = string.Empty;

            string _ModifyType = string.Empty;

            if (dataGridSearchModule.CurrentRow.Cells["IdTabela"].Value != null)
            {
                if (MessageBox.Show("Deseja excluir este registro?",
                                    UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoParametroGerenciador, FormsMessages.TituloProcessoAcaoParametroGerenciadorExclusao),
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (_ThrowingException != null) { _ThrowingException = null; }
                        _IdTabela = (int)dataGridSearchModule.CurrentRow.Cells["IdTabela"].Value;
                        _IdTipoProcEsp = (int)dataGridSearchModule.CurrentRow.Cells["IdTipoProcEsp"].Value;
                        _IdTipoProcessoInt = (int)dataGridSearchModule.CurrentRow.Cells["IdTipoProcInt"].Value;
                        _DirLogoEmpresa = (string)dataGridSearchModule.CurrentRow.Cells["DirLogoEmpresa"].Value;
                        _DirRelatorio = (string)dataGridSearchModule.CurrentRow.Cells["DirRelatorio"].Value;
                        _DirPgmRelatorio = (string)dataGridSearchModule.CurrentRow.Cells["DirPgmRelatorio"].Value;
                        _DirBackup = (string)dataGridSearchModule.CurrentRow.Cells["DirBackup"].Value;
                        _DirScript = (string)dataGridSearchModule.CurrentRow.Cells["DirScript"].Value;
                        _DirImportacao = (string)dataGridSearchModule.CurrentRow.Cells["DirImportacao"].Value;
                        _DirExportacaoExcel = (string)dataGridSearchModule.CurrentRow.Cells["DirExportacaoExcel"].Value;
                        _MostraFormMenu = (string)dataGridSearchModule.CurrentRow.Cells["MostraFormMenu"].Value;
                        _DirFoto = (string)dataGridSearchModule.CurrentRow.Cells["DirFoto"].Value;
                        _DirServidor = (string)dataGridSearchModule.CurrentRow.Cells["DirServidor"].Value;
                        _ModifyType = ManagementParameterProcess.CreateInstance.FromToModificaParametroGerenciador(ModificaParametroGerenciadorType.ParametroGerenciadorExcluir);
                        FillLogHeaderFromDeleteModify(_IdTabela, _DirLogoEmpresa, _DirPgmRelatorio, _DirRelatorio, _DirBackup, _DirScript, _DirImportacao, _IdTipoProcEsp, _IdTipoProcessoInt, _DirExportacaoExcel, _MostraFormMenu, _DirFoto, _DirServidor);
                        ManagementParameterProcess.CreateInstance.TaskModifyDataProcesses(IdTabela, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, 0, string.Empty, string.Empty, string.Empty, _ModifyType);
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

                        if (_LogIdTabela != null) { _LogIdTabela.ValorNovo = _IdTabela ; }
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
                        dataGridSearchModule.DataSource = null;

                        FillDataGrid(ManagementParameterProcess.CreateInstance.TaskGetDataProcessesByFilter(0, 0, 0, "N"));

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

        private void FillLogHeaderFromDeleteModify(int _IdTabela, string _DirLogoEmpresa, string _DirPgmRelatorio, string _DirRelatorio, string _DirBackup,
                                                   string _DirScript, string _DirImportacao, int _CodTipoProcessoEsp, int _CodTipoProcessoInt, string _DirExportacaoExcel,
                                                   string _MostraFormMenu, string _DirFoto, string _Servidor)
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboGeParametroGerenciador.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdEmpresaFromDashboard;
            _ChangesHeader.TipoModificacao = ManagementParameterProcess.CreateInstance.FromToModificaParametroGerenciador(ModificaParametroGerenciadorType.ParametroGerenciadorExcluir);
            _ChangesHeader.Usuario = this.UsuarioLoginDashboard;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Id Tabela
            _LogIdTabela = new ChangeItem();
            _LogIdTabela.IdChangeHeader = _ChangesHeader.Id;
            _LogIdTabela.IdItem = 1;
            _LogIdTabela.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogIdTabela.NomeCampo = DboGeParametroGerenciador.NomeIdTabela;
            _LogIdTabela.ValorAntigo = _IdTabela;

            //Logo Empresa
            _LogDirLogoEmpresa = new ChangeItem();
            _LogDirLogoEmpresa.IdChangeHeader = _ChangesHeader.Id;
            _LogDirLogoEmpresa.IdItem = 2;
            _LogDirLogoEmpresa.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirLogoEmpresa.NomeCampo = DboGeParametroGerenciador.NomeDirLogoEmpresa;
            _LogDirLogoEmpresa.ValorAntigo = _DirLogoEmpresa;

            //Diretorio Pgm Relatório
            _LogDirPmgRelatorio = new ChangeItem();
            _LogDirPmgRelatorio.IdChangeHeader = _ChangesHeader.Id;
            _LogDirPmgRelatorio.IdItem = 3;
            _LogDirPmgRelatorio.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirPmgRelatorio.NomeCampo = DboGeParametroGerenciador.NomeDirPgmRelatorio;
            _LogDirPmgRelatorio.ValorAntigo = _DirPgmRelatorio;
            
            //Diretorio Relatorio
            _LogDirRelatorio = new ChangeItem();
            _LogDirRelatorio.IdChangeHeader = _ChangesHeader.Id;
            _LogDirRelatorio.IdItem = 4;
            _LogDirRelatorio.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirRelatorio.NomeCampo = DboGeParametroGerenciador.NomeDirRelatorio;
            _LogDirRelatorio.ValorAntigo = _DirRelatorio;

            //Diretório Backup
            _LogDirBackup = new ChangeItem();
            _LogDirBackup.IdChangeHeader = _ChangesHeader.Id;
            _LogDirBackup.IdItem = 5;
            _LogDirBackup.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirBackup.NomeCampo = DboGeParametroGerenciador.NomeDirBackup;
            _LogDirBackup.ValorAntigo = _DirBackup;

            //Diretório Script
            _LogDirScript = new ChangeItem();
            _LogDirScript.IdChangeHeader = _ChangesHeader.Id;
            _LogDirScript.IdItem = 6;
            _LogDirScript.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirScript.NomeCampo = DboGeParametroGerenciador.NomeDirScript;
            _LogDirScript.ValorAntigo = _DirScript;

            //Diretório Importação
            _LogDirImportacao = new ChangeItem();
            _LogDirImportacao.IdChangeHeader = _ChangesHeader.Id;
            _LogDirImportacao.IdItem = 7;
            _LogDirImportacao.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirImportacao.NomeCampo = DboGeParametroGerenciador.NomeDirImportacao;
            _LogDirImportacao.ValorAntigo = _DirImportacao;

            //Codigo Tipo Processo Esp
            _LogCodTipoProcessoEsp = new ChangeItem();
            _LogCodTipoProcessoEsp.IdChangeHeader = _ChangesHeader.Id;
            _LogCodTipoProcessoEsp.IdItem = 8;
            _LogCodTipoProcessoEsp.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogCodTipoProcessoEsp.NomeCampo = DboGeParametroGerenciador.NomeCodTipoProcessoEsp;
            _LogCodTipoProcessoEsp.ValorAntigo = _CodTipoProcessoEsp;

            //Codigo Tipo Processo Int
            _LogCodTipoProcessoInt = new ChangeItem();
            _LogCodTipoProcessoInt.IdChangeHeader = _ChangesHeader.Id;
            _LogCodTipoProcessoInt.IdItem = 9;
            _LogCodTipoProcessoInt.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogCodTipoProcessoInt.NomeCampo = DboGeParametroGerenciador.NomeCodTipoProcessoInt;
            _LogCodTipoProcessoInt.ValorAntigo = _CodTipoProcessoInt;

            //Dirretorio Excel Exportação
            _LogDirExportacaoExcel = new ChangeItem();
            _LogDirExportacaoExcel.IdChangeHeader = _ChangesHeader.Id;
            _LogDirExportacaoExcel.IdItem = 10;
            _LogDirExportacaoExcel.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirExportacaoExcel.NomeCampo = DboGeParametroGerenciador.NomeDirExportacaoExcel;
            _LogDirExportacaoExcel.ValorAntigo = _DirExportacaoExcel;

            //Mostra Formulario Menu
            _LogMostraFormMenu = new ChangeItem();
            _LogMostraFormMenu.IdChangeHeader = _ChangesHeader.Id;
            _LogMostraFormMenu.IdItem = 11;
            _LogMostraFormMenu.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogMostraFormMenu.NomeCampo = DboGeParametroGerenciador.NomeMostraFormMenu;
            _LogMostraFormMenu.ValorAntigo = _MostraFormMenu;

            //Diretório Foto
            _LogDirFoto = new ChangeItem();
            _LogDirFoto.IdChangeHeader = _ChangesHeader.Id;
            _LogDirFoto.IdItem = 12;
            _LogDirFoto.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogDirFoto.NomeCampo = DboGeParametroGerenciador.NomeDirFoto;
            _LogDirFoto.ValorAntigo = _DirFoto;

            //Diretório Servidor
            _LogServidor = new ChangeItem();
            _LogServidor.IdChangeHeader = _ChangesHeader.Id;
            _LogServidor.IdItem = 13;
            _LogServidor.NomeTabela = DboGeParametroGerenciador.NomeTabela;
            _LogServidor.NomeCampo = DboGeParametroGerenciador.NomeDirServidor;
            _LogServidor.ValorAntigo = _Servidor;

            #endregion
        }

        private void tlstrpBtnFirst_Click(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsParametroGerenciador.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsParametroGerenciador.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsParametroGerenciador.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsParametroGerenciador.MoveLast();
            }
        }

        private void tlstrpBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                AlteraParametroGerenciador();
            }
        }

        private void tlstrpBtnSearchCriteria_Click(object sender, EventArgs e)
        {
            int _SearchType = 0;
            int _IdTipoProcessoEspecial = 0;
            int _IdTipoProcessoInternet = 0;
            int _IdTabela = 0;
            FilterSearchFormParametroGerenciador _FilterSearchFormParametroGerenciador = null;

            if (dataGridSearchModule.DataSource != null)
            {
                try
                {
                    _FilterSearchFormParametroGerenciador = new FilterSearchFormParametroGerenciador();
                    _FilterSearchFormParametroGerenciador.ShowDialog();
                }
                finally 
                {
                    _SearchType = _FilterSearchFormParametroGerenciador.SearchType;

                    switch (_SearchType)
                    {
                        case 0:
                            dataGridSearchModule.DataSource = null;
                            _IdTabela = _FilterSearchFormParametroGerenciador.IdTabela;
                            FillDataGrid(ManagementParameterProcess.CreateInstance.TaskGetDataProcessesByFilter(_IdTabela, 0, 0, "C"));
                            break;
                        case 1:
                            dataGridSearchModule.DataSource = null;
                            _IdTipoProcessoEspecial = _FilterSearchFormParametroGerenciador.IdTipoProcessoEspecial;
                            FillDataGrid(ManagementParameterProcess.CreateInstance.TaskGetDataProcessesByFilter(0, _IdTipoProcessoEspecial, 0, "E"));
                            break;
                        case 2:
                            dataGridSearchModule.DataSource = null;
                            _IdTipoProcessoInternet = _FilterSearchFormParametroGerenciador.IdTipoProcessoInternet;
                            FillDataGrid(ManagementParameterProcess.CreateInstance.TaskGetDataProcessesByFilter(0, 0, _IdTipoProcessoInternet, "I"));
                            break;
                    }

                    _FilterSearchFormParametroGerenciador.Dispose();
                }
            }
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, EventArgs e)
        {
            dataGridSearchModule.DataSource = null;
            FillDataGrid(ManagementParameterProcess.CreateInstance.TaskGetDataProcessesByFilter(0, 0, 0, "N"));
        }

        private void SearchFormParametroGerenciador_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
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
