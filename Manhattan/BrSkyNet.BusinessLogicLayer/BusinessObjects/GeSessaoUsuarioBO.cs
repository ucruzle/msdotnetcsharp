using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class GeSessaoUsuarioBO
    {
        [Dependency]
        public GeSessaoUsuarioDAO DAO { get; set; }

        public List<GeSessaoUsuario> ListarGeSessoesUsuarios()
        {
            List<GeSessaoUsuario> _GeSessoesUsuarios = DAO.ListarGeSessoesUsuarios();
            return _GeSessoesUsuarios;
        }

        public GeSessaoUsuario RecuperaGeSessaoUsuario(string _Usuario)
        {
            GeSessaoUsuario _Result = DAO.RecuperarGeSessaoUsuario(_Usuario);
            return _Result;
        }

        public void AdicionarGeSessaoUsuario(GeSessaoUsuario _GeSessaoUsuario)
        {
            DAO.Insert(_GeSessaoUsuario);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarGeSessaoUsuario(GeSessaoUsuario _GeSessaoUsuario)
        {
            DAO.Update(_GeSessaoUsuario);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarGeSessaoUsuario(string _Usuario)
        {
            GeSessaoUsuario _GeSessaoUsuario = null;

            _GeSessaoUsuario = DAO.FindByPrimaryKey(_Usuario);

            DAO.Delete(_GeSessaoUsuario);
            DAO.UnitOfWork.Commit();
        }
    }
}
