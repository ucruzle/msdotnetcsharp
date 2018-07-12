using System.Collections.Generic;

namespace Dominio.Modelo
{
    public class Plano
    {
        // Propriedades
        public int PlanoID { get; set; }
        public string Nome { get; set; }
        public string Detalhe { get; set; }

        // Relacionamentos
        public virtual ICollection<PlanoContratado> ListaPlanoContratado { get; set; }

        // Construtor
        public Plano()
        {
            ListaPlanoContratado = new List<PlanoContratado>();
        }
    }
}
