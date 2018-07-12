using System;

namespace ClubeDoPedido.Modelo.Modelo
{
    public class ProdutoDto
    {
        public int ProdutoID { get; set; }
        public string DescricaoReduzida { get; set; }
        public string DescricaoDetalhada { get; set; }
        public decimal ValorUnitario { get; set; }
        public string Imagem { get; set; }
        public int ParceiroID { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
