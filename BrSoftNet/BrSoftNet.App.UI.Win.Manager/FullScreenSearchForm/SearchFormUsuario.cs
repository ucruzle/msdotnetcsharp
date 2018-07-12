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
    public partial class SearchFormUsuario : Form
    {
        #region ...::: Private Variable :::...

        private string _Usuario = string.Empty;
        private string _Nome = string.Empty;
        private int _CodigoEmpresa = 0;
        private int _CodigoRG = 0;
        private string _StatusDBA = string.Empty;
        private DateTime _DataCadastro = DateTime.Now;
        private string _Senha = string.Empty;
        private string _Ramal = string.Empty;
        private string _Ativo = string.Empty;
        private string _UsuarioIncl = string.Empty;

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

        public SearchFormUsuario()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(UsuarioProcess.CreateInstance.TaskGetCollectionGeUsuarioByFilter("", 0));
        }

        private void FillDataGrid(List<GeUsuario> _GeUsuarioCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateManager.GeUsuarioCollection = _GeUsuarioCollection;

                bsGeUsuario.DataSource = AppStateManager.GeUsuarioCollection;
                bsGeUsuario.AllowNew = false;

                dataGridSearchModule.DataSource = bsGeUsuario;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["Usuario"].HeaderText = "Usuário";
                dataGridSearchModule.Columns["Usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["Nome"].HeaderText = "Descrição";
                dataGridSearchModule.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoEmpresa"].HeaderText = "Código Empresa";
                dataGridSearchModule.Columns["CodigoEmpresa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoRG"].HeaderText = "Código RG";
                dataGridSearchModule.Columns["CodigoRG"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["StatusDBA"].HeaderText = "Status DBA";
                dataGridSearchModule.Columns["StatusDBA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DataCadastro"].HeaderText = "Data Cadastro";
                dataGridSearchModule.Columns["DataCadastro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["Senha"].HeaderText = "Senha";
                dataGridSearchModule.Columns["Senha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["Ramal"].HeaderText = "Ramal";
                dataGridSearchModule.Columns["Ramal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["Ativo"].HeaderText = "Ativo";
                dataGridSearchModule.Columns["Ativo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["UsuarioIncl"].HeaderText = "Usuário Incl.";
                dataGridSearchModule.Columns["UsuarioIncl"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void tlstrpBtnFirst_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeUsuario.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeUsuario.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeUsuario.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsGeUsuario.MoveLast();
            }
        }

        private void tlstrpBtnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        }

        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AdicionaGeUsuario();
        }

        private void AdicionaGeUsuario()
        {
            UpdateFormUsuario _UpdateFormUsuario = new UpdateFormUsuario();
            _UpdateFormUsuario.ModificaUsuarioType = ModificaUsuarioType.UsuarioAdicionar;
            _UpdateFormUsuario.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormUsuario.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormUsuario.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoUsuario, FormsMessages.TituloProcessoAcaoUsuarioInclusao);

            try
            {
                _UpdateFormUsuario.ShowDialog();
            }
            finally
            {
                _UpdateFormUsuario = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(UsuarioProcess.CreateInstance.TaskGetCollectionGeUsuarioByFilter("", 0));
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, System.EventArgs e)
        {
            AlteraGeUsuario();
        }

        private void AlteraGeUsuario()
        {
            string _Filter = string.Empty;

            UpdateFormUsuario _UpdateFormUsuario = new UpdateFormUsuario();
            _UpdateFormUsuario.ModificaUsuarioType = ModificaUsuarioType.UsuarioAlterar;
            _UpdateFormUsuario.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormUsuario.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormUsuario.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoUsuario, FormsMessages.TituloProcessoAcaoUsuarioAlteracao);

            _Usuario = (string)dataGridSearchModule.CurrentRow.Cells["Usuario"].Value;
            _Nome = (string)dataGridSearchModule.CurrentRow.Cells["Nome"].Value;
            _CodigoEmpresa = (int)dataGridSearchModule.CurrentRow.Cells["CodigoEmpresa"].Value;
            _CodigoRG = (int)dataGridSearchModule.CurrentRow.Cells["CodigoRG"].Value;
            _StatusDBA = (string)dataGridSearchModule.CurrentRow.Cells["StatusDBA"].Value;
            _DataCadastro = (DateTime)dataGridSearchModule.CurrentRow.Cells["DataCadastro"].Value;
            _Senha = (string)dataGridSearchModule.CurrentRow.Cells["Senha"].Value;
            _Ramal = (string)dataGridSearchModule.CurrentRow.Cells["Ramal"].Value;
            _Ativo = (string)dataGridSearchModule.CurrentRow.Cells["Ativo"].Value;
            _UsuarioIncl = (string)dataGridSearchModule.CurrentRow.Cells["UsuarioIncl"].Value;

            _UpdateFormUsuario.Usuario = _Usuario;
            _UpdateFormUsuario.Nome = _Nome;
            _UpdateFormUsuario.CodigoEmpresa = _CodigoEmpresa;
            _UpdateFormUsuario.CodigoRG = _CodigoRG;
            _UpdateFormUsuario.StatusDBA = _StatusDBA;
            _UpdateFormUsuario.DataCadastro = _DataCadastro;
            _UpdateFormUsuario.Senha = _Senha;
            _UpdateFormUsuario.Ramal = _Ramal;
            _UpdateFormUsuario.Ativo = _Ativo;
            _UpdateFormUsuario.UsuarioIncl = _UsuarioIncl;

            try
            {
                _UpdateFormUsuario.ShowDialog();
            }
            finally
            {
                AppStateManager.Usuario = _UpdateFormUsuario.Usuario;

                _Filter = string.Format(" where usuario = '{0}' ", AppStateManager.Usuario);

                _UpdateFormUsuario = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(UsuarioProcess.CreateInstance.TaskGetCollectionGeUsuarioByFilter(_Filter, 1));
            }
        }

        private void tlstrpBtnDelete_Click(object sender, System.EventArgs e)
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnDelete_Click";
            string _ModifyType = string.Empty;
            string _Usuario = string.Empty;
            string _Nome = string.Empty;
            string _StatusDBA = string.Empty;
            DateTime _DataCadastro = new DateTime(1900, 01, 01);
            string _Ativo = string.Empty;

            if (dataGridSearchModule.CurrentRow.Cells["Usuario"].Value != null)
            {
                if (MessageBox.Show("Deseja excluir este registro?",
                                    UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoUsuario, FormsMessages.TituloProcessoAcaoUsuarioExclusao),
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (_ThrowingException != null) { _ThrowingException = null; }
                        _Usuario = (string)dataGridSearchModule.CurrentRow.Cells["Usuario"].Value;
                        _ModifyType = UsuarioProcess.CreateInstance.FromToModificaUsuario(ModificaUsuarioType.UsuarioExcluir);
                        UsuarioProcess.CreateInstance.TaskModifyProcessUsuario(_Usuario, string.Empty, 0, 0, string.Empty, _DataCadastro, string.Empty, string.Empty, string.Empty, string.Empty, _ModifyType);
                    }
                    catch (Exception _Exception)
                    {
                        throw _Exception;
                    }
                    finally
                    {
                        dataGridSearchModule.DataSource = null;

                        FillDataGrid(UsuarioProcess.CreateInstance.TaskGetCollectionGeUsuarioByFilter("", 0));
                    }
                }
            }
        }

        private void tlstrpBtnSearchCriteria_Click(object sender, EventArgs e)
        {
            int _SearchType = 0;
            string _Filter = "";
            string _Usuario = "";
            string _Nome = "";
            int _CodigoEmpresa = 0;
            int _CodigoRG = 0;
            string _StatusDBA = string.Empty;
            DateTime _DataCadastro = new DateTime(1900, 01, 01);
            string _Ativo = string.Empty;

            FilterSearchFormUsuario _FilterSearchFormUsuario = null;

            if (dataGridSearchModule.DataSource != null)
            {
                try
                {
                    _FilterSearchFormUsuario = new FilterSearchFormUsuario();
                    _FilterSearchFormUsuario.ShowDialog();
                }
                finally
                {
                    _SearchType = _FilterSearchFormUsuario.SearchType;

                    switch (_SearchType)
                    {
                        case 0:
                            dataGridSearchModule.DataSource = null;
                            _Usuario = _FilterSearchFormUsuario.Usuario;
                            AppStateManager.Usuario = _Usuario.ToUpper();
                            _Filter = string.Format(" where usuario LIKE '%{0}%' ", AppStateManager.Usuario);
                            FillDataGrid(UsuarioProcess.CreateInstance.TaskGetCollectionGeUsuarioByFilter(_Filter, 1));
                            break;
                        case 1:
                            dataGridSearchModule.DataSource = null;
                            _Nome = _FilterSearchFormUsuario.Nome;
                            AppStateManager.Nome = _Nome.ToUpper();
                            _Filter = string.Format(" where nome = '%{0}%' ", AppStateManager.Nome);
                            FillDataGrid(UsuarioProcess.CreateInstance.TaskGetCollectionGeUsuarioByFilter(_Filter, 1));
                            break;
                        case 2:
                            dataGridSearchModule.DataSource = null;
                            _CodigoEmpresa = _FilterSearchFormUsuario.CodigoEmpresa;
                            AppStateManager.CodigoEmpresa = _CodigoEmpresa;
                            _Filter = string.Format(" where cod_empr = {0} ", AppStateManager.CodigoEmpresa);
                            FillDataGrid(UsuarioProcess.CreateInstance.TaskGetCollectionGeUsuarioByFilter(_Filter, 1));
                            break;
                        case 3:
                            dataGridSearchModule.DataSource = null;
                            _CodigoRG = _FilterSearchFormUsuario.CodigoRG;
                            AppStateManager.CodigoRG = _CodigoRG;
                            _Filter = string.Format(" where cod_rg = {0} ", AppStateManager.CodigoRG);
                            FillDataGrid(UsuarioProcess.CreateInstance.TaskGetCollectionGeUsuarioByFilter(_Filter, 1));
                            break;
                        case 4:
                            dataGridSearchModule.DataSource = null;
                            _StatusDBA = _FilterSearchFormUsuario.StatusDBA;
                            AppStateManager.StatusDBA = _StatusDBA.ToUpper();
                            _Filter = string.Format(" where status_dba = '%{0}%' ", AppStateManager.StatusDBA);
                            FillDataGrid(UsuarioProcess.CreateInstance.TaskGetCollectionGeUsuarioByFilter(_Filter, 1));
                            break;
                        case 5:
                            dataGridSearchModule.DataSource = null;
                            _DataCadastro = _FilterSearchFormUsuario.DataCadastro;
                            AppStateManager.DataCadastro = _DataCadastro;
                            _Filter = string.Format(" where dt_cadastro = '%{0}%' ", AppStateManager.DataCadastro);
                            FillDataGrid(UsuarioProcess.CreateInstance.TaskGetCollectionGeUsuarioByFilter(_Filter, 1));
                            break;
                        case 6:
                            dataGridSearchModule.DataSource = null;
                            _Ativo = _FilterSearchFormUsuario.Ativo;
                            AppStateManager.Ativo = _Ativo.ToUpper();
                            _Filter = string.Format(" where ativo = '%{0}%' ", AppStateManager.Ativo);
                            FillDataGrid(UsuarioProcess.CreateInstance.TaskGetCollectionGeUsuarioByFilter(_Filter, 1));
                            break;
                    }

                    _FilterSearchFormUsuario.Dispose();
                }
            }
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, EventArgs e)
        {
            dataGridSearchModule.DataSource = null;
            FillDataGrid(UsuarioProcess.CreateInstance.TaskGetCollectionGeUsuarioByFilter("", 0));
        }

        private void SearchFormUsuario_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                this.AlteraGeUsuario();
            }
        }
    }
}
