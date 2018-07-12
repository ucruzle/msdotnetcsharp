using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.Business.Processes.Manager.Entities
{
    [Serializable]
    public class GeUsuarioGrupo
    {
        #region Properties
        public int CodigoEmpresa { get; set; }

        public int CodigoGrupo { get; set; }

        public string Usuario { get; set; }

        #endregion

        #region Constructors

        public GeUsuarioGrupo(DataRow _Row) 
        {
            CodigoEmpresa = int.Parse(_Row["cod_empr"].ToString());
            CodigoGrupo = int.Parse(_Row["cod_grupo"].ToString());
            Usuario = _Row["usuario"].ToString();
        }

        public GeUsuarioGrupo() { }

        #endregion
    }
}
