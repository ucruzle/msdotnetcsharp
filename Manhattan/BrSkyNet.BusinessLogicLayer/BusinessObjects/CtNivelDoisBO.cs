using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class CtNivelDoisBO
    {
        [Dependency]
        public CtNivelDoisDAO DAO { get; set; }

        public List<CtNivelDois> ListarCtNiveisDois()
        {
            List<CtNivelDois> _CtNiveisDois = DAO.ListarCtNiveisDois();
            return _CtNiveisDois;
        }

        public CtNivelDois RecuperarCtNivelDois(int _CodEmpr, int _CodPlanoCont, int _CodNivel1, int _CodNivel2)
        {
            CtNivelDois _Result = DAO.RecuperarCtNivelDois(_CodEmpr, _CodPlanoCont, _CodNivel1, _CodNivel2);
            return _Result;
        }

        public void AdicionarCtNivelDois(CtNivelDois _CtNivelDois)
        {
            DAO.Insert(_CtNivelDois);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarCtNivelDois(CtNivelDois _CtNivelDois)
        {
            DAO.Update(_CtNivelDois);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarCtNivelDois(CtNivelDois _CtNivelDois)
        {
            CtNivelDois _Result = null;

            _Result = DAO.FindByPrimaryKey(_CtNivelDois.cod_empr, _CtNivelDois.cod_plano_cont, _CtNivelDois.cod_nivel1, _CtNivelDois.cod_nivel2);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
