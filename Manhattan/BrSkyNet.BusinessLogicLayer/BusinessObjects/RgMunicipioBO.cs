using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class RgMunicipioBO
    {
        [Dependency]
        public RgMunicipioDAO DAO { get; set; }

        public List<RgMunicipio> ListarRgMunicipios()
        {
            List<RgMunicipio> _RgMunicipios = DAO.ListarRgMunicipios();
            return _RgMunicipios;
        }

        public RgMunicipio RecuperarRgMunicipio(int _CodMunicipio)
        {
            RgMunicipio _Result = DAO.RecuperarRgMunicipio(_CodMunicipio);
            return _Result;
        }

        public void AdicionarRgMunicipio(RgMunicipio _RgMunicipio)
        {
            DAO.Insert(_RgMunicipio);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarRgMunicipio(RgMunicipio _RgMunicipio)
        {
            DAO.Update(_RgMunicipio);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarRgEstado(int _CodMunicipio)
        {
            RgMunicipio _Result = null;

            _Result = DAO.FindByPrimaryKey(_CodMunicipio);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
