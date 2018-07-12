using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class CtNivelSeisBO
    {
        [Dependency]
        public CtNivelSeisDAO DAO { get; set; }

        public List<CtNivelSeis> ListarCtNiveisSeis()
        {
            List<CtNivelSeis> _CtNiveisSeis = DAO.ListarCtNiveisSeis();
            return _CtNiveisSeis;
        }

        public CtNivelSeis RecuperarCtNivelSeis(int _CodEmpr, int _CodPlanoCont, int _CodNivel1, int _CodNivel2, int _CodNivel3, int _CodNivel4, int _CodNivel5, int _CodNivel6)
        {
            CtNivelSeis _Result = DAO.RecuperarCtNivelSeis(_CodEmpr, _CodPlanoCont, _CodNivel1, _CodNivel2, _CodNivel3, _CodNivel4, _CodNivel5, _CodNivel6);
            return _Result;
        }

        public void AdicionarCtNivelSeis(CtNivelSeis _CtNivelSeis)
        {
            DAO.Insert(_CtNivelSeis);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarCtNivelSeis(CtNivelSeis _CtNivelSeis)
        {
            DAO.Update(_CtNivelSeis);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarCtNivelSeis(CtNivelSeis _CtNivelSeis)
        {
            CtNivelSeis _Result = null;

            _Result = DAO.FindByPrimaryKey(_CtNivelSeis.cod_empr,
                                           _CtNivelSeis.cod_plano_cont,
                                           _CtNivelSeis.cod_nivel1,
                                           _CtNivelSeis.cod_nivel2,
                                           _CtNivelSeis.cod_nivel3,
                                           _CtNivelSeis.cod_nivel4,
                                           _CtNivelSeis.cod_nivel5,
                                           _CtNivelSeis.cod_nivel6);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
