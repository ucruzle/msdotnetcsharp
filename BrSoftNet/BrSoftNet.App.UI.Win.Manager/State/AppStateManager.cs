using BrSoftNet.App.Business.Processes.Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.UI.Win.Manager.State
{
    public static class AppStateManager
    {
        public static int IdTipoProcesso { get; set; }
        public static List<ProcessoGerenciador> ProcessoGerenciadorCollection { get; set; }
        public static List<ParametroGerenciador> ParametroGerenciadorCollection { get; set; }
        public static List<GeGrupo> GeGrupoCollection { get; set; }
        public static List<GeUsuario> GeUsuarioCollection { get; set; }
        public static List<GeEmpresaConsolidada> GeEmpresaConsolidadaCollection { get; set; }
        public static List<GeProcesso> GeProcessoCollection { get; set; }
        public static List<GeTipoProcesso> GeTipoProcessoCollection { get; set; }
        public static List<GeUsuarioGrupo> GeUsuarioGrupoCollection { get; set; }
        public static List<GeAplicacao> GeAplicacaoCollection { get; set; }
        public static List<GrupoProcessoPorFiltro> GeGrupoProcessoCollection { get; set; }
        public static List<GeEmpresa> GeEmpresaCollection { get; set; }
        public static List<GeEmpresaAplicacao> GeEmpresaAplicacaoCollection { get; set; }
        public static int CodigoProcesso { get; set; }
        public static int CodigoAplicacao { get; set; }
        public static string DescricaoAplicacao { get; set; }
        public static string SiglaAplicacao { get; set; }
        public static string SequenciaAplicacao { get; set; }
        public static string AtivaAplicacao { get; set; }
        public static string FormAplicacao { get; set; }
        public static int CodigoGrupo { get; set; }
        public static string DescricaoGrupo { get; set; }
        public static int CodigoEmpresaConsolidada { get; set; }
        public static string DescricaoEmpresaConsolidada { get; set; }
        public static string AtivaEmpresaConsolidada { get; set; }
        public static int IdTabela { get; set; }
        public static string DirLogoEmpresa { get; set; }
        public static string DirPgmRelatorio { get; set; }
        public static string DirRelatorio { get; set; }
        public static string DirBackup { get; set; }
        public static string DirScript { get; set; }
        public static string DirImportacao { get; set; }
        public static string DirExportacaoExcel { get; set; }
        public static int IdTipoProcEsp { get; set; }
        public static int IdTipoProcInt { get; set; }
        public static string MostraFormMenu { get; set; }
        public static string DirFoto { get; set; }
        public static string DirServidor { get; set; }
        public static string Usuario { get; set; }
        public static string Nome { get; set; }
        public static int CodigoEmpresa { get; set; }
        public static string DescricaoEmpresa { get; set; }
        public static int CodigoRG { get; set; }
        public static string StatusDBA { get; set; }
        public static DateTime DataCadastro { get; set; }
        public static string Senha { get; set; }
        public static string Ramal { get; set; }
        public static string Ativo { get; set; }
        public static string UsuarioIncl { get; set; }
        public static string DescricaoProcesso { get; set; }
        public static string DescricaoTipoProcesso { get; set; }
        public static int CodigoTipoProcesso { get; set; }
        public static int SequenciaTipoProcesso { get; set; }
        public static string Form { get; set; }
        public static int SequenciaProcesso { get; set; }
        public static int CodigoEmpresaLiberacaoUsuario { get; set; }
        public static int CodigoAplicacaoLiberacaoUsuario { get; set; }
        public static string UsuarioLiberacaoUsuario { get; set; }
        public static int CodigoTipoProcessoLiberacaoUsuario { get; set; }
        public static int CodigoEmpresaGrupoProcesso { get; set; }
        public static int CodigoAplicacaoGrupoProcesso { get; set; }
        public static int CodigoGrupoProcesso { get; set; }
        public static int CodigoTipoProcessoGrupoProcesso { get; set; }
        public static List<GeUsuarioProcesso> UsuarioProcessoCollection { get; set; }
        public static List<ProcessoLiberacaoUsuario> ProcessoLiberacaoUsuarioCollection { get; set; }
        public static List<ProcessoGrupoProcesso> ProcessoGrupoProcessoCollection { get; set; }
        public static List<GeGrupoProcesso> GrupoProcessoCollection { get; set; }
        public static List<LiberacaoUsuarioPorFiltro> LiberacaoUsuarioPorFiltroCollection { get; set; }
        public static GeTipoProcesso GeTipoProcessoModifyProcess { get; set; }
        public static int CodigoEmpresaPorVinculo { get; set; }
        public static int CodigoApicacaoPorVinculo { get; set; }
        public static int CodigoEmpresaUsuarioGrupo { get; set; }
        public static string UserUsuarioGrupo { get; set; }
        public static int CodigoGrupoUsuarioGrupo { get; set; }
        public static int CodigoTipoProcessoPorVinculo { get; set; }
        public static int CodigoApicacaoProcessoPorVinculo { get; set; }
        public static int CodigoIntegracaoRegGeralPorVinculo { get; set; }
        public static int CodigoEmpresaRegGeralPorVinculo { get; set; }
        public static int CodigoEmpresaConsolidadaRegGeralPorVinculo { get; set; }
    }
}
