using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class RgStatusBO
    {
        [Dependency]
        public RgStatusDAO DAO { get; set; }

        public List<RgStatus> ListarRgStatusCollection()
        {
            List<RgStatus> _RgStatusCollection = DAO.ListarRgStatusCollection();
            return _RgStatusCollection;
        }

        public RgStatus RecuperarRgStatus(int _CodStatus)
        {
            RgStatus _Result = DAO.RecuperarRgStatus(_CodStatus);
            return _Result;
        }

        public void AdicionarRgStatus(RgStatus _RgStatus)
        {
            DAO.Insert(_RgStatus);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarRgStatus(RgStatus _RgStatus)
        {
            DAO.Update(_RgStatus);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarRgStatus(int _CodStatus)
        {
            RgStatus _Result = null;
            _Result = DAO.FindByPrimaryKey(_CodStatus);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
