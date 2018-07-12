using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects
{
    [Serializable]
    public class RgMunicipio
    {
        public int IdMunicipio { get; set; }

        public string Municipio { get; set; }

        public string UF { get; set; }

        public RgMunicipio() { }

        public RgMunicipio(DataRow _Row) 
        {
            IdMunicipio = int.Parse(_Row["cod_municipio"].ToString());
            Municipio = _Row["municipio"].ToString();
            UF = _Row["sigla_estado"].ToString();
        }

        public RgMunicipio(int _IdMunicipio, string _DescrEstado, string _UF) 
        {
	        IdMunicipio = _IdMunicipio;
	        Municipio = _DescrEstado;
	        UF = _UF;
        }
    }
}
