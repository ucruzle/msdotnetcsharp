using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class CtNivelTresBO
    {
        [Dependency]
        public CtNivelTresDAO DAO { get; set; }

        public List<CtNivelTres> ListarCtNiveisTres()
        {
            List<CtNivelTres> _CtNiveisTres = DAO.ListarCtNiveisTres();
            return _CtNiveisTres;
        }

        public CtNivelTres RecuperarCtNivelTres(int _CodEmpr, int _CodPlanoCont, int _CodNivel1, int _CodNivel2, int _CodNivel3)
        {
            CtNivelTres _Result = DAO.RecuperarCtNivelTres(_CodEmpr, _CodPlanoCont, _CodNivel1, _CodNivel2, _CodNivel3);
            return _Result;
        }

        public void AdicionarCtNivelTres(CtNivelTres _CtNivelTres)
        {
            DAO.Insert(_CtNivelTres);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarCtNivelTres(CtNivelTres _CtNivelTres)
        {
            DAO.Update(_CtNivelTres);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarCtNivelTres(CtNivelTres _CtNivelTres)
        {
            CtNivelTres _Result = null;

            _Result = DAO.FindByPrimaryKey(_CtNivelTres.cod_empr, _CtNivelTres.cod_plano_cont, _CtNivelTres.cod_nivel1, _CtNivelTres.cod_nivel2, _CtNivelTres.cod_nivel3);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
