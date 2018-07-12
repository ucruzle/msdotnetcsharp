using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.Business.Processes.Manager.Entities
{
    [Serializable]
    public class GeGrupoProcesso
    {
        #region Properties
        public int CodigoEmpresa { get; set; }

        public int CodigoGrupo { get; set; }

        public int CodigoProcesso{ get; set; }

        #endregion

        #region Constructors

        public GeGrupoProcesso(DataRow _Row) 
        {
            CodigoEmpresa = int.Parse(_Row["cod_empr"].ToString());
            CodigoGrupo = int.Parse(_Row["cod_grupo"].ToString());
            CodigoProcesso = int.Parse(_Row["cod_proc"].ToString());
        }

        public GeGrupoProcesso(int _CodigoEmpresa, int _CodigoGrupo, int _CodigoProcesso) 
        {
            CodigoEmpresa = _CodigoEmpresa;
            CodigoGrupo = _CodigoGrupo;
            CodigoProcesso = _CodigoProcesso;
        }

        public GeGrupoProcesso() { }

        #endregion
    }
}
