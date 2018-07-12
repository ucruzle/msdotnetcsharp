namespace ClubeDoPedido.Mobile.Configuration.Theme
{
    public class DeepPurple
    {
        //Campos
        private const string _colorPrimary = "#673ab7";
        private const string _colorDark = "#311b92";
        private const string _colorLight = "#ede7f6";
        private const string _colorAccent = "#6200ea";
        private const string _iconCart = "facartdeeppurple.png";
        private const string _iconChat = "fachatdeeppurple.png";
        private const string _iconCatalogo = "facatalogodeeppurple.png";

        //Propriedades
        public string ColorPrimary { get; private set; }
        public string ColorDark { get; private set; }
        public string ColorLight { get; private set; }
        public string ColorAccent { get; private set; }
        public string IconCart { get; private set; }
        public string IconChat { get; private set; }
        public string IconCatalogo { get; private set; }

        //Construtor
        public DeepPurple()
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
