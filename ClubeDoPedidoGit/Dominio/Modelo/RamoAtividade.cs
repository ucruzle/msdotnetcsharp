using System.Collections.Generic;

namespace Dominio.Modelo
{
    public class RamoAtividade
    {
        // Propriedades
        public int RamoAtividadeID { get; set; }
        public string Descricao { get; set; }

        // Relacionamentos
        public virtual ICollection<Parceiro> ListaParceiro { get; set; }

        // Construtor
        public RamoAtividade()
        {
            ListaParceiro = new List<Parceiro>();
        }
    }
}
