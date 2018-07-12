using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.Manager.Entities
{
    [Serializable]
    public class AplicacaoEmpresaLiberacao
    {
        #region Properties

        public int CodigoAplicacao { get; set; }

        public string DescricaoAplicacao { get; set; }        

        #endregion

        #region Constructors

        public AplicacaoEmpresaLiberacao(DataRow _Row) 
        {
            CodigoAplicacao = int.Parse(_Row["CodigoAplicacao"].ToString());
            DescricaoAplicacao = _Row["DescricaoAplicacao"].ToString();            
        }

        public AplicacaoEmpresaLiberacao() { }

        #endregion
    }
}
