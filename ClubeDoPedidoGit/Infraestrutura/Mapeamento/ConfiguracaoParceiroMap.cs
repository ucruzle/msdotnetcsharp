using System.Data.Entity.ModelConfiguration;
using Dominio.Modelo;

namespace Infraestrutura.Mapeamento
{
    public class ConfiguracaoParceiroMap : EntityTypeConfiguration<ConfiguracaoParceiro>
    {
        public ConfiguracaoParceiroMap()
        {
            // Chave Primária
            HasKey(t => t.ConfiguracaoParceiroID);

            // Propriedades
            Property(t => t.ConfiguracaoParceiroID).IsRequired();
            Property(t => t.ParceiroID).IsRequired();
            Property(t => t.Logo).IsOptional();
            Property(t => t.LogoMobile).IsOptional();
            Property(t => t.LogoWeb).IsOptional();
            Property(t => t.Tema).IsOptional();
            Property(t => t.Frete).IsOptional();

            // Mapeamento dos Campos
            ToTable("ConfiguracaoParceiro");
            Property(t => t.ConfiguracaoParceiroID).HasColumnName("configuracaoParceiroID");
            Property(t => t.ParceiroID).HasColumnName("parceiroID");
            Property(t => t.Logo).HasColumnName("logo");
            Property(t => t.LogoMobile).HasColumnName("logoMobile");
            Property(t => t.LogoWeb).HasColumnName("logoWeb");
            Property(t => t.Tema).HasColumnName("tema");
            Property(t => t.Frete).HasColumnName("frete");
        }
    }
}
