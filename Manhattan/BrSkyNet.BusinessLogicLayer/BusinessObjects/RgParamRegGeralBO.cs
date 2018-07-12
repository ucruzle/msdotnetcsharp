using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class RgParamRegGeralBO
    {
        [Dependency]
        public RgParamRegGeralDAO DAO { get; set; }

        public List<RgParamRegGeral> ListarRgParamRegsGerais()
        {
            List<RgParamRegGeral> _RgParamRegsGerais = DAO.ListarRgParamRegsGerais();
            return _RgParamRegsGerais;
        }

        public RgParamRegGeral RecuperaRgParamRegGeral(int _CodEmpr)
        {
            RgParamRegGeral _Result = DAO.RecuperarRgParamRegGeral(_CodEmpr);
            return _Result;
        }

        public void AdicionarRgParamRegGeral(RgParamRegGeral _RgParamRegGeral)
        {
            DAO.Insert(_RgParamRegGeral);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarRgParamRegGeral(RgParamRegGeral _RgParamRegGeral)
        {
            DAO.Update(_RgParamRegGeral);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarRgParamRegGeral(int _CodEmpr)
        {
            RgParamRegGeral _Result = null;

            _Result = DAO.FindByPrimaryKey(_CodEmpr);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
