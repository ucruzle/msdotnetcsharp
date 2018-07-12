using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class GeMvcWebProcessoBO
    {
        [Dependency]
        public GeMvcWebProcessoDAO DAO { get; set; }

        public List<GeMvcWebProcesso> ListarGeMvcWebProcessos()
        {
            List<GeMvcWebProcesso> _GeMvcWebProcessos = DAO.ListarGeMvcWebProcessos();
            return _GeMvcWebProcessos;
        }

        public GeMvcWebProcesso RecuperaGeMvcWebProcesso(int _CodProc)
        {
            GeMvcWebProcesso _Result = DAO.RecuperarGeMvcWebProcesso(_CodProc);
            return _Result;
        }

        public void AdicionarGeMvcWebProcesso(GeMvcWebProcesso _GeMvcWebProcesso)
        {
            DAO.Insert(_GeMvcWebProcesso);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarGeMvcWebProcesso(GeMvcWebProcesso _GeMvcWebProcesso)
        {
            DAO.Update(_GeMvcWebProcesso);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarGeMvcWebProcesso(int _CodProc)
        {
            GeMvcWebProcesso _Result = null;

            _Result = DAO.FindByPrimaryKey(_CodProc);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
