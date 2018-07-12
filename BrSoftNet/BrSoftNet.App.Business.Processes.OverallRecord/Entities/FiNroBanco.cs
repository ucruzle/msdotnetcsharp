using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects
{
    [Serializable]
    public class FiNroBanco
    {
        public int IdNroBanco { get; set; }

        public string DescrNroBanco { get; set; }

        public string DescrNroBancoRed { get; set; }
        public FiNroBanco() { }

        public FiNroBanco(DataRow _Row) 
        {
            IdNroBanco = int.Parse(_Row["nro_banco"].ToString());
            DescrNroBanco = _Row["descr_nro_banco"].ToString();
            DescrNroBancoRed = _Row["descr_nro_banco_red"].ToString();
        }

        public FiNroBanco(int _IdNroBanco, string _DescrNroBanco, string _DescrNroBancoRed)
        {
            IdNroBanco = _IdNroBanco;
            DescrNroBanco = _DescrNroBanco;
            DescrNroBancoRed = _DescrNroBancoRed;
        }
    }
}
