using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class RgRegGeralBO
    {
        [Dependency]
        public RgRegGeralDAO DAO { get; set; }

        public List<RgRegGeral> ListarRgRegGerais()
        {
            List<RgRegGeral> _RgRegGerais = DAO.ListarRgRegGerais();
            return _RgRegGerais;
        }

        public RgRegGeral RecuperaRgRegGeral(int _CodEmpr, int _codRg) 
        {
            RgRegGeral _Result = null;
            _Result = DAO.FindByPrimaryKey(_CodEmpr, _codRg);
            return _Result;
        }

        public void AdicionaRgRegGeal(RgRegGeral _RgRegGeral) 
        {
            DAO.Insert(_RgRegGeral);
            DAO.UnitOfWork.Commit();
        }

        public void AlteraRgRegGeal(RgRegGeral _RgRegGeral)
        {
            DAO.Update(_RgRegGeral);
            DAO.UnitOfWork.Commit();
        }

        public void EliminaRgRegGeal(RgRegGeral _RgRegGeral)
        {
            RgRegGeral _Result = DAO.FindByPrimaryKey(_RgRegGeral.cod_empr, _RgRegGeral.cod_rg);
            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
