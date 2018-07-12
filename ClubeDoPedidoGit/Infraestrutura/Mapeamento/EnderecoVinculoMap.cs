using System.Data.Entity.ModelConfiguration;
using Dominio.Modelo;

namespace Infraestrutura.Mapeamento
{
    public class EnderecoVinculoMap : EntityTypeConfiguration<EnderecoVinculo>
    {
        public EnderecoVinculoMap()
        {
            // Chave Compósta
            HasKey(t => new { t.VinculoID, t.EnderecoID, t.TipoVinculado });

            // Propiedades
            Property(t => t.VinculoID).IsRequired();
            Property(t => t.EnderecoID).IsRequired();
            Property(t => t.TipoVinculado).IsRequired();

            // Mapeamento dos Campos
            Property(t => t.VinculoID).HasColumnName("vinculoID");
            Property(t => t.EnderecoID).HasColumnName("enderecoID");
            Property(t => t.TipoVinculado).HasColumnName("tipoVinculado");
        }
    }
}
