using System.Data.Entity.ModelConfiguration;
using Dominio.Modelo;

namespace Infraestrutura.Mapeamento
{
    public class PromocaoMap : EntityTypeConfiguration<Promocao>
    {
        public PromocaoMap()
        {
            // Chave Primária
            HasKey(t => t.PromocaoID);

            // Propriedades
            Property(t => t.PromocaoID).IsRequired();
            Property(t => t.ParceiroID).IsRequired();
            Property(t => t.DescricaoReduzida).HasMaxLength(50).IsRequired();
            Property(t => t.DescricaoDetalhada).HasMaxLength(300).IsOptional();
            Property(t => t.valorUnitario).IsRequired();
            Property(t => t.Image).IsRequired();
            Property(t => t.DataInicio).IsRequired();
            Property(t => t.DataFim).IsRequired();
            Property(t => t.QuantidadeClick).IsRequired();
            Property(t => t.QuantidadeVendida).IsRequired();
            Property(t => t.CardLimite).IsRequired();

            // Mapeamento dos Campos
            ToTable("Promocao");
            Property(t => t.PromocaoID).HasColumnName("promocaoID");
            Property(t => t.ParceiroID).HasColumnName("parceiroID");
            Property(t => t.DescricaoReduzida).HasColumnName("descricaoReduzida");
            Property(t => t.DescricaoDetalhada).HasColumnName("descricaoDetalhada");
            Property(t => t.valorUnitario).HasColumnName("valorUnitario");
            Property(t => t.Image).HasColumnName("image");
            Property(t => t.DataInicio).HasColumnName("dtInicio");
            Property(t => t.DataFim).HasColumnName("dtFim");
            Property(t => t.QuantidadeClick).HasColumnName("quantidadeClicks");
            Property(t => t.QuantidadeVendida).HasColumnName("quantidadeVendida");
            Property(t => t.CardLimite).HasColumnName("cardLimite");

            // Configuração dos relacionamentos
            HasRequired(t => t.PedidoPromocao);
            HasRequired(t => t.Parceiro);
        }
    }
}
