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
    public class TipoProcessoProcess : TaskFactory<TipoProcessoProcess>
    {
        public List<GeTipoProcesso> TaskGetCollectionGeTipoProcessoByFilter(string _StrFilter, int _IsFilter)
        {
            List<GeTipoProcesso> _Result = new List<GeTipoProcesso>();
            List<DbParameter> _ParameterList = new List<DbParameter>();
            DataTable _DataTable = null;
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_RetornaTipoProcesso]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@StrFilter", System.Data.DbType.String, _StrFilter));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@IsFilter", System.Data.DbType.Int32, _IsFilter));

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, CommandType.StoredProcedure, _ParameterList, ExecuteType.ExecuteDataTable);

                foreach (DataRow _Row in _DataTable.Rows)
                {
                    _Result.Add(new GeTipoProcesso(_Row));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Result;
        }
        public int TaskModifyTypeProcessTypeProcess(int _TipoProcesso, string _DescrProcesso, int _SequenciaProcesso, string _TipoModificacao)
        {
            int _Result = 0;
            List<DbParameter> _ParameterList = new List<DbParameter>();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_ModificaProcessoTipoProcesso]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoTipoProcesso", System.Data.DbType.String, _TipoProcesso));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@DescricaoTipoProcesso", System.Data.DbType.String, _DescrProcesso));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@SequenciaTipoProcesso", System.Data.DbType.String, _SequenciaProcesso));
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

        public List<GeTipoProcesso> TaskGetCollectionTipoProcesso()
        {
            List<GeTipoProcesso> _Result = new List<GeTipoProcesso>();
            DataTable _DataTable = null;
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_RetornaTipoProcesso]";

             try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, CommandType.StoredProcedure, null, ExecuteType.ExecuteDataTable);

                foreach (DataRow _Row in _DataTable.Rows)
                {
                    _Result.Add(new GeTipoProcesso(_Row));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Result;
        }
        public string FromToModificaTipoProcesso(ModificaTipoProcessoType _ModificaTipoProcessoType)
        {
            string _Result = string.Empty;

            switch (_ModificaTipoProcessoType)
            {
                case ModificaTipoProcessoType.TipoProcessoAdicionar:
                    _Result = "I";
                    break;
                case ModificaTipoProcessoType.TipoProcessoAlterar:
                    _Result = "U";
                    break;
                case ModificaTipoProcessoType.TipoProcessoExcluir:
                    _Result = "D";
                    break;
            }

            return _Result;
        }

        public List<GeTipoProcesso> TaskGetCollectionGeTipoProcessoByFilter()
        {
            throw new NotImplementedException();
        }
    }
}
