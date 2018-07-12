using System.Data.Entity.ModelConfiguration;
using Dominio.Modelo;

namespace Infraestrutura.Mapeamento
{
    public class PlanoMap : EntityTypeConfiguration<Plano>
    {
        public PlanoMap()
        {
            // Chave Primária
            HasKey(t => t.PlanoID);

            // Propriedades
            Property(t => t.PlanoID).IsRequired();
            Property(t => t.Nome).HasMaxLength(50).IsRequired();
            Property(t => t.Detalhe).HasMaxLength(300).IsOptional();

            // Mapeamento dos Campos
            ToTable("Plano");
            Property(t => t.PlanoID).HasColumnName("planoID");
            Property(t => t.Nome).HasColumnName("nome");
            Property(t => t.Detalhe).HasColumnName("detalhe");

            // Configuração dos relacionamentos
            HasMany(t => t.ListaPlanoContratado);
        }
    }
}
