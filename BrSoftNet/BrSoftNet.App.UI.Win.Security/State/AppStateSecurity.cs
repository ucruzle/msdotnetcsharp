using BrSoftNet.App.Business.Processes.Security.Entities;
using System.Collections.Generic;

namespace BrSoftNet.App.UI.Win.Main.State
{
    public static class AppStateSecurity
    {
        public static string Usuario { get; set; }

        public static string Senha { get; set; }

        public static string Nome { get; set; }

        public static int CodigoEmpresa { get; set; }

        public static string NomeFantasia { get; set; }

        public static List<EmpresaLogin> EmpresaLoginCollection { get; set; }

        public static int CodigoAplicacao { get; set; }

        public static List<AplicacaoLogin> AplicacaoLoginCollection { get; set; }

        public static string NomeAplicacao { get; set; }

        public static int CodigoTipoProcesso { get; set; }

        public static List<TipoProcessoLogin> TipoProcessoCollection { get; set; }

        public static int CodigoProcesso { get; set; }

        public static List<ProcessoLogin> ProcessoCollection { get; set; }

        public static int CodigoMunicipio { get; set; }

        public static int CodigoNatureza { get; set; }

        public static int CodigoStatus { get; set; }

        public static int CodigoTipoFone { get; set; }

        public static int CodigoRegGeral { get; set; }

        public static int CodigoTipoRg { get; set; }

        public static int CodigoGrupo { get; set; }
    }
}
