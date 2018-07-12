using BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects;
using BrSoftNet.App.Business.Processes.OverallRecord.Enumerators;
using BrSoftNet.App.Business.Processes.OverallRecord.Tasks;
using BrSoftNet.App.UI.Win.OverallRecord.DataMaintenance;
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
using System.Data;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.OverallRecord.FullScreenSearchForm
{
    public partial class SearchFormRegistroGeral : Form
    {
        #region ...::: Private Consts :::...

        private const string _TituloProcesso = "Processo Gestão de Estados - {0}";
        private const string _TituloProcessoAcaoInclusao = "Inclusão";
        private const string _TituloProcessoAcaoAlteracao = "Alteração";
        private const string _TituloProcessoAcaoExclusao = "Exclusão";

        #endregion

        #region ...::: Private Variable :::...

        private string _StrFilter = string.Empty;
        private int _IsFilter = 0;
        private int _IdEmpresa = 0;
        private int _IdRegistro = 0;
        private int _IdStatus = 0;
        private string _RazaoSocial = string.Empty;
        private string _TipoRg = string.Empty;
        private string _Usuario = string.Empty;
        private string _NomeFantazia = string.Empty;
        private string _OpitanteSimples = string.Empty;
        private string _TipoModificacao;
        private DataSet _MapaDadosProcessoRegistroGeral = null;
        private DateTime _DataHora = Convert.ToDateTime("01/01/0001 00:00:00");

        #endregion

        #region ...::: Private Service Variable :::...

        private GenericSerializer<RegistroGeralProcessMapping> _Map = null;

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;

        private ChangeItem _LogIdEmpresa = null;
        private ChangeItem _LogIdRg = null;
        private ChangeItem _LogRazaoSocial = null;
        private ChangeItem _LogTipoRg = null;
        private ChangeItem _LogIdStatus = null;
        private ChangeItem _LogDataHora = null;
        private ChangeItem _LogUsuario = null;
        private ChangeItem _LogNomeFantazia = null;
        private ChangeItem _LogOpitanteSimples = null;

        private List<ChangeItem> _ChangeItems = null;

        private ThrowingException _ThrowingException = null;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpresaFromDashboard { get; set; }

        public int IdRegGeralLogDashboard { get; set; }

        public string UsuarioLoginDashboard { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        public SearchFormRegistroGeral()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.FillDataGrid(OverallRecordProcess.CreateInstance.TaskGetCollectionRgRegGeral(string.Empty, 0));
        }

        private void FillDataGrid(List<RgRegGeral> _RgRegGeralCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateOverallRecord.RgRegGeralCollection = _RgRegGeralCollection;

                bsRgRegistroGeral.DataSource = AppStateOverallRecord.RgRegGeralCollection;
                bsRgRegistroGeral.AllowNew = false;

                dataGridSearchModule.DataSource = bsRgRegistroGeral;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["IdEmpr"].HeaderText = "ID Empresa";
                dataGridSearchModule.Columns["IdEmpr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridSearchModule.Columns["IdRg"].HeaderText = "ID Registro";
                dataGridSearchModule.Columns["IdRg"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridSearchModule.Columns["RazaoSocial"].HeaderText = "Razão Social";
                dataGridSearchModule.Columns["RazaoSocial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridSearchModule.Columns["TipoRg"].HeaderText = "Tipo Registro";
                dataGridSearchModule.Columns["TipoRg"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridSearchModule.Columns["IdStatus"].HeaderText = "Status";
                dataGridSearchModule.Columns["IdStatus"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridSearchModule.Columns["DataHora"].HeaderText = "Data / Hora";
                dataGridSearchModule.Columns["DataHora"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridSearchModule.Columns["Usuario"].HeaderText = "Usuário";
                dataGridSearchModule.Columns["Usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridSearchModule.Columns["NomeFantasia"].HeaderText = "Nome Fantasia";
                dataGridSearchModule.Columns["NomeFantasia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridSearchModule.Columns["OptanteSimples"].HeaderText = "Optante Somples";
                dataGridSearchModule.Columns["OptanteSimples"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AdicionarRegistroGeral();
        }

        private void AdicionarRegistroGeral()
        {
            UpdateFormRegistroGeral _UpdateFormRegistroGeral = new UpdateFormRegistroGeral();
            _UpdateFormRegistroGeral.ModificaRegistroGeralType = ModificaRegistroGeralType.RegistroGeralAdicionar;
            _UpdateFormRegistroGeral.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormRegistroGeral.IdRg = IdRegGeralLogDashboard;
            _UpdateFormRegistroGeral.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormRegistroGeral.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoRegGeral, FormsMessages.TituloProcessoAcaoRegGeralInclusao);

            _IdEmpresa = IdEmpresaFromDashboard;
            _Usuario = UsuarioLoginDashboard;

            _UpdateFormRegistroGeral.IdEmpr = _IdEmpresa;
            _UpdateFormRegistroGeral.UsuarioLogin = _Usuario;

            AppStateOverallRecord.RgRegGeral = new RgRegGeral();
            AppStateOverallRecord.RgEndereco = new RgEndereco();
            AppStateOverallRecord.RgFisicasJuridica = new RgFisicaJuridica();

            try
            {
                _UpdateFormRegistroGeral.ShowDialog();
            }
            finally
            {
                AppStateOverallRecord.IdEmpresa = _UpdateFormRegistroGeral.IdEmpr;
                AppStateOverallRecord.IdRegistro = _UpdateFormRegistroGeral.IdRg;

                _UpdateFormRegistroGeral.Dispose();

                if ((AppStateOverallRecord.IdEmpresa != 0) && (AppStateOverallRecord.IdRegistro != 0))
                {
                    _StrFilter = string.Format(" WHERE RG.cod_empr = {0} AND RG.cod_rg = {1} ", AppStateOverallRecord.IdEmpresa, AppStateOverallRecord.IdRegistro);
                    _IsFilter = 1;

                    dataGridSearchModule.DataSource = null;
                    FillDataGrid(OverallRecordProcess.CreateInstance.TaskGetCollectionRgRegGeral(_StrFilter, _IsFilter));
                }
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, System.EventArgs e)
        {
            AlterarRegistroGeral();
        }

        private void AlterarRegistroGeral()
        {
            if ((dataGridSearchModule.CurrentRow.Cells["IdEmpr"].Value != null) && (dataGridSearchModule.CurrentRow.Cells["IdRg"].Value != null))
            {
                UpdateFormRegistroGeral _UpdateFormRegistroGeral = new UpdateFormRegistroGeral();
                _UpdateFormRegistroGeral.ModificaRegistroGeralType = ModificaRegistroGeralType.RegistroGeralAlterar;
                _UpdateFormRegistroGeral.IdEmpr = IdEmpresaFromDashboard;
                _UpdateFormRegistroGeral.IdRg = IdRegGeralLogDashboard;
                _UpdateFormRegistroGeral.UsuarioLogin = UsuarioLoginDashboard;
                _UpdateFormRegistroGeral.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoRegGeral, FormsMessages.TituloProcessoAcaoRegGeralAlteracao);

                _IdEmpresa = (int)dataGridSearchModule.CurrentRow.Cells["IdEmpr"].Value;
                _IdRegistro = (int)dataGridSearchModule.CurrentRow.Cells["IdRg"].Value;

                _UpdateFormRegistroGeral.IdEmpr = _IdEmpresa;
                _UpdateFormRegistroGeral.IdRg = _IdRegistro;

                AtualizaMapaDadosProcessoRegistroGeral(_IdEmpresa, _IdRegistro);

                try
                {
                    _UpdateFormRegistroGeral.ShowDialog();
                }
                finally
                {
                    AppStateOverallRecord.IdEmpresa = _UpdateFormRegistroGeral.IdEmpr;
                    AppStateOverallRecord.IdRegistro = _UpdateFormRegistroGeral.IdRg;

                    _UpdateFormRegistroGeral.Dispose();

                    if ((AppStateOverallRecord.IdEmpresa != 0) && (AppStateOverallRecord.IdRegistro != 0))
                    {
                        _StrFilter = string.Format(" WHERE RG.cod_empr = {0} AND RG.cod_rg = {1} ", AppStateOverallRecord.IdEmpresa, AppStateOverallRecord.IdRegistro);
                        _IsFilter = 1;

                        dataGridSearchModule.DataSource = null;
                        FillDataGrid(OverallRecordProcess.CreateInstance.TaskGetCollectionRgRegGeral(_StrFilter, _IsFilter));
                    }
                }
            }
        }

        private void AtualizaMapaDadosProcessoRegistroGeral(int _IdEmpresa, int _IdRegistro)
        {
            List<RgTelefone> _RgTelefoneCollection = new List<RgTelefone>();
            List<RgRegGeralNatureza> _RgRegGeralNaturezaCollection = new List<RgRegGeralNatureza>();

            _MapaDadosProcessoRegistroGeral = OverallRecordProcess.CreateInstance.TaskGetCollectionsRegistroGeral(_IdEmpresa, _IdRegistro);

            if (_MapaDadosProcessoRegistroGeral != null)
            {
                if (_MapaDadosProcessoRegistroGeral.Tables[0].Rows.Count == 1)
                {
                    AppStateOverallRecord.RgRegGeral = new RgRegGeral(_MapaDadosProcessoRegistroGeral.Tables[0].Rows[0]);
                }

                if (_MapaDadosProcessoRegistroGeral.Tables[1].Rows.Count == 1)
                {
                    AppStateOverallRecord.RgEndereco = new RgEndereco(_MapaDadosProcessoRegistroGeral.Tables[1].Rows[0]);
                }

                if (_MapaDadosProcessoRegistroGeral.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow _Row in _MapaDadosProcessoRegistroGeral.Tables[2].Rows)
                    {
                        _RgTelefoneCollection.Add(new RgTelefone(_Row));
                    }

                    AppStateOverallRecord.RgTelefoneCollection = _RgTelefoneCollection;
                }

                if (_MapaDadosProcessoRegistroGeral.Tables[3].Rows.Count > 0)
                {
                    foreach (DataRow _Row in _MapaDadosProcessoRegistroGeral.Tables[3].Rows)
                    {
                        _RgRegGeralNaturezaCollection.Add(new RgRegGeralNatureza(_Row));
                    }

                    AppStateOverallRecord.RgRegGeralNaturezaCollection = _RgRegGeralNaturezaCollection;
                }

                if (_MapaDadosProcessoRegistroGeral.Tables[4].Rows.Count == 1)
                {
                    AppStateOverallRecord.RgFisicasJuridica = new RgFisicaJuridica(_MapaDadosProcessoRegistroGeral.Tables[4].Rows[0]);
                }
            }
        }

        private void tlstrpBtnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        }

        private void tlstrpBtnDelete_Click(object sender, System.EventArgs e)
        {
            ExcluiParametroGerenciador();
        }

        private void ExcluiParametroGerenciador()
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnDelete_Click";

            int _IdExecute = 0;
            string _ModifyType = string.Empty;
            string _XML = string.Empty;
            RegistroGeralProcessMapping _RegistroGeralProcessMapping = null;

            if ((dataGridSearchModule.CurrentRow.Cells["IdEmpr"].Value != null) && (dataGridSearchModule.CurrentRow.Cells["IdRg"].Value != null))
            {
                if (MessageBox.Show("Deseja excluir este registro?",
                                    UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoRegGeral, FormsMessages.TituloProcessoAcaoParametroRgExclusao),
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (_ThrowingException != null) { _ThrowingException = null; }   
                        _IdEmpresa = (int)dataGridSearchModule.CurrentRow.Cells["IdEmpr"].Value;
                        _IdRegistro = (int)dataGridSearchModule.CurrentRow.Cells["IdRg"].Value;
                        AtualizaMapaDadosProcessoRegistroGeral(_IdEmpresa, _IdRegistro);
                        _RegistroGeralProcessMapping = OverallRecordServiceHelper.CreateInstance.RetornaMapaDadosRegistroGeral(AppStateOverallRecord.RgRegGeral, AppStateOverallRecord.RgEndereco, AppStateOverallRecord.RgTelefoneCollection, AppStateOverallRecord.RgRegGeralNaturezaCollection, AppStateOverallRecord.RgFisicasJuridica);
                        _TipoModificacao = OverallRecordProcess.CreateInstance.FromToModificaParametroGerenciador(ModificaRegistroGeralType.RegistroGeralExcluir);
                        _XML = SerializationData.CreateInstance.GetSerializableData(_RegistroGeralProcessMapping, "RegistroGeralProcessMapping");
                        FillLogHeaderFromDeleteModify(_IdEmpresa, _IdRegistro, _RazaoSocial, _Usuario, _TipoRg, _IdStatus, _DataHora, _NomeFantazia, _OpitanteSimples);
                        _IdExecute = OverallRecordProcess.CreateInstance.TaskModifyProcessGegistroGeral(_XML, _TipoModificacao);
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

                        if (_LogIdEmpresa != null) { _LogIdEmpresa.ValorNovo = _IdEmpresa; }
                        if (_LogIdRg != null) { _LogIdRg.ValorNovo = _IdRegistro; }
                        if (_LogRazaoSocial != null) { _LogRazaoSocial.ValorNovo = _RazaoSocial;}
                        if (_LogUsuario != null) { _LogUsuario.ValorNovo = _Usuario; }
                        if (_LogTipoRg != null) { _LogTipoRg.ValorNovo = _TipoRg; }
                        if (_LogIdStatus != null) { _LogIdStatus.ValorNovo = _IdStatus; }
                        if (_LogDataHora != null) { _LogDataHora.ValorNovo = _DataHora; }
                        if (_LogNomeFantazia != null) { _LogNomeFantazia.ValorNovo = _NomeFantazia; }
                        if (_LogOpitanteSimples != null) { _LogOpitanteSimples.ValorNovo = _OpitanteSimples; }

                        _ChangeItems = new List<ChangeItem>();
                        _ChangeItems.Add(_LogIdEmpresa);
                        _ChangeItems.Add(_LogIdRg);
                        _ChangeItems.Add(_LogRazaoSocial);
                        _ChangeItems.Add(_LogUsuario);
                        _ChangeItems.Add(_LogTipoRg);
                        _ChangeItems.Add(_LogIdStatus);
                        _ChangeItems.Add(_LogDataHora);
                        _ChangeItems.Add(_LogNomeFantazia);
                        _ChangeItems.Add(_LogOpitanteSimples);

                        #endregion

                        ExecuteModifyExceptionLogRgGeral(_ChangesHeader, _ChangeItems, _ThrowingException);
                    }
                    finally
                    {
                        dataGridSearchModule.DataSource = null;
                        FillDataGrid(OverallRecordProcess.CreateInstance.TaskGetCollectionRgRegGeral(string.Empty, 0));

                        if (_ThrowingException == null)
                        {
                            #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                            if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                            #endregion

                            #region ...::: Atualiza os Itens do Log de Modificações :::...

                            if (_LogIdEmpresa != null) { _LogIdEmpresa.ValorNovo = _IdEmpresa; }
                            if (_LogIdRg != null) { _LogIdRg.ValorNovo = _IdRegistro; }
                            if (_LogRazaoSocial != null) { _LogRazaoSocial.ValorNovo = _RazaoSocial; }
                            if (_LogUsuario != null) { _LogUsuario.ValorNovo = _Usuario; }
                            if (_LogTipoRg != null) { _LogTipoRg.ValorNovo = _TipoRg; }
                            if (_LogIdStatus != null) { _LogIdStatus.ValorNovo = _IdStatus; }
                            if (_LogDataHora != null) { _LogDataHora.ValorNovo = _DataHora; }
                            if (_LogNomeFantazia != null) { _LogNomeFantazia.ValorNovo = _NomeFantazia; }
                            if (_LogOpitanteSimples != null) { _LogOpitanteSimples.ValorNovo = _OpitanteSimples; }

                            _ChangeItems = new List<ChangeItem>();
                            _ChangeItems.Add(_LogIdEmpresa);
                            _ChangeItems.Add(_LogIdRg);
                            _ChangeItems.Add(_LogRazaoSocial);
                            _ChangeItems.Add(_LogUsuario);
                            _ChangeItems.Add(_LogTipoRg);
                            _ChangeItems.Add(_LogIdStatus);
                            _ChangeItems.Add(_LogDataHora);
                            _ChangeItems.Add(_LogNomeFantazia);
                            _ChangeItems.Add(_LogOpitanteSimples);

                            #endregion

                            ExecuteModifyLogRegGeral(_ChangesHeader, _ChangeItems);
                        }
                    }
                }
            }
        }

        private void ExecuteModifyLogRegGeral(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }

        private void ExecuteModifyExceptionLogRgGeral(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void FillLogHeaderFromDeleteModify(int _IdEmpresa, int _IdRegistro, string _RazaoSocial, string _Usuario, string _TipoRg, int _IdStatus, DateTime _DataHora, string _NomeFantazia, string _OpitanteSimples)
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgRegistroGeral.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdRegGeralLogDashboard;
            _ChangesHeader.TipoModificacao = OverallRecordProcess.CreateInstance.FromToModificaParametroGerenciador(ModificaRegistroGeralType.RegistroGeralExcluir);
            _ChangesHeader.Usuario = this.UsuarioLoginDashboard;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            // Codigo Empresa
            _LogIdEmpresa = new ChangeItem();
            _LogIdEmpresa.IdChangeHeader = _ChangesHeader.Id;
            _LogIdEmpresa.IdItem = 1;
            _LogIdEmpresa.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogIdEmpresa.NomeCampo = DboRgRegistroGeral.NomeIdEmpresa;
            _LogIdEmpresa.ValorAntigo = _IdEmpresa;

            // Codigo Rg
            _LogIdRg = new ChangeItem();
            _LogIdRg.IdChangeHeader = _ChangesHeader.Id;
            _LogIdRg.IdItem = 2;
            _LogIdRg.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogIdRg.NomeCampo = DboRgRegistroGeral.NomeIdRg;
            _LogIdRg.ValorAntigo = _IdRegistro;

            // Razão Social
            _LogRazaoSocial = new ChangeItem();
            _LogRazaoSocial.IdChangeHeader = _ChangesHeader.Id;
            _LogRazaoSocial.IdItem = 3;
            _LogRazaoSocial.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogRazaoSocial.NomeCampo = DboRgRegistroGeral.NomeRazaoSocial;
            _LogRazaoSocial.ValorAntigo = _RazaoSocial;

            // Usuário
            _LogUsuario = new ChangeItem();
            _LogUsuario.IdChangeHeader = _ChangesHeader.Id;
            _LogUsuario.IdItem = 4;
            _LogUsuario.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogUsuario.NomeCampo = DboRgRegistroGeral.NomeUsuario;
            _LogUsuario.ValorAntigo = _Usuario;

            // Tipo Rg
            _LogTipoRg = new ChangeItem();
            _LogTipoRg.IdChangeHeader = _ChangesHeader.Id;
            _LogTipoRg.IdItem = 5;
            _LogTipoRg.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogTipoRg.NomeCampo = DboRgRegistroGeral.NomeTipoRg;
            _LogTipoRg.ValorAntigo = _TipoRg;

            // Cod Status
            _LogIdStatus = new ChangeItem();
            _LogIdStatus.IdChangeHeader = _ChangesHeader.Id;
            _LogIdStatus.IdItem = 6;
            _LogIdStatus.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogIdStatus.NomeCampo = DboRgRegistroGeral.NomeIdStatus;
            _LogIdStatus.ValorAntigo = _IdStatus;

            // Data Hora
            _LogDataHora = new ChangeItem();
            _LogDataHora.IdChangeHeader = _ChangesHeader.Id;
            _LogDataHora.IdItem = 7;
            _LogDataHora.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogDataHora.NomeCampo = DboRgRegistroGeral.NomeDataHora;
            _LogDataHora.ValorAntigo = _DataHora;

            // Nome Fantazia
            _LogNomeFantazia = new ChangeItem();
            _LogNomeFantazia.IdChangeHeader = _ChangesHeader.Id;
            _LogNomeFantazia.IdItem = 8;
            _LogNomeFantazia.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogNomeFantazia.NomeCampo = DboRgRegistroGeral.NomeNomeFantasia;
            _LogNomeFantazia.ValorAntigo = _NomeFantazia;

            // Opitante Simples
            _LogOpitanteSimples = new ChangeItem();
            _LogOpitanteSimples.IdChangeHeader = _ChangesHeader.Id;
            _LogOpitanteSimples.IdItem = 9;
            _LogOpitanteSimples.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogOpitanteSimples.NomeCampo = DboRgRegistroGeral.NomeOptanteSimples;
            _LogOpitanteSimples.ValorAntigo = _OpitanteSimples;

            #endregion
        }

        private void tlstrpBtnFirst_Click(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgRegistroGeral.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgRegistroGeral.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgRegistroGeral.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgRegistroGeral.MoveLast();
            }
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, EventArgs e)
        {
            this.dataGridSearchModule.DataSource = null;
            this.FillDataGrid(OverallRecordProcess.CreateInstance.TaskGetCollectionRgRegGeral(string.Empty, 0));
        }

        private void tlstrpBtnSearchCriteria_Click(object sender, EventArgs e)
        {
            ShowFormFilterRegistroGeral();
        }

        private void ShowFormFilterRegistroGeral()
        {
            FilterSearchFormRegistroGeral _FilterSearchFormRegistroGeral = new FilterSearchFormRegistroGeral();
            _FilterSearchFormRegistroGeral.IdEmpresa = IdEmpresaFromDashboard;

            try
            {
                _FilterSearchFormRegistroGeral.ShowDialog();
                _StrFilter = _FilterSearchFormRegistroGeral.Filter;
                _IsFilter = _FilterSearchFormRegistroGeral.IsFilter;
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally
            {
                this.dataGridSearchModule.DataSource = null;
                this.FillDataGrid(OverallRecordProcess.CreateInstance.TaskGetCollectionRgRegGeral(_StrFilter, _IsFilter));
            }
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                this.AlterarRegistroGeral();
            }
        }

        private void SearchFormRegistroGeral_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }
    }
    internal static class DboRgRegistroGeral
    {
        #region ...::: Private Constantes :::...

        private const string _NomeIdEmpresa = "cod_empr";
        private const string _NomeIdRg = "cod_rg";
        private const string _NomeRazaoSocial = "razao_social";
        private const string _NomeTipoRg = "tipo_rg";
        private const string _NomeIdStatus = "cod_status";
        private const string _NomeDataHora = "data_hora";
        private const string _NomeUsuario = "usuario";
        private const string _NomeNomeFantasia = "nome_fantasia";
        private const string _NomeOptanteSimples = "optante_simples";
        private const string _NomeTabela = "rg_reg_geral";
        private const string _NomeProcesso = "Reg Geral";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeIdEmpresa { get { return _NomeIdEmpresa; } }
        public static string NomeIdRg { get { return _NomeIdRg; } }
        public static string NomeRazaoSocial { get { return _NomeRazaoSocial; } }
        public static string NomeTipoRg { get { return _NomeTipoRg; } }
        public static string NomeIdStatus { get { return _NomeIdStatus; } }
        public static string NomeDataHora { get { return _NomeDataHora; } }
        public static string NomeUsuario { get { return _NomeUsuario; } }
        public static string NomeNomeFantasia { get { return _NomeNomeFantasia; } }
        public static string NomeOptanteSimples { get { return _NomeOptanteSimples; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
