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
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Manager.FullScreenSearchForm
{
    public partial class SearchFormEmpresa : Form
    {
        #region ...::: Private Variable :::...

        private int _CodigoEmpresa = 0;
        private string _DescricaoEmpresa = string.Empty;
        private string _DescricaoEmpresaRed = string.Empty;
        private int _CodigoEmpresaConsolidada = 0;
        private string _Ativa = string.Empty;
        private int _CodigoRg = 0;
        private string _Host = string.Empty;
        private int _Port = 0;
        private string _Username = string.Empty;
        private string _Senha = string.Empty;
        private string _Email = string.Empty;
        private string _EnderecoBanco = string.Empty;
        private string _Versao = string.Empty;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpresaFromDashboard { get; set; }

        public string UsuarioLoginDashboard { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }
        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;

        private ChangeItem _LogCodigoEmpresa = null;
        private ChangeItem _LogDescricaoEmpresa = null;
        private ChangeItem _LogDescricaoEmpresaRed = null;
        private ChangeItem _LogCodigoEmpresaConsolidada = null;
        private ChangeItem _LogAtiva = null;
        private ChangeItem _LogCodigoRg = null;
        private ChangeItem _LogHost = null;
        private ChangeItem _LogPort = null;
        private ChangeItem _LogUsername = null;
        private ChangeItem _LogSenha = null;
        private ChangeItem _LogEmail = null;
        private ChangeItem _LogEnderecoBanco = null;
        private ChangeItem _LogVersao = null;

        private List<ChangeItem> _ChangeItems = null;
        private ThrowingException _ThrowingException = null;

        private string _IdExcepitionLog = string.Empty;
        private string _MenssageLogError = string.Empty;

        #endregion

        public SearchFormEmpresa()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(EmpresaProcess.CreateInstance.TaskGetCollectionGeEmpresaByFilter("", 0));
        }

        private void FillDataGrid(List<GeEmpresa> _GeEmpresaCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateManager.GeEmpresaCollection = _GeEmpresaCollection;

                bsGeEmpresa.DataSource = AppStateManager.GeEmpresaCollection;
                bsGeEmpresa.AllowNew = false;

                dataGridSearchModule.DataSource = bsGeEmpresa;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["CodigoEmpresa"].HeaderText = "Empresa";
                dataGridSearchModule.Columns["CodigoEmpresa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescricaoEmpresa"].HeaderText = "Descrição";
                dataGridSearchModule.Columns["DescricaoEmpresa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescricaoEmpresaRed"].HeaderText = "Descrição Red";
                dataGridSearchModule.Columns["DescricaoEmpresaRed"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoEmpresaConsolidada"].HeaderText = "Empresa Consolidada";
                dataGridSearchModule.Columns["CodigoEmpresaConsolidada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["Ativa"].HeaderText = "Ativa";
                dataGridSearchModule.Columns["Ativa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoRg"].HeaderText = "Reg. Geral";
                dataGridSearchModule.Columns["CodigoRg"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["Host"].HeaderText = "Host";
                dataGridSearchModule.Columns["Host"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["Port"].HeaderText = "Port";
                dataGridSearchModule.Columns["Port"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["Username"].HeaderText = "Username";
                dataGridSearchModule.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["Senha"].HeaderText = "Senha";
                dataGridSearchModule.Columns["Senha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["Email"].HeaderText = "Email";
                dataGridSearchModule.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["EnderecoBanco"].HeaderText = "EnderecoBanco";
                dataGridSearchModule.Columns["EnderecoBanco"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["Versao"].HeaderText = "Versao";
                dataGridSearchModule.Columns["Versao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void tlstrpBtnFirst_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeEmpresa.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeEmpresa.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeEmpresa.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeEmpresa.MoveLast();
            }
        }

        private void tlstrpBtnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        }

        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AdicionaGeEmpresa();
        }

        private void AdicionaGeEmpresa()
        {
            UpdateFormEmpresa _UpdateFormEmpresa = new UpdateFormEmpresa();
            _UpdateFormEmpresa.ModificaEmpresaType = ModificaEmpresaType.EmpresaAdicionar;
            _UpdateFormEmpresa.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormEmpresa.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormEmpresa.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoEmpresa, FormsMessages.TituloProcessoAcaoEmpresaInclusao);

            try
            {
                _UpdateFormEmpresa.ShowDialog();
            }
            finally
            {
                _UpdateFormEmpresa = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(EmpresaProcess.CreateInstance.TaskGetCollectionGeEmpresaByFilter("", 0));
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, System.EventArgs e)
        {
            AlteraGeEmpresa();
        }

        private void AlteraGeEmpresa()
        {
            string _Filter = string.Empty;

            UpdateFormEmpresa _UpdateFormEmpresa = new UpdateFormEmpresa();
            _UpdateFormEmpresa.ModificaEmpresaType = ModificaEmpresaType.EmpresaAlterar;
            _UpdateFormEmpresa.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormEmpresa.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormEmpresa.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoEmpresa, FormsMessages.TituloProcessoAcaoEmpresaAlteracao);

            _CodigoEmpresa = (int)dataGridSearchModule.CurrentRow.Cells["CodigoEmpresa"].Value;
            _DescricaoEmpresa = (string)dataGridSearchModule.CurrentRow.Cells["DescricaoEmpresa"].Value;
            _DescricaoEmpresaRed = (string)dataGridSearchModule.CurrentRow.Cells["DescricaoEmpresaRed"].Value;
            _CodigoEmpresaConsolidada = (int)dataGridSearchModule.CurrentRow.Cells["CodigoEmpresaConsolidada"].Value;
            _Ativa = (string)dataGridSearchModule.CurrentRow.Cells["Ativa"].Value;
            _CodigoRg = (int)dataGridSearchModule.CurrentRow.Cells["CodigoRg"].Value;
            _Host = (string)dataGridSearchModule.CurrentRow.Cells["Host"].Value;
            _Port = (int)dataGridSearchModule.CurrentRow.Cells["Port"].Value;
            _Username = (string)dataGridSearchModule.CurrentRow.Cells["Username"].Value;
            _Senha = (string)dataGridSearchModule.CurrentRow.Cells["Senha"].Value;
            _Email = (string)dataGridSearchModule.CurrentRow.Cells["Email"].Value;
            _EnderecoBanco = (string)dataGridSearchModule.CurrentRow.Cells["EnderecoBanco"].Value;
            _Versao = (string)dataGridSearchModule.CurrentRow.Cells["Versao"].Value;

            _UpdateFormEmpresa.CodigoEmpresa = _CodigoEmpresa;
            _UpdateFormEmpresa.DescricaoEmpresa = _DescricaoEmpresa;
            _UpdateFormEmpresa.DescricaoEmpresaRed = _DescricaoEmpresaRed;
            _UpdateFormEmpresa.CodigoEmpresaConsolidada = _CodigoEmpresaConsolidada;
            _UpdateFormEmpresa.Ativa = _Ativa;
            _UpdateFormEmpresa.CodigoRg = _CodigoRg;
            _UpdateFormEmpresa.Host = _Host;
            _UpdateFormEmpresa.Port = _Port;
            _UpdateFormEmpresa.Username = _Username;
            _UpdateFormEmpresa.Senha = _Senha;
            _UpdateFormEmpresa.Email = _Email;
            _UpdateFormEmpresa.EnderecoBanco = _EnderecoBanco;
            _UpdateFormEmpresa.Versao = _Versao;

            try
            {
                _UpdateFormEmpresa.ShowDialog();
            }
            finally
            {
                AppStateManager.CodigoEmpresa = _UpdateFormEmpresa.CodigoEmpresa;

                _Filter = string.Format(" where cod_empr = '{0}' ", AppStateManager.CodigoEmpresa);

                _UpdateFormEmpresa = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(EmpresaProcess.CreateInstance.TaskGetCollectionGeEmpresaByFilter(_Filter, 1));
            }
        }

        private void tlstrpBtnDelete_Click(object sender, System.EventArgs e)
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnDelete_Click";

            string _ModifyType = string.Empty;
            string _CodigoEmpresa = string.Empty;
            string _DescricaoEmpresa = string.Empty;
            string _DescricaoEmpresaRed = string.Empty;
            int _CodigoEmpresaConsolidada = 0;
            string _Ativa = string.Empty;
            int _CodigoRg = 0;
            string _Host = string.Empty;
            int _Port = 0;
            string _Username = string.Empty;
            string _Senha = string.Empty;
            string _Email = string.Empty;
            string _EnderecoBanco = string.Empty;
            string _Versao = string.Empty;
            

            if (dataGridSearchModule.CurrentRow.Cells["CodigoEmpresa"].Value != null)
            {
                if (MessageBox.Show("Deseja excluir este registro?",
                                    UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoEmpresa, FormsMessages.TituloProcessoAcaoEmpresaExclusao), 
                                    MessageBoxButtons.OKCancel, 
                                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (_ThrowingException != null) { _ThrowingException = null; }   
                        _CodigoEmpresa = (string)dataGridSearchModule.CurrentRow.Cells["CodigoEmpresa"].Value;
                        _DescricaoEmpresa = (string)dataGridSearchModule.CurrentRow.Cells["DescricaoEmpresa"].Value;
                        _DescricaoEmpresaRed = (string)dataGridSearchModule.CurrentRow.Cells["DescricaoEmpresaRed"].Value;
                        _CodigoEmpresaConsolidada = (int)dataGridSearchModule.CurrentRow.Cells["CodigoEmpresaConsolidada"].Value;
                        _Ativa = (string)dataGridSearchModule.CurrentRow.Cells["Ativa"].Value;
                        _CodigoRg = (int)dataGridSearchModule.CurrentRow.Cells["CodigoRg"].Value;
                        _Host = (string)dataGridSearchModule.CurrentRow.Cells["Host"].Value;
                        _Port = (int)dataGridSearchModule.CurrentRow.Cells["Port"].Value;
                        _Username = (string)dataGridSearchModule.CurrentRow.Cells["Username"].Value;
                        _Senha = (string)dataGridSearchModule.CurrentRow.Cells["Senha"].Value;
                        _Email = (string)dataGridSearchModule.CurrentRow.Cells["Email"].Value;
                        _EnderecoBanco = (string)dataGridSearchModule.CurrentRow.Cells["EnderecoBanco"].Value;
                        _Versao = (string)dataGridSearchModule.CurrentRow.Cells["Versao"].Value;
                        _ModifyType = EmpresaProcess.CreateInstance.FromToModificaEmpresa(ModificaEmpresaType.EmpresaExcluir);
                        FillLogHeaderFromDeleteModify(_CodigoEmpresa, _DescricaoEmpresa, _DescricaoEmpresaRed, _CodigoEmpresaConsolidada, _Ativa, _CodigoRg, _Host, _Port, _Username, _Senha, _Email, _EnderecoBanco, _Versao);
                        EmpresaProcess.CreateInstance.TaskModifyProcessEmpresa(int.Parse(_CodigoEmpresa), string.Empty, string.Empty, 0, string.Empty, 0, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, _ModifyType);
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

                        if (_LogCodigoEmpresa != null) { _LogCodigoEmpresa.ValorNovo = _CodigoEmpresa; }
                        if (_LogDescricaoEmpresa != null) { _LogDescricaoEmpresa.ValorNovo = _DescricaoEmpresa; }
                        if (_LogDescricaoEmpresaRed != null) { _LogDescricaoEmpresaRed.ValorNovo = _DescricaoEmpresaRed; }
                        if (_LogCodigoEmpresaConsolidada != null) { _LogCodigoEmpresaConsolidada.ValorNovo = _CodigoEmpresaConsolidada; }
                        if (_LogAtiva != null) { _LogAtiva.ValorNovo = _Ativa; }
                        if (_LogCodigoRg != null) { _LogCodigoRg.ValorNovo = _CodigoRg; }
                        if (_LogHost != null) { _LogHost.ValorNovo = _Host; }
                        if (_LogPort != null) { _LogPort.ValorNovo = _Port; }
                        if (_LogUsername != null) { _LogUsername.ValorNovo = _Username; }
                        if (_LogSenha != null) { _LogSenha.ValorNovo = _Senha; }
                        if (_LogEmail != null) { _LogEmail.ValorNovo = _Email; }
                        if (_LogEnderecoBanco != null) { _LogEnderecoBanco.ValorNovo = _EnderecoBanco; }
                        if (_LogVersao != null) { _LogVersao.ValorNovo = _Versao; }

                        _ChangeItems = new List<ChangeItem>();
                        _ChangeItems.Add(_LogCodigoEmpresa);
                        _ChangeItems.Add(_LogDescricaoEmpresa);
                        _ChangeItems.Add(_LogDescricaoEmpresaRed);
                        _ChangeItems.Add(_LogCodigoEmpresaConsolidada);
                        _ChangeItems.Add(_LogAtiva);
                        _ChangeItems.Add(_LogCodigoRg);
                        _ChangeItems.Add(_LogHost);
                        _ChangeItems.Add(_LogPort);
                        _ChangeItems.Add(_LogUsername);
                        _ChangeItems.Add(_LogSenha);
                        _ChangeItems.Add(_LogEmail);
                        _ChangeItems.Add(_LogEnderecoBanco);
                        _ChangeItems.Add(_LogVersao);

                        #endregion

                        ExecuteModifyExceptionLogEmpresa(_ChangesHeader, _ChangeItems, _ThrowingException);
                    }
                    finally
                    {
                        dataGridSearchModule.DataSource = null;

                        FillDataGrid(EmpresaProcess.CreateInstance.TaskGetCollectionGeEmpresaByFilter("", 0));

                        #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                        if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                        #endregion

                        #region ...::: Atualiza os Itens do Log de Modificações :::...

                        if (_LogCodigoEmpresa != null) { _LogCodigoEmpresa.ValorNovo = _CodigoEmpresa; }
                        if (_LogDescricaoEmpresa != null) { _LogDescricaoEmpresa.ValorNovo = _DescricaoEmpresa; }
                        if (_LogDescricaoEmpresaRed != null) { _LogDescricaoEmpresaRed.ValorNovo = _DescricaoEmpresaRed; }
                        if (_LogCodigoEmpresaConsolidada != null) { _LogCodigoEmpresaConsolidada.ValorNovo = _CodigoEmpresaConsolidada; }
                        if (_LogAtiva != null) { _LogAtiva.ValorNovo = _Ativa; }
                        if (_LogCodigoRg != null) { _LogCodigoRg.ValorNovo = _CodigoRg; }
                        if (_LogHost != null) { _LogHost.ValorNovo = _Host; }
                        if (_LogPort != null) { _LogPort.ValorNovo = _Port; }
                        if (_LogUsername != null) { _LogUsername.ValorNovo = _Username; }
                        if (_LogSenha != null) { _LogSenha.ValorNovo = _Senha; }
                        if (_LogEmail != null) { _LogEmail.ValorNovo = _Email; }
                        if (_LogEnderecoBanco != null) { _LogEnderecoBanco.ValorNovo = _EnderecoBanco; }
                        if (_LogVersao != null) { _LogVersao.ValorNovo = _Versao; }

                        _ChangeItems = new List<ChangeItem>();
                        _ChangeItems.Add(_LogCodigoEmpresa);
                        _ChangeItems.Add(_LogDescricaoEmpresa);
                        _ChangeItems.Add(_LogDescricaoEmpresaRed);
                        _ChangeItems.Add(_LogCodigoEmpresaConsolidada);
                        _ChangeItems.Add(_LogAtiva);
                        _ChangeItems.Add(_LogCodigoRg);
                        _ChangeItems.Add(_LogHost);
                        _ChangeItems.Add(_LogPort);
                        _ChangeItems.Add(_LogUsername);
                        _ChangeItems.Add(_LogSenha);
                        _ChangeItems.Add(_LogEmail);
                        _ChangeItems.Add(_LogEnderecoBanco);
                        _ChangeItems.Add(_LogVersao);

                        #endregion

                        ExecuteModifyLogEmpresa(_ChangesHeader, _ChangeItems);
                    }
                }
            }
        }
        private void ExecuteModifyLogEmpresa(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }

        private void ExecuteModifyExceptionLogEmpresa(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void FillLogHeaderFromDeleteModify(string _CodigoEmpresa, string _DescricaoEmpresa, string _DescricaoEmpresaRed, int _CodigoEmpresaConsolidada, string _Ativa,
                                                   int _CodigoRg, string _Host, int _Port, string _Username, string _Senha, string _Email, string _EnderecoBanco, string _Versao)
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboGeEmpresa.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdEmpresaFromDashboard;
            _ChangesHeader.TipoModificacao = EmpresaProcess.CreateInstance.FromToModificaEmpresa(ModificaEmpresaType.EmpresaExcluir);
            _ChangesHeader.Usuario = this.UsuarioLoginDashboard;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Empresa
            _LogCodigoEmpresa = new ChangeItem();
            _LogCodigoEmpresa.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoEmpresa.IdItem = 1;
            _LogCodigoEmpresa.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogCodigoEmpresa.NomeCampo = DboGeEmpresa.NomeCodigoEmpresa;
            _LogCodigoEmpresa.ValorAntigo = _CodigoEmpresa;

            //Descrição Empresa
            _LogDescricaoEmpresa = new ChangeItem();
            _LogDescricaoEmpresa.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricaoEmpresa.IdItem = 2;
            _LogDescricaoEmpresa.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogDescricaoEmpresa.NomeCampo = DboGeEmpresa.NomeDescricaoEmpresa;
            _LogDescricaoEmpresa.ValorAntigo = _DescricaoEmpresa;

            //Descrição Empresa Reduzida
            _LogDescricaoEmpresaRed = new ChangeItem();
            _LogDescricaoEmpresaRed.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricaoEmpresaRed.IdItem = 3;
            _LogDescricaoEmpresaRed.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogDescricaoEmpresaRed.NomeCampo = DboGeEmpresa.NomeDescricaoEmpresaRed;
            _LogDescricaoEmpresaRed.ValorAntigo = _DescricaoEmpresaRed;

            //Sequencia Aplicação
            _LogCodigoEmpresaConsolidada = new ChangeItem();
            _LogCodigoEmpresaConsolidada.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoEmpresaConsolidada.IdItem = 4;
            _LogCodigoEmpresaConsolidada.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogCodigoEmpresaConsolidada.NomeCampo = DboGeEmpresa.NomeCodigoEmpresaConsolidada;
            _LogCodigoEmpresaConsolidada.ValorAntigo = _CodigoEmpresaConsolidada;

            //Ativa 
            _LogAtiva = new ChangeItem();
            _LogAtiva.IdChangeHeader = _ChangesHeader.Id;
            _LogAtiva.IdItem = 5;
            _LogAtiva.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogAtiva.NomeCampo = DboGeEmpresa.NomeAtiva;
            _LogAtiva.ValorAntigo = _Ativa;

            //Codigo Rg
            _LogCodigoRg = new ChangeItem();
            _LogCodigoRg.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoRg.IdItem = 6;
            _LogCodigoRg.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogCodigoRg.NomeCampo = DboGeEmpresa.NomeCodigoRg;
            _LogCodigoRg.ValorAntigo = _CodigoRg;

            //Host
            _LogHost = new ChangeItem();
            _LogHost.IdChangeHeader = _ChangesHeader.Id;
            _LogHost.IdItem = 7;
            _LogHost.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogHost.NomeCampo = DboGeEmpresa.NomeHost;
            _LogHost.ValorAntigo = _Host;

            //Port
            _LogPort = new ChangeItem();
            _LogPort.IdChangeHeader = _ChangesHeader.Id;
            _LogPort.IdItem = 8;
            _LogPort.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogPort.NomeCampo = DboGeEmpresa.NomePort;
            _LogPort.ValorAntigo = _Port;

            //User Name
            _LogUsername = new ChangeItem();
            _LogUsername.IdChangeHeader = _ChangesHeader.Id;
            _LogUsername.IdItem = 9;
            _LogUsername.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogUsername.NomeCampo = DboGeEmpresa.NomeUsername;
            _LogUsername.ValorAntigo = _Username;

            //Senha
            _LogSenha = new ChangeItem();
            _LogSenha.IdChangeHeader = _ChangesHeader.Id;
            _LogSenha.IdItem = 10;
            _LogSenha.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogSenha.NomeCampo = DboGeEmpresa.NomeSenha;
            _LogSenha.ValorAntigo = _Senha;

            //Email
            _LogEmail = new ChangeItem();
            _LogEmail.IdChangeHeader = _ChangesHeader.Id;
            _LogEmail.IdItem = 11;
            _LogEmail.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogEmail.NomeCampo = DboGeEmpresa.NomeEmail;
            _LogEmail.ValorAntigo = _Email;

            //Endereço Banco
            _LogEnderecoBanco = new ChangeItem();
            _LogEnderecoBanco.IdChangeHeader = _ChangesHeader.Id;
            _LogEnderecoBanco.IdItem = 12;
            _LogEnderecoBanco.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogEnderecoBanco.NomeCampo = DboGeEmpresa.NomeEnderecoBanco;
            _LogEnderecoBanco.ValorAntigo = _EnderecoBanco;

            //Versão
            _LogVersao = new ChangeItem();
            _LogVersao.IdChangeHeader = _ChangesHeader.Id;
            _LogVersao.IdItem = 13;
            _LogVersao.NomeTabela = DboGeEmpresa.NomeTabela;
            _LogVersao.NomeCampo = DboGeEmpresa.NomeVersao;
            _LogVersao.ValorAntigo = _Versao;

            #endregion
        }

        private void tlstrpBtnSearchCriteria_Click(object sender, EventArgs e)
        {
            int _SearchType = 0;
            string _Filter = "";
            int _DescrEmpresa = 0;
            string _Descricao = "";
            FilterSearchFormEmpresa _FilterSearchFormEmpresa = null;

            if (dataGridSearchModule.DataSource != null)
            {
                try
                {
                    _FilterSearchFormEmpresa = new FilterSearchFormEmpresa();
                    _FilterSearchFormEmpresa.ShowDialog();
                }
                finally
                {
                    _SearchType = _FilterSearchFormEmpresa.SearchType;

                    switch (_SearchType)
                    {
                        case 0:
                            dataGridSearchModule.DataSource = null;
                            _DescrEmpresa = _FilterSearchFormEmpresa.CodigoEmpresa;
                            AppStateManager.CodigoEmpresa = _DescrEmpresa;
                            _Filter = string.Format(" where cod_empr = {0} ", AppStateManager.CodigoEmpresa);
                            FillDataGrid(EmpresaProcess.CreateInstance.TaskGetCollectionGeEmpresaByFilter(_Filter, 1));
                            break;
                        case 1:
                            dataGridSearchModule.DataSource = null;
                            _Descricao = _FilterSearchFormEmpresa.DescricaoEmpresa;
                            AppStateManager.DescricaoEmpresa = _Descricao.ToUpper();
                            _Filter = string.Format(" where descr_empr = '%{0}%' ", AppStateManager.DescricaoEmpresa);
                            FillDataGrid(EmpresaProcess.CreateInstance.TaskGetCollectionGeEmpresaByFilter(_Filter, 1));
                            break;
                    }

                    _FilterSearchFormEmpresa.Dispose();
                }
            }
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, EventArgs e)
        {
            dataGridSearchModule.DataSource = null;
            FillDataGrid(EmpresaProcess.CreateInstance.TaskGetCollectionGeEmpresaByFilter("", 0));
        }

        private void SearchFormEmpresa_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                this.AlteraGeEmpresa();
            }
        }
    }

    internal static class DboGeEmpresa
    {
        #region ...::: Private Constantes :::...

        private const string _NomeCodigoEmpresa = "cod_empr";
        private const string _NomeDescricaoEmpresa = "descr_empr";
        private const string _NomeDescricaoEmpresaRed = "descr_empr_red";
        private const string _NomeCodigoEmpresaConsolidada = "cod_empr_consol";
        private const string _NomeAtiva = "ativa";
        private const string _NomeCodigoRg = "cod_rg";
        private const string _NomeHost = "host";
        private const string _NomePort = "port";
        private const string _NomeUsername = "username";
        private const string _NomeSenha = "senha";
        private const string _NomeEmail = "e_mail";
        private const string _NomeEnderecoBanco = "endereco_banco";
        private const string _NomeVersao = "versao";

        private const string _NomeTabela = "ge_empresa";
        private const string _NomeProcesso = "Empresa";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeCodigoEmpresa { get { return _NomeCodigoEmpresa; } }
        public static string NomeDescricaoEmpresa { get { return _NomeDescricaoEmpresa; } }
        public static string NomeDescricaoEmpresaRed { get { return _NomeDescricaoEmpresaRed; } }
        public static string NomeCodigoEmpresaConsolidada { get { return _NomeCodigoEmpresaConsolidada; } }
        public static string NomeAtiva { get { return _NomeAtiva; } }
        public static string NomeCodigoRg { get { return _NomeCodigoRg; } }
        public static string NomeHost { get { return _NomeHost; } }
        public static string NomePort { get { return _NomePort; } }
        public static string NomeUsername { get { return _NomeUsername; } }
        public static string NomeSenha { get { return _NomeSenha; } }
        public static string NomeEmail { get { return _NomeEmail; } }
        public static string NomeEnderecoBanco { get { return _NomeEnderecoBanco; } }
        public static string NomeVersao { get { return _NomeVersao; } }
        

        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
