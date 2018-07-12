using BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects;
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
    public class StatusProcess : TaskFactory<StatusProcess>
    {
        public List<RgStatus> TaskGetCollectionRgStatusByFilter(string _StrFilter, int _IsFilter)
        {
            List<RgStatus> _Result = new List<RgStatus>();
            List<DbParameter> _ParameterList = new List<DbParameter>();
            DataTable _DataTable = null;
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Rg_RetornaStatus]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@StrFilter", System.Data.DbType.String, _StrFilter));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@IsFilter", System.Data.DbType.Int32, _IsFilter));

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, CommandType.StoredProcedure, _ParameterList, ExecuteType.ExecuteDataTable);

                foreach (DataRow _Row in _DataTable.Rows)
                {
                    _Result.Add(new RgStatus(_Row));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Result;
        }

        public int TaskModifyProcessStatus(int _IdRgStatus, string _DescrStatus, string _TipoModificacao)
        {
            int _Result = 0;
            List<DbParameter> _ParameterList = new List<DbParameter>();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Rg_ModificaProcessoStatus]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@IdRgStatus", System.Data.DbType.Int32, _IdRgStatus));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@DescrStatus", System.Data.DbType.String, _DescrStatus));
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

        public string FromToModificaStatus(ModificaStatusType _ModificaStatusType)
        {
            string _Result = string.Empty;

            switch (_ModificaStatusType)
            {
                case ModificaStatusType.StatusAdicionar:
                    _Result = "I";
                    break;
                case ModificaStatusType.StatusAlterar:
                    _Result = "U";
                    break;
                case ModificaStatusType.StatusExcluir:
                    _Result = "D";
                    break;
            }

            return _Result;
        }
    }
}
