using BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects;
using BrSoftNet.App.Business.Processes.OverallRecord.Entities;
using BrSoftNet.App.UI.Win.OverallRecord.DataTransferProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.UI.Win.OverallRecord.State
{
    public static class AppStateOverallRecord
    {
        public static string Usuario { get; set; }
        public static int IdTipoProcesso { get; set; }
        public static int IdEmpresa { get; set; }
        public static int IdRegistro { get; set; }
        public static string SiglaRegiao { get; set; }
        public static string SiglaEstado { get; set; }
        public static int IdNatureza { get; set; }
        public static string DescrNatureza { get; set; }
        public static string DescricaoRegiao { get; set; }
        public static List<RgRegGeral> RgRegGeralCollection { get; set; }
        public static RgRegGeral RgRegGeral { get; set; }
        public static string TipoRg { get; set; }
        public static string DescrTipo { get; set; }
        public static int IdTipoFone { get; set; }
        public static string DescrTipoFone { get; set; }
        public static int IdRgStatus { get; set; }
        public static string DescrStatus { get; set; }
        public static RgRegiao RgRegiao { get; set; }
        public static List<RgRegiao> RgRegiaoCollection { get; set; }
        public static List<RgEstado> RgEstadoCollection { get; set; }
        public static List<RgParamRegGeral> RgParamRegGeralCollection { get; set; }
        public static RgEndereco RgEndereco { get; set; }
        public static List<RgTelefone> RgTelefoneCollection { get; set; }
        public static List<RgRegGeralNatureza> RgRegGeralNaturezaCollection { get; set; }
        public static RgFisicaJuridica RgFisicasJuridica { get; set; }
        public static List<RgNatureza> RgNaturezaCollection { get; set; }
        public static List<RgStatus> RgStatusCollection { get; set; }
        public static List<RgTipoRg> RgTipoRgCollection { get; set; }
        public static List<RgTipoFone> RgTipoFoneCollection { get; set; }
        public static List<RgMunicipio> RgMunicipioCollection { get; set; }
        public static RgTelefone RgTelefoneModifyProcess { get; set; }
        public static dsOverallRecordProcess.tblRgTelefoneRow TelefoneRow { get; set; }
        public static RgRegGeralNatureza RgRegGeralNaturezaModifyProcess { get; set; }
        public static RgRegiao RgRegiaoModifyProcess { get; set; }
        public static dsOverallRecordProcess.tblRgNaturezaRow RegGeralNaturezaRow { get; set; }
        public static int CodigoEmpresa { get; set; }
        public static int IdMunicipio { get; set; }
        public static string Municipio { get; set; }
        public static string UF { get; set; }
        public static RgEstado RgEstadoModifyProcess { get; set; }
        public static int CodigoEmpresaNaturesaStatusPorVinculo { get; set; }

    }
}
