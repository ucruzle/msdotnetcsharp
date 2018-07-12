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
    public class AplicacaoProcess : TaskFactory<AplicacaoProcess>
    {
        public List<GeAplicacao> TaskGetCollectionGeAplicacaoByFilter(string _StrFilter, int _IsFilter)
        {
            List<GeAplicacao> _Result = new List<GeAplicacao>();
            List<DbParameter> _ParameterList = new List<DbParameter>();
            DataTable _DataTable = null;
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_RetornaAplicacao]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@StrFilter", System.Data.DbType.String, _StrFilter));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@IsFilter", System.Data.DbType.Int32, _IsFilter));

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, CommandType.StoredProcedure, _ParameterList, ExecuteType.ExecuteDataTable);

                foreach (DataRow _Row in _DataTable.Rows)
                {
                    _Result.Add(new GeAplicacao(_Row));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Result;
        }

        public int TaskModifyProcessAplicacao(int _CodigoAplicacao, string _DescrAplicacao, string _SiglaAplicacao, int _SequenciaAplicacao, string _AtivaAplicacao, string _FormAplicacao, string _TipoModificacao)
        {
            int _Result = 0;
            List<DbParameter> _ParameterList = new List<DbParameter>();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_ModificaProcessoAplicacao]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodAplicacao", System.Data.DbType.Int32, _CodigoAplicacao));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@DescreciaoAplicacao", System.Data.DbType.String, _DescrAplicacao));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@SiglaAplicacao", System.Data.DbType.String, _SiglaAplicacao));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@SequenciaAplicacao", System.Data.DbType.Int32, _SequenciaAplicacao));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@AtivaAplicacao", System.Data.DbType.String, _AtivaAplicacao));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@FormAplicacao", System.Data.DbType.String, _FormAplicacao));
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

        public string FromToModificaAplicacao(ModificaAplicacaoType _ModificaAplicacaoType)
        {
            string _Result = string.Empty;

            switch (_ModificaAplicacaoType)
            {
                case ModificaAplicacaoType.AplicacaoAdicionar:
                    _Result = "I";
                    break;
                case ModificaAplicacaoType.AplicacaoAlterar:
                    _Result = "U";
                    break;
                case ModificaAplicacaoType.AplicacaoExcluir:
                    _Result = "D";
                    break;
            }

            return _Result;
        }
    }
}
