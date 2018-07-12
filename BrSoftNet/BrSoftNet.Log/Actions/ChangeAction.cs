using BrSoftNet.Library.Utilities;
using BrSoftNet.Log.Helpers;
using BrSoftNet.Log.Maps;
using BrSoftNet.Log.Structures;
using Data.Access.Logic.Components.ObjectsPersistence;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace BrSoftNet.Log.Actions
{
    public class ChangeAction : ActionFactory<ChangeAction>
    {
        public string ActionExecuteChangeLog(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItemCollection)
        {
            string _Result = string.Empty;
            MappingChanges _MappingChanges = null;
            string _XML = string.Empty;
            List<DbParameter> _ParameterList = new List<DbParameter>();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04_HistoricoModificacoes"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04_HistoricoModificacoes"].ProviderName;
            string _TSQL = "[dbo].[Log_ModificaLogModificacoes]";

            _MappingChanges = ServiceHelper.CreateInstance.GetMappingChanges(_ChangesHeader, _ChangeItemCollection);
            _XML = SerializationData.CreateInstance.GetSerializableData(_MappingChanges, "MappingExecuteChangeLog");

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@XMLChangeLog", System.Data.DbType.Xml, _XML));

            try
            {
                _Result = Convert.ToString(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, CommandType.StoredProcedure, _ParameterList, ExecuteType.ExecuteScalar));
            }
            catch (Exception ex)
            {
                ExceptionHandling.CreateInstance.AddExceptionAndSaveTextFile(ex);
            }

            return _Result;
        }
    }
}
