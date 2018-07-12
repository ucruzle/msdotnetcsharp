using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ClubeDoPedido.Mobile.Template.usuario.conta
{
    public partial class CriarConta : ContentPage
    {
        public CriarConta()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new CriarContaLogic();
        }
    }
}
