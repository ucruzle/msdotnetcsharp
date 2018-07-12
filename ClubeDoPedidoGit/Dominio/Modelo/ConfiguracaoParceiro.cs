namespace Dominio.Modelo
{
    public class ConfiguracaoParceiro
    {
        // Propriedades
        public int ConfiguracaoParceiroID { get; set; }
        public int ParceiroID { get; set; }
        public byte[] Logo { get; set; }
        public byte[] LogoMobile { get; set; }
        public byte[] LogoWeb { get; set; }
        public string Tema { get; set; }
        public decimal Frete { get; set; }

        // Construtor
        public ConfiguracaoParceiro() {}
    }
}
