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
    public partial class SearchFormUsuarioUsuarioGrupo : Form
    {
        #region ...::: Private Variable :::...

        private int _CodigoEmpresa = 0;
        private int _CodigoGrupo = 0;
        private string _Usuario = string.Empty;

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

        public SearchFormUsuarioUsuarioGrupo()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(UsuarioGrupoProcess.CreateInstance.TaskGetCollectionGeUsuarioGrupoByFilter("", 0));
        }

        private void FillDataGrid(List<GeUsuarioGrupo> _GeUsuarioGrupoCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateManager.GeUsuarioGrupoCollection = _GeUsuarioGrupoCollection;

                bsGeUsuarioGrupo.DataSource = AppStateManager.GeUsuarioGrupoCollection;
                bsGeUsuarioGrupo.AllowNew = false;

                dataGridSearchModule.DataSource = bsGeUsuarioGrupo;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["CodigoEmpresa"].HeaderText = "Empresa";
                dataGridSearchModule.Columns["CodigoEmpresa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoGrupo"].HeaderText = "Grupo";
                dataGridSearchModule.Columns["CodigoGrupo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["Usuario"].HeaderText = "Usuário";
                dataGridSearchModule.Columns["Usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void tlstrpBtnFirst_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeUsuarioGrupo.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeUsuarioGrupo.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeUsuarioGrupo.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeUsuarioGrupo.MoveLast();
            }
        }

        private void tlstrpBtnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        }

        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AdicionaGeUsuarioGrupo();
        }

        private void AdicionaGeUsuarioGrupo()
        {
            UpdateFormUsuarioGrupo _UpdateFormUsuarioGrupo = new UpdateFormUsuarioGrupo();
            _UpdateFormUsuarioGrupo.ModificaUsuarioGrupoType = ModificaUsuarioGrupoType.UsuarioGrupoAdicionar;
            _UpdateFormUsuarioGrupo.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormUsuarioGrupo.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormUsuarioGrupo.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoUsuarioGrupo, FormsMessages.TituloProcessoAcaoUsuarioGrupoInclusao);

            try
            {
                _UpdateFormUsuarioGrupo.ShowDialog();
            }
            finally
            {
                _UpdateFormUsuarioGrupo = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(UsuarioGrupoProcess.CreateInstance.TaskGetCollectionGeUsuarioGrupoByFilter("", 0));
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, System.EventArgs e)
        {
            AlteraGeUsuarioGrupo();
        }

        private void AlteraGeUsuarioGrupo()
        {
            string _Filter = string.Empty;

            UpdateFormUsuarioGrupo _UpdateFormUsuarioGrupo = new UpdateFormUsuarioGrupo();
            _UpdateFormUsuarioGrupo.ModificaUsuarioGrupoType = ModificaUsuarioGrupoType.UsuarioGrupoAlterar;
            _UpdateFormUsuarioGrupo.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormUsuarioGrupo.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormUsuarioGrupo.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoUsuarioGrupo, FormsMessages.TituloProcessoAcaoUsuarioGrupoAlteracao);

            _CodigoEmpresa = (int)dataGridSearchModule.CurrentRow.Cells["CodigoEmpresa"].Value;
            _CodigoGrupo = (int)dataGridSearchModule.CurrentRow.Cells["CodigoGrupo"].Value;
            _Usuario = (string)dataGridSearchModule.CurrentRow.Cells["Usuario"].Value;

            _UpdateFormUsuarioGrupo.CodigoEmpresa = _CodigoEmpresa;
            _UpdateFormUsuarioGrupo.CodigoGrupo = _CodigoGrupo;
            _UpdateFormUsuarioGrupo.Usuario = _Usuario;

            try
            {
                _UpdateFormUsuarioGrupo.ShowDialog();
            }
            finally
            {
                AppStateManager.CodigoEmpresa = _UpdateFormUsuarioGrupo.CodigoEmpresa;

                _Filter = string.Format(" where cod_empr = '{0}' and cod_grupo = '{1}' and usuario = '{2}' ", AppStateManager.CodigoEmpresa, AppStateManager.CodigoGrupo, AppStateManager.Usuario);

                _UpdateFormUsuarioGrupo = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(UsuarioGrupoProcess.CreateInstance.TaskGetCollectionGeUsuarioGrupoByFilter(_Filter, 1));
            }
        }

        private void tlstrpBtnDelete_Click(object sender, System.EventArgs e)
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnDelete_Click";
            string _ModifyType = string.Empty;
            int _CodigoEmpresa = 0;
            int _CodigoGrupo = 0;
            string _Usuario = string.Empty;

            if (dataGridSearchModule.CurrentRow.Cells["CodigoEmpresa"].Value != null || dataGridSearchModule.CurrentRow.Cells["CodigoGrupo"].Value != null
                    || dataGridSearchModule.CurrentRow.Cells["Usuario"].Value != null)
            {
                if (MessageBox.Show("Deseja excluir este registro?",
                                    UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoUsuarioGrupo, FormsMessages.TituloProcessoAcaoUsuarioGrupoExclusao),
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (_ThrowingException != null) { _ThrowingException = null; }
                        _CodigoEmpresa = (int)dataGridSearchModule.CurrentRow.Cells["CodigoEmpresa"].Value;
                        _CodigoGrupo = (int)dataGridSearchModule.CurrentRow.Cells["CodigoGrupo"].Value;
                        _Usuario = (string)dataGridSearchModule.CurrentRow.Cells["Usuario"].Value;
                        _ModifyType = UsuarioGrupoProcess.CreateInstance.FromToModificaUsuarioGrupo(ModificaUsuarioGrupoType.UsuarioGrupoExcluir);
                        UsuarioGrupoProcess.CreateInstance.TaskModifyProcessUsuarioGrupo(_CodigoEmpresa, _CodigoGrupo, _Usuario, _ModifyType);
                    }
                    catch (Exception _Exception)
                    {
                        throw _Exception;
                    }
                    finally
                    {
                        dataGridSearchModule.DataSource = null;

                        FillDataGrid(UsuarioGrupoProcess.CreateInstance.TaskGetCollectionGeUsuarioGrupoByFilter("", 0));
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
            string _Usuario = string.Empty;
            FilterSearchFormUsuarioGrupo _FilterSearchFormUsuarioGrupo = null;

            if (dataGridSearchModule.DataSource != null)
            {
                try
                {
                    _FilterSearchFormUsuarioGrupo = new FilterSearchFormUsuarioGrupo();
                    _FilterSearchFormUsuarioGrupo.ShowDialog();
                }
                finally
                {
                    _SearchType = _FilterSearchFormUsuarioGrupo.SearchType;

                    switch (_SearchType)
                    {
                        case 0:
                            dataGridSearchModule.DataSource = null;
                            _CodigoEmpresa = _FilterSearchFormUsuarioGrupo.CodigoEmpresa;
                            AppStateManager.CodigoEmpresa = _CodigoEmpresa;
                            _Filter = string.Format(" where cod_empr = {0} ", AppStateManager.CodigoEmpresa);
                            FillDataGrid(UsuarioGrupoProcess.CreateInstance.TaskGetCollectionGeUsuarioGrupoByFilter(_Filter, 1));
                            break;
                        case 1:
                            dataGridSearchModule.DataSource = null;
                            _CodigoGrupo = _FilterSearchFormUsuarioGrupo.CodigoGrupo;
                            AppStateManager.CodigoGrupo = _CodigoGrupo;
                            _Filter = string.Format(" where cod_grupo = {0} ", AppStateManager.CodigoGrupo);
                            FillDataGrid(UsuarioGrupoProcess.CreateInstance.TaskGetCollectionGeUsuarioGrupoByFilter(_Filter, 1));
                            break;
                        case 2:
                            dataGridSearchModule.DataSource = null;
                            _Usuario = _FilterSearchFormUsuarioGrupo.Usuario;
                            AppStateManager.Usuario = _Usuario.ToUpper();
                            _Filter = string.Format(" where usuario = '%{0}%' ", AppStateManager.Usuario);
                            FillDataGrid(UsuarioGrupoProcess.CreateInstance.TaskGetCollectionGeUsuarioGrupoByFilter(_Filter, 1));
                            break;
                    }

                    _FilterSearchFormUsuarioGrupo.Dispose();
                }
            }
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, EventArgs e)
        {
            dataGridSearchModule.DataSource = null;
            FillDataGrid(UsuarioGrupoProcess.CreateInstance.TaskGetCollectionGeUsuarioGrupoByFilter("", 0));
        }

        private void SearchFormUsuarioUsuarioGrupo_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                this.AlteraGeUsuarioGrupo();
            }
        }
    }
}
