using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.Manager.Entities
{
    [Serializable]
    public class GeTipoProcesso
    {
        #region ...::: Properties :::...

        public int CodigoTipoProcesso { get; set; }
        public string DescricaoTipoProcesso { get; set; }
        public int SequequenciaTipoProcesso { get; set; }   

        #endregion

        #region Constructors

        public GeTipoProcesso(DataRow _Row) 
        {
            CodigoTipoProcesso = int.Parse(_Row["cod_tipo_proc"].ToString());
            DescricaoTipoProcesso = _Row["descr_tipo_proc"].ToString();
            SequequenciaTipoProcesso = int.Parse(_Row["sequ_tipo_proc"].ToString());
        }

        public GeTipoProcesso() { }

        public GeTipoProcesso(Int32 _CodTipoProcesso, string _DescrTipoProcesso)
        {
            CodigoTipoProcesso = _CodTipoProcesso;
            DescricaoTipoProcesso = _DescrTipoProcesso;

        }

        #endregion
    }
}
