using BrSoftNet.App.Business.Processes.Manager.Entities;
using BrSoftNet.App.Business.Processes.Manager.Enumerators;
using BrSoftNet.App.Business.Processes.Manager.Tasks;
using BrSoftNet.App.UI.Win.Manager.State;
using BrSoftNet.App.UI.Win.OverallRecord.DialogUpdateForm;
using BrSoftNet.Library.Messages;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Log.Structures;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.OverallRecord.FullScreenSearchForm
{
    public partial class SearchFormLiberacaoUsuario : Form
    {
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
        public SearchFormLiberacaoUsuario()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.tlstrpBtnDelete.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(LiberacaoUsuarioProcess.CreateInstance.TaskGetDataLiberacaoUsuarioByFilter(string.Empty, 0));
        }

        private void FillDataGrid(List<LiberacaoUsuarioPorFiltro> _LiberacaoUsuarioPorFiltroCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateManager.LiberacaoUsuarioPorFiltroCollection = _LiberacaoUsuarioPorFiltroCollection;

                bsLiberacaoUsuarioPorFiltro.DataSource = AppStateManager.LiberacaoUsuarioPorFiltroCollection;
                bsLiberacaoUsuarioPorFiltro.AllowNew = false;

                dataGridSearchModule.DataSource = bsLiberacaoUsuarioPorFiltro;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["CodigoEmpresa"].HeaderText = "Cod.Empresa";
                dataGridSearchModule.Columns["CodigoEmpresa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescricaoEmpresa"].HeaderText = "Desc.Empresa";
                dataGridSearchModule.Columns["DescricaoEmpresa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoAplicacao"].HeaderText = "Cod.Aplicação";
                dataGridSearchModule.Columns["CodigoAplicacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescricaoAplicacao"].HeaderText = "Desc.Aplicação";
                dataGridSearchModule.Columns["DescricaoAplicacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["Usuario"].HeaderText = "Usuário";
                dataGridSearchModule.Columns["Usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

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

        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AdicionaGeProcessoLiberacaoUsuario();
        }

        private void AdicionaGeProcessoLiberacaoUsuario()
        {
            UpdateFormLiberacaoUsuario _UpdateFormLiberacaoUsuario = new UpdateFormLiberacaoUsuario();
            _UpdateFormLiberacaoUsuario.ModificaLiberacaoUsuarioType = ModificaLiberacaoUsuarioType.LiberacaoUsuarioAdicionar;
            _UpdateFormLiberacaoUsuario.CodigoEmpresaLiberacaoUsuario = IdEmpresaFromDashboard;
            _UpdateFormLiberacaoUsuario.UsuarioLiberacaoUsuario = UsuarioLoginDashboard;
            _UpdateFormLiberacaoUsuario.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoLiberacaoUsuario, FormsMessages.TituloProcessoAcaoLiberacaoUsuarioInclusao);

            try
            {
                _UpdateFormLiberacaoUsuario.ShowDialog();
            }
            finally
            {
                _UpdateFormLiberacaoUsuario = null;

                dataGridSearchModule.DataSource = null;

                //FillDataGrid(EmpresaProcess.CreateInstance.TaskGetCollectionGeEmpresaByFilter("", 0));
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, System.EventArgs e)
        {
            AlteraGeProcessoLiberacaoUsuario();
        }

        private void AlteraGeProcessoLiberacaoUsuario()
        {
            string _Filter = string.Empty;

            if (bsLiberacaoUsuarioPorFiltro.DataSource != null)
            {
                if (dataGridSearchModule.CurrentRow.Cells["CodigoEmpresa"].Value != null &&
                    dataGridSearchModule.CurrentRow.Cells["CodigoAplicacao"].Value != null &&
                    dataGridSearchModule.CurrentRow.Cells["Usuario"].Value != null)
                {
                    UpdateFormLiberacaoUsuario _UpdateFormLiberacaoUsuario = new UpdateFormLiberacaoUsuario();
                    _UpdateFormLiberacaoUsuario.ModificaLiberacaoUsuarioType = ModificaLiberacaoUsuarioType.LiberacaoUsuarioAlterar;
                    _UpdateFormLiberacaoUsuario.CodigoEmpresaLiberacaoUsuario = IdEmpresaFromDashboard;
                    _UpdateFormLiberacaoUsuario.UsuarioLiberacaoUsuario = UsuarioLoginDashboard;
                    _UpdateFormLiberacaoUsuario.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoLiberacaoUsuario, FormsMessages.TituloProcessoAcaoLiberacaoUsuarioAlteracao);

                    _UpdateFormLiberacaoUsuario.CodigoEmpresaLiberacaoUsuario = (int)dataGridSearchModule.CurrentRow.Cells["CodigoEmpresa"].Value;
                    _UpdateFormLiberacaoUsuario.CodigoAplicacaoLiberacaoUsuario = (int)dataGridSearchModule.CurrentRow.Cells["CodigoAplicacao"].Value;
                    _UpdateFormLiberacaoUsuario.UsuarioLiberacaoUsuario = (string)dataGridSearchModule.CurrentRow.Cells["Usuario"].Value;

                    try
                    {
                        _UpdateFormLiberacaoUsuario.ShowDialog();
                    }
                    finally
                    {
                        AppStateManager.CodigoEmpresaLiberacaoUsuario = _UpdateFormLiberacaoUsuario.CodigoEmpresaLiberacaoUsuario;
                        AppStateManager.CodigoAplicacaoLiberacaoUsuario = _UpdateFormLiberacaoUsuario.CodigoAplicacaoLiberacaoUsuario;
                        AppStateManager.UsuarioLiberacaoUsuario = _UpdateFormLiberacaoUsuario.UsuarioLiberacaoUsuario;

                        _Filter = string.Format(" where emp.cod_empr = {0} AND apl.cod_aplic = {1} AND upr.usuario = '{2}' ", AppStateManager.CodigoEmpresaLiberacaoUsuario, AppStateManager.CodigoAplicacaoLiberacaoUsuario, AppStateManager.UsuarioLiberacaoUsuario);

                        _UpdateFormLiberacaoUsuario = null;

                        dataGridSearchModule.DataSource = null;

                        FillDataGrid(LiberacaoUsuarioProcess.CreateInstance.TaskGetDataLiberacaoUsuarioByFilter(_Filter, 1));
                    }
                }
            }
        }

        private void tlstrpBtnExit_Click(object sender, System.EventArgs e)
        {
            CloseSearchForm();
        }

        private void CloseSearchForm()
        {
            this.Close();

            bsLiberacaoUsuarioPorFiltro.DataSource = null;
        }

        private void tlstrpBtnFirst_Click(object sender, System.EventArgs e)
        {
            if (bsLiberacaoUsuarioPorFiltro.DataSource != null)
            {
                bsLiberacaoUsuarioPorFiltro.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, System.EventArgs e)
        {
            if (bsLiberacaoUsuarioPorFiltro.DataSource != null)
            {
                bsLiberacaoUsuarioPorFiltro.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, System.EventArgs e)
        {
            if (bsLiberacaoUsuarioPorFiltro.DataSource != null)
            {
                bsLiberacaoUsuarioPorFiltro.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, System.EventArgs e)
        {
            if (bsLiberacaoUsuarioPorFiltro.DataSource != null)
            {
                bsLiberacaoUsuarioPorFiltro.MoveLast();
            }
        }

        private void SearchFormLiberacaoUsuario_Load(object sender, System.EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }

        private void dataGridSearchModule_DoubleClick(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                this.AlteraGeProcessoLiberacaoUsuario();
            }
        }
    }
}
