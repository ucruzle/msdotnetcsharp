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
    public partial class SearchFormGrupoProcesso : Form
    {
        #region ...::: Private Variable :::...

        private int _CodigoEmpresa = 0;
        private int _CodigoGrupo = 0;
        private int _CodigoProcesso = 0;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpresaFromDashboard { get; set; }

        public string UsuarioLoginDashboard { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        public SearchFormGrupoProcesso()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.tlstrpBtnDelete.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(GrupoProcessoProcess.CreateInstance.TaskGetCollectionGeGrupoProcessoByFilter("", 0));
        }

        private void FillDataGrid(List<GrupoProcessoPorFiltro> _GeGrupoProcessoCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateManager.GeGrupoProcessoCollection = _GeGrupoProcessoCollection;

                bsGeGrupoProcesso.DataSource = AppStateManager.GeGrupoProcessoCollection;
                bsGeGrupoProcesso.AllowNew = false;

                dataGridSearchModule.DataSource = bsGeGrupoProcesso;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["CodigoEmpresa"].HeaderText = "Cod.Empresa";
                dataGridSearchModule.Columns["CodigoEmpresa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescricaoEmpresa"].HeaderText = "Desc.Empresa";
                dataGridSearchModule.Columns["DescricaoEmpresa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoAplicacao"].HeaderText = "Cod.Aplicação";
                dataGridSearchModule.Columns["CodigoAplicacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescricaoAplicacao"].HeaderText = "Desc.Aplicação";
                dataGridSearchModule.Columns["DescricaoAplicacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoGrupo"].HeaderText = "Cod.Grupo";
                dataGridSearchModule.Columns["CodigoGrupo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescricaoGrupo"].HeaderText = "Desc.Grupo";
                dataGridSearchModule.Columns["DescricaoGrupo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoTipoProcesso"].HeaderText = "Cod.Tp.Proc";
                dataGridSearchModule.Columns["CodigoTipoProcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescricaoTipoProcesso"].HeaderText = "Desc.Tp.Proc";
                dataGridSearchModule.Columns["DescricaoTipoProcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoProcesso"].HeaderText = "Cod.Processo";
                dataGridSearchModule.Columns["CodigoProcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescricaoProcesso"].HeaderText = "Desc.Processo";
                dataGridSearchModule.Columns["DescricaoProcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void tlstrpBtnFirst_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeGrupoProcesso.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeGrupoProcesso.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeGrupoProcesso.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeGrupoProcesso.MoveLast();
            }
        }

        private void tlstrpBtnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        }

        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AdicionaGeGrupoProcesso();
        }

        private void AdicionaGeGrupoProcesso()
        {
            UpdateFormGrupoProcesso _UpdateFormGrupoProcesso = new UpdateFormGrupoProcesso();
            _UpdateFormGrupoProcesso.ModificaGrupoProcessoType = ModificaGrupoProcessoType.GrupoProcessoAdicionar;
            _UpdateFormGrupoProcesso.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormGrupoProcesso.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormGrupoProcesso.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoGrupoProcesso, FormsMessages.TituloProcessoAcaoGrupoProcessoInclusao);

            try
            {
                _UpdateFormGrupoProcesso.ShowDialog();
            }
            finally
            {
                _UpdateFormGrupoProcesso = null;

                dataGridSearchModule.DataSource = null;

                //FillDataGrid(GrupoProcessoProcess.CreateInstance.TaskGetCollectionGeGrupoProcessoByFilter("", 0));
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, System.EventArgs e)
        {
            AlteraGeGrupoProcesso();
        }

        private void AlteraGeGrupoProcesso()
        {
            string _Filter = string.Empty;

            if (bsGeGrupoProcesso.DataSource != null)
            {
                if (dataGridSearchModule.CurrentRow.Cells["CodigoEmpresa"].Value != null &&
                    dataGridSearchModule.CurrentRow.Cells["CodigoGrupo"].Value != null &&
                    dataGridSearchModule.CurrentRow.Cells["CodigoProcesso"].Value != null)
                {
                    UpdateFormGrupoProcesso _UpdateFormGrupoProcesso = new UpdateFormGrupoProcesso();
                    _UpdateFormGrupoProcesso.ModificaGrupoProcessoType = ModificaGrupoProcessoType.GrupoProcessoAlterar;
                    _UpdateFormGrupoProcesso.IdEmpr = IdEmpresaFromDashboard;
                    _UpdateFormGrupoProcesso.UsuarioLogin = UsuarioLoginDashboard;
                    _UpdateFormGrupoProcesso.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoGrupoProcesso, FormsMessages.TituloProcessoAcaoGrupoProcessoAlteracao);

                    _UpdateFormGrupoProcesso.CodigoEmpresa = (int)dataGridSearchModule.CurrentRow.Cells["CodigoEmpresa"].Value;
                    _UpdateFormGrupoProcesso.CodigoGrupo = (int)dataGridSearchModule.CurrentRow.Cells["CodigoGrupo"].Value;
                    _UpdateFormGrupoProcesso.CodigoAplicacao = (int)dataGridSearchModule.CurrentRow.Cells["CodigoProcesso"].Value;

                    try
                    {
                        _UpdateFormGrupoProcesso.ShowDialog();
                    }
                    finally
                    {
                        AppStateManager.CodigoEmpresa = _UpdateFormGrupoProcesso.CodigoEmpresa;
                        AppStateManager.CodigoGrupo = _UpdateFormGrupoProcesso.CodigoGrupo;
                        AppStateManager.CodigoProcesso = _UpdateFormGrupoProcesso.CodigoAplicacao;

                        _Filter = string.Format(" where cod_empr = '{0}' and cod_grupo = '{1}' and cod_proc = '{2}' ", AppStateManager.CodigoEmpresa, AppStateManager.CodigoGrupo, AppStateManager.CodigoProcesso);

                        _UpdateFormGrupoProcesso = null;

                        dataGridSearchModule.DataSource = null;

                        //FillDataGrid(GrupoProcessoProcess.CreateInstance.TaskGetCollectionGeGrupoProcessoByFilter(_Filter, 1));
                    }
                }
            }
        }

        private void tlstrpBtnSearchCriteria_Click(object sender, EventArgs e)
        {
            int _SearchType = 0;
            string _Filter = "";
            int _CodigoEmpresa = 0;
            int _CodigoGrupo = 0;
            int _CodigoProcesso = 0;
            FilterSearchFormGrupoProcesso _FilterSearchFormGrupoProcesso = null;

            if (dataGridSearchModule.DataSource != null)
            {
                try
                {
                    _FilterSearchFormGrupoProcesso = new FilterSearchFormGrupoProcesso();
                    _FilterSearchFormGrupoProcesso.ShowDialog();
                }
                finally
                {
                    _SearchType = _FilterSearchFormGrupoProcesso.SearchType;

                    switch (_SearchType)
                    {
                        case 0:
                            dataGridSearchModule.DataSource = null;
                            _CodigoEmpresa = _FilterSearchFormGrupoProcesso.CodigoEmpresa;
                            AppStateManager.CodigoEmpresa = _CodigoEmpresa;
                            _Filter = string.Format(" where cod_empr = {0} ", AppStateManager.CodigoEmpresa);
                            FillDataGrid(GrupoProcessoProcess.CreateInstance.TaskGetCollectionGeGrupoProcessoByFilter(_Filter, 1));
                            break;
                        case 1:
                            dataGridSearchModule.DataSource = null;
                            _CodigoGrupo = _FilterSearchFormGrupoProcesso.CodigoGrupo;
                            AppStateManager.CodigoGrupo = _CodigoGrupo;
                            _Filter = string.Format(" where cod_grupo = {0} ", AppStateManager.CodigoGrupo);
                            FillDataGrid(GrupoProcessoProcess.CreateInstance.TaskGetCollectionGeGrupoProcessoByFilter(_Filter, 1));
                            break;
                        case 2:
                            dataGridSearchModule.DataSource = null;
                            _CodigoProcesso = _FilterSearchFormGrupoProcesso.CodigoProcesso;
                            AppStateManager.CodigoProcesso = _CodigoProcesso;
                            _Filter = string.Format(" where cod_proc = {0} ", AppStateManager.CodigoProcesso);
                            FillDataGrid(GrupoProcessoProcess.CreateInstance.TaskGetCollectionGeGrupoProcessoByFilter(_Filter, 1));
                            break;
                    }

                    _FilterSearchFormGrupoProcesso.Dispose();
                }
            }
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, EventArgs e)
        {
            dataGridSearchModule.DataSource = null;
            FillDataGrid(GrupoProcessoProcess.CreateInstance.TaskGetCollectionGeGrupoProcessoByFilter("", 0));
        }

        private void SearchFormGrupoProcesso_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                this.AlteraGeGrupoProcesso();
            }
        }
    }
}
