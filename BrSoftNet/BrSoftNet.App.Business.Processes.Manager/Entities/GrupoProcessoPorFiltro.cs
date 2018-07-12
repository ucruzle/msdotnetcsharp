using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.Business.Processes.Manager.Entities
{
    [Serializable]
    public class GrupoProcessoPorFiltro
    {
        #region ...::: Properties :::...

        public int CodigoEmpresa { get; set; }

        public string DescricaoEmpresa { get; set; }

        public int CodigoAplicacao { get; set; }

        public string DescricaoAplicacao { get; set; }

        public int CodigoGrupo { get; set; }

        public string DescricaoGrupo { get; set; }

        public int CodigoTipoProcesso { get; set; }

        public string DescricaoTipoProcesso { get; set; }

        public int CodigoProcesso { get; set; }

        public string DescricaoProcesso { get; set; }

        #endregion

        #region ...::: Constructors :::...

        public GrupoProcessoPorFiltro(DataRow _Row) 
        {
            CodigoEmpresa = int.Parse(_Row["CodigoEmpresa"].ToString());
            DescricaoEmpresa = _Row["DescricaoEmpresa"].ToString();
            CodigoAplicacao = int.Parse(_Row["CodigoAplicacao"].ToString());
            DescricaoAplicacao = _Row["DescricaoAplicacao"].ToString();
            CodigoGrupo = int.Parse(_Row["cod_grupo"].ToString());
            DescricaoGrupo = _Row["descr_grupo"].ToString();
            CodigoTipoProcesso = int.Parse(_Row["codigoTipoProcesso"].ToString());
            DescricaoTipoProcesso = _Row["DescricaoTipoProcesso"].ToString();
            CodigoProcesso = int.Parse(_Row["CodigoProcesso"].ToString());
            DescricaoProcesso = _Row["DescricaoProcesso"].ToString();
        }

        public GrupoProcessoPorFiltro() { }

        #endregion
    }
}
