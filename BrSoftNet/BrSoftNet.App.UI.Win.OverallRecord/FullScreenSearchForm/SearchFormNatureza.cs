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
    public partial class SearchFormNatureza : Form
    {
        #region ...::: Private Variable :::...

        private int _IdNatureza = 0;
        private string _DescricaoNatureza = string.Empty;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpresaFromDashboard { get; set; }
        public string UsuarioLoginDashboard { get; set; }
        public int IdNaturezaLogDashboard { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;
        private ChangeItem _LogIdNatureza = null;
        private ChangeItem _LogDescricao = null;
        private List<ChangeItem> _ChangeItems = null;
        private ThrowingException _ThrowingException = null;

        #endregion

        public SearchFormNatureza()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(NaturezaProcess.CreateInstance.TaskGetCollectionRgNaturezaByFilter("", 0));
        }

        private void FillDataGrid(List<RgNatureza> _RgNaturezaCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateOverallRecord.RgNaturezaCollection = _RgNaturezaCollection;

                bsRgNatureza.DataSource = AppStateOverallRecord.RgNaturezaCollection;
                bsRgNatureza.AllowNew = false;

                dataGridSearchModule.DataSource = bsRgNatureza;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["IdNatureza"].HeaderText = "Natureza";
                dataGridSearchModule.Columns["IdNatureza"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["DescrNatureza"].HeaderText = "Descrição";
                dataGridSearchModule.Columns["DescrNatureza"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void tlstrpBtnFirst_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgNatureza.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgNatureza.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgNatureza.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgNatureza.MoveLast();
            }
        }

        private void tlstrpBtnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        }

        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AdicionaRgNatureza();
        }

        private void AdicionaRgNatureza()
        {
            UpdateFormNatureza _UpdateFormNatureza = new UpdateFormNatureza();
            _UpdateFormNatureza.ModificaNaturezaType = ModificaNaturezaType.NaturezaAdicionar;
            _UpdateFormNatureza.IdNatureza = IdNaturezaLogDashboard;
            _UpdateFormNatureza.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormNatureza.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormNatureza.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoNatureza, FormsMessages.TituloProcessoAcaoNaturezaInclusao);


            try
            {
                _UpdateFormNatureza.ShowDialog();
            }
            finally
            {
                _UpdateFormNatureza = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(NaturezaProcess.CreateInstance.TaskGetCollectionRgNaturezaByFilter("", 0));
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, System.EventArgs e)
        {
            AlteraRgNatureza();
        }

        private void AlteraRgNatureza()
        {
            string _Filter = string.Empty;

            UpdateFormNatureza _UpdateFormNatureza = new UpdateFormNatureza();
            _UpdateFormNatureza.ModificaNaturezaType = ModificaNaturezaType.NaturezaAlterar;
            _UpdateFormNatureza.IdNatureza = IdNaturezaLogDashboard;
            _UpdateFormNatureza.IdEmpr = IdEmpresaFromDashboard;
            _UpdateFormNatureza.UsuarioLogin = UsuarioLoginDashboard;
            _UpdateFormNatureza.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoNatureza, FormsMessages.TituloProcessoAcaoNaturezaAlteracao);

            _IdNatureza = (int)dataGridSearchModule.CurrentRow.Cells["IdNatureza"].Value;
            _DescricaoNatureza = dataGridSearchModule.CurrentRow.Cells["DescrNatureza"].Value.ToString();

            _UpdateFormNatureza.IdNatureza = _IdNatureza;
            _UpdateFormNatureza.DescrNatureza = _DescricaoNatureza;

            try
            {
                _UpdateFormNatureza.ShowDialog();
            }
            finally
            {
                AppStateOverallRecord.IdNatureza = _UpdateFormNatureza.IdNatureza;

                _Filter = string.Format(" where cod_natureza = {0} ", AppStateOverallRecord.IdNatureza);

                _UpdateFormNatureza = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(NaturezaProcess.CreateInstance.TaskGetCollectionRgNaturezaByFilter(_Filter, 1));
            }
        }

        private void tlstrpBtnDelete_Click(object sender, System.EventArgs e)
        {
            const string _FUNCAO_DISPARADOR = "tlstrpBtnDelete_Click";

            string _ModifyType = string.Empty;
            string _DescrNatureza = string.Empty;
            int _IdNatureza = 0;

            if (dataGridSearchModule.CurrentRow.Cells["IdNatureza"].Value != null)
            {
                if (MessageBox.Show("Deseja excluir este registro?",
                                    UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoNatureza, FormsMessages.TituloProcessoAcaoNaturezaExclusao),
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (_ThrowingException != null) { _ThrowingException = null; }   
                        _IdNatureza = (int)dataGridSearchModule.CurrentRow.Cells["IdNatureza"].Value;
                        _DescrNatureza = (string)dataGridSearchModule.CurrentRow.Cells["DescrNatureza"].Value;
                        _ModifyType = NaturezaProcess.CreateInstance.FromToModificaNatureza(ModificaNaturezaType.NaturezaExcluir);
                        FillLogHeaderFromDeleteModify(_IdNatureza, _DescrNatureza);
                        NaturezaProcess.CreateInstance.TaskModifyProcessNatureza(_IdNatureza, string.Empty, _ModifyType);
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

                        if (_LogIdNatureza != null) { _LogIdNatureza.ValorNovo = _IdNatureza; }
                        if (_LogDescricao != null) { _LogDescricao.ValorNovo = _DescrNatureza; }

                        _ChangeItems = new List<ChangeItem>();
                        _ChangeItems.Add(_LogIdNatureza);
                        _ChangeItems.Add(_LogDescricao);

                        #endregion

                        ExecuteModifyExceptionLogNatureza(_ChangesHeader, _ChangeItems, _ThrowingException);
                    }
                    finally
                    {
                        dataGridSearchModule.DataSource = null;

                        FillDataGrid(NaturezaProcess.CreateInstance.TaskGetCollectionRgNaturezaByFilter("", 0));

                        if (_ThrowingException == null)
                        {
                            #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                            if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                            #endregion

                            #region ...::: Atualiza os Itens do Log de Modificações :::...

                            if (_LogIdNatureza != null) { _LogIdNatureza.ValorNovo = _IdNatureza; }
                            if (_LogDescricao != null) { _LogDescricao.ValorNovo = _DescrNatureza; }

                            _ChangeItems = new List<ChangeItem>();
                            _ChangeItems.Add(_LogIdNatureza);
                            _ChangeItems.Add(_LogDescricao);

                            #endregion

                            ExecuteModifyLogNatureza(_ChangesHeader, _ChangeItems);
                        }
                    }
                }
            }
        }

        private void ExecuteModifyExceptionLogNatureza(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void ExecuteModifyLogNatureza(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }
        private void FillLogHeaderFromDeleteModify(int _IdNatureza, string _DescrNatureza)
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgNatureza.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdNaturezaLogDashboard;
            _ChangesHeader.TipoModificacao = NaturezaProcess.CreateInstance.FromToModificaNatureza(ModificaNaturezaType.NaturezaExcluir);
            _ChangesHeader.Usuario = this.UsuarioLoginDashboard;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Código Natureza
            _LogIdNatureza = new ChangeItem();
            _LogIdNatureza.IdChangeHeader = _ChangesHeader.Id;
            _LogIdNatureza.IdItem = 1;
            _LogIdNatureza.NomeTabela = DboRgNatureza.NomeTabela;
            _LogIdNatureza.NomeCampo = DboRgNatureza.NomeIdNatureza;
            _LogIdNatureza.ValorAntigo = _IdNatureza;

            //Descrição Natureza    
            _LogDescricao = new ChangeItem();
            _LogDescricao.IdChangeHeader = _ChangesHeader.Id;
            _LogDescricao.IdItem = 2;
            _LogDescricao.NomeTabela = DboRgNatureza.NomeTabela;
            _LogDescricao.NomeCampo = DboRgNatureza.NomeDescrNatureza;
            _LogDescricao.ValorAntigo = _DescrNatureza;

            #endregion
        }

        private void tlstrpBtnSearchCriteria_Click(object sender, EventArgs e)
        {
            int _SearchType = 0;
            string _Filter = "";
            int _IdNatureza = 0;
            string _Descricao = "";
            FilterSearchFormNatureza _FilterSearchFormNatureza = null;

            if (dataGridSearchModule.DataSource != null)
            {
                try
                {
                    _FilterSearchFormNatureza = new FilterSearchFormNatureza();
                    _FilterSearchFormNatureza.ShowDialog();
                }
                finally
                {
                    _SearchType = _FilterSearchFormNatureza.SearchType;

                    switch (_SearchType)
                    {
                        case 0:
                            dataGridSearchModule.DataSource = null;
                            _IdNatureza = _FilterSearchFormNatureza.IdNatureza;
                            AppStateOverallRecord.IdNatureza = _IdNatureza;
                            _Filter = string.Format(" WHERE cod_natureza = {0} ", AppStateOverallRecord.IdNatureza);
                            FillDataGrid(NaturezaProcess.CreateInstance.TaskGetCollectionRgNaturezaByFilter(_Filter, 1));
                            break;
                        case 1:
                            dataGridSearchModule.DataSource = null;
                            _Descricao = _FilterSearchFormNatureza.DescrNatureza;
                            AppStateOverallRecord.DescrNatureza = _Descricao.ToUpper();
                            _Filter = string.Format(" WHERE descr_natureza LIKE '%{0}%' ", AppStateOverallRecord.DescrNatureza);
                            FillDataGrid(NaturezaProcess.CreateInstance.TaskGetCollectionRgNaturezaByFilter(_Filter, 1));
                            break;
                    }

                    _FilterSearchFormNatureza.Dispose();
                }
            }
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, EventArgs e)
        {
            this.dataGridSearchModule.DataSource = null;
            this.FillDataGrid(NaturezaProcess.CreateInstance.TaskGetCollectionRgNaturezaByFilter(string.Empty, 0));
        }

        private void SearchFormNatureza_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                this.AlteraRgNatureza();
            }
        }
    }
    internal static class DboRgNatureza
    {
        #region ...::: Private Constantes :::...

        private const string _NomeIdNatureza = "cod_natureza";
        private const string _NomeDescrNatureza = "descr_natureza";
        private const string _NomeTabela = "rg_natureza";
        private const string _NomeProcesso = "Natureza";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeIdNatureza { get { return _NomeIdNatureza; } }
        public static string NomeDescrNatureza { get { return _NomeDescrNatureza; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
