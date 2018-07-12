using BrSoftNet.App.Business.Processes.Manager.Enumerators;
using BrSoftNet.App.Business.Processes.Manager.Entities;
using BrSoftNet.App.Business.Processes.Manager.Tasks;
using BrSoftNet.App.UI.Win.Manager.State;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System;
using BrSoftNet.Library.Messages;
using BrSoftNet.Library.Utilities;


namespace BrSoftNet.App.UI.Win.Manager.DialogUpdateForm
{
    public partial class UpdateFormTipoProcesso : Form
    {
        #region . ..::: Variaveis :::...
        private string _TipoModificacao = string.Empty;
        private int _IdExecute = 0;
        private GeTipoProcesso _GeTipoProcesso = null;
        private List<GeTipoProcesso> _GeTipoProcessoCollection = null;
        #endregion  

        #region ...::: Public Properties :::...

        public int IdEmpr { get; set; }
        public string UsuarioLogin { get; set; }
        public int CodigoTipoProcesso { get; set; }
        public string DescricaoTipoProcesso { get; set; }
        public int SequenciaTipoProcesso { get; set; }
        public ModificaTipoProcessoType ModificaTipoProcessoType { get; set; }
        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        public UpdateFormTipoProcesso()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();

            this.txtBxDecricaoProcesso.GotFocus += txtBxDecricaoProcesso_GotFocus;
            this.txtBxDecricaoProcesso.LostFocus += txtBxDecricaoProcesso_LostFocus;

            this.txtBxSequenciaProcesso.GotFocus += txtBxSequenciaProcesso_GotFocus;
            this.txtBxSequenciaProcesso.LostFocus += txtBxSequenciaProcesso_LostFocus;
        }

        private void txtBxSequenciaProcesso_LostFocus(object sender, EventArgs e)
        {
            this.txtBxSequenciaProcesso.BackColor = Color.White;
        }

        private void txtBxSequenciaProcesso_GotFocus(object sender, EventArgs e)
        {
            this.txtBxSequenciaProcesso.BackColor = Color.LightYellow;
        }

        private void txtBxDecricaoProcesso_LostFocus(object sender, EventArgs e)
        {
            this.txtBxDecricaoProcesso.BackColor = Color.White;
        }

        private void txtBxDecricaoProcesso_GotFocus(object sender, EventArgs e)
        {
            this.txtBxDecricaoProcesso.BackColor = Color.LightYellow;
        }
       
        private void InicialiazeUpdateForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void ExecuteModifyTipoProcesso()
        {
            switch (ModificaTipoProcessoType)
            {
                case ModificaTipoProcessoType.TipoProcessoAdicionar:
                    ExecuteAddTipoProcesso();
                    break;
                case ModificaTipoProcessoType.TipoProcessoAlterar:
                    ExecuteUpdateTipoProcesso();
                    break;
            }
        }

        private void ExecuteUpdateTipoProcesso()
        {
            _TipoModificacao = TipoProcessoProcess.CreateInstance.FromToModificaTipoProcesso(ModificaTipoProcessoType.TipoProcessoAlterar);

            try
            {
                _IdExecute = TipoProcessoProcess.CreateInstance.TaskModifyTypeProcessTypeProcess(int.Parse(txtBxCodTipoProcesso.Text), txtBxDecricaoProcesso.Text, int.Parse(txtBxSequenciaProcesso.Text), _TipoModificacao);

            }
            catch (Exception _Exception)
            {
                throw _Exception;
            }
          
        }
        private void ExecuteAddTipoProcesso()
        {
            _TipoModificacao = TipoProcessoProcess.CreateInstance.FromToModificaTipoProcesso(ModificaTipoProcessoType.TipoProcessoAdicionar);

            try
            {
                _IdExecute = TipoProcessoProcess.CreateInstance.TaskModifyTypeProcessTypeProcess(0, txtBxDecricaoProcesso.Text, int.Parse(txtBxSequenciaProcesso.Text), _TipoModificacao);
            }
            catch (Exception _Exception)
            {
                throw _Exception;
            } 
        }

        private void FillDataParametersToExecuteUpdateModify()
        {
            txtBxCodTipoProcesso.Text = CodigoTipoProcesso.ToString();
            txtBxDecricaoProcesso.Text = DescricaoTipoProcesso;
            txtBxSequenciaProcesso.Text = SequenciaTipoProcesso.ToString();
        }
        private void FillDataParametersToExecuteAddModify()
        {
            //txtBxCodTipoProcesso.Text = CodigoTipoProcesso.ToString();
            //txtBxDecricaoProcesso.Text = DescricaoTipoProcesso;
            //txtBxSequenciaProcesso.Text = SequenciaTipoProcesso.ToString();
        }

        private void UpdateFormTipoProcesso_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;

            if (ModificaTipoProcessoType == ModificaTipoProcessoType.TipoProcessoAlterar)
            {
               FillDataParametersToExecuteUpdateModify();  
            }

            if (ModificaTipoProcessoType == ModificaTipoProcessoType.TipoProcessoAdicionar)
            {
                FillDataParametersToExecuteAddModify();
            }
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, EventArgs e)
        {
            if (txtBxDecricaoProcesso.Text == string.Empty)
            {
                ErrPrvdrTipoProcesso.SetError(txtBxDecricaoProcesso, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxDecricaoProcesso.Focus();
                return;
            }

            if (txtBxSequenciaProcesso.Text == string.Empty)
            {
                ErrPrvdrTipoProcesso.SetError(txtBxSequenciaProcesso, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtBxSequenciaProcesso.Focus();
                return;
            }
            ExecuteModifyTipoProcesso();
            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBxDecricaoProcesso_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
             if (txtBxDecricaoProcesso.Text == string.Empty)
            {
                ErrPrvdrTipoProcesso.SetError(txtBxDecricaoProcesso, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrTipoProcesso.SetError(txtBxDecricaoProcesso, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtBxSequenciaProcesso_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtBxSequenciaProcesso.Text == string.Empty)
            {
                ErrPrvdrTipoProcesso.SetError(txtBxSequenciaProcesso, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrTipoProcesso.SetError(txtBxSequenciaProcesso, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;

                if (!ValidationData.CreateInstance.ValidaAceiteSomenteNumeros(txtBxSequenciaProcesso.Text))
                {
                    ErrPrvdrTipoProcesso.SetError(txtBxSequenciaProcesso, ValidationsMessages.VALIDA_NUMERO);
                    tlstrpActionMenuBtnConfirm.Enabled = false;
                }
                else
                {
                    ErrPrvdrTipoProcesso.SetError(txtBxSequenciaProcesso, string.Empty);
                    tlstrpActionMenuBtnConfirm.Enabled = true;
                }
            }
        }

        private void txtBxDecricaoProcesso_KeyPress(object sender, KeyPressEventArgs e)
        {

            ErrPrvdrTipoProcesso.SetError(txtBxDecricaoProcesso, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtBxSequenciaProcesso_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrTipoProcesso.SetError(txtBxSequenciaProcesso, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }
    }
}
