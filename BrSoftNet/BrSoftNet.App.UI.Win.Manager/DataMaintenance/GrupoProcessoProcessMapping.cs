using BrSoftNet.App.Business.Processes.Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.UI.Win.Manager.DataMaintenance
{
    [Serializable]
    public class GrupoProcessoProcessMapping
    {
        public List<GeGrupoProcesso> GrupoProcessos { get; set; }
    }
}
