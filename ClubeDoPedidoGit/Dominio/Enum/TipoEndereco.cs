using Comum.Auxiliares;

namespace Dominio.Enum
{
    public enum TipoEndereco
    {
        [StringValue("Principal")]
        Principal = 1,
        [StringValue("Entrega")]
        Entrega = 2,
        [StringValue("Cobrança")]
        Cobranca = 3
    }
}
