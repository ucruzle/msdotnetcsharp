using BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects;
using BrSoftNet.App.Business.Processes.OverallRecord.Enumerators;
using BrSoftNet.App.Business.Processes.OverallRecord.Tasks;
using BrSoftNet.App.UI.Win.OverallRecord.DataTransferProcess;
using BrSoftNet.App.UI.Win.OverallRecord.State;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BrSoftNet.Library.Messages;
using BrSoftNet.Library.Utilities;

namespace BrSoftNet.App.UI.Win.OverallRecord.DialogUpdateForm.UpdateFormRegistroGeralHelperScreen
{
    public partial class HelperFormRegistroGeralContato : Form
    {
        #region ...::: Private Variable :::...

        RgTelefone _RgTelefone = null;

        List<RgTipoFone> _RgTipoFoneCollection = null;

        dsOverallRecordProcess.tblRgTelefoneDataTable _TelefoneTable = null;

        dsOverallRecordProcess.tblRgTelefoneRow _TelefoneRow = null;

        #endregion

        #region ...::: Public Properties :::...
        public ModificaRegistroGeralType ModificaRegistroGeralType { get; set; }

        #endregion

        public HelperFormRegistroGeralContato()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();
        }

        private void InicialiazeUpdateForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.cmBxTipo.GotFocus += cmBxTipo_GotFocus;
            this.cmBxTipo.LostFocus += cmBxTipo_LostFocus;

            this.txtContato.GotFocus += txtContato_GotFocus;
            this.txtContato.LostFocus += txtContato_LostFocus;

            this.txtEMail.GotFocus += txtEMail_GotFocus;
            this.txtEMail.LostFocus += txtEMail_LostFocus;

            this.txtddd.GotFocus += txtddd_GotFocus;
            this.txtddd.LostFocus += txtddd_LostFocus;

