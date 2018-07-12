using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.Security.Entities
{
    [Serializable]
    public class EmpresaLogin
    {
        #region Properties

        public int CodigoEmpresa { get; set; }

        public string NomeFantasia { get; set; }

        #endregion

        #region Constructors

        public EmpresaLogin(DataRow _Row) 
        {
            CodigoEmpresa = int.Parse(_Row["CodigoEmpresa"].ToString());
            NomeFantasia = _Row["NomeFantasia"].ToString();
        }

        public EmpresaLogin() { }

        #endregion
    }
}
