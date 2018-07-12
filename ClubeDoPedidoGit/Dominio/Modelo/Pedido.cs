using System;
using System.Collections.Generic;

namespace Dominio.Modelo
{
    public class Pedido
    {
        // Propriedades
        public int PedidoID { get; set; }
        public int ClienteID { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataEntrega { get; set; }
        public decimal ValorPedido { get; set; }
        public decimal Frete { get; set; }
        public string FormaPagamento { get; set; }

        // Relacionamentos
        public virtual ICollection<PedidoItem> ListaItem { get; set; }
        public virtual Usuario Cliente { get; set; }

        // Construtor
        public Pedido()
        {
            ListaItem = new List<PedidoItem>();
        }
    }
}
