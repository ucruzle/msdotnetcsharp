using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class FiNroBancoDAO : BaseRepository<FiNroBanco>
    {
        public List<FiNroBanco> ListarFiNrosBancos()
        {
            List<FiNroBanco> _FiNrosBancos = this.GetQueryable().OrderBy(f => f.descr_nro_banco).ToList();
            return _FiNrosBancos;
        }

        public FiNroBanco RecuperarFiNroBanco(int _NroBanco)
        {
            FiNroBanco _Result = null;

            _Result = this.FindByPrimaryKey(_NroBanco);

            return _Result;
        }
    }
}
