using BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects;
using BrSoftNet.App.Business.Processes.OverallRecord.Entities;
using BrSoftNet.App.Business.Processes.OverallRecord.Enumerators;
using BrSoftNet.App.Business.Processes.OverallRecord.Tasks;
using BrSoftNet.App.UI.Win.OverallRecord.State;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace BrSoftNet.App.UI.Win.Manager.DialogUpdateForm
{
    public partial class UpdateFormParamRegGeral : Form
    {
        #region ...::: Private Variable :::...

        private string _TipoModificacao = string.Empty;

        private int _IdExecute = 0;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpr { get; set; }
        public int IdRg { get; set; }
        public string UsuarioLogin { get; set; }
        public ModificaParamRegGeralType ModificaParamRegGeralType { get; set; }
        public int CodigoEmpresa { get; set; }
        public int CodigoNatFunc { get; set; }
        public int CodigoNatFuncLider { get; set; }
        public int CodigoNatCliente { get; set; }
        public int CodigoNatFornecedor { get; set; }
        public int CodigoNatBanco { get; set; }
        public int CodigoStatusAtivo { get; set; }
        public int CodigoStatusInativo { get; set; }
        public string PermiteCGCCPFZerado { get; set; }
        public int CodigoNatTomadora { get; set; }
        public int CodigoNatResp { get; set; }
        public string PermiteCGCCPFDuplicado { get; set; }

        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Properties :::...

        private List<RgNatureza> RgNatureza { get; set; }
        private List<RgParamNatureza> RgParamNatureza { get; set; }
        private List<IntegracaoEmpresa> IntegracaoEmpresa { get; set; }
        private List<RgStatus> RgStatus { get; set; }
        private List<RgParamStatus> RgParamStatus { get; set; }

        #endregion

        #region ...::: Private Fields :::...

        private DataSet _DataSetEmpresaNaturezaStatusPorVinculo = null;
        private List<IntegracaoEmpresa> _IntegracaoEmpresaCollection = null;
        private List<RgNatureza> _RgNaturezaCollection = null;
        private List<RgParamNatureza> _RgParamNaturezaCollection = null;
        private List<RgStatus> _RgStatusCollection = null;
        private List<RgParamStatus> _RgParamStatusCollection = null;
        #endregion

        public UpdateFormParamRegGeral()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();

            this.cmbBxEmpresa.GotFocus += cmbBxEmpresa_GotFocus;
            this.cmbBxEmpresa.LostFocus += cmbBxEmpresa_LostFocus;

            this.cmbBxCodigoNatFunc.GotFocus += cmbBxCodigoNatFunc_GotFocus;
            this.cmbBxCodigoNatFunc.LostFocus += cmbBxCodigoNatFunc_LostFocus;

            this.cmbBxCodigoNatFuncLider.GotFocus += cmbBxCodigoNatFuncLider_GotFocus;
            this.cmbBxCodigoNatFuncLider.LostFocus += cmbBxCodigoNatFuncLider_LostFocus;

            this.cmbBxCodigoNatCliente.GotFocus += cmbBxNatCliente_GotFocus;
            this.cmbBxCodigoNatCliente.LostFocus += cmbBxNatCliente_LostFocus;

            this.cmbBxCodigoNatFornecedor.GotFocus += cmbBxCodigoNatFornecedor_GotFocus;
            this.cmbBxCodigoNatFornecedor.LostFocus += cmbBxCodigoNatFornecedor_LostFocus;

            this.cmbBxCodigoNatBanco.GotFocus += cmbBxCodigoNatBanco_GotFocus;
            this.cmbBxCodigoNatBanco.LostFocus += cmbBxCodigoNatBanco_LostFocus;

            this.cmbBxCodigoStatusAtivo.GotFocus += cmbBxCodigoStatusAtivo_GotFocus;
            this.cmbBxCodigoStatusAtivo.LostFocus += cmbBxCodigoStatusAtivo_LostFocus;

            this.cmbBxCodigoStatusInativo.GotFocus += cmbBxCodigoStatusInativo_GotFocus;
            this.cmbBxCodigoStatusInativo.LostFocus += cmbBxCodigoStatusInativo_LostFocus;

            this.cmbBxCodigoNatTomadora.GotFocus += cmbBxCodigoNatTomadora_GotFocus;
            this.cmbBxCodigoNatTomadora.LostFocus += cmbBxCodigoNatTomadora_LostFocus;

            this.cmbBxCodigoNatResponsavel.GotFocus += cmbBxCodigoNatResponsavel_GotFocus;
            this.cmbBxCodigoNatResponsavel.LostFocus += cmbBxCodigoNatResponsavel_LostFocus;
        }

        void cmbBxCodigoNatResponsavel_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoNatResponsavel.BackColor = Color.White;
        }

        void cmbBxCodigoNatResponsavel_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoNatResponsavel.BackColor = Color.LightYellow;
        }

        void cmbBxCodigoNatTomadora_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoNatTomadora.BackColor = Color.White;
        }

        void cmbBxCodigoNatTomadora_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoNatTomadora.BackColor = Color.LightYellow;
        }

        void cmbBxCodigoStatusInativo_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoStatusInativo.BackColor = Color.White;
        }

        void cmbBxCodigoStatusInativo_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoStatusInativo.BackColor = Color.LightYellow;
        }

        void cmbBxCodigoStatusAtivo_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoStatusAtivo.BackColor = Color.White;
        }

        void cmbBxCodigoStatusAtivo_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoStatusAtivo.BackColor = Color.LightYellow;
        }

        void cmbBxCodigoNatBanco_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoNatBanco.BackColor = Color.White;
        }

        void cmbBxCodigoNatBanco_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoNatBanco.BackColor = Color.LightYellow;
        }

        void cmbBxCodigoNatFornecedor_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoNatFornecedor.BackColor = Color.White;
        }

        void cmbBxCodigoNatFornecedor_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoNatFornecedor.BackColor = Color.LightYellow;
        }

        void cmbBxNatCliente_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoNatCliente.BackColor = Color.White;
        }

        void cmbBxNatCliente_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoNatCliente.BackColor = Color.LightYellow;
        }

        void cmbBxCodigoNatFuncLider_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoNatFuncLider.BackColor = Color.White;
        }

        void cmbBxCodigoNatFuncLider_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoNatFuncLider.BackColor = Color.LightYellow;
        }

        void cmbBxCodigoNatFunc_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoNatFunc.BackColor = Color.White;
        }

        void cmbBxCodigoNatFunc_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxCodigoNatFunc.BackColor = Color.LightYellow;
        }

        void cmbBxEmpresa_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxEmpresa.BackColor = Color.White;
        }

        void cmbBxEmpresa_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxEmpresa.BackColor = Color.LightYellow;
        }

        private void InicialiazeUpdateForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {
            ExecuteModifyParamRegGeral();
            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void ExecuteModifyParamRegGeral()
        {
            switch (ModificaParamRegGeralType)
            {
                case ModificaParamRegGeralType.ParamRegGeralAdicionar:
                    ExecuteAddParamRegGeral();
                    break;
                case ModificaParamRegGeralType.ParamRegGeralAlterar:
                    ExecuteUpdateParamRegGeral();
                    break;
            }
        }

        private void ExecuteUpdateParamRegGeral()
        {
            int _CodigoEmpresa = 0;
            int _CodigoNatFunc = 0;
            int _CodigoNatFuncLider = 0;
            int _CodigoNatCliente = 0;
            int _CodigoNatFornecedor = 0;
            int _CodigoNatBanco = 0;
            int _CodigoStatusAtivo = 0;
            int _CodigoStatusInativo = 0;
            int _CodigoNatTomadora = 0;
            int _CodigoNatResp = 0;
            string _TipoModificacao = string.Empty;

            _CodigoEmpresa = Convert.ToInt32(cmbBxEmpresa.SelectedValue); 
            _CodigoNatFunc = Convert.ToInt32(cmbBxCodigoNatFunc.SelectedValue);
            _CodigoNatFuncLider = Convert.ToInt32(cmbBxCodigoNatFuncLider.SelectedValue);
            _CodigoNatCliente = Convert.ToInt32(cmbBxCodigoNatCliente.SelectedValue);
            _CodigoNatFornecedor = Convert.ToInt32(cmbBxCodigoNatFornecedor.SelectedValue);
            _CodigoNatBanco = Convert.ToInt32(cmbBxCodigoNatBanco.SelectedValue);
            _CodigoStatusAtivo = Convert.ToInt32(cmbBxCodigoStatusAtivo.SelectedValue);
            _CodigoStatusInativo = Convert.ToInt32(cmbBxCodigoStatusInativo.SelectedValue);
            _CodigoNatTomadora = Convert.ToInt32(cmbBxCodigoNatTomadora.SelectedValue);
            _CodigoNatResp = Convert.ToInt32(cmbBxCodigoNatResponsavel.SelectedValue);

            _TipoModificacao = ParamRegGeralProcess.CreateInstance.FromToModificaParamRegGeral(ModificaParamRegGeralType.ParamRegGeralAlterar);

            PermiteCGCCPFDuplicado = ckBxPermiteCGCCPFDuplic.Checked ? "S" : "N";
            PermiteCGCCPFZerado = ckBxPermiteCGCCPFZerado.Checked ? "S" : "N";

            try
            {
                _IdExecute = ParamRegGeralProcess.CreateInstance.TaskModifyProcessParamRegGeral(_CodigoEmpresa, _CodigoNatFunc, _CodigoNatFuncLider, _CodigoNatCliente, _CodigoNatFornecedor, _CodigoNatBanco, _CodigoStatusAtivo, _CodigoStatusInativo, PermiteCGCCPFZerado, _CodigoNatTomadora, _CodigoNatResp, PermiteCGCCPFDuplicado, _TipoModificacao);
            }
            catch (Exception _Exception)
            {
                throw _Exception;
            }
            finally
            {

            }
        }

        private void ExecuteAddParamRegGeral()
        {
            int _CodigoEmpresa = 0;
            int _CodigoNatFunc = 0;
            int _CodigoNatFuncLider = 0;
            int _CodigoNatCliente = 0;
            int _CodigoNatFornecedor = 0;
            int _CodigoNatBanco = 0;
            int _CodigoStatusAtivo = 0;
            int _CodigoStatusInativo = 0;
            int _CodigoNatTomadora = 0;
            int _CodigoNatResp = 0;
            string _TipoModificacao = string.Empty;

            _CodigoEmpresa = Convert.ToInt32(cmbBxEmpresa.SelectedValue);
            _CodigoNatFunc = Convert.ToInt32(cmbBxCodigoNatFunc.SelectedValue);
            _CodigoNatFuncLider = Convert.ToInt32(cmbBxCodigoNatFuncLider.SelectedValue);
            _CodigoNatCliente = Convert.ToInt32(cmbBxCodigoNatCliente.SelectedValue);
            _CodigoNatFornecedor = Convert.ToInt32(cmbBxCodigoNatFornecedor.SelectedValue);
            _CodigoNatBanco = Convert.ToInt32(cmbBxCodigoNatBanco.SelectedValue);
            _CodigoStatusAtivo = Convert.ToInt32(cmbBxCodigoStatusAtivo.SelectedValue);
            _CodigoStatusInativo = Convert.ToInt32(cmbBxCodigoStatusInativo.SelectedValue);
            _CodigoNatTomadora = Convert.ToInt32(cmbBxCodigoNatTomadora.SelectedValue);
            _CodigoNatResp = Convert.ToInt32(cmbBxCodigoNatResponsavel.SelectedValue);

            _TipoModificacao = ParamRegGeralProcess.CreateInstance.FromToModificaParamRegGeral(ModificaParamRegGeralType.ParamRegGeralAdicionar);

            PermiteCGCCPFDuplicado = ckBxPermiteCGCCPFDuplic.Checked ? "S" : "N";
            PermiteCGCCPFZerado = ckBxPermiteCGCCPFZerado.Checked ? "S" : "N";

            try
            {
                _IdExecute = ParamRegGeralProcess.CreateInstance.TaskModifyProcessParamRegGeral(_CodigoEmpresa, _CodigoNatFunc, _CodigoNatFuncLider, _CodigoNatCliente, _CodigoNatFornecedor, _CodigoNatBanco, _CodigoStatusAtivo, _CodigoStatusInativo, PermiteCGCCPFZerado, _CodigoNatTomadora, _CodigoNatResp, PermiteCGCCPFDuplicado, _TipoModificacao);
            }
            catch (Exception _Exception)
            {
                throw _Exception;
            }
            finally
            {

            }
        }

        private void UpdateFormParamRegGeral_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;

            _DataSetEmpresaNaturezaStatusPorVinculo = ParamRegGeralProcess.CreateInstance.TaskRgCollectionRetornaEmpresaNaturezaStatusPorVinculo();

            switch (ModificaParamRegGeralType)
            {
                case ModificaParamRegGeralType.ParamRegGeralAdicionar:
                    FillProcessoToAddModify();
                    break;
                case ModificaParamRegGeralType.ParamRegGeralAlterar:
                    FillDataParametersToExecuteUpdateModify();
                    FillProcessoToUpdateModify();
                    break;
                case ModificaParamRegGeralType.ParamRegGeralExcluir:
                    break;
                default:
                    break;
            }
        }

        private void FillProcessoToAddModify()
        {
            FillEmpresaCollection();
            cmbBxEmpresa.DataSource = IntegracaoEmpresa;
            cmbBxEmpresa.ValueMember = "CodigoEmpresa";
            cmbBxEmpresa.DisplayMember = "DescricaoEmpresa";
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxEmpresa.SelectedValue);

            FillCodNaturezaFuncionarioCollection();
            cmbBxCodigoNatFunc.DataSource = RgParamNatureza;
            cmbBxCodigoNatFunc.ValueMember = "IdNaturezaFuncionario";
            cmbBxCodigoNatFunc.DisplayMember = "DescrNaturezaFuncionario";
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxCodigoNatFunc.SelectedValue);

            FillCodNaturezaFuncionarioLiderCollection();
            cmbBxCodigoNatFuncLider.DataSource = RgParamNatureza;
            cmbBxCodigoNatFuncLider.ValueMember = "IdNaturezaFuncionarioLider";
            cmbBxCodigoNatFuncLider.DisplayMember = "DescrNaturezaFuncionarioLider";
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxCodigoNatFuncLider.SelectedValue);

            FillCodNaturezaClienteCollection();
            cmbBxCodigoNatCliente.DataSource = RgParamNatureza;
            cmbBxCodigoNatCliente.ValueMember = "IdNaturezaCliente";
            cmbBxCodigoNatCliente.DisplayMember = "DescrNaturezaCliente";
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxCodigoNatCliente.SelectedValue);

            FillCodNaturezaFornecedorCollection();
            cmbBxCodigoNatFornecedor.DataSource = RgParamNatureza;
            cmbBxCodigoNatFornecedor.ValueMember = "IdNaturezaFornecedor";
            cmbBxCodigoNatFornecedor.DisplayMember = "DescrNaturezaFornecedor";
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxCodigoNatFornecedor.SelectedValue);

            FillCodNaturezaBancoCollection();
            cmbBxCodigoNatBanco.DataSource = RgParamNatureza;
            cmbBxCodigoNatBanco.ValueMember = "IdNaturezaBanco";
            cmbBxCodigoNatBanco.DisplayMember = "DescrNaturezaBanco";
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxCodigoNatBanco.SelectedValue);

            FillCodStatusAtivoCollection();
            cmbBxCodigoStatusAtivo.DataSource = RgParamStatus;
            cmbBxCodigoStatusAtivo.ValueMember = "IdRgStatusAtivo";
            cmbBxCodigoStatusAtivo.DisplayMember = "DescrStatusAtivo";
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxCodigoStatusAtivo.SelectedValue);

            FillCodStatusInativoCollection();
            cmbBxCodigoStatusInativo.DataSource = RgParamStatus;
            cmbBxCodigoStatusInativo.ValueMember = "IdRgStatusInativo";
            cmbBxCodigoStatusInativo.DisplayMember = "DescrStatusInativo";
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxCodigoStatusInativo.SelectedValue);

            FillCodNaturezaTomadoraCollection();
            cmbBxCodigoNatTomadora.DataSource = RgParamNatureza;
            cmbBxCodigoNatTomadora.ValueMember = "IdNaturezaTomadora";
            cmbBxCodigoNatTomadora.DisplayMember = "DescrNaturezaTomadora";
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxCodigoNatTomadora.SelectedValue);

            FillCodNaturezaResponsavelCollection();
            cmbBxCodigoNatResponsavel.DataSource = RgParamNatureza;
            cmbBxCodigoNatResponsavel.ValueMember = "IdNaturezaResponsavel";
            cmbBxCodigoNatResponsavel.DisplayMember = "DescrNaturezaResponsavel";
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxCodigoNatResponsavel.SelectedValue);
        }

        private void FillProcessoToUpdateModify()
        {
            FillEmpresaCollection();
            cmbBxEmpresa.DataSource = IntegracaoEmpresa;
            cmbBxEmpresa.ValueMember = "CodigoEmpresa";
            cmbBxEmpresa.DisplayMember = "DescricaoEmpresa";
            cmbBxEmpresa.SelectedValue = this.CodigoEmpresa;
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxEmpresa.SelectedValue);

            FillCodNaturezaFuncionarioCollection();
            cmbBxCodigoNatFunc.DataSource = RgParamNatureza;
            cmbBxCodigoNatFunc.ValueMember = "IdNaturezaFuncionario";
            cmbBxCodigoNatFunc.DisplayMember = "DescrNaturezaFuncionario";
            cmbBxCodigoNatFunc.SelectedValue = this.CodigoNatFunc;
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxCodigoNatFunc.SelectedValue);

            FillCodNaturezaFuncionarioLiderCollection();
            cmbBxCodigoNatFuncLider.DataSource = RgParamNatureza;
            cmbBxCodigoNatFuncLider.ValueMember = "IdNaturezaFuncionarioLider";
            cmbBxCodigoNatFuncLider.DisplayMember = "DescrNaturezaFuncionarioLider";
            cmbBxCodigoNatFuncLider.SelectedValue = this.CodigoNatFuncLider;
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxCodigoNatFuncLider.SelectedValue);

            FillCodNaturezaClienteCollection();
            cmbBxCodigoNatCliente.DataSource = RgParamNatureza;
            cmbBxCodigoNatCliente.ValueMember = "IdNaturezaCliente";
            cmbBxCodigoNatCliente.DisplayMember = "DescrNaturezaCliente";
            cmbBxCodigoNatCliente.SelectedValue = this.CodigoNatCliente;
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxCodigoNatCliente.SelectedValue);

            FillCodNaturezaFornecedorCollection();
            cmbBxCodigoNatFornecedor.DataSource = RgParamNatureza;
            cmbBxCodigoNatFornecedor.ValueMember = "IdNaturezaFornecedor";
            cmbBxCodigoNatFornecedor.DisplayMember = "DescrNaturezaFornecedor";
            cmbBxCodigoNatFornecedor.SelectedValue = this.CodigoNatFornecedor;
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxCodigoNatFornecedor.SelectedValue);

            FillCodNaturezaBancoCollection();
            cmbBxCodigoNatBanco.DataSource = RgParamNatureza;
            cmbBxCodigoNatBanco.ValueMember = "IdNaturezaBanco";
            cmbBxCodigoNatBanco.DisplayMember = "DescrNaturezaBanco";
            cmbBxCodigoNatBanco.SelectedValue = this.CodigoNatBanco;
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxCodigoNatBanco.SelectedValue);

            FillCodStatusAtivoCollection();
            cmbBxCodigoStatusAtivo.DataSource = RgParamStatus;
            cmbBxCodigoStatusAtivo.ValueMember = "IdRgStatusAtivo";
            cmbBxCodigoStatusAtivo.DisplayMember = "DescrStatusAtivo";
            cmbBxCodigoStatusAtivo.SelectedValue = this.CodigoStatusAtivo;
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxCodigoStatusAtivo.SelectedValue);

            FillCodStatusInativoCollection();
            cmbBxCodigoStatusInativo.DataSource = RgParamStatus;
            cmbBxCodigoStatusInativo.ValueMember = "IdRgStatusInativo";
            cmbBxCodigoStatusInativo.DisplayMember = "DescrStatusInativo";
            cmbBxCodigoStatusInativo.SelectedValue = this.CodigoStatusInativo;
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxCodigoStatusInativo.SelectedValue);

            FillCodNaturezaTomadoraCollection();
            cmbBxCodigoNatTomadora.DataSource = RgParamNatureza;
            cmbBxCodigoNatTomadora.ValueMember = "IdNaturezaTomadora";
            cmbBxCodigoNatTomadora.DisplayMember = "DescrNaturezaTomadora";
            cmbBxCodigoNatTomadora.SelectedValue = this.CodigoNatTomadora;
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxCodigoNatTomadora.SelectedValue);

            FillCodNaturezaResponsavelCollection();
            cmbBxCodigoNatResponsavel.DataSource = RgParamNatureza;
            cmbBxCodigoNatResponsavel.ValueMember = "IdNaturezaResponsavel";
            cmbBxCodigoNatResponsavel.DisplayMember = "DescrNaturezaResponsavel";
            cmbBxCodigoNatResponsavel.SelectedValue = this.CodigoNatResp;
            AppStateOverallRecord.CodigoEmpresaNaturesaStatusPorVinculo = Convert.ToInt32(cmbBxCodigoNatResponsavel.SelectedValue);
        }
        private void FillEmpresaCollection()
        {
            if (_IntegracaoEmpresaCollection == null)
            {
                _IntegracaoEmpresaCollection = new List<IntegracaoEmpresa>();
            }

            foreach (DataRow _Row  in _DataSetEmpresaNaturezaStatusPorVinculo.Tables[0].Rows)
            {
                _IntegracaoEmpresaCollection.Add(new IntegracaoEmpresa(_Row));
            }

            IntegracaoEmpresa = _IntegracaoEmpresaCollection;
        }

        private void FillCollectionRgParamNatureza(int _Tbl)
        {

            _RgParamNaturezaCollection = null;

            if (_RgParamNaturezaCollection == null)
            {
                _RgParamNaturezaCollection = new List<RgParamNatureza>();
            }

            foreach (DataRow _Row in _DataSetEmpresaNaturezaStatusPorVinculo.Tables[_Tbl].Rows)
            {
                _RgParamNaturezaCollection.Add(new RgParamNatureza(_Row, _Tbl));
            }

            RgParamNatureza = _RgParamNaturezaCollection;
        }

        private void FillCollectionRgParamStatus(int _Tbl)
        {
            _RgParamStatusCollection = null;

            if (_RgParamStatusCollection == null)
            {
                _RgParamStatusCollection = new List<RgParamStatus>();
            }

            foreach (DataRow _Row in _DataSetEmpresaNaturezaStatusPorVinculo.Tables[_Tbl].Rows)
            {
                _RgParamStatusCollection.Add(new RgParamStatus(_Row, _Tbl));
            }

            RgParamStatus = _RgParamStatusCollection;
        }

        private void FillCodNaturezaFuncionarioCollection()
        {
            int _Tbl = 1;
            FillCollectionRgParamNatureza(_Tbl);
        }

        private void FillCodNaturezaFuncionarioLiderCollection()
        {
            int _Tbl = 2;
            FillCollectionRgParamNatureza(_Tbl);
        }

        private void FillCodNaturezaClienteCollection()
        {
            int _Tbl = 3;
            FillCollectionRgParamNatureza(_Tbl);
        }

        private void FillCodNaturezaFornecedorCollection()
        {
            int _Tbl = 4;
            FillCollectionRgParamNatureza(_Tbl);
        }

        private void FillCodNaturezaBancoCollection()
        {
            int _Tbl = 5;
            FillCollectionRgParamNatureza(_Tbl);
        }

         private void FillCodStatusAtivoCollection()
        {
            int _Tbl = 6;
            FillCollectionRgParamStatus(_Tbl);
        }

        private void FillCodStatusInativoCollection()
        {
            int _Tbl = 7;
            FillCollectionRgParamStatus(_Tbl);
        }

        private void FillCodNaturezaTomadoraCollection()
        {
            int _Tbl = 8;
            FillCollectionRgParamNatureza(_Tbl);
        }

        private void FillCodNaturezaResponsavelCollection()
        {
            int _Tbl = 9;
            FillCollectionRgParamNatureza(_Tbl);
        }

        private void FillDataParametersToExecuteUpdateModify()
        {
            cmbBxEmpresa.SelectedValue = CodigoEmpresa.ToString();
            cmbBxCodigoNatFunc.SelectedValue = CodigoNatFunc.ToString();
            cmbBxCodigoNatFuncLider.SelectedValue = CodigoNatFuncLider.ToString();
            cmbBxCodigoNatCliente.SelectedValue = CodigoNatCliente.ToString();
            cmbBxCodigoNatFornecedor.SelectedValue = CodigoNatFornecedor.ToString();
            cmbBxCodigoNatBanco.SelectedValue = CodigoNatBanco.ToString();
            cmbBxCodigoStatusAtivo.SelectedValue = CodigoStatusAtivo.ToString();
            cmbBxCodigoStatusInativo.SelectedValue = CodigoStatusInativo.ToString();
            cmbBxCodigoNatTomadora.SelectedValue = CodigoNatTomadora.ToString();
            cmbBxCodigoNatResponsavel.SelectedValue = CodigoNatResp.ToString();
            ckBxPermiteCGCCPFDuplic.Checked = PermiteCGCCPFDuplicado.ToString() == "S" ? true : false;
            ckBxPermiteCGCCPFZerado.Checked = PermiteCGCCPFZerado.ToString() == "S" ? true : false;
        }
    }
}
