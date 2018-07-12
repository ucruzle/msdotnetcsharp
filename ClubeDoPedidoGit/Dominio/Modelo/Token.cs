using System;

namespace Dominio.Modelo
{
    public class Token
    {
        // Propriedades
        public int TokenID { get; set; }
        public int ParceiroID { get; set; }
        public Guid CodigoToken { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public virtual Parceiro Parceiro { get; set; }

        // Construtor
        public Token() {}
    }
}
