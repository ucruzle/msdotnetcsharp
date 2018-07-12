using BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects;
using BrSoftNet.App.Business.Processes.OverallRecord.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using BrSoftNet.Library.Messages;
using BrSoftNet.Library.Utilities;

namespace BrSoftNet.App.UI.Win.OverallRecord.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormRegistroGeral : Form
    {
        #region ...::: Private Fields :::...

        private List<RgMunicipio> _RgMunicipioCollection = null;
        private List<RgTipoRg> _RgTipoRgCollection = null;
        private List<RgStatus> _RgStatusCollection = null;
        private List<RgNatureza> _RgNaturezaCollection = null;
        private List<RgEstado> _RgEstadoCollection = null;

        private string _Filter = string.Empty;
        private int _IsFilter = 0;

        #endregion

        #region ...::: Public Properties :::...

        public string Filter { get; set; }

        public int IsFilter { get; set; }

        public int IdEmpresa { get; set; }

        #endregion

        public FilterSearchFormRegistroGeral()
        {
            InitializeComponent();
            InicializeDataForm();

            this.txtBxRg.GotFocus += txtRg_GotFocus;
            this.txtBxRg.LostFocus += txtRg_LostFocus;

            this.txtBxNome.LostFocus += txtNome_LostFocus;
            this.txtBxNome.GotFocus += txtNome_GotFocus;

            this.cmBxCidade.GotFocus += cmBxCidade_GotFocus;
            this.cmBxCidade.LostFocus += cmBxCidade_LostFocus;

            this.txtNroCPF.LostFocus += txtNroCPF_LostFocus;
            this.txtNroCPF.GotFocus += txtNroCPF_GotFocus;

            this.txtCPFDigito.LostFocus += txtCPFDigito_LostFocus;
            this.txtCPFDigito.GotFocus += txtCPFDigito_GotFocus;

            this.txtNroRg.LostFocus += txtNroRg_LostFocus;
            this.txtNroRg.GotFocus += txtNroRg_GotFocus;

            this.txtRGDigito.LostFocus += txtRGDigito_LostFocus;
            this.txtRGDigito.GotFocus += txtRGDigito_GotFocus;

            this.txtCNPJ.LostFocus += txtCNPJ_LostFocus;
            this.txtCNPJ.GotFocus += txtCNPJ_GotFocus;

            this.txtBarraCNPJ.LostFocus += txtBarraCNPJ_LostFocus;
            this.txtBarraCNPJ.GotFocus += txtBarraCNPJ_GotFocus;

            this.txtIfemCNPJ.LostFocus += txtIfemCNPJ_LostFocus;
            this.txtIfemCNPJ.GotFocus += txtIfemCNPJ_GotFocus;

            this.txtBxInscrEst.LostFocus += txtInscrEst_LostFocus;
            this.txtBxInscrEst.GotFocus += txtInscrEst_GotFocus;

            this.txtBxUsuario.LostFocus += txtUsuario_LostFocus;
            this.txtBxUsuario.GotFocus += txtUsuario_GotFocus;

            this.cmBxEstado.LostFocus += cmBxEstado_LostFocus;
            this.cmBxEstado.GotFocus += cmBxEstado_GotFocus;

            this.txtBxCEP.LostFocus += txtCEP_LostFocus;
            this.txtBxCEP.GotFocus += txtCEP_GotFocus;

            this.txtddd.LostFocus += txtddd_LostFocus;
            this.txtddd.GotFocus += txtddd_GotFocus;

            this.txtNro.LostFocus += txtNro_LostFocus;
            this.txtNro.GotFocus += txtNro_GotFocus;

            this.mskdEdtDtInclusaoIni.LostFocus += mskdEdtDtInclusaoIni_LostFocus;
            this.mskdEdtDtInclusaoIni.GotFocus += mskdEdtDtInclusaoIni_GotFocus;

            this.mskdEdtDtInclusaoFim.LostFocus += mskdEdtDtInclusaoFim_LostFocus;
            this.mskdEdtDtInclusaoFim.GotFocus += mskdEdtDtInclusaoFim_GotFocus;

            this.cmBxStatusRg.LostFocus += cmBxStatusRg_LostFocus;
            this.cmBxStatusRg.GotFocus += cmBxStatusRg_GotFocus;

            this.cmBxTipoPessoa.LostFocus += cmBxTipoPessoa_LostFocus;
            this.cmBxTipoPessoa.GotFocus += cmBxTipoPessoa_GotFocus;

            this.cmBxNaturezas.LostFocus += cmBxNaturezas_LostFocus;
            this.cmBxNaturezas.GotFocus += cmBxNaturezas_GotFocus;
        }

        void cmBxNaturezas_GotFocus(object sender, EventArgs e)
        {
            cmBxNaturezas.BackColor = Color.LightYellow;
        }

        void cmBxNaturezas_LostFocus(object sender, EventArgs e)
        {
            cmBxNaturezas.BackColor = Color.White;
        }

        void cmBxTipoPessoa_GotFocus(object sender, EventArgs e)
        {
            cmBxTipoPessoa.BackColor = Color.LightYellow;
        }

        void cmBxTipoPessoa_LostFocus(object sender, EventArgs e)
        {
            cmBxTipoPessoa.BackColor = Color.White;
        }

        void cmBxStatusRg_GotFocus(object sender, EventArgs e)
        {
            cmBxStatusRg.BackColor = Color.LightYellow;
        }

        void cmBxStatusRg_LostFocus(object sender, EventArgs e)
        {
            cmBxStatusRg.BackColor = Color.White;
        }

        void mskdEdtDtInclusaoFim_GotFocus(object sender, EventArgs e)
        {
            mskdEdtDtInclusaoFim.BackColor = Color.LightYellow;
        }

        void mskdEdtDtInclusaoFim_LostFocus(object sender, EventArgs e)
        {
            mskdEdtDtInclusaoFim.BackColor = Color.White;
        }

        void mskdEdtDtInclusaoIni_GotFocus(object sender, EventArgs e)
        {
            mskdEdtDtInclusaoIni.BackColor = Color.LightYellow;
        }

        void mskdEdtDtInclusaoIni_LostFocus(object sender, EventArgs e)
        {
            mskdEdtDtInclusaoIni.BackColor = Color.White;
        }

        void txtNro_GotFocus(object sender, EventArgs e)
        {
            txtNro.BackColor = Color.LightYellow;
        }

        void txtNro_LostFocus(object sender, EventArgs e)
        {
            txtNro.BackColor = Color.White;
        }

        void txtddd_GotFocus(object sender, EventArgs e)
        {
            txtddd.BackColor = Color.LightYellow;
        }

        void txtddd_LostFocus(object sender, EventArgs e)
        {
            txtddd.BackColor = Color.White;
        }

        void txtCEP_GotFocus(object sender, EventArgs e)
        {
            txtBxCEP.BackColor = Color.LightYellow;
        }

        void txtCEP_LostFocus(object sender, EventArgs e)
        {
            txtBxCEP.BackColor = Color.White;
        }

        void cmBxEstado_GotFocus(object sender, EventArgs e)
        {
            cmBxEstado.BackColor = Color.LightYellow;
        }

        void cmBxEstado_LostFocus(object sender, EventArgs e)
        {
            cmBxEstado.BackColor = Color.White;
        }

        void txtUsuario_GotFocus(object sender, EventArgs e)
        {
            txtBxUsuario.BackColor = Color.LightYellow;
        }

        void txtUsuario_LostFocus(object sender, EventArgs e)
        {
            txtBxUsuario.BackColor = Color.White;
        }

        void txtInscrEst_GotFocus(object sender, EventArgs e)
        {
            txtBxInscrEst.BackColor = Color.LightYellow;
        }

        void txtInscrEst_LostFocus(object sender, EventArgs e)
        {
            txtBxInscrEst.BackColor = Color.White;
        }

        void txtIfemCNPJ_GotFocus(object sender, EventArgs e)
        {
            txtIfemCNPJ.BackColor = Color.LightYellow;
        }

        void txtIfemCNPJ_LostFocus(object sender, EventArgs e)
        {
            txtIfemCNPJ.BackColor = Color.White;
        }

        void txtBarraCNPJ_GotFocus(object sender, EventArgs e)
        {
            txtBarraCNPJ.BackColor = Color.LightYellow;
        }

        void txtBarraCNPJ_LostFocus(object sender, EventArgs e)
        {
            txtBarraCNPJ.BackColor = Color.White;
        }

        void txtCNPJ_GotFocus(object sender, EventArgs e)
        {
            txtCNPJ.BackColor = Color.LightYellow;
        }

        void txtCNPJ_LostFocus(object sender, EventArgs e)
        {
            txtCNPJ.BackColor = Color.White;
        }

        void txtRGDigito_GotFocus(object sender, EventArgs e)
        {
            txtRGDigito.BackColor = Color.LightYellow;
        }

        void txtRGDigito_LostFocus(object sender, EventArgs e)
        {
            txtRGDigito.BackColor = Color.White;
        }

        void txtNroRg_GotFocus(object sender, EventArgs e)
        {
            txtNroRg.BackColor = Color.LightYellow;
        }

        void txtNroRg_LostFocus(object sender, EventArgs e)
        {
            txtNroRg.BackColor = Color.White;
        }

        void txtCPFDigito_GotFocus(object sender, EventArgs e)
        {
            txtCPFDigito.BackColor = Color.LightYellow;
        }

        void txtCPFDigito_LostFocus(object sender, EventArgs e)
        {
            txtCPFDigito.BackColor = Color.White;
        }

        void txtNroCPF_GotFocus(object sender, EventArgs e)
        {
            txtNroCPF.BackColor = Color.LightYellow;
        }

        void txtNroCPF_LostFocus(object sender, EventArgs e)
        {
            txtNroCPF.BackColor = Color.White;
        }

        void cmBxCidade_LostFocus(object sender, EventArgs e)
        {
            cmBxCidade.BackColor = Color.White;
        }

        void cmBxCidade_GotFocus(object sender, EventArgs e)
        {
            cmBxCidade.BackColor = Color.LightYellow;
        }

        void txtNome_GotFocus(object sender, EventArgs e)
        {
            txtBxNome.BackColor = Color.LightYellow;
        }

        void txtNome_LostFocus(object sender, EventArgs e)
        {
            txtBxNome.BackColor = Color.White;
        }

        void txtRg_LostFocus(object sender, EventArgs e)
        {
            txtBxRg.BackColor = Color.White;
        }

        void txtRg_GotFocus(object sender, EventArgs e)
        {
            txtBxRg.BackColor = Color.LightYellow;
        }

        private void InicializeDataForm()
        {
            if ((_RgMunicipioCollection == null) || (_RgTipoRgCollection == null) || (_RgStatusCollection == null) || (_RgNaturezaCollection == null) || (_RgEstadoCollection == null))
            {
                _RgMunicipioCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgMunicipio();
                _RgTipoRgCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgTipoRg();
                _RgStatusCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgStatus();
                _RgNaturezaCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgNatureza();
                _RgEstadoCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgEstado();
            }

            cmBxCidade.DataSource = _RgMunicipioCollection;
            cmBxCidade.ValueMember = "IdMunicipio";
            cmBxCidade.DisplayMember = "Municipio";

            cmBxTipoPessoa.DataSource = _RgTipoRgCollection;
            cmBxTipoPessoa.ValueMember = "TipoRg";
            cmBxTipoPessoa.DisplayMember = "DescrTipo";

            cmBxStatusRg.DataSource = _RgStatusCollection;
            cmBxStatusRg.ValueMember = "IdRgStatus";
            cmBxStatusRg.DisplayMember = "DescrStatus";

            cmBxNaturezas.DataSource = _RgNaturezaCollection;
            cmBxNaturezas.ValueMember = "IdNatureza";
            cmBxNaturezas.DisplayMember = "DescrNatureza";

            cmBxEstado.DataSource = _RgEstadoCollection;
            cmBxEstado.ValueMember = "UF";
            cmBxEstado.DisplayMember = "DescrEstado";
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            FormClose();
        }

        private void FormClose()
        {
            this.Filter = string.Empty;
            this.IsFilter = 0;
            this.Close();
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {
            SetFilter();
            this.Close();
        }

        private void SetFilter()
        {
            switch (tbCntrlByFilterRegistroGeral.SelectedIndex)
            {
                case 0:
                    _IsFilter = 1;
                    _Filter = string.Format(" WHERE RG.cod_empr = {0} AND RG.cod_rg = {1} ", IdEmpresa, Convert.ToInt32(txtBxRg.Text));
                    break;
                case 1:
                    _IsFilter = 1;
                    _Filter = string.Format(" WHERE RG.razao_social LIKE '%{0}%' ", txtBxNome.Text);
                    break;
                case 2:
                    _IsFilter = 1;
                    _Filter = string.Format(" WHERE ED.cod_municipio = {0} ", Convert.ToInt32(cmBxCidade.SelectedValue));
                    break;
                case 3:
                    _IsFilter = 1;
                    _Filter = string.Format(" WHERE FJ.num_cpf = {0} AND FJ.dig_cpf = {1} ", Convert.ToInt32(txtNroCPF.Text), Convert.ToInt32(txtCPFDigito.Text));
                    break;
                case 4:
                    _IsFilter = 1;
                    _Filter = string.Format(" WHERE FJ.num_rg = '{0}' AND FJ.dig_rg = '{1}' ", txtNroRg.Text, txtRGDigito.Text);
                    break;
                case 5:
                    _IsFilter = 1;
                    _Filter = string.Format(" WHERE FJ.cgc = {0} AND FJ.filial_cgc = {1} AND FJ.dig_cgc = {2} ", Convert.ToInt32(txtCNPJ.Text), Convert.ToInt32(txtBarraCNPJ.Text), Convert.ToInt32(txtIfemCNPJ.Text));
                    break;
                case 6:
                    _IsFilter = 1;
                    _Filter = string.Format(" WHERE FJ.insc_estadual = '{0}' ", txtBxInscrEst.Text);
                    break;
                case 7:
                    _IsFilter = 1;
                    _Filter = string.Format(" WHERE RG.usuario = '{0}' ", txtBxUsuario.Text);
                    break;
                case 8:
                    _IsFilter = 1;
                    _Filter = string.Format(" WHERE UF.sigla_estado = '{0}' ", Convert.ToString(cmBxEstado.SelectedValue));
                    break;
                case 9:
                    _IsFilter = 1;
                    _Filter = string.Format(" WHERE ED.cep = {0} ", Convert.ToInt32(txtBxCEP.Text));
                    break;
                case 10:
                    _IsFilter = 1;
                    _Filter = string.Format(" WHERE TE.ddd_fone = {0} AND TE.numero_fone = '{1}' ", Convert.ToInt32(txtddd.Text), txtNro.Text);
                    break;
                case 11:
                    _IsFilter = 1;
                    _Filter = string.Format(" WHERE RG.data_hora <= '{0}' AND RG.data_hora >= '{1}' ", DateTime.Parse(mskdEdtDtInclusaoFim.Text).ToString("yyyy-MM-dd"), DateTime.Parse(mskdEdtDtInclusaoIni.Text).ToString("yyyy-MM-dd"));
                    break;
                case 12:
                    _IsFilter = 1;
                    if (chckBxStatusRg.Checked)
                    {
                        _Filter = " WHERE RG.cod_status IN (SELECT cod_status FROM rg_status) ";
                    }
                    else
                    {
                        _Filter = string.Format(" WHERE RG.cod_status = {0} ", Convert.ToInt32(cmBxStatusRg.SelectedValue));
                    }
                    break;
                case 13:
                    _IsFilter = 1;
                    if (chckBxTipoPessoa.Checked)
                    {
                        _Filter = " WHERE RG.tipo_rg IN (SELECT tipo_rg FROM rg_tipo_rg) ";
                    }
                    else
                    {
                        _Filter = string.Format(" WHERE RG.tipo_rg = '{0}' ", Convert.ToString(cmBxTipoPessoa.SelectedValue));
                    }
                    break;
                case 14:
                    _IsFilter = 1;
                    if (chckNatureza.Checked)
                    {
                        _Filter = " WHERE NA.cod_natureza IN (SELECT cod_natureza FROM rg_natureza) ";
                    }
                    else
                    {
                        _Filter = string.Format(" WHERE NA.cod_natureza = {0} ", Convert.ToInt32(cmBxNaturezas.SelectedValue));
                    }
                    break;
                default:
                    this.Filter = string.Empty;
                    this.IsFilter = 0;
                    break;
            }

            this.Filter = _Filter;
            this.IsFilter = _IsFilter;
        }

        // ...::: INICO VALIDAÇÕES :::...
        private void txtBxRg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBxRg.Text == string.Empty)
            {
                ErrPvdrRegistroGeral.SetError(txtBxRg, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPvdrRegistroGeral.SetError(txtBxRg, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaAceiteSomenteNumeros(txtBxRg.Text))
                {
                    ErrPvdrRegistroGeral.SetError(txtBxRg, ValidationsMessages.VALIDA_CODIGO);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPvdrRegistroGeral.SetError(txtBxRg, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBxNome.Text == string.Empty)
            {
                ErrPvdrRegistroGeral.SetError(txtBxNome, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPvdrRegistroGeral.SetError(txtBxNome, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaAceiteSomenteCaracteres(txtBxNome.Text))
                {
                    ErrPvdrRegistroGeral.SetError(txtBxNome, ValidationsMessages.VALIDA_NOME);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPvdrRegistroGeral.SetError(txtBxNome, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxInscrEst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBxInscrEst.Text == string.Empty)
            {
                ErrPvdrRegistroGeral.SetError(txtBxInscrEst, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPvdrRegistroGeral.SetError(txtBxInscrEst, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaIncricaoEstadual(txtBxInscrEst.Text))
                {
                    ErrPvdrRegistroGeral.SetError(txtBxInscrEst, ValidationsMessages.VALIDA_INSCEST);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPvdrRegistroGeral.SetError(txtBxInscrEst, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBxUsuario.Text == string.Empty)
            {
                ErrPvdrRegistroGeral.SetError(txtBxUsuario, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPvdrRegistroGeral.SetError(txtBxUsuario, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }

        }

        private void txtBxCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBxCEP.Text == string.Empty)
            {
                ErrPvdrRegistroGeral.SetError(txtBxCEP, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPvdrRegistroGeral.SetError(txtBxCEP, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaCEP(txtBxCEP.Text))
                {
                    ErrPvdrRegistroGeral.SetError(txtBxCEP, ValidationsMessages.VALIDA_CEP);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPvdrRegistroGeral.SetError(txtBxCEP, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void mskdEdtDtInclusaoIni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mskdEdtDtInclusaoIni.Text == string.Empty)
            {
                ErrPvdrRegistroGeral.SetError(mskdEdtDtInclusaoIni, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPvdrRegistroGeral.SetError(mskdEdtDtInclusaoIni, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaData(mskdEdtDtInclusaoIni.Text))
                {
                    ErrPvdrRegistroGeral.SetError(mskdEdtDtInclusaoIni, ValidationsMessages.VALIDA_DATA);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPvdrRegistroGeral.SetError(mskdEdtDtInclusaoIni, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void mskdEdtDtInclusaoFim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mskdEdtDtInclusaoFim.Text == string.Empty)
            {
                ErrPvdrRegistroGeral.SetError(mskdEdtDtInclusaoFim, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPvdrRegistroGeral.SetError(mskdEdtDtInclusaoFim, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaData(mskdEdtDtInclusaoFim.Text))
                {
                    ErrPvdrRegistroGeral.SetError(mskdEdtDtInclusaoFim, ValidationsMessages.VALIDA_DATA);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPvdrRegistroGeral.SetError(mskdEdtDtInclusaoFim, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }
    }
}
