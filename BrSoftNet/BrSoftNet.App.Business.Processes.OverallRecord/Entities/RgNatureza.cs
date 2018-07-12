using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects
{
    [Serializable]
    public class RgNatureza
    {
        public int IdNatureza { get; set; }
        public string DescrNatureza { get; set; }

        public RgNatureza() { }

        public RgNatureza(DataRow _Row) 
        {
            IdNatureza = int.Parse(_Row["cod_natureza"].ToString());
            DescrNatureza = _Row["descr_natureza"].ToString();
        }

        public RgNatureza(int _IdNatureza, string _DescrNatureza)
        {
            IdNatureza = _IdNatureza;
            DescrNatureza = _DescrNatureza;
        }
    }
   
}
