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
    public partial class SearchFormRegiao : Form
    {
        #region ...::: Private Variable :::...

        private string _SiglaRegiao = string.Empty;
        private string _DescrRegiao = string.Empty;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpresaFromDashboard { get; set; }

        public string UsuarioLoginDashboard { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;
        private ChangeItem _LogSiglaRegiao = null;
        private ChangeItem _LogDescricaoRegiao = null;
        private List<ChangeItem> _ChangeItems = null;
        private ThrowingException _ThrowingException = null;

        #endregion

        public SearchFormRegiao()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(RegionProcess.CreateInstance.TaskGetCollectionRgRegiaoByFilter("", 0));
        }

        private void FillDataGrid(List<RgRegiao> _RgRegiaoCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateOverallRecord.RgRegiaoCollection = _RgRegiaoCollection;

                bsRgRegiao.DataSource = AppStateOverallRecord.RgRegiaoCollection;
                bsRgRegiao.AllowNew = false;

                dataGridSearchModule.DataSource = bsRgRegiao;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["SiglaRegiao"].HeaderText = "Sigla";
                dataGridSearchModule.Columns["SiglaRegiao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescrRegiao"].HeaderText = "Descrição";
                dataGridSearchModule.Columns["DescrRegiao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void tlstrpBtnFirst_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgRegiao.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgRegiao.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgRegiao.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgRegiao.MoveLast();
            }
        }

        private void tlstrpBtnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        }

        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AdicionaRgRegiao();
        }

        private void AdicionaRgRegiao()
        {
            UpdateFormRegiao _UpdateFormRegiao = new UpdateFormRegiao();
            _UpdateFormRegiao.ModificaRegiaoType = ModificaRegiaoType.RegiaoAdicionar;
            _UpdateFormRegiao.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormRegiao.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormRegiao.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoRegiao, FormsMessages.TituloProcessoAcaoParametroRgInclusao);

            try
            {
                _UpdateFormRegiao.ShowDialog();
            }
            finally
            {
                _UpdateFormRegiao = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(RegionProcess.CreateInstance.TaskGetCollectionRgRegiaoByFilter("", 0));
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, System.EventArgs e)
        {
            AlteraRgRegiao();
        }

        private void AlteraRgRegiao()
        {
            string _Filter = string.Empty;

            UpdateFormRegiao _UpdateFormRegiao = new UpdateFormRegiao();
            _UpdateFormRegiao.ModificaRegiaoType = ModificaRegiaoType.RegiaoAlterar;
            _UpdateFormRegiao.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormRegiao.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormRegiao.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoRegiao, FormsMessages.TituloProcessoAcaoParametroRgAlteracao);

            _SiglaRegiao = (string)dataGridSearchModule.CurrentRow.Cells["SiglaRegiao"].Value;
            _DescrRegiao = (string)dataGridSearchModule.CurrentRow.Cells["DescrRegiao"].Value;

            _UpdateFormRegiao.Sigla = _SiglaRegiao;
            _UpdateFormRegiao.Descricao = _DescrRegiao;

            try
            {
                _UpdateFormRegiao.ShowDialog();
            }
            finally
            {
                AppStateOverallRecord.SiglaRegiao = _UpdateFormRegiao.Sigla;

                _Filter = string.Format(" where sigla_regiao = '{0}' ", AppStateOverallRecord.SiglaRegiao);

                _UpdateFormRegiao = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(RegionProcess.CreateInstance.TaskGetCollectionRgRegiaoByFilter(_Filter, 1));
            }
        }

        private void tlstrpBtnDelete_Click(object sender, System.EventArgs e)
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnDelete_Click";

            string _ModifyType = string.Empty;
            string _Sigla = string.Empty;
            string _DescrRegiao = string.Empty;

            if (dataGridSearchModule.CurrentRow.Cells["SiglaRegiao"].Value != null)
            {
                if (MessageBox.Show("Deseja excluir este registro?",
                                    UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoRegiao, FormsMessages.TituloProcessoAcaoParametroRgExclusao),
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (_ThrowingException != null) { _ThrowingException = null; }
                        _Sigla = (string)dataGridSearchModule.CurrentRow.Cells["SiglaRegiao"].Value;
                        _DescrRegiao = (string)dataGridSearchModule.CurrentRow.Cells["DescrRegiao"].Value;
                        _ModifyType = RegionProcess.CreateInstance.FromToModificaRegiao(ModificaRegiaoType.RegiaoExcluir);
                        FillLogHeaderFromDeleteModify(_Sigla, _DescrRegiao);
                        RegionProcess.CreateInstance.TaskModifyProcessRegiao(_Sigla, string.Empty, _ModifyType);
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

                        if (_LogSiglaRegiao != null) { _LogSiglaRegiao.ValorNovo = _Sigla; }
                        if (_LogDescricaoRegiao != null) { _LogDescricaoRegiao.ValorNovo = _DescrRegiao; }

                        _ChangeItems = new List<ChangeItem>();
                        _ChangeItems.Add(_LogSiglaRegiao);
                        _ChangeItems.Add(_LogDescricaoRegiao);

                        #endregion

                        ExecuteModifyExceptionLogRegiao(_ChangesHeader, _ChangeItems, _ThrowingException);
                    }
                    finally
                    {
                        dataGridSearchModule.DataSource = null;

                        FillDataGrid(RegionProcess.CreateInstance.TaskGetCollectionRgRegiaoByFilter("", 0));
                        if (_ThrowingException == null)
                        {
                            #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                            if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                            #endregion

                            #region ...::: Atualiza os Itens do Log de Modificações :::...

                            if (_LogSiglaRegiao != null) { _LogSiglaRegiao.ValorNovo = _Sigla; }
                            if (_LogDescricaoRegiao != null) { _LogDescricaoRegiao.ValorNovo = _DescrRegiao; }

                            _ChangeItems = new List<ChangeItem>();
                            _ChangeItems.Add(_LogSiglaRegiao);
                            _ChangeItems.Add(_LogDescricaoRegiao);

                            #endregion

                            ExecuteModifyLogRegiao(_ChangesHeader, _ChangeItems);
                        }
                    }
                }
            }
        }

        private void ExecuteModifyLogRegiao(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }

        private void ExecuteModifyExceptionLogRegiao(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void FillLogHeaderFromDeleteModify(string _Sigla, string _DescrRegiao)
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgRegiao.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdEmpresaFromDashboard;
            _ChangesHeader.TipoModificacao = RegionProcess.CreateInstance.FromToModificaRegiao(ModificaRegiaoType.RegiaoExcluir);
            _ChangesHeader.Usuario = this.UsuarioLoginDashboard;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Sigla Região
            _LogSiglaRegiao = new ChangeItem();
            _LogSiglaRegiao.IdChangeHeader = _ChangesHeader.Id;
            _LogSiglaRegiao.IdItem = 1;
            _LogSiglaRegiao.NomeTabela = DboRgRegiao.NomeTabela;
            _LogSiglaRegiao.NomeCampo = DboRgRegiao.NomeSiglaRegiao;
            _LogSiglaRegiao.ValorAntigo = _Sigla;

            //Descrição Região
            _LogDescricaoRegiao = new ChangeItem();
            _LogDescricaoRegiao.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricaoRegiao.IdItem = 2;
            _LogDescricaoRegiao.NomeTabela = DboRgRegiao.NomeTabela;
            _LogDescricaoRegiao.NomeCampo = DboRgRegiao.NomeDescrRegiao;
            _LogDescricaoRegiao.ValorAntigo = _DescrRegiao;

            #endregion
        }
        private void tlstrpBtnSearchCriteria_Click(object sender, EventArgs e)
        {
            int _SearchType = 0;
            string _Filter = "";
            string _Sigla = "";
            string _Descricao = "";
            FilterSearchFormRegiao _FilterSearchFormRegiao = null;

            if (dataGridSearchModule.DataSource != null)
            {
                try
                {
                    _FilterSearchFormRegiao = new FilterSearchFormRegiao();
                    _FilterSearchFormRegiao.ShowDialog();
                }
                finally
                {
                    _SearchType = _FilterSearchFormRegiao.SearchType;

                    switch (_SearchType)
                    {
                        case 0:
                            dataGridSearchModule.DataSource = null;
                            _Sigla = _FilterSearchFormRegiao.Sigla;
                            AppStateOverallRecord.SiglaRegiao = _Sigla;
                            _Filter = string.Format(" where sigla_regiao = '%{0}%' ", AppStateOverallRecord.SiglaRegiao);
                            FillDataGrid(RegionProcess.CreateInstance.TaskGetCollectionRgRegiaoByFilter(_Filter, 1));
                            break;
                        case 1:
                            dataGridSearchModule.DataSource = null;
                            _Descricao = _FilterSearchFormRegiao.Descricao;
                            AppStateOverallRecord.DescricaoRegiao = _Descricao.ToUpper();
                            _Filter = string.Format(" where descr_regiao = '%{0}%' ", AppStateOverallRecord.DescricaoRegiao);
                            FillDataGrid(RegionProcess.CreateInstance.TaskGetCollectionRgRegiaoByFilter(_Filter, 1));
                            break;
                    }

                    _FilterSearchFormRegiao.Dispose();
                }
            }
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, EventArgs e)
        {
            dataGridSearchModule.DataSource = null;
            FillDataGrid(RegionProcess.CreateInstance.TaskGetCollectionRgRegiaoByFilter("", 0));
        }

        private void SearchFormRegiao_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                this.AlteraRgRegiao();
            }
        }
    }

    internal static class DboRgRegiao
    {
        #region ...::: Private Constantes :::...

        private const string _NomeSiglaRegiao = "sigla_regiao";
        private const string _NomeDescrRegiao = "descr_regiao";
        private const string _NomeTabela = "rg_regiao";
        private const string _NomeProcesso = "Regiao";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeSiglaRegiao { get { return _NomeSiglaRegiao; } }
        public static string NomeDescrRegiao { get { return _NomeDescrRegiao; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
