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
    public partial class SearchFormEstado : Form
    {
        #region ...::: Private Variable :::...

        private string _UF { get; set; }
        private string _DescrEstado { get; set; }
        private string _SiglaRegiao { get; set; }

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpresaFromDashboard { get; set; }

        public string UsuarioLoginDashboard { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;
        private ChangeItem _LogSiglaEstado = null;
        private ChangeItem _LogDescricao = null;
        private ChangeItem _LogSiglaRegiao = null;
        private List<ChangeItem> _ChangeItems = null;
        private ThrowingException _ThrowingException = null;

        #endregion

        public SearchFormEstado()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(EstadoProcess.CreateInstance.TaskGetCollectionRgEstadoByFilter("", 0));
        }

        private void FillDataGrid(List<RgEstado> _RgEstadoCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateOverallRecord.RgEstadoCollection = _RgEstadoCollection;

                bsRgEstado.DataSource = AppStateOverallRecord.RgEstadoCollection;
                bsRgEstado.AllowNew = false;

                dataGridSearchModule.DataSource = bsRgEstado;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["UF"].HeaderText = "UF";
                dataGridSearchModule.Columns["UF"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescrEstado"].HeaderText = "Descrição";
                dataGridSearchModule.Columns["DescrEstado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["SiglaRegiao"].HeaderText = "Região";
                dataGridSearchModule.Columns["SiglaRegiao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void tlstrpBtnFirst_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgEstado.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgEstado.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgEstado.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgEstado.MoveLast();
            }
        }

        private void tlstrpBtnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        }

        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AdicionaRgEstado();
        }

        private void AdicionaRgEstado()
        {
            UpdateFormEstado _UpdateFormEstado = new UpdateFormEstado();
            _UpdateFormEstado.ModificaEstadoType = ModificaEstadoType.EstadoAdicionar;
            _UpdateFormEstado.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormEstado.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormEstado.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoEstado, FormsMessages.TituloProcessoEstadoAcaoInclusao);

            try
            {
                _UpdateFormEstado.ShowDialog();
            }
            finally
            {
                _UpdateFormEstado = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(EstadoProcess.CreateInstance.TaskGetCollectionRgEstadoByFilter("", 0));
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, System.EventArgs e)
        {
            AlteraRgEstado();
        }

        private void AlteraRgEstado()
        {
            string _Filter = string.Empty;

            UpdateFormEstado _UpdateFormEstado = new UpdateFormEstado();
            _UpdateFormEstado.ModificaEstadoType = ModificaEstadoType.EstadoAlterar;
            _UpdateFormEstado.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormEstado.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormEstado.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoEstado, FormsMessages.TituloProcessoEstadoAcaoAlteracao);

            _UF = (string)dataGridSearchModule.CurrentRow.Cells["UF"].Value;
            _DescrEstado = (string)dataGridSearchModule.CurrentRow.Cells["DescrEstado"].Value;
            _SiglaRegiao = (string)dataGridSearchModule.CurrentRow.Cells["SiglaRegiao"].Value;

            _UpdateFormEstado.SiglaEstado = _UF;
            _UpdateFormEstado.Descricao = _DescrEstado;
            _UpdateFormEstado.SiglaRegiao = _SiglaRegiao;

            try
            {
                _UpdateFormEstado.ShowDialog();
            }
            finally
            {
                AppStateOverallRecord.SiglaEstado = _UpdateFormEstado.SiglaEstado;

                _Filter = string.Format(" where sigla_estado = '{0}' ", AppStateOverallRecord.SiglaEstado);

                _UpdateFormEstado = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(EstadoProcess.CreateInstance.TaskGetCollectionRgEstadoByFilter(_Filter, 1));
            }
        }

        private void tlstrpBtnDelete_Click(object sender, System.EventArgs e)
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnDelete_Click";

            string _ModifyType = string.Empty;
            string _Sigla = string.Empty;
            string _DescrEstado = string.Empty;
            string _SiglaRegiao = string.Empty;

            if (dataGridSearchModule.CurrentRow.Cells["UF"].Value != null)
            {
                if (MessageBox.Show("Deseja excluir este registro?",
                                    UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoEstado, FormsMessages.TituloProcessoEstadoAcaoExclusao), 
                                    MessageBoxButtons.OKCancel, 
                                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (_ThrowingException != null) { _ThrowingException = null; }   
                        _Sigla = (string)dataGridSearchModule.CurrentRow.Cells["UF"].Value;
                        _DescrEstado = (string)dataGridSearchModule.CurrentRow.Cells["DescrEstado"].Value;
                        _SiglaRegiao = (string)dataGridSearchModule.CurrentRow.Cells["SiglaRegiao"].Value;
                        _ModifyType = EstadoProcess.CreateInstance.FromToModificaEstado(ModificaEstadoType.EstadoExcluir);
                        FillLogHeaderFromDeleteModify(_Sigla, _DescrEstado, _SiglaRegiao);
                        EstadoProcess.CreateInstance.TaskModifyProcessEstado(_Sigla, string.Empty, string.Empty, _ModifyType);
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

                        if (_LogSiglaEstado != null) { _LogSiglaEstado.ValorNovo = _Sigla; }
                        if (_LogDescricao != null) { _LogDescricao.ValorNovo = _DescrEstado; }
                        if (_LogSiglaRegiao != null) { _LogSiglaRegiao.ValorNovo = _SiglaRegiao; }

                        _ChangeItems = new List<ChangeItem>();
                        _ChangeItems.Add(_LogSiglaEstado);
                        _ChangeItems.Add(_LogDescricao);
                        _ChangeItems.Add(_LogSiglaRegiao);

                        #endregion

                        ExecuteModifyExceptionLogEstado(_ChangesHeader, _ChangeItems, _ThrowingException);
                    }
                    finally
                    {
                        dataGridSearchModule.DataSource = null;

                        FillDataGrid(EstadoProcess.CreateInstance.TaskGetCollectionRgEstadoByFilter("", 0));

                        if (_ThrowingException == null)
                        {
                            #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                            if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                            #endregion

                            #region ...::: Atualiza os Itens do Log de Modificações :::...

                            if (_LogSiglaEstado != null) { _LogSiglaEstado.ValorNovo = _Sigla; }
                            if (_LogDescricao != null) { _LogDescricao.ValorNovo = _DescrEstado; }
                            if (_LogSiglaRegiao != null) { _LogSiglaRegiao.ValorNovo = _SiglaRegiao; }

                            _ChangeItems = new List<ChangeItem>();
                            _ChangeItems.Add(_LogSiglaEstado);
                            _ChangeItems.Add(_LogDescricao);
                            _ChangeItems.Add(_LogSiglaRegiao);

                            #endregion

                            ExecuteModifyLogEstado(_ChangesHeader, _ChangeItems);
                        }
                    }
                }
            }
        }

        private void ExecuteModifyLogEstado(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }

        private void ExecuteModifyExceptionLogEstado(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void FillLogHeaderFromDeleteModify(string _Sigla, string _DescrEstado, string _SiglaRegiao)
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgEstado.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdEmpresaFromDashboard;
            _ChangesHeader.TipoModificacao = EstadoProcess.CreateInstance.FromToModificaEstado(ModificaEstadoType.EstadoExcluir);
            _ChangesHeader.Usuario = this.UsuarioLoginDashboard;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Sigla Estado
            _LogSiglaEstado = new ChangeItem();
            _LogSiglaEstado.IdChangeHeader = _ChangesHeader.Id;
            _LogSiglaEstado.IdItem = 1;
            _LogSiglaEstado.NomeTabela = DboRgEstado.NomeTabela;
            _LogSiglaEstado.NomeCampo = DboRgEstado.NomeSiglaEstado;
            _LogSiglaEstado.ValorAntigo = _Sigla;

            //Descrição Estado
            _LogDescricao = new ChangeItem();
            _LogDescricao.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricao.IdItem = 2;
            _LogDescricao.NomeTabela = DboRgEstado.NomeTabela;
            _LogDescricao.NomeCampo = DboRgEstado.NomeDescrEstado;
            _LogDescricao.ValorAntigo = _DescrEstado;

            //Sigla Região
            _LogSiglaRegiao = new ChangeItem();
            _LogSiglaRegiao.IdChangeHeader = _ChangesHeader.Id;
            _LogSiglaRegiao.IdItem = 3;
            _LogSiglaRegiao.NomeTabela = DboRgEstado.NomeTabela;
            _LogSiglaRegiao.NomeCampo = DboRgEstado.NomeSiglaRegiao;
            _LogSiglaRegiao.ValorAntigo = _SiglaRegiao;

            #endregion
        }

        private void tlstrpBtnSearchCriteria_Click(object sender, EventArgs e)
        {
            int _SearchType = 0;
            string _Filter = "";
            string _Sigla = "";
            string _Descricao = "";
            string _Regiao = "";
            FilterSearchFormEstado _FilterSearchFormEstado = null;

            if (dataGridSearchModule.DataSource != null)
            {
                try
                {
                    _FilterSearchFormEstado = new FilterSearchFormEstado();
                    _FilterSearchFormEstado.ShowDialog();
                }
                finally
                {
                    _SearchType = _FilterSearchFormEstado.SearchType;

                    switch (_SearchType)
                    {
                        case 0:
                            dataGridSearchModule.DataSource = null;
                            _Sigla = _FilterSearchFormEstado.SiglaEstado;
                            AppStateOverallRecord.SiglaEstado = _Sigla;
                            _Filter = string.Format(" where sigla_estado LIKE '%{0}%' ", AppStateOverallRecord.SiglaEstado);
                            FillDataGrid(EstadoProcess.CreateInstance.TaskGetCollectionRgEstadoByFilter(_Filter, 1));
                            break;
                        case 1:
                            dataGridSearchModule.DataSource = null;
                            _Descricao = _FilterSearchFormEstado.Descricao;
                            AppStateOverallRecord.DescricaoRegiao = _Descricao.ToUpper();
                            _Filter = string.Format(" where descr_estado LIKE '%{0}%' ", AppStateOverallRecord.DescricaoRegiao);
                            FillDataGrid(EstadoProcess.CreateInstance.TaskGetCollectionRgEstadoByFilter(_Filter, 1));
                            break;
                        case 2:
                            dataGridSearchModule.DataSource = null;
                            _Regiao = _FilterSearchFormEstado.SiglaRegiao;
                            AppStateOverallRecord.SiglaRegiao = _Regiao.ToUpper();
                            _Filter = string.Format(" where sigla_regiao LIKE '%{0}%' ", AppStateOverallRecord.SiglaRegiao);
                            FillDataGrid(EstadoProcess.CreateInstance.TaskGetCollectionRgEstadoByFilter(_Filter, 1));
                            break;
                    }

                    _FilterSearchFormEstado.Dispose();
                }
            }
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, EventArgs e)
        {
            dataGridSearchModule.DataSource = null;
            FillDataGrid(EstadoProcess.CreateInstance.TaskGetCollectionRgEstadoByFilter("", 0));
        }

        private void SearchFormEstado_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                this.AlteraRgEstado();
            }
        }
    }

    internal static class DboRgEstado
    {
        #region ...::: Private Constantes :::...

        private const string _NomeSiglaEstado = "sigla_estado";
        private const string _NomeDescrEstado = "descr_estado";
        private const string _NomeSiglaRegiao = "sigla_regiao";
        private const string _NomeTabela = "rg_estado";
        private const string _NomeProcesso = "Estado";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeSiglaEstado { get { return _NomeSiglaEstado; } }
        public static string NomeDescrEstado { get { return _NomeDescrEstado; } }
        public static string NomeSiglaRegiao { get { return _NomeSiglaRegiao; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
