using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.Security.Entities
{
    [Serializable]
    public class NomeFantasiaLogin
    {
        #region Properties

        public string NomeFantasia { get; set; }

        #endregion

        #region Constructors

        public NomeFantasiaLogin(DataRow _Row) 
        {
            NomeFantasia = _Row["NomeFantasia"].ToString();
        }

        public NomeFantasiaLogin() { }

        #endregion
    }
}
