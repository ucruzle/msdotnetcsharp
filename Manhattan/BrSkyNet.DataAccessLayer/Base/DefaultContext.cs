using BrSkyNet.ModelLayer.Entities;
using System.Data.Entity;

namespace BrSkyNet.DataAccessLayer.Base
{
    public class DefaultContext : DbContext
    {
        public DbSet<CtNivelCinco> CtNiveisCinco { get; set; }
        public DbSet<CtNivelDois> CtNiveisDois { get; set; }
        public DbSet<CtNivelQuatro> CtNiveisQuatro { get; set; }
        public DbSet<CtNivelSeis> CtNiveisSeis { get; set; }
        public DbSet<CtNivelTres> CtNiveisTres { get; set; }
        public DbSet<CtNivelUm> CtNiveisUm { get; set; }
        public DbSet<CtPlanoContabil> CtPlanosContabeis { get; set; }
        public DbSet<FiNroBanco> FiNrosBancos { get; set; }
        public DbSet<FiTipoCtaBanco> FiTiposCtasBancos { get; set; }
        public DbSet<GeAplicacao> GeAplicacoes { get; set; }
        public DbSet<GeEmpresa> GeEmpresas { get; set; }
        public DbSet<GeEmpresaAplicacao> GeEmpresasAplicacoes { get; set; }
        public DbSet<GeEmpresaConsol> GeEmpresasConsols { get; set; }
        public DbSet<GeGrupo> GeGrupos { get; set; }
        public DbSet<GeGrupoProcesso> GeGruposProcessos { get; set; }
        public DbSet<GeMvcWebProcesso> GeMvcWebProcessos { get; set; }
        public DbSet<GeParametro> GeParametros { get; set; }
        public DbSet<GeProcesso> GeProcessos { get; set; }
        public DbSet<GeSessaoUsuario> GeSessoesUsuarios { get; set; }
        public DbSet<GeTipoProcesso> GeTiposProcessos { get; set; }
        public DbSet<GeTmpValor> GeTmpValores { get; set; }
        public DbSet<GeTmpValorDet> GeTmpValoresDet { get; set; }
        public DbSet<GeUsuario> GeUsuarios { get; set; }
        public DbSet<GeUsuarioAplicacao> GeUsuariosAplicacoes { get; set; }
        public DbSet<GeUsuarioGrupo> GeUsuariosGrupos { get; set; }
        public DbSet<GeUsuarioProcesso> GeUsuariosProcessos { get; set; }
        public DbSet<RgEstado> RgEstados { get; set; }
        public DbSet<RgMunicipio> RgMunicipios { get; set; }
        public DbSet<RgNatureza> RgNaturezas { get; set; }
        public DbSet<RgRegGeral> RgRegGerais { get; set; }
        public DbSet<RgRegGeralNatureza> RgRegGeraisNaturezas { get; set; }
        public DbSet<RgRegiao> RgRegioes { get; set; }
        public DbSet<RgStatus> RgStatusCollection { get; set; }
        public DbSet<RgTelefone> RgTelefones { get; set; }
        public DbSet<RgTipoFone> RgTiposFones { get; set; }
        public DbSet<RgTipoRg> RgTiposRgs { get; set; }
        public DbSet<RgTmpAniversariante> RgTmpAniversariantes { get; set; }
        public DbSet<RgEndereco> RgEnderecos { get; set; }
        public DbSet<RgFisicaJuridica> RgFisicasJuridicas { get; set; }
        public DbSet<RgParamRegGeral> RgParamRegsGerais { get; set; }

    }
}
