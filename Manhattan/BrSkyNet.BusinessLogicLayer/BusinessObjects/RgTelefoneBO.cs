using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class RgTelefoneBO
    {
        [Dependency]
        public RgTelefoneDAO DAO { get; set; }

        public List<RgTelefone> ListarRgTelefones()
        {
            List<RgTelefone> _RgTelefones = DAO.ListarRgTelefones();
            return _RgTelefones;
        }

        public RgTelefone RecuperarRgTelefone(int _CodEmpr, int _CodRg, int _Seq_tel)
        {
            RgTelefone _Result = DAO.RecuperarRgTelefone(_CodEmpr, _CodRg, _Seq_tel);
            return _Result;
        }

        public void AdicionarRgTelefone(RgTelefone _RgTelefone)
        {
            DAO.Insert(_RgTelefone);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarRgTelefone(RgTelefone _RgTelefone)
        {
            DAO.Update(_RgTelefone);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarRgTelefone(RgTelefone _RgTelefone)
        {
            RgTelefone _Result = null;

            _Result = DAO.FindByPrimaryKey(_RgTelefone.cod_empr, _RgTelefone.cod_rg, _RgTelefone.seq_tel);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
