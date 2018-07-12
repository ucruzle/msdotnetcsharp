using System.Data;

namespace BrSoftNet.App.Business.Processes.Manager.Entities
{
    public class LiberacaoUsuarioPorFiltro
    {
        #region ...::: Properties :::...

        public int CodigoEmpresa { get; set; }

        public string DescricaoEmpresa { get; set; }

        public int CodigoAplicacao { get; set; }

        public string DescricaoAplicacao { get; set; }

        public string Usuario { get; set; }

        public int CodigoTipoProcesso { get; set; }

        public string DescricaoTipoProcesso { get; set; }

        public int CodigoProcesso { get; set; }

        public string DescricaoProcesso { get; set; }

        #endregion

        #region ...::: Constructors :::...

        public LiberacaoUsuarioPorFiltro(DataRow _Row) 
        {
            CodigoEmpresa = int.Parse(_Row["CodigoEmpresa"].ToString());
            DescricaoEmpresa = _Row["DescricaoEmpresa"].ToString();
            CodigoAplicacao = int.Parse(_Row["CodigoAplicacao"].ToString());
            DescricaoAplicacao = _Row["DescricaoAplicacao"].ToString();
            Usuario = _Row["Usuario"].ToString();
            CodigoTipoProcesso = int.Parse(_Row["codigoTipoProcesso"].ToString());
            DescricaoTipoProcesso = _Row["DescricaoTipoProcesso"].ToString();
            CodigoProcesso = int.Parse(_Row["CodigoProcesso"].ToString());
            DescricaoProcesso = _Row["DescricaoProcesso"].ToString();
        }

        public LiberacaoUsuarioPorFiltro() { }

        #endregion
    }
}
