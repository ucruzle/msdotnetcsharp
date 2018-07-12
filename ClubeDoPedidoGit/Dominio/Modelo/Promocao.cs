using System;

namespace Dominio.Modelo
{
    public class Promocao
    {
        // Propriedades
        public int PromocaoID { get; set; }
        public int ParceiroID { get; set; }
        public string DescricaoReduzida { get; set; }
        public string DescricaoDetalhada { get; set; }
        public decimal valorUnitario { get; set; }
        public byte[] Image { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int QuantidadeClick { get; set; }
        public int QuantidadeVendida { get; set; }
        public int CardLimite { get; set; }

        // Relacionamentos
        public virtual PedidoPromocao PedidoPromocao { get; set; }
        public virtual Parceiro Parceiro { get; set; }

        // Construtor
        public Promocao() { }
    }
}
