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
    public partial class SearchFormMunicipio : Form
    {
        #region ...::: Private Variable :::...

        private int _IdMunicipio = 0;
        private string _Municipio = string.Empty;
        private string _SiglaMunicipio = string.Empty;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpresaFromDashboard { get; set; }
        public string UsuarioLoginDashboard { get; set; }
        public int IdMunicipioLogDashboard { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }
       
        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;

        private ChangeItem _LogIdMunicipio = null;
        private ChangeItem _LogMunicipio = null;
        private ChangeItem _LogUF = null;

        private List<ChangeItem> _ChangeItems = null;

        private ThrowingException _ThrowingException = null;

        #endregion
        public SearchFormMunicipio()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(MunicipioProcess.CreateInstance.TaskGetCollectionRgMunicipioByFilter("", 0));
        }

        private void FillDataGrid(List<RgMunicipio> _RgMunicipioCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateOverallRecord.RgMunicipioCollection = _RgMunicipioCollection;

                bsRgMunicipio.DataSource = AppStateOverallRecord.RgMunicipioCollection;
                bsRgMunicipio.AllowNew = false;

                dataGridSearchModule.DataSource = bsRgMunicipio;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["IdMunicipio"].HeaderText = "Municipio";
                dataGridSearchModule.Columns["IdMunicipio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["Municipio"].HeaderText = "Descrição";
                dataGridSearchModule.Columns["Municipio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["UF"].HeaderText = "Estado";
                dataGridSearchModule.Columns["UF"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void tlstrpBtnFirst_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgMunicipio.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgMunicipio.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgMunicipio.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgMunicipio.MoveLast();
            }
        }

        private void tlstrpBtnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        }

        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AdicionaRgMunicipio();
        }

        private void AdicionaRgMunicipio()
        {
            UpdateFormMunicipio _UpdateFormMunicipio = new UpdateFormMunicipio();
            _UpdateFormMunicipio.ModificaMunicipioType = ModificaMunicipioType.MunicipioAdicionar;
            _UpdateFormMunicipio.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormMunicipio.IdMunicipio = IdMunicipioLogDashboard;
            _UpdateFormMunicipio.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormMunicipio.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoMunicipio, FormsMessages.TituloProcessoAcaoMunicipioInclusao);
            
            try
            {
                _UpdateFormMunicipio.ShowDialog();
            }
            finally
            {
                _UpdateFormMunicipio = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(MunicipioProcess.CreateInstance.TaskGetCollectionRgMunicipioByFilter("", 0));
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, System.EventArgs e)
        {
            AlteraRgMunicipio();
        }

        private void AlteraRgMunicipio()
        {
            string _Filter = string.Empty;

            UpdateFormMunicipio _UpdateFormMunicipio = new UpdateFormMunicipio();
            _UpdateFormMunicipio.ModificaMunicipioType = ModificaMunicipioType.MunicipioAlterar;
            _UpdateFormMunicipio.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormMunicipio.IdMunicipio = IdMunicipioLogDashboard;
            _UpdateFormMunicipio.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormMunicipio.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoMunicipio, FormsMessages.TituloProcessoAcaoMunicipioAlteracao);

            _IdMunicipio = (int)dataGridSearchModule.CurrentRow.Cells["IdMunicipio"].Value;
            _Municipio = (string)dataGridSearchModule.CurrentRow.Cells["Municipio"].Value;
            _SiglaMunicipio = (string)dataGridSearchModule.CurrentRow.Cells["UF"].Value;

            _UpdateFormMunicipio.IdMunicipio = _IdMunicipio;
            _UpdateFormMunicipio.Municipio = _Municipio;
            _UpdateFormMunicipio.UF = _SiglaMunicipio;

            try
            {
                _UpdateFormMunicipio.ShowDialog();
            }
            finally
            {
                AppStateOverallRecord.IdMunicipio = _UpdateFormMunicipio.IdMunicipio;

                _Filter = string.Format(" where cod_municipio = '{0}' ", AppStateOverallRecord.IdMunicipio);

                _UpdateFormMunicipio = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(MunicipioProcess.CreateInstance.TaskGetCollectionRgMunicipioByFilter(_Filter, 1));
            }
        }

        private void tlstrpBtnDelete_Click(object sender, System.EventArgs e)
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnDelete_Click";

            string _ModifyType = string.Empty;
            string _Descricao = string.Empty;
            string _Municipio = string.Empty;
            string _SiglaMunicipio = string.Empty;
            int _IdMunicipio = 0;


            if (dataGridSearchModule.CurrentRow.Cells["IdMunicipio"].Value != null)
            {
                if (MessageBox.Show("Deseja excluir este registro?",
                                    UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoMunicipio, FormsMessages.TituloProcessoAcaoMunicipioExclusao),
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (_ThrowingException != null) { _ThrowingException = null; }  
                        _IdMunicipio = (int)dataGridSearchModule.CurrentRow.Cells["IdMunicipio"].Value;
                        _Municipio = (string)dataGridSearchModule.CurrentRow.Cells["Municipio"].Value;
                        _SiglaMunicipio = (string)dataGridSearchModule.CurrentRow.Cells["UF"].Value;
                        _ModifyType = MunicipioProcess.CreateInstance.FromToModificaMunicipio(ModificaMunicipioType.MunicipioExcluir);
                        MunicipioProcess.CreateInstance.TaskModifyProcessMunicipio(_IdMunicipio, string.Empty, string.Empty, _ModifyType);
                        FillLogHeaderFromDeleteModify((Convert.ToString(_IdMunicipio)), _Municipio, _SiglaMunicipio);
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

                        if (_LogIdMunicipio != null) { _LogIdMunicipio.ValorNovo = _IdMunicipio; }
                        if (_LogMunicipio != null) { _LogMunicipio.ValorNovo = _Descricao; }
                        if (_LogUF != null) { _LogUF.ValorNovo = _SiglaMunicipio; }

                        _ChangeItems = new List<ChangeItem>();
                        _ChangeItems.Add(_LogIdMunicipio);
                        _ChangeItems.Add(_LogMunicipio);
                        _ChangeItems.Add(_LogUF);

                        #endregion

                        ExecuteModifyExceptionLogMunicipio(_ChangesHeader, _ChangeItems, _ThrowingException);
                    }
                    finally
                    {
                        dataGridSearchModule.DataSource = null;

                        FillDataGrid(MunicipioProcess.CreateInstance.TaskGetCollectionRgMunicipioByFilter("", 0));

                        #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                        if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                        #endregion

                        #region ...::: Atualiza os Itens do Log de Modificações :::...

                        if (_LogIdMunicipio != null) { _LogIdMunicipio.ValorNovo = _IdMunicipio; }
                        if (_LogMunicipio != null) { _LogMunicipio.ValorNovo = _Municipio; }
                        if (_LogUF != null) { _LogUF.ValorNovo = _SiglaMunicipio; }

                        _ChangeItems = new List<ChangeItem>();
                        _ChangeItems.Add(_LogIdMunicipio);
                        _ChangeItems.Add(_LogMunicipio);
                        _ChangeItems.Add(_LogUF);

                        #endregion

                        ExecuteModifyLogMunicipio(_ChangesHeader, _ChangeItems);
                    }
                }
            }
        }

        private void ExecuteModifyLogMunicipio(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }
        private void ExecuteModifyExceptionLogMunicipio(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void FillLogHeaderFromDeleteModify(string _IdMunicipio, string _Municipio, string _UF)
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgMunicipio.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdMunicipioLogDashboard;
            _ChangesHeader.TipoModificacao = MunicipioProcess.CreateInstance.FromToModificaMunicipio(ModificaMunicipioType.MunicipioExcluir);
            _ChangesHeader.Usuario = this.UsuarioLoginDashboard;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Municipio
            _LogIdMunicipio = new ChangeItem();
            _LogIdMunicipio.IdChangeHeader = _ChangesHeader.Id;
            _LogIdMunicipio.IdItem = 1;
            _LogIdMunicipio.NomeTabela = DboRgMunicipio.NomeTabela;
            _LogIdMunicipio.NomeCampo = DboRgMunicipio.NomeIdMunicipio;
            _LogIdMunicipio.ValorAntigo = _IdMunicipio;

            //Descrição Municipio
            _LogMunicipio = new ChangeItem();
            _LogMunicipio.IdChangeHeader = _ChangesHeader.Id;
            _LogMunicipio.IdItem = 2;
            _LogMunicipio.NomeTabela = DboRgMunicipio.NomeTabela;
            _LogMunicipio.NomeCampo = DboRgMunicipio.NomeDescrMunicipio;
            _LogMunicipio.ValorAntigo = _Municipio;

            //Sigla Região
            _LogUF = new ChangeItem();
            _LogUF.IdChangeHeader = _ChangesHeader.Id;
            _LogUF.IdItem = 3;
            _LogUF.NomeTabela = DboRgMunicipio.NomeTabela;
            _LogUF.NomeCampo = DboRgMunicipio.NomeSiglaMunicipio;
            _LogUF.ValorAntigo = _UF;

            #endregion
        }
        private void tlstrpBtnSearchCriteria_Click(object sender, EventArgs e)
        {
            int _SearchType = 0;
            string _Filter = "";
            int _IdMunicipio = 0;
            string _Descricao = "";
            string _UF = "";
            FilterSearchFormMunicipio _FilterSearchFormMunicipio = null;

            if (dataGridSearchModule.DataSource != null)
            {
                try
                {
                    _FilterSearchFormMunicipio = new FilterSearchFormMunicipio();
                    _FilterSearchFormMunicipio.ShowDialog();
                }
                finally
                {
                    _SearchType = _FilterSearchFormMunicipio.SearchType;

                    switch (_SearchType)
                    {
                        case 0:
                            dataGridSearchModule.DataSource = null;
                            _IdMunicipio = _FilterSearchFormMunicipio.CodigoMunicipio;
                            AppStateOverallRecord.IdMunicipio = _IdMunicipio;
                            _Filter = string.Format(" where cod_municipio = {0} ", AppStateOverallRecord.IdMunicipio);
                            FillDataGrid(MunicipioProcess.CreateInstance.TaskGetCollectionRgMunicipioByFilter(_Filter, 1));
                            break;
                        case 1:
                            dataGridSearchModule.DataSource = null;
                            _Descricao = _FilterSearchFormMunicipio.Descricao;
                            AppStateOverallRecord.Municipio = _Descricao.ToUpper();
                            _Filter = string.Format(" where municipio = '%{0}%' ", AppStateOverallRecord.Municipio);
                            FillDataGrid(MunicipioProcess.CreateInstance.TaskGetCollectionRgMunicipioByFilter(_Filter, 1));
                            break;
                        case 2:
                            dataGridSearchModule.DataSource = null;
                            _UF = _FilterSearchFormMunicipio.Descricao;
                            AppStateOverallRecord.UF = _Descricao.ToUpper();
                            _Filter = string.Format(" where sigla_estado = '%{0}%' ", AppStateOverallRecord.UF);
                            FillDataGrid(MunicipioProcess.CreateInstance.TaskGetCollectionRgMunicipioByFilter(_Filter, 1));
                            break;
                    }

                    _FilterSearchFormMunicipio.Dispose();
                }
            }
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, EventArgs e)
        {
            dataGridSearchModule.DataSource = null;
            FillDataGrid(MunicipioProcess.CreateInstance.TaskGetCollectionRgMunicipioByFilter("", 0));
        }

        private void SearchFormMunicipio_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                this.AlteraRgMunicipio();
            }
        }
    }

    internal static class DboRgMunicipio
    {
        #region ...::: Private Constantes :::...

        private const string _NomeIdMunicipio = "cod_municipio";
        private const string _NomeDescrMunicipio = "municipio";
        private const string _NomeSiglaMunicipio = "sigla_estado";
        private const string _NomeTabela = "rg_municipio";
        private const string _NomeProcesso = "Municipio";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeIdMunicipio { get { return _NomeIdMunicipio; } }
        public static string NomeDescrMunicipio { get { return _NomeDescrMunicipio; } }
        public static string NomeSiglaMunicipio { get { return _NomeSiglaMunicipio; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
