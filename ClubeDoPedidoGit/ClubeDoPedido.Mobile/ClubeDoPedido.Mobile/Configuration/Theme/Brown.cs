namespace ClubeDoPedido.Mobile.Configuration.Theme
{
    public class Brown
    {
        //Campos
        private const string _colorPrimary = "#795548";
        private const string _colorDark = "#3e2723";
        private const string _colorLight = "#efebe9";
        private const string _colorAccent = "#4e342e";
        private const string _iconCart = "facartbrown.png";
        private const string _iconChat = "fachatbrown.png";
        private const string _iconCatalogo = "facatalogobrown.png";

        //Propriedades
        public string ColorPrimary { get; private set; }
        public string ColorDark { get; private set; }
        public string ColorLight { get; private set; }
        public string ColorAccent { get; private set; }
        public string IconCart { get; private set; }
        public string IconChat { get; private set; }
        public string IconCatalogo { get; private set; }

        //Construtor
        public Brown()
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
