namespace ClubeDoPedido.Modelo.Modelo
{
    public class EstabelecimentoDto
    {
        public int ParceiroID { get; set; }
        public string NomeFantasia { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int RamoAtividadeID { get; set; }
        public string RamoAtividade { get; set; }
        public bool Ativo { get; set; }
        public byte[] LogoMobile { get; set; }
        public string ImageUrl { get; set; }
        public string BnnerUrl { get; set; }
        public int Tema { get; set; }
        public decimal Frete { get; set; }
        public double Avaliacao { get; set; }
        public bool Seguir { get; set; }
        public string Endereco { get; set; }
        public ProdutoDto Produto { get; set; }
    }
}
