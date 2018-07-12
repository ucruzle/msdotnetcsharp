using BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects;
using BrSoftNet.App.Business.Processes.OverallRecord.Enumerators;
using BrSoftNet.App.Business.Processes.OverallRecord.Tasks;
using BrSoftNet.App.UI.Win.OverallRecord.DataMaintenance;
using BrSoftNet.App.UI.Win.OverallRecord.DataTransferProcess;
using BrSoftNet.App.UI.Win.OverallRecord.DialogUpdateForm.UpdateFormRegistroGeralHelperScreen;
using BrSoftNet.App.UI.Win.OverallRecord.State;
using BrSoftNet.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Linq.Expressions;
using BrSoftNet.Library.Messages;
using BrSoftNet.Log.Structures;
using BrSoftNet.Log.Helpers;
using BrSoftNet.Log.Actions;

namespace BrSoftNet.App.UI.Win.OverallRecord.DialogUpdateForm
{
    public partial class UpdateFormRegistroGeral : Form
    {
        #region ...::: Private Variable :::...

        RgRegGeral _RgRegGeral = null; 
        RgEndereco _RgEndereco = null; 
        List<RgTelefone> _RgTelefoneCollection = null;
        List<RgRegGeralNatureza> _RgRegGeralNaturezaCollection = null;
        RgFisicaJuridica _RgFisicaJuridica = null;
        private RegistroGeralProcessMapping _RegistroGeralProcessMapping = null;
        private GenericSerializer<RegistroGeralProcessMapping> _Map = null;
        private List<RgMunicipio> _RgMunicipioCollection = null;
        private List<RgTipoRg> _RgTipoRgCollection = null;
        private List<RgStatus> _RgStatusCollection = null;
        private string _XML = string.Empty;
        private string _TipoModificacao = string.Empty;
        private int _IdExecute = 0;

        // Variaveis usadas no Log
        private int _IdEmpresa = 0;
        private int _IdRegistro = 0;
        private int _IdStatus = 0;
        private string _RazaoSocial = string.Empty;
        private string _TipoRg = string.Empty;
        private string _Usuario = string.Empty;
        private string _NomeFantazia = string.Empty;
        private string _OpitanteSimples = string.Empty;
        private DateTime _DataHora = Convert.ToDateTime("01/01/0001 00:00:00");

        #endregion

        #region ...::: Private Constants :::...

        private const string _COLLECTION_NAME = "RegistroGeralProcessMapping";

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpr { get; set; }
        public int IdRg { get; set; }
        public int IdStatus { get; set; }
        public string RazaoSocial { get; set; }
        public string TipoRg { get; set; }
        public string Usuario { get; set; }
        public string NomeFantazia { get; set; }
        public string OpitanteSimples{ get; set; }
        public DateTime DataHora { get; set; }

        public string UsuarioLogin { get; set; }
        public ModificaRegistroGeralType ModificaRegistroGeralType { get; set; }
        public string TextoDoTilutoDoFormulario { get; set; }

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

        private string _IdExcepitionLog = string.Empty;
        private string _MenssageLogError = string.Empty;

        #endregion

        public UpdateFormRegistroGeral()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();

            this.txtBxRazaoSocial.GotFocus += txtBxRazaoSocial_GotFocus;
            this.txtBxRazaoSocial.LostFocus += txtBxRazaoSocial_LostFocus;

            this.txtBxNomeFantasia.GotFocus += txtNomeFantasia_GotFocus;
            this.txtBxNomeFantasia.LostFocus += txtNomeFantasia_LostFocus;

            this.txtBxEndereco.GotFocus += txtEndereco_GotFocus;
            this.txtBxEndereco.LostFocus += txtEndereco_LostFocus;

            this.txtBxNro.GotFocus += txtNro_GotFocus;
            this.txtBxNro.LostFocus += txtNro_LostFocus;

            this.txtBxBairro.GotFocus += txtBairro_GotFocus;
            this.txtBxBairro.LostFocus += txtBairro_LostFocus;

            this.txtBxComplemento.GotFocus += txtComplemento_GotFocus;
            this.txtBxComplemento.LostFocus += txtComplemento_LostFocus;

            this.cmBxCidade.GotFocus += cmBxCidade_GotFocus;
            this.cmBxCidade.LostFocus += cmBxCidade_LostFocus;

            this.txtBxCEP.GotFocus += txtCEP_GotFocus;
            this.txtBxCEP.LostFocus += txtCEP_LostFocus;

            this.txtBxCxPostal.GotFocus += txtCxPostal_GotFocus;
            this.txtBxCxPostal.LostFocus += txtCxPostal_LostFocus;

            this.txtBxHomePage.GotFocus += txtHomePage_GotFocus;
            this.txtBxHomePage.LostFocus += txtHomePage_LostFocus;

            this.txtBxEmail.GotFocus += txtEmail_GotFocus;
            this.txtBxEmail.LostFocus += txtEmail_LostFocus;

            this.txtCPF.GotFocus += txtCPF_GotFocus;
            this.txtCPF.LostFocus += txtCPF_LostFocus;

            this.txtCPFDigito.GotFocus += txtCPFDigito_GotFocus;
            this.txtCPFDigito.LostFocus += txtCPFDigito_LostFocus;

            this.txtInscrMunicipal.GotFocus += txtInscrMunicipal_GotFocus;
            this.txtInscrMunicipal.LostFocus += txtInscrMunicipal_LostFocus;

            this.txtCEI.GotFocus += txtCEI_GotFocus;
            this.txtCEI.LostFocus += txtCEI_LostFocus;

            this.txtRG.GotFocus += txtRG_GotFocus;
            this.txtRG.LostFocus += txtRG_LostFocus;

            this.txtRGDigito.GotFocus += txtRGDigito_GotFocus;
            this.txtRGDigito.LostFocus += txtRGDigito_LostFocus;

            this.mskdEdtDtEmissao.GotFocus += mskdEdtDtEmissao_GotFocus;
            this.mskdEdtDtEmissao.LostFocus += mskdEdtDtEmissao_LostFocus;

            this.txtOrgaoExpeditor.GotFocus += txtOrgaoExpeditor_GotFocus;
            this.txtOrgaoExpeditor.LostFocus += txtOrgaoExpeditor_LostFocus;

            this.txtCNPJ.GotFocus += txtCNPJ_GotFocus;
            this.txtCNPJ.LostFocus += txtCNPJ_LostFocus;

            this.txtBarraCNPJ.GotFocus += txtBarraCNPJ_GotFocus;
            this.txtBarraCNPJ.LostFocus += txtBarraCNPJ_LostFocus;

            this.txtIfemCNPJ.GotFocus += txtIfemCNPJ_GotFocus;
            this.txtIfemCNPJ.LostFocus += txtIfemCNPJ_LostFocus;

            this.txtInscEst.GotFocus += txtInscEst_GotFocus;
            this.txtInscEst.LostFocus += txtInscEst_LostFocus;

            this.txtInscMunipJuridica.GotFocus += txtInscMunipJuridica_GotFocus;
            this.txtInscMunipJuridica.LostFocus += txtInscMunipJuridica_LostFocus;

            this.txtCEIJuridica.GotFocus += txtCEIJuridica_GotFocus;
            this.txtCEIJuridica.LostFocus += txtCEIJuridica_LostFocus;

            this.cmBxRgTipoRg.GotFocus += cmBxRgTipoRg_GotFocus;
            this.cmBxRgTipoRg.LostFocus += cmBxRgTipoRg_LostFocus;

            this.cmBxRgStatus.GotFocus += cmBxRgStatus_GotFocus;
            this.cmBxRgStatus.LostFocus += cmBxRgStatus_LostFocus;
        }

        void cmBxRgStatus_LostFocus(object sender, EventArgs e)
        {
            this.cmBxRgStatus.BackColor = Color.White;
        }

        void cmBxRgStatus_GotFocus(object sender, EventArgs e)
        {
            this.cmBxRgStatus.BackColor = Color.LightYellow;
        }

        void cmBxRgTipoRg_LostFocus(object sender, EventArgs e)
        {
            this.cmBxRgTipoRg.BackColor = Color.White;
        }

        void cmBxRgTipoRg_GotFocus(object sender, EventArgs e)
        {
            this.cmBxRgTipoRg.BackColor = Color.LightYellow;
        }

        void txtCEIJuridica_LostFocus(object sender, System.EventArgs e)
        {
            this.txtCEIJuridica.BackColor = Color.White;
        }

        void txtCEIJuridica_GotFocus(object sender, System.EventArgs e)
        {
            this.txtCEIJuridica.BackColor = Color.LightYellow;
        }

        void txtInscMunipJuridica_LostFocus(object sender, System.EventArgs e)
        {
            this.txtInscMunipJuridica.BackColor = Color.White;
        }

        void txtInscMunipJuridica_GotFocus(object sender, System.EventArgs e)
        {
            this.txtInscMunipJuridica.BackColor = Color.LightYellow;
        }

        void txtInscEst_LostFocus(object sender, System.EventArgs e)
        {
            this.txtInscEst.BackColor = Color.White;
        }

        void txtInscEst_GotFocus(object sender, System.EventArgs e)
        {
            this.txtInscEst.BackColor = Color.LightYellow;
        }

        void txtIfemCNPJ_LostFocus(object sender, System.EventArgs e)
        {
            this.txtIfemCNPJ.BackColor = Color.White;
        }

        void txtIfemCNPJ_GotFocus(object sender, System.EventArgs e)
        {
            this.txtIfemCNPJ.BackColor = Color.LightYellow;
        }

