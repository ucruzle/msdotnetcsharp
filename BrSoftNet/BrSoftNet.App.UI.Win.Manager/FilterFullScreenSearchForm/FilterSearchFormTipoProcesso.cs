using System.Drawing;
using System.Windows.Forms;
using System;

namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormTipoProcesso : Form
    {
        public int CodigoTipoProcesso { get; set; }
        public string DescricaoTipoProcesso { get; set; }
        public int SequenciaTipoProcesso { get; set; }
        public int SearchType { get; set; }

        public FilterSearchFormTipoProcesso()
        {
            InitializeComponent();

            this.txtBxCodigoTipoProcesso.GotFocus  += txtBxCodigoTipoProcesso_GotFocus;
            this.txtBxCodigoTipoProcesso.LostFocus += txtBxCodigoTipoProcesso_LostFocus;

            this.txtBxDescricaoTipoProcesso.GotFocus  += txtBxDescricaoTipoProcesso_GotFocus;
            this.txtBxDescricaoTipoProcesso.LostFocus += txtBxDescricaoTipoProcesso_LostFocus;

            this.txtBxSequenciaTipoProcesso.GotFocus  += txtBxSequenciaTipoProcesso_GotFocus;
            this.txtBxSequenciaTipoProcesso.LostFocus += txtBxSequenciaTipoProcesso_LostFocus;
           
        }

        private void txtBxSequenciaTipoProcesso_LostFocus(object sender, System.EventArgs e)
        {
            this.txtBxSequenciaTipoProcesso.BackColor = Color.White;
        }

        private void txtBxSequenciaTipoProcesso_GotFocus(object sender, System.EventArgs e)
        {
            this.txtBxSequenciaTipoProcesso.BackColor = Color.LightYellow;
        }

        private void txtBxDescricaoTipoProcesso_LostFocus(object sender, System.EventArgs e)
        {
            this.txtBxDescricaoTipoProcesso.BackColor = Color.White;
        }

        private void txtBxDescricaoTipoProcesso_GotFocus(object sender, System.EventArgs e)
        {
            this.txtBxDescricaoTipoProcesso.BackColor = Color.LightYellow;
        }

        private void txtBxCodigoTipoProcesso_LostFocus(object sender, System.EventArgs e)
        {
            this.txtBxCodigoTipoProcesso.BackColor = Color.White;
        }

        private void txtBxCodigoTipoProcesso_GotFocus(object sender, System.EventArgs e)
        {
            this.txtBxCodigoTipoProcesso.BackColor = Color.LightYellow;
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {

            if (tbControlTipoProcesso.SelectedIndex.Equals(0))
            {
                CodigoTipoProcesso = int.Parse(txtBxCodigoTipoProcesso.Text);
            }

            if (tbControlTipoProcesso.SelectedIndex.Equals(1))
            {
                DescricaoTipoProcesso = txtBxDescricaoTipoProcesso.Text;
            }

            if (tbControlTipoProcesso.SelectedIndex.Equals(2))
            {
                SequenciaTipoProcesso = int.Parse(txtBxSequenciaTipoProcesso.Text);
            }

            SearchType = tbControlTipoProcesso.SelectedIndex;

            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