            this.txtNro.GotFocus += txtNro_GotFocus;
            this.txtNro.LostFocus += txtNro_LostFocus;
        }

        void txtNro_LostFocus(object sender, System.EventArgs e)
        {
            this.txtNro.BackColor = Color.White;
        }

        void txtNro_GotFocus(object sender, System.EventArgs e)
        {
            this.txtNro.BackColor = Color.LightYellow;
        }

        void txtddd_LostFocus(object sender, System.EventArgs e)
        {
            this.txtddd.BackColor = Color.White;
        }

        void txtddd_GotFocus(object sender, System.EventArgs e)
        {
            this.txtddd.BackColor = Color.LightYellow;
        }

        void txtEMail_LostFocus(object sender, System.EventArgs e)
        {
            this.txtEMail.BackColor = Color.White;
        }

        void txtEMail_GotFocus(object sender, System.EventArgs e)
        {
            this.txtEMail.BackColor = Color.LightYellow;
        }

        void txtContato_LostFocus(object sender, System.EventArgs e)
        {
            this.txtContato.BackColor = Color.White;
        }

        void txtContato_GotFocus(object sender, System.EventArgs e)
        {
            this.txtContato.BackColor = Color.LightYellow;
        }

        void cmBxTipo_LostFocus(object sender, System.EventArgs e)
        {
            this.cmBxTipo.BackColor = Color.White;
        }

        void cmBxTipo_GotFocus(object sender, System.EventArgs e)
        {
            this.cmBxTipo.BackColor = Color.LightYellow;
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {
            if (txtddd.Text == string.Empty)
            {
                ErrPrvdrContato.SetError(txtddd, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtddd.Focus();
                return;
            }

            if (txtNro.Text == string.Empty)
            {
                ErrPrvdrContato.SetError(txtNro, ValidationsMessages.VALIDA_CAMPO_VAZIO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblError.Visible = true;
                txtNro.Focus();
                return;
            }

            ExecuteModifyContato();
            this.Close();
        }

        private void ExecuteModifyContato()
        {
            switch (ModificaRegistroGeralType)
            {
                case ModificaRegistroGeralType.RegistroGeralAdicionar:
                    ExecuteAddContato();
                    break;
                case ModificaRegistroGeralType.RegistroGeralAlterar:
                    ExecuteUpdateContatos();
                    break;
            }
        }

        private void ExecuteAddContato() 
        {
            _TelefoneTable = new dsOverallRecordProcess.tblRgTelefoneDataTable();
            _TelefoneRow = _TelefoneTable.NewtblRgTelefoneRow();

            _TelefoneRow.SegTel = txtItem.Text != string.Empty ? Convert.ToInt32(txtItem.Text) : 0;
            _TelefoneRow.CodTipoFone = cmBxTipo.SelectedValue != null ? Convert.ToInt32(cmBxTipo.SelectedValue) : 0;
            _TelefoneRow.DDDFone = txtddd.Text;
            _TelefoneRow.NumeroFone = txtNro.Text;
            _TelefoneRow.Contato = txtContato.Text;
            _TelefoneRow.EMail = txtEMail.Text;
            _TelefoneRow.Principal = (chckBxPrincipal.Checked ? "S" : "N");

            AppStateOverallRecord.TelefoneRow = _TelefoneRow;
        }

        private void ExecuteUpdateContatos() 
        {
            _TelefoneTable = new dsOverallRecordProcess.tblRgTelefoneDataTable();
            _TelefoneRow = _TelefoneTable.NewtblRgTelefoneRow();

            _TelefoneRow.SegTel = txtItem.Text != string.Empty ? Convert.ToInt32(txtItem.Text) : 0;
            _TelefoneRow.CodTipoFone = cmBxTipo.SelectedValue != null ? Convert.ToInt32(cmBxTipo.SelectedValue) : 0;
            _TelefoneRow.DDDFone = txtddd.Text;
            _TelefoneRow.NumeroFone = txtNro.Text;
            _TelefoneRow.Contato = txtContato.Text;
            _TelefoneRow.EMail = txtEMail.Text;
            _TelefoneRow.Principal = (chckBxPrincipal.Checked ? "S" : "N");

            AppStateOverallRecord.TelefoneRow = _TelefoneRow;
        }

        private void HelperFormRegistroGeralContato_Load(object sender, EventArgs e)
        {
            switch (ModificaRegistroGeralType)
            {
                case ModificaRegistroGeralType.RegistroGeralAdicionar:
                    FillDataContatosAddModify();
                    break;
                case ModificaRegistroGeralType.RegistroGeralAlterar:
                    FillDataContatosUpdateModify();
                    break;
            }
        }

        public void FillDataContatosAddModify()
        {
            if (_RgTipoFoneCollection == null)
            {
                _RgTipoFoneCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgTipoFone();
            }

            _RgTelefone = AppStateOverallRecord.RgTelefoneModifyProcess;

            #region ...::: Dados Telefones \ Contatos :::...

            txtItem.Text = _RgTelefone.SeqTel != 0 ? Convert.ToString(_RgTelefone.SeqTel) : string.Empty;

            #endregion

            cmBxTipo.DataSource = _RgTipoFoneCollection;
            cmBxTipo.ValueMember = "IdTipoFone";
            cmBxTipo.DisplayMember = "DescrTipoFone";
        }

        public void FillDataContatosUpdateModify() 
        {
            if (_RgTipoFoneCollection == null)
            {
                _RgTipoFoneCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgTipoFone();
            }

            _RgTelefone = AppStateOverallRecord.RgTelefoneModifyProcess;

            #region ...::: Dados Telefones \ Contatos :::...

            txtItem.Text = _RgTelefone.SeqTel != 0 ? Convert.ToString(_RgTelefone.SeqTel) : string.Empty;
            txtContato.Text = _RgTelefone.Contato;
            txtEMail.Text = _RgTelefone.EMail;
            txtddd.Text = _RgTelefone.DDDFone;
            txtNro.Text = _RgTelefone.NroFone;

            #endregion

            cmBxTipo.DataSource = _RgTipoFoneCollection;
            cmBxTipo.ValueMember = "IdTipoFone";
            cmBxTipo.DisplayMember = "DescrTipoFone";
            cmBxTipo.SelectedValue = _RgTelefone.IdTipoFone;
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, EventArgs e)
        {
            if (AppStateOverallRecord.TelefoneRow != null)
            {
                AppStateOverallRecord.TelefoneRow = null;
            }
            this.Close();
        }

        // ...::: INICIO VALIDAÇÕES :::...
        private void txtEMail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ValidationData.CreateInstance.ValidaEMail(txtEMail.Text))
            {
                ErrPrvdrContato.SetError(txtEMail, ValidationsMessages.VALIDA_EMAIL);
            }
            else
            {
                ErrPrvdrContato.SetError(txtEMail, string.Empty);
            }
        }

        private void txtddd_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ValidationData.CreateInstance.ValidaAceiteSomenteNumeros(txtddd.Text))
            {
                ErrPrvdrContato.SetError(txtddd, ValidationsMessages.VALIDA_NUMERO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrContato.SetError(txtddd, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtNro_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ValidationData.CreateInstance.ValidaAceiteSomenteNumeros(txtNro.Text))
            {
                ErrPrvdrContato.SetError(txtNro, ValidationsMessages.VALIDA_NUMERO);
                tlstrpActionMenuBtnConfirm.Enabled = false;
            }
            else
            {
                ErrPrvdrContato.SetError(txtNro, string.Empty);
                tlstrpActionMenuBtnConfirm.Enabled = true;
            }
        }

        private void txtddd_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrContato.SetError(txtddd, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }

        private void txtNro_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrPrvdrContato.SetError(txtNro, string.Empty);
            tlstrpActionMenuBtnConfirm.Enabled = true;
            tlstrpLblError.Visible = false;
        }
    }
}
