using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.Manager.Entities
{
    [Serializable]
    public class GeUsuarioProcesso
    {
        #region ...::: Properties :::...
        public int CodigoEmpresa { get; set; }

        public string Usuario { get; set; }

        public int CodigoProcesso { get; set; }

        #endregion

        #region ...::: Constructors :::...

        public GeUsuarioProcesso(DataRow _Row)
        {
            CodigoEmpresa = int.Parse(_Row["cod_empr"].ToString());
            Usuario = _Row["usuario"].ToString();
            CodigoProcesso = int.Parse(_Row["cod_proc"].ToString());
        }

        public GeUsuarioProcesso(int _CodigoEmpresa, string _Usuario, int _CodigoProcesso) 
        {
            CodigoEmpresa = _CodigoEmpresa;
            Usuario = _Usuario;
            CodigoProcesso = _CodigoProcesso;
        }
        
        public GeUsuarioProcesso() { }

        #endregion
    }
}
