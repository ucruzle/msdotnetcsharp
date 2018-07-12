using BrSoftNet.App.Business.Processes.Manager.Entities;
using BrSoftNet.App.Business.Processes.Manager.Enumerators;
using BrSoftNet.App.Business.Processes.Manager.Tasks;
using BrSoftNet.App.UI.Win.Manager.DialogUpdateForm;
using BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm;
using BrSoftNet.App.UI.Win.Manager.State;
using BrSoftNet.Library.Messages;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Log.Structures;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Manager.FullScreenSearchForm
{
    public partial class SearchFormProcesso : Form
    {
        #region ...::: Private Variable :::...

        private int _CodigoProcesso = 0;
        private string _DescricaoProcesso = string.Empty;
        private int _CodigoTipoProcesso = 0;
        private int _CodigoAplicacao = 0;
        private string _Ativo = string.Empty;
        private string _Form = string.Empty;
        private int _SequenciaProcesso = 0;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpresaFromDashboard { get; set; }

        public int IdProcessoFromDashboard { get; set; }

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

        public SearchFormProcesso()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(ProcessoProcess.CreateInstance.TaskGetCollectionGeProcessoByFilter("", 0));
        }

        private void FillDataGrid(List<GeProcesso> _GeProcessoCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateManager.GeProcessoCollection = _GeProcessoCollection;

                bsGeProcesso.DataSource = AppStateManager.GeProcessoCollection;
                bsGeProcesso.AllowNew = false;

                dataGridSearchModule.DataSource = bsGeProcesso;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["CodigoProcesso"].HeaderText = "Código";
                dataGridSearchModule.Columns["CodigoProcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescricaoProcesso"].HeaderText = "Descrição";
                dataGridSearchModule.Columns["DescricaoProcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoTipoProcesso"].HeaderText = "Tipo Processo";
                dataGridSearchModule.Columns["CodigoTipoProcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoAplicacao"].HeaderText = "Aplicação";
                dataGridSearchModule.Columns["CodigoAplicacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["Ativo"].HeaderText = "Ativo";
                dataGridSearchModule.Columns["Ativo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["Form"].HeaderText = "Form";
                dataGridSearchModule.Columns["Form"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["SequenciaProcesso"].HeaderText = "Sequência";
                dataGridSearchModule.Columns["SequenciaProcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void tlstrpBtnFirst_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeProcesso.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeProcesso.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeProcesso.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeProcesso.MoveLast();
            }
        }

        private void tlstrpBtnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        }

        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AdicionaGeProcesso();
        }

        private void AdicionaGeProcesso()
        {
            UpdateFormProcesso _UpdateFormProcesso = new UpdateFormProcesso();
            _UpdateFormProcesso.ModificaProcessoType = ModificaProcessoType.ProcessoAdicionar;
            _UpdateFormProcesso.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormProcesso.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormProcesso.CodigoProcesso = IdProcessoFromDashboard;
            _UpdateFormProcesso.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoProcessos, FormsMessages.TituloProcessoAcaoProcessosInclusao);

            try
            {
                _UpdateFormProcesso.ShowDialog();
            }
            finally
            {
                _UpdateFormProcesso = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(ProcessoProcess.CreateInstance.TaskGetCollectionGeProcessoByFilter("", 0));
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, System.EventArgs e)
        {
            AlteraGeProcesso();
        }

        private void AlteraGeProcesso()
        {
            string _Filter = string.Empty;

            UpdateFormProcesso _UpdateFormProcesso = new UpdateFormProcesso();
            _UpdateFormProcesso.ModificaProcessoType = ModificaProcessoType.ProcessoAlterar;
            _UpdateFormProcesso.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormProcesso.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormProcesso.CodigoProcesso = IdProcessoFromDashboard;
            _UpdateFormProcesso.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoProcessos, FormsMessages.TituloProcessoAcaoProcessosAlteracao);

            _CodigoProcesso = (int)dataGridSearchModule.CurrentRow.Cells["CodigoProcesso"].Value;
            _DescricaoProcesso = (string)dataGridSearchModule.CurrentRow.Cells["DescricaoProcesso"].Value;
            _CodigoTipoProcesso = (int)dataGridSearchModule.CurrentRow.Cells["CodigoTipoProcesso"].Value;
            _CodigoAplicacao = (int)dataGridSearchModule.CurrentRow.Cells["CodigoAplicacao"].Value;
            _Ativo = (string)dataGridSearchModule.CurrentRow.Cells["Ativo"].Value;
            _Form = (string)dataGridSearchModule.CurrentRow.Cells["Form"].Value;
            _SequenciaProcesso = (int)dataGridSearchModule.CurrentRow.Cells["SequenciaProcesso"].Value;

            _UpdateFormProcesso.CodigoProcesso = _CodigoProcesso;
            _UpdateFormProcesso.DescricaoProcesso = _DescricaoProcesso;
            _UpdateFormProcesso.CodigoTipoProcesso = _CodigoTipoProcesso;
            _UpdateFormProcesso.CodigoAplicacao = _CodigoAplicacao;
            _UpdateFormProcesso.Ativo = _Ativo;
            _UpdateFormProcesso.Form = _Form;
            _UpdateFormProcesso.SequenciaProcesso = _SequenciaProcesso;

            try
            {
                _UpdateFormProcesso.ShowDialog();
            }
            finally
            {
                AppStateManager.CodigoProcesso = _UpdateFormProcesso.CodigoProcesso;

                _Filter = string.Format(" where cod_proc = '{0}' ", AppStateManager.CodigoProcesso);

                _UpdateFormProcesso = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(ProcessoProcess.CreateInstance.TaskGetCollectionGeProcessoByFilter(_Filter, 1));
            }
        }

        private void tlstrpBtnDelete_Click(object sender, System.EventArgs e)
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnDelete_Click";
            string _ModifyType = string.Empty;
            int _CodigoProcesso = 0;

            if (dataGridSearchModule.CurrentRow.Cells["CodigoProcesso"].Value != null)
            {
                if (MessageBox.Show("Deseja excluir este registro?",
                                    UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoProcessos, FormsMessages.TituloProcessoAcaoProcessosExclusao),
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (_ThrowingException != null) { _ThrowingException = null; }
                        _CodigoProcesso = int.Parse(dataGridSearchModule.CurrentRow.Cells["CodigoProcesso"].Value.ToString());
                        _ModifyType = ProcessoProcess.CreateInstance.FromToModificaProcesso(ModificaProcessoType.ProcessoExcluir);
                        ProcessoProcess.CreateInstance.TaskModifyProcessProcesso(_CodigoProcesso, string.Empty, 0, 0, string.Empty, string.Empty, 0, _ModifyType);
                    }
                    catch (Exception _Exception)
                    {
                        throw _Exception;
                    }
                    finally
                    {
                        dataGridSearchModule.DataSource = null;

                        FillDataGrid(ProcessoProcess.CreateInstance.TaskGetCollectionGeProcessoByFilter("", 0));
                    }
                }
            }
        }

        private void tlstrpBtnSearchCriteria_Click(object sender, EventArgs e)
        {
            int _SearchType = 0;
            string _Filter = "";
            int _CodigoProcesso = 0;
            string _DescricaoProcesso = string.Empty;
            int _CodigoTipoProcesso = 0;
            int _CodigoAplicacao = 0;
            string _Ativo = string.Empty;
            string _Form = string.Empty;
            string _SequenciaProcesso = string.Empty;

            FilterSearchFormProcesso _FilterSearchFormProcesso = null;

            if (dataGridSearchModule.DataSource != null)
            {
                try
                {
                    _FilterSearchFormProcesso = new FilterSearchFormProcesso();
                    _FilterSearchFormProcesso.ShowDialog();
                }
                finally
                {
                    _SearchType = _FilterSearchFormProcesso.SearchType;

                    switch (_SearchType)
                    {
                        case 0:
                            dataGridSearchModule.DataSource = null;
                            _CodigoProcesso = _FilterSearchFormProcesso.CodigoProcesso;
                            AppStateManager.CodigoProcesso = _CodigoProcesso;
                            _Filter = string.Format(" where cod_proc = {0} ", AppStateManager.CodigoProcesso);
                            FillDataGrid(ProcessoProcess.CreateInstance.TaskGetCollectionGeProcessoByFilter(_Filter, 1));
                            break;
                        case 1:
                            dataGridSearchModule.DataSource = null;
                            _DescricaoProcesso = _FilterSearchFormProcesso.DescricaoProcesso;
                            AppStateManager.DescricaoProcesso = _DescricaoProcesso.ToUpper();
                            _Filter = string.Format(" where descr_proc = '%{0}%' ", AppStateManager.DescricaoProcesso);
                            FillDataGrid(ProcessoProcess.CreateInstance.TaskGetCollectionGeProcessoByFilter(_Filter, 1));
                            break;
                        case 2:
                            dataGridSearchModule.DataSource = null;
                            _CodigoTipoProcesso = _FilterSearchFormProcesso.CodigoTipoProcesso;
                            AppStateManager.CodigoTipoProcesso = _CodigoTipoProcesso;
                            _Filter = string.Format(" where cod_tipo_proc = {0} ", AppStateManager.CodigoTipoProcesso);
                            FillDataGrid(ProcessoProcess.CreateInstance.TaskGetCollectionGeProcessoByFilter(_Filter, 1));
                            break;
                        case 3:
                            dataGridSearchModule.DataSource = null;
                            _CodigoAplicacao = _FilterSearchFormProcesso.CodigoAplicacao;
                            AppStateManager.CodigoAplicacao = _CodigoAplicacao;
                            _Filter = string.Format(" where cod_aplic = {0} ", AppStateManager.CodigoAplicacao);
                            FillDataGrid(ProcessoProcess.CreateInstance.TaskGetCollectionGeProcessoByFilter(_Filter, 1));
                            break;
                        case 4:
                            dataGridSearchModule.DataSource = null;
                            _Ativo = _FilterSearchFormProcesso.Ativo;
                            AppStateManager.Ativo = _Ativo.ToUpper();
                            _Filter = string.Format(" where ativo = '%{0}%' ", AppStateManager.Ativo);
                            FillDataGrid(ProcessoProcess.CreateInstance.TaskGetCollectionGeProcessoByFilter(_Filter, 1));
                            break;
                        case 5:
                            dataGridSearchModule.DataSource = null;
                            _Form = _FilterSearchFormProcesso.Form;
                            AppStateManager.Form = _Form.ToUpper();
                            _Filter = string.Format(" where form = '%{0}%' ", AppStateManager.Form);
                            FillDataGrid(ProcessoProcess.CreateInstance.TaskGetCollectionGeProcessoByFilter(_Filter, 1));
                            break;
                    }

                    _FilterSearchFormProcesso.Dispose();
                }
            }
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, EventArgs e)
        {
            dataGridSearchModule.DataSource = null;
            FillDataGrid(ProcessoProcess.CreateInstance.TaskGetCollectionGeProcessoByFilter("", 0));
        }

        private void SearchFormProcesso_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                this.AlteraGeProcesso();
            }
        }
    }
}
