using System.Collections.Generic;

namespace Dominio.Modelo
{
    public class PedidoPromocao
    {
        // Propriedades
        public int PedidioPromocaoID { get; set; }
        public int UsuarioID { get; set; }
        public int PromocaoID { get; set; }

        // Relacionamentos    
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Promocao> ListaPromocao { get; set; }

        // Construtor
        public PedidoPromocao() {
            ListaPromocao = new List<Promocao>();
        }
    }
}
