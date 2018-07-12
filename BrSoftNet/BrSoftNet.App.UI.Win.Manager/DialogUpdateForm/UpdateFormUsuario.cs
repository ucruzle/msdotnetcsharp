using BrSoftNet.App.Business.Processes.Manager.Entities;
using BrSoftNet.App.Business.Processes.Manager.Enumerators;
using BrSoftNet.App.Business.Processes.Manager.Tasks;
using BrSoftNet.App.UI.Win.Manager.State;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BrSoftNet.Library.Utilities;
using BrSoftNet.Library.Messages;

namespace BrSoftNet.App.UI.Win.Manager.DialogUpdateForm
{
    public partial class UpdateFormUsuario : Form
    {
        #region ...::: Private Variable :::...

        private string _TipoModificacao = string.Empty;

        private int _IdExecute = 0;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpr { get; set; }
        public int IdRg { get; set; }
        public string UsuarioLogin { get; set; }
        public ModificaUsuarioType ModificaUsuarioType { get; set; }
        public string Usuario { get; set; }
        public string Nome { get; set; }
        public int CodigoEmpresa { get; set; }
        public int CodigoRG { get; set; }
        public string StatusDBA { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Senha { get; set; }
        public string Ramal { get; set; }
        public string Ativo { get; set; }
        public string UsuarioIncl { get; set; }
        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Properties :::...
        private List<GeEmpresa> GeEmpresaCollection { get; set; }
        private List<IntegracaoRegGeral> IntegracaoRegGeralCollection { get; set; }
        #endregion

        #region ...::: Private Fields :::...

        private List<GeEmpresa> _GeEmpresaCollection = null;
        private List<IntegracaoRegGeral> _IntegracaoRegGeralCollection = null;
        private DataSet _DataSetEmpresaRegistroGeralPorVinculo = null;

        #endregion

        public UpdateFormUsuario()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();

            this.txtBxUsuario.GotFocus += txtBxUsuario_GotFocus;
            this.txtBxUsuario.LostFocus += txtBxUsuario_LostFocus;

            this.txtBxDataCadastro.GotFocus += txtBxDataCadastro_GotFocus;
            this.txtBxDataCadastro.LostFocus += txtBxDataCadastro_LostFocus;

            this.txtBxNome.GotFocus += txtBxNome_GotFocus;
            this.txtBxNome.LostFocus += txtBxNome_LostFocus;

            this.txtBxSenhaAtual.GotFocus += txtBxSenhaAtual_GotFocus;
            this.txtBxSenhaAtual.LostFocus += txtBxSenhaAtual_LostFocus;

            this.txtBxNovaSenha.GotFocus += txtBxNovaSenha_GotFocus;
            this.txtBxNovaSenha.LostFocus += txtBxNovaSenha_LostFocus;

            this.txtBxConfirmaSenha.GotFocus += txtBxConfirmaSenha_GotFocus;
            this.txtBxConfirmaSenha.LostFocus += txtBxConfirmaSenha_LostFocus;

            this.txtBxRamal.GotFocus += txtBxRamal_GotFocus;
            this.txtBxRamal.LostFocus += txtBxRamal_LostFocus;

            this.cmbBxEmpresaRegGeral.GotFocus += cmbBxEmpresaRegGeral_GotFocus;
            this.cmbBxEmpresaRegGeral.LostFocus += cmbBxEmpresaRegGeral_LostFocus;

            this.cmbBxRegGeral.GotFocus += cmbBxRegGeral_GotFocus;
            this.cmbBxRegGeral.LostFocus += cmbBxRegGeral_LostFocus;
        }

        private void cmbBxRegGeral_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxRegGeral.BackColor = Color.White;
        }

