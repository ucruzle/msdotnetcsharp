using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class FiTipoCtaBancoDAO : BaseRepository<FiTipoCtaBanco>
    {
        public List<FiTipoCtaBanco> ListarFiTiposCtasBancos()
        {
            List<FiTipoCtaBanco> _FiTiposCtasBancos = this.GetQueryable().OrderBy(f => f.descr_cta_banco).ToList();
            return _FiTiposCtasBancos;
        }

        public FiTipoCtaBanco RecuperarFiTipoCtaBanco(int _CodTipoCta)
        {
            FiTipoCtaBanco _Result = null;

            _Result = this.FindByPrimaryKey(_CodTipoCta);

            return _Result;
        }
    }
}
