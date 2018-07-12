using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class GeGrupoProcessoBO
    {
        [Dependency]
        public GeGrupoProcessoDAO DAO { get; set; }

        public List<GeGrupoProcesso> ListarGeGruposProcessos()
        {
            List<GeGrupoProcesso> _GeGruposProcessos = DAO.ListarGeGruposProcessos();
            return _GeGruposProcessos;
        }

        public GeGrupoProcesso RecuperaGeGrupo(int _CodEmpr, int _CodGrupo, int _CodProc)
        {
            GeGrupoProcesso _Result = DAO.RecuperarGeGrupoProcesso(_CodEmpr, _CodGrupo, _CodProc);
            return _Result;
        }

        public void AdicionarGeGrupoProcesso(GeGrupoProcesso _GeGrupoProcesso)
        {
            DAO.Insert(_GeGrupoProcesso);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarGeGrupoProcesso(GeGrupoProcesso _GeGrupoProcesso)
        {
            GeGrupoProcesso _Result = null;

            _Result = DAO.FindByPrimaryKey(_GeGrupoProcesso.cod_empr, _GeGrupoProcesso.cod_grupo, _GeGrupoProcesso.cod_proc);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
