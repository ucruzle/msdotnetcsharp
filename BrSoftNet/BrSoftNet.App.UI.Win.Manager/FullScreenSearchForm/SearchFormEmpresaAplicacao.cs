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
    public partial class SearchFormEmpresaAplicacao : Form
    {
        #region ...::: Private Variable :::...

        private int CodigoEmpresa = 0;
       
        private int CodigoAplicacao = 0;
        
        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpresaFromDashboard { get; set; }

        public string UsuarioLoginDashboard { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }
        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;

        private ChangeItem _LogCodigoEmpresa = null;
        private ChangeItem _LogCodigoAplicacao = null;

        private List<ChangeItem> _ChangeItems = null;
        private ThrowingException _ThrowingException = null;

        #endregion
        
        public SearchFormEmpresaAplicacao()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.tlstrpBtnUpdate.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(EmpresaAplicacaoProcess.CreateInstance.TaskGetCollectionGeEmpresaAplicacaoByFilter("", 0));
        }

        private void FillDataGrid(List<GeEmpresaAplicacao> _GeEmpresaAplicacaoCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateManager.GeEmpresaAplicacaoCollection = _GeEmpresaAplicacaoCollection;

                bsGeEmpresaAplicacao.DataSource = AppStateManager.GeEmpresaAplicacaoCollection;
                bsGeEmpresaAplicacao.AllowNew = false;

                dataGridSearchModule.DataSource = bsGeEmpresaAplicacao;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["CodigoEmpresa"].HeaderText = "Empresa";
                dataGridSearchModule.Columns["CodigoEmpresa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescricaoEmpresa"].HeaderText = "Descrição Empresa";
                dataGridSearchModule.Columns["DescricaoEmpresa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoAplicacao"].HeaderText = "Aplicação";
                dataGridSearchModule.Columns["CodigoAplicacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescricaoAplicacao"].HeaderText = "Descrição Aplicação";
                dataGridSearchModule.Columns["DescricaoAplicacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void tlstrpBtnSearchCriteria_Click(object sender, System.EventArgs e)
        {
            int _SearchType = 0;
            string _Filter = "";
            int _CodigoEmpresa = 0;
            int _CodigoAplicacao = 0;
            FilterSearchFormEmpresaAplicacao _FilterSearchFormEmpresaAplicacao = null;

            if (dataGridSearchModule.DataSource != null)
            {
                try
                {
                    _FilterSearchFormEmpresaAplicacao = new FilterSearchFormEmpresaAplicacao();
                    _FilterSearchFormEmpresaAplicacao.ShowDialog();
                }
                finally
                {
                    _SearchType = _FilterSearchFormEmpresaAplicacao.SearchType;

                    switch (_SearchType)
                    {
                        case 0:
                            dataGridSearchModule.DataSource = null;
                            _CodigoEmpresa = _FilterSearchFormEmpresaAplicacao.CodigoEmpresa;
                            AppStateManager.CodigoEmpresa = _CodigoEmpresa;
                            _Filter = string.Format(" where emp.cod_empr = {0} ", AppStateManager.CodigoEmpresa);
                            FillDataGrid(EmpresaAplicacaoProcess.CreateInstance.TaskGetCollectionGeEmpresaAplicacaoByFilter(_Filter, 1));
                            break;
                        case 1:
                            dataGridSearchModule.DataSource = null;
                            _CodigoAplicacao = _FilterSearchFormEmpresaAplicacao.CodigoAplicacao;
                            AppStateManager.CodigoAplicacao = _CodigoAplicacao;
                            _Filter = string.Format(" where apl.cod_aplic = {0} ", AppStateManager.CodigoAplicacao);
                            FillDataGrid(EmpresaAplicacaoProcess.CreateInstance.TaskGetCollectionGeEmpresaAplicacaoByFilter(_Filter, 1));
                            break;
                    }

                    _FilterSearchFormEmpresaAplicacao.Dispose();
                }
            }
        }
        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AddGeEmpresaAplicacao();
        }

        private void AddGeEmpresaAplicacao()
        {
            UpdateFormEmpresaAplicacao _UpdateFormEmpresaAplicacao = new UpdateFormEmpresaAplicacao();
            _UpdateFormEmpresaAplicacao._ModificaEmpresaAplicacaoType = ModificaEmpresaAplicacaoType.EmpresaAplicacaoAdicionar;
            _UpdateFormEmpresaAplicacao.CodigoAplicacao = IdEmpresaFromDashboard;
            _UpdateFormEmpresaAplicacao.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormEmpresaAplicacao.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoEmpresaAplicacao, FormsMessages.TituloProcessoAcaoEmpresaAplicacaoInclusao);

            try
            {
                _UpdateFormEmpresaAplicacao.ShowDialog();
            }
            finally
            {
                _UpdateFormEmpresaAplicacao = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(EmpresaAplicacaoProcess.CreateInstance.TaskGetCollectionGeEmpresaAplicacaoByFilter("", 0));
            }
           
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, System.EventArgs e)
        {
            dataGridSearchModule.DataSource = null;
            FillDataGrid(EmpresaAplicacaoProcess.CreateInstance.TaskGetCollectionGeEmpresaAplicacaoByFilter("", 0));
        }

        private void tlstrpBtnDelete_Click(object sender, System.EventArgs e)
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnDelete_Click";
            string _ModifyType = string.Empty;
            int _CodigoEmpresa = 0;
            int _CodigoAplicacao = 0;
            string _DescricaoEmpresa = string.Empty;
            string _DescricaoApicacao = string.Empty;

            if (dataGridSearchModule.CurrentRow.Cells["CodigoEmpresa"].Value != null || dataGridSearchModule.CurrentRow.Cells["CodigoAplicacao"].Value != null
                    || dataGridSearchModule.CurrentRow.Cells["DescricaoEmpresa"].Value != null || dataGridSearchModule.CurrentRow.Cells["DescricaoAplicacao"].Value != null)
            {
                if (MessageBox.Show("Deseja excluir este registro?",
                                    UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoEmpresaAplicacao, FormsMessages.TituloProcessoAcaoEmpresaAplicacaoExclusao),
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (_ThrowingException != null) { _ThrowingException = null; }   
                        _CodigoEmpresa = (int)dataGridSearchModule.CurrentRow.Cells["CodigoEmpresa"].Value;
                        _CodigoAplicacao = (int)dataGridSearchModule.CurrentRow.Cells["CodigoAplicacao"].Value;
                        _DescricaoEmpresa = (string)dataGridSearchModule.CurrentRow.Cells["DescricaoEmpresa"].Value;
                        _DescricaoApicacao = (string)dataGridSearchModule.CurrentRow.Cells["DescricaoAplicacao"].Value;
                        _ModifyType = EmpresaAplicacaoProcess.CreateInstance.FromToModificaEmpresaAplicacao(ModificaEmpresaAplicacaoType.EmpresaAplicacaoExcluir);
                        FillLogHeaderFromDeleteModify(_CodigoEmpresa, _CodigoAplicacao);
                        EmpresaAplicacaoProcess.CreateInstance.TaskModifyProcessEmpresaAplicacao(_CodigoEmpresa, _CodigoAplicacao, _DescricaoEmpresa, _DescricaoApicacao, _ModifyType);
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
                        if (_LogCodigoAplicacao != null) { _LogCodigoAplicacao.ValorNovo = _CodigoAplicacao; }
                       

                        _ChangeItems = new List<ChangeItem>();
                        _ChangeItems.Add(_LogCodigoEmpresa);
                        _ChangeItems.Add(_LogCodigoAplicacao);

                        #endregion

                        ExecuteModifyExceptionLogEmpresaAplicacao(_ChangesHeader, _ChangeItems, _ThrowingException);
                    }
                    finally
                    {
                        dataGridSearchModule.DataSource = null;

                        FillDataGrid(EmpresaAplicacaoProcess.CreateInstance.TaskGetCollectionGeEmpresaAplicacaoByFilter("",0));

                        #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                        if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                        #endregion

                        #region ...::: Atualiza os Itens do Log de Modificações :::...

                        if (_LogCodigoEmpresa != null) { _LogCodigoEmpresa.ValorNovo = _CodigoEmpresa; }
                        if (_LogCodigoAplicacao != null) { _LogCodigoAplicacao.ValorNovo = _CodigoAplicacao; }


                        _ChangeItems = new List<ChangeItem>();
                        _ChangeItems.Add(_LogCodigoEmpresa);
                        _ChangeItems.Add(_LogCodigoAplicacao);

                        #endregion


                        ExecuteModifyLogEmpresaAplicacao(_ChangesHeader, _ChangeItems);
                    }
                }
            }
        }

        private void ExecuteModifyLogEmpresaAplicacao(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }

        private void ExecuteModifyExceptionLogEmpresaAplicacao(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void FillLogHeaderFromDeleteModify(int _CodigoEmpresa, int _CodigoAplicacao)
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboGeEmpresaAplicacao.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdEmpresaFromDashboard;
            _ChangesHeader.TipoModificacao = EmpresaAplicacaoProcess.CreateInstance.FromToModificaEmpresaAplicacao(ModificaEmpresaAplicacaoType.EmpresaAplicacaoExcluir);
            _ChangesHeader.Usuario = this.UsuarioLoginDashboard;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Empresa
            _LogCodigoEmpresa = new ChangeItem();
            _LogCodigoEmpresa.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoEmpresa.IdItem = 1;
            _LogCodigoEmpresa.NomeTabela = DboGeEmpresaAplicacao.NomeTabela;
            _LogCodigoEmpresa.NomeCampo = DboGeEmpresaAplicacao.NomeCodigoEmpresa;
            _LogCodigoEmpresa.ValorAntigo = _CodigoEmpresa;

            //Codigo Aplicação
            _LogCodigoAplicacao = new ChangeItem();
            _LogCodigoAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoAplicacao.IdItem = 2;
            _LogCodigoAplicacao.NomeTabela = DboGeEmpresaAplicacao.NomeTabela;
            _LogCodigoAplicacao.NomeCampo = DboGeEmpresaAplicacao.NomeCodigoAplicacao;
            _LogCodigoAplicacao.ValorAntigo = _CodigoAplicacao;

            #endregion
        }

        private void tlstrpBtnFirst_Click(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeEmpresaAplicacao.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeEmpresaAplicacao.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeEmpresaAplicacao.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeEmpresaAplicacao.MoveLast();
            }
        }

        private void tlstrpBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        }

        private void SearchFormEmpresaAplicacao_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Ação não permitida para esse processo!", " Informação...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }

    internal static class DboGeEmpresaAplicacao
    {
        #region ...::: Private Constantes :::...

        private const string _NomeCodigoAplicacao = "cod_aplic";
        private const string _NomeCodigoEmpresa= "cod_empr";
        private const string _NomeTabela = "ge_empresa_aplicacao";
        private const string _NomeProcesso = "Empresa Aplicação";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeCodigoAplicacao { get { return _NomeCodigoAplicacao; } }
        public static string NomeCodigoEmpresa { get { return _NomeCodigoEmpresa; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
