using BrSkyNet.ModelLayer.Entities;
using Microsoft.OData.Edm;
using System.Web.Http;
using System.Web.OData.Batch;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace BrSkyNet.InteropLayer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MapODataServiceRoute("odata", null, GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "BrSkyNet";
            builder.ContainerName = "DefaultContainer";

            builder.EntitySet<CtNivelCinco>("CtNiveisCinco");
            builder.EntitySet<CtNivelDois>("CtNiveisDois");
            builder.EntitySet<CtNivelQuatro>("CtNiveisQuatro");
            builder.EntitySet<CtNivelSeis>("CtNiveisSeis");
            builder.EntitySet<CtNivelTres>("CtNiveisTres");
            builder.EntitySet<CtNivelUm>("CtNiveisUm");
            builder.EntitySet<CtPlanoContabil>("CtPlanosContabeis");
            builder.EntitySet<FiNroBanco>("FiNrosBancos");
            builder.EntitySet<FiTipoCtaBanco>("FiTiposCtasBancos");
            builder.EntitySet<GeAplicacao>("GeAplicacoes");
            builder.EntitySet<GeEmpresa>("GeEmpresas");
            builder.EntitySet<GeEmpresaAplicacao>("GeEmpresasAplicacoes");
            builder.EntitySet<GeEmpresaConsol>("GeEmpresasConsols");
            builder.EntitySet<GeGrupo>("GeGrupos");
            builder.EntitySet<GeGrupoProcesso>("GeGruposProcessos");
            builder.EntitySet<GeMvcWebProcesso>("GeMvcWebProcessos");
            builder.EntitySet<GeParametro>("GeParametros");
            builder.EntitySet<GeProcesso>("GeProcessos");
            builder.EntitySet<GeSessaoUsuario>("GeSessoesUsuarios");
            builder.EntitySet<GeTipoProcesso>("GeTiposProcessos");
            builder.EntitySet<GeTmpValor>("GeTmpValores");
            builder.EntitySet<GeTmpValorDet>("GeTmpValoresDet");
            builder.EntitySet<GeUsuario>("GeUsuarios");
            builder.EntitySet<GeUsuarioAplicacao>("GeUsuariosAplicacoes");
            builder.EntitySet<GeUsuarioGrupo>("GeUsuariosGrupos");
            builder.EntitySet<GeUsuarioProcesso>("GeUsuariosProcessos");
            builder.EntitySet<RgEstado>("RgEstados");
            builder.EntitySet<RgMunicipio>("RgMunicipios");
            builder.EntitySet<RgNatureza>("RgNaturezas");
            builder.EntitySet<RgRegGeral>("RgRegGerais");
            builder.EntitySet<RgRegGeralNatureza>("RgRegGeraisNaturezas");
            builder.EntitySet<RgRegiao>("RgRegioes");
            builder.EntitySet<RgStatus>("RgStatusCollection");
            builder.EntitySet<RgTelefone>("RgTelefones");
            builder.EntitySet<RgTipoFone>("RgTiposFones");
            builder.EntitySet<RgTipoRg>("RgTiposRgs");
            builder.EntitySet<RgTmpAniversariante>("RgTmpAniversariantes");
            builder.EntitySet<RgEndereco>("RgEnderecos");
            builder.EntitySet<RgFisicaJuridica>("RgFisicasJuridicas");
            builder.EntitySet<RgParamRegGeral>("RgParamRegsGerais");

            var edmModel = builder.GetEdmModel();
            return edmModel;
        }
    }
}
