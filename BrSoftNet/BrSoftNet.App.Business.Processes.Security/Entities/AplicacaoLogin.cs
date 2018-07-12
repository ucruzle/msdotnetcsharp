using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BrSoftNet.App.Business.Processes.Security.Entities
{
    [Serializable]
    public class AplicacaoLogin
    {
        #region Properties

        public int CodigoAplicacao { get; set; }

        public string DescricaoAplicacao { get; set; }        

        #endregion

        #region Constructors

        public AplicacaoLogin(DataRow _Row) 
        {
            CodigoAplicacao = int.Parse(_Row["CodigoAplicacao"].ToString());
            DescricaoAplicacao = _Row["DescricaoAplicacao"].ToString();            
        }

        public AplicacaoLogin() { }

        #endregion
    }
}
