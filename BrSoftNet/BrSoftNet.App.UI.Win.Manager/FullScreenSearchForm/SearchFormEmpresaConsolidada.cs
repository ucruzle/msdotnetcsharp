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
    public partial class SearchFormEmpresaConsolidada : Form
    {
        #region ...::: Private Variable :::...

        private int _CodigoEmpresaConsolidada = 0;
        private string _DescricaoEmpresaConsolidada = string.Empty;
        private string _AtivaEmpresaConsolidada = string.Empty;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpresaFromDashboard { get; set; }

        public string UsuarioLoginDashboard { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;

        private ChangeItem _LogCodigoEmpresaConsolidada = null;
        private ChangeItem _LogDescricaoEmpresaConsolidada = null;
        private ChangeItem _LogAtivaEmpresaConsolidada = null;

        private List<ChangeItem> _ChangeItems = null;
        private ThrowingException _ThrowingException = null;

        #endregion

        public SearchFormEmpresaConsolidada()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(EmpresaConsolidadaProcess.CreateInstance.TaskGetCollectionGeEmpresaConsolidadaByFilter("", 0));
        }

        private void FillDataGrid(List<GeEmpresaConsolidada> _GeEmpresaConsolidadaCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateManager.GeEmpresaConsolidadaCollection = _GeEmpresaConsolidadaCollection;

                bsGeEmpresaConsolidada.DataSource = AppStateManager.GeEmpresaConsolidadaCollection;
                bsGeEmpresaConsolidada.AllowNew = false;

                dataGridSearchModule.DataSource = bsGeEmpresaConsolidada;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["CodigoEmpresaConsolidada"].HeaderText = "Empresa";
                dataGridSearchModule.Columns["CodigoEmpresaConsolidada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescricaoEmpresaConsolidada"].HeaderText = "Descrição";
                dataGridSearchModule.Columns["DescricaoEmpresaConsolidada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["AtivaEmpresaConsolidada"].HeaderText = "Ativo";
                dataGridSearchModule.Columns["AtivaEmpresaConsolidada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void tlstrpBtnFirst_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeEmpresaConsolidada.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeEmpresaConsolidada.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeEmpresaConsolidada.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeEmpresaConsolidada.MoveLast();
            }
        }

        private void tlstrpBtnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        }

        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AdicionaGeEmpresaConsolidada();
        }

        private void AdicionaGeEmpresaConsolidada()
        {
            UpdateFormEmpresaConsolidada _UpdateFormEmpresaConsolidada = new UpdateFormEmpresaConsolidada();
            _UpdateFormEmpresaConsolidada.ModificaEmpresaConsolidadaType = ModificaEmpresaConsolidadaType.EmpresaConsolidadaAdicionar;
            _UpdateFormEmpresaConsolidada.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormEmpresaConsolidada.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormEmpresaConsolidada.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoEmpresaConsolidada, FormsMessages.TituloProcessoAcaoEmpresaConsolidadaInclusao);

            try
            {
                _UpdateFormEmpresaConsolidada.ShowDialog();
            }
            finally
            {
                _UpdateFormEmpresaConsolidada = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(EmpresaConsolidadaProcess.CreateInstance.TaskGetCollectionGeEmpresaConsolidadaByFilter("", 0));
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, System.EventArgs e)
        {
            AlteraGeEmpresaConsolidada();
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, EventArgs e)
        {
            dataGridSearchModule.DataSource = null;
            FillDataGrid(EmpresaConsolidadaProcess.CreateInstance.TaskGetCollectionGeEmpresaConsolidadaByFilter("", 0));
        }

        private void AlteraGeEmpresaConsolidada()
        {
            string _Filter = string.Empty;

            UpdateFormEmpresaConsolidada _UpdateFormEmpresaConsolidada = new UpdateFormEmpresaConsolidada();
            _UpdateFormEmpresaConsolidada.ModificaEmpresaConsolidadaType = ModificaEmpresaConsolidadaType.EmpresaConsolidadaAlterar;
            _UpdateFormEmpresaConsolidada.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormEmpresaConsolidada.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormEmpresaConsolidada.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoEmpresaConsolidada, FormsMessages.TituloProcessoAcaoEmpresaConsolidadaAlteracao);

            _CodigoEmpresaConsolidada = (int)dataGridSearchModule.CurrentRow.Cells["CodigoEmpresaConsolidada"].Value;
            _DescricaoEmpresaConsolidada = (string)dataGridSearchModule.CurrentRow.Cells["DescricaoEmpresaConsolidada"].Value;
            _AtivaEmpresaConsolidada = (string)dataGridSearchModule.CurrentRow.Cells["AtivaEmpresaConsolidada"].Value;

            _UpdateFormEmpresaConsolidada.CodigoEmpresaConsolidada = _CodigoEmpresaConsolidada;
            _UpdateFormEmpresaConsolidada.DescricaoEmpresaConsolidada = _DescricaoEmpresaConsolidada;
            _UpdateFormEmpresaConsolidada.AtivaEmpresaConsolidada = _AtivaEmpresaConsolidada;

            try
            {
                _UpdateFormEmpresaConsolidada.ShowDialog();
            }
            finally
            {
                AppStateManager.CodigoEmpresaConsolidada = _UpdateFormEmpresaConsolidada.CodigoEmpresaConsolidada;

                _Filter = string.Format(" where cod_empr_consol = '{0}' ", AppStateManager.CodigoEmpresaConsolidada);

                _UpdateFormEmpresaConsolidada = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(EmpresaConsolidadaProcess.CreateInstance.TaskGetCollectionGeEmpresaConsolidadaByFilter(_Filter, 1));
            }
        }

        private void tlstrpBtnDelete_Click(object sender, System.EventArgs e)
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnDelete_Click";
            string _ModifyType = string.Empty;
            int _CodigoEmpresaConsolidada = 0;
            string _Descricao = string.Empty;

            if (dataGridSearchModule.CurrentRow.Cells["CodigoEmpresaConsolidada"].Value != null)
            {
                if (MessageBox.Show("Deseja excluir este registro?",
                                    UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoEmpresaConsolidada, FormsMessages.TituloProcessoAcaoEmpresaConsolidadaExclusao),
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (_ThrowingException != null) { _ThrowingException = null; }
                        _CodigoEmpresaConsolidada = Convert.ToInt32(dataGridSearchModule.CurrentRow.Cells["CodigoEmpresaConsolidada"].Value);
                        _DescricaoEmpresaConsolidada = (string)dataGridSearchModule.CurrentRow.Cells["DescricaoEmpresaConsolidada"].Value;
                        _AtivaEmpresaConsolidada = (string)dataGridSearchModule.CurrentRow.Cells["AtivaEmpresaConsolidada"].Value;
                        FillLogHeaderFromDeleteModify(_CodigoEmpresaConsolidada, _DescricaoEmpresaConsolidada, _AtivaEmpresaConsolidada);
                        _ModifyType = EmpresaConsolidadaProcess.CreateInstance.FromToModificaEmpresaConsolidada(ModificaEmpresaConsolidadaType.EmpresaConsolidadaExcluir);
                        EmpresaConsolidadaProcess.CreateInstance.TaskModifyProcessEmpresaConsolidada(_CodigoEmpresaConsolidada, string.Empty, string.Empty, _ModifyType);
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

                        if (_LogCodigoEmpresaConsolidada != null) { _LogCodigoEmpresaConsolidada.ValorNovo = _CodigoEmpresaConsolidada; }
                        if (_LogDescricaoEmpresaConsolidada != null) { _LogDescricaoEmpresaConsolidada.ValorNovo = _DescricaoEmpresaConsolidada; }
                        if (_LogAtivaEmpresaConsolidada != null) { _LogAtivaEmpresaConsolidada.ValorNovo = _AtivaEmpresaConsolidada; }


                        _ChangeItems = new List<ChangeItem>();
                        _ChangeItems.Add(_LogCodigoEmpresaConsolidada);
                        _ChangeItems.Add(_LogDescricaoEmpresaConsolidada);
                        _ChangeItems.Add(_LogAtivaEmpresaConsolidada);
                        #endregion

                        ExecuteModifyExceptionLogEmpresaConsolidada(_ChangesHeader, _ChangeItems, _ThrowingException);
                        
                    }
                    finally
                    {
                        dataGridSearchModule.DataSource = null;

                        FillDataGrid(EmpresaConsolidadaProcess.CreateInstance.TaskGetCollectionGeEmpresaConsolidadaByFilter("", 0));

                        #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                        if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                        #endregion

                        #region ...::: Atualiza os Itens do Log de Modificações :::...

                        if (_LogCodigoEmpresaConsolidada != null) { _LogCodigoEmpresaConsolidada.ValorNovo = _CodigoEmpresaConsolidada; }
                        if (_LogDescricaoEmpresaConsolidada != null) { _LogDescricaoEmpresaConsolidada.ValorNovo = _DescricaoEmpresaConsolidada; }
                        if (_LogAtivaEmpresaConsolidada != null)
                        {
                            _LogAtivaEmpresaConsolidada.ValorNovo = _AtivaEmpresaConsolidada
                                ;
                        }

                        _ChangeItems = new List<ChangeItem>();
                        _ChangeItems.Add(_LogCodigoEmpresaConsolidada);
                        _ChangeItems.Add(_LogDescricaoEmpresaConsolidada);
                        _ChangeItems.Add(_LogAtivaEmpresaConsolidada);
                        #endregion

                        ExecuteModifyLogEmpresaConsolidada(_ChangesHeader, _ChangeItems);
                    }
                }
            }
        }

        private void ExecuteModifyLogEmpresaConsolidada(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }

        private void ExecuteModifyExceptionLogEmpresaConsolidada(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void FillLogHeaderFromDeleteModify(int _CodigoEmpresaConsolidada, string _DescricaoEmpresaConsolidada, string _AtivaEmpresaConsolidada)
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboGeEmpresaConsolidada.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdEmpresaFromDashboard;
            _ChangesHeader.TipoModificacao = EmpresaConsolidadaProcess.CreateInstance.FromToModificaEmpresaConsolidada(ModificaEmpresaConsolidadaType.EmpresaConsolidadaExcluir);
            _ChangesHeader.Usuario = this.UsuarioLoginDashboard;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Aplicação
            _LogCodigoEmpresaConsolidada = new ChangeItem();
            _LogCodigoEmpresaConsolidada.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoEmpresaConsolidada.IdItem = 1;
            _LogCodigoEmpresaConsolidada.NomeTabela = DboGeEmpresaConsolidada.NomeTabela;
            _LogCodigoEmpresaConsolidada.NomeCampo = DboGeEmpresaConsolidada.NomeCodigoEmpresaConsolidada;
            _LogCodigoEmpresaConsolidada.ValorAntigo = _CodigoEmpresaConsolidada;

            //Descrição Aplicação
            _LogDescricaoEmpresaConsolidada = new ChangeItem();
            _LogDescricaoEmpresaConsolidada.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricaoEmpresaConsolidada.IdItem = 2;
            _LogDescricaoEmpresaConsolidada.NomeTabela = DboGeEmpresaConsolidada.NomeTabela;
            _LogDescricaoEmpresaConsolidada.NomeCampo = DboGeEmpresaConsolidada.NomeDescrEmpresaConolidada;
            _LogDescricaoEmpresaConsolidada.ValorAntigo = _DescricaoEmpresaConsolidada;

            //Sigla Aplicação
            _LogAtivaEmpresaConsolidada = new ChangeItem();
            _LogAtivaEmpresaConsolidada.IdChangeHeader = _ChangesHeader.Id;
            _LogAtivaEmpresaConsolidada.IdItem = 3;
            _LogAtivaEmpresaConsolidada.NomeTabela = DboGeEmpresaConsolidada.NomeTabela;
            _LogAtivaEmpresaConsolidada.NomeCampo = DboGeEmpresaConsolidada.NomeAtivaEmpresaConsolidada;
            _LogAtivaEmpresaConsolidada.ValorAntigo = _AtivaEmpresaConsolidada;

            #endregion
        }

        private void tlstrpBtnSearchCriteria_Click(object sender, EventArgs e)
        {
            int _SearchType = 0;
            string _Filter = "";
            int _DescrEmpresaConsolidada = 0;
            string _Descricao = "";
            FilterSearchFormEmpresaConsolidada _FilterSearchFormEmpresaConsolidada = null;

            if (dataGridSearchModule.DataSource != null)
            {
                try
                {
                    _FilterSearchFormEmpresaConsolidada = new FilterSearchFormEmpresaConsolidada();
                    _FilterSearchFormEmpresaConsolidada.ShowDialog();
                }
                finally
                {
                    _SearchType = _FilterSearchFormEmpresaConsolidada.SearchType;

                    switch (_SearchType)
                    {
                        case 0:
                            dataGridSearchModule.DataSource = null;
                            _DescrEmpresaConsolidada = _FilterSearchFormEmpresaConsolidada.CodigoEmpresaConsolidada;
                            AppStateManager.CodigoEmpresaConsolidada = _DescrEmpresaConsolidada;
                            _Filter = string.Format(" where cod_empr_consol = {0} ", AppStateManager.CodigoEmpresaConsolidada);
                            FillDataGrid(EmpresaConsolidadaProcess.CreateInstance.TaskGetCollectionGeEmpresaConsolidadaByFilter(_Filter, 1));
                            break;
                        case 1:
                            dataGridSearchModule.DataSource = null;
                            _Descricao = _FilterSearchFormEmpresaConsolidada.DescricaoEmpresaConsolidada;
                            AppStateManager.DescricaoEmpresaConsolidada = _Descricao.ToUpper();
                            _Filter = string.Format(" where descr_empr_consol = '%{0}%' or ativa = '%{1}%'", AppStateManager.DescricaoEmpresaConsolidada, AppStateManager.AtivaEmpresaConsolidada);
                            FillDataGrid(EmpresaConsolidadaProcess.CreateInstance.TaskGetCollectionGeEmpresaConsolidadaByFilter(_Filter, 1));
                            break;
                    }

                    _FilterSearchFormEmpresaConsolidada.Dispose();
                }
            }
        }

        private void SearchFormEmpresaConsolidada_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                this.AlteraGeEmpresaConsolidada();
            }
        }
    }

    internal static class DboGeEmpresaConsolidada
    {
        #region ...::: Private Constantes :::...

        private const string _NomeCodigoEmpresaConsolidada = "cod_empr_consol";
        private const string _NomeDescrEmpresaConolidada = "descr_empr_consol";
        private const string _NomeAtivaEmpresaConsolidada= "sigla_aplic";
        private const string _NomeTabela = "ge_empresa_consol";
        private const string _NomeProcesso = "Empresa Consolidada";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeCodigoEmpresaConsolidada { get { return _NomeCodigoEmpresaConsolidada; } }
        public static string NomeDescrEmpresaConolidada { get { return _NomeDescrEmpresaConolidada; } }
        public static string NomeAtivaEmpresaConsolidada { get { return _NomeAtivaEmpresaConsolidada; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
