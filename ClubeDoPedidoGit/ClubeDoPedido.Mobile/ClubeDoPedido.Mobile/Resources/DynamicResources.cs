using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClubeDoPedido.Mobile.Resources
{
    public class DynamicResources : IDynamicResources
    {
        public Color Cinza { get; set; }
        public Color Vermelho { get; set; }

        public DynamicResources()
        {
            Cinza = Color.FromRgb(117, 117, 117);
            Vermelho = Color.FromRgb(229, 57, 53);
        }
    }
}
