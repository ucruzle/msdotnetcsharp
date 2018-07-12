using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class CtNivelUmBO
    {
        [Dependency]
        public CtNivelUmDAO DAO { get; set; }

        public List<CtNivelUm> ListarCtNiveisUm()
        {
            List<CtNivelUm> _CtNiveisUm = DAO.ListarCtNiveisUm();
            return _CtNiveisUm;
        }

        public CtNivelUm RecuperarCtNivelUm(int _CodEmpr, int _CodPlanoCont, int _CodNivel1) 
        {
            CtNivelUm _Result = DAO.RecuperarCtNivelUm(_CodEmpr, _CodPlanoCont, _CodNivel1);
            return _Result;
        }

        public void AdicionarCtNivelUm(CtNivelUm _CtNivelUm)
        {
            DAO.Insert(_CtNivelUm);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarCtNivelUm(CtNivelUm _CtNivelUm)
        {
            DAO.Update(_CtNivelUm);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarCtNivelUm(CtNivelUm _CtNivelUm)
        {
            CtNivelUm _Result = null;

            _Result = DAO.FindByPrimaryKey(_CtNivelUm.cod_empr, _CtNivelUm.cod_plano_cont, _CtNivelUm.cod_nivel1);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
