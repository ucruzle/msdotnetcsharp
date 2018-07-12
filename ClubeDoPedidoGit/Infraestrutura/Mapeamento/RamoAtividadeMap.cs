using System.Data.Entity.ModelConfiguration;
using Dominio.Modelo;

namespace Infraestrutura.Mapeamento
{
    public class RamoAtividadeMap : EntityTypeConfiguration<RamoAtividade>
    {
        public RamoAtividadeMap()
        {
            // Chave Primaria
            HasKey(t => t.RamoAtividadeID);

            // Propriedades
            Property(t => t.RamoAtividadeID).IsRequired();
            Property(t => t.Descricao).HasMaxLength(30).IsRequired();

            // Mapeamento dos campos
            ToTable("RamoAtividade");
            Property(t => t.RamoAtividadeID).HasColumnName("ramoAtividadeID");
            Property(t => t.Descricao).HasColumnName("descricaoAtividade");

            // Configurações dos Relacionamentos
            HasMany(t => t.ListaParceiro);
        }
    }
}
