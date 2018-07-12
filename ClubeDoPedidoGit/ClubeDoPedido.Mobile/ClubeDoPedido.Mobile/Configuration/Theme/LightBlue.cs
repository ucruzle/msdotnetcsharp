namespace ClubeDoPedido.Mobile.Configuration.Theme
{
    public class LightBlue
    {
        //Campos
        private const string _colorPrimary = "#03a9f4 ";
        private const string _colorDark = "#01579b ";
        private const string _colorLight = "#e1f5fe ";
        private const string _colorAccent = "#0091ea ";
        private const string _iconCart = "facartlightblue.png";
        private const string _iconChat = "fachatlightblue.png";
        private const string _iconCatalogo = "facatalogolightblue.png";

        //Propriedades
        public string ColorPrimary { get; private set; }
        public string ColorDark { get; private set; }
        public string ColorLight { get; private set; }
        public string ColorAccent { get; private set; }
        public string IconCart { get; private set; }
        public string IconChat { get; private set; }
        public string IconCatalogo { get; private set; }

        //Construtor
        public LightBlue()
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
