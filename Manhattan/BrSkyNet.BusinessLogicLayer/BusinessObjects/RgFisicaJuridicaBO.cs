using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class RgFisicaJuridicaBO
    {
        [Dependency]
        public RgFisicaJuridicaDAO DAO { get; set; }

        public List<RgFisicaJuridica> ListarRgFisicasJuridicas()
        {
            List<RgFisicaJuridica> _RgFisicasJuridicas = DAO.ListarRgFisicasJuridicas();
            return _RgFisicasJuridicas;
        }

        public RgFisicaJuridica RecuperarRgFisicaJuridica(int _CodEmpr, int _CodRg)
        {
            RgFisicaJuridica _Result = null;
            _Result = DAO.RecuperarRgFisicaJuridica(_CodEmpr, _CodRg);
            return _Result;
        }

        public bool CPFJaExistente(int _Cod_Empr, int _Cod_Rg, int _Num_Cpf, int _Dig_Cpf)
        {
            bool _Result = false;
            _Result = DAO.CPFJaExistente(_Cod_Empr, _Cod_Rg, _Num_Cpf, _Dig_Cpf);
            return _Result;
        }

        public bool CNPJJaExistente(int _Cod_Empr, int _Cod_Rg, int _Cgc, int _Dig_Cgc)
        {
            bool _Result = false;
            _Result = DAO.CNPJJaExistente(_Cod_Empr, _Cod_Rg, _Cgc, _Dig_Cgc);
            return _Result;
        }

        public bool RGJaExistente(int _Cod_Empr, int _Cod_Rg, string _Num_RG, string _Dig_Rg)
        {
            bool _Result = false;
            _Result = DAO.RGJaExistente(_Cod_Empr, _Cod_Rg, _Num_RG, _Dig_Rg);
            return _Result;
        }

        public void AdicionarRgFisicaJuridica(RgFisicaJuridica _RgFisicaJuridica)
        {
            DAO.Insert(_RgFisicaJuridica);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarRgFisicaJuridica(RgFisicaJuridica _RgFisicaJuridica)
        {
            DAO.Update(_RgFisicaJuridica);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarRgFisicaJuridica(RgFisicaJuridica _RgFisicaJuridica)
        {
            RgFisicaJuridica _Result = null;
            _Result = DAO.FindByPrimaryKey(_RgFisicaJuridica.cod_empr, _RgFisicaJuridica.cod_rg);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
