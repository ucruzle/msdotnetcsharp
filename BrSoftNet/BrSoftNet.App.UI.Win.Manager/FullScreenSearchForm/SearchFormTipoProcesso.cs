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
    public partial class SearchFormTipoProcesso : Form
    {
        #region ...::: Private Variable :::...

        private int _CodigoTipoProcesso = 0;
        private string _DescTipoProcesso = string.Empty;
        private int _SequenciaTipoProcesso = 0;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpresaFromDashboard { get; set; }

        public string UsuarioLoginDashboard { get; set; }

        public int IdTipoProcessoFromDashboard { get; set; }

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
        public SearchFormTipoProcesso()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(TipoProcessoProcess.CreateInstance.TaskGetCollectionGeTipoProcessoByFilter("", 0));

        }

        private void FillDataGrid(List<GeTipoProcesso> _GeTipoProcessoCollection)
        {

            if (dataGridSearchModule.DataSource == null) //verifica se o Data Grid esta vazio
            {
                AppStateManager.GeTipoProcessoCollection = _GeTipoProcessoCollection;

                bsGeTipoProcesso.DataSource = AppStateManager.GeTipoProcessoCollection;
                bsGeTipoProcesso.AllowNew = false;

                dataGridSearchModule.DataSource = bsGeTipoProcesso;
                dataGridSearchModule.ReadOnly = true; //Bloqueia o Data Grid para somente leitura

                dataGridSearchModule.Columns["CodigoTipoProcesso"].HeaderText = "Código Processo";
                dataGridSearchModule.Columns["CodigoTipoProcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
             

                dataGridSearchModule.Columns["DescricaoTipoProcesso"].HeaderText = "Descrição Processo";
                dataGridSearchModule.Columns["DescricaoTipoProcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["SequequenciaTipoProcesso"].HeaderText = "Sequência Processo";
                dataGridSearchModule.Columns["SequequenciaTipoProcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
             
            }
        }

        private void tlstrpBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        
        }

        private void tlstrpBtnLast_Click(object sender, EventArgs e)
        {
              if (dataGridSearchModule.DataSource != null)
            {
                bsGeTipoProcesso.MoveLast();
            }
        }

        private void tlstrpBtnNext_Click(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeTipoProcesso.MoveNext();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeTipoProcesso.MovePrevious();
            }
        }

        private void tlstrpBtnFirst_Click(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeTipoProcesso.MoveFirst();
            }
        }

        private void tlstrpBtnSearchCriteria_Click(object sender, EventArgs e)
        {
            //Declaração de variaveis
            int _SearchType = 0; 
            string _Filter = "";
            int _CodigoTipoProcesso = 0;
            string _DecricaoTipoProcesso = string.Empty;
            int _SequenciaTipoProcesso = 0;
            FilterSearchFormTipoProcesso _FilterSearchFormTipoProcesso = null;

            if (dataGridSearchModule.DataSource != null)//Verifica conteudo do data grid
            {
                try
                {
                    _FilterSearchFormTipoProcesso = new FilterSearchFormTipoProcesso();//Cria objeto 
                    _FilterSearchFormTipoProcesso.ShowDialog();//Faz chamada do objedo
                }
                finally
                {
                    _SearchType = _FilterSearchFormTipoProcesso.SearchType;

                    switch (_SearchType)
                    {
                        case 0:
                            dataGridSearchModule.DataSource = null;
                            _CodigoTipoProcesso = _FilterSearchFormTipoProcesso.CodigoTipoProcesso;
                            AppStateManager.CodigoTipoProcesso = _CodigoTipoProcesso;
                            _Filter = string.Format(" Where cod_tipo_proc = {0} ", AppStateManager.CodigoTipoProcesso);
                            FillDataGrid(TipoProcessoProcess.CreateInstance.TaskGetCollectionGeTipoProcessoByFilter(_Filter, 1));
                            break;
                        case 1:
                            dataGridSearchModule.DataSource = null;
                            _DecricaoTipoProcesso = _FilterSearchFormTipoProcesso.DescricaoTipoProcesso;
                            AppStateManager.DescricaoTipoProcesso = _DecricaoTipoProcesso;
                            _Filter = string.Format (" Where descr_tipo_proc LIKE '%{0}%' ", AppStateManager.DescricaoTipoProcesso);
                            FillDataGrid(TipoProcessoProcess.CreateInstance.TaskGetCollectionGeTipoProcessoByFilter(_Filter, 1));
                            break;
                        case 2:
                             dataGridSearchModule.DataSource = null;
                            _SequenciaTipoProcesso = _FilterSearchFormTipoProcesso.SequenciaTipoProcesso;
                            AppStateManager.SequenciaTipoProcesso = _SequenciaTipoProcesso;
                            _Filter = string.Format (" Where sequ_tipo_proc = {0} ", AppStateManager.SequenciaTipoProcesso);
                            FillDataGrid(TipoProcessoProcess.CreateInstance.TaskGetCollectionGeTipoProcessoByFilter(_Filter, 1));
                            break;
                    }

                    _FilterSearchFormTipoProcesso.Dispose();
                }

            }
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, EventArgs e)
        {
            ClearFilter();
        }

        private void ClearFilter()
        {
            dataGridSearchModule.DataSource = null;
            FillDataGrid(TipoProcessoProcess.CreateInstance.TaskGetCollectionGeTipoProcessoByFilter("", 0));
        }

        private void tlstrpBtnAdd_Click(object sender, EventArgs e)
        {
            AddTypeProcess();
            
        }

        private void AddTypeProcess()
        {
            UpdateFormTipoProcesso _updateFormTipoProcesso = new UpdateFormTipoProcesso();
            _updateFormTipoProcesso.ModificaTipoProcessoType = ModificaTipoProcessoType.TipoProcessoAdicionar;
            _updateFormTipoProcesso.IdEmpr = IdEmpresaFromDashboard;
            _updateFormTipoProcesso.CodigoTipoProcesso = IdTipoProcessoFromDashboard;
            _updateFormTipoProcesso.UsuarioLogin = UsuarioLoginDashboard;
            _updateFormTipoProcesso.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoTipoProcessos, FormsMessages.TituloProcessoAcaoTipoProcessosInclusao);

            try
            {
                _updateFormTipoProcesso.ShowDialog();
               
            }
            finally
            {
                _updateFormTipoProcesso = null;
                dataGridSearchModule.DataSource = null;
                FillDataGrid(TipoProcessoProcess.CreateInstance.TaskGetCollectionGeTipoProcessoByFilter("", 0));
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateTypeProcess();
        }

        private void UpdateTypeProcess()
        {
            int _CodigoTipoProcesso = 0;
            string _DescricaoTipoProcesso = string.Empty;
            int _SequenciaTipoProcesso = 0;

            UpdateFormTipoProcesso _updateFormTipoProcesso = new UpdateFormTipoProcesso();
            _updateFormTipoProcesso.ModificaTipoProcessoType = ModificaTipoProcessoType.TipoProcessoAlterar;
            _updateFormTipoProcesso.IdEmpr = IdEmpresaFromDashboard;
            _updateFormTipoProcesso.CodigoTipoProcesso = IdTipoProcessoFromDashboard;
            _updateFormTipoProcesso.UsuarioLogin = UsuarioLoginDashboard;
            _updateFormTipoProcesso.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoTipoProcessos, FormsMessages.TituloProcessoAcaoTipoProcessosAlteracao);

            _CodigoTipoProcesso = Convert.ToInt32(dataGridSearchModule.CurrentRow.Cells["CodigoTipoProcesso"].Value);
            _DescricaoTipoProcesso = (string)dataGridSearchModule.CurrentRow.Cells["DescricaoTipoProcesso"].Value;
            _SequenciaTipoProcesso = Convert.ToInt32(dataGridSearchModule.CurrentRow.Cells["SequequenciaTipoProcesso"].Value);

            _updateFormTipoProcesso.CodigoTipoProcesso = _CodigoTipoProcesso;
            _updateFormTipoProcesso.DescricaoTipoProcesso = _DescricaoTipoProcesso;
            _updateFormTipoProcesso.SequenciaTipoProcesso = _SequenciaTipoProcesso;

            try
            {
                _updateFormTipoProcesso.ShowDialog();

            }
            finally
            {
                _updateFormTipoProcesso = null;
                dataGridSearchModule.DataSource = null;
                FillDataGrid(TipoProcessoProcess.CreateInstance.TaskGetCollectionGeTipoProcessoByFilter("", 0));
            }
        }

        private void tlstrpBtnDelete_Click(object sender, EventArgs e)
        {
            DeleteTypeProcess();
        }

        private void DeleteTypeProcess()
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnDelete_Click";
            string _ModifyType = string.Empty;
            int _CodigoTipoProcesso = 0;
            int _IdExecute = 0;

            if (dataGridSearchModule.CurrentRow.Cells["CodigoTipoProcesso"].Value != null)
            {
                if (MessageBox.Show("Deseja excluir este registro?",
                                    UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoTipoProcessos, FormsMessages.TituloProcessoAcaoTipoProcessosExclusao),
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (_ThrowingException != null) { _ThrowingException = null; }
                        _CodigoTipoProcesso = Convert.ToInt32(dataGridSearchModule.CurrentRow.Cells["CodigoTipoProcesso"].Value);
                        _ModifyType = TipoProcessoProcess.CreateInstance.FromToModificaTipoProcesso(ModificaTipoProcessoType.TipoProcessoExcluir);
                        _IdExecute = TipoProcessoProcess.CreateInstance.TaskModifyTypeProcessTypeProcess(_CodigoTipoProcesso, string.Empty, 0, _ModifyType);
                    }
                    catch (Exception _Exception)
                    {
                        throw _Exception;
                    }
                    finally
                    {
                        dataGridSearchModule.DataSource = null;

                        FillDataGrid(TipoProcessoProcess.CreateInstance.TaskGetCollectionGeTipoProcessoByFilter("", 0));
                    }
                }
            }
        }

        private void SearchFormTipoProcesso_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                this.UpdateTypeProcess();
            }
        }
    
    }
}
