using BrSoftNet.App.Business.Processes.Manager.Entities;
using BrSoftNet.App.Business.Processes.Manager.Enumerators;
using Data.Access.Logic.Components.ObjectsPersistence;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.Business.Processes.Manager.Tasks
{
    public class EmpresaAplicacaoProcess : TaskFactory<EmpresaAplicacaoProcess>
    {
        public List<GeEmpresaAplicacao> TaskGetCollectionGeEmpresaAplicacaoByFilter(string _StrFilter, int _IsFilter)
        {
            List<GeEmpresaAplicacao> _Result = new List<GeEmpresaAplicacao>();
            List<DbParameter> _ParameterList = new List<DbParameter>();
            DataTable _DataTable = null;
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_RetornaEmpresaAplicacao]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@StrFilter", System.Data.DbType.String, _StrFilter));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@IsFilter", System.Data.DbType.Int32, _IsFilter));

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, CommandType.StoredProcedure, _ParameterList, ExecuteType.ExecuteDataTable);

                foreach (DataRow _Row in _DataTable.Rows)
                {
                    _Result.Add(new GeEmpresaAplicacao(_Row));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Result;
        }
        public DataSet TaskGetCollectionGeEmpresaAplicacaoPorVinculo()
        {
            DataSet _Result = null;
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_RetornaEmpresaAplicacaoPorVinculo]";
           
            try
            {
                _Result = (DataSet)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, CommandType.StoredProcedure, null, ExecuteType.ExecuteDataSet);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Result;
        }
        public int TaskModifyProcessEmpresaAplicacao(int _CodigoEmpresa, int _CodigoAplicacao, string _DescricaoEmpresa, string _DescricaoAplicacao, string _TipoModificacao)
        {
            int _Result = 0;
            List<DbParameter> _ParameterList = new List<DbParameter>();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_ModificaProcessoEmpresaAplicacao]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoEmpresa", System.Data.DbType.Int32, _CodigoEmpresa));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoAplicacao", System.Data.DbType.Int32, _CodigoAplicacao));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@DescricaoEmpresa", System.Data.DbType.String, _DescricaoEmpresa));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@DescricaoAplicacao", System.Data.DbType.String, _DescricaoAplicacao));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@ModifyType", System.Data.DbType.String, _TipoModificacao));

            try
            {
                _Result = Convert.ToInt32(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, CommandType.StoredProcedure, _ParameterList, ExecuteType.ExecuteScalar));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Result;
        }

        public string FromToModificaEmpresaAplicacao(ModificaEmpresaAplicacaoType _ModificaEmpresaAplicacaoType)
        {
            string _Result = string.Empty;

            switch (_ModificaEmpresaAplicacaoType)
            {
                case ModificaEmpresaAplicacaoType.EmpresaAplicacaoAdicionar:
                    _Result = "I";
                    break;
                case ModificaEmpresaAplicacaoType.EmpresaAplicacaoAlterar:
                    _Result = "U";
                    break;
                case ModificaEmpresaAplicacaoType.EmpresaAplicacaoExcluir:
                    _Result = "D";
                    break;
            }

            return _Result;
        }
    }
}
