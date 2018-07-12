using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoPedido.Mobile.Configuration.Theme
{
    public class Indigo
    {
        //Campos
        private const string _colorPrimary = "#3f51b5";
        private const string _colorDark = "#1a237e";
        private const string _colorLight = "#e8eaf6";
        private const string _colorAccent = "#304ffe";
        private const string _iconCart = "facartindigo.png";
        private const string _iconChat = "fachatindigo.png";
        private const string _iconCatalogo = "facatalogoindigo.png";

        //Propriedades
        public string ColorPrimary { get; private set; }
        public string ColorDark { get; private set; }
        public string ColorLight { get; private set; }
        public string ColorAccent { get; private set; }
        public string IconCart { get; private set; }
        public string IconChat { get; private set; }
        public string IconCatalogo { get; private set; }

        //Construtor
        public Indigo()
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
