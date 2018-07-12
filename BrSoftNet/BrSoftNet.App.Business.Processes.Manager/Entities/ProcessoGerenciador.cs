using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.Manager.Entities
{
    [Serializable]
    public class ProcessoGerenciador
    {
        #region Properties
        public int CodigoProcesso { get; set; }

        public string DescricaoProcesso { get; set; }

        #endregion

        #region Constructors

        public ProcessoGerenciador(DataRow _Row) 
        {
            CodigoProcesso = int.Parse(_Row["CodigoProcesso"].ToString());
            DescricaoProcesso = _Row["DescricaoProcesso"].ToString();
        }

        public ProcessoGerenciador() { }

        #endregion
    }
}