        private void cmbBxRegGeral_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxRegGeral.BackColor = Color.LightYellow;
        }

        void cmbBxEmpresaRegGeral_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxEmpresaRegGeral.BackColor = Color.White;
        }

        private void cmbBxEmpresaRegGeral_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxEmpresaRegGeral.BackColor = Color.LightYellow;
        }

        void txtBxUsuario_LostFocus(object sender, EventArgs e)
        {
            this.txtBxUsuario.BackColor = Color.White;
        }

        void txtBxUsuario_GotFocus(object sender, EventArgs e)
        {
            this.txtBxUsuario.BackColor = Color.LightYellow;
        }

        void txtBxDataCadastro_LostFocus(object sender, EventArgs e)
        {
            this.txtBxDataCadastro.BackColor = Color.White;
        }

        void txtBxDataCadastro_GotFocus(object sender, EventArgs e)
        {
            this.txtBxDataCadastro.BackColor = Color.LightYellow;
        }

        void txtBxNome_LostFocus(object sender, EventArgs e)
        {
            this.txtBxNome.BackColor = Color.White;
        }

        void txtBxNome_GotFocus(object sender, EventArgs e)
        {
            this.txtBxNome.BackColor = Color.LightYellow;
        }

        void txtBxSenhaAtual_LostFocus(object sender, EventArgs e)
        {
            this.txtBxSenhaAtual.BackColor = Color.White;
        }

        void txtBxSenhaAtual_GotFocus(object sender, EventArgs e)
        {
            this.txtBxSenhaAtual.BackColor = Color.LightYellow;
        }

        void txtBxNovaSenha_LostFocus(object sender, EventArgs e)
        {
            this.txtBxNovaSenha.BackColor = Color.White;
        }

        void txtBxNovaSenha_GotFocus(object sender, EventArgs e)
        {
            this.txtBxNovaSenha.BackColor = Color.LightYellow;
        }

        void txtBxConfirmaSenha_LostFocus(object sender, EventArgs e)
        {
            this.txtBxConfirmaSenha.BackColor = Color.White;
        }

        void txtBxConfirmaSenha_GotFocus(object sender, EventArgs e)
        {
            this.txtBxConfirmaSenha.BackColor = Color.LightYellow;
        }

        void txtBxRamal_LostFocus(object sender, EventArgs e)
        {
            this.txtBxRamal.BackColor = Color.White;
        }

        void txtBxRamal_GotFocus(object sender, EventArgs e)
        {
            this.txtBxRamal.BackColor = Color.LightYellow;
        }

        private void InicialiazeUpdateForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, EventArgs e)
        {
            if (txtBxNome.Text == string.Empty)
            {
                ErrPrvdrUsuario.SetError(txtBxNome, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxNome.Focus();
                return;
            }

            if (txtBxDataCadastro.Text == string.Empty)
            {
                ErrPrvdrUsuario.SetError(txtBxDataCadastro, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxDataCadastro.Focus();
                return;
            }

            if (txtBxUsuario.Text == string.Empty)
            {
                ErrPrvdrUsuario.SetError(txtBxUsuario, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxUsuario.Focus();
                return;
            }

            if (txtBxNovaSenha.Text == string.Empty)
            {
                ErrPrvdrUsuario.SetError(txtBxNovaSenha, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxNovaSenha.Focus();
                return;
            }

            if (txtBxConfirmaSenha.Text == string.Empty)
            {
                ErrPrvdrUsuario.SetError(txtBxConfirmaSenha, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxConfirmaSenha.Focus();
                return;
            }

            if (txtBxRamal.Text == string.Empty)
            {
                ErrPrvdrUsuario.SetError(txtBxRamal, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxRamal.Focus();
                return;
            }

            ExecuteModifyUsuario();
            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExecuteModifyUsuario()
        {
            switch (ModificaUsuarioType)
            {
                case ModificaUsuarioType.UsuarioAdicionar:
                    ExecuteAddUsuario();
                    break;
                case ModificaUsuarioType.UsuarioAlterar:
                    ExecuteUpdateUsuario();
                    break;
            }
        }

        private void ExecuteUpdateUsuario()
        {
            string _Usuario = txtBxUsuario.Text;
            string _Nome = txtBxNome.Text;
            int _CodigoEmpresa = 0;
            int _CodigoRG = 0;
            DateTime _DataCadastro = DateTime.Parse("01/01/0001 00:00:00");
            string _SenhaNova = txtBxNovaSenha.Text;
            string _SenhaConfirma = txtBxConfirmaSenha.Text;
            string _SenhaAtual = txtBxSenhaAtual.Text;
            string _Ramal = txtBxRamal.Text;
            string _TipoModificacao = string.Empty;

            _CodigoEmpresa = Convert.ToInt32(cmbBxEmpresaRegGeral.SelectedValue);
            _CodigoRG = Convert.ToInt32(cmbBxRegGeral.SelectedValue);
            _DataCadastro = Convert.ToDateTime(txtBxDataCadastro.Text);
            _TipoModificacao = UsuarioProcess.CreateInstance.FromToModificaUsuario(ModificaUsuarioType.UsuarioAlterar);

            Ativo = ckBxAtiva.Checked ? "S" : "N";
            StatusDBA = ckBxStatusDBA.Checked ? "S" : "N";

            try
            {
                if (_SenhaNova == _SenhaConfirma)
                {
                    List<GeUsuario> _GeUsuario = new List<GeUsuario>();

                    string _Filter = string.Format(" where usuario = '{0}' ", _Usuario);

                    _GeUsuario = UsuarioProcess.CreateInstance.TaskGetCollectionGeUsuarioByFilter(_Filter, 1);

                    if (_GeUsuario[0].Senha == _SenhaAtual)
                    {
                        _IdExecute = TrocaSenhaUsuarioProcess.CreateInstance.TaskModifyProcessTrocaSenhaUsuario(_Usuario, _SenhaNova, _TipoModificacao);
                    }
                }

                _IdExecute = UsuarioProcess.CreateInstance.TaskModifyProcessUsuario(_Usuario, _Nome, _CodigoEmpresa, _CodigoRG, StatusDBA, _DataCadastro, _SenhaNova, _Ramal, Ativo, string.Empty, _TipoModificacao);
            }
            catch (Exception _Exception)
            {
                throw _Exception;
            }
            finally
            {

            }
        }

        private void ExecuteAddUsuario()
        {
            string _Usuario = txtBxUsuario.Text;
            string _Nome = txtBxNome.Text;
            int _CodigoEmpresa = 0;
            int _CodigoRG = 0;
            DateTime _DataCadastro = DateTime.Parse("01/01/0001 00:00:00");
            string _Senha = txtBxNovaSenha.Text;
            string _Ramal = txtBxRamal.Text;
            string _TipoModificacao = string.Empty;

            _CodigoEmpresa = Convert.ToInt32(cmbBxEmpresaRegGeral.SelectedValue);
            _CodigoRG = Convert.ToInt32(cmbBxRegGeral.SelectedValue);
            _DataCadastro = Convert.ToDateTime(txtBxDataCadastro.Text);
            _TipoModificacao = UsuarioProcess.CreateInstance.FromToModificaUsuario(ModificaUsuarioType.UsuarioAdicionar);

            Ativo = ckBxAtiva.Checked ? "S" : "N";
            StatusDBA = ckBxStatusDBA.Checked ? "S" : "N";

            try
            {
                _IdExecute = UsuarioProcess.CreateInstance.TaskModifyProcessUsuario(_Usuario, _Nome, _CodigoEmpresa, _CodigoRG, StatusDBA, _DataCadastro, _Senha, _Ramal, Ativo, string.Empty, _TipoModificacao);
            }
            catch (Exception _Exception)
            {
                throw _Exception;
            }
            finally
            {

            }
        }

        private void UpdateFormUsuario_Load(object sender, System.EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;

            _DataSetEmpresaRegistroGeralPorVinculo = UsuarioProcess.CreateInstance.TaskGeCollectionGeRetornaEmpresaRegistroGeralPorVinculo();

            FillEmpresaCollection();
            FillIntegracaoCollection();
            

            switch (ModificaUsuarioType)
            {
                case ModificaUsuarioType.UsuarioAdicionar:
                    FillProcessoToAddModify();
                    break;
                case ModificaUsuarioType.UsuarioAlterar:
                    FillDataParametersToExecuteUpdateModify();
                    FillProcessoToUpdateModify(sender, e);
                    break;
                case ModificaUsuarioType.UsuarioExcluir:
                    break;
                default:
                    break;
            }

        }

        private void FillDataParametersToExecuteUpdateModify()
        {
            ckBxAtiva.Checked = (Ativo == "S" ? true : false);
            ckBxStatusDBA.Checked = (StatusDBA == "S" ? true : false);

            txtBxUsuario.Text = Usuario.ToString();
            txtBxNome.Text = Nome.ToString();
            cmbBxEmpresaRegGeral.SelectedValue = CodigoEmpresa.ToString();
            cmbBxRegGeral.SelectedValue = CodigoRG.ToString();
            txtBxDataCadastro.Text = DataCadastro.ToString();
            txtBxSenhaAtual.Text = "";
            txtBxNovaSenha.Text = "";
            txtBxConfirmaSenha.Text = "";
            txtBxRamal.Text = Ramal.ToString();
        }

        private void FillProcessoToUpdateModify(object sender, EventArgs e)
        {
            cmbBxEmpresaRegGeral.DataSource = GeEmpresaCollection;
            cmbBxEmpresaRegGeral.ValueMember = "CodigoEmpresa";
            cmbBxEmpresaRegGeral.DisplayMember = "DescricaoEmpresa";
            cmbBxEmpresaRegGeral.SelectedValue = this.CodigoEmpresa;

            cmbBxRegGeral.DataSource = IntegracaoRegGeralCollection;
            cmbBxRegGeral.ValueMember = "IdRg";
            cmbBxRegGeral.DisplayMember = "RazaoSocial";
            cmbBxRegGeral.SelectedValue = this.CodigoRG;

            txtBxSenhaAtual.Enabled = true;
            lblNovaSenha.Text = "Nova Senha:";

            AppStateManager.CodigoEmpresaRegGeralPorVinculo = Convert.ToInt32(cmbBxEmpresaRegGeral.SelectedValue);
            AppStateManager.CodigoIntegracaoRegGeralPorVinculo = Convert.ToInt32(cmbBxRegGeral.SelectedValue);
        }

        private void FillProcessoToAddModify()
        {
            cmbBxEmpresaRegGeral.DataSource = GeEmpresaCollection;
            cmbBxEmpresaRegGeral.ValueMember = "CodigoEmpresa";
            cmbBxEmpresaRegGeral.DisplayMember = "DescricaoEmpresa";

            cmbBxRegGeral.DataSource = IntegracaoRegGeralCollection;
            cmbBxRegGeral.ValueMember = "IdRg";
            cmbBxRegGeral.DisplayMember = "RazaoSocial";

            txtBxSenhaAtual.Enabled = false;
            lblNovaSenha.Text = "Senha:";
            Point pt = new Point(51, 146); //Ponteriro de nova localização de lbl.NovaSenha
            this.lblNovaSenha.Location = pt;

            AppStateManager.CodigoEmpresaRegGeralPorVinculo = Convert.ToInt32(cmbBxEmpresaRegGeral.SelectedValue);
            AppStateManager.CodigoIntegracaoRegGeralPorVinculo = Convert.ToInt32(cmbBxRegGeral.SelectedValue);
        }

        private void FillEmpresaCollection()
        {
            if (_GeEmpresaCollection == null)
            {
                _GeEmpresaCollection = new List<GeEmpresa>();
            }

            foreach (DataRow _Row in _DataSetEmpresaRegistroGeralPorVinculo.Tables[0].Rows)
            {
                _GeEmpresaCollection.Add(new GeEmpresa(_Row));
            }

            GeEmpresaCollection = _GeEmpresaCollection;
        }

        private void FillIntegracaoCollection()
        {
            if (_IntegracaoRegGeralCollection == null)
            {
                _IntegracaoRegGeralCollection = new List<IntegracaoRegGeral>();
            }

            foreach (DataRow _Row in _DataSetEmpresaRegistroGeralPorVinculo.Tables[1].Rows)
            {
                _IntegracaoRegGeralCollection.Add(new IntegracaoRegGeral(_Row));
            }

            IntegracaoRegGeralCollection = _IntegracaoRegGeralCollection;
        }

        // ...::: INICIO VALIDAÇÕES :::...
        private void txtBxUsuario_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxUsuario.Text == string.Empty)
            {
                ErrPrvdrUsuario.SetError(txtBxUsuario, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrUsuario.SetError(txtBxUsuario, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxDataCadastro_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxDataCadastro.Text == string.Empty)
            {
                ErrPrvdrUsuario.SetError(txtBxDataCadastro, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrUsuario.SetError(txtBxDataCadastro, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaData(txtBxDataCadastro.Text))
                {
                    ErrPrvdrUsuario.SetError(txtBxDataCadastro, ValidationsMessages.VALIDA_DATA);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrUsuario.SetError(txtBxDataCadastro, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxNome_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxNome.Text == string.Empty)
            {
                ErrPrvdrUsuario.SetError(txtBxNome, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrUsuario.SetError(txtBxNome, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaAceiteSomenteCaracteres(txtBxNome.Text))
                {
                    ErrPrvdrUsuario.SetError(txtBxNome, ValidationsMessages.VALIDA_NOME);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrUsuario.SetError(txtBxNome, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxSenhaAtual_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxSenhaAtual.Text == string.Empty)
            {
                ErrPrvdrUsuario.SetError(txtBxSenhaAtual, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrUsuario.SetError(txtBxSenhaAtual, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaSenha(txtBxSenhaAtual.Text))
                {
                    ErrPrvdrUsuario.SetError(txtBxSenhaAtual, ValidationsMessages.VALIDA_SENHA);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrUsuario.SetError(txtBxSenhaAtual, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxNovaSenha_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxNovaSenha.Text == string.Empty)
            {
                ErrPrvdrUsuario.SetError(txtBxNovaSenha, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrUsuario.SetError(txtBxNovaSenha, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaSenha(txtBxNovaSenha.Text))
                {
                    ErrPrvdrUsuario.SetError(txtBxNovaSenha, ValidationsMessages.VALIDA_SENHA);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrUsuario.SetError(txtBxNovaSenha, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxConfirmaSenha_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxConfirmaSenha.Text == string.Empty)
            {
                ErrPrvdrUsuario.SetError(txtBxConfirmaSenha, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrUsuario.SetError(txtBxConfirmaSenha, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaSenha(txtBxConfirmaSenha.Text))
                {
                    ErrPrvdrUsuario.SetError(txtBxConfirmaSenha, ValidationsMessages.VALIDA_SENHA);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrUsuario.SetError(txtBxConfirmaSenha, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxRamal_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxRamal.Text == string.Empty)
            {
                ErrPrvdrUsuario.SetError(txtBxRamal, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrUsuario.SetError(txtBxRamal, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaAceiteSomenteCaracteres(txtBxRamal.Text))
                {
                    ErrPrvdrUsuario.SetError(txtBxRamal, ValidationsMessages.VALIDA_NUMERO);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrUsuario.SetError(txtBxRamal, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrUsuario.SetError(txtBxUsuario, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxDataCadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrUsuario.SetError(txtBxDataCadastro, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrUsuario.SetError(txtBxNome, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxSenhaAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrUsuario.SetError(txtBxSenhaAtual, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false; 
        }

        private void txtBxNovaSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrUsuario.SetError(txtBxNovaSenha, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxConfirmaSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrUsuario.SetError(txtBxConfirmaSenha, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxRamal_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrUsuario.SetError(txtBxRamal, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

   }
}
