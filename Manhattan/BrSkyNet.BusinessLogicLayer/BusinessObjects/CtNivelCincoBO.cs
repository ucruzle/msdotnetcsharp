using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class CtNivelCincoBO
    {
        [Dependency]
        public CtNivelCincoDAO DAO { get; set; }

        public List<CtNivelCinco> ListarCtNiveisCinco()
        {
            List<CtNivelCinco> _CtNiveisCinco = DAO.ListarCtNiveisCinco();
            return _CtNiveisCinco;
        }

        public CtNivelCinco RecuperarCtNivelCinco(int _CodEmpr, int _CodPlanoCont, int _CodNivel1, int _CodNivel2, int _CodNivel3, int _CodNivel4, int _CodNivel5)
        {
            CtNivelCinco _Result = DAO.RecuperarCtNivelCinco(_CodEmpr, _CodPlanoCont, _CodNivel1, _CodNivel2, _CodNivel3, _CodNivel4, _CodNivel5);
            return _Result;
        }

        public void AdicionarCtNivelCinco(CtNivelCinco _CtNivelCinco)
        {
            DAO.Insert(_CtNivelCinco);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarCtNivelCinco(CtNivelCinco _CtNivelCinco)
        {
            DAO.Update(_CtNivelCinco);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarCtNivelCinco(CtNivelCinco _CtNivelCinco)
        {
            CtNivelCinco _Result = null;

            _Result = DAO.FindByPrimaryKey(_CtNivelCinco.cod_empr, 
                                           _CtNivelCinco.cod_plano_cont, 
                                           _CtNivelCinco.cod_nivel1, 
                                           _CtNivelCinco.cod_nivel2, 
                                           _CtNivelCinco.cod_nivel3, 
                                           _CtNivelCinco.cod_nivel4, 
                                           _CtNivelCinco.cod_nivel5);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
