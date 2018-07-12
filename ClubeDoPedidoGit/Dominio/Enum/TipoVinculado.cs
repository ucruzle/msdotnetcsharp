using Comum.Auxiliares;

namespace Dominio.Enum
{
    public enum TipoVinculado
    {
        [StringValue("Parceiro Principal")]
        ParceiroPrincipal = 1,
        [StringValue("Parceiro Entrega")]
        ParceiroEntrega = 2,
        [StringValue("Parceiro Correspondência")]
        ParceiroCorrespondência = 3,
        [StringValue("Usuario Principal")]
        UsuarioPrincipal = 4,
        [StringValue("Usuario Entrega")]
        UsuarioEntrega = 5,
    }
}
