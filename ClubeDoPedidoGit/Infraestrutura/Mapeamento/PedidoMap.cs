using System.Data.Entity.ModelConfiguration;
using Dominio.Modelo;

namespace Infraestrutura.Mapeamento
{
    public class PedidoMap : EntityTypeConfiguration<Pedido>
    {
        public PedidoMap()
        {
            // Chave Primária
            HasKey(t => t.PedidoID);

            // Propriedades
            Property(t => t.PedidoID).IsRequired();
            Property(t => t.ClienteID).IsRequired();
            Property(t => t.DataPedido).IsRequired();
            Property(t => t.DataEntrega).IsOptional();
            Property(t => t.ValorPedido).IsRequired();
            Property(t => t.Frete).IsOptional();
            Property(t => t.FormaPagamento).HasMaxLength(20).IsOptional();

            // Mapeamento dos Campos
            ToTable("Pedido");
            Property(t => t.PedidoID).HasColumnName("pedidoID");
            Property(t => t.ClienteID).HasColumnName("usuarioID");
            Property(t => t.DataPedido).HasColumnName("dataPedido");
            Property(t => t.DataEntrega).HasColumnName("dataEntrega");
            Property(t => t.ValorPedido).HasColumnName("valorPedido");
            Property(t => t.Frete).HasColumnName("frete");
            Property(t => t.FormaPagamento).HasColumnName("formaPagamento");

            // Configuração dos relacionamentos
            HasMany(t => t.ListaItem);
            HasRequired(t => t.Cliente);
        }
    }
}