        void txtBarraCNPJ_LostFocus(object sender, System.EventArgs e)
        {
            this.txtBarraCNPJ.BackColor = Color.White;
        }

        void txtBarraCNPJ_GotFocus(object sender, System.EventArgs e)
        {
            this.txtBarraCNPJ.BackColor = Color.LightYellow;
        }

        void txtCNPJ_LostFocus(object sender, System.EventArgs e)
        {
            this.txtCNPJ.BackColor = Color.White;
        }

        void txtCNPJ_GotFocus(object sender, System.EventArgs e)
        {
            this.txtCNPJ.BackColor = Color.LightYellow;
        }

        void txtOrgaoExpeditor_LostFocus(object sender, System.EventArgs e)
        {
            this.txtOrgaoExpeditor.BackColor = Color.White;
        }

        void txtOrgaoExpeditor_GotFocus(object sender, System.EventArgs e)
        {
            this.txtOrgaoExpeditor.BackColor = Color.LightYellow;
        }

        void mskdEdtDtEmissao_LostFocus(object sender, System.EventArgs e)
        {
            this.mskdEdtDtEmissao.BackColor = Color.White;
        }

        void mskdEdtDtEmissao_GotFocus(object sender, System.EventArgs e)
        {
            this.mskdEdtDtEmissao.BackColor = Color.LightYellow;
        }

        void txtRGDigito_LostFocus(object sender, System.EventArgs e)
        {
            this.txtRGDigito.BackColor = Color.White;    
        }

        void txtRGDigito_GotFocus(object sender, System.EventArgs e)
        {
            this.txtRGDigito.BackColor = Color.LightYellow;
        }

        void txtRG_LostFocus(object sender, System.EventArgs e)
        {
            this.txtRG.BackColor = Color.White;
        }

        void txtRG_GotFocus(object sender, System.EventArgs e)
        {
            this.txtRG.BackColor = Color.LightYellow;
        }

        void txtCEI_LostFocus(object sender, System.EventArgs e)
        {
            this.txtCEI.BackColor = Color.White;
        }

        void txtCEI_GotFocus(object sender, System.EventArgs e)
        {
            this.txtCEI.BackColor = Color.LightYellow;
        }

        void txtInscrMunicipal_LostFocus(object sender, System.EventArgs e)
        {
            this.txtInscrMunicipal.BackColor = Color.White;
        }

        void txtInscrMunicipal_GotFocus(object sender, System.EventArgs e)
        {
            this.txtInscrMunicipal.BackColor = Color.LightYellow;
        }

        void txtCPFDigito_LostFocus(object sender, System.EventArgs e)
        {
            this.txtCPFDigito.BackColor = Color.White;
        }

        void txtCPFDigito_GotFocus(object sender, System.EventArgs e)
        {
            this.txtCPFDigito.BackColor = Color.LightYellow;
        }

        void txtCPF_LostFocus(object sender, System.EventArgs e)
        {
            this.txtCPF.BackColor = Color.White;
        }

        void txtCPF_GotFocus(object sender, System.EventArgs e)
        {
            this.txtCPF.BackColor = Color.LightYellow;
        }

        void txtEmail_LostFocus(object sender, System.EventArgs e)
        {
            this.txtBxEmail.BackColor = Color.White;
        }

        void txtEmail_GotFocus(object sender, System.EventArgs e)
        {
            this.txtBxEmail.BackColor = Color.LightYellow;
        }

        void txtHomePage_LostFocus(object sender, System.EventArgs e)
        {
            this.txtBxHomePage.BackColor = Color.White;
        }

        void txtHomePage_GotFocus(object sender, System.EventArgs e)
        {
            this.txtBxHomePage.BackColor = Color.LightYellow;
        }

        void txtCxPostal_LostFocus(object sender, System.EventArgs e)
        {
            this.txtBxCxPostal.BackColor = Color.White;
        }

        void txtCxPostal_GotFocus(object sender, System.EventArgs e)
        {
            this.txtBxCxPostal.BackColor = Color.LightYellow;
        }

        void txtCEP_LostFocus(object sender, System.EventArgs e)
        {
            this.txtBxCEP.BackColor = Color.White;
        }

        void txtCEP_GotFocus(object sender, System.EventArgs e)
        {
            this.txtBxCEP.BackColor = Color.LightYellow;
        }

        void cmBxCidade_LostFocus(object sender, System.EventArgs e)
        {
            this.cmBxCidade.BackColor = Color.White;
        }

        void cmBxCidade_GotFocus(object sender, System.EventArgs e)
        {
            this.cmBxCidade.BackColor = Color.LightYellow;
        }

        void txtComplemento_LostFocus(object sender, System.EventArgs e)
        {
            this.txtBxComplemento.BackColor = Color.White;
        }

        void txtComplemento_GotFocus(object sender, System.EventArgs e)
        {
            this.txtBxComplemento.BackColor = Color.LightYellow;
        }

        void txtBairro_LostFocus(object sender, System.EventArgs e)
        {
            this.txtBxBairro.BackColor = Color.White;
        }

        void txtBairro_GotFocus(object sender, System.EventArgs e)
        {
            this.txtBxBairro.BackColor = Color.LightYellow;
        }

        void txtNro_LostFocus(object sender, System.EventArgs e)
        {
            this.txtBxNro.BackColor = Color.White;
        }

        void txtNro_GotFocus(object sender, System.EventArgs e)
        {
            this.txtBxNro.BackColor = Color.LightYellow;
        }

        void txtEndereco_LostFocus(object sender, System.EventArgs e)
        {
            this.txtBxEndereco.BackColor = Color.White;
        }

        void txtEndereco_GotFocus(object sender, System.EventArgs e)
        {
            this.txtBxEndereco.BackColor = Color.LightYellow;
        }

        void txtNomeFantasia_LostFocus(object sender, System.EventArgs e)
        {
            this.txtBxNomeFantasia.BackColor = Color.White;
        }

        void txtNomeFantasia_GotFocus(object sender, System.EventArgs e)
        {
            this.txtBxNomeFantasia.BackColor = Color.LightYellow;
        }

        void txtBxRazaoSocial_LostFocus(object sender, System.EventArgs e)
        {
            this.txtBxRazaoSocial.BackColor = Color.White;
        }

        void txtBxRazaoSocial_GotFocus(object sender, System.EventArgs e)
        {
            this.txtBxRazaoSocial.BackColor = Color.LightYellow;
        }

        private void InicialiazeUpdateForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void AdicionaContato()
        {
            int _SeqTel = 0;
            dsOverallRecordProcess.tblRgTelefoneRow _TelefoneRow = null;
            RgTelefone _RgTelefoneModifyProcess = null;
            List<RgTelefone> _RgTelefoneCollectionModifyProcess = dtGrdVwDadosContatos.DataSource as List<RgTelefone>;

            if (_RgTelefoneCollectionModifyProcess != null)
            {
                _SeqTel = _RgTelefoneCollectionModifyProcess.Count + 1;
            }
            else 
            {
                _SeqTel = 1;
                _RgTelefoneCollectionModifyProcess = new List<RgTelefone>();
            }

            _RgTelefoneModifyProcess = new RgTelefone() { SeqTel = _SeqTel };

            AppStateOverallRecord.RgTelefoneModifyProcess = _RgTelefoneModifyProcess;

            HelperFormRegistroGeralContato _HelperFormRegistroGeralContato = new HelperFormRegistroGeralContato();
            _HelperFormRegistroGeralContato.ModificaRegistroGeralType = ModificaRegistroGeralType.RegistroGeralAdicionar;

            try
            {
                _HelperFormRegistroGeralContato.ShowDialog();
            }
            finally
            {
                if (AppStateOverallRecord.TelefoneRow != null)
                {
                    _TelefoneRow = AppStateOverallRecord.TelefoneRow;

                    _RgTelefoneCollectionModifyProcess.Add(new RgTelefone(
                        IdEmpr,
                        IdRg,
                        _TelefoneRow.SegTel,
                        _TelefoneRow.CodTipoFone,
                        _TelefoneRow.DDDFone,
                        _TelefoneRow.NumeroFone,
                        _TelefoneRow.Contato,
                        _TelefoneRow.EMail,
                        _TelefoneRow.Principal));

                    dtGrdVwDadosContatos.DataSource = null;
                    _RgTelefoneCollectionModifyProcess.OrderBy(x => x.SeqTel);
                    FillDataGridContatos(_RgTelefoneCollectionModifyProcess);

                    _HelperFormRegistroGeralContato.Dispose();
                }
            }
        }

