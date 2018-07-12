using System.Data.Entity.ModelConfiguration;
using Dominio.Modelo;

namespace Infraestrutura.Mapeamento
{
    public class ParceiroMap : EntityTypeConfiguration<Parceiro>
    {
        public ParceiroMap()
        {
            // Chave primária
            HasKey(t => t.ParceiroID);

            // Propriedades
            Property(t => t.ParceiroID).IsRequired();
            Property(t => t.NomeFantasia).HasMaxLength(100).IsRequired();
            Property(t => t.CpfCnpj).HasMaxLength(14).IsOptional();
            Property(t => t.Email).HasMaxLength(150).IsRequired();
            Property(t => t.Senha).IsRequired();
            Property(t => t.Telefone).HasMaxLength(10).IsOptional();
            Property(t => t.Celular).HasMaxLength(11).IsOptional();
            Property(t => t.Ativo).IsRequired();
            Property(t => t.DataInclusao).IsRequired();
            Property(t => t.DataAlteracao).IsOptional();
            Property(t => t.RamoAtividadeID).IsRequired();

            // Mapeamento dos Campos
            ToTable("Parceiro");
            Property(t => t.ParceiroID).HasColumnName("parceiroID");
            Property(t => t.NomeFantasia).HasColumnName("nomeFantasia");
            Property(t => t.CpfCnpj).HasColumnName("cnpjCpf");
            Property(t => t.Email).HasColumnName("email");
            Property(t => t.Senha).HasColumnName("senha");
            Property(t => t.Telefone).HasColumnName("telefone");
            Property(t => t.Celular).HasColumnName("celular");
            Property(t => t.Ativo).HasColumnName("ativo");
            Property(t => t.DataInclusao).HasColumnName("dtInclusao");
            Property(t => t.DataAlteracao).HasColumnName("dtAlteracao");
            Property(t => t.RamoAtividadeID).HasColumnName("ramoAtividadeID");

            // Configuração dos relacionamentos
            HasMany(t => t.ListaEndereco);
            HasMany(t => t.ListaProduto);
            HasMany(t => t.ListaPromocao);
            HasRequired(t => t.RamoAtividade);
        }
    }
}
