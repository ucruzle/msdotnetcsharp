using System.Data.Entity.ModelConfiguration;
using Dominio.Modelo;

namespace Infraestrutura.Mapeamento
{
    public class PedidoPromocaoMap : EntityTypeConfiguration<PedidoPromocao>
    {
        public PedidoPromocaoMap()
        {
            // Chave Primária
            HasKey(t => t.PedidioPromocaoID);

            // Propriedades
            Property(t => t.PedidioPromocaoID).IsRequired();
            Property(t => t.PromocaoID).IsRequired();
            Property(t => t.UsuarioID).IsRequired();

            // Mapeamento dos Campos
            ToTable("PedidoPromocao");
            Property(t => t.PedidioPromocaoID).HasColumnName("pedidoPromocaoID");
            Property(t => t.UsuarioID).HasColumnName("usuarioID");
            Property(t => t.PromocaoID).HasColumnName("promocaoID");

            // Configurações dos relacionamentos
            HasMany(t => t.ListaPromocao);
            HasRequired(t => t.Usuario);
        }
    }
}
