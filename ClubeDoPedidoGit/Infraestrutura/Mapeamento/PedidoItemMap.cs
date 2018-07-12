using System.Data.Entity.ModelConfiguration;
using Dominio.Modelo;

namespace Infraestrutura.Mapeamento
{
    public class PedidoItemMap : EntityTypeConfiguration<PedidoItem>
    {
        public PedidoItemMap()
        {
            // Chave Primária
            HasKey(t => t.PeidoItemID);

            // Propriedades
            Property(t => t.PeidoItemID).IsRequired();
            Property(t => t.PedidoID).IsRequired();
            Property(t => t.ProdutoID).IsRequired();
            Property(t => t.ValorUnitario).IsRequired();
            Property(t => t.Quantidade).IsRequired();
            Property(t => t.ValorDesconto).IsRequired();
            Property(t => t.ValorTotal).IsRequired();

            // Mapeamento dos Campos
            ToTable("PedidoItem");
            Property(t => t.PeidoItemID).HasColumnName("pedidoItemID");
            Property(t => t.PedidoID).HasColumnName("pedidoID");
            Property(t => t.ProdutoID).HasColumnName("produtoID");
            Property(t => t.ValorUnitario).HasColumnName("valorUnitario");
            Property(t => t.Quantidade).HasColumnName("quantidade");
            Property(t => t.ValorDesconto).HasColumnName("valorDesconto");
            Property(t => t.ValorTotal).HasColumnName("valorTotal");

            // Configuração dos relacionamentos
            HasRequired(t => t.Pedido);
            HasRequired(t => t.Produto);
        }
    }
}
