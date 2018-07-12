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
    public partial class SearchFormAplicacao : Form
    {
        #region ...::: Private Variable :::...

        private int _CodigoAplicacao = 0;
        private string _DescricaoAplicacao = string.Empty;
        private string _SiglaAplicacao = string.Empty;
        private int _SequenciaAplicacao = 0;
        private string _AtivaAplicacao = string.Empty;
        private string _FormAplicacao = string.Empty;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpresaFromDashboard { get; set; }

        public string UsuarioLoginDashboard { get; set; }

        public int IdAplicacaoLogDashboard { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;
        private ChangeItem _LogCodigoAplicacao = null;
        private ChangeItem _LogDescricaoAplicacao = null;
        private ChangeItem _LogSiglaAplicacao = null;
        private ChangeItem _LogSequenciaAplicacao = null;
        private ChangeItem _LogAtivaAplicacao = null;
        private ChangeItem _LogFormAplicacao = null;
        private List<ChangeItem> _ChangeItems = null;
        private ThrowingException _ThrowingException = null;

        #endregion

        public SearchFormAplicacao()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(AplicacaoProcess.CreateInstance.TaskGetCollectionGeAplicacaoByFilter("", 0));
        }

        private void FillDataGrid(List<GeAplicacao> _GeAplicacaoCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateManager.GeAplicacaoCollection = _GeAplicacaoCollection;

                bsGeAplicacao.DataSource = AppStateManager.GeAplicacaoCollection;
                bsGeAplicacao.AllowNew = false;

                dataGridSearchModule.DataSource = bsGeAplicacao;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["CodigoAplicacao"].HeaderText = "Aplicacao";
                dataGridSearchModule.Columns["CodigoAplicacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescricaoAplicacao"].HeaderText = "Descrição";
                dataGridSearchModule.Columns["DescricaoAplicacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["SiglaAplicacao"].HeaderText = "Sigla";
                dataGridSearchModule.Columns["SiglaAplicacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["SequenciaAplicacao"].HeaderText = "Sequência";
                dataGridSearchModule.Columns["SequenciaAplicacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["AtivaAplicacao"].HeaderText = "Ativo";
                dataGridSearchModule.Columns["AtivaAplicacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["FormAplicacao"].HeaderText = "Form";
                dataGridSearchModule.Columns["FormAplicacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void tlstrpBtnFirst_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeAplicacao.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeAplicacao.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeAplicacao.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeAplicacao.MoveLast();
            }
        }

        private void tlstrpBtnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        }

        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AdicionaGeAplicacao();
        }

        private void AdicionaGeAplicacao()
        {
            UpdateFormAplicacao _UpdateFormAplicacao = new UpdateFormAplicacao();
            _UpdateFormAplicacao.ModificaAplicacaoType = ModificaAplicacaoType.AplicacaoAdicionar;
            _UpdateFormAplicacao.CodigoAplicacao = IdAplicacaoLogDashboard;
            _UpdateFormAplicacao.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormAplicacao.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormAplicacao.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoAplicacao, FormsMessages.TituloProcessoAcaoAplicacaoInclusao);


            try
            {
                _UpdateFormAplicacao.ShowDialog();
            }
            finally
            {
                _UpdateFormAplicacao = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(AplicacaoProcess.CreateInstance.TaskGetCollectionGeAplicacaoByFilter("", 0));
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, System.EventArgs e)
        {
            AlteraGeAplicacao();
        }

        private void AlteraGeAplicacao()
        {
            string _Filter = string.Empty;

            UpdateFormAplicacao _UpdateFormAplicacao = new UpdateFormAplicacao();
            _UpdateFormAplicacao.ModificaAplicacaoType = ModificaAplicacaoType.AplicacaoAlterar;
            _UpdateFormAplicacao.CodigoAplicacao = IdAplicacaoLogDashboard;
            _UpdateFormAplicacao.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormAplicacao.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormAplicacao.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoAplicacao, FormsMessages.TituloProcessoAcaoAplicacaoAlteracao);

            _CodigoAplicacao = (int)dataGridSearchModule.CurrentRow.Cells["CodigoAplicacao"].Value;
            _DescricaoAplicacao = (string)dataGridSearchModule.CurrentRow.Cells["DescricaoAplicacao"].Value;
            _SiglaAplicacao = (string)dataGridSearchModule.CurrentRow.Cells["SiglaAplicacao"].Value;
            _SequenciaAplicacao = (int)dataGridSearchModule.CurrentRow.Cells["SequenciaAplicacao"].Value;
            _AtivaAplicacao = (string)dataGridSearchModule.CurrentRow.Cells["AtivaAplicacao"].Value;
            _FormAplicacao = (string)dataGridSearchModule.CurrentRow.Cells["FormAplicacao"].Value;

            _UpdateFormAplicacao.CodigoAplicacao = _CodigoAplicacao;
            _UpdateFormAplicacao.DescricaoAplicacao = _DescricaoAplicacao;
            _UpdateFormAplicacao.SiglaAplicacao = _SiglaAplicacao;
            _UpdateFormAplicacao.SequenciaAplicacao = _SequenciaAplicacao;
            _UpdateFormAplicacao.AtivaAplicacao = _AtivaAplicacao;
            _UpdateFormAplicacao.FormAplicacao = _FormAplicacao;

            try
            {
                _UpdateFormAplicacao.ShowDialog();
            }
            finally
            {
                AppStateManager.CodigoAplicacao = _UpdateFormAplicacao.CodigoAplicacao;

                _Filter = string.Format(" where cod_aplic = '{0}' ", AppStateManager.CodigoAplicacao);

                _UpdateFormAplicacao = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(AplicacaoProcess.CreateInstance.TaskGetCollectionGeAplicacaoByFilter(_Filter, 1));
            }
        }

        private void tlstrpBtnDelete_Click(object sender, System.EventArgs e)
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnDelete_Click";

            string _ModifyType = string.Empty;
            string _CodigoAplicacao = string.Empty;
            string _DescricaoAplicacao = string.Empty;
            string _SiglaAplicacao = string.Empty;
            string _SequenciaAplicacao = string.Empty;
            string _AtivaAplicacao = string.Empty;
            string _FormAplicacao = string.Empty;


            if (dataGridSearchModule.CurrentRow.Cells["CodigoAplicacao"].Value != null)
            {
                if (MessageBox.Show("Deseja excluir este registro?",
                                    UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoAplicacao, FormsMessages.TituloProcessoAcaoAplicacaoExclusao),
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (_ThrowingException != null) { _ThrowingException = null; }   
                        _CodigoAplicacao = dataGridSearchModule.CurrentRow.Cells["CodigoAplicacao"].Value.ToString();
                        _DescricaoAplicacao = (string)dataGridSearchModule.CurrentRow.Cells["DescricaoAplicacao"].Value;
                        _SiglaAplicacao = (string)dataGridSearchModule.CurrentRow.Cells["SiglaAplicacao"].Value;
                        _SequenciaAplicacao = dataGridSearchModule.CurrentRow.Cells["SequenciaAplicacao"].Value.ToString();
                        _AtivaAplicacao = (string)dataGridSearchModule.CurrentRow.Cells["AtivaAplicacao"].Value;
                        _FormAplicacao = (string)dataGridSearchModule.CurrentRow.Cells["FormAplicacao"].Value;
                        _ModifyType = AplicacaoProcess.CreateInstance.FromToModificaAplicacao(ModificaAplicacaoType.AplicacaoExcluir);
                        FillLogHeaderFromDeleteModify(_CodigoAplicacao, _DescricaoAplicacao, _SiglaAplicacao, _SequenciaAplicacao, _AtivaAplicacao, _FormAplicacao);
                        AplicacaoProcess.CreateInstance.TaskModifyProcessAplicacao(int.Parse(_CodigoAplicacao), string.Empty, string.Empty, 0, string.Empty, string.Empty, _ModifyType);
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

                        if (_LogCodigoAplicacao != null) { _LogCodigoAplicacao.ValorNovo = _CodigoAplicacao; }
                        if (_LogDescricaoAplicacao != null) { _LogDescricaoAplicacao.ValorNovo = _DescricaoAplicacao; }
                        if (_LogSiglaAplicacao != null) { _LogSiglaAplicacao.ValorNovo = _SiglaAplicacao; }
                        if (_LogSequenciaAplicacao != null) { _LogSequenciaAplicacao.ValorNovo = _SequenciaAplicacao; }
                        if (_LogAtivaAplicacao != null) { _LogAtivaAplicacao.ValorNovo = _AtivaAplicacao; }
                        if (_LogFormAplicacao != null) { _LogFormAplicacao.ValorNovo = _FormAplicacao; }

                        _ChangeItems = new List<ChangeItem>();
                        _ChangeItems.Add(_LogCodigoAplicacao);
                        _ChangeItems.Add(_LogDescricaoAplicacao);
                        _ChangeItems.Add(_LogSiglaAplicacao);
                        _ChangeItems.Add(_LogSequenciaAplicacao);
                        _ChangeItems.Add(_LogAtivaAplicacao);
                        _ChangeItems.Add(_LogFormAplicacao);

                        #endregion

                        ExecuteModifyExceptionLogAplicacao(_ChangesHeader, _ChangeItems, _ThrowingException);
                    }
                    finally
                    {
                        dataGridSearchModule.DataSource = null;

                        FillDataGrid(AplicacaoProcess.CreateInstance.TaskGetCollectionGeAplicacaoByFilter("", 0));

                        #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                        if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                        #endregion

                        #region ...::: Atualiza os Itens do Log de Modificações :::...

                        if (_LogCodigoAplicacao != null) { _LogCodigoAplicacao.ValorNovo = _CodigoAplicacao; }
                        if (_LogDescricaoAplicacao != null) { _LogDescricaoAplicacao.ValorNovo = _DescricaoAplicacao; }
                        if (_LogSiglaAplicacao != null) { _LogSiglaAplicacao.ValorNovo = _SiglaAplicacao; }
                        if (_LogSequenciaAplicacao != null) { _LogSequenciaAplicacao.ValorNovo = _SequenciaAplicacao; }
                        if (_LogAtivaAplicacao != null) { _LogAtivaAplicacao.ValorNovo = _AtivaAplicacao; }
                        if (_LogFormAplicacao != null) { _LogFormAplicacao.ValorNovo = _FormAplicacao; }

                        _ChangeItems = new List<ChangeItem>();
                        _ChangeItems.Add(_LogCodigoAplicacao);
                        _ChangeItems.Add(_LogDescricaoAplicacao);
                        _ChangeItems.Add(_LogSiglaAplicacao);
                        _ChangeItems.Add(_LogSequenciaAplicacao);
                        _ChangeItems.Add(_LogAtivaAplicacao);
                        _ChangeItems.Add(_LogFormAplicacao);

                        #endregion

                        ExecuteModifyLogAplicacao(_ChangesHeader, _ChangeItems);
                    }
                }
            }
        }

        private void ExecuteModifyLogAplicacao(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }

        private void ExecuteModifyExceptionLogAplicacao(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void FillLogHeaderFromDeleteModify(string _CodigoAplicacao, string _DescricaoAplicacao, string _SiglaAplicacao, string _SequenciaAplicacao, string _AtivaAplicacao, string _FormAplicacao)
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboGeAplicacao.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdAplicacaoLogDashboard;
            _ChangesHeader.TipoModificacao = AplicacaoProcess.CreateInstance.FromToModificaAplicacao(ModificaAplicacaoType.AplicacaoExcluir);
            _ChangesHeader.Usuario = this.UsuarioLoginDashboard;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Aplicação
            _LogCodigoAplicacao = new ChangeItem();
            _LogCodigoAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoAplicacao.IdItem = 1;
            _LogCodigoAplicacao.NomeTabela = DboGeAplicacao.NomeTabela;
            _LogCodigoAplicacao.NomeCampo = DboGeAplicacao.NomeCodigoAplicacao;
            _LogCodigoAplicacao.ValorAntigo = _CodigoAplicacao;

            //Descrição Aplicação
            _LogDescricaoAplicacao = new ChangeItem();
            _LogDescricaoAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricaoAplicacao.IdItem = 2;
            _LogDescricaoAplicacao.NomeTabela = DboGeAplicacao.NomeTabela;
            _LogDescricaoAplicacao.NomeCampo = DboGeAplicacao.NomeDescrAplicacao;
            _LogDescricaoAplicacao.ValorAntigo = _DescricaoAplicacao;

            //Sigla Aplicação
            _LogSiglaAplicacao = new ChangeItem();
            _LogSiglaAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogSiglaAplicacao.IdItem = 3;
            _LogSiglaAplicacao.NomeTabela = DboGeAplicacao.NomeTabela;
            _LogSiglaAplicacao.NomeCampo = DboGeAplicacao.NomeSiglaAplicacao;
            _LogSiglaAplicacao.ValorAntigo = _SiglaAplicacao;

            //Sequencia Aplicação
            _LogSequenciaAplicacao = new ChangeItem();
            _LogSequenciaAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogSequenciaAplicacao.IdItem = 4;
            _LogSequenciaAplicacao.NomeTabela = DboGeAplicacao.NomeTabela;
            _LogSequenciaAplicacao.NomeCampo = DboGeAplicacao.NomeSequenciaAplicacao;
            _LogSequenciaAplicacao.ValorAntigo = _SequenciaAplicacao;

            //Ativa Aplicação
            _LogAtivaAplicacao = new ChangeItem();
            _LogAtivaAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogAtivaAplicacao.IdItem = 5;
            _LogAtivaAplicacao.NomeTabela = DboGeAplicacao.NomeTabela;
            _LogAtivaAplicacao.NomeCampo = DboGeAplicacao.NomeAtivaAplicacao;
            _LogAtivaAplicacao.ValorAntigo = _AtivaAplicacao;

            //Form Aplicação
            _LogFormAplicacao = new ChangeItem();
            _LogFormAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogFormAplicacao.IdItem = 6;
            _LogFormAplicacao.NomeTabela = DboGeAplicacao.NomeTabela;
            _LogFormAplicacao.NomeCampo = DboGeAplicacao.NomeFormAplicacao;
            _LogFormAplicacao.ValorAntigo = _FormAplicacao;

            #endregion
        }
        private void tlstrpBtnSearchCriteria_Click(object sender, EventArgs e)
        {
            int _SearchType = 0;
            string _Filter = "";
            int _CodigoAplicacao = 0;
            string _Descricao = "";
            FilterSearchFormAplicacao _FilterSearchFormAplicacao = null;

            if (dataGridSearchModule.DataSource != null)
            {
                try
                {
                    _FilterSearchFormAplicacao = new FilterSearchFormAplicacao();
                    _FilterSearchFormAplicacao.ShowDialog();
                }
                finally
                {
                    _SearchType = _FilterSearchFormAplicacao.SearchType;

                    switch (_SearchType)
                    {
                        case 0:
                            dataGridSearchModule.DataSource = null;
                            _CodigoAplicacao = _FilterSearchFormAplicacao.CodigoAplicacao;
                            AppStateManager.CodigoAplicacao = _CodigoAplicacao;
                            _Filter = string.Format(" where cod_aplic = {0} ", AppStateManager.CodigoAplicacao);
                            FillDataGrid(AplicacaoProcess.CreateInstance.TaskGetCollectionGeAplicacaoByFilter(_Filter, 1));
                            break;
                        case 1:
                            dataGridSearchModule.DataSource = null;
                            _Descricao = _FilterSearchFormAplicacao.DescricaoAplicacao;
                            AppStateManager.DescricaoAplicacao = _Descricao.ToUpper();
                            _Filter = string.Format(" where descr_aplic = '%{0}%' or sigla_aplic = '%{1}%' or sequ_aplic = '%{1}%' or ativa = '%{1}%' or form_aplic = '%{1}%'", AppStateManager.DescricaoAplicacao, AppStateManager.SiglaAplicacao, AppStateManager.SequenciaAplicacao, AppStateManager.AtivaAplicacao, AppStateManager.FormAplicacao);
                            FillDataGrid(AplicacaoProcess.CreateInstance.TaskGetCollectionGeAplicacaoByFilter(_Filter, 1));
                            break;
                    }

                    _FilterSearchFormAplicacao.Dispose();
                }
            }
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, EventArgs e)
        {
            dataGridSearchModule.DataSource = null;
            FillDataGrid(AplicacaoProcess.CreateInstance.TaskGetCollectionGeAplicacaoByFilter("", 0));
        }

        private void SearchFormAplicacao_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                this.AlteraGeAplicacao();
            }
        }
    }

    internal static class DboGeAplicacao
    {
        #region ...::: Private Constantes :::...

        private const string _NomeCodigoAplicacao = "cod_aplic";
        private const string _NomeDescrAplicacao = "descr_aplic";
        private const string _NomeSiglaAplicacao = "sigla_aplic";
        private const string _NomeSequenciaAplicacao = "sequ_aplic";
        private const string _NomeAtivaAplicacao = "ativa";
        private const string _NomeFormAplicacao = "form_aplic";
        private const string _NomeTabela = "ge_aplicacao";
        private const string _NomeProcesso = "Aplicação";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeCodigoAplicacao { get { return _NomeCodigoAplicacao; } }
        public static string NomeDescrAplicacao { get { return _NomeDescrAplicacao; } }
        public static string NomeSiglaAplicacao { get { return _NomeSiglaAplicacao; } }
        public static string NomeSequenciaAplicacao { get { return _NomeSequenciaAplicacao; } }
        public static string NomeAtivaAplicacao { get { return _NomeAtivaAplicacao; } }
        public static string NomeFormAplicacao { get { return _NomeFormAplicacao; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
