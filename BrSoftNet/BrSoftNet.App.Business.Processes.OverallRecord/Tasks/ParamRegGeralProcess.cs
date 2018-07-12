using BrSoftNet.App.Business.Processes.OverallRecord.Entities;
using BrSoftNet.App.Business.Processes.OverallRecord.Enumerators;
using Data.Access.Logic.Components.ObjectsPersistence;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.Business.Processes.OverallRecord.Tasks
{
    public class ParamRegGeralProcess : TaskFactory<ParamRegGeralProcess>
    {
        public List<RgParamRegGeral> TaskGetCollectionRgParamRegGeralByFilter(string _StrFilter, int _IsFilter)
        {
            List<RgParamRegGeral> _Result = new List<RgParamRegGeral>();
            List<DbParameter> _ParameterList = new List<DbParameter>();
            DataTable _DataTable = null;
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Rg_RetornaParamRegGeral]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@StrFilter", System.Data.DbType.String, _StrFilter));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@IsFilter", System.Data.DbType.Int32, _IsFilter));

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, CommandType.StoredProcedure, _ParameterList, ExecuteType.ExecuteDataTable);

                foreach (DataRow _Row in _DataTable.Rows)
                {
                    _Result.Add(new RgParamRegGeral(_Row));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Result;
        }

        public int TaskModifyProcessParamRegGeral(int _CodigoEmpresa, int _CodigoNatFunc, int _CodigoNatFuncLider, int _CodigoNatCliente, int _CodigoNatFornecedor, int _CodigoNatBanco, int _CodigoStatusAtivo, int _CodigoStatusInativo, string _PermiteCGCCPFZerado, int _CodigoNatTomadora, int _CodigoNatResp, string _PermiteCGCCPFDuplicado, string _TipoModificacao)
        {
            int _Result = 0;
            List<DbParameter> _ParameterList = new List<DbParameter>();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Rg_ModificaProcessoParamRegGeral]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoEmpresa", System.Data.DbType.Int32, _CodigoEmpresa));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoNatFunc", System.Data.DbType.Int32, _CodigoNatFunc));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoNatFuncLider", System.Data.DbType.Int32, _CodigoNatFuncLider));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoNatCliente", System.Data.DbType.Int32, _CodigoNatCliente));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoNatFornecedor", System.Data.DbType.Int32, _CodigoNatFornecedor));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoNatBanco", System.Data.DbType.Int32, _CodigoNatBanco));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoStatusAtivo", System.Data.DbType.Int32, _CodigoStatusAtivo));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoStatusInativo", System.Data.DbType.Int32, _CodigoStatusInativo));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@PermiteCGCCPFZerado", System.Data.DbType.String, _PermiteCGCCPFZerado));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoNatTomadora", System.Data.DbType.Int32, _CodigoNatTomadora));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoNatResp", System.Data.DbType.Int32, _CodigoNatResp));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@PermiteCGCCPFDuplicado", System.Data.DbType.String, _PermiteCGCCPFDuplicado));
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

        public DataSet TaskRgCollectionRetornaEmpresaNaturezaStatusPorVinculo()
        {
            DataSet _Result = null;
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Rg_RetornaEmpresaNaturesaStatuPorVinculo]";

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

        public string FromToModificaParamRegGeral(ModificaParamRegGeralType _ModificaParamRegGeralType)
        {
            string _Result = string.Empty;

            switch (_ModificaParamRegGeralType)
            {
                case ModificaParamRegGeralType.ParamRegGeralAdicionar:
                    _Result = "I";
                    break;
                case ModificaParamRegGeralType.ParamRegGeralAlterar:
                    _Result = "U";
                    break;
                case ModificaParamRegGeralType.ParamRegGeralExcluir:
                    _Result = "D";
                    break;
            }

            return _Result;
        }
    }
}
