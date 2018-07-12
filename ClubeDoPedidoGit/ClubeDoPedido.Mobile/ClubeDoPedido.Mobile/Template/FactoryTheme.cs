using ClubeDoPedido.Mobile.Configuration.Theme;
using ClubeDoPedido.Mobile.Enum;

namespace ClubeDoPedido.Mobile.Template
{
    public class FactoryTheme
    {
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
        public string IconCart { get; private set; }
        public string IconChat { get; private set; }
        public string IconCatalogo { get; private set; }

        public FactoryTheme(Theme theme)
        {
            CarregandoTema(theme);
        }

        private void CarregandoTema(Theme theme)
        {
            switch (theme)
            {
                case Theme.Principal:
                    var principal = new Principal();
                    ColorPrimary = principal.ColorPrimary;
                    ColorDark = principal.ColorDark;
                    ColorLight = principal.ColorLight;
                    ColorAccent = principal.ColorAccent;
                    ColorTextIcons = principal.ColorTextIcons;
                    ColorTextPrimary = principal.ColorTextPrimary;
                    ColorTextSecondary = principal.ColorTextSecondary;
                    ColorDivider = principal.ColorDivider;
                    ColorButtonPrimary = principal.ColorButtonPrimary;
                    ColorButtonSecondary = principal.ColorButtonSecondary;
                    break;
                case Theme.Red:
                    var red = new Red();
                    ColorPrimary = red.ColorPrimary;
                    ColorDark = red.ColorDark;
                    ColorLight = red.ColorLight;
                    ColorAccent = red.ColorAccent;
                    IconCart = red.IconCart;
                    IconChat = red.IconChat;
                    IconCatalogo = red.IconCatalogo;
                    break;
                case Theme.Pink:
                    var pink = new Pink();
                    ColorPrimary = pink.ColorPrimary;
                    ColorDark = pink.ColorDark;
                    ColorLight = pink.ColorLight;
                    ColorAccent = pink.ColorAccent;
                    IconCart = pink.IconCart;
                    IconChat = pink.IconChat;
                    IconCatalogo = pink.IconCatalogo;
                    break;
                case Theme.Purple:
                    var purple = new Purple();
                    ColorPrimary = purple.ColorPrimary;
                    ColorDark = purple.ColorDark;
                    ColorLight = purple.ColorLight;
                    ColorAccent = purple.ColorAccent;
                    IconCart = purple.IconCart;
                    IconChat = purple.IconChat;
                    IconCatalogo = purple.IconCatalogo;
                    break;
                case Theme.DeepPurple:
                    var deepPurple = new DeepPurple();
                    ColorPrimary = deepPurple.ColorPrimary;
                    ColorDark = deepPurple.ColorDark;
                    ColorLight = deepPurple.ColorLight;
                    ColorAccent = deepPurple.ColorAccent;
                    IconCart = deepPurple.IconCart;
                    IconChat = deepPurple.IconChat;
                    IconCatalogo = deepPurple.IconCatalogo;
                    break;
                case Theme.Indigo:
                    var indigo = new Indigo();
                    ColorPrimary = indigo.ColorPrimary;
                    ColorDark = indigo.ColorDark;
                    ColorLight = indigo.ColorLight;
                    ColorAccent = indigo.ColorAccent;
                    IconCart = indigo.IconCart;
                    IconChat = indigo.IconChat;
                    IconCatalogo = indigo.IconCatalogo;
                    break;
                case Theme.Blue:
                    var blue = new Blue();
                    ColorPrimary = blue.ColorPrimary;
                    ColorDark = blue.ColorDark;
                    ColorLight = blue.ColorLight;
                    ColorAccent = blue.ColorAccent;
                    IconCart = blue.IconCart;
                    IconChat = blue.IconChat;
                    IconCatalogo = blue.IconCatalogo;
                    break;
                case Theme.LightBlue:
                    var lightBlue = new LightBlue();
                    ColorPrimary = lightBlue.ColorPrimary;
                    ColorDark = lightBlue.ColorDark;
                    ColorLight = lightBlue.ColorLight;
                    ColorAccent = lightBlue.ColorAccent;
                    IconCart = lightBlue.IconCart;
                    IconChat = lightBlue.IconChat;
                    IconCatalogo = lightBlue.IconCatalogo;
                    break;
                case Theme.Cyan:
                    var cyan = new Cyan();
                    ColorPrimary = cyan.ColorPrimary;
                    ColorDark = cyan.ColorDark;
                    ColorLight = cyan.ColorLight;
                    ColorAccent = cyan.ColorAccent;
                    IconCart = cyan.IconCart;
                    IconChat = cyan.IconChat;
                    IconCatalogo = cyan.IconCatalogo;
                    break;
                case Theme.Teal:
                    var teal = new Teal();
                    ColorPrimary = teal.ColorPrimary;
                    ColorDark = teal.ColorDark;
                    ColorLight = teal.ColorLight;
                    ColorAccent = teal.ColorAccent;
                    IconCart = teal.IconCart;
                    IconChat = teal.IconChat;
                    IconCatalogo = teal.IconCatalogo;
                    break;
                case Theme.Brown:
                    var brown = new Brown();
                    ColorPrimary = brown.ColorPrimary;
                    ColorDark = brown.ColorDark;
                    ColorLight = brown.ColorLight;
                    ColorAccent = brown.ColorAccent;
                    IconCart = brown.IconCart;
                    IconChat = brown.IconChat;
                    IconCatalogo = brown.IconCatalogo;
                    break;
                default:
                    break;
            }
        }
    }
}
