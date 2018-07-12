using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class GeUsuarioProcessoBO
    {
        [Dependency]
        public GeUsuarioProcessoDAO DAO { get; set; }

        public List<GeUsuarioProcesso> ListarGeUsuariosProcessos()
        {
            List<GeUsuarioProcesso> _GeUsuariosProcessos = DAO.ListarGeUsuariosProcessos();
            return _GeUsuariosProcessos;
        }

        public GeUsuarioProcesso RecuperaGeUsuarioProcesso(int _CodEmpr, string _Usuario, int _CodProc)
        {
            GeUsuarioProcesso _Result = DAO.RecuperarGeUsuarioProcesso(_CodEmpr, _Usuario, _CodProc);
            return _Result;
        }

        public void AdicionarGeUsuarioProcesso(GeUsuarioProcesso _GeUsuarioProcesso)
        {
            DAO.Insert(_GeUsuarioProcesso);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarGeUsuarioProcesso(GeUsuarioProcesso _GeUsuarioProcesso)
        {
            GeUsuarioProcesso _Result = null;

            _Result = DAO.FindByPrimaryKey(_GeUsuarioProcesso.cod_empr,
                                           _GeUsuarioProcesso.usuario,
                                           _GeUsuarioProcesso.cod_proc);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
