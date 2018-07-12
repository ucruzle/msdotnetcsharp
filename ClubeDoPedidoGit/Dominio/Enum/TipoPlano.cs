using Comum.Auxiliares;

namespace Dominio.Enum
{
    public enum TipoPlano
    {
        [StringValue("L")]
        Livre = 0,
        [StringValue("B")]
        Basico = 1,
        [StringValue("I")]
        Ideal = 2,
        [StringValue("MJ")]
        MeuJeito = 3
    }
}
