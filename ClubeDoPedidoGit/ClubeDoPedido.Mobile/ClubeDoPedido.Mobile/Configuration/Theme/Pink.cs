namespace ClubeDoPedido.Mobile.Configuration.Theme
{
    public class Pink
    {
        //Campos
        private const string _colorPrimary = "#e91e63";
        private const string _colorDark = "#880e4f";
        private const string _colorLight = "#fce4ec";
        private const string _colorAccent = "#c51162";
        private const string _iconCart = "facartpink.png";
        private const string _iconChat = "fachatpink.png";
        private const string _iconCatalogo = "facatalogopink.png";

        //Propriedades
        public string ColorPrimary { get; private set; }
        public string ColorDark { get; private set; }
        public string ColorLight { get; private set; }
        public string ColorAccent { get; private set; }
        public string IconCart { get; private set; }
        public string IconChat { get; private set; }
        public string IconCatalogo { get; private set; }

        //Construtor
        public Pink()
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
