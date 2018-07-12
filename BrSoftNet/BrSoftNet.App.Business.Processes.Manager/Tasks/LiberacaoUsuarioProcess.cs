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
    public class LiberacaoUsuarioProcess : TaskFactory<LiberacaoUsuarioProcess>
    {
        public int TaskModifyProcessLiberacaoUsuario(string _XML, string _TipoModificacao)
        {
            int _Result = 0;
            List<DbParameter> _ParameterList = new List<DbParameter>();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_ModificaProcessoLiberacaoUsuario]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@XMLProcessoUsuarioProcesso", System.Data.DbType.Xml, _XML));
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

        public DataSet GetCollectionLiberacaoUsuarioTask()
        {
            DataSet _Result = null;
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_RetornaLiberacaoUsuario]";

            try
            {
                _Result = (DataSet)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, CommandType.Text, null, ExecuteType.ExecuteDataSet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Result;
        }

        public List<GeProcesso> TaskGetCollectionGeProcessoByEmpresaAplicacaoTipoProcesso(int _CodigoEmpresa, int _CodigoAplicacao, string _Usuario, string _TipoDeModificacao)
        {
            List<GeProcesso> _Result = new List<GeProcesso>();
            List<DbParameter> _ParameterList = new List<DbParameter>();
            DataTable _DataTable = null;
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_RetornaProcessoDeLiberacaoUsuarioPorEmpresaAplicacaoTipoProcesso]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoEmpresa", System.Data.DbType.Int32, _CodigoEmpresa));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoAplicacao", System.Data.DbType.Int32, _CodigoAplicacao));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@Usuario", System.Data.DbType.String, _Usuario));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@TipoDeModificacao", System.Data.DbType.String, _TipoDeModificacao));

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, CommandType.StoredProcedure, _ParameterList, ExecuteType.ExecuteDataTable);

                foreach (DataRow _Row in _DataTable.Rows)
                {
                    _Result.Add(new GeProcesso(_Row));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Result;
        }

        public List<LiberacaoUsuarioPorFiltro> TaskGetDataLiberacaoUsuarioByFilter(string _StrFilter, int _IsFilter) 
        {
            List<LiberacaoUsuarioPorFiltro> _Result = new List<LiberacaoUsuarioPorFiltro>();
            List<DbParameter> _ParameterList = new List<DbParameter>();
            DataTable _DataTable = null;
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_RetornaLiberacaoUsuarioPorFiltro]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@StrFilter", System.Data.DbType.String, _StrFilter));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@IsFilter", System.Data.DbType.Int32, _IsFilter));

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, CommandType.StoredProcedure, _ParameterList, ExecuteType.ExecuteDataTable);

                foreach (DataRow _Row in _DataTable.Rows)
                {
                    _Result.Add(new LiberacaoUsuarioPorFiltro(_Row));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Result;
        }

        public string FromToModificaLiberacaoUsuario(ModificaLiberacaoUsuarioType _ModificaLiberacaoUsuarioType)
        {
            string _Result = string.Empty;

            switch (_ModificaLiberacaoUsuarioType)
            {
                case ModificaLiberacaoUsuarioType.LiberacaoUsuarioAdicionar:
                    _Result = "I";
                    break;
                case ModificaLiberacaoUsuarioType.LiberacaoUsuarioAlterar:
                    _Result = "U";
                    break;
                case ModificaLiberacaoUsuarioType.LiberacaoUsuarioExcluir:
                    _Result = "D";
                    break;
            }

            return _Result;
        }
    }
}
