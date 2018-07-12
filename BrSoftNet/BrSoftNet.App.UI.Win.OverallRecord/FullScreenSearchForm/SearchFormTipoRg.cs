using BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects;
using BrSoftNet.App.Business.Processes.OverallRecord.Enumerators;
using BrSoftNet.App.Business.Processes.OverallRecord.Tasks;
using BrSoftNet.App.UI.Win.OverallRecord.DialogUpdateForm;
using BrSoftNet.App.UI.Win.OverallRecord.FilterFullScreenSearchForm;
using BrSoftNet.App.UI.Win.OverallRecord.State;
using BrSoftNet.Library.Messages;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Log.Actions;
using BrSoftNet.Log.Helpers;
using BrSoftNet.Log.Structures;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.OverallRecord.FullScreenSearchForm
{
    public partial class SearchFormTipoRg : Form
    {
        #region ...::: Private Variable :::...

        private string _TipoRg = string.Empty;
        private string _DescrTipo = string.Empty;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpresaFromDashboard { get; set; }

        public int IdTipoRgLogDashboard { get; set; }

        public string UsuarioLoginDashboard { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;

        private ChangeItem _LogIdTipoRg = null;
        private ChangeItem _LogDescrTipoRg = null;

        private List<ChangeItem> _ChangeItems = null;

        private ThrowingException _ThrowingException = null;

        #endregion
        public SearchFormTipoRg()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(TipoRgProcess.CreateInstance.TaskGetCollectionRgTipoRgByFilter("", 0));
        }

        private void FillDataGrid(List<RgTipoRg> _RgTipoRgCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateOverallRecord.RgTipoRgCollection = _RgTipoRgCollection;

                bsRgTipoRg.DataSource = AppStateOverallRecord.RgTipoRgCollection;
                bsRgTipoRg.AllowNew = false;

                dataGridSearchModule.DataSource = bsRgTipoRg;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["TipoRg"].HeaderText = "Tipo";
                dataGridSearchModule.Columns["TipoRg"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescrTipo"].HeaderText = "Descrição";
                dataGridSearchModule.Columns["DescrTipo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void tlstrpBtnFirst_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgTipoRg.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgTipoRg.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgTipoRg.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgTipoRg.MoveLast();
            }
        }

        private void tlstrpBtnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        }

        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AdicionaRgTipoRg();
        }

        private void AdicionaRgTipoRg()
        {
            UpdateFormTipoRg _UpdateFormTipoRg = new UpdateFormTipoRg();
            _UpdateFormTipoRg.ModificaTipoRgType = ModificaTipoRgType.TipoRgAdicionar;
            _UpdateFormTipoRg.IdTipoRg = IdTipoRgLogDashboard;
            _UpdateFormTipoRg.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormTipoRg.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoTipoRg, FormsMessages.TituloProcessoAcaoTipoRgInclusao);

            try
            {
                _UpdateFormTipoRg.ShowDialog();
            }
            finally
            {
                _UpdateFormTipoRg = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(TipoRgProcess.CreateInstance.TaskGetCollectionRgTipoRgByFilter("", 0));
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, System.EventArgs e)
        {
            AlteraRgTipoRg();
        }

        private void AlteraRgTipoRg()
        {
            string _Filter = string.Empty;

            UpdateFormTipoRg _UpdateFormTipoRg = new UpdateFormTipoRg();
            _UpdateFormTipoRg.ModificaTipoRgType = ModificaTipoRgType.TipoRgAlterar;
            _UpdateFormTipoRg.IdTipoRg = IdTipoRgLogDashboard;
            _UpdateFormTipoRg.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormTipoRg.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoTipoRg, FormsMessages.TituloProcessoAcaoTipoRgAlteracao);

            _TipoRg = (string)dataGridSearchModule.CurrentRow.Cells["TipoRg"].Value;
            _DescrTipo = (string)dataGridSearchModule.CurrentRow.Cells["DescrTipo"].Value;

            _UpdateFormTipoRg.Sigla = _TipoRg;
            _UpdateFormTipoRg.Descricao = _DescrTipo;

            try
            {
                _UpdateFormTipoRg.ShowDialog();
            }
            finally
            {
                AppStateOverallRecord.TipoRg = _UpdateFormTipoRg.Sigla;

                _Filter = string.Format(" where tipo_rg = '{0}' ", AppStateOverallRecord.TipoRg);

                _UpdateFormTipoRg = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(TipoRgProcess.CreateInstance.TaskGetCollectionRgTipoRgByFilter(_Filter, 1));
            }
        }

        private void tlstrpBtnDelete_Click(object sender, System.EventArgs e)
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnDelete_Click";

            string _ModifyType = string.Empty;
            string _TipoRg = string.Empty;
            string _DescrTipo = string.Empty;

            if (dataGridSearchModule.CurrentRow.Cells["TipoRg"].Value != null)
            {
                if (MessageBox.Show("Deseja excluir este registro?",
                                    UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoTipoRg, FormsMessages.TituloProcessoAcaoTipoRgExclusao),
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (_ThrowingException != null) { _ThrowingException = null; }   
                        _TipoRg = (string)dataGridSearchModule.CurrentRow.Cells["TipoRg"].Value;
                        _DescrTipo = (string)dataGridSearchModule.CurrentRow.Cells["DescrTipo"].Value;
                        _ModifyType = TipoRgProcess.CreateInstance.FromToModificaTipoRg(ModificaTipoRgType.TipoRgExcluir);
                        FillLogHeaderFromDeleteModify(_TipoRg, _DescrTipo);
                        TipoRgProcess.CreateInstance.TaskModifyProcessTipoRg(_TipoRg, string.Empty, _ModifyType);
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

                        if (_LogIdTipoRg != null) { _LogIdTipoRg.ValorNovo = _TipoRg; }
                        if (_LogDescrTipoRg != null) { _LogDescrTipoRg.ValorNovo = _DescrTipo; }

                        _ChangeItems = new List<ChangeItem>();
                        _ChangeItems.Add(_LogIdTipoRg);
                        _ChangeItems.Add(_LogDescrTipoRg);

                        #endregion

                        ExecuteModifyExceptionLogTipoRg(_ChangesHeader, _ChangeItems, _ThrowingException);
                    }
                    finally
                    {
                        dataGridSearchModule.DataSource = null;

                        FillDataGrid(TipoRgProcess.CreateInstance.TaskGetCollectionRgTipoRgByFilter("", 0));

                        if (_ThrowingException == null)
                        {
                            #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                            if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                            #endregion

                            #region ...::: Atualiza os Itens do Log de Modificações :::...

                            if (_LogIdTipoRg != null) { _LogIdTipoRg.ValorNovo = _TipoRg; }
                            if (_LogDescrTipoRg != null) { _LogDescrTipoRg.ValorNovo = _DescrTipo; }

                            _ChangeItems = new List<ChangeItem>();
                            _ChangeItems.Add(_LogIdTipoRg);
                            _ChangeItems.Add(_LogDescrTipoRg);

                            #endregion

                            ExecuteModifyLogTipoRg(_ChangesHeader, _ChangeItems);
                        }
                    }
                }
            }
        }

        private void ExecuteModifyLogTipoRg(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }

        private void ExecuteModifyExceptionLogTipoRg(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void FillLogHeaderFromDeleteModify(string _TipoRg, string _DescrTipo)
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgTipoRg.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdTipoRgLogDashboard;
            _ChangesHeader.TipoModificacao = TipoRgProcess.CreateInstance.FromToModificaTipoRg(ModificaTipoRgType.TipoRgExcluir);
            _ChangesHeader.Usuario = this.UsuarioLoginDashboard;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Tipo Rg
            _LogIdTipoRg = new ChangeItem();
            _LogIdTipoRg.IdChangeHeader = _ChangesHeader.Id;
            _LogIdTipoRg.IdItem = 1;
            _LogIdTipoRg.NomeTabela = DboRgTipoRg.NomeTabela;
            _LogIdTipoRg.NomeCampo = DboRgTipoRg.NomeTipoRg;
            _LogIdTipoRg.ValorAntigo = _TipoRg;

            //Descrição Tipo Rg
            _LogDescrTipoRg = new ChangeItem();
            _LogDescrTipoRg.IdChangeHeader = _ChangesHeader.Id;
            _LogDescrTipoRg.IdItem = 2;
            _LogDescrTipoRg.NomeTabela = DboRgTipoRg.NomeTabela;
            _LogDescrTipoRg.NomeCampo = DboRgTipoRg.NomeDescrTipoRg;
            _LogDescrTipoRg.ValorAntigo = _DescrTipo;

            #endregion
        }
        private void tlstrpBtnSearchCriteria_Click(object sender, EventArgs e)
        {
            int _SearchType = 0;
            string _Filter = "";
            string _TipoRg = "";
            string _DescrTipo = "";
            FilterSearchFormTipoRg _FilterSearchFormTipoRg = null;

            if (dataGridSearchModule.DataSource != null)
            {
                try
                {
                    _FilterSearchFormTipoRg = new FilterSearchFormTipoRg();
                    _FilterSearchFormTipoRg.ShowDialog();
                }
                finally
                {
                    _SearchType = _FilterSearchFormTipoRg.SearchType;

                    switch (_SearchType)
                    {
                        case 0:
                            dataGridSearchModule.DataSource = null;
                            _TipoRg = _FilterSearchFormTipoRg.TipoRg;
                            AppStateOverallRecord.TipoRg = _TipoRg;
                            _Filter = string.Format(" where tipo_rg LIKE '%{0}%' ", AppStateOverallRecord.TipoRg);
                            FillDataGrid(TipoRgProcess.CreateInstance.TaskGetCollectionRgTipoRgByFilter(_Filter, 1));
                            break;
                        case 1:
                            dataGridSearchModule.DataSource = null;
                            _DescrTipo = _FilterSearchFormTipoRg.Descricao;
                            AppStateOverallRecord.DescrTipo = _DescrTipo.ToUpper();
                            _Filter = string.Format(" where descr_tipo_rg = '%{0}%' ", AppStateOverallRecord.DescrTipo);
                            FillDataGrid(TipoRgProcess.CreateInstance.TaskGetCollectionRgTipoRgByFilter(_Filter, 1));
                            break;
                    }

                    _FilterSearchFormTipoRg.Dispose();
                }
            }
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, EventArgs e)
        {
            dataGridSearchModule.DataSource = null;
            FillDataGrid(TipoRgProcess.CreateInstance.TaskGetCollectionRgTipoRgByFilter("", 0));
        }

        private void SearchFormTipoRg_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                this.AlteraRgTipoRg();
            }
        }
    }

    internal static class DboRgTipoRg
    {
        #region ...::: Private Constantes :::...

        private const string _NomeTipoRg = "tipo_rg";
        private const string _NomeDescrTipoRg = "descr_tipo_rg";
        private const string _NomeTabela = "rg_tipo_rg";
        private const string _NomeProcesso = "Tipo Rg";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeTipoRg { get { return _NomeTipoRg; } }
        public static string NomeDescrTipoRg { get { return _NomeDescrTipoRg; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
