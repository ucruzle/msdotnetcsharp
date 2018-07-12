namespace ClubeDoPedido.Mobile.Configuration.Theme
{
    public class Principal
    {
        //Campos
        private const string _colorPrimary = "#E53935"; // Vermelho
        private const string _colorDark = "#D32F2F"; // Vermelho Escuro 
        private const string _colorLight = "#ef5350"; // Laranja Claro 
        private const string _colorAccent = "#f2f2f2"; // Azul Mariho
        private const string _colorTextIcons = "#FFFFFF"; // Branco
        private const string _colorTextPrimary = "#212121"; // Preto
        private const string _colorTextSecondary = "#757575"; // Cinza
        private const string _colorDivider = "#BDBDBD"; // Cinza Claro
        private const string _colorButtonPrimary = "#BDBDBD"; // Cinza Claro
        private const string _colorButtonSecondary = "#FFFFFF"; // Branco


        //Propriedades
        public string ColorPrimary { get; private set; }
        public string ColorDark { get; private set; }
        public string ColorLight { get; private set; }
        public string ColorAccent { get; private set; }
        public string ColorTextIcons { get; private set; }
        public string ColorTextPrimary { get; private set; }
        public string ColorTextSecondary { get; private set; }
        public string ColorDivider { get; private set; }
        public string ColorButtonPrimary { get; private set; }
        public string ColorButtonSecondary { get; private set; }

        //Construtor
        public Principal()
        {
            ColorPrimary = _colorPrimary;
            ColorDark = _colorDark;
            ColorLight = _colorLight;
            ColorAccent = _colorAccent;
            ColorTextIcons = _colorTextIcons;
            ColorTextPrimary = _colorTextPrimary;
            ColorTextSecondary = _colorTextSecondary;
            ColorDivider = _colorDivider;
            ColorButtonPrimary = _colorButtonPrimary;
            ColorButtonSecondary = _colorButtonSecondary;
        }
    }
}
