using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class CtNivelQuatroBO
    {
        [Dependency]
        public CtNivelQuatroDAO DAO { get; set; }

        public List<CtNivelQuatro> ListarCtNiveisQuatro()
        {
            List<CtNivelQuatro> _CtNiveisQuatro = DAO.ListarCtNiveisQuatro();
            return _CtNiveisQuatro;
        }

        public CtNivelQuatro RecuperarCtNivelQuatro(int _CodEmpr, int _CodPlanoCont, int _CodNivel1, int _CodNivel2, int _CodNivel3, int _CodNivel4)
        {
            CtNivelQuatro _Result = DAO.RecuperarCtNivelQuatro(_CodEmpr, _CodPlanoCont, _CodNivel1, _CodNivel2, _CodNivel3, _CodNivel4);
            return _Result;
        }

        public void AdicionarCtNivelQuatro(CtNivelQuatro _CtNivelQuatro)
        {
            DAO.Insert(_CtNivelQuatro);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarCtNivelQuatro(CtNivelQuatro _CtNivelQuatro)
        {
            DAO.Update(_CtNivelQuatro);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarCtNivelQuatro(CtNivelQuatro _CtNivelQuatro)
        {
            CtNivelQuatro _Result = null;

            _Result = DAO.FindByPrimaryKey(_CtNivelQuatro.cod_empr, _CtNivelQuatro.cod_plano_cont, _CtNivelQuatro.cod_nivel1, _CtNivelQuatro.cod_nivel2, _CtNivelQuatro.cod_nivel3, _CtNivelQuatro.cod_nivel4);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
