using BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects;
using BrSoftNet.App.Business.Processes.OverallRecord.Enumerators;
using BrSoftNet.App.Business.Processes.OverallRecord.Tasks;
using BrSoftNet.App.UI.Win.OverallRecord.DataTransferProcess;
using BrSoftNet.App.UI.Win.OverallRecord.State;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.OverallRecord.DialogUpdateForm.UpdateFormRegistroGeralHelperScreen
{
    public partial class HelperFormRegistroGeralNatureza : Form
    {
        #region ...::: Private Variable :::...

        private RgRegGeralNatureza _RgRegGeralNatureza = null;

        private List<RgNatureza> _RgNaturezaCollection = null;

        private List<RgStatus> _RgStatusCollection = null;

        private dsOverallRecordProcess.tblRgNaturezaDataTable _RgRegGeralNaturezaTable = null;
        
        private dsOverallRecordProcess.tblRgNaturezaRow _RgRegGeralNaturezaRow = null; 

        #endregion

        #region ...::: Public Properties :::...
        public ModificaRegistroGeralType ModificaRegistroGeralType { get; set; }

        #endregion

        public HelperFormRegistroGeralNatureza()
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

            this.cmBxStatusNat.GotFocus += cmBxStatusNat_GotFocus;
            this.cmBxStatusNat.LostFocus += cmBxStatusNat_LostFocus;

            this.cmBxNatureza.GotFocus += cmBxNatureza_GotFocus;
            this.cmBxNatureza.LostFocus += cmBxNatureza_LostFocus;
        }

        void cmBxNatureza_LostFocus(object sender, System.EventArgs e)
        {
            this.cmBxNatureza.BackColor = Color.White;
        }

        void cmBxNatureza_GotFocus(object sender, System.EventArgs e)
        {
            this.cmBxNatureza.BackColor = Color.LightYellow;
        }

        void cmBxStatusNat_LostFocus(object sender, System.EventArgs e)
        {
            this.cmBxStatusNat.BackColor = Color.White;
        }

        void cmBxStatusNat_GotFocus(object sender, System.EventArgs e)
        {
            this.cmBxStatusNat.BackColor = Color.LightYellow;
        }

        private void ExecuteModifyGeralNatureza()
        {
            switch (ModificaRegistroGeralType)
            {
                case ModificaRegistroGeralType.RegistroGeralAdicionar:
                    ExecuteAddGeralNatureza();
                    break;
                case ModificaRegistroGeralType.RegistroGeralAlterar:
                    ExecuteUpdateGeralNatureza();
                    break;
            }
        }

        private void ExecuteUpdateGeralNatureza()
        {
            _RgRegGeralNaturezaTable = new dsOverallRecordProcess.tblRgNaturezaDataTable();
            _RgRegGeralNaturezaRow = _RgRegGeralNaturezaTable.NewtblRgNaturezaRow();

            _RgRegGeralNaturezaRow.CodNatureza = cmBxNatureza.SelectedValue != null ? Convert.ToInt32(cmBxNatureza.SelectedValue) : 0;
            _RgRegGeralNaturezaRow.Usuario = txtUsuario.Text;
            _RgRegGeralNaturezaRow.CodStatusNat = cmBxStatusNat.SelectedValue != null ? Convert.ToInt32(cmBxStatusNat.SelectedValue) : 0;
            _RgRegGeralNaturezaRow.DataHora = Convert.ToDateTime(txtDtHr.Text) != DateTime.Parse("01/01/0001 00:00:00") ? Convert.ToDateTime(txtDtHr.Text) : Convert.ToDateTime("01/01/0001 00:00:00");

            AppStateOverallRecord.RegGeralNaturezaRow = _RgRegGeralNaturezaRow;
        }

        private void ExecuteAddGeralNatureza()
        {
            _RgRegGeralNaturezaTable = new dsOverallRecordProcess.tblRgNaturezaDataTable();
            _RgRegGeralNaturezaRow = _RgRegGeralNaturezaTable.NewtblRgNaturezaRow();

            _RgRegGeralNaturezaRow.CodNatureza = cmBxNatureza.SelectedValue != null ? Convert.ToInt32(cmBxNatureza.SelectedValue) : 0;
            _RgRegGeralNaturezaRow.Usuario = txtUsuario.Text;
            _RgRegGeralNaturezaRow.CodStatusNat = cmBxStatusNat.SelectedValue != null ? Convert.ToInt32(cmBxStatusNat.SelectedValue) : 0;
            _RgRegGeralNaturezaRow.DataHora = Convert.ToDateTime(txtDtHr.Text) != DateTime.Parse("01/01/0001 00:00:00") ? Convert.ToDateTime(txtDtHr.Text) : Convert.ToDateTime("01/01/0001 00:00:00");

            AppStateOverallRecord.RegGeralNaturezaRow = _RgRegGeralNaturezaRow;
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {
            ExecuteModifyGeralNatureza();
            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            if (AppStateOverallRecord.RegGeralNaturezaRow != null)
            {
                AppStateOverallRecord.RegGeralNaturezaRow = null;
            }
            this.Close();
        }

        private void HelperFormRegistroGeralNatureza_Load(object sender, EventArgs e)
        {
            switch (ModificaRegistroGeralType)
            {
                case ModificaRegistroGeralType.RegistroGeralAdicionar:
                    FillDataGeralNaturezaAddModify();
                    break;
                case ModificaRegistroGeralType.RegistroGeralAlterar:
                    FillDataGeralNaturezaUpdateModify();
                    break;
            }
        }

        private void FillDataGeralNaturezaUpdateModify()
        {
            if ((_RgNaturezaCollection == null) || (_RgStatusCollection == null))
            {
                _RgNaturezaCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgNatureza();

                _RgStatusCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgStatus();
            }

            _RgRegGeralNatureza = AppStateOverallRecord.RgRegGeralNaturezaModifyProcess;

            #region ...::: Dados Natureza Geral :::...

            txtUsuario.Text = _RgRegGeralNatureza.Usuario;
            txtDtHr.Text = _RgRegGeralNatureza.DataHora != DateTime.Parse("01/01/0001 00:00:00") ? _RgRegGeralNatureza.DataHora.ToString() : string.Empty;

            #endregion

            cmBxNatureza.DataSource = _RgNaturezaCollection;
            cmBxNatureza.ValueMember = "IdNatureza";
            cmBxNatureza.DisplayMember = "DescrNatureza";
            cmBxNatureza.SelectedValue = _RgRegGeralNatureza.IdNatureza;

            cmBxStatusNat.DataSource = _RgStatusCollection;
            cmBxStatusNat.ValueMember = "IdRgStatus";
            cmBxStatusNat.DisplayMember = "DescrStatus";
            cmBxStatusNat.SelectedValue = _RgRegGeralNatureza.IdStatusNat;
        }

        private void FillDataGeralNaturezaAddModify()
        {
            if ((_RgNaturezaCollection == null) || (_RgStatusCollection == null))
            {
                _RgNaturezaCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgNatureza();

                _RgStatusCollection = OverallRecordProcess.CreateInstance.TaskGetCollectionRgStatus();
            }

            _RgRegGeralNatureza = AppStateOverallRecord.RgRegGeralNaturezaModifyProcess;

            #region ...::: Dados Natureza Geral :::...

            txtUsuario.Text = _RgRegGeralNatureza.Usuario;
            txtDtHr.Text = DateTime.Now.ToString();

            #endregion

            cmBxNatureza.DataSource = _RgNaturezaCollection;
            cmBxNatureza.ValueMember = "IdNatureza";
            cmBxNatureza.DisplayMember = "DescrNatureza";

            cmBxStatusNat.DataSource = _RgStatusCollection;
            cmBxStatusNat.ValueMember = "IdRgStatus";
            cmBxStatusNat.DisplayMember = "DescrStatus";
        }
    }
}
