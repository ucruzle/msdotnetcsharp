using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class CtPlanoContabilBO
    {
        [Dependency]
        public CtPlanoContabilDAO DAO { get; set; }

        public List<CtPlanoContabil> ListarCtPlanosContabeis()
        {
            List<CtPlanoContabil> _CtPlanosContabeis = DAO.ListarCtPlanosContabeis();
            return _CtPlanosContabeis;
        }

        public CtPlanoContabil RecuperarCtPlanoContabil(int _CodPlanoCont)
        {
            CtPlanoContabil _Result = DAO.RecuperarCtPlanoContabil(_CodPlanoCont);
            return _Result;
        }

        public void AdicionarCtPlanoContabil(CtPlanoContabil _CtPlanoContabil)
        {
            DAO.Insert(_CtPlanoContabil);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarCtPlanoContabil(CtPlanoContabil _CtPlanoContabil)
        {
            DAO.Update(_CtPlanoContabil);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarCtPlanoContabil(CtPlanoContabil _CtPlanoContabil)
        {
            CtPlanoContabil _Result = null;

            _Result = DAO.FindByPrimaryKey(_CtPlanoContabil.cod_plano_cont);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
