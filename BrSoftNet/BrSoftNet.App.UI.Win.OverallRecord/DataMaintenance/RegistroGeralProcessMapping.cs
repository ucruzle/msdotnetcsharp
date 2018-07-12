using BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects;
using System;
using System.Collections.Generic;

namespace BrSoftNet.App.UI.Win.OverallRecord.DataMaintenance
{
    [Serializable]
    public class RegistroGeralProcessMapping
    {
        public List<RgRegGeral> RgRegGerais { get; set; }
        public List<RgEndereco> RgEnderecos { get; set; }
        public List<RgTelefone> RgTelefones { get; set; }
        public List<RgRegGeralNatureza> RgRegGeralNaturezas { get; set; }
        public List<RgFisicaJuridica> RgFisicasJuridicas { get; set; }
    }
}
