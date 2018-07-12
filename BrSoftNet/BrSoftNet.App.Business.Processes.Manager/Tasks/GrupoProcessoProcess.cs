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
    public class GrupoProcessoProcess : TaskFactory<GrupoProcessoProcess>
    {
        public int TaskModifyProcessGrupoProcesso(string _XML, string _TipoModificacao)
        {
            int _Result = 0;
            List<DbParameter> _ParameterList = new List<DbParameter>();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_ModificaProcessoGrupoProcesso]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@XMLProcessoGrupoProcesso", System.Data.DbType.Xml, _XML));
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

        public DataSet GetCollectionGrupoProcessoTask()
        {
            DataSet _Result = null;
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_RetornaLiberacaoGrupoProcesso]";

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

        public List<GeProcesso> TaskGetCollectionGeProcessoByEmpresaAplicacaoTipoProcesso(int _CodigoEmpresa, int _CodigoAplicacao, int _CodigoGrupo, string _TipoDeModificacao)
        {
            List<GeProcesso> _Result = new List<GeProcesso>();
            List<DbParameter> _ParameterList = new List<DbParameter>();
            DataTable _DataTable = null;
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_RetornaProcessoGrupoProcessoPorEmpresaAplicacaoTipoProcesso]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoEmpresa", System.Data.DbType.Int32, _CodigoEmpresa));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoAplicacao", System.Data.DbType.Int32, _CodigoAplicacao));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoGrupo", System.Data.DbType.Int32, _CodigoGrupo));
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

        public List<GrupoProcessoPorFiltro> TaskGetCollectionGeGrupoProcessoByFilter(string _StrFilter, int _IsFilter)
        {
            List<GrupoProcessoPorFiltro> _Result = new List<GrupoProcessoPorFiltro>();
            List<DbParameter> _ParameterList = new List<DbParameter>();
            DataTable _DataTable = null;
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_RetornaGrupoProcesso]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@StrFilter", System.Data.DbType.String, _StrFilter));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@IsFilter", System.Data.DbType.Int32, _IsFilter));

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, CommandType.StoredProcedure, _ParameterList, ExecuteType.ExecuteDataTable);

                foreach (DataRow _Row in _DataTable.Rows)
                {
                    _Result.Add(new GrupoProcessoPorFiltro(_Row));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Result;
        }

        public string FromToModificaGrupoProcesso(ModificaGrupoProcessoType _ModificaGrupoProcessoType)
        {
            string _Result = string.Empty;

            switch (_ModificaGrupoProcessoType)
            {
                case ModificaGrupoProcessoType.GrupoProcessoAdicionar:
                    _Result = "I";
                    break;
                case ModificaGrupoProcessoType.GrupoProcessoAlterar:
                    _Result = "U";
                    break;
                case ModificaGrupoProcessoType.GrupoProcessoExcluir:
                    _Result = "D";
                    break;
            }

            return _Result;
        }
    }
}
