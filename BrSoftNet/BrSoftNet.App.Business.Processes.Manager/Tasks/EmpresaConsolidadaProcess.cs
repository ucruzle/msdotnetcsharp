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
    public class EmpresaConsolidadaProcess : TaskFactory<EmpresaConsolidadaProcess>
    {
        public List<GeEmpresaConsolidada> TaskGetCollectionGeEmpresaConsolidadaByFilter(string _StrFilter, int _IsFilter)
        {
            List<GeEmpresaConsolidada> _Result = new List<GeEmpresaConsolidada>();
            List<DbParameter> _ParameterList = new List<DbParameter>();
            DataTable _DataTable = null;
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_RetornaEmpresaConsolidada]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@StrFilter", System.Data.DbType.String, _StrFilter));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@IsFilter", System.Data.DbType.Int32, _IsFilter));

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, CommandType.StoredProcedure, _ParameterList, ExecuteType.ExecuteDataTable);

                foreach (DataRow _Row in _DataTable.Rows)
                {
                    _Result.Add(new GeEmpresaConsolidada(_Row));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Result;
        }

        public int TaskModifyProcessEmpresaConsolidada(int _CodigoEmpresaConsolidada, string _DescricaoEmpresaConsolidada, string _AtivaEmpresaConsolidada, string _TipoModificacao)
        {
            int _Result = 0;
            List<DbParameter> _ParameterList = new List<DbParameter>();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_ModificaProcessoEmpresaConsolidada]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoEmpresaConsolidada", System.Data.DbType.Int32, _CodigoEmpresaConsolidada));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@DescricaoEmpresaConsolidada", System.Data.DbType.String, _DescricaoEmpresaConsolidada));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@AtivaEmpresaConsolidada", System.Data.DbType.String, _AtivaEmpresaConsolidada));
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

        public string FromToModificaEmpresaConsolidada(ModificaEmpresaConsolidadaType _ModificaEmpresaConsolidadaType)
        {
            string _Result = string.Empty;

            switch (_ModificaEmpresaConsolidadaType)
            {
                case ModificaEmpresaConsolidadaType.EmpresaConsolidadaAdicionar:
                    _Result = "I";
                    break;
                case ModificaEmpresaConsolidadaType.EmpresaConsolidadaAlterar:
                    _Result = "U";
                    break;
                case ModificaEmpresaConsolidadaType.EmpresaConsolidadaExcluir:
                    _Result = "D";
                    break;
            }

            return _Result;
        }
    }
}
