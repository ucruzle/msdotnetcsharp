using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class RgEstadoBO
    {
        [Dependency]
        public RgEstadoDAO DAO { get; set; }

        public List<RgEstado> ListarRgEstados()
        {
            List<RgEstado> _RgEstados = DAO.ListarRgEstados();
            return _RgEstados;
        }

        public RgEstado RecuperaRgEstado(string _SiglaEstado)
        {
            RgEstado _Result = DAO.RecuperarRgEstado(_SiglaEstado);
            return _Result;
        }

        public void AdicionarRgEstado(RgEstado _RgEstado)
        {
            DAO.Insert(_RgEstado);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarRgEstado(RgEstado _RgEstado)
        {
            DAO.Update(_RgEstado);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarRgEstado(string _SiglaEstado)
        {
            RgEstado _Result = null;

            _Result = DAO.FindByPrimaryKey(_SiglaEstado);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
