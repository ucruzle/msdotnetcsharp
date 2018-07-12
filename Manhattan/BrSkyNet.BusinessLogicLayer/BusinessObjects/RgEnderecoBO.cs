using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class RgEnderecoBO
    {
        [Dependency]
        public RgEnderecoDAO DAO { get; set; }

        public List<RgEndereco> ListarRgEnderecos()
        {
            List<RgEndereco> _RgEnderecos = DAO.ListarRgEnderecos();
            return _RgEnderecos;
        }

        public RgEndereco RecuperaRgEndereco(int _CodEmpr, int _CodRg)
        {
            RgEndereco _Result = DAO.RecuperarRgEndereco(_CodEmpr, _CodRg);
            return _Result;
        }

        public void AdicionarRgEndereco(RgEndereco _RgEndereco)
        {
            DAO.Insert(_RgEndereco);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarRgEndereco(RgEndereco _RgEndereco)
        {
            DAO.Update(_RgEndereco);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarRgEndereco(RgEndereco _RgEndereco)
        {
            RgEndereco _Result = null;

            _Result = DAO.FindByPrimaryKey(_RgEndereco.cod_empr, _RgEndereco.cod_rg);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
