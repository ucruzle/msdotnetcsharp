using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.Manager.Entities
{
    [Serializable]
    public class EmpresaGrupoProcesso
    {
        #region Properties

        public int CodigoEmpresa { get; set; }

        public string NomeFantasia { get; set; }

        #endregion

        #region Constructors

        public EmpresaGrupoProcesso(DataRow _Row) 
        {
            CodigoEmpresa = int.Parse(_Row["CodigoEmpresa"].ToString());
            NomeFantasia = _Row["NomeFantasia"].ToString();
        }

        public EmpresaGrupoProcesso() { }

        #endregion
    }
}
