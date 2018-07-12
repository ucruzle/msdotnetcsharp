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
    public class UsuarioGrupoProcess : TaskFactory<UsuarioGrupoProcess>
    {
        public int TaskModifyProcessUsuarioGrupo(int _CodigoEmpresa, int _CodigoGrupo, string _Usuario, string _TipoModificacao)
        {
            int _Result = 0;
            List<DbParameter> _ParameterList = new List<DbParameter>();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_ModificaProcessoUsuarioGrupo]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoEmpresa", System.Data.DbType.Int32, _CodigoEmpresa));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoGrupo", System.Data.DbType.Int32, _CodigoGrupo));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@Usuario", System.Data.DbType.String, _Usuario));
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
        public List<GeUsuarioGrupo> TaskGetCollectionGeUsuarioGrupoByFilter(string _StrFilter, int _IsFilter)
        {
            List<GeUsuarioGrupo> _Result = new List<GeUsuarioGrupo>();
            List<DbParameter> _ParameterList = new List<DbParameter>();
            DataTable _DataTable = null;
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_RetornaUsuarioGrupo]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@StrFilter", System.Data.DbType.String, _StrFilter));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@IsFilter", System.Data.DbType.Int32, _IsFilter));

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, CommandType.StoredProcedure, _ParameterList, ExecuteType.ExecuteDataTable);

                foreach (DataRow _Row in _DataTable.Rows)
                {
                    _Result.Add(new GeUsuarioGrupo(_Row));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Result;
        }

        public DataSet TaskGetCollectionsProcessoUsuarioGrupo() 
        {
            DataSet _Result = null;
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_RetornaProcessoUsuarioGrupo]";

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
        public string FromToModificaUsuarioGrupo(ModificaUsuarioGrupoType _ModificaUsuarioGrupoType)
        {
            string _Result = string.Empty;

            switch (_ModificaUsuarioGrupoType)
            {
                case ModificaUsuarioGrupoType.UsuarioGrupoAdicionar:
                    _Result = "I";
                    break;
                case ModificaUsuarioGrupoType.UsuarioGrupoAlterar:
                    _Result = "U";
                    break;
                case ModificaUsuarioGrupoType.UsuarioGrupoExcluir:
                    _Result = "D";
                    break;
            }

            return _Result;
        }
    }
}
