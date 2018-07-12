namespace Dominio.Modelo
{
    public class PedidoItem
    {
        // Propriedades
        public int PeidoItemID { get; set; }
        public int PedidoID { get; set; }
        public int ProdutoID { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorTotal { get; set; }

        // Relacionamentos
        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }

        // Construtor
        public PedidoItem(){}
    }
}
