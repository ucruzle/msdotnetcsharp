namespace ClubeDoPedido.Mobile.Configuration.Theme
{
    public class Purple
    {
        //Campos
        private const string _colorPrimary = "#9c27b0";
        private const string _colorDark = "#4a148c";
        private const string _colorLight = "#f3e5f5";
        private const string _colorAccent = "#aa00f";
        private const string _iconCart = "facartpurple.png";
        private const string _iconChat = "fachatpurple.png";
        private const string _iconCatalogo = "facatalogopurple.png";

        //Propriedades
        public string ColorPrimary { get; private set; }
        public string ColorDark { get; private set; }
        public string ColorLight { get; private set; }
        public string ColorAccent { get; private set; }
        public string IconCart { get; private set; }
        public string IconChat { get; private set; }
        public string IconCatalogo { get; private set; }

        //Construtor
        public Purple()
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