        private void AlteraContato()
        {
            int _IdEmpr = 0;
            int _IdRg = 0;
            int _SeqTel = 0;
            int _IdTipoFone = 0;
            string _DDDFone = string.Empty;
            string _NroFone = string.Empty;
            string _Contato = string.Empty;
            string _EMail = string.Empty;
            string _Principal = string.Empty;

            dsOverallRecordProcess.tblRgTelefoneRow _TelefoneRow = null;
            RgTelefone _RgTelefoneModifyProcess = null;
            List<RgTelefone> _RgTelefoneCollectionModifyProcess = dtGrdVwDadosContatos.DataSource as List<RgTelefone>;

            if (_RgTelefoneCollectionModifyProcess != null)
            {
                if ((Convert.ToInt32(dtGrdVwDadosContatos.CurrentRow.Cells["IdEmpr"].Value) > 0) && (Convert.ToInt32(dtGrdVwDadosContatos.CurrentRow.Cells["IdRg"].Value) > 0))
                {
                    _IdEmpr = dtGrdVwDadosContatos.CurrentRow.Cells["IdEmpr"].Value != null ? Convert.ToInt32(dtGrdVwDadosContatos.CurrentRow.Cells["IdEmpr"].Value) : 0;
                    _IdRg = dtGrdVwDadosContatos.CurrentRow.Cells["IdRg"].Value != null ? Convert.ToInt32(dtGrdVwDadosContatos.CurrentRow.Cells["IdRg"].Value) : 0;
                    _SeqTel = dtGrdVwDadosContatos.CurrentRow.Cells["SeqTel"].Value != null ? Convert.ToInt32(dtGrdVwDadosContatos.CurrentRow.Cells["SeqTel"].Value) : 0;
                    _IdTipoFone = dtGrdVwDadosContatos.CurrentRow.Cells["IdTipoFone"].Value != null ? Convert.ToInt32(dtGrdVwDadosContatos.CurrentRow.Cells["IdTipoFone"].Value) : 0;
                    _DDDFone = dtGrdVwDadosContatos.CurrentRow.Cells["DDDFone"].Value != null ? Convert.ToString(dtGrdVwDadosContatos.CurrentRow.Cells["DDDFone"].Value) : string.Empty;
                    _NroFone = dtGrdVwDadosContatos.CurrentRow.Cells["NroFone"].Value != null ? Convert.ToString(dtGrdVwDadosContatos.CurrentRow.Cells["NroFone"].Value) : string.Empty;
                    _Contato = dtGrdVwDadosContatos.CurrentRow.Cells["Contato"].Value != null ? Convert.ToString(dtGrdVwDadosContatos.CurrentRow.Cells["Contato"].Value) : string.Empty;
                    _EMail = dtGrdVwDadosContatos.CurrentRow.Cells["EMail"].Value != null ? Convert.ToString(dtGrdVwDadosContatos.CurrentRow.Cells["EMail"].Value) : string.Empty;
                    _Principal = dtGrdVwDadosContatos.CurrentRow.Cells["Principal"].Value != null ? Convert.ToString(dtGrdVwDadosContatos.CurrentRow.Cells["Principal"].Value) : string.Empty;

                    _RgTelefoneModifyProcess = new RgTelefone(_IdEmpr, _IdRg, _SeqTel, _IdTipoFone, _DDDFone, _NroFone, _Contato, _EMail, _Principal);

                    AppStateOverallRecord.RgTelefoneModifyProcess = _RgTelefoneModifyProcess;

                    HelperFormRegistroGeralContato _HelperFormRegistroGeralContato = new HelperFormRegistroGeralContato();
                    _HelperFormRegistroGeralContato.ModificaRegistroGeralType = ModificaRegistroGeralType.RegistroGeralAlterar;

                    try
                    {
                        _HelperFormRegistroGeralContato.ShowDialog();
                    }
                    finally
                    {
                        if (AppStateOverallRecord.TelefoneRow != null)
                        {
                            _TelefoneRow = AppStateOverallRecord.TelefoneRow;

                            foreach (RgTelefone _Item in _RgTelefoneCollectionModifyProcess)
                            {
                                if ((_Item.IdEmpr == _RgTelefoneModifyProcess.IdEmpr) && (_Item.IdRg == _RgTelefoneModifyProcess.IdRg) && (_Item.SeqTel == _RgTelefoneModifyProcess.SeqTel))
                                {
                                    _Item.SeqTel = _TelefoneRow.SegTel;
                                    _Item.IdTipoFone = _TelefoneRow.CodTipoFone;
                                    _Item.DDDFone = _TelefoneRow.DDDFone;
                                    _Item.NroFone = _TelefoneRow.NumeroFone;
                                    _Item.Contato = _TelefoneRow.Contato;
                                    _Item.EMail = _TelefoneRow.EMail;
                                    _Item.Principal = _TelefoneRow.Principal;
                                    break;
                                }
                            }

                            dtGrdVwDadosContatos.DataSource = null;
                            _RgTelefoneCollectionModifyProcess.OrderBy(x => x.SeqTel);
                            FillDataGridContatos(_RgTelefoneCollectionModifyProcess);

                            _HelperFormRegistroGeralContato.Dispose();
                        }
                    }
                }
            }
        }

        private void VisualizaContato()
        {
            HelperFormRegistroGeralContatoView _HelperFormRegistroGeralContatoView = new HelperFormRegistroGeralContatoView();
            AppStateOverallRecord.RgTelefoneCollection = dtGrdVwDadosContatos.DataSource as List<RgTelefone>;

            try
            {
                _HelperFormRegistroGeralContatoView.ShowDialog();
            }
            finally
            {
                _HelperFormRegistroGeralContatoView.Dispose();
            }
        }

        private void AdicionaNatureza()
        {
            dsOverallRecordProcess.tblRgNaturezaRow _RgRegGeralNaturezaRow = null;
            RgRegGeralNatureza _RgRegGeralNaturezaModifyProcess = null;
            List<RgRegGeralNatureza> _RgRegGeralNaturezaCollectionModifyProcess = dtGrdVwDadosOperacoes.DataSource as List<RgRegGeralNatureza>;

            if (_RgRegGeralNaturezaCollectionModifyProcess == null)
            {
                _RgRegGeralNaturezaCollectionModifyProcess = new List<RgRegGeralNatureza>();
            }

            _RgRegGeralNaturezaModifyProcess = new RgRegGeralNatureza() { Usuario = UsuarioLogin };

            AppStateOverallRecord.RgRegGeralNaturezaModifyProcess = _RgRegGeralNaturezaModifyProcess;

            HelperFormRegistroGeralNatureza _HelperFormRegistroGeralNatureza = new HelperFormRegistroGeralNatureza();
            _HelperFormRegistroGeralNatureza.ModificaRegistroGeralType = ModificaRegistroGeralType.RegistroGeralAdicionar;

            try
            {
                _HelperFormRegistroGeralNatureza.ShowDialog();
            }
            finally
            {
                if (AppStateOverallRecord.RegGeralNaturezaRow != null)
                {
                    _RgRegGeralNaturezaRow = AppStateOverallRecord.RegGeralNaturezaRow;

                    _RgRegGeralNaturezaCollectionModifyProcess.Add(new RgRegGeralNatureza(
                        IdEmpr,
                        IdRg,
                        _RgRegGeralNaturezaRow.CodNatureza,
                        _RgRegGeralNaturezaRow.CodStatusNat,
                        _RgRegGeralNaturezaRow.DataHora != DateTime.Parse("01/01/0001 00:00:00") ? _RgRegGeralNaturezaRow.DataHora.ToString() : string.Empty,
                        _RgRegGeralNaturezaRow.Usuario));

                    dtGrdVwDadosOperacoes.DataSource = null;
                    _RgRegGeralNaturezaCollectionModifyProcess.OrderBy(x => x.IdNatureza);
                    FillDataGridNatureza(_RgRegGeralNaturezaCollectionModifyProcess);

                    _HelperFormRegistroGeralNatureza.Dispose();
                }
            }
        }

        private void AlteraNatureza()
        {
            int _IdEmpr = 0;
            int _IdRg = 0;
            int _IdNatureza = 0;
            int _IdStatusNat = 0;
            string _DataHora = "01/01/0001 00:00:00";
            string _Usuario = string.Empty;
            string _Ativo = string.Empty;

            dsOverallRecordProcess.tblRgNaturezaRow _RgRegGeralNaturezaRow = null;
            RgRegGeralNatureza _RgRegGeralNaturezaModifyProcess = null;
            List<RgRegGeralNatureza> _RgRegGeralNaturezaCollectionModifyProcess = dtGrdVwDadosOperacoes.DataSource as List<RgRegGeralNatureza>;

            if (_RgRegGeralNaturezaCollectionModifyProcess != null)
            {
                if ((dtGrdVwDadosOperacoes.CurrentRow.Cells["IdEmpr"].Value != null) && (dtGrdVwDadosOperacoes.CurrentRow.Cells["IdRg"].Value != null))
                {
                    _IdEmpr = Convert.ToInt32(dtGrdVwDadosOperacoes.CurrentRow.Cells["IdEmpr"].Value) > 0 ? Convert.ToInt32(dtGrdVwDadosOperacoes.CurrentRow.Cells["IdEmpr"].Value) : 0;
                    _IdRg = Convert.ToInt32(dtGrdVwDadosOperacoes.CurrentRow.Cells["IdRg"].Value) > 0 ? Convert.ToInt32(dtGrdVwDadosOperacoes.CurrentRow.Cells["IdRg"].Value) : 0;
                    _IdNatureza = Convert.ToInt32(dtGrdVwDadosOperacoes.CurrentRow.Cells["IdNatureza"].Value) > 0 ? Convert.ToInt32(dtGrdVwDadosOperacoes.CurrentRow.Cells["IdNatureza"].Value) : 0;
                    _IdStatusNat = Convert.ToInt32(dtGrdVwDadosOperacoes.CurrentRow.Cells["IdStatusNat"].Value) > 0 ? Convert.ToInt32(dtGrdVwDadosOperacoes.CurrentRow.Cells["IdStatusNat"].Value) : 0;
                    _DataHora = Convert.ToDateTime(dtGrdVwDadosOperacoes.CurrentRow.Cells["DataHora"].Value) != DateTime.Parse("01/01/0001 00:00:00") ? dtGrdVwDadosOperacoes.CurrentRow.Cells["DataHora"].Value.ToString() : string.Empty;
                    _Usuario = Convert.ToString(dtGrdVwDadosOperacoes.CurrentRow.Cells["Usuario"].Value) != string.Empty ? Convert.ToString(dtGrdVwDadosOperacoes.CurrentRow.Cells["Usuario"].Value) : string.Empty;

                    _RgRegGeralNaturezaModifyProcess = new RgRegGeralNatureza(_IdEmpr, _IdRg, _IdNatureza, _IdStatusNat, _DataHora, _Usuario);

                    AppStateOverallRecord.RgRegGeralNaturezaModifyProcess = _RgRegGeralNaturezaModifyProcess;

                    HelperFormRegistroGeralNatureza _HelperFormRegistroGeralNatureza = new HelperFormRegistroGeralNatureza();
                    _HelperFormRegistroGeralNatureza.ModificaRegistroGeralType = ModificaRegistroGeralType.RegistroGeralAlterar;

                    try
                    {
                        _HelperFormRegistroGeralNatureza.ShowDialog();
                    }
                    finally
                    {
                        if (AppStateOverallRecord.RegGeralNaturezaRow != null)
                        {
                            _RgRegGeralNaturezaRow = AppStateOverallRecord.RegGeralNaturezaRow;

                            foreach (RgRegGeralNatureza _Item in _RgRegGeralNaturezaCollectionModifyProcess)
                            {
                                if ((_Item.IdEmpr == _RgRegGeralNaturezaModifyProcess.IdEmpr) && (_Item.IdRg == _RgRegGeralNaturezaModifyProcess.IdRg) && (_Item.IdNatureza == _RgRegGeralNaturezaModifyProcess.IdNatureza))
                                {
                                    _Item.IdNatureza = _RgRegGeralNaturezaRow.CodNatureza;
                                    _Item.IdStatusNat = _RgRegGeralNaturezaRow.CodStatusNat;
                                    _Item.DataHora = _RgRegGeralNaturezaRow.DataHora;
                                    _Item.Usuario = _RgRegGeralNaturezaRow.Usuario;
                                    break;
                                }
                            }

                            dtGrdVwDadosOperacoes.DataSource = null;
                            _RgRegGeralNaturezaCollectionModifyProcess.OrderBy(x => x.IdNatureza);
                            FillDataGridNatureza(_RgRegGeralNaturezaCollectionModifyProcess);

                            _HelperFormRegistroGeralNatureza.Dispose();
                        }
                    }
                }
            }
        }

