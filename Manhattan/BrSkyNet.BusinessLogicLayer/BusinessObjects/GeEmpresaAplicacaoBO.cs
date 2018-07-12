using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class GeEmpresaAplicacaoBO
    {
        [Dependency]
        public GeEmpresaAplicacaoDAO DAO { get; set; }

        public List<GeEmpresaAplicacao> ListarGeEmpresasAplicacoes()
        {
            List<GeEmpresaAplicacao> _GeEmpresasAplicacoes = DAO.ListarGeEmpresasAplicacoes();
            return _GeEmpresasAplicacoes;
        }

        public GeEmpresaAplicacao RecuperarGeEmpresaAplicacao(int _CodEmpr, int _CodAplic)
        {
            GeEmpresaAplicacao _Result = DAO.RecuperarGeEmpresaAplicacao(_CodEmpr, _CodAplic);
            return _Result;
        }

        public void AdicionarGeEmpresaAplicacao(GeEmpresaAplicacao _GeEmpresaAplicacao)
        {
            DAO.Insert(_GeEmpresaAplicacao);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarGeEmpresaAplicacao(GeEmpresaAplicacao _GeEmpresaAplicacao)
        {
            GeEmpresaAplicacao _Result = null;

            _Result = DAO.FindByPrimaryKey(_GeEmpresaAplicacao.cod_empr, _GeEmpresaAplicacao.cod_aplic);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
