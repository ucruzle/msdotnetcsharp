using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoPedido.Modelo.Modelo
{
    public class PromocaoDto
    {
        // Propriedades
        public int PromocaoID { get; set; }
        public int ParceiroID { get; set; }
        public string DescricaoReduzida { get; set; }
        public string DescricaoDetalhada { get; set; }
        public decimal valorUnitario { get; set; }
        public string Image { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int QuantidadeClick { get; set; }
        public int QuantidadeVendida { get; set; }
        public int CardLimite { get; set; }
    }
}
