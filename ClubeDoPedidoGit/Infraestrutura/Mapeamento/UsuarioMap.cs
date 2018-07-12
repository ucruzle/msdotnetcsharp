using System.Data.Entity.ModelConfiguration;
using Dominio.Modelo;

namespace Infraestrutura.Mapeamento
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            // Primary Key
            HasKey(t => t.UsuarioID);

            // Propriedade
            Property(t => t.Nome).HasMaxLength(50).IsRequired();
            Property(t => t.Email) .HasMaxLength(150).IsRequired();
            Property(t => t.Senha).IsRequired();
            Property(t => t.TipoUsuarioID).IsRequired();
            Property(t => t.Foto).IsOptional();
            Property(t => t.Celular).IsOptional();
            Property(t => t.Telefone).IsOptional();
            Property(t => t.CnpjCpf).HasMaxLength(14).IsOptional();
            Property(t => t.Ativo).IsRequired();
            Property(t => t.DataInclusao).IsRequired();
            Property(t => t.DataAlteracao).IsOptional();

            // Mapeamento dos Campos
            ToTable("Usuario");
            Property(t => t.UsuarioID).HasColumnName("usuarioID");
            Property(t => t.Nome).HasColumnName("nome");
            Property(t => t.Email).HasColumnName("email");
            Property(t => t.Senha).HasColumnName("senha");
            Property(t => t.TipoUsuarioID).HasColumnName("tipoUsuarioID");
            Property(t => t.Foto).HasColumnName("foto");
            Property(t => t.Celular).HasColumnName("celular");
            Property(t => t.Telefone).HasColumnName("telefone");
            Property(t => t.CnpjCpf).HasColumnName("cnpjCpf");
            Property(t => t.Ativo).HasColumnName("ativo");
            Property(t => t.DataInclusao).HasColumnName("dtInclusao");
            Property(t => t.DataAlteracao).HasColumnName("dtAlteracao");

            // Configurações dos relacionamentos
            HasMany(t => t.ListaEndereco);
            HasMany(t => t.ListaPedidoPromocao);
        }
    }
}


