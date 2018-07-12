using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class GeAplicacaoBO
    {
        [Dependency]
        public GeAplicacaoDAO DAO { get; set; }

        public List<GeAplicacao> ListarGeAplicacoes()
        {
            List<GeAplicacao> _GeAplicacoes = DAO.ListarGeAplicacoes();
            return _GeAplicacoes;
        }

        public GeAplicacao RecuperarGeAplicacao(int _CodAplic)
        {
            GeAplicacao _Result = DAO.RecuperarGeAplicacao(_CodAplic);
            return _Result;
        }

        public void AdicionarGeAplicacao(GeAplicacao _GeAplicacao)
        {
            DAO.Insert(_GeAplicacao);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarGeAplicacao(GeAplicacao _GeAplicacao)
        {
            DAO.Update(_GeAplicacao);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarGeAplicacao(GeAplicacao _GeAplicacao)
        {
            GeAplicacao _Result = null;

            _Result = DAO.FindByPrimaryKey(_GeAplicacao.cod_aplic);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
