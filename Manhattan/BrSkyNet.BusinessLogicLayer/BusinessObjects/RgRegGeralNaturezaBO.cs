using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class RgRegGeralNaturezaBO
    {
        [Dependency]
        public RgRegGeralNaturezaDAO DAO { get; set; }

        public List<RgRegGeralNatureza> ListarRgRegGeraisNaturezas()
        {
            List<RgRegGeralNatureza> _RgRegGeraisNaturezas = DAO.ListarRgRegGeraisNaturezas();
            return _RgRegGeraisNaturezas;
        }

        public RgRegGeralNatureza RecuperarRgRegGeralNatureza(int _CodEmpr, int _CodRg, int _CodNatureza)
        {
            RgRegGeralNatureza _Result = DAO.RecuperarRgRegGeralNatureza(_CodEmpr, _CodRg, _CodNatureza);
            return _Result;
        }

        public void AdicionarRgRegGeralNatureza(RgRegGeralNatureza _RgRegGeralNatureza)
        {
            DAO.Insert(_RgRegGeralNatureza);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarRgRegGeralNatureza(RgRegGeralNatureza _RgRegGeralNatureza)
        {
            DAO.Update(_RgRegGeralNatureza);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarRgRegGeralNatureza(RgRegGeralNatureza _RgRegGeralNatureza)
        {
            RgRegGeralNatureza _Result = null;

            _Result = DAO.FindByPrimaryKey(_RgRegGeralNatureza.cod_empr, 
                                           _RgRegGeralNatureza.cod_rg, 
                                           _RgRegGeralNatureza.cod_natureza);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
