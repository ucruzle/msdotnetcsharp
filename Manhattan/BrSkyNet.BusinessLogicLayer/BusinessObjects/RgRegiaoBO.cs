using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class RgRegiaoBO
    {
        [Dependency]
        public RgRegiaoDAO DAO { get; set; }

        public List<RgRegiao> ListarRgRegioes()
        {
            List<RgRegiao> _RgRegioes = DAO.ListarRgRegioes();
            return _RgRegioes;
        }

        public RgRegiao RecuperarRgRegiao(string _SiglaRegiao)
        {
            RgRegiao _Result = DAO.RecuperarRgRegiao(_SiglaRegiao);
            return _Result;
        }

        public void AdicionarRgRegiao(RgRegiao _RgRegiao)
        {
            DAO.Insert(_RgRegiao);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarRgRegiao(RgRegiao _RgRegiao)
        {
            DAO.Update(_RgRegiao);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarRgRegiao(string _SiglaRegiao)
        {
            RgRegiao _Result = null;

            _Result = DAO.FindByPrimaryKey(_SiglaRegiao);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
