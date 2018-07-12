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
    public partial class SearchFormStatus : Form
    {
        #region ...::: Private Variable :::...

        private int _IdRgStatus = 0;
        private string _DescrStatus = string.Empty;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpresaFromDashboard { get; set; }
        public string UsuarioLoginDashboard { get; set; }
        public int IdStatusLogDashboard { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;

        private ChangeItem _LogIdStatus = null;
        private ChangeItem _LogDescrStatus = null;

        private List<ChangeItem> _ChangeItems = null;

        private ThrowingException _ThrowingException = null;

        #endregion
        public SearchFormStatus()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(StatusProcess.CreateInstance.TaskGetCollectionRgStatusByFilter("", 0));
        }

        private void FillDataGrid(List<RgStatus> _RgStatusCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateOverallRecord.RgStatusCollection = _RgStatusCollection;

                bsRgStatus.DataSource = AppStateOverallRecord.RgStatusCollection;
                bsRgStatus.AllowNew = false;

                dataGridSearchModule.DataSource = bsRgStatus;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["IdRgStatus"].HeaderText = "Status";
                dataGridSearchModule.Columns["IdRgStatus"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescrStatus"].HeaderText = "Descrição";
                dataGridSearchModule.Columns["DescrStatus"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void tlstrpBtnFirst_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgStatus.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgStatus.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgStatus.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgStatus.MoveLast();
            }
        }

        private void tlstrpBtnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        }

        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AdicionaRgStatus();
        }

        private void AdicionaRgStatus()
        {
            UpdateFormStatus _UpdateFormStatus = new UpdateFormStatus();
            _UpdateFormStatus.ModificaStatusType = ModificaStatusType.StatusAdicionar;
            _UpdateFormStatus.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormStatus.IdRgStatus = IdStatusLogDashboard;
            _UpdateFormStatus.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormStatus.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoStatus, FormsMessages.TituloProcessoAcaoStatusInclusao);

            try
            {
                _UpdateFormStatus.ShowDialog();
            }
            finally
            {
                _UpdateFormStatus = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(StatusProcess.CreateInstance.TaskGetCollectionRgStatusByFilter("", 0));
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, System.EventArgs e)
        {
            AlteraRgStatus();
        }

        private void AlteraRgStatus()
        {
            string _Filter = string.Empty;

            UpdateFormStatus _UpdateFormStatus = new UpdateFormStatus();
            _UpdateFormStatus.ModificaStatusType = ModificaStatusType.StatusAlterar;
            _UpdateFormStatus.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormStatus.IdRgStatus = IdStatusLogDashboard;
            _UpdateFormStatus.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormStatus.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoStatus, FormsMessages.TituloProcessoAcaoStatusAlteracao);

            _IdRgStatus = (int)dataGridSearchModule.CurrentRow.Cells["IdRgStatus"].Value;
            _DescrStatus = (string)dataGridSearchModule.CurrentRow.Cells["DescrStatus"].Value;

            _UpdateFormStatus.IdRgStatus = _IdRgStatus;
            _UpdateFormStatus.DescrStatus = _DescrStatus;

            try
            {
                _UpdateFormStatus.ShowDialog();
            }
            finally
            {
                AppStateOverallRecord.IdRgStatus = _UpdateFormStatus.IdRgStatus;

                _Filter = string.Format(" where cod_status = '{0}' ", AppStateOverallRecord.IdRgStatus);

                _UpdateFormStatus = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(StatusProcess.CreateInstance.TaskGetCollectionRgStatusByFilter(_Filter, 1));
            }
        }

        private void tlstrpBtnDelete_Click(object sender, System.EventArgs e)
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnDelete_Click";

            string _ModifyType = string.Empty;
            int _IdRgStatus = 0;
            string _DescrStatus = string.Empty;

            if (dataGridSearchModule.CurrentRow.Cells["IdRgStatus"].Value != null)
            {
                if (MessageBox.Show("Deseja excluir este registro?",
                                    UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoStatus, FormsMessages.TituloProcessoAcaoStatusExclusao),
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (_ThrowingException != null) { _ThrowingException = null; }  
                        _IdRgStatus = (int)dataGridSearchModule.CurrentRow.Cells["IdRgStatus"].Value;
                        _DescrStatus = (string)dataGridSearchModule.CurrentRow.Cells["DescrStatus"].Value;
                        _ModifyType = StatusProcess.CreateInstance.FromToModificaStatus(ModificaStatusType.StatusExcluir);
                        StatusProcess.CreateInstance.TaskModifyProcessStatus(_IdRgStatus, string.Empty, _ModifyType);
                        FillLogHeaderFromDeleteModify(Convert.ToString(_IdRgStatus), _DescrStatus);
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

                        if (_LogIdStatus != null) { _LogIdStatus.ValorNovo = _IdRgStatus; }
                        if (_LogDescrStatus != null) { _LogDescrStatus.ValorNovo = _DescrStatus; }

                        _ChangeItems = new List<ChangeItem>();
                        _ChangeItems.Add(_LogIdStatus);
                        _ChangeItems.Add(_LogDescrStatus);

                        #endregion

                        ExecuteModifyExceptionLogStatus(_ChangesHeader, _ChangeItems, _ThrowingException);
                    }
                    finally
                    {
                        dataGridSearchModule.DataSource = null;

                        FillDataGrid(StatusProcess.CreateInstance.TaskGetCollectionRgStatusByFilter("", 0));

                        if (_ThrowingException == null)
                        {
                            #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                            if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                            #endregion

                            #region ...::: Atualiza os Itens do Log de Modificações :::...

                            if (_LogIdStatus != null) { _LogIdStatus.ValorNovo = _IdRgStatus; }
                            if (_LogDescrStatus != null) { _LogDescrStatus.ValorNovo = _DescrStatus; }

                            _ChangeItems = new List<ChangeItem>();
                            _ChangeItems.Add(_LogIdStatus);
                            _ChangeItems.Add(_LogDescrStatus);

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

        private void FillLogHeaderFromDeleteModify(string _IdRgStatus, string _DescrStatus)
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgStatus.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdStatusLogDashboard;
            _ChangesHeader.TipoModificacao = StatusProcess.CreateInstance.FromToModificaStatus(ModificaStatusType.StatusExcluir);
            _ChangesHeader.Usuario = this.UsuarioLoginDashboard;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Status
            _LogIdStatus = new ChangeItem();
            _LogIdStatus.IdChangeHeader = _ChangesHeader.Id;
            _LogIdStatus.IdItem = 1;
            _LogIdStatus.NomeTabela = DboRgStatus.NomeTabela;
            _LogIdStatus.NomeCampo = DboRgStatus.NomeIdStatus;
            _LogIdStatus.ValorAntigo = _IdRgStatus;

            //Descrição Status
            _LogDescrStatus = new ChangeItem();
            _LogDescrStatus.IdChangeHeader = _ChangesHeader.Id;
            _LogDescrStatus.IdItem = 2;
            _LogDescrStatus.NomeTabela = DboRgStatus.NomeTabela;
            _LogDescrStatus.NomeCampo = DboRgStatus.NomeDescrStatus;
            _LogDescrStatus.ValorAntigo = _DescrStatus;

            #endregion
        }
        private void tlstrpBtnSearchCriteria_Click(object sender, EventArgs e)
        {
            int _SearchType = 0;
            string _Filter = "";
            int _IdRgStatus = 0;
            string _Descricao = "";
            FilterSearchFormStatus _FilterSearchFormStatus = null;

            if (dataGridSearchModule.DataSource != null)
            {
                try
                {
                    _FilterSearchFormStatus = new FilterSearchFormStatus();
                    _FilterSearchFormStatus.ShowDialog();
                }
                finally
                {
                    _SearchType = _FilterSearchFormStatus.SearchType;

                    switch (_SearchType)
                    {
                        case 0:
                            dataGridSearchModule.DataSource = null;
                            _IdRgStatus = _FilterSearchFormStatus.IdRgStatus;
                            AppStateOverallRecord.IdRgStatus = _IdRgStatus;
                            _Filter = string.Format(" where cod_status = {0} ", AppStateOverallRecord.IdRgStatus);
                            FillDataGrid(StatusProcess.CreateInstance.TaskGetCollectionRgStatusByFilter(_Filter, 1));
                            break;
                        case 1:
                            dataGridSearchModule.DataSource = null;
                            _Descricao = _FilterSearchFormStatus.DescrStatus;
                            AppStateOverallRecord.DescrStatus = _Descricao.ToUpper();
                            _Filter = string.Format(" where descr_status = '%{0}%' ", AppStateOverallRecord.DescrStatus);
                            FillDataGrid(StatusProcess.CreateInstance.TaskGetCollectionRgStatusByFilter(_Filter, 1));
                            break;
                    }

                    _FilterSearchFormStatus.Dispose();
                }
            }
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, EventArgs e)
        {
            dataGridSearchModule.DataSource = null;
            FillDataGrid(StatusProcess.CreateInstance.TaskGetCollectionRgStatusByFilter("", 0));
        }

        private void SearchFormStatus_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                this.AlteraRgStatus();
            }
        }
    }

    internal static class DboRgStatus
    {
        #region ...::: Private Constantes :::...

        private const string _NomeIdStatus = "cod_status";
        private const string _NomeDescrStatus = "descr_status";
        private const string _NomeTabela = "rg_status";
        private const string _NomeProcesso = "Status";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeIdStatus { get { return _NomeIdStatus; } }
        public static string NomeDescrStatus { get { return _NomeDescrStatus; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
