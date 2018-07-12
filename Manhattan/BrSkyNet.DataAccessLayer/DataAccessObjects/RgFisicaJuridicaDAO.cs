using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class RgFisicaJuridicaDAO : BaseRepository<RgFisicaJuridica>
    {
        public List<RgFisicaJuridica> ListarRgFisicasJuridicas()
        {
            List<RgFisicaJuridica> _RgFisicasJuridicas = this.GetQueryable().OrderBy(p => p.cod_rg).ToList();
            return _RgFisicasJuridicas;
        }

        public RgFisicaJuridica RecuperarRgFisicaJuridica(int _CodEmpr, int _CodRg)
        {
            RgFisicaJuridica _Result = null;

            _Result = this.FindByPrimaryKey(_CodEmpr, _CodRg);

            return _Result;
        }

        public bool CPFJaExistente(int _Cod_Empr, int _Cod_Rg, int _Num_Cpf, int _Dig_Cpf)
        {
            var _FisicasJuridicasEncontradas = this.GetQueryable().Where(p => p.cod_empr != _Cod_Empr &&
                                                                              p.cod_rg   != _Cod_Rg   &&
                                                                              p.num_cpf  == _Num_Cpf  &&
                                                                              p.dig_cpf  == _Dig_Cpf);
            return (_FisicasJuridicasEncontradas.Count() > 0);
        }

        public bool CNPJJaExistente(int _Cod_Empr, int _Cod_Rg, int _Cgc, int _Dig_Cgc)
        {
            var _FisicasJuridicasEncontradas = this.GetQueryable().Where(p => p.cod_empr != _Cod_Empr &&
                                                                              p.cod_rg   != _Cod_Rg   &&
                                                                              p.cgc      == _Cgc      &&
                                                                              p.dig_cgc  == _Dig_Cgc);
            return (_FisicasJuridicasEncontradas.Count() > 0);
        }

        public bool RGJaExistente(int _Cod_Empr, int _Cod_Rg, string _Num_RG, string _Dig_Rg)
        {
            var _FisicasJuridicasEncontradas = this.GetQueryable().Where(p => p.cod_empr != _Cod_Empr &&
                                                                              p.cod_rg   != _Cod_Rg   &&
                                                                              p.num_rg   == _Num_RG   &&
                                                                              p.dig_rg   == _Dig_Rg);
            return (_FisicasJuridicasEncontradas.Count() > 0);
        }
    }
}
