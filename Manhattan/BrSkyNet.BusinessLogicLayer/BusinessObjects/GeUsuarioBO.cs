using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class GeUsuarioBO
    {
        [Dependency]
        public GeUsuarioDAO DAO { get; set; }

        public List<GeUsuario> ListarGeUsuarios()
        {
            List<GeUsuario> _GeUsuarios = DAO.ListarGeUsuarios();
            return _GeUsuarios;
        }

        public GeUsuario RecuperaGeUsuario(string _Usuario)
        {
            GeUsuario _Result = DAO.RecuperarGeUsuario(_Usuario);
            return _Result;
        }

        public void AdicionarGeUsuario(GeUsuario _GeUsuario)
        {
            DAO.Insert(_GeUsuario);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarGeUsuario(GeUsuario _GeUsuario)
        {
            DAO.Update(_GeUsuario);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarGeUsuario(string _Usuario)
        {
            GeUsuario _Result = null;

            _Result = DAO.FindByPrimaryKey(_Usuario);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
