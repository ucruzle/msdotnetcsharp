namespace ClubeDoPedido.Mobile.Configuration.Theme
{
    public class Cyan
    {
        //Campos
        private const string _colorPrimary = "#00bcd4";
        private const string _colorDark = "#006064";
        private const string _colorLight = "#e0f7fa";
        private const string _colorAccent = "#00b8d4";
        private const string _iconCart = "facartcyan.png";
        private const string _iconChat = "fachatcyan.png";
        private const string _iconCatalogo = "facatalogocyan.png";

        //Propriedades
        public string ColorPrimary { get; private set; }
        public string ColorDark { get; private set; }
        public string ColorLight { get; private set; }
        public string ColorAccent { get; private set; }
        public string IconCart { get; private set; }
        public string IconChat { get; private set; }
        public string IconCatalogo { get; private set; }

        //Construtor
        public Cyan()
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
