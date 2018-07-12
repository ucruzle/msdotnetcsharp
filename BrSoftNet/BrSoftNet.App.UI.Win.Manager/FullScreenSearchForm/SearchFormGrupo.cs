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
    public partial class SearchFormGrupo : Form
    {
        #region ...::: Private Variable :::...

        private int _CodigoGrupo = 0;
        private string _DescricaoGrupo = string.Empty;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpresaFromDashboard { get; set; }

        public string UsuarioLoginDashboard { get; set; }

        public int IdGrupoFromDashboard { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;

        private ChangeItem _LogCodigoGrupo = null;
        private ChangeItem _LogDescricaoGrupo = null;

        private List<ChangeItem> _ChangeItems = null;
        private ThrowingException _ThrowingException = null;



        #endregion

        public SearchFormGrupo()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(GrupoProcess.CreateInstance.TaskGetCollectionGeGrupoByFilter("", 0));
        }

        private void FillDataGrid(List<GeGrupo> _GeGrupoCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateManager.GeGrupoCollection = _GeGrupoCollection;

                bsGeGrupo.DataSource = AppStateManager.GeGrupoCollection;
                bsGeGrupo.AllowNew = false;

                dataGridSearchModule.DataSource = bsGeGrupo;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["CodigoGrupo"].HeaderText = "Grupo";
                dataGridSearchModule.Columns["CodigoGrupo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescricaoGrupo"].HeaderText = "Descrição";
                dataGridSearchModule.Columns["DescricaoGrupo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void tlstrpBtnFirst_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeGrupo.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeGrupo.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeGrupo.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeGrupo.MoveLast();
            }
        }

        private void tlstrpBtnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        }

        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AdicionaGeGrupo();
        }

        private void AdicionaGeGrupo()
        {
            UpdateFormGrupo _UpdateFormGrupo = new UpdateFormGrupo();
            _UpdateFormGrupo.ModificaGrupoType = ModificaGrupoType.GrupoAdicionar;
            _UpdateFormGrupo.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormGrupo.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormGrupo.CodigoGrupo = IdGrupoFromDashboard;
            _UpdateFormGrupo.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoGrupo, FormsMessages.TituloProcessoAcaoGrupoInclusao);

            try
            {
                _UpdateFormGrupo.ShowDialog();
            }
            finally
            {
                _UpdateFormGrupo = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(GrupoProcess.CreateInstance.TaskGetCollectionGeGrupoByFilter("", 0));
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, System.EventArgs e)
        {
            AlteraGeGrupo();
        }

        private void AlteraGeGrupo()
        {
            string _Filter = string.Empty;

            UpdateFormGrupo _UpdateFormGrupo = new UpdateFormGrupo();
            _UpdateFormGrupo.ModificaGrupoType = ModificaGrupoType.GrupoAlterar;
            _UpdateFormGrupo.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormGrupo.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormGrupo.CodigoGrupo = IdGrupoFromDashboard;
            _UpdateFormGrupo.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoGrupo, FormsMessages.TituloProcessoAcaoGrupoAlteracao);

            _CodigoGrupo = (int)dataGridSearchModule.CurrentRow.Cells["CodigoGrupo"].Value;
            _DescricaoGrupo = (string)dataGridSearchModule.CurrentRow.Cells["DescricaoGrupo"].Value;

            _UpdateFormGrupo.CodigoGrupo = _CodigoGrupo;
            _UpdateFormGrupo.DescricaoGrupo = _DescricaoGrupo;

            try
            {
                _UpdateFormGrupo.ShowDialog();
            }
            finally
            {
                AppStateManager.CodigoGrupo = _UpdateFormGrupo.CodigoGrupo;

                _Filter = string.Format(" where cod_grupo = '{0}' ", AppStateManager.CodigoGrupo);

                _UpdateFormGrupo = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(GrupoProcess.CreateInstance.TaskGetCollectionGeGrupoByFilter(_Filter, 1));
            }
        }

        private void tlstrpBtnDelete_Click(object sender, System.EventArgs e)
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnDelete_Click";
            string _ModifyType = string.Empty;
            int _CodigoGrupo = 0;
            string _DescricaoGrupo = string.Empty;

            if (dataGridSearchModule.CurrentRow.Cells["CodigoGrupo"].Value != null)
            {
                if (MessageBox.Show("Deseja excluir este registro?",
                                    UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoGrupo, FormsMessages.TituloProcessoAcaoGrupoExclusao),
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (_ThrowingException != null) { _ThrowingException = null; }
                        _CodigoGrupo = int.Parse((dataGridSearchModule.CurrentRow.Cells["CodigoGrupo"].Value.ToString()));
                        _DescricaoGrupo = (string)dataGridSearchModule.CurrentRow.Cells["DescricaoGrupo"].Value;
                        FillLogHeaderFromDeleteModify(_CodigoGrupo, _DescricaoGrupo);
                        _ModifyType = GrupoProcess.CreateInstance.FromToModificaGrupo(ModificaGrupoType.GrupoExcluir);
                        GrupoProcess.CreateInstance.TaskModifyProcessGrupo(_CodigoGrupo, string.Empty, _ModifyType);
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
                        dataGridSearchModule.DataSource = null;

                        FillDataGrid(GrupoProcess.CreateInstance.TaskGetCollectionGeGrupoByFilter("", 0));

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

        private void FillLogHeaderFromDeleteModify(int _CodigoGrupo, string _DescricaoGrupo)
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboGeGrupo.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdGrupoFromDashboard;
            _ChangesHeader.TipoModificacao = GrupoProcess.CreateInstance.FromToModificaGrupo(ModificaGrupoType.GrupoExcluir);
            _ChangesHeader.Usuario = this.UsuarioLoginDashboard;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Grupo
            _LogCodigoGrupo = new ChangeItem();
            _LogCodigoGrupo.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoGrupo.IdItem = 1;
            _LogCodigoGrupo.NomeTabela = DboGeGrupo.NomeTabela;
            _LogCodigoGrupo.NomeCampo = DboGeGrupo.NomeCodigoGrupo;
            _LogCodigoGrupo.ValorAntigo = _CodigoGrupo;

            //Descrição Grupo
            _LogDescricaoGrupo = new ChangeItem();
            _LogDescricaoGrupo.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricaoGrupo.IdItem = 2;
            _LogDescricaoGrupo.NomeTabela = DboGeGrupo.NomeTabela;
            _LogDescricaoGrupo.NomeCampo = DboGeGrupo.NomeDescricaoGrupo;
            _LogDescricaoGrupo.ValorAntigo = _DescricaoGrupo;

            #endregion
        }

        private void tlstrpBtnSearchCriteria_Click(object sender, EventArgs e)
        {
            int _SearchType = 0;
            string _Filter = "";
            int _DescrGrupo = 0;
            string _Descricao = "";
            FilterSearchFormGrupo _FilterSearchFormGrupo = null;

            if (dataGridSearchModule.DataSource != null)
            {
                try
                {
                    _FilterSearchFormGrupo = new FilterSearchFormGrupo();
                    _FilterSearchFormGrupo.ShowDialog();
                }
                finally
                {
                    _SearchType = _FilterSearchFormGrupo.SearchType;

                    switch (_SearchType)
                    {
                        case 0:
                            dataGridSearchModule.DataSource = null;
                            _DescrGrupo = _FilterSearchFormGrupo.CodigoGrupo;
                            AppStateManager.CodigoGrupo = _DescrGrupo;
                            _Filter = string.Format(" where cod_grupo = {0} ", AppStateManager.CodigoGrupo);
                            FillDataGrid(GrupoProcess.CreateInstance.TaskGetCollectionGeGrupoByFilter(_Filter, 1));
                            break;
                        case 1:
                            dataGridSearchModule.DataSource = null;
                            _Descricao = _FilterSearchFormGrupo.DescricaoGrupo;
                            AppStateManager.DescricaoGrupo = _Descricao.ToUpper();
                            _Filter = string.Format(" where descr_grupo = '%{0}%' ", AppStateManager.DescricaoGrupo);
                            FillDataGrid(GrupoProcess.CreateInstance.TaskGetCollectionGeGrupoByFilter(_Filter, 1));
                            break;
                    }

                    _FilterSearchFormGrupo.Dispose();
                }
            }
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, EventArgs e)
        {
            dataGridSearchModule.DataSource = null;
            FillDataGrid(GrupoProcess.CreateInstance.TaskGetCollectionGeGrupoByFilter("", 0));
        }

        private void SearchFormGrupo_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                this.AlteraGeGrupo();
            }
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
