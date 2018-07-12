using System.Data.Entity.ModelConfiguration;
using Dominio.Modelo;

namespace Infraestrutura.Mapeamento
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            // Chave Primária
            HasKey(t => t.ProdutoID);

            // Propriedades
            Property(t => t.ProdutoID).IsRequired();
            Property(t => t.ParceiroID).IsRequired();
            Property(t => t.DescricaoReduzida).HasMaxLength(50).IsRequired();
            Property(t => t.DescricaoDetalhada).HasMaxLength(300).IsRequired();
            Property(t => t.ValorUnitario).IsRequired();
            Property(t => t.Imagem).IsRequired();
            Property(t => t.DataInclusao).IsRequired();
            Property(t => t.DataAlteracao).IsOptional();

            // Mapeamento dos Campos
            ToTable("Produto");
            Property(t => t.ProdutoID).HasColumnName("produtoID");
            Property(t => t.ParceiroID).HasColumnName("parceiroID");
            Property(t => t.DescricaoReduzida).HasColumnName("descricaoReduzida");
            Property(t => t.DescricaoDetalhada).HasColumnName("descricaoDetalhada");
            Property(t => t.ValorUnitario).HasColumnName("valorUnitario");
            Property(t => t.Imagem).HasColumnName("image");
            Property(t => t.DataInclusao).HasColumnName("dtInclusao");
            Property(t => t.DataAlteracao).HasColumnName("dtAlteracao");

            // Configuração dos relacionamentos
            HasRequired(t => t.Parceiro);
        }
    }
}
