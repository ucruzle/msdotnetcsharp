using System;
using System.Data;
using System.Xml.Serialization;

namespace BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects
{
    [Serializable]
    public class RgRegGeralNatureza
    {
        public int IdEmpr { get; set; }
        public int IdRg { get; set; }
        public int IdNatureza { get; set; }
        public int IdStatusNat { get; set; }
        public DateTime DataHora { get; set; }
        public string Usuario { get; set; }
        
        public RgRegGeralNatureza() { }

        public RgRegGeralNatureza(DataRow _Row) 
        {
            IdEmpr = int.Parse(_Row["cod_empr"].ToString());
            IdRg = int.Parse(_Row["cod_rg"].ToString());
            IdNatureza = int.Parse(_Row["cod_natureza"].ToString());
            IdStatusNat = int.Parse(_Row["cod_status_nat_rg"].ToString());
            DataHora = DateTime.Parse(_Row["data_hora"].ToString());
            Usuario = _Row["usuario"].ToString();
        }

        public RgRegGeralNatureza(int _IdEmpr, int _IdRg, int _IdNatureza, int _IdStatusNat, string _DataHora, string _Usuario)
        {
            IdEmpr = _IdEmpr;
            IdRg = _IdRg;
            IdNatureza = _IdNatureza;
            IdStatusNat = _IdStatusNat;
            DataHora = DateTime.Parse(_DataHora);
            Usuario = _Usuario;
        }
    }
}
