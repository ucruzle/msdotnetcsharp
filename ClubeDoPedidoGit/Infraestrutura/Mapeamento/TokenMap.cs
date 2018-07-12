using System.Data.Entity.ModelConfiguration;
using Dominio.Modelo;

namespace Infraestrutura.Mapeamento
{
    public class TokenMap : EntityTypeConfiguration<Token>
    {
        public TokenMap()
        {
            // Chave Primária
            HasKey(t => t.TokenID);

            // Propriedades
            Property(t => t.TokenID).IsRequired();
            Property(t => t.ParceiroID).IsRequired();
            Property(t => t.CodigoToken).IsRequired();
            Property(t => t.DataInclusao).IsRequired();
            Property(t => t.DataAlteracao).IsOptional();

            // Mapeamento dos Campos
            ToTable("Token");
            Property(t => t.TokenID).HasColumnName("tokenID");
            Property(t => t.ParceiroID).HasColumnName("parceiroID");
            Property(t => t.CodigoToken).HasColumnName("codigoToken");
            Property(t => t.DataInclusao).HasColumnName("dtInclusao");
            Property(t => t.DataAlteracao).HasColumnName("dtAlteracao");

            // Configuração dos relacionamentos
            HasRequired(t => t.Parceiro);
        }
    }
}
