using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.Business.Processes.Manager.Entities
{
    public class GeEmpresaAplicacao
    {
        #region ...::: Properties / Propriedades :::...
        public int CodigoEmpresa { get; set; }
        public string DescricaoEmpresa { get; set; }
        public int CodigoAplicacao { get; set; }
        public string DescricaoAplicacao { get; set; }
       

        #endregion

        #region ...::: Constructors / Construtores
        public GeEmpresaAplicacao(DataRow _Row)
        {
            CodigoEmpresa = int.Parse(_Row["cod_empr"].ToString());
            CodigoAplicacao = int.Parse(_Row["cod_aplic"].ToString());
            DescricaoEmpresa = _Row["descr_empr"].ToString();
            DescricaoAplicacao = _Row["descr_aplic"].ToString();
        }

        public GeEmpresaAplicacao(int _CodigoEmpresa, int _CodigoAplicacao)
        {
            CodigoEmpresa = _CodigoEmpresa;
            CodigoAplicacao = _CodigoAplicacao;
        }
        #endregion
    }
}
