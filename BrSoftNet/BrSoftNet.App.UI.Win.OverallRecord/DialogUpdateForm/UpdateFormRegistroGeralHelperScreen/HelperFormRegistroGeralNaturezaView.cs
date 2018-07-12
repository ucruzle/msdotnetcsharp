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
    public partial class HelperFormRegistroGeralNaturezaView : Form
    {
        public HelperFormRegistroGeralNaturezaView()
        {
            InitializeComponent();
        }

        private void HelperFormRegistroGeralNaturezaView_Load(object sender, EventArgs e)
        {
            FillDataGridNatureza(AppStateOverallRecord.RgRegGeralNaturezaCollection);
        }

        private void FillDataGridNatureza(List<RgRegGeralNatureza> _RgRegGeralNaturezaCollection)
        {
            if (_RgRegGeralNaturezaCollection != null)
            {
                dtGrdVwHelperForm.DataSource = _RgRegGeralNaturezaCollection;
                dtGrdVwHelperForm.ReadOnly = true;

                dtGrdVwHelperForm.Columns["IdEmpr"].HeaderText = "ID Empresa";
                dtGrdVwHelperForm.Columns["IdEmpr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dtGrdVwHelperForm.Columns["IdEmpr"].Width = 150;

                dtGrdVwHelperForm.Columns["IdRg"].HeaderText = "ID Registro";
                dtGrdVwHelperForm.Columns["IdRg"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dtGrdVwHelperForm.Columns["IdRg"].Width = 150;

                dtGrdVwHelperForm.Columns["IdNatureza"].HeaderText = "ID Natureza";
                dtGrdVwHelperForm.Columns["IdNatureza"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dtGrdVwHelperForm.Columns["IdNatureza"].Width = 150;

                dtGrdVwHelperForm.Columns["IdStatusNat"].HeaderText = "Status Registro";
                dtGrdVwHelperForm.Columns["IdStatusNat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dtGrdVwHelperForm.Columns["IdStatusNat"].Width = 150;

                dtGrdVwHelperForm.Columns["DataHora"].HeaderText = "Data / Hora";
                dtGrdVwHelperForm.Columns["DataHora"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dtGrdVwHelperForm.Columns["DataHora"].Width = 150;

                dtGrdVwHelperForm.Columns["Usuario"].HeaderText = "Usuário";
                dtGrdVwHelperForm.Columns["Usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dtGrdVwHelperForm.Columns["Usuario"].Width = 150;
            }
        }
    }
}
