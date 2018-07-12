using System.Data.Entity.ModelConfiguration;
using Dominio.Modelo;

namespace Infraestrutura.Mapeamento
{
    public class PlanoContratadoMap : EntityTypeConfiguration<PlanoContratado>
    {
        public PlanoContratadoMap()
        {
            // Chave primária
            HasKey(t => t.PlanoContratadoID);

            // Propriedades
            Property(t => t.PlanoContratadoID).IsRequired();
            Property(t => t.PlanoID).IsRequired();
            Property(t => t.ParceiroID).IsRequired();
            Property(t => t.QuantidadeProdutosPorPlano).IsRequired();
            Property(t => t.QuantidadeProdutosCadastrados).IsOptional();

            // Mapeamento dos Campos
            ToTable("PlanoContratado");
            Property(t => t.PlanoContratadoID).HasColumnName("planoContratadoID");
            Property(t => t.PlanoID).HasColumnName("planoID");
            Property(t => t.ParceiroID).HasColumnName("parceiroID");
            Property(t => t.QuantidadeProdutosPorPlano).HasColumnName("quantidadeProdutosPorPlano");
            Property(t => t.QuantidadeProdutosCadastrados).HasColumnName("quantidadeProdutosCadastrados");

            // Configuração dos relacionamentos
            HasRequired(t => t.Parceiro);
            HasRequired(t => t.Plano);
        }
    }
}
