using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class GeUsuarioAplicacaoBO
    {
        [Dependency]
        public GeUsuarioAplicacaoDAO DAO { get; set; }

        public List<GeUsuarioAplicacao> ListarGeUsuariosAplicacoes()
        {
            List<GeUsuarioAplicacao> _GeUsuariosAplicacoes = DAO.ListarGeUsuariosAplicacoes();
            return _GeUsuariosAplicacoes;
        }

        public GeUsuarioAplicacao RecuperaGeUsuarioAplicacao(int _CodEmpr, string _Usuario, int _CodAplic)
        {
            GeUsuarioAplicacao _Result = DAO.RecuperarGeUsuarioAplicacao(_CodEmpr, _Usuario, _CodAplic);
            return _Result;
        }

        public void AdicionarGeUsuarioAplicacao(GeUsuarioAplicacao _GeUsuarioAplicacao)
        {
            DAO.Insert(_GeUsuarioAplicacao);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarGeUsuarioAplicacao(GeUsuarioAplicacao _GeUsuarioAplicacao)
        {
            GeUsuarioAplicacao _Result = null;

            _Result = DAO.FindByPrimaryKey(_GeUsuarioAplicacao.cod_empr,
                                           _GeUsuarioAplicacao.usuario,
                                           _GeUsuarioAplicacao.cod_aplic);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
