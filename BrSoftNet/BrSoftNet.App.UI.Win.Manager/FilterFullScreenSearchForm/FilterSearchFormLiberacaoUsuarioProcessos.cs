using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    public partial class FilterSearchFormLiberacaoUsuarioProcessos : Form
    {
        public FilterSearchFormLiberacaoUsuarioProcessos()
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
        }
    }
}
