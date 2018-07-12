using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.Security.Entities
{
    [Serializable]
    public class ProcessoLogin
    {
        #region Properties
        public int CodigoProcesso { get; set; }

        public string DescricaoProcesso { get; set; }

        #endregion

        #region Constructors

        public ProcessoLogin(DataRow _Row) 
        {
            CodigoProcesso = int.Parse(_Row["CodigoProcesso"].ToString());
            DescricaoProcesso = _Row["DescricaoProcesso"].ToString();
        }

        public ProcessoLogin() { }

        #endregion
    }
}
