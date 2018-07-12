using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class RgNaturezaBO
    {
        [Dependency]
        public RgNaturezaDAO DAO { get; set; }

        public List<RgNatureza> ListarRgNaturezas()
        {
            List<RgNatureza> _RgNaturezas = DAO.ListarRgNaturezas();
            return _RgNaturezas;
        }

        public RgNatureza RecuperarRgNatureza(int _CodNatureza)
        {
            RgNatureza _Result = DAO.RecuperarRgNatureza(_CodNatureza);
            return _Result;
        }

        public void AdicionarRgNatureza(RgNatureza _RgNatureza)
        {
            DAO.Insert(_RgNatureza);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarRgNatureza(RgNatureza _RgNatureza)
        {
            DAO.Update(_RgNatureza);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarRgNatureza(int _CodNatureza)
        {
            RgNatureza _Result = null;

            _Result = DAO.FindByPrimaryKey(_CodNatureza);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
