using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class RgTipoRgBO
    {
        [Dependency]
        public RgTipoRgDAO DAO { get; set; }

        public List<RgTipoRg> ListarRgTiposRgs()
        {
            List<RgTipoRg> _RgTiposRgs = DAO.ListarRgTiposRgs();
            return _RgTiposRgs;
        }

        public RgTipoRg RecuperarRgTipoRg(string _TipoRg)
        {
            RgTipoRg _Result = DAO.RecuperarRgTipoRg(_TipoRg);
            return _Result;
        }

        public void AdicionarRgTipoRg(RgTipoRg _RgTipoRg)
        {
            DAO.Insert(_RgTipoRg);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarRgTipoRg(RgTipoRg _RgTipoRg)
        {
            DAO.Update(_RgTipoRg);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarRgTipoRg(string _TipoRg)
        {
            RgTipoRg _Result = null;
            _Result = DAO.FindByPrimaryKey(_TipoRg);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
