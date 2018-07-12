using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.Business.Processes.Manager.Entities
{
    [Serializable]
    public class GeGrupo
    {
         #region Properties
        public int CodigoGrupo { get; set; }

        public string DescricaoGrupo { get; set; }

        #endregion

        #region Constructors

        public GeGrupo(DataRow _Row) 
        {
            CodigoGrupo = int.Parse(_Row["cod_grupo"].ToString());
            DescricaoGrupo = _Row["descr_grupo"].ToString();
        }

        public GeGrupo() { }

        #endregion
    }
}
