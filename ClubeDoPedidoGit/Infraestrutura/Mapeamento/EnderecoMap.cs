using System.Data.Entity.ModelConfiguration;
using Dominio.Modelo;

namespace Infraestrutura.Mapeamento
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            // Chave primária
            HasKey(t => t.EnderecoID);

            // Propriedades
            Property(t => t.EnderecoID).IsRequired();
            Property(t => t.TipoEnderecoID).IsRequired();
            Property(t => t.Logradouro).HasMaxLength(50).IsRequired();
            Property(t => t.Numero).HasMaxLength(6).IsRequired();
            Property(t => t.Complemento).HasMaxLength(150).IsOptional();
            Property(t => t.Bairro).HasMaxLength(50).IsRequired();
            Property(t => t.Cidade).HasMaxLength(50).IsRequired();
            Property(t => t.Uf).HasMaxLength(2).IsRequired();
            Property(t => t.Cep).HasMaxLength(8).IsOptional();
            Property(t => t.PontoReferencia).HasMaxLength(150).IsOptional();
            Property(t => t.Ativo).IsRequired();
            Property(t => t.DataInclusao).IsRequired();
            Property(t => t.DataAlteracao).IsOptional();

            // Mapeamento dos Campos
            ToTable("Endereco");
            Property(t => t.EnderecoID).HasColumnName("enderecoID");
            Property(t => t.TipoEnderecoID).HasColumnName("tipoEnderecoID");
            Property(t => t.Logradouro).HasColumnName("logradouro");
            Property(t => t.Numero).HasColumnName("numero");
            Property(t => t.Complemento).HasColumnName("complemento");
            Property(t => t.Bairro).HasColumnName("bairro");
            Property(t => t.Cidade).HasColumnName("cidade");
            Property(t => t.Uf).HasColumnName("uf");
            Property(t => t.Cep).HasColumnName("cep");
            Property(t => t.PontoReferencia).HasColumnName("pontoReferencia");
            Property(t => t.Ativo).HasColumnName("ativo");
            Property(t => t.DataInclusao).HasColumnName("dtInclusao");
            Property(t => t.DataAlteracao).HasColumnName("dtAlteracao");

            // Configuração dos relacionamentos
            HasMany(t => t.ListaParceiro)
                .WithMany(t => t.ListaEndereco)
                .Map(t => t.ToTable("EnderecoPessoa"));
            HasMany(t => t.ListaUsuario);
            HasRequired(t => t.TipoEndereco);
        }
    }
}
