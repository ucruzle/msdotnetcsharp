using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class RgTmpAniversarianteBO
    {
        [Dependency]
        public RgTmpAniversarianteDAO DAO { get; set; }

        public List<RgTmpAniversariante> ListarRgTmpAniversariantes()
        {
            List<RgTmpAniversariante> _RgTmpAniversariantes = DAO.ListarRgTmpAniversariantes();
            return _RgTmpAniversariantes;
        }

        public RgTmpAniversariante RecuperarRgTmpAniversariante(string _Usuario, int _CodRg)
        {
            RgTmpAniversariante _Result = DAO.RecuperarRgTmpAniversariante(_Usuario, _CodRg);
            return _Result;
        }

        public void AdicionarRgTmpAniversariante(RgTmpAniversariante _RgTmpAniversariante)
        {
            DAO.Insert(_RgTmpAniversariante);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarRgTmpAniversariante(RgTmpAniversariante _RgTmpAniversariante)
        {
            DAO.Update(_RgTmpAniversariante);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarRgTmpAniversariante(RgTmpAniversariante _RgTmpAniversariante)
        {
            RgTmpAniversariante _Result = null;

            _Result = DAO.FindByPrimaryKey(_RgTmpAniversariante.usuario, _RgTmpAniversariante.cod_rg);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
