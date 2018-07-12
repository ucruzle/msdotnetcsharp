namespace ClubeDoPedido.Mobile.Configuration.Theme
{
    public class Red
    {
        //Campos
        private const string _colorPrimary = "#f44336"; 
        private const string _colorDark = "#b71c1c"; 
        private const string _colorLight = "#ffebee"; 
        private const string _colorAccent = "#d50000";
        private const string _iconCart = "facartred.png";
        private const string _iconChat = "fachatred.png";
        private const string _iconCatalogo = "facatalogored.png";

        //Propriedades
        public string ColorPrimary { get; private set; }
        public string ColorDark { get; private set; }
        public string ColorLight { get; private set; }
        public string ColorAccent { get; private set; }
        public string IconCart { get; private set; }
        public string IconChat { get; private set; }
        public string IconCatalogo { get; private set; }

        //Construtor
        public Red()
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
