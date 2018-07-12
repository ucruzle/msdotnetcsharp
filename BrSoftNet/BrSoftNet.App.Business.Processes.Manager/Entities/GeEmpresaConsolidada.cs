using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.Business.Processes.Manager.Entities
{
    [Serializable]
    public class GeEmpresaConsolidada
    {
        #region Properties
        public int CodigoEmpresaConsolidada { get; set; }

        public string DescricaoEmpresaConsolidada { get; set; }

        public string AtivaEmpresaConsolidada { get; set; }

        #endregion

        #region Constructors

        public GeEmpresaConsolidada(DataRow _Row) 
        {
            CodigoEmpresaConsolidada = int.Parse(_Row["cod_empr_consol"].ToString());
            DescricaoEmpresaConsolidada = _Row["descr_empr_consol"].ToString();
            AtivaEmpresaConsolidada = _Row["ativa"].ToString();
        }

        public GeEmpresaConsolidada() { }

        #endregion
    }
}
