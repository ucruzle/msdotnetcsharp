using BrSoftNet.App.Business.Processes.OverallRecord.Entities;
using BrSoftNet.App.Business.Processes.OverallRecord.Enumerators;
using BrSoftNet.App.Business.Processes.OverallRecord.Tasks;
using BrSoftNet.App.UI.Win.Manager.DialogUpdateForm;
using BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm;
using BrSoftNet.App.UI.Win.OverallRecord.State;
using BrSoftNet.Library.Messages;
using BrSoftNet.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Manager.FullScreenSearchForm
{
    public partial class SearchFormParamRegGeral : Form
    {
        #region ...::: Private Variable :::...

        private int _CodigoEmpresa = 0;
        private int _CodigoNatFunc = 0;
        private int _CodigoNatFuncLider = 0;
        private int _CodigoNatCliente = 0;
        private int _CodigoNatFornecedor = 0;
        private int _CodigoNatBanco = 0;
        private int _CodigoStatusAtivo = 0;
        private int _CodigoStatusInativo = 0;
        private string _PermiteCGCCPFZerado = string.Empty;
        private int _CodigoNatTomadora = 0;
        private int _CodigoNatResp = 0;
        private string _PermiteCGCCPFDuplicado = string.Empty;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpresaFromDashboard { get; set; }

        public string UsuarioLoginDashboard { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        public SearchFormParamRegGeral()
        {
            InitializeComponent();
            this.InicializeSearchForm();
        }

        private void InicializeSearchForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            FillDataGrid(ParamRegGeralProcess.CreateInstance.TaskGetCollectionRgParamRegGeralByFilter("", 0));
        }

        private void FillDataGrid(List<RgParamRegGeral> _RgParamRegGeralCollection)
        {
            if (dataGridSearchModule.DataSource == null)
            {
                AppStateOverallRecord.RgParamRegGeralCollection = _RgParamRegGeralCollection;

                bsRgParamRegGeral.DataSource = AppStateOverallRecord.RgParamRegGeralCollection;
                bsRgParamRegGeral.AllowNew = false;

                dataGridSearchModule.DataSource = bsRgParamRegGeral;
                dataGridSearchModule.ReadOnly = true;

                dataGridSearchModule.Columns["CodigoEmpresa"].HeaderText = "Empresa";
                dataGridSearchModule.Columns["CodigoEmpresa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoNatFunc"].HeaderText = "Nat Func";
                dataGridSearchModule.Columns["CodigoNatFunc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoNatFuncLider"].HeaderText = "NatFunc Líder";
                dataGridSearchModule.Columns["CodigoNatFuncLider"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoNatCliente"].HeaderText = "Nat Cliente";
                dataGridSearchModule.Columns["CodigoNatCliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoNatFornecedor"].HeaderText = "Nat Fornecedor";
                dataGridSearchModule.Columns["CodigoNatFornecedor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoNatBanco"].HeaderText = "Nat Banco";
                dataGridSearchModule.Columns["CodigoNatBanco"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoStatusAtivo"].HeaderText = "Status Ativo";
                dataGridSearchModule.Columns["CodigoStatusAtivo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoStatusInativo"].HeaderText = "Status Inativo";
                dataGridSearchModule.Columns["CodigoStatusInativo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["PermiteCGCCPFZerado"].HeaderText = "Permite CGC CPF Zerado";
                dataGridSearchModule.Columns["PermiteCGCCPFZerado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoNatTomadora"].HeaderText = "Nat Tomadora";
                dataGridSearchModule.Columns["CodigoNatTomadora"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["CodigoNatResp"].HeaderText = "Nat Resp";
                dataGridSearchModule.Columns["CodigoNatResp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridSearchModule.Columns["PermiteCGCCPFDuplicado"].HeaderText = "Permite CGC CPF Duplicado";
                dataGridSearchModule.Columns["PermiteCGCCPFDuplicado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void tlstrpBtnFirst_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgParamRegGeral.MoveFirst();
            }
        }

        private void tlstrpBtnPreview_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgParamRegGeral.MovePrevious();
            }
        }

        private void tlstrpBtnNext_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgParamRegGeral.MoveNext();
            }
        }

        private void tlstrpBtnLast_Click(object sender, System.EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                bsRgParamRegGeral.MoveLast();
            }
        }

        private void tlstrpBtnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();

            dataGridSearchModule.DataSource = null;
        }

        private void tlstrpBtnAdd_Click(object sender, System.EventArgs e)
        {
            AdicionaRgParamRegGeral();
        }

        private void AdicionaRgParamRegGeral()
        {
            UpdateFormParamRegGeral _UpdateFormParamRegGeral = new UpdateFormParamRegGeral();
            _UpdateFormParamRegGeral.ModificaParamRegGeralType = ModificaParamRegGeralType.ParamRegGeralAdicionar;

            _UpdateFormParamRegGeral.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoParametroRg, FormsMessages.TituloProcessoAcaoParametroRgInclusao);

            try
            {
                _UpdateFormParamRegGeral.ShowDialog();
            }
            finally
            {
                _UpdateFormParamRegGeral = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(ParamRegGeralProcess.CreateInstance.TaskGetCollectionRgParamRegGeralByFilter("", 0));
            }
        }

        private void tlstrpBtnUpdate_Click(object sender, System.EventArgs e)
        {
            AlteraRgParamRegGeral();
        }

        private void AlteraRgParamRegGeral()
        {
            string _Filter = string.Empty;

            UpdateFormParamRegGeral _UpdateFormParamRegGeral = new UpdateFormParamRegGeral();
            _UpdateFormParamRegGeral.ModificaParamRegGeralType = ModificaParamRegGeralType.ParamRegGeralAlterar;

            _UpdateFormParamRegGeral.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoParametroRg, FormsMessages.TituloProcessoAcaoParametroRgAlteracao);

            _CodigoEmpresa = (int)dataGridSearchModule.CurrentRow.Cells["CodigoEmpresa"].Value;
            _CodigoNatFunc = (int)dataGridSearchModule.CurrentRow.Cells["CodigoNatFunc"].Value;
            _CodigoNatFuncLider = (int)dataGridSearchModule.CurrentRow.Cells["CodigoNatFuncLider"].Value;
            _CodigoNatCliente = (int)dataGridSearchModule.CurrentRow.Cells["CodigoNatCliente"].Value;
            _CodigoNatFornecedor = (int)dataGridSearchModule.CurrentRow.Cells["CodigoNatFornecedor"].Value;
            _CodigoNatBanco = (int)dataGridSearchModule.CurrentRow.Cells["CodigoNatBanco"].Value;
            _CodigoStatusAtivo = (int)dataGridSearchModule.CurrentRow.Cells["CodigoStatusAtivo"].Value;
            _CodigoStatusInativo = (int)dataGridSearchModule.CurrentRow.Cells["CodigoStatusInativo"].Value;
            _PermiteCGCCPFZerado = (string)dataGridSearchModule.CurrentRow.Cells["PermiteCGCCPFZerado"].Value;
            _CodigoNatTomadora = (int)dataGridSearchModule.CurrentRow.Cells["CodigoNatTomadora"].Value;
            _CodigoNatResp = (int)dataGridSearchModule.CurrentRow.Cells["CodigoNatResp"].Value;
            _PermiteCGCCPFDuplicado = (string)dataGridSearchModule.CurrentRow.Cells["PermiteCGCCPFDuplicado"].Value;

            _UpdateFormParamRegGeral.CodigoEmpresa = _CodigoEmpresa;
            _UpdateFormParamRegGeral.CodigoNatFunc = _CodigoNatFunc;
            _UpdateFormParamRegGeral.CodigoNatFuncLider = _CodigoNatFuncLider;
            _UpdateFormParamRegGeral.CodigoNatCliente = _CodigoNatCliente;
            _UpdateFormParamRegGeral.CodigoNatFornecedor = _CodigoNatFornecedor;
            _UpdateFormParamRegGeral.CodigoNatBanco = _CodigoNatBanco;
            _UpdateFormParamRegGeral.CodigoStatusAtivo = _CodigoStatusAtivo;
            _UpdateFormParamRegGeral.CodigoStatusInativo = _CodigoStatusInativo;
            _UpdateFormParamRegGeral.PermiteCGCCPFZerado = _PermiteCGCCPFZerado;
            _UpdateFormParamRegGeral.CodigoNatTomadora = _CodigoNatTomadora;
            _UpdateFormParamRegGeral.CodigoNatResp = _CodigoNatResp;
            _UpdateFormParamRegGeral.PermiteCGCCPFDuplicado = _PermiteCGCCPFDuplicado;

            try
            {
                _UpdateFormParamRegGeral.ShowDialog();
            }
            finally
            {
                AppStateOverallRecord.CodigoEmpresa = _UpdateFormParamRegGeral.CodigoEmpresa;

                _Filter = string.Format(" where cod_empr = '{0}' ", AppStateOverallRecord.CodigoEmpresa);

                _UpdateFormParamRegGeral = null;

                dataGridSearchModule.DataSource = null;

                FillDataGrid(ParamRegGeralProcess.CreateInstance.TaskGetCollectionRgParamRegGeralByFilter(_Filter, 1));
            }
        }

        private void tlstrpBtnDelete_Click(object sender, System.EventArgs e)
        {
            string _ModifyType = string.Empty;
            int _CodigoEmpresa = 0;
            string _Descricao = string.Empty;

            if (dataGridSearchModule.CurrentRow.Cells["CodigoEmpresa"].Value != null)
            {
                if (MessageBox.Show("Deseja excluir este registro?",
                                    UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoParametroRg, FormsMessages.TituloProcessoEstadoAcaoExclusao),
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        _CodigoEmpresa = (int)dataGridSearchModule.CurrentRow.Cells["CodigoEmpresa"].Value;
                        _ModifyType = ParamRegGeralProcess.CreateInstance.FromToModificaParamRegGeral(ModificaParamRegGeralType.ParamRegGeralExcluir);
                        ParamRegGeralProcess.CreateInstance.TaskModifyProcessParamRegGeral(_CodigoEmpresa, 0, 0, 0, 0, 0, 0, 0, string.Empty, 0, 0, string.Empty, _ModifyType);
                    }
                    catch (Exception _Exception)
                    {
                        throw _Exception;
                    }
                    finally
                    {
                        dataGridSearchModule.DataSource = null;

                        FillDataGrid(ParamRegGeralProcess.CreateInstance.TaskGetCollectionRgParamRegGeralByFilter("", 0));
                    }
                }
            }
        }

        private void tlstrpBtnSearchCriteria_Click(object sender, EventArgs e)
        {
            int _SearchType = 0;
            string _Filter = "";
            int _CodigoEmpresa = 0;
            FilterSearchFormParamRegGeral _FilterSearchFormParamRegGeral = null;

            if (dataGridSearchModule.DataSource != null)
            {
                try
                {
                    _FilterSearchFormParamRegGeral = new FilterSearchFormParamRegGeral();
                    _FilterSearchFormParamRegGeral.ShowDialog();
                }
                finally
                {
                    _SearchType = _FilterSearchFormParamRegGeral.SearchType;

                    switch (_SearchType)
                    {
                        case 0:
                            dataGridSearchModule.DataSource = null;
                            _CodigoEmpresa = _FilterSearchFormParamRegGeral.CodigoEmpresa;
                            AppStateOverallRecord.CodigoEmpresa = _CodigoEmpresa;
                            _Filter = string.Format(" where cod_empr = {0} ", AppStateOverallRecord.CodigoEmpresa);
                            FillDataGrid(ParamRegGeralProcess.CreateInstance.TaskGetCollectionRgParamRegGeralByFilter(_Filter, 1));
                            break;
                    }

                    _FilterSearchFormParamRegGeral.Dispose();
                }
            }
        }

        private void tlstrpBtnClearSearchCriteria_Click(object sender, EventArgs e)
        {
            dataGridSearchModule.DataSource = null;
            FillDataGrid(ParamRegGeralProcess.CreateInstance.TaskGetCollectionRgParamRegGeralByFilter("", 0));
        }

        private void SearchFormParamRegGeral_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;
        }

        private void dataGridSearchModule_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridSearchModule.DataSource != null)
            {
                this.AlteraRgParamRegGeral();
            }
        }
    }
}
