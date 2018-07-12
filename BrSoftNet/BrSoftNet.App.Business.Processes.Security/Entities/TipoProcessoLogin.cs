using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.Security.Entities
{
    [Serializable]
    public class TipoProcessoLogin
    {
        #region Properties
        public int CodigoTipoProcesso { get; set; }
        public string DescricaoTipoProcesso { get; set; }        

        #endregion

        #region Constructors

        public TipoProcessoLogin(DataRow _Row) 
        {
            CodigoTipoProcesso = int.Parse(_Row["CodigoTipoProcesso"].ToString());
            DescricaoTipoProcesso = _Row["DescricaoTipoProcesso"].ToString();
        }

        public TipoProcessoLogin() { }

        #endregion
    }
}
