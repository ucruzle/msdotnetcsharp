using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoPedido.Mobile.Configuration.Theme
{
    public class Blue
    {
        //Campos
        private const string _colorPrimary = "#2196f3";
        private const string _colorDark = "#0d47a1";
        private const string _colorLight = "#e3f2fd";
        private const string _colorAccent = "#2962ff";
        private const string _iconCart = "facartblue.png";
        private const string _iconChat = "fachatblue.png";
        private const string _iconCatalogo = "facatalogoblue.png";

        //Propriedades
        public string ColorPrimary { get; private set; }
        public string ColorDark { get; private set; }
        public string ColorLight { get; private set; }
        public string ColorAccent { get; private set; }
        public string IconCart { get; private set; }
        public string IconChat { get; private set; }
        public string IconCatalogo { get; private set; }

        //Construtor
        public Blue()
        {
            ColorPrimary = _colorPrimary;
            ColorDark = _colorDark;
            ColorLight = _colorLight;
            ColorAccent = _colorAccent;
            IconCart = _iconCart;
            IconChat = _iconChat;
            IconCatalogo = _iconCatalogo;
        }
    }
}
