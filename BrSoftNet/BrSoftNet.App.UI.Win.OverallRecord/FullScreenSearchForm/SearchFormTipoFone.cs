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
    public partial class SearchFormTipoFone : Form
    {
        #region ...::: Private Variable :::...

        private int _IdTipoFone { get; set; }
        private string _DescrTipoFone { get; set; }

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpresaFromDashboard { get; set; }

        public string UsuarioLoginDashboard { get; set; }

        public int IdTipoFoneLogDashboard { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;

        private ChangeItem _LogIdTipoFone = null;
        private ChangeItem _LogDescrTipoFone = null;

        private List<ChangeItem> _ChangeItems = null;

        private ThrowingException _ThrowingException = null;

        #endregion

        public SearchFormTipoFone()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(TipoFoneProcess.CreateInstance.TaskGetCollectionRgTipoFoneByFilter("", 0));
        }

        private void FillDataGrid(List<RgTipoFone> _RgTipoFoneCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateOverallRecord.RgTipoFoneCollection = _RgTipoFoneCollection;

                bsRgTipoFone.DataSource = AppStateOverallRecord.RgTipoFoneCollection;
                bsRgTipoFone.AllowNew = false;

                dataGridSearchModule.DataSource = bsRgTipoFone;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["IdTipoFone"].HeaderText = "Tipo";
                dataGridSearchModule.Columns["IdTipoFone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescrTipoFone"].HeaderText = "Descrição";
                dataGridSearchModule.Columns["DescrTipoFone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void tlstrpBtnFirst_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgTipoFone.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgTipoFone.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgTipoFone.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgTipoFone.MoveLast();
            }
        }

        private void tlstrpBtnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        }

        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AdicionaRgTipoFone();
        }

        private void AdicionaRgTipoFone()
        {
            UpdateFormTipoFone _UpdateFormTipoFone = new UpdateFormTipoFone();
            _UpdateFormTipoFone.ModificaTipoFoneType = ModificaTipoFoneType.TipoFoneAdicionar;
            _UpdateFormTipoFone.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormTipoFone.IdTipoFone = IdTipoFoneLogDashboard;
            _UpdateFormTipoFone.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormTipoFone.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoTipoFone, FormsMessages.TituloProcessoAcaoTipoFoneInclusao);
           

            try
            {
                _UpdateFormTipoFone.ShowDialog();
            }
            finally
            {
                _UpdateFormTipoFone = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(TipoFoneProcess.CreateInstance.TaskGetCollectionRgTipoFoneByFilter("", 0));
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, System.EventArgs e)
        {
            AlteraRgTipoFone();
        }

        private void AlteraRgTipoFone()
        {
            string _Filter = string.Empty;

            UpdateFormTipoFone _UpdateFormTipoFone = new UpdateFormTipoFone();
            _UpdateFormTipoFone.ModificaTipoFoneType = ModificaTipoFoneType.TipoFoneAlterar;
            _UpdateFormTipoFone.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormTipoFone.IdTipoFone = IdTipoFoneLogDashboard;
            _UpdateFormTipoFone.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormTipoFone.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoTipoFone, FormsMessages.TituloProcessoAcaoTipoFoneAlteracao);

            _IdTipoFone = (int)dataGridSearchModule.CurrentRow.Cells["IdTipoFone"].Value;
            _DescrTipoFone = (string)dataGridSearchModule.CurrentRow.Cells["DescrTipoFone"].Value;

            _UpdateFormTipoFone.IdTipoFone = _IdTipoFone;
            _UpdateFormTipoFone.DescrTipoFone = _DescrTipoFone;

            try
            {
                _UpdateFormTipoFone.ShowDialog();
            }
            finally
            {
                AppStateOverallRecord.IdTipoFone = _UpdateFormTipoFone.IdTipoFone;

                _Filter = string.Format(" where cod_tipo_fone = '{0}' ", AppStateOverallRecord.IdTipoFone);

                _UpdateFormTipoFone = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(TipoFoneProcess.CreateInstance.TaskGetCollectionRgTipoFoneByFilter(_Filter, 1));
            }
        }

        private void tlstrpBtnDelete_Click(object sender, System.EventArgs e)
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnDelete_Click";

            string _ModifyType = string.Empty;
            int _RgTipoFone = 0;
            string _DescrTipoFone = string.Empty;

            if (dataGridSearchModule.CurrentRow.Cells["IdTipoFone"].Value != null)
            {
                if (MessageBox.Show("Deseja excluir este registro?",
                                    UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoTipoFone, FormsMessages.TituloProcessoAcaoStatusExclusao),
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (_ThrowingException != null) { _ThrowingException = null; }  
                        _RgTipoFone = (int)dataGridSearchModule.CurrentRow.Cells["IdTipoFone"].Value;
                        _DescrTipoFone = (string)dataGridSearchModule.CurrentRow.Cells["DescrTipoFone"].Value;
                        _ModifyType = TipoFoneProcess.CreateInstance.FromToModificaTipoFone(ModificaTipoFoneType.TipoFoneExcluir);
                        FillLogHeaderFromDeleteModify(Convert.ToString(_IdTipoFone), _DescrTipoFone);
                        TipoFoneProcess.CreateInstance.TaskModifyProcessTipoFone(_RgTipoFone, string.Empty, _ModifyType);
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

                        if (_LogIdTipoFone != null) { _LogIdTipoFone.ValorNovo = _IdTipoFone; }
                        if (_LogDescrTipoFone != null) { _LogDescrTipoFone.ValorNovo = _DescrTipoFone; }

                        _ChangeItems = new List<ChangeItem>();
                        _ChangeItems.Add(_LogIdTipoFone);
                        _ChangeItems.Add(_LogDescrTipoFone);

                        #endregion

                        ExecuteModifyExceptionLogStatus(_ChangesHeader, _ChangeItems, _ThrowingException);
                    }
                    finally
                    {
                        dataGridSearchModule.DataSource = null;

                        FillDataGrid(TipoFoneProcess.CreateInstance.TaskGetCollectionRgTipoFoneByFilter("", 0));

                        if (_ThrowingException == null)
                        {
                            #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                            if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                            #endregion

                            #region ...::: Atualiza os Itens do Log de Modificações :::...

                            if (_LogIdTipoFone != null) { _LogIdTipoFone.ValorNovo = _IdTipoFone; }
                            if (_LogDescrTipoFone != null) { _LogDescrTipoFone.ValorNovo = _DescrTipoFone; }

                            _ChangeItems = new List<ChangeItem>();
                            _ChangeItems.Add(_LogIdTipoFone);
                            _ChangeItems.Add(_LogDescrTipoFone);

                            #endregion

                            ExecuteModifyLogStatus(_ChangesHeader, _ChangeItems);
                        }
                    }
                }
            }
        }

        private void ExecuteModifyLogStatus(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }
        private void ExecuteModifyExceptionLogStatus(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void FillLogHeaderFromDeleteModify(string _IdTipoFone, string _DescrTipoFone)
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgTipoFone.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdTipoFoneLogDashboard;
            _ChangesHeader.TipoModificacao = TipoFoneProcess.CreateInstance.FromToModificaTipoFone(ModificaTipoFoneType.TipoFoneExcluir);
            _ChangesHeader.Usuario = this.UsuarioLoginDashboard;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Tipo Fone
            _LogIdTipoFone = new ChangeItem();
            _LogIdTipoFone.IdChangeHeader = _ChangesHeader.Id;
            _LogIdTipoFone.IdItem = 1;
            _LogIdTipoFone.NomeTabela = DboRgTipoFone.NomeTabela;
            _LogIdTipoFone.NomeCampo = DboRgTipoFone.NomeIdTipoFone;
            _LogIdTipoFone.ValorAntigo = _IdTipoFone;

            //Descrição Tipo Fone
            _LogDescrTipoFone = new ChangeItem();
            _LogDescrTipoFone.IdChangeHeader = _ChangesHeader.Id;
            _LogDescrTipoFone.IdItem = 2;
            _LogDescrTipoFone.NomeTabela = DboRgTipoFone.NomeTabela;
            _LogDescrTipoFone.NomeCampo = DboRgTipoFone.NomeDescrTipoFone;
            _LogDescrTipoFone.ValorAntigo = _DescrTipoFone;

            #endregion
        }
        private void tlstrpBtnSearchCriteria_Click(object sender, EventArgs e)
        {
            int _SearchType = 0;
            string _Filter = "";
            int _RgTipoFone = 0;
            string _Descricao = "";
            FilterSearchFormTipoFone _FilterSearchFormTipoFone = null;

            if (dataGridSearchModule.DataSource != null)
            {
                try
                {
                    _FilterSearchFormTipoFone = new FilterSearchFormTipoFone();
                    _FilterSearchFormTipoFone.ShowDialog();
                }
                finally
                {
                    _SearchType = _FilterSearchFormTipoFone.SearchType;

                    switch (_SearchType)
                    {
                        case 0:
                            dataGridSearchModule.DataSource = null;
                            _RgTipoFone = _FilterSearchFormTipoFone.IdTipoFone;
                            AppStateOverallRecord.IdTipoFone = _RgTipoFone;
                            _Filter = string.Format(" where cod_tipo_fone = {0} ", AppStateOverallRecord.IdTipoFone);
                            FillDataGrid(TipoFoneProcess.CreateInstance.TaskGetCollectionRgTipoFoneByFilter(_Filter, 1));
                            break;
                        case 1:
                            dataGridSearchModule.DataSource = null;
                            _Descricao = _FilterSearchFormTipoFone.DescrTipoFone;
                            AppStateOverallRecord.DescrTipoFone = _Descricao.ToUpper();
                            _Filter = string.Format(" where descr_tipo_fone = '%{0}%' ", AppStateOverallRecord.DescrTipoFone);
                            FillDataGrid(TipoFoneProcess.CreateInstance.TaskGetCollectionRgTipoFoneByFilter(_Filter, 1));
                            break;
                    }

                    _FilterSearchFormTipoFone.Dispose();
                }
            }
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, EventArgs e)
        {
            dataGridSearchModule.DataSource = null;
            FillDataGrid(TipoFoneProcess.CreateInstance.TaskGetCollectionRgTipoFoneByFilter("", 0));
        }

        private void SearchFormTipoFone_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                this.AlteraRgTipoFone();
            }
        }
    }

    internal static class DboRgTipoFone
    {
        #region ...::: Private Constantes :::...

        private const string _NomeIdTipoFone = "cod_tipo_fone";
        private const string _NomeDescrTipoFone = "descr_tipo_fone";
        private const string _NomeTabela = "rg_tipo_fone";
        private const string _NomeProcesso = "Tipo Fone";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeIdTipoFone { get { return _NomeIdTipoFone; } }
        public static string NomeDescrTipoFone { get { return _NomeDescrTipoFone; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
