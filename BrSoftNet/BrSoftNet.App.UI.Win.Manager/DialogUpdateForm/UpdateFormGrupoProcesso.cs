using BrSoftNet.App.Business.Processes.Manager.Entities;
using BrSoftNet.App.Business.Processes.Manager.Enumerators;
using BrSoftNet.App.Business.Processes.Manager.Tasks;
using BrSoftNet.App.UI.Win.Manager.DataMaintenance;
using BrSoftNet.App.UI.Win.Manager.State;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Log.Structures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Manager.DialogUpdateForm
{
    public partial class UpdateFormGrupoProcesso : Form
    {
        #region ...::: Private Constants :::...

        private const string _COLLECTION_NAME = "GrupoProcessoMapping";

        #endregion

        #region ...::: Private Variable :::...

        private DataSet _DataSetProcessoGrupoProcesso = null;
        private List<EmpresaGrupoProcesso> _EmpresaCollection = null;
        private List<AplicacaoEmpresaGrupo> _AplicacaoCollection = null;
        private List<GeGrupo> _GrupoCollection = null;
        private List<GeTipoProcesso> _TipoProcessoCollection = null;
        private List<GeProcesso> _GeProcessoToProcess = null;
        private List<ProcessoGrupoProcesso> _ProcessoGrupoProcessoToDataGrid = null;
        private List<GeGrupoProcesso> _GeGrupoProcessoMapping = null;
        private int _CodigoEmpresa = 0;
        private int _Grupo = 0;
        private string _TipoModificacao = string.Empty;
        private int _IdExecute = 0;
        GrupoProcessoProcessMapping _GrupoProcessoProcessMapping = null;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpr { get; set; }
        public int IdRg { get; set; }
        public string UsuarioLogin { get; set; }
        public ModificaGrupoProcessoType ModificaGrupoProcessoType { get; set; }
        private List<EmpresaGrupoProcesso> EmpresaCollection { get; set; }
        private List<AplicacaoEmpresaGrupo> AplicacaoCollection { get; set; }
        private List<GeGrupo> GrupoCollection { get; set; }
        private List<GeTipoProcesso> TipoProcessoCollection { get; set; }
        private List<GeProcesso> ProcessoCollection { get; set; }
        public int CodigoEmpresa { get; set; }
        public int CodigoGrupo { get; set; }
        public int CodigoAplicacao { get; set; }
        public int CodigoTipoProcesso { get; set; }
        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;

        private ChangeItem _LogCodigoEmpresa = null;
        private ChangeItem _LogCodigoGrupo = null;
        private ChangeItem _LogCodigoProcesso = null;

        private List<ChangeItem> _ChangeItems = null;
        private ThrowingException _ThrowingException = null;

        private string _IdExcepitionLog = string.Empty;
        private string _MenssageLogError = string.Empty;

        #endregion

        public UpdateFormGrupoProcesso()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();

            this.cmbBxEmpresa.GotFocus += cmbBxEmpresa_GotFocus;
            this.cmbBxEmpresa.LostFocus += cmbBxEmpresa_LostFocus;

            this.cmbBxAplicacao.GotFocus += cmbBxAplicacao_GotFocus;
            this.cmbBxAplicacao.LostFocus += cmbBxAplicacao_LostFocus;

            this.cmbBxGrupo.GotFocus += cmbBxGrupo_GotFocus;
            this.cmbBxGrupo.LostFocus += cmbBxGrupo_LostFocus;

            this.tlStrpCmbBxFindProcesses.ComboBox.GotFocus += ComboBox_GotFocus;
            this.tlStrpCmbBxFindProcesses.ComboBox.LostFocus += ComboBox_LostFocus;
        }

        void ComboBox_LostFocus(object sender, EventArgs e)
        {
            this.tlStrpCmbBxFindProcesses.ComboBox.BackColor = Color.White;
        }

        void ComboBox_GotFocus(object sender, EventArgs e)
        {
            this.tlStrpCmbBxFindProcesses.ComboBox.BackColor = Color.LightYellow;
        }

        void cmbBxEmpresa_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxEmpresa.BackColor = Color.White;
        }

        void cmbBxEmpresa_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxEmpresa.BackColor = Color.LightYellow;
        }

        void cmbBxAplicacao_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxAplicacao.BackColor = Color.White;
        }

        void cmbBxAplicacao_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxAplicacao.BackColor = Color.LightYellow;
        }

        void cmbBxGrupo_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxGrupo.BackColor = Color.White;
        }

        void cmbBxGrupo_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxGrupo.BackColor = Color.LightYellow;
        }

        private void InicialiazeUpdateForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void UpdateFormGrupoProcesso_Load(object sender, System.EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;

            _DataSetProcessoGrupoProcesso = GrupoProcessoProcess.CreateInstance.GetCollectionGrupoProcessoTask();

            PreencheEmpresaCollection();
            PreencheAplicacaoCollection();
            PreencheGrupoCollection();
            PreencheTipoProcessoCollection();
            
            switch (ModificaGrupoProcessoType)
            {
                case ModificaGrupoProcessoType.GrupoProcessoAdicionar:
                    FillDataLiberacaoUsuarioToExecuteAddModify();
                    break;
                case ModificaGrupoProcessoType.GrupoProcessoAlterar:
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
                _EmpresaCollection = new List<EmpresaGrupoProcesso>();
            }

            foreach (DataRow _Row in _DataSetProcessoGrupoProcesso.Tables[0].Rows)
            {
                _EmpresaCollection.Add(new EmpresaGrupoProcesso(_Row));
            }

            EmpresaCollection = _EmpresaCollection;
        }

        private void PreencheAplicacaoCollection()
        {
            if (_AplicacaoCollection == null)
            {
                _AplicacaoCollection = new List<AplicacaoEmpresaGrupo>();
            }

            foreach (DataRow _Row in _DataSetProcessoGrupoProcesso.Tables[1].Rows)
            {
                _AplicacaoCollection.Add(new AplicacaoEmpresaGrupo(_Row));
            }

            AplicacaoCollection = _AplicacaoCollection;
        }

        private void PreencheGrupoCollection()
        {
            if (_GrupoCollection == null)
            {
                _GrupoCollection = new List<GeGrupo>();
            }

            foreach (DataRow _Row in _DataSetProcessoGrupoProcesso.Tables[2].Rows)
            {
                _GrupoCollection.Add(new GeGrupo(_Row));
            }

            GrupoCollection = _GrupoCollection;
        }

        private void PreencheTipoProcessoCollection()
        {
            if (_TipoProcessoCollection == null)
            {
                _TipoProcessoCollection = new List<GeTipoProcesso>();
            }

            foreach (DataRow _Row in _DataSetProcessoGrupoProcesso.Tables[3].Rows)
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
            cmbBxEmpresa.SelectedValue = this.CodigoEmpresa;

            cmbBxAplicacao.DataSource = AplicacaoCollection;
            cmbBxAplicacao.ValueMember = "CodigoAplicacao";
            cmbBxAplicacao.DisplayMember = "DescricaoAplicacao";
            cmbBxAplicacao.SelectedValue = this.CodigoAplicacao;

            cmbBxGrupo.DataSource = GrupoCollection;
            cmbBxGrupo.ValueMember = "CodigoGrupo";
            cmbBxGrupo.DisplayMember = "DescricaoGrupo";
            cmbBxGrupo.SelectedValue = this.CodigoGrupo;

            tlStrpCmbBxFindProcesses.ComboBox.DataSource = TipoProcessoCollection;
            tlStrpCmbBxFindProcesses.ComboBox.ValueMember = "CodigoTipoProcesso";
            tlStrpCmbBxFindProcesses.ComboBox.DisplayMember = "DescricaoTipoProcesso";
            tlStrpCmbBxFindProcesses.ComboBox.SelectedValue = this.CodigoTipoProcesso;

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

            cmbBxGrupo.DataSource = GrupoCollection;
            cmbBxGrupo.ValueMember = "CodigoGrupo";
            cmbBxGrupo.DisplayMember = "DescricaoGrupo";

            tlStrpCmbBxFindProcesses.ComboBox.DataSource = TipoProcessoCollection;
            tlStrpCmbBxFindProcesses.ComboBox.ValueMember = "CodigoTipoProcesso";
            tlStrpCmbBxFindProcesses.ComboBox.DisplayMember = "DescricaoTipoProcesso";

            AppStateManager.CodigoEmpresaLiberacaoUsuario = Convert.ToInt32(cmbBxEmpresa.SelectedValue);
            AppStateManager.CodigoAplicacao = Convert.ToInt32(cmbBxAplicacao.SelectedValue);
            AppStateManager.CodigoGrupo = Convert.ToInt32(cmbBxGrupo.SelectedValue);
            AppStateManager.CodigoTipoProcesso = Convert.ToInt32(tlStrpCmbBxFindProcesses.ComboBox.SelectedValue);

            chckBxExibirTodosOsProcessos.Checked = true;

            ExibeTodosOsProcessos();
        }

        private void ExibeTodosOsProcessos()
        {
            int _CodigoEmpresa = 0;
            int _CodigoAplicacao = 0;
            int _CodigoGrupo = 0;
            string _TipoDeModificacao = string.Empty;

            AppStateManager.CodigoEmpresaGrupoProcesso = Convert.ToInt32(cmbBxEmpresa.SelectedValue);
            AppStateManager.CodigoAplicacaoGrupoProcesso = Convert.ToInt32(cmbBxAplicacao.SelectedValue);
            AppStateManager.CodigoGrupoProcesso = Convert.ToInt32(cmbBxGrupo.SelectedValue);

            if (chckBxExibirTodosOsProcessos.Checked)
            {
                if (bsGrupoProcesso.DataSource != null)
                {
                    bsGrupoProcesso.DataSource = null;
                }

                tlStrpBtnFindProcesses.Enabled = false;
                tlStrpCmbBxFindProcesses.Enabled = false;

                _CodigoEmpresa = AppStateManager.CodigoEmpresaGrupoProcesso;
                _CodigoGrupo = AppStateManager.CodigoGrupoProcesso;
                _CodigoAplicacao = AppStateManager.CodigoAplicacaoGrupoProcesso;

                switch (this.ModificaGrupoProcessoType)
                {
                    case ModificaGrupoProcessoType.GrupoProcessoAdicionar:
                        _TipoDeModificacao = GrupoProcessoProcess.CreateInstance.FromToModificaGrupoProcesso(ModificaGrupoProcessoType.GrupoProcessoAdicionar);
                        _GeProcessoToProcess = GrupoProcessoProcess.CreateInstance.TaskGetCollectionGeProcessoByEmpresaAplicacaoTipoProcesso(_CodigoEmpresa, _CodigoAplicacao, 0, _TipoDeModificacao);
                        break;
                    case ModificaGrupoProcessoType.GrupoProcessoAlterar:
                        _TipoDeModificacao = GrupoProcessoProcess.CreateInstance.FromToModificaGrupoProcesso(ModificaGrupoProcessoType.GrupoProcessoAlterar);
                        _GeProcessoToProcess = GrupoProcessoProcess.CreateInstance.TaskGetCollectionGeProcessoByEmpresaAplicacaoTipoProcesso(_CodigoEmpresa, _CodigoAplicacao, _CodigoGrupo, _TipoDeModificacao);
                        break;
                    default:
                        break;
                }

                ConfiguraGridDadosGrupoProcessos(_GeProcessoToProcess);
            }
            else
            {
                tlStrpBtnFindProcesses.Enabled = true;
                tlStrpCmbBxFindProcesses.Enabled = true;
            }
        }

        private void ConfiguraGridDadosGrupoProcessos(List<GeProcesso> _ProcessosCollection)
        {
            if (_ProcessoGrupoProcessoToDataGrid != null)
            {
                _ProcessoGrupoProcessoToDataGrid = null;
            }

            switch (ModificaGrupoProcessoType)
            {
                case ModificaGrupoProcessoType.GrupoProcessoAdicionar:
                    PreparaGridDadosGrupoProcessosToAdd(_ProcessosCollection);
                    break;
                case ModificaGrupoProcessoType.GrupoProcessoAlterar:
                    PreparaGridDadosGrupoProcessosToUpdate(_ProcessosCollection);
                    break;
                default:
                    break;
            }
        }

        private void PreparaGridDadosGrupoProcessosToUpdate(List<GeProcesso> _ProcessosCollection)
        {
            if (_ProcessoGrupoProcessoToDataGrid == null)
            {
                _ProcessoGrupoProcessoToDataGrid = new List<ProcessoGrupoProcesso>();
            }

            foreach (GeProcesso _Processo in _ProcessosCollection)
            {
                _ProcessoGrupoProcessoToDataGrid.Add(new ProcessoGrupoProcesso(true, _Processo.CodigoProcesso, _Processo.DescricaoProcesso, _Processo.CodigoTipoProcesso, _Processo.CodigoAplicacao, _Processo.Ativo, _Processo.Form, _Processo.SequenciaProcesso));
            }

            AjustaCamposDoDataGridParaExibicao(_ProcessoGrupoProcessoToDataGrid);
        }

        private void PreparaGridDadosGrupoProcessosToAdd(List<GeProcesso> _ProcessosCollection)
        {
            if (_ProcessoGrupoProcessoToDataGrid == null)
            {
                _ProcessoGrupoProcessoToDataGrid = new List<ProcessoGrupoProcesso>();
            }

            foreach (GeProcesso _Processo in _ProcessosCollection)
            {
                _ProcessoGrupoProcessoToDataGrid.Add(new ProcessoGrupoProcesso(false, _Processo.CodigoProcesso, _Processo.DescricaoProcesso, _Processo.CodigoTipoProcesso, _Processo.CodigoAplicacao, _Processo.Ativo, _Processo.Form, _Processo.SequenciaProcesso));
            }

            AjustaCamposDoDataGridParaExibicao(_ProcessoGrupoProcessoToDataGrid);
        }

        private void AjustaCamposDoDataGridParaExibicao(List<ProcessoGrupoProcesso> _ProcessoGrupoProcessoToDataGrid)
        {
            bsGrupoProcesso.DataSource = _ProcessoGrupoProcessoToDataGrid;
            bsGrupoProcesso.AllowNew = false;

            dtGridDadosProcesso.DataSource = bsGrupoProcesso;
            dtGridDadosProcesso.ReadOnly = false;

            dtGridDadosProcesso.Columns["Liberar"].HeaderText = "Liberar";
            dtGridDadosProcesso.Columns["Liberar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGridDadosProcesso.Columns["Liberar"].ReadOnly = false;

            dtGridDadosProcesso.Columns["CodigoProcesso"].HeaderText = "Cód.Proc";
            dtGridDadosProcesso.Columns["CodigoProcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGridDadosProcesso.Columns["CodigoProcesso"].ReadOnly = true;

            dtGridDadosProcesso.Columns["DescricaoProcesso"].HeaderText = "Desc.Processo";
            dtGridDadosProcesso.Columns["DescricaoProcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGridDadosProcesso.Columns["DescricaoProcesso"].ReadOnly = true;

            dtGridDadosProcesso.Columns["CodigoTipoProcesso"].HeaderText = "Cód.Tipo.Proc";
            dtGridDadosProcesso.Columns["CodigoTipoProcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGridDadosProcesso.Columns["CodigoTipoProcesso"].ReadOnly = true;

            dtGridDadosProcesso.Columns["CodigoAplicacao"].HeaderText = "Cód.Aplicação";
            dtGridDadosProcesso.Columns["CodigoAplicacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGridDadosProcesso.Columns["CodigoAplicacao"].ReadOnly = true;

            dtGridDadosProcesso.Columns["Ativo"].HeaderText = "Ativo";
            dtGridDadosProcesso.Columns["Ativo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGridDadosProcesso.Columns["Ativo"].ReadOnly = true;

            dtGridDadosProcesso.Columns["Form"].HeaderText = "Formulário";
            dtGridDadosProcesso.Columns["Form"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGridDadosProcesso.Columns["Form"].ReadOnly = true;

            dtGridDadosProcesso.Columns["SequenciaProcesso"].HeaderText = "Sequência";
            dtGridDadosProcesso.Columns["SequenciaProcesso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGridDadosProcesso.Columns["SequenciaProcesso"].ReadOnly = true;
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, EventArgs e)
        {
            switch (ModificaGrupoProcessoType)
            {
                case ModificaGrupoProcessoType.GrupoProcessoAdicionar:
                    AdicionaVinculoGrupoProcessos();
                    break;
                case ModificaGrupoProcessoType.GrupoProcessoAlterar:
                    ExcluiVinculoGrupoProcessos();
                    break;
                default:
                    break;
            }
        }

        private void ExcluiVinculoGrupoProcessos()
        {
            List<ProcessoGrupoProcesso> _ProcessoGrupoProcessoCollection = null;
            _CodigoEmpresa = AppStateManager.CodigoEmpresaLiberacaoUsuario;
            _Grupo = AppStateManager.CodigoGrupo;
            string _XML = string.Empty;

            if (bsGrupoProcesso.DataSource != null)
            {
                AppStateManager.ProcessoGrupoProcessoCollection = bsGrupoProcesso.DataSource as List<ProcessoGrupoProcesso>;

                _ProcessoGrupoProcessoCollection = AppStateManager.ProcessoGrupoProcessoCollection;

                if (_GeGrupoProcessoMapping == null)
                {
                    _GeGrupoProcessoMapping = new List<GeGrupoProcesso>();
                }

                foreach (ProcessoGrupoProcesso _Process in _ProcessoGrupoProcessoCollection)
                {
                    if (!_Process.Liberar)
                    {
                        _GeGrupoProcessoMapping.Add(new GeGrupoProcesso(_CodigoEmpresa, _Grupo, _Process.CodigoProcesso));
                        AppStateManager.GrupoProcessoCollection = _GeGrupoProcessoMapping;
                    }
                }

                _GrupoProcessoProcessMapping = ManagerServiceHelper.CreateInstance.RetornaDadosGrupoProcesso(AppStateManager.GrupoProcessoCollection);
                _XML = SerializationData.CreateInstance.GetSerializableData(_GrupoProcessoProcessMapping, _COLLECTION_NAME);
                _TipoModificacao = GrupoProcessoProcess.CreateInstance.FromToModificaGrupoProcesso(ModificaGrupoProcessoType.GrupoProcessoAlterar);
                _IdExecute = GrupoProcessoProcess.CreateInstance.TaskModifyProcessGrupoProcesso(_XML, _TipoModificacao);
            }
        }

        private void AdicionaVinculoGrupoProcessos()
        {
            List<ProcessoGrupoProcesso> _ProcessoGrupoProcessoCollection = null;
            _CodigoEmpresa = AppStateManager.CodigoEmpresaLiberacaoUsuario;
            _Grupo = AppStateManager.CodigoGrupo;
            string _XML = string.Empty;

            if (bsGrupoProcesso.DataSource != null)
            {
                AppStateManager.ProcessoGrupoProcessoCollection = bsGrupoProcesso.DataSource as List<ProcessoGrupoProcesso>;

                _ProcessoGrupoProcessoCollection = AppStateManager.ProcessoGrupoProcessoCollection;

                if (_GeGrupoProcessoMapping == null)
                {
                    _GeGrupoProcessoMapping = new List<GeGrupoProcesso>();
                }

                foreach (ProcessoGrupoProcesso _Process in _ProcessoGrupoProcessoCollection)
                {
                    if (_Process.Liberar)
                    {
                        _GeGrupoProcessoMapping.Add(new GeGrupoProcesso(_CodigoEmpresa, _Grupo, _Process.CodigoProcesso));
                        AppStateManager.GrupoProcessoCollection = _GeGrupoProcessoMapping;
                    }
                }

                _GrupoProcessoProcessMapping = ManagerServiceHelper.CreateInstance.RetornaDadosGrupoProcesso(AppStateManager.GrupoProcessoCollection);
                _XML = SerializationData.CreateInstance.GetSerializableData(_GrupoProcessoProcessMapping, _COLLECTION_NAME);
                _TipoModificacao = GrupoProcessoProcess.CreateInstance.FromToModificaGrupoProcesso(ModificaGrupoProcessoType.GrupoProcessoAdicionar);
                _IdExecute = GrupoProcessoProcess.CreateInstance.TaskModifyProcessGrupoProcesso(_XML, _TipoModificacao);
            }
        }

        private void tlStrpBtnFindProcesses_Click(object sender, EventArgs e)
        {
            PreencheGridDadosGrupoProcesso();
        }

        private void PreencheGridDadosGrupoProcesso()
        {
            int _CodigoEmpresa = 0;
            int _CodigoAplicacao = 0;
            int _CodigoGrupo = 0;
            int _CodigoTipoProcesso = 0;
            string _TipoDeModificacao = string.Empty;

            AppStateManager.CodigoEmpresaGrupoProcesso = Convert.ToInt32(cmbBxEmpresa.SelectedValue);
            AppStateManager.CodigoAplicacaoGrupoProcesso = Convert.ToInt32(cmbBxAplicacao.SelectedValue);
            AppStateManager.CodigoGrupoProcesso = Convert.ToInt32(cmbBxGrupo.SelectedValue);
            AppStateManager.CodigoTipoProcessoGrupoProcesso = Convert.ToInt32(tlStrpCmbBxFindProcesses.ComboBox.SelectedValue);

            if (bsGrupoProcesso.DataSource != null)
            {
                bsGrupoProcesso.DataSource = null;
            }

            _CodigoEmpresa = AppStateManager.CodigoEmpresaGrupoProcesso;
            _CodigoAplicacao = AppStateManager.CodigoAplicacaoGrupoProcesso;
            _CodigoGrupo = AppStateManager.CodigoGrupoProcesso;
            _CodigoTipoProcesso = AppStateManager.CodigoTipoProcessoGrupoProcesso;
            
            switch (ModificaGrupoProcessoType)
            {
                case ModificaGrupoProcessoType.GrupoProcessoAdicionar:
                    _TipoDeModificacao = GrupoProcessoProcess.CreateInstance.FromToModificaGrupoProcesso(ModificaGrupoProcessoType.GrupoProcessoAdicionar);
                    _GeProcessoToProcess = GrupoProcessoProcess.CreateInstance.TaskGetCollectionGeProcessoByEmpresaAplicacaoTipoProcesso(_CodigoEmpresa, _CodigoAplicacao, 0, _TipoDeModificacao);
                    break;
                case ModificaGrupoProcessoType.GrupoProcessoAlterar:
                    _TipoDeModificacao = GrupoProcessoProcess.CreateInstance.FromToModificaGrupoProcesso(ModificaGrupoProcessoType.GrupoProcessoAlterar);
                    _GeProcessoToProcess = GrupoProcessoProcess.CreateInstance.TaskGetCollectionGeProcessoByEmpresaAplicacaoTipoProcesso(_CodigoEmpresa, _CodigoAplicacao, _CodigoGrupo, _TipoDeModificacao);
                    break;
                default:
                    break;
            }

            ConfiguraGridDadosGrupoProcesso(_GeProcessoToProcess.FindAll(p => p.CodigoTipoProcesso == _CodigoTipoProcesso));
        }

        private void ConfiguraGridDadosGrupoProcesso(List<GeProcesso> _ProcessosCollection)
        {
            if (_ProcessoGrupoProcessoToDataGrid != null)
            {
                _ProcessoGrupoProcessoToDataGrid = null;
            }

            switch (ModificaGrupoProcessoType)
            {
                case ModificaGrupoProcessoType.GrupoProcessoAdicionar:
                    PreparaGridDadosGrupoProcessosToAdd(_ProcessosCollection);
                    break;
                case ModificaGrupoProcessoType.GrupoProcessoAlterar:
                    PreparaGridDadosGrupoProcessosToUpdate(_ProcessosCollection);
                    break;
                default:
                    break;
            }
        }

        private void tlStrpBtnSelectAllProcesses_Click(object sender, EventArgs e)
        {
            this.CheckAllProcess();
        }

        private void CheckAllProcess()
        {
            List<ProcessoGrupoProcesso> _ProcessoGrupoProcessoCollectionFromDataGrid = null;
            List<ProcessoGrupoProcesso> _ProcessoGrupoProcessoCollectionFromCheck = null;

            if (bsGrupoProcesso.DataSource != null)
            {
                _ProcessoGrupoProcessoCollectionFromDataGrid = bsGrupoProcesso.DataSource as List<ProcessoGrupoProcesso>;
                bsGrupoProcesso.DataSource = null;

                _ProcessoGrupoProcessoCollectionFromCheck = new List<ProcessoGrupoProcesso>();

                foreach (ProcessoGrupoProcesso _Processo in _ProcessoGrupoProcessoCollectionFromDataGrid)
                {
                    _ProcessoGrupoProcessoCollectionFromCheck.Add(new ProcessoGrupoProcesso(true, _Processo.CodigoProcesso, _Processo.DescricaoProcesso, _Processo.CodigoTipoProcesso, _Processo.CodigoAplicacao, _Processo.Ativo, _Processo.Form, _Processo.SequenciaProcesso));
                }

                AjustaCamposDoDataGridParaExibicao(_ProcessoGrupoProcessoCollectionFromCheck);
            }
        }

        private void tlStrpBtnClearAllProcesses_Click(object sender, EventArgs e)
        {
            this.UncheckAllProcess();
        }

        private void UncheckAllProcess()
        {
            List<ProcessoGrupoProcesso> _ProcessoGrupoProcessoCollectionFromDataGrid = null;
            List<ProcessoGrupoProcesso> _ProcessoGrupoProcessoCollectionFromCheck = null;

            if (bsGrupoProcesso.DataSource != null)
            {
                _ProcessoGrupoProcessoCollectionFromDataGrid = bsGrupoProcesso.DataSource as List<ProcessoGrupoProcesso>;
                bsGrupoProcesso.DataSource = null;

                _ProcessoGrupoProcessoCollectionFromCheck = new List<ProcessoGrupoProcesso>();

                foreach (ProcessoGrupoProcesso _Processo in _ProcessoGrupoProcessoCollectionFromDataGrid)
                {
                    _ProcessoGrupoProcessoCollectionFromCheck.Add(new ProcessoGrupoProcesso(false, _Processo.CodigoProcesso, _Processo.DescricaoProcesso, _Processo.CodigoTipoProcesso, _Processo.CodigoAplicacao, _Processo.Ativo, _Processo.Form, _Processo.SequenciaProcesso));
                }

                AjustaCamposDoDataGridParaExibicao(_ProcessoGrupoProcessoCollectionFromCheck);
            }
        }

        private void chckBxExibirTodosOsProcessos_Click(object sender, EventArgs e)
        {
            ExibeTodosOsProcessos();
        }

        private void tlstrpActionMenuBtnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    internal static class DboGeGrupoProcesso
    {
        #region ...::: Private Constantes :::...

        private const string _NomeCodigoEmpresa = "cod_empr";
        private const string _NomeCodigoGrupo = "cod_grupo";
        private const string _NomeCodigoProcesso = "cod_proc";
        private const string _NomeTabela = "ge_grupo_processo";
        private const string _NomeProcesso = "Grupo Processo";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeCodigoEmpresa { get { return _NomeCodigoEmpresa; } }
        public static string NomeCodigoGrupo { get { return _NomeCodigoGrupo; } }
        public static string NomeCodigoProcesso { get { return _NomeCodigoProcesso; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
