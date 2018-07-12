using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.Security.Entities
{
    [Serializable]
    public class NomeAplicacaoLogin
    {
        #region Properties

        public string NomeApplicacao { get; set; }

        #endregion

        #region Constructors

        public NomeAplicacaoLogin(DataRow _Row) 
        {
            NomeApplicacao = _Row["NomeApplicacao"].ToString();
        }

        public NomeAplicacaoLogin() { }

        #endregion
    }
}
