namespace ClubeDoPedido.Mobile.Configuration.Theme
{
    public class Teal
    {
        //Campos
        private const string _colorPrimary = "#009688";
        private const string _colorDark = "#004d40";
        private const string _colorLight = "#e0f2f1";
        private const string _colorAccent = "#00bfa5";
        private const string _iconCart = "facartteal.png";
        private const string _iconChat = "fachatteal.png";
        private const string _iconCatalogo = "facatalogoteal.png";

        //Propriedades
        public string ColorPrimary { get; private set; }
        public string ColorDark { get; private set; }
        public string ColorLight { get; private set; }
        public string ColorAccent { get; private set; }
        public string IconCart { get; private set; }
        public string IconChat { get; private set; }
        public string IconCatalogo { get; private set; }

        //Construtor
        public Teal()
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
