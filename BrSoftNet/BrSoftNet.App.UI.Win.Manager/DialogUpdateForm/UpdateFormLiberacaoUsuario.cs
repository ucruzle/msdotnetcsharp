using BrSoftNet.App.Business.Processes.Manager.Entities;
using BrSoftNet.App.Business.Processes.Manager.Enumerators;
using BrSoftNet.App.Business.Processes.Manager.Tasks;
using BrSoftNet.App.UI.Win.Manager.DataMaintenance;
using BrSoftNet.App.UI.Win.Manager.State;
using BrSoftNet.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.OverallRecord.DialogUpdateForm
{
    public partial class UpdateFormLiberacaoUsuario : Form
    {
        #region ...::: Private Constants :::...

        private const string _COLLECTION_NAME = "UsuarioProcessoMapping";

        #endregion

        #region ...::: Private Fields :::...

        private DataSet _DataSetProcessoLiberacaoUsuario = null;

        private List<EmpresaLiberacaoUsuario> _EmpresaCollection = null;

        private List<AplicacaoEmpresaLiberacao> _AplicacaoCollection = null;

        private List<UsuarioLiberacaoUsuario> _UsuarioCollection = null;

        private List<GeTipoProcesso> _TipoProcessoCollection = null;
        
        private List<GeProcesso> _GeProcessoToProcess = null;

        private List<ProcessoLiberacaoUsuario> _ProcessoLiberacaoUsuarioToDataGrid = null;

        private List<GeUsuarioProcesso> _GeUsuarioProcessoMapping = null;

        private int _CodigoEmpresa = 0;

        private string _Usuario = string.Empty;

        private string _TipoModificacao = string.Empty;

        private int _IdExecute = 0;

        LiberacaoUsuarioProcessMapping _LiberacaoUsuarioProcessMapping = null;

        #endregion

        #region ...::: Properties :::...
        public ModificaLiberacaoUsuarioType ModificaLiberacaoUsuarioType { get; set; }
        private List<EmpresaLiberacaoUsuario> EmpresaCollection { get; set; }
        private List<AplicacaoEmpresaLiberacao> AplicacaoCollection { get; set; }
        private List<UsuarioLiberacaoUsuario> UsuarioCollection { get; set; }
        private List<GeTipoProcesso> TipoProcessoCollection { get; set; }
        private List<GeProcesso> ProcessoCollection { get; set; }
        public int CodigoEmpresaLiberacaoUsuario { get; set; }
        public int CodigoAplicacaoLiberacaoUsuario { get; set; }
        public string UsuarioLiberacaoUsuario { get; set; }
        public int CodigoTipoProcessoLiberacaoUsuario { get; set; }
        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        public UpdateFormLiberacaoUsuario()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();

            this.cmbBxEmpresa.LostFocus += cmbBxEmpresa_LostFocus;
            this.cmbBxEmpresa.GotFocus += cmbBxEmpresa_GotFocus;

            this.cmbBxUsuario.LostFocus += cmbBxUsuario_LostFocus;
            this.cmbBxUsuario.GotFocus += cmbBxUsuario_GotFocus;

            this.cmbBxAplicacao.LostFocus += cmbBxAplicacao_LostFocus;
            this.cmbBxAplicacao.GotFocus += cmbBxAplicacao_GotFocus;

            this.tlStrpCmbBxFindProcesses.ComboBox.LostFocus += ComboBox_LostFocus;
            this.tlStrpCmbBxFindProcesses.ComboBox.GotFocus += ComboBox_GotFocus;
        }

        void ComboBox_GotFocus(object sender, EventArgs e)
        {
            this.tlStrpCmbBxFindProcesses.ComboBox.BackColor = Color.LightYellow;
        }

        void ComboBox_LostFocus(object sender, EventArgs e)
        {
            this.tlStrpCmbBxFindProcesses.ComboBox.BackColor = Color.White;
        }

        void cmbBxAplicacao_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxAplicacao.BackColor = Color.LightYellow;
        }

        void cmbBxAplicacao_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxAplicacao.BackColor = Color.White;
        }

        void cmbBxUsuario_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxUsuario.BackColor = Color.LightYellow;
        }

        void cmbBxUsuario_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxUsuario.BackColor = Color.White;
        }

        void cmbBxEmpresa_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxEmpresa.BackColor = Color.LightYellow;
        }

        void cmbBxEmpresa_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxEmpresa.BackColor = Color.White;
        }

        private void InicialiazeUpdateForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void UpdateFormLiberacaoUsuario_Load(object sender, System.EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;

            _DataSetProcessoLiberacaoUsuario = LiberacaoUsuarioProcess.CreateInstance.GetCollectionLiberacaoUsuarioTask();

            PreencheEmpresaCollection();
            PreencheAplicacaoCollection();
            PreencheUsuarioCollection();
            PreencheTipoProcessoCollection();

            switch (ModificaLiberacaoUsuarioType)
            {
                case ModificaLiberacaoUsuarioType.LiberacaoUsuarioAdicionar:
                    FillDataLiberacaoUsuarioToExecuteAddModify();
                    break;
                case ModificaLiberacaoUsuarioType.LiberacaoUsuarioAlterar:
                    FillDataLiberacaoUsuarioToExecuteUpdateModify();
                    break;                
                default:
                    break;
            }
        }

        private void PreencheEmpresaCollection()
        {
            if (_EmpresaCollection == null)
            {
                _EmpresaCollection = new List<EmpresaLiberacaoUsuario>();
            }

            foreach (DataRow _Row in _DataSetProcessoLiberacaoUsuario.Tables[0].Rows)
            {
                _EmpresaCollection.Add(new EmpresaLiberacaoUsuario(_Row));
            }

            EmpresaCollection = _EmpresaCollection;
        }

        private void PreencheAplicacaoCollection()
        {
            if (_AplicacaoCollection == null)
            {
                _AplicacaoCollection = new List<AplicacaoEmpresaLiberacao>();
            }

            foreach (DataRow _Row in _DataSetProcessoLiberacaoUsuario.Tables[1].Rows)
            {
                _AplicacaoCollection.Add(new AplicacaoEmpresaLiberacao(_Row));
            }

            AplicacaoCollection = _AplicacaoCollection;
        }

        private void PreencheUsuarioCollection()
        {
            if (_UsuarioCollection == null)
            {
                _UsuarioCollection = new List<UsuarioLiberacaoUsuario>();
            }

            foreach (DataRow _Row in _DataSetProcessoLiberacaoUsuario.Tables[2].Rows)
            {
                _UsuarioCollection.Add(new UsuarioLiberacaoUsuario(_Row));
            }

            UsuarioCollection = _UsuarioCollection;
        }

        private void PreencheTipoProcessoCollection()
        {
            if (_TipoProcessoCollection == null)
            {
                _TipoProcessoCollection = new List<GeTipoProcesso>();
            }

            foreach (DataRow _Row in _DataSetProcessoLiberacaoUsuario.Tables[3].Rows)
            {
                _TipoProcessoCollection.Add(new GeTipoProcesso(_Row));
            }

            TipoProcessoCollection = _TipoProcessoCollection;
        }

        private void FillDataLiberacaoUsuarioToExecuteUpdateModify()
        {
            cmbBxEmpresa.DataSource = EmpresaCollection;
            cmbBxEmpresa.ValueMember = "CodigoEmpresa";
            cmbBxEmpresa.DisplayMember = "NomeFantasia";
            cmbBxEmpresa.SelectedValue = this.CodigoEmpresaLiberacaoUsuario;

            cmbBxAplicacao.DataSource = AplicacaoCollection;
            cmbBxAplicacao.ValueMember = "CodigoAplicacao";
            cmbBxAplicacao.DisplayMember = "DescricaoAplicacao";
            cmbBxAplicacao.SelectedValue = this.CodigoAplicacaoLiberacaoUsuario;

            cmbBxUsuario.DataSource = UsuarioCollection;
            cmbBxUsuario.ValueMember = "Usuario";
            cmbBxUsuario.DisplayMember = "Nome";
            cmbBxUsuario.SelectedValue = this.UsuarioLiberacaoUsuario;

            tlStrpCmbBxFindProcesses.ComboBox.DataSource = TipoProcessoCollection;
            tlStrpCmbBxFindProcesses.ComboBox.ValueMember = "CodigoTipoProcesso";
            tlStrpCmbBxFindProcesses.ComboBox.DisplayMember = "DescricaoTipoProcesso";
            tlStrpCmbBxFindProcesses.ComboBox.SelectedValue = this.CodigoTipoProcessoLiberacaoUsuario;

            chckBxExibirTodosOsProcessos.Checked = true;

            ExibeTodosOsProcessos();
        }

        private void FillDataLiberacaoUsuarioToExecuteAddModify()
        {
            cmbBxEmpresa.DataSource = EmpresaCollection;
            cmbBxEmpresa.ValueMember = "CodigoEmpresa";
            cmbBxEmpresa.DisplayMember = "NomeFantasia";

            cmbBxAplicacao.DataSource = AplicacaoCollection;
            cmbBxAplicacao.ValueMember = "CodigoAplicacao";
            cmbBxAplicacao.DisplayMember = "DescricaoAplicacao";

            cmbBxUsuario.DataSource = UsuarioCollection;
            cmbBxUsuario.ValueMember = "Usuario";
            cmbBxUsuario.DisplayMember = "Nome";

            tlStrpCmbBxFindProcesses.ComboBox.DataSource = TipoProcessoCollection;
            tlStrpCmbBxFindProcesses.ComboBox.ValueMember = "CodigoTipoProcesso";
            tlStrpCmbBxFindProcesses.ComboBox.DisplayMember = "DescricaoTipoProcesso";

            AppStateManager.CodigoEmpresaLiberacaoUsuario = Convert.ToInt32(cmbBxEmpresa.SelectedValue);
            AppStateManager.CodigoAplicacaoLiberacaoUsuario = Convert.ToInt32(cmbBxAplicacao.SelectedValue);
            AppStateManager.UsuarioLiberacaoUsuario = Convert.ToString(cmbBxUsuario.SelectedValue);
            AppStateManager.CodigoTipoProcessoLiberacaoUsuario = Convert.ToInt32(tlStrpCmbBxFindProcesses.ComboBox.SelectedValue);

            chckBxExibirTodosOsProcessos.Checked = true;

            ExibeTodosOsProcessos();
        }

        private void tlStrpBtnFindProcesses_Click(object sender, EventArgs e)
        {
            PreencheGridDadosLiberacaoProcessosUsuario();
        }

        private void PreencheGridDadosLiberacaoProcessosUsuario()
        {
            int _CodigoEmpresa = 0;
            int _CodigoAplicacao = 0;
            string _Usuario = string.Empty;
            int _CodigoTipoProcesso = 0;
            string _TipoDeModificacao = string.Empty;

            AppStateManager.CodigoEmpresaLiberacaoUsuario = Convert.ToInt32(cmbBxEmpresa.SelectedValue);
            AppStateManager.CodigoAplicacaoLiberacaoUsuario = Convert.ToInt32(cmbBxAplicacao.SelectedValue);
            AppStateManager.UsuarioLiberacaoUsuario = Convert.ToString(cmbBxUsuario.SelectedValue);
            AppStateManager.CodigoTipoProcessoLiberacaoUsuario = Convert.ToInt32(tlStrpCmbBxFindProcesses.ComboBox.SelectedValue);

            if (bsLiberacaoUsuario.DataSource != null)
            {
                bsLiberacaoUsuario.DataSource = null;
            }

            _CodigoEmpresa = AppStateManager.CodigoEmpresaLiberacaoUsuario;
            _CodigoAplicacao = AppStateManager.CodigoAplicacaoLiberacaoUsuario;
            _Usuario = AppStateManager.UsuarioLiberacaoUsuario;
            _CodigoTipoProcesso = AppStateManager.CodigoTipoProcessoLiberacaoUsuario;

            switch (ModificaLiberacaoUsuarioType)
            {
                case ModificaLiberacaoUsuarioType.LiberacaoUsuarioAdicionar:
                    _TipoDeModificacao = LiberacaoUsuarioProcess.CreateInstance.FromToModificaLiberacaoUsuario(ModificaLiberacaoUsuarioType.LiberacaoUsuarioAdicionar);
                    _GeProcessoToProcess = LiberacaoUsuarioProcess.CreateInstance.TaskGetCollectionGeProcessoByEmpresaAplicacaoTipoProcesso(_CodigoEmpresa, _CodigoAplicacao, string.Empty, _TipoDeModificacao);
                    break;
                case ModificaLiberacaoUsuarioType.LiberacaoUsuarioAlterar:
                    _TipoDeModificacao = LiberacaoUsuarioProcess.CreateInstance.FromToModificaLiberacaoUsuario(ModificaLiberacaoUsuarioType.LiberacaoUsuarioAlterar);
                    _GeProcessoToProcess = LiberacaoUsuarioProcess.CreateInstance.TaskGetCollectionGeProcessoByEmpresaAplicacaoTipoProcesso(_CodigoEmpresa, _CodigoAplicacao, _Usuario, _TipoDeModificacao);
                    break;
                default:
                    break;
            }

            ConfiguraGridDadosLiberacaoProcessosUsuario(_GeProcessoToProcess.FindAll(p => p.CodigoTipoProcesso == _CodigoTipoProcesso));
        }

        private void ConfiguraGridDadosLiberacaoProcessosUsuario(List<GeProcesso> _ProcessosCollection)
        {
            if (_ProcessoLiberacaoUsuarioToDataGrid != null)
            {
                _ProcessoLiberacaoUsuarioToDataGrid = null;
            }

            switch (ModificaLiberacaoUsuarioType)
            {
                case ModificaLiberacaoUsuarioType.LiberacaoUsuarioAdicionar:
                    PreparaGridDadosLiberacaoProcessosUsuarioToAdd(_ProcessosCollection);
                    break;
                case ModificaLiberacaoUsuarioType.LiberacaoUsuarioAlterar:
                    PreparaGridDadosLiberacaoProcessosUsuarioToUpdate(_ProcessosCollection);
                    break;
                default:
                    break;
            }
        }

        private void PreparaGridDadosLiberacaoProcessosUsuarioToUpdate(List<GeProcesso> _ProcessosCollection)
        {
            if (_ProcessoLiberacaoUsuarioToDataGrid == null)
            {
                _ProcessoLiberacaoUsuarioToDataGrid = new List<ProcessoLiberacaoUsuario>();
            }

            foreach (GeProcesso _Processo in _ProcessosCollection)
            {
                _ProcessoLiberacaoUsuarioToDataGrid.Add(new ProcessoLiberacaoUsuario(true, _Processo.CodigoProcesso, _Processo.DescricaoProcesso, _Processo.CodigoTipoProcesso, _Processo.CodigoAplicacao, _Processo.Ativo, _Processo.Form, _Processo.SequenciaProcesso));
            }

            AjustaCamposDoDataGridParaExibicao(_ProcessoLiberacaoUsuarioToDataGrid);
        }

        private void PreparaGridDadosLiberacaoProcessosUsuarioToAdd(List<GeProcesso> _ProcessosCollection)
        {
            if (_ProcessoLiberacaoUsuarioToDataGrid == null)
            {
                _ProcessoLiberacaoUsuarioToDataGrid = new List<ProcessoLiberacaoUsuario>();
            }

            foreach (GeProcesso _Processo in _ProcessosCollection)
            {
                _ProcessoLiberacaoUsuarioToDataGrid.Add(new ProcessoLiberacaoUsuario(false, _Processo.CodigoProcesso, _Processo.DescricaoProcesso, _Processo.CodigoTipoProcesso, _Processo.CodigoAplicacao, _Processo.Ativo, _Processo.Form, _Processo.SequenciaProcesso));
            }

            AjustaCamposDoDataGridParaExibicao(_ProcessoLiberacaoUsuarioToDataGrid);
        }

        private void AjustaCamposDoDataGridParaExibicao(List<ProcessoLiberacaoUsuario> _ProcessoLiberacaoUsuarioToDataGrid)
        {
            bsLiberacaoUsuario.DataSource = _ProcessoLiberacaoUsuarioToDataGrid;
            bsLiberacaoUsuario.AllowNew = false;

            dtGridDadosLiberacao.DataSource = bsLiberacaoUsuario;
            dtGridDadosLiberacao.ReadOnly = false;

            dtGridDadosLiberacao.Columns["Liberar"].HeaderText = "Liberar";
            dtGridDadosLiberacao.Columns["Liberar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGridDadosLiberacao.Columns["Liberar"].ReadOnly = false;

            dtGridDadosLiberacao.Columns["CodigoProcesso"].HeaderText = "Cód.Proc";
            dtGridDadosLiberacao.Columns["CodigoProcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGridDadosLiberacao.Columns["CodigoProcesso"].ReadOnly = true;

            dtGridDadosLiberacao.Columns["DescricaoProcesso"].HeaderText = "Desc.Processo";
            dtGridDadosLiberacao.Columns["DescricaoProcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGridDadosLiberacao.Columns["DescricaoProcesso"].ReadOnly = true;

            dtGridDadosLiberacao.Columns["CodigoTipoProcesso"].HeaderText = "Cód.Tipo.Proc";
            dtGridDadosLiberacao.Columns["CodigoTipoProcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGridDadosLiberacao.Columns["CodigoTipoProcesso"].ReadOnly = true;

            dtGridDadosLiberacao.Columns["CodigoAplicacao"].HeaderText = "Cód.Aplicação";
            dtGridDadosLiberacao.Columns["CodigoAplicacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGridDadosLiberacao.Columns["CodigoAplicacao"].ReadOnly = true;

            dtGridDadosLiberacao.Columns["Ativo"].HeaderText = "Ativo";
            dtGridDadosLiberacao.Columns["Ativo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGridDadosLiberacao.Columns["Ativo"].ReadOnly = true;

            dtGridDadosLiberacao.Columns["Form"].HeaderText = "Formulário";
            dtGridDadosLiberacao.Columns["Form"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGridDadosLiberacao.Columns["Form"].ReadOnly = true;

            dtGridDadosLiberacao.Columns["SequenciaProcesso"].HeaderText = "Sequência";
            dtGridDadosLiberacao.Columns["SequenciaProcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGridDadosLiberacao.Columns["SequenciaProcesso"].ReadOnly = true;
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, EventArgs e)
        {            
            switch (ModificaLiberacaoUsuarioType)
            {
                case ModificaLiberacaoUsuarioType.LiberacaoUsuarioAdicionar:
                    AdicionaVinculoDeLiberacaoDeProcessos();
                    break;
                case ModificaLiberacaoUsuarioType.LiberacaoUsuarioAlterar:
                    ExcluiVinculoDeLiberacaoDeProcessos();
                    break;
                default:
                    break;
            }

            this.Close();
        }

        private void ExcluiVinculoDeLiberacaoDeProcessos()
        {
            List<ProcessoLiberacaoUsuario> _ProcessoLiberacaoUsuarioCollection = null;
            _CodigoEmpresa = AppStateManager.CodigoEmpresaLiberacaoUsuario;
            _Usuario = AppStateManager.UsuarioLiberacaoUsuario;
            string _XML = string.Empty;

            if (bsLiberacaoUsuario.DataSource != null)
            {
                AppStateManager.ProcessoLiberacaoUsuarioCollection = bsLiberacaoUsuario.DataSource as List<ProcessoLiberacaoUsuario>;

                _ProcessoLiberacaoUsuarioCollection = AppStateManager.ProcessoLiberacaoUsuarioCollection;

                if (_GeUsuarioProcessoMapping == null)
                {
                    _GeUsuarioProcessoMapping = new List<GeUsuarioProcesso>();
                }

                foreach (ProcessoLiberacaoUsuario _Process in _ProcessoLiberacaoUsuarioCollection)
                {
                    if (!_Process.Liberar)
                    {
                        _GeUsuarioProcessoMapping.Add(new GeUsuarioProcesso(_CodigoEmpresa, _Usuario, _Process.CodigoProcesso));
                        AppStateManager.UsuarioProcessoCollection = _GeUsuarioProcessoMapping;
                    }
                }

                _LiberacaoUsuarioProcessMapping = ManagerServiceHelper.CreateInstance.RetornaDadosLiberacaoUsuario(AppStateManager.UsuarioProcessoCollection);
                _XML = SerializationData.CreateInstance.GetSerializableData(_LiberacaoUsuarioProcessMapping, _COLLECTION_NAME);
                _TipoModificacao = LiberacaoUsuarioProcess.CreateInstance.FromToModificaLiberacaoUsuario(ModificaLiberacaoUsuarioType.LiberacaoUsuarioAlterar);
                _IdExecute = LiberacaoUsuarioProcess.CreateInstance.TaskModifyProcessLiberacaoUsuario(_XML, _TipoModificacao);
            }
        }

        private void AdicionaVinculoDeLiberacaoDeProcessos()
        {
            List<ProcessoLiberacaoUsuario> _ProcessoLiberacaoUsuarioCollection = null;
            _CodigoEmpresa = AppStateManager.CodigoEmpresaLiberacaoUsuario;
            _Usuario = AppStateManager.UsuarioLiberacaoUsuario;
            string _XML = string.Empty;

            if (bsLiberacaoUsuario.DataSource != null)
            {
                AppStateManager.ProcessoLiberacaoUsuarioCollection = bsLiberacaoUsuario.DataSource as List<ProcessoLiberacaoUsuario>;

                _ProcessoLiberacaoUsuarioCollection = AppStateManager.ProcessoLiberacaoUsuarioCollection;

                if (_GeUsuarioProcessoMapping == null)
                {
                    _GeUsuarioProcessoMapping = new List<GeUsuarioProcesso>();
                }

                foreach (ProcessoLiberacaoUsuario _Process in _ProcessoLiberacaoUsuarioCollection)
                {
                    if (_Process.Liberar)
                    {
                        _GeUsuarioProcessoMapping.Add(new GeUsuarioProcesso(_CodigoEmpresa, _Usuario, _Process.CodigoProcesso));
                        AppStateManager.UsuarioProcessoCollection = _GeUsuarioProcessoMapping;
                    }
                }

                _LiberacaoUsuarioProcessMapping = ManagerServiceHelper.CreateInstance.RetornaDadosLiberacaoUsuario(AppStateManager.UsuarioProcessoCollection);
                _XML = SerializationData.CreateInstance.GetSerializableData(_LiberacaoUsuarioProcessMapping, _COLLECTION_NAME);
                _TipoModificacao = LiberacaoUsuarioProcess.CreateInstance.FromToModificaLiberacaoUsuario(ModificaLiberacaoUsuarioType.LiberacaoUsuarioAdicionar);
                _IdExecute = LiberacaoUsuarioProcess.CreateInstance.TaskModifyProcessLiberacaoUsuario(_XML, _TipoModificacao);
            }
        }

        private void chckBxExibirTodosOsProcessos_Click(object sender, EventArgs e)
        {
            ExibeTodosOsProcessos();
        }

        private void ExibeTodosOsProcessos()
        {
            int _CodigoEmpresa = 0;
            int _CodigoAplicacao = 0;
            string _Usuario = string.Empty;
            string _TipoDeModificacao = string.Empty;

            AppStateManager.CodigoEmpresaLiberacaoUsuario = Convert.ToInt32(cmbBxEmpresa.SelectedValue);
            AppStateManager.UsuarioLiberacaoUsuario = Convert.ToString(cmbBxUsuario.SelectedValue);
            AppStateManager.CodigoAplicacaoLiberacaoUsuario = Convert.ToInt32(cmbBxAplicacao.SelectedValue);

            if (chckBxExibirTodosOsProcessos.Checked)
            {
                if (bsLiberacaoUsuario.DataSource != null)
                {
                    bsLiberacaoUsuario.DataSource = null;
                }

                tlStrpBtnFindProcesses.Enabled = false;
                tlStrpCmbBxFindProcesses.Enabled = false;

                _CodigoEmpresa = AppStateManager.CodigoEmpresaLiberacaoUsuario;
                _Usuario = AppStateManager.UsuarioLiberacaoUsuario;
                _CodigoAplicacao = AppStateManager.CodigoAplicacaoLiberacaoUsuario;

                switch (this.ModificaLiberacaoUsuarioType)
                {
                    case ModificaLiberacaoUsuarioType.LiberacaoUsuarioAdicionar:
                        _TipoDeModificacao = LiberacaoUsuarioProcess.CreateInstance.FromToModificaLiberacaoUsuario(ModificaLiberacaoUsuarioType.LiberacaoUsuarioAdicionar);
                        _GeProcessoToProcess = LiberacaoUsuarioProcess.CreateInstance.TaskGetCollectionGeProcessoByEmpresaAplicacaoTipoProcesso(_CodigoEmpresa, _CodigoAplicacao, string.Empty, _TipoDeModificacao);
                        break;
                    case ModificaLiberacaoUsuarioType.LiberacaoUsuarioAlterar:
                        _TipoDeModificacao = LiberacaoUsuarioProcess.CreateInstance.FromToModificaLiberacaoUsuario(ModificaLiberacaoUsuarioType.LiberacaoUsuarioAlterar);
                        _GeProcessoToProcess = LiberacaoUsuarioProcess.CreateInstance.TaskGetCollectionGeProcessoByEmpresaAplicacaoTipoProcesso(_CodigoEmpresa, _CodigoAplicacao, _Usuario, _TipoDeModificacao);
                        break;
                    default:
                        break;
                }

                ConfiguraGridDadosLiberacaoProcessosUsuario(_GeProcessoToProcess);
            }
            else
            {
                tlStrpBtnFindProcesses.Enabled = true;
                tlStrpCmbBxFindProcesses.Enabled = true;
            }
        }

        private void tlStrpBtnSelectAllProcesses_Click(object sender, EventArgs e)
        {
            CheckAllProcess();
        }

        private void CheckAllProcess()
        {
            List<ProcessoLiberacaoUsuario> _ProcessoLiberacaoUsuarioCollectionFromDataGrid = null;
            List<ProcessoLiberacaoUsuario> _ProcessoLiberacaoUsuarioCollectionFromCheck = null;

            if (bsLiberacaoUsuario.DataSource != null)
            {
                _ProcessoLiberacaoUsuarioCollectionFromDataGrid = bsLiberacaoUsuario.DataSource as List<ProcessoLiberacaoUsuario>;
                bsLiberacaoUsuario.DataSource = null;

                _ProcessoLiberacaoUsuarioCollectionFromCheck = new List<ProcessoLiberacaoUsuario>();

                foreach (ProcessoLiberacaoUsuario _Processo in _ProcessoLiberacaoUsuarioCollectionFromDataGrid)
                {
                    _ProcessoLiberacaoUsuarioCollectionFromCheck.Add(new ProcessoLiberacaoUsuario(true, _Processo.CodigoProcesso, _Processo.DescricaoProcesso, _Processo.CodigoTipoProcesso, _Processo.CodigoAplicacao, _Processo.Ativo, _Processo.Form, _Processo.SequenciaProcesso));
                }

                AjustaCamposDoDataGridParaExibicao(_ProcessoLiberacaoUsuarioCollectionFromCheck);
            }
        }

        private void tlStrpBtnClearAllProcesses_Click(object sender, EventArgs e)
        {
            UncheckAllProcess();
        }

        private void UncheckAllProcess()
        {
            List<ProcessoLiberacaoUsuario> _ProcessoLiberacaoUsuarioCollectionFromDataGrid = null;
            List<ProcessoLiberacaoUsuario> _ProcessoLiberacaoUsuarioCollectionFromCheck = null;

            if (bsLiberacaoUsuario.DataSource != null)
            {
                _ProcessoLiberacaoUsuarioCollectionFromDataGrid = bsLiberacaoUsuario.DataSource as List<ProcessoLiberacaoUsuario>;
                bsLiberacaoUsuario.DataSource = null;

                _ProcessoLiberacaoUsuarioCollectionFromCheck = new List<ProcessoLiberacaoUsuario>();

                foreach (ProcessoLiberacaoUsuario _Processo in _ProcessoLiberacaoUsuarioCollectionFromDataGrid)
                {
                    _ProcessoLiberacaoUsuarioCollectionFromCheck.Add(new ProcessoLiberacaoUsuario(false, _Processo.CodigoProcesso, _Processo.DescricaoProcesso, _Processo.CodigoTipoProcesso, _Processo.CodigoAplicacao, _Processo.Ativo, _Processo.Form, _Processo.SequenciaProcesso));
                }

                AjustaCamposDoDataGridParaExibicao(_ProcessoLiberacaoUsuarioCollectionFromCheck);
            }
        }
    }
}