        private void VisualizaNatureza()
        {
            HelperFormRegistroGeralNaturezaView _HelperFormRegistroGeralNaturezaView = new HelperFormRegistroGeralNaturezaView();
            AppStateOverallRecord.RgRegGeralNaturezaCollection = dtGrdVwDadosOperacoes.DataSource as List<RgRegGeralNatureza>;

            try
            {
                _HelperFormRegistroGeralNaturezaView.ShowDialog();
            }
            finally
            {
                _HelperFormRegistroGeralNaturezaView.Dispose();
            }
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {

            this.ExecuteModifyRegistroGerla();

            if (txtBxRazaoSocial.Text == string.Empty)
            {
                ErrPrvdrRegistroGeral.SetError(txtBxRazaoSocial, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxRazaoSocial.Focus();
                return;
            }

            if (txtBxEndereco.Text == string.Empty)
            {
                ErrPrvdrRegistroGeral.SetError(txtBxEndereco, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxEndereco.Focus();
                return;
            }

            if (txtBxNro.Text == string.Empty)
            {
                ErrPrvdrRegistroGeral.SetError(txtBxNro, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxNro.Focus();
                return;
            }

            if (txtBxBairro.Text == string.Empty)
            {
                ErrPrvdrRegistroGeral.SetError(txtBxBairro, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxBairro.Focus();
                return;
            }

            if (txtBxCEP.Text == string.Empty)
            {
                ErrPrvdrRegistroGeral.SetError(txtBxCEP, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxCEP.Focus();
                return;
            }

            if (txtBxCxPostal.Text == string.Empty)
            {
                ErrPrvdrRegistroGeral.SetError(txtBxCxPostal, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxCxPostal.Focus();
                return;
            }

            if (_IdExcepitionLog != string.Empty)
            {
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblExcecao.Text = _MenssageLogError;
                tlstrpLblExcecao.Visible = true;
                return;
            }

            
            this.Close();
        }

        private void ExecuteModifyRegistroGerla()
        {
            switch (ModificaRegistroGeralType)
            {
                case ModificaRegistroGeralType.RegistroGeralAdicionar:
                    ExecuteAddRegistroGeral();
                    break;
                case ModificaRegistroGeralType.RegistroGeralAlterar:
                    ExecuteUpdateRegistroGeral();
                    break;
            }
        }

        private void ExecuteUpdateRegistroGeral()
        {
            #region ...::: Campos Dados Gerais :::...

            AppStateOverallRecord.RgRegGeral.IdEmpr = txtEmpresaVinculada.Text != string.Empty ? Convert.ToInt32(txtEmpresaVinculada.Text) : 0;
            AppStateOverallRecord.RgRegGeral.IdRg = txtCodRg.Text != string.Empty ? Convert.ToInt32(txtCodRg.Text) : 0;
            AppStateOverallRecord.RgRegGeral.RazaoSocial = txtBxRazaoSocial.Text;
            AppStateOverallRecord.RgRegGeral.TipoRg = cmBxRgTipoRg.SelectedValue != null ? Convert.ToString(cmBxRgTipoRg.SelectedValue) : string.Empty;
            AppStateOverallRecord.RgRegGeral.IdStatus = cmBxRgStatus.SelectedValue != null ? Convert.ToInt32(cmBxRgStatus.SelectedValue) : 0;
            AppStateOverallRecord.RgRegGeral.DataHora = txtBxDtHrRgGeral.Text != DateTime.Parse("01/01/0001 00:00:00").ToString() ? DateTime.Parse(txtBxDtHrRgGeral.Text) : DateTime.Parse("01/01/0001 00:00:00");
            AppStateOverallRecord.RgRegGeral.Usuario = txtUsusarioRg.Text;
            AppStateOverallRecord.RgRegGeral.NomeFantasia = txtBxNomeFantasia.Text;
            AppStateOverallRecord.RgRegGeral.OptanteSimples = chckBxAtivoInativo.Checked ? "S" : "N";

            #endregion

            #region ...::: Campos Dados de Localização :::...

            AppStateOverallRecord.RgEndereco.IdEmpr = txtEmpresaVinculada.Text != string.Empty ? Convert.ToInt32(txtEmpresaVinculada.Text) : 0;
            AppStateOverallRecord.RgEndereco.IdRg = txtCodRg.Text != string.Empty ? Convert.ToInt32(txtCodRg.Text) : 0;
            AppStateOverallRecord.RgEndereco.Endereco = txtBxEndereco.Text;
            AppStateOverallRecord.RgEndereco.Nro = txtBxNro.Text;
            AppStateOverallRecord.RgEndereco.Bairro = txtBxBairro.Text;
            AppStateOverallRecord.RgEndereco.Complemento = txtBxComplemento.Text;
            AppStateOverallRecord.RgEndereco.CEP = txtBxCEP.Text != string.Empty ? Convert.ToInt32(txtBxCEP.Text) : 0;
            AppStateOverallRecord.RgEndereco.IdMunicipio = cmBxCidade.SelectedValue != null ? Convert.ToInt32(cmBxCidade.SelectedValue) : 0;
            AppStateOverallRecord.RgEndereco.CxPostal = txtBxCxPostal.Text != string.Empty ? Convert.ToInt32(txtBxCxPostal.Text) : 0;
            AppStateOverallRecord.RgEndereco.EMail = txtBxEmail.Text;
            AppStateOverallRecord.RgEndereco.HomePage = txtBxHomePage.Text;

            #endregion

            #region ...::: Campos Dados de Contatos :::...

            AppStateOverallRecord.RgTelefoneCollection = dtGrdVwDadosContatos.DataSource as List<RgTelefone>;

            #endregion

            #region ...::: Campos Dados de Natureza de Operações :::...

            AppStateOverallRecord.RgRegGeralNaturezaCollection = dtGrdVwDadosOperacoes.DataSource as List<RgRegGeralNatureza>;

            #endregion
            
            #region ...::: Campos Dados de Pessoas Físicas \ Jurídicas :::...

            AppStateOverallRecord.RgFisicasJuridica.IdEmpr = txtEmpresaVinculada.Text != string.Empty ? Convert.ToInt32(txtEmpresaVinculada.Text) : 0;
            AppStateOverallRecord.RgFisicasJuridica.IdRg = txtCodRg.Text != string.Empty ? Convert.ToInt32(txtCodRg.Text) : 0;
            AppStateOverallRecord.RgFisicasJuridica.NroCPF = txtCPF.Text != string.Empty ? Convert.ToInt32(txtCPF.Text) : 0;
            AppStateOverallRecord.RgFisicasJuridica.DigCPF = txtCPFDigito.Text != string.Empty ? Convert.ToInt32(txtCPFDigito.Text) : 0;
            AppStateOverallRecord.RgFisicasJuridica.NroRg = txtRG.Text;
            AppStateOverallRecord.RgFisicasJuridica.DigRg = txtRGDigito.Text;
            ValidaDataDeEmissao();
            AppStateOverallRecord.RgFisicasJuridica.OrgaoExpRg = txtOrgaoExpeditor.Text;
            AppStateOverallRecord.RgFisicasJuridica.InscrMunicipal = txtInscrMunicipal.Text;
            AppStateOverallRecord.RgFisicasJuridica.CEI = txtCEI.Text;
            AppStateOverallRecord.RgFisicasJuridica.CGC = txtCNPJ.Text != string.Empty ? Convert.ToInt32(txtCNPJ.Text) : 0;
            AppStateOverallRecord.RgFisicasJuridica.FilialCGC = txtBarraCNPJ.Text != string.Empty ? Convert.ToInt32(txtBarraCNPJ.Text) : 0;
            AppStateOverallRecord.RgFisicasJuridica.DigCGC = txtIfemCNPJ.Text != string.Empty ? Convert.ToInt32(txtIfemCNPJ.Text) : 0;
            AppStateOverallRecord.RgFisicasJuridica.InscEstadual = txtInscEst.Text;
            AppStateOverallRecord.RgFisicasJuridica.NroBanco = 0;
            AppStateOverallRecord.RgFisicasJuridica.NroAgencia = 0;
            AppStateOverallRecord.RgFisicasJuridica.DigAgencia = 0;
            AppStateOverallRecord.RgFisicasJuridica.NroConta = 0;
            AppStateOverallRecord.RgFisicasJuridica.DigConta = 0;
            AppStateOverallRecord.RgFisicasJuridica.IdTipoCta = 0;

            #endregion

            const string _FUNCAO_DISPARADOR = "ExecuteUpdateRegistro";

            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }   
                _RegistroGeralProcessMapping = OverallRecordServiceHelper.CreateInstance.RetornaMapaDadosRegistroGeral(AppStateOverallRecord.RgRegGeral, AppStateOverallRecord.RgEndereco, AppStateOverallRecord.RgTelefoneCollection, AppStateOverallRecord.RgRegGeralNaturezaCollection, AppStateOverallRecord.RgFisicasJuridica);
                _XML = SerializationData.CreateInstance.GetSerializableData(_RegistroGeralProcessMapping, _COLLECTION_NAME);
                _TipoModificacao = OverallRecordProcess.CreateInstance.FromToModificaParametroGerenciador(ModificaRegistroGeralType.RegistroGeralAlterar);
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

                _IdExcepitionLog = _ThrowingException.Id;

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

                ExecuteModifyExceptionLogRgGeral(_ChangesHeader, _ChangeItems, _ThrowingException);

            }
            finally
            {
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
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }

        private void ValidaDataDeEmissao()
        {
            if (string.IsNullOrEmpty(mskdEdtDtEmissao.Text))
            {
                AppStateOverallRecord.RgFisicasJuridica.DtEmissao = DateTime.Parse("01/01/0001 00:00:00");
            }
            else
            {
                if (!ValidationData.CreateInstance.ValidaData(mskdEdtDtEmissao.Text))
                {
                    AppStateOverallRecord.RgFisicasJuridica.DtEmissao = DateTime.Parse("01/01/0001 00:00:00");
                }
                else
                {
                    AppStateOverallRecord.RgFisicasJuridica.DtEmissao = Convert.ToDateTime(mskdEdtDtEmissao.Text);
                }
            }
        }

        private void ExecuteAddRegistroGeral()
        {
            #region ...::: Campos Dados Gerais :::...

            AppStateOverallRecord.RgRegGeral.IdEmpr = txtEmpresaVinculada.Text != string.Empty ? Convert.ToInt32(txtEmpresaVinculada.Text) : 0;
            AppStateOverallRecord.RgRegGeral.IdRg = txtCodRg.Text != string.Empty ? Convert.ToInt32(txtCodRg.Text) : 0;
            AppStateOverallRecord.RgRegGeral.RazaoSocial = txtBxRazaoSocial.Text;
            AppStateOverallRecord.RgRegGeral.TipoRg = cmBxRgTipoRg.SelectedValue != null ? Convert.ToString(cmBxRgTipoRg.SelectedValue) : string.Empty;
            AppStateOverallRecord.RgRegGeral.IdStatus = cmBxRgStatus.SelectedValue != null ? Convert.ToInt32(cmBxRgStatus.SelectedValue) : 0;
            AppStateOverallRecord.RgRegGeral.DataHora = txtBxDtHrRgGeral.Text != DateTime.Parse("01/01/0001 00:00:00").ToString() ? DateTime.Parse(txtBxDtHrRgGeral.Text) : DateTime.Parse("01/01/0001 00:00:00");
            AppStateOverallRecord.RgRegGeral.Usuario = txtUsusarioRg.Text;
            AppStateOverallRecord.RgRegGeral.NomeFantasia = txtBxNomeFantasia.Text;
            AppStateOverallRecord.RgRegGeral.OptanteSimples = chckBxAtivoInativo.Checked ? "S" : "N";

            #endregion

            #region ...::: Campos Dados de Localização :::...

            AppStateOverallRecord.RgEndereco.IdEmpr = txtEmpresaVinculada.Text != string.Empty ? Convert.ToInt32(txtEmpresaVinculada.Text) : 0;
            AppStateOverallRecord.RgEndereco.IdRg = txtCodRg.Text != string.Empty ? Convert.ToInt32(txtCodRg.Text) : 0;
            AppStateOverallRecord.RgEndereco.Endereco = txtBxEndereco.Text;
            AppStateOverallRecord.RgEndereco.Nro = txtBxNro.Text;
            AppStateOverallRecord.RgEndereco.Bairro = txtBxBairro.Text;
            AppStateOverallRecord.RgEndereco.Complemento = txtBxComplemento.Text;
            AppStateOverallRecord.RgEndereco.CEP = txtBxCEP.Text != string.Empty ? Convert.ToInt32(txtBxCEP.Text) : 0;
            AppStateOverallRecord.RgEndereco.IdMunicipio = cmBxCidade.SelectedValue != null ? Convert.ToInt32(cmBxCidade.SelectedValue) : 0;
            AppStateOverallRecord.RgEndereco.CxPostal = txtBxCxPostal.Text != string.Empty ? Convert.ToInt32(txtBxCxPostal.Text) : 0;
            AppStateOverallRecord.RgEndereco.EMail = txtBxEmail.Text;
            AppStateOverallRecord.RgEndereco.HomePage = txtBxHomePage.Text;

            #endregion

            #region ...::: Campos Dados de Contatos :::...

            AppStateOverallRecord.RgTelefoneCollection = dtGrdVwDadosContatos.DataSource as List<RgTelefone>;

            #endregion

            #region ...::: Campos Dados de Natureza de Operações :::...

            AppStateOverallRecord.RgRegGeralNaturezaCollection = dtGrdVwDadosOperacoes.DataSource as List<RgRegGeralNatureza>;

            #endregion

            #region ...::: Campos Dados de Pessoas Físicas \ Jurídicas :::...

            AppStateOverallRecord.RgFisicasJuridica.IdEmpr = txtEmpresaVinculada.Text != string.Empty ? Convert.ToInt32(txtEmpresaVinculada.Text) : 0;
            AppStateOverallRecord.RgFisicasJuridica.IdRg = txtCodRg.Text != string.Empty ? Convert.ToInt32(txtCodRg.Text) : 0;
            AppStateOverallRecord.RgFisicasJuridica.NroCPF = txtCPF.Text != string.Empty ? Convert.ToInt32(txtCPF.Text) : 0;
            AppStateOverallRecord.RgFisicasJuridica.DigCPF = txtCPFDigito.Text != string.Empty ? Convert.ToInt32(txtCPFDigito.Text) : 0;
            AppStateOverallRecord.RgFisicasJuridica.NroRg = txtRG.Text;
            AppStateOverallRecord.RgFisicasJuridica.DigRg = txtRGDigito.Text;
            ValidaDataDeEmissao();
            AppStateOverallRecord.RgFisicasJuridica.OrgaoExpRg = txtOrgaoExpeditor.Text;
            AppStateOverallRecord.RgFisicasJuridica.InscrMunicipal = txtInscrMunicipal.Text;
            AppStateOverallRecord.RgFisicasJuridica.CEI = txtCEI.Text;
            AppStateOverallRecord.RgFisicasJuridica.CGC = txtCNPJ.Text != string.Empty ? Convert.ToInt32(txtCNPJ.Text) : 0;
            AppStateOverallRecord.RgFisicasJuridica.FilialCGC = txtBarraCNPJ.Text != string.Empty ? Convert.ToInt32(txtBarraCNPJ.Text) : 0;
            AppStateOverallRecord.RgFisicasJuridica.DigCGC = txtIfemCNPJ.Text != string.Empty ? Convert.ToInt32(txtIfemCNPJ.Text) : 0;
            AppStateOverallRecord.RgFisicasJuridica.InscEstadual = txtInscEst.Text;
            AppStateOverallRecord.RgFisicasJuridica.NroBanco = 0;
            AppStateOverallRecord.RgFisicasJuridica.NroAgencia = 0;
            AppStateOverallRecord.RgFisicasJuridica.DigAgencia = 0;
            AppStateOverallRecord.RgFisicasJuridica.NroConta = 0;
            AppStateOverallRecord.RgFisicasJuridica.DigConta = 0;
            AppStateOverallRecord.RgFisicasJuridica.IdTipoCta = 0;

            #endregion

            const string _FUNCAO_DISPARADOR = "ExecuteAddRegistro";
            try
            {
                _RegistroGeralProcessMapping = OverallRecordServiceHelper.CreateInstance.RetornaMapaDadosRegistroGeral(AppStateOverallRecord.RgRegGeral, AppStateOverallRecord.RgEndereco, AppStateOverallRecord.RgTelefoneCollection, AppStateOverallRecord.RgRegGeralNaturezaCollection, AppStateOverallRecord.RgFisicasJuridica);
                _XML = SerializationData.CreateInstance.GetSerializableData(_RegistroGeralProcessMapping, _COLLECTION_NAME);
                _TipoModificacao = OverallRecordProcess.CreateInstance.FromToModificaParametroGerenciador(ModificaRegistroGeralType.RegistroGeralAdicionar);
                _IdExecute = OverallRecordProcess.CreateInstance.TaskModifyProcessGegistroGeral(_XML, _TipoModificacao);

                IdRg = _IdExecute > 0 ? _IdExecute : 0;
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

                _IdExcepitionLog = _ThrowingException.Id;

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

                ExecuteModifyExceptionLogRgGeral(_ChangesHeader, _ChangeItems, _ThrowingException);

            }
            finally
            {
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
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
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

        private void FillLogHeaderFromUpdateModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgRegistroGeral.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdRg;
            _ChangesHeader.TipoModificacao = OverallRecordProcess.CreateInstance.FromToModificaParametroGerenciador(ModificaRegistroGeralType.RegistroGeralAlterar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            // Codigo Empresa
            _LogIdEmpresa = new ChangeItem();
            _LogIdEmpresa.IdChangeHeader = _ChangesHeader.Id;
            _LogIdEmpresa.IdItem = 1;
            _LogIdEmpresa.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogIdEmpresa.NomeCampo = DboRgRegistroGeral.NomeIdEmpresa;
            _LogIdEmpresa.ValorAntigo = IdEmpr;

            // Codigo Rg
            _LogIdRg = new ChangeItem();
            _LogIdRg.IdChangeHeader = _ChangesHeader.Id;
            _LogIdRg.IdItem = 2;
            _LogIdRg.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogIdRg.NomeCampo = DboRgRegistroGeral.NomeIdRg;
            _LogIdRg.ValorAntigo = IdRg;

            // Razão Social
            _LogRazaoSocial = new ChangeItem();
            _LogRazaoSocial.IdChangeHeader = _ChangesHeader.Id;
            _LogRazaoSocial.IdItem = 3;
            _LogRazaoSocial.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogRazaoSocial.NomeCampo = DboRgRegistroGeral.NomeRazaoSocial;
            _LogRazaoSocial.ValorAntigo = RazaoSocial;

            // Usuário
            _LogUsuario = new ChangeItem();
            _LogUsuario.IdChangeHeader = _ChangesHeader.Id;
            _LogUsuario.IdItem = 4;
            _LogUsuario.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogUsuario.NomeCampo = DboRgRegistroGeral.NomeUsuario;
            _LogUsuario.ValorAntigo = Usuario;

            // Tipo Rg
            _LogTipoRg = new ChangeItem();
            _LogTipoRg.IdChangeHeader = _ChangesHeader.Id;
            _LogTipoRg.IdItem = 5;
            _LogTipoRg.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogTipoRg.NomeCampo = DboRgRegistroGeral.NomeTipoRg;
            _LogTipoRg.ValorAntigo = TipoRg;

            // Cod Status
            _LogIdStatus = new ChangeItem();
            _LogIdStatus.IdChangeHeader = _ChangesHeader.Id;
            _LogIdStatus.IdItem = 6;
            _LogIdStatus.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogIdStatus.NomeCampo = DboRgRegistroGeral.NomeIdStatus;
            _LogIdStatus.ValorAntigo = IdStatus;

            // Data Hora
            _LogDataHora = new ChangeItem();
            _LogDataHora.IdChangeHeader = _ChangesHeader.Id;
            _LogDataHora.IdItem = 7;
            _LogDataHora.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogDataHora.NomeCampo = DboRgRegistroGeral.NomeDataHora;
            _LogDataHora.ValorAntigo = DataHora;

            // Nome Fantazia
            _LogNomeFantazia = new ChangeItem();
            _LogNomeFantazia.IdChangeHeader = _ChangesHeader.Id;
            _LogNomeFantazia.IdItem = 8;
            _LogNomeFantazia.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogNomeFantazia.NomeCampo = DboRgRegistroGeral.NomeNomeFantasia;
            _LogNomeFantazia.ValorAntigo = NomeFantazia;

            // Opitante Simples
            _LogOpitanteSimples = new ChangeItem();
            _LogOpitanteSimples.IdChangeHeader = _ChangesHeader.Id;
            _LogOpitanteSimples.IdItem = 9;
            _LogOpitanteSimples.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogOpitanteSimples.NomeCampo = DboRgRegistroGeral.NomeOptanteSimples;
            _LogOpitanteSimples.ValorAntigo = OpitanteSimples;

            #endregion
        }

        private void FillLogHeaderFromAddModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboRgRegistroGeral.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.IdRg;
            _ChangesHeader.TipoModificacao = OverallRecordProcess.CreateInstance.FromToModificaParametroGerenciador(ModificaRegistroGeralType.RegistroGeralAdicionar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            // Codigo Empresa
            _LogIdEmpresa = new ChangeItem();
            _LogIdEmpresa.IdChangeHeader = _ChangesHeader.Id;
            _LogIdEmpresa.IdItem = 1;
            _LogIdEmpresa.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogIdEmpresa.NomeCampo = DboRgRegistroGeral.NomeIdEmpresa;
            //_LogIdEmpresa.ValorAntigo = IdEmpr;

            // Codigo Rg
            _LogIdRg = new ChangeItem();
            _LogIdRg.IdChangeHeader = _ChangesHeader.Id;
            _LogIdRg.IdItem = 2;
            _LogIdRg.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogIdRg.NomeCampo = DboRgRegistroGeral.NomeIdRg;
            //_LogIdRg.ValorAntigo = IdRg;

            // Razão Social
            _LogRazaoSocial = new ChangeItem();
            _LogRazaoSocial.IdChangeHeader = _ChangesHeader.Id;
            _LogRazaoSocial.IdItem = 3;
            _LogRazaoSocial.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogRazaoSocial.NomeCampo = DboRgRegistroGeral.NomeRazaoSocial;
            //_LogRazaoSocial.ValorAntigo = RazaoSocial;

            // Usuário
            _LogUsuario = new ChangeItem();
            _LogUsuario.IdChangeHeader = _ChangesHeader.Id;
            _LogUsuario.IdItem = 4;
            _LogUsuario.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogUsuario.NomeCampo = DboRgRegistroGeral.NomeUsuario;
            //_LogUsuario.ValorAntigo = Usuario;

            // Tipo Rg
            _LogTipoRg = new ChangeItem();
            _LogTipoRg.IdChangeHeader = _ChangesHeader.Id;
            _LogTipoRg.IdItem = 5;
            _LogTipoRg.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogTipoRg.NomeCampo = DboRgRegistroGeral.NomeTipoRg;
            //_LogTipoRg.ValorAntigo = TipoRg;

            // Cod Status
            _LogIdStatus = new ChangeItem();
            _LogIdStatus.IdChangeHeader = _ChangesHeader.Id;
            _LogIdStatus.IdItem = 6;
            _LogIdStatus.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogIdStatus.NomeCampo = DboRgRegistroGeral.NomeIdStatus;
            _LogIdStatus.ValorAntigo = IdStatus;

            // Data Hora
            _LogDataHora = new ChangeItem();
            _LogDataHora.IdChangeHeader = _ChangesHeader.Id;
            _LogDataHora.IdItem = 7;
            _LogDataHora.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogDataHora.NomeCampo = DboRgRegistroGeral.NomeDataHora;
            //_LogDataHora.ValorAntigo = DataHora;
            
            // Nome Fantazia
            _LogNomeFantazia = new ChangeItem();
            _LogNomeFantazia.IdChangeHeader = _ChangesHeader.Id;
            _LogNomeFantazia.IdItem = 8;
            _LogNomeFantazia.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogNomeFantazia.NomeCampo = DboRgRegistroGeral.NomeNomeFantasia;
            //_LogNomeFantazia.ValorAntigo = NomeFantazia;

            // Opitante Simples
            _LogOpitanteSimples = new ChangeItem();
            _LogOpitanteSimples.IdChangeHeader = _ChangesHeader.Id;
            _LogOpitanteSimples.IdItem = 9;
            _LogOpitanteSimples.NomeTabela = DboRgRegistroGeral.NomeTabela;
            _LogOpitanteSimples.NomeCampo = DboRgRegistroGeral.NomeOptanteSimples;
            //_LogOpitanteSimples.ValorAntigo = OpitanteSimples;

            #endregion
        }

       

        private void UpdateFormRegistroGeral_Load(object sender, EventArgs e)
        {
            this.lblActionModuleTitle.Text = TextoDoTilutoDoFormulario;

            switch (ModificaRegistroGeralType)
            {
                case ModificaRegistroGeralType.RegistroGeralAdicionar:
                    FillLogHeaderFromAddModify();
                    FillDataParametersToExecuteAddModify();
                    break;
                case ModificaRegistroGeralType.RegistroGeralAlterar:
                    FillLogHeaderFromUpdateModify();
                    FillDataParametersToExecuteUpdateModify();
                    break;
            }
        }

        private void FillDataParametersToExecuteUpdateModify()
        {
            if ((_RgMunicipioCollection == null) || (_RgTipoRgCollection == null) || (_RgStatusCollection == null))
            {
                _RgMunicipioCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgMunicipio();
                _RgTipoRgCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgTipoRg();
                _RgStatusCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgStatus();
            }

            #region ...::: Campos Dados Gerais :::...

            txtCodRg.Text = AppStateOverallRecord.RgRegGeral.IdRg.ToString();
            txtBxRazaoSocial.Text = AppStateOverallRecord.RgRegGeral.RazaoSocial;
            txtUsusarioRg.Text = AppStateOverallRecord.RgRegGeral.Usuario;
            txtBxNomeFantasia.Text = AppStateOverallRecord.RgRegGeral.NomeFantasia;
            txtEmpresaVinculada.Text = AppStateOverallRecord.RgRegGeral.IdEmpr.ToString();
            txtBxDtHrRgGeral.Text = AppStateOverallRecord.RgRegGeral.DataHora != DateTime.Parse("01/01/0001 00:00:00") ? AppStateOverallRecord.RgRegGeral.DataHora.ToString() : "01/01/0001 00:00:00";
            chckBxAtivoInativo.Checked = (AppStateOverallRecord.RgRegGeral.OptanteSimples == "S" ? true : false);

            #endregion

            #region ...::: Campos Dados de Localização :::...

            txtBxEndereco.Text = AppStateOverallRecord.RgEndereco.Endereco;
            txtBxNro.Text = AppStateOverallRecord.RgEndereco.Nro;
            txtBxBairro.Text = AppStateOverallRecord.RgEndereco.Bairro;
            txtBxComplemento.Text = AppStateOverallRecord.RgEndereco.Complemento;
            txtBxCEP.Text = AppStateOverallRecord.RgEndereco.CEP != 0 ? AppStateOverallRecord.RgEndereco.CEP.ToString() : string.Empty;
            txtBxCxPostal.Text = AppStateOverallRecord.RgEndereco.CxPostal != 0 ? AppStateOverallRecord.RgEndereco.CxPostal.ToString() : string.Empty;
            txtBxEmail.Text = AppStateOverallRecord.RgEndereco.EMail;
            txtBxHomePage.Text = AppStateOverallRecord.RgEndereco.HomePage;

            #endregion

            #region ...::: Campos Dados de Contatos :::...

            FillDataGridContatos(AppStateOverallRecord.RgTelefoneCollection);

            #endregion

            #region ...::: Campos Dados de Natureza de Operações :::...

            FillDataGridNatureza(AppStateOverallRecord.RgRegGeralNaturezaCollection);

            #endregion

            #region ...::: Campos Dados de Pessoas Físicas \ Jurídicas :::...

            txtRG.Text = AppStateOverallRecord.RgFisicasJuridica.IdRg.ToString();
            txtCPFDigito.Text = AppStateOverallRecord.RgFisicasJuridica.DigCPF != 0 ? AppStateOverallRecord.RgFisicasJuridica.DigCPF.ToString() : string.Empty;
            txtInscrMunicipal.Text = AppStateOverallRecord.RgFisicasJuridica.InscrMunicipal;
            txtCEI.Text = AppStateOverallRecord.RgFisicasJuridica.CEI;
            txtCPF.Text = AppStateOverallRecord.RgFisicasJuridica.NroCPF != 0 ? AppStateOverallRecord.RgFisicasJuridica.NroCPF.ToString() : string.Empty;
            txtRGDigito.Text = AppStateOverallRecord.RgFisicasJuridica.DigRg;
            mskdEdtDtEmissao.Text = AppStateOverallRecord.RgFisicasJuridica.DtEmissao != DateTime.Parse("01/01/0001 00:00:00") ? AppStateOverallRecord.RgFisicasJuridica.DtEmissao.ToString() : "01/01/0001 00:00:00";
            txtOrgaoExpeditor.Text = AppStateOverallRecord.RgFisicasJuridica.OrgaoExpRg;
            txtCNPJ.Text = AppStateOverallRecord.RgFisicasJuridica.CGC != 0 ? AppStateOverallRecord.RgFisicasJuridica.CGC.ToString() : string.Empty;
            txtBarraCNPJ.Text = AppStateOverallRecord.RgFisicasJuridica.FilialCGC != 0 ? AppStateOverallRecord.RgFisicasJuridica.FilialCGC.ToString() : string.Empty;
            txtIfemCNPJ.Text = AppStateOverallRecord.RgFisicasJuridica.DigCGC != 0 ? AppStateOverallRecord.RgFisicasJuridica.DigCGC.ToString() : string.Empty;
            txtInscEst.Text = AppStateOverallRecord.RgFisicasJuridica.InscEstadual;
            txtInscMunipJuridica.Text = string.Empty;
            txtCEIJuridica.Text = string.Empty;

            #endregion

            cmBxCidade.DataSource = _RgMunicipioCollection;
            cmBxCidade.ValueMember = "IdMunicipio";
            cmBxCidade.DisplayMember = "Municipio";
            cmBxCidade.SelectedValue = AppStateOverallRecord.RgEndereco.IdMunicipio;

            cmBxRgTipoRg.DataSource = _RgTipoRgCollection;
            cmBxRgTipoRg.ValueMember = "TipoRg";
            cmBxRgTipoRg.DisplayMember = "DescrTipo";
            cmBxRgTipoRg.SelectedValue = AppStateOverallRecord.RgRegGeral.TipoRg;

            cmBxRgStatus.DataSource = _RgStatusCollection;
            cmBxRgStatus.ValueMember = "IdRgStatus";
            cmBxRgStatus.DisplayMember = "DescrStatus";
            cmBxRgStatus.SelectedValue = AppStateOverallRecord.RgRegGeral.IdStatus;
        }

        private void FillDataGridContatos(List<RgTelefone> _RgTelefoneCollection)
        {
            if (dtGrdVwDadosContatos.DataSource == null)
            {
                dtGrdVwDadosContatos.DataSource = _RgTelefoneCollection;
                dtGrdVwDadosContatos.ReadOnly = true;

                dtGrdVwDadosContatos.Columns["IdEmpr"].HeaderText = "ID Empresa";
                dtGrdVwDadosContatos.Columns["IdEmpr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtGrdVwDadosContatos.Columns["IdRg"].HeaderText = "ID Registro";
                dtGrdVwDadosContatos.Columns["IdRg"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtGrdVwDadosContatos.Columns["SeqTel"].HeaderText = "Sequência";
                dtGrdVwDadosContatos.Columns["SeqTel"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtGrdVwDadosContatos.Columns["IdTipoFone"].HeaderText = "Tipo Telefone";
                dtGrdVwDadosContatos.Columns["IdTipoFone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtGrdVwDadosContatos.Columns["DDDFone"].HeaderText = "DDD";
                dtGrdVwDadosContatos.Columns["DDDFone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtGrdVwDadosContatos.Columns["NroFone"].HeaderText = "Nro Fone";
                dtGrdVwDadosContatos.Columns["NroFone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtGrdVwDadosContatos.Columns["Contato"].HeaderText = "Contato";
                dtGrdVwDadosContatos.Columns["Contato"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtGrdVwDadosContatos.Columns["EMail"].HeaderText = "E-Mail";
                dtGrdVwDadosContatos.Columns["EMail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtGrdVwDadosContatos.Columns["Principal"].HeaderText = "Principal";
                dtGrdVwDadosContatos.Columns["Principal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void FillDataGridNatureza(List<RgRegGeralNatureza> _RgRegGeralNaturezaCollection)
        {
            if (dtGrdVwDadosOperacoes.DataSource == null)
            {
                dtGrdVwDadosOperacoes.DataSource = _RgRegGeralNaturezaCollection;
                dtGrdVwDadosOperacoes.ReadOnly = true;

                dtGrdVwDadosOperacoes.Columns["IdEmpr"].HeaderText = "ID Empresa";
                dtGrdVwDadosOperacoes.Columns["IdEmpr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dtGrdVwDadosOperacoes.Columns["IdEmpr"].Width = 150;

                dtGrdVwDadosOperacoes.Columns["IdRg"].HeaderText = "ID Registro";
                dtGrdVwDadosOperacoes.Columns["IdRg"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dtGrdVwDadosOperacoes.Columns["IdRg"].Width = 150;

                dtGrdVwDadosOperacoes.Columns["IdNatureza"].HeaderText = "ID Natureza";
                dtGrdVwDadosOperacoes.Columns["IdNatureza"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dtGrdVwDadosOperacoes.Columns["IdNatureza"].Width = 150;

                dtGrdVwDadosOperacoes.Columns["IdStatusNat"].HeaderText = "Status Registro";
                dtGrdVwDadosOperacoes.Columns["IdStatusNat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dtGrdVwDadosOperacoes.Columns["IdStatusNat"].Width = 150;

                dtGrdVwDadosOperacoes.Columns["DataHora"].HeaderText = "Data / Hora";
                dtGrdVwDadosOperacoes.Columns["DataHora"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dtGrdVwDadosOperacoes.Columns["DataHora"].Width = 150;

                dtGrdVwDadosOperacoes.Columns["Usuario"].HeaderText = "Usuário";
                dtGrdVwDadosOperacoes.Columns["Usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dtGrdVwDadosOperacoes.Columns["Usuario"].Width = 150;
            }
        }

        private void FillDataParametersToExecuteAddModify()
        {
            if ((_RgMunicipioCollection == null) || (_RgTipoRgCollection == null) || (_RgStatusCollection == null))
            {
                _RgMunicipioCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgMunicipio();
                _RgTipoRgCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgTipoRg();
                _RgStatusCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgStatus();
            }

            #region ...::: Campos Dados Gerais :::...

            txtCodRg.Text = string.Empty;
            txtUsusarioRg.Text = UsuarioLogin;
            txtEmpresaVinculada.Text = IdEmpr > 0 ? Convert.ToString(IdEmpr) : string.Empty;
            txtBxDtHrRgGeral.Text = DateTime.Now.ToString();

            #endregion

            cmBxCidade.DataSource = _RgMunicipioCollection;
            cmBxCidade.ValueMember = "IdMunicipio";
            cmBxCidade.DisplayMember = "Municipio";

            cmBxRgTipoRg.DataSource = _RgTipoRgCollection;
            cmBxRgTipoRg.ValueMember = "TipoRg";
            cmBxRgTipoRg.DisplayMember = "DescrTipo";

            cmBxRgStatus.DataSource = _RgStatusCollection;
            cmBxRgStatus.ValueMember = "IdRgStatus";
            cmBxRgStatus.DisplayMember = "DescrStatus";
        }

        private void tlStrpBtnAddContato_Click(object sender, EventArgs e)
        {
            AdicionaContato();
        }

        private void tlStrpBtnEditlContato_Click(object sender, EventArgs e)
        {
            AlteraContato();
        }

        private void tlStrpBtnViewContato_Click(object sender, EventArgs e)
        {
            VisualizaContato();
        }

        private void tlStrpBtnAddCategoria_Click(object sender, EventArgs e)
        {
            AdicionaNatureza();
        }

        private void tlStrpBtnEditCategoria_Click(object sender, EventArgs e)
        {
            AlteraNatureza();
        }

        private void tlStrpBtnViewlCategoria_Click(object sender, EventArgs e)
        {
            VisualizaNatureza();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlStrpBtnDelContato_Click(object sender, EventArgs e)
        {
            ExcluiContato();
        }

        private void ExcluiContato()
        {
            int _IdEmpr = 0;
            int _IdRg = 0;
            int _SeqTel = 0;

            List<RgTelefone> _RgTelefoneCollectionModifyProcess = dtGrdVwDadosContatos.DataSource as List<RgTelefone>;

            if (_RgTelefoneCollectionModifyProcess != null)
            {
                if ((Convert.ToInt32(dtGrdVwDadosContatos.CurrentRow.Cells["IdEmpr"].Value) > 0) && (Convert.ToInt32(dtGrdVwDadosContatos.CurrentRow.Cells["IdRg"].Value) > 0))
                {
                    _IdEmpr = Convert.ToInt32(dtGrdVwDadosContatos.CurrentRow.Cells["IdEmpr"].Value) > 0 ? Convert.ToInt32(dtGrdVwDadosContatos.CurrentRow.Cells["IdEmpr"].Value) : 0;
                    _IdRg = Convert.ToInt32(dtGrdVwDadosContatos.CurrentRow.Cells["IdRg"].Value) > 0 ? Convert.ToInt32(dtGrdVwDadosContatos.CurrentRow.Cells["IdRg"].Value) : 0;
                    _SeqTel = Convert.ToInt32(dtGrdVwDadosContatos.CurrentRow.Cells["SeqTel"].Value) > 0 ? Convert.ToInt32(dtGrdVwDadosContatos.CurrentRow.Cells["SeqTel"].Value) : 0;

                    if (MessageBox.Show("Desenja excluir este registro de contatos?", "Excluir Registro de Contatos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        for (int i = 0; i < _RgTelefoneCollectionModifyProcess.Count; i++)
                        {
                            if ((_RgTelefoneCollectionModifyProcess[i].IdEmpr == _IdEmpr) && (_RgTelefoneCollectionModifyProcess[i].IdRg == _IdRg) && (_RgTelefoneCollectionModifyProcess[i].SeqTel == _SeqTel))
                            {
                                _RgTelefoneCollectionModifyProcess.RemoveAt(i);
                                break;
                            }
                        }

                        dtGrdVwDadosContatos.DataSource = null;
                        _RgTelefoneCollectionModifyProcess.OrderBy(x => x.SeqTel);
                        FillDataGridContatos(_RgTelefoneCollectionModifyProcess);
                    }
                }
            }
        }

        private void tlStrpBtnDelCategoria_Click(object sender, EventArgs e)
        {
            ExcluiRegistroGeralNatureza();
        }

        private void ExcluiRegistroGeralNatureza()
        {
            int _IdEmpr = 0;
            int _IdRg = 0;
            int _IdNatureza = 0;

            List<RgRegGeralNatureza> _RgRegGeralNaturezaCollectionModifyProcess = dtGrdVwDadosOperacoes.DataSource as List<RgRegGeralNatureza>;

            if (_RgRegGeralNaturezaCollectionModifyProcess != null)
            {
                if ((Convert.ToInt32(dtGrdVwDadosOperacoes.CurrentRow.Cells["IdEmpr"].Value) > 0) && (Convert.ToInt32(dtGrdVwDadosOperacoes.CurrentRow.Cells["IdRg"].Value) > 0))
                {
                    _IdEmpr = Convert.ToInt32(dtGrdVwDadosOperacoes.CurrentRow.Cells["IdEmpr"].Value) > 0 ? Convert.ToInt32(dtGrdVwDadosOperacoes.CurrentRow.Cells["IdEmpr"].Value) : 0;
                    _IdRg = Convert.ToInt32(dtGrdVwDadosOperacoes.CurrentRow.Cells["IdRg"].Value) > 0 ? Convert.ToInt32(dtGrdVwDadosOperacoes.CurrentRow.Cells["IdRg"].Value) : 0;
                    _IdNatureza = Convert.ToInt32(dtGrdVwDadosOperacoes.CurrentRow.Cells["IdNatureza"].Value) > 0 ? Convert.ToInt32(dtGrdVwDadosOperacoes.CurrentRow.Cells["IdNatureza"].Value) : 0;

                    if (MessageBox.Show("Desenja excluir este registro de natureza geral?", "Excluir Registro Natureza Geral", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        for (int i = 0; i < _RgRegGeralNaturezaCollectionModifyProcess.Count; i++)
                        {
                            if ((_RgRegGeralNaturezaCollectionModifyProcess[i].IdEmpr == _IdEmpr) && (_RgRegGeralNaturezaCollectionModifyProcess[i].IdRg == _IdRg) && (_RgRegGeralNaturezaCollectionModifyProcess[i].IdNatureza == _IdNatureza))
                            {
                                _RgRegGeralNaturezaCollectionModifyProcess.RemoveAt(i);
                                break;
                            }
                        }

                        dtGrdVwDadosOperacoes.DataSource = null;
                        _RgRegGeralNaturezaCollectionModifyProcess.OrderBy(x => x.IdNatureza);
                        FillDataGridNatureza(_RgRegGeralNaturezaCollectionModifyProcess);
                    }
                }
            }
        }


        // ...::: INICIO VALIDAÇÕES :::...
        private void txtBxRazaoSocial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxRazaoSocial.Text == string.Empty)
            {
                ErrPrvdrRegistroGeral.SetError(txtBxRazaoSocial, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrRegistroGeral.SetError(txtBxRazaoSocial, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxEndereco_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxEndereco.Text == string.Empty)
            {
                ErrPrvdrRegistroGeral.SetError(txtBxEndereco, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrRegistroGeral.SetError(txtBxEndereco, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxNro_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxNro.Text == string.Empty)
            {
                ErrPrvdrRegistroGeral.SetError(txtBxNro, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrRegistroGeral.SetError(txtBxNro, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaAceiteSomenteNumeros(txtBxNro.Text))
                {
                    ErrPrvdrRegistroGeral.SetError(txtBxNro, ValidationsMessages.VALIDA_NUMERO);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrRegistroGeral.SetError(txtBxNro, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxBairro_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxBairro.Text == string.Empty)
            {
                ErrPrvdrRegistroGeral.SetError(txtBxBairro, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrRegistroGeral.SetError(txtBxBairro, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxCEP_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxCEP.Text == string.Empty)
            {
                ErrPrvdrRegistroGeral.SetError(txtBxCEP, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrRegistroGeral.SetError(txtBxCEP, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaCEP(txtBxCEP.Text))
                {
                    ErrPrvdrRegistroGeral.SetError(txtBxCEP, ValidationsMessages.VALIDA_CEP);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrRegistroGeral.SetError(txtBxCEP, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxCxPostal_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxCxPostal.Text == string.Empty)
            {
                ErrPrvdrRegistroGeral.SetError(txtBxCxPostal, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrRegistroGeral.SetError(txtBxCxPostal, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaNroCaixaPostal(txtBxCxPostal.Text))
                {
                    ErrPrvdrRegistroGeral.SetError(txtBxCxPostal, ValidationsMessages.VALIDA_CX_POSTAL);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrRegistroGeral.SetError(txtBxCxPostal, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
                if (!ValidationData.CreateInstance.ValidaEMail(txtBxEmail.Text))
                {
                    ErrPrvdrRegistroGeral.SetError(txtBxEmail, ValidationsMessages.VALIDA_EMAIL);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrRegistroGeral.SetError(txtBxEmail, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
         }


        private void txtBxRazaoSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
        ErrPrvdrRegistroGeral.SetError(txtBxRazaoSocial, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxEndereco_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrRegistroGeral.SetError(txtBxEndereco, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxNro_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrRegistroGeral.SetError(txtBxNro, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxBairro_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrRegistroGeral.SetError(txtBxBairro, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxCEP_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrRegistroGeral.SetError(txtBxCEP, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxCxPostal_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrRegistroGeral.SetError(txtBxCxPostal, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
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
