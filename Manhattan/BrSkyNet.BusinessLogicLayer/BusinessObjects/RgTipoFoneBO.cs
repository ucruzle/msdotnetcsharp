using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class RgTipoFoneBO
    {
        [Dependency]
        public RgTipoFoneDAO DAO { get; set; }

        public List<RgTipoFone> ListarRgTiposFones()
        {
            List<RgTipoFone> _RgTelefones = DAO.ListarRgTiposFones();
            return _RgTelefones;
        }

        public RgTipoFone RecuperarRgTipoFone(int _CodTipoFone)
        {
            RgTipoFone _Result = DAO.RecuperarRgTipoFone(_CodTipoFone);
            return _Result;
        }

        public void AdicionarRgTipoFone(RgTipoFone _RgTipoFone)
        {
            DAO.Insert(_RgTipoFone);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarRgTipoFone(RgTipoFone _RgTipoFone)
        {
            DAO.Update(_RgTipoFone);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarRgTipoFone(int _CodTipoFone)
        {
            RgTipoFone _Result = null;
            _Result = DAO.FindByPrimaryKey(_CodTipoFone);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
