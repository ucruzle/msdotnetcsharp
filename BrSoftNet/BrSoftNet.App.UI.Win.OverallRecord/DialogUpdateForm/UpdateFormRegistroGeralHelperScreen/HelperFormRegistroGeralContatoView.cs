using BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects;
using BrSoftNet.App.UI.Win.OverallRecord.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.OverallRecord.DialogUpdateForm.UpdateFormRegistroGeralHelperScreen
{
    public partial class HelperFormRegistroGeralContatoView : Form
    {
        public HelperFormRegistroGeralContatoView()
        {
            InitializeComponent();
        }

        private void HelperFormRegistroGeralContatoView_Load(object sender, EventArgs e)
        {
            FillDataGridContatos(AppStateOverallRecord.RgTelefoneCollection);
        }

        private void FillDataGridContatos(List<RgTelefone> _RgTelefoneCollection)
        {
            if (_RgTelefoneCollection != null)
            {
                dtGrdVwHelperForm.DataSource = _RgTelefoneCollection;
                dtGrdVwHelperForm.ReadOnly = true;

                dtGrdVwHelperForm.Columns["IdEmpr"].HeaderText = "ID Empresa";
                dtGrdVwHelperForm.Columns["IdEmpr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtGrdVwHelperForm.Columns["IdRg"].HeaderText = "ID Registro";
                dtGrdVwHelperForm.Columns["IdRg"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtGrdVwHelperForm.Columns["SeqTel"].HeaderText = "Sequência";
                dtGrdVwHelperForm.Columns["SeqTel"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtGrdVwHelperForm.Columns["IdTipoFone"].HeaderText = "Tipo Telefone";
                dtGrdVwHelperForm.Columns["IdTipoFone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtGrdVwHelperForm.Columns["DDDFone"].HeaderText = "DDD";
                dtGrdVwHelperForm.Columns["DDDFone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtGrdVwHelperForm.Columns["NroFone"].HeaderText = "Nro Fone";
                dtGrdVwHelperForm.Columns["NroFone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtGrdVwHelperForm.Columns["Contato"].HeaderText = "Contato";
                dtGrdVwHelperForm.Columns["Contato"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtGrdVwHelperForm.Columns["EMail"].HeaderText = "E-Mail";
                dtGrdVwHelperForm.Columns["EMail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dtGrdVwHelperForm.Columns["Principal"].HeaderText = "Principal";
                dtGrdVwHelperForm.Columns["Principal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
    }
}
