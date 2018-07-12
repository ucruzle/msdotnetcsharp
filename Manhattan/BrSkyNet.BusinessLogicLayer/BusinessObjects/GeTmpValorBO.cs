using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class GeTmpValorBO
    {
        [Dependency]
        public GeTmpValorDAO DAO { get; set; }

        public List<GeTmpValor> ListarGeTmpValores()
        {
            List<GeTmpValor> _GeTmpValores = DAO.ListarGeTmpValores();
            return _GeTmpValores;
        }

        public GeTmpValor RecuperaGeTmpValor(string _Usuario)
        {
            GeTmpValor _Result = DAO.RecuperarGeTmpValor(_Usuario);
            return _Result;
        }

        public void AdicionarGeTmpValor(GeTmpValor _GeTmpValor)
        {
            DAO.Insert(_GeTmpValor);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarGeTmpValor(GeTmpValor _GeTmpValor)
        {
            DAO.Update(_GeTmpValor);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarGeTmpValor(string _Usuario)
        {
            GeTmpValor _GeTmpValor = null;

            _GeTmpValor = DAO.FindByPrimaryKey(_Usuario);

            DAO.Delete(_GeTmpValor);
            DAO.UnitOfWork.Commit();
        }
    }
}
