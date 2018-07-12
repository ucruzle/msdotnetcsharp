using BrSoftNet.App.Business.Processes.Security.Entities;
using Data.Access.Logic.Components.ObjectsPersistence;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace BrSoftNet.App.Business.Processes.Security.Tasks
{
    public class AccessTask : TaskFactory<AccessTask>
    {
        public DataSet GetLoginTask(string _User, string _Password) 
        {
            DataSet _Result = null;
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "declare @UserName char(20) = '" + _User + "'," +
				                  " @Password char(10) = '" + _Password + "'," +
				                  " @Usuario char(20)," +
				                  " @Senha char(10);" +												          
			    
		           " set @Usuario = (select usuario from ge_usuario where usuario = @UserName and senha = @Password and ativo = 'S');" +
		           " set @Senha = (select senha from ge_usuario where usuario = @UserName and senha = @Password and ativo = 'S');" +				           
		
		           " select usuario as Usuario," +       				
				           " nome as Nome," +
				           " cod_empr as CodigoEmpresa," +
				           " cod_rg as CodigoRegistroGeral," +
				           " status_dba as StatusDba," +
				           " ramal as Ramal" +
		              " from ge_usuario" +
		             " where usuario = @Usuario" +
			           " and senha = @Senha;" +			   
					
		           " select distinct" + 
			              " upr.cod_empr as CodigoEmpresa," +			       
			              " emp.descr_empr_red as NomeFantasia" +
		             " from ge_usuario_processo as upr" +
	           " inner join ge_empresa as emp" +
			           " on upr.cod_empr = emp.cod_empr" +
	           " inner join rg_reg_geral as rgl" +                
			           " on emp.cod_rg = rgl.cod_rg" +			   
		              " and rgl.cod_status = 1" +
		              " and upr.usuario = @Usuario" +
		            " order by upr.cod_empr";

            try
            {
                _Result = (DataSet)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, System.Data.CommandType.Text, null, ExecuteType.ExecuteDataSet);
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }

            return _Result;
        }

        public RazaoSocialLogin GetRazaoSocialTask(int _CodigoEmpresa) 
        {
            RazaoSocialLogin _Result = null;
            DataTable _DataTable = new DataTable();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "select distinct" + 			       
			                     " emp.descr_empr as RazaoSocial" +				   
		                    " from ge_empresa as emp" +			    
		                   " where emp.cod_empr = " + _CodigoEmpresa;

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, System.Data.CommandType.Text, null, ExecuteType.ExecuteDataTable);

                if (_DataTable.Rows.Count > 0)
                {
                    _Result = new RazaoSocialLogin(_DataTable.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _DataTable.Dispose();                
            }

            return _Result;
        }

        public NomeFantasiaLogin GetNomeFantasiaTask(int _CodigoEmpresa)
        {
            NomeFantasiaLogin _Result = null;
            DataTable _DataTable = new DataTable();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "select distinct" +
                                 " emp.descr_empr_red as NomeFantasia" +
                            " from ge_empresa as emp" +
                           " where emp.cod_empr = " + _CodigoEmpresa;

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, System.Data.CommandType.Text, null, ExecuteType.ExecuteDataTable);

                if (_DataTable.Rows.Count > 0)
                {
                    _Result = new NomeFantasiaLogin(_DataTable.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _DataTable.Dispose();
            }

            return _Result;
        }

        public List<AplicacaoLogin> GetAplicacaoLoginTask(string _Usuario, int _CodigoEmpresa) 
        {
            List<AplicacaoLogin> _Result = new List<AplicacaoLogin>();
            DataTable _DataTable = new DataTable();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "select distinct" +
                                 " pro.cod_aplic as CodigoAplicacao," +
			                     " apl.descr_aplic as DescricaoAplicacao" +			                     
		                    " from ge_usuario_processo as upr" +
	                  " inner join ge_processo as pro" +
	                          " on upr.cod_proc = pro.cod_proc" +
	                  " inner join ge_tipo_processo as tpr" +
	                          " on pro.cod_tipo_proc = tpr.cod_tipo_proc" +
                      " inner join ge_aplicacao as apl" +
	                          " on apl.cod_aplic = pro.cod_aplic" +
     	                   " where upr.usuario = '" + _Usuario + "'" +	
		                     " and upr.cod_empr = " + _CodigoEmpresa +
                        " order by pro.cod_aplic";

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, System.Data.CommandType.Text, null, ExecuteType.ExecuteDataTable);

                foreach (DataRow _Row in _DataTable.Rows)
                {
                    _Result.Add(new AplicacaoLogin(_Row));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _DataTable.Dispose();                
            }

            return _Result;
        }

        public NomeAplicacaoLogin GetNomeAplicacaoTask(int _CodigoAplicacao)
        {
            NomeAplicacaoLogin _Result = null;
            DataTable _DataTable = new DataTable();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "select distinct" +
                                 " apl.descr_aplic as NomeApplicacao" +
                            " from ge_aplicacao as apl" +
                           " where apl.cod_aplic = " + _CodigoAplicacao;

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, System.Data.CommandType.Text, null, ExecuteType.ExecuteDataTable);

                if (_DataTable.Rows.Count > 0)
                {
                    _Result = new NomeAplicacaoLogin(_DataTable.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _DataTable.Dispose();
            }

            return _Result;
        }

        public List<TipoProcessoLogin> GetTipoProcessoLoginTask(int _CodigoAplicacao)
        {
            List<TipoProcessoLogin> _Result = new List<TipoProcessoLogin>();
            DataTable _DataTable = new DataTable();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "select distinct" +
                                 " pro.cod_tipo_proc as CodigoTipoProcesso," +
                                 " tpr.descr_tipo_proc as DescricaoTipoProcesso" +
                            " from ge_usuario_processo as upr" +
                      " inner join ge_processo as pro" +
                              " on upr.cod_proc = pro.cod_proc" +
                      " inner join ge_tipo_processo as tpr" +
                              " on pro.cod_tipo_proc = tpr.cod_tipo_proc" +
                      " inner join ge_aplicacao as apl" +
                              " on apl.cod_aplic = pro.cod_aplic" +
                           " where apl.cod_aplic = " + _CodigoAplicacao +
                        " order by pro.cod_tipo_proc";

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, System.Data.CommandType.Text, null, ExecuteType.ExecuteDataTable);

                foreach (DataRow _Row in _DataTable.Rows)
                {
                    _Result.Add(new TipoProcessoLogin(_Row));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _DataTable.Dispose();
            }

            return _Result;
        }

        public List<ProcessoLogin> GetProcessoLoginTask(int _CodigoAplicacao, int _CodigoTipoProcesso)
        {
            List<ProcessoLogin> _Result = new List<ProcessoLogin>();
            DataTable _DataTable = new DataTable();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "select distinct" +
                                 " upr.cod_proc as CodigoProcesso," +
                                 " pro.descr_proc as DescricaoProcesso" +
                            " from ge_usuario_processo as upr" +
                      " inner join ge_processo as pro" +
                              " on upr.cod_proc = pro.cod_proc" +
                      " inner join ge_tipo_processo as tpr" +
                              " on pro.cod_tipo_proc = tpr.cod_tipo_proc" +
                      " inner join ge_aplicacao as apl" +
                              " on apl.cod_aplic = pro.cod_aplic" +
                           " where pro.cod_aplic = " + _CodigoAplicacao +
                             " and tpr.cod_tipo_proc = " + _CodigoTipoProcesso +
                        " order by upr.cod_proc";

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, System.Data.CommandType.Text, null, ExecuteType.ExecuteDataTable);

                foreach (DataRow _Row in _DataTable.Rows)
                {
                    _Result.Add(new ProcessoLogin(_Row));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _DataTable.Dispose();
            }

            return _Result;
        }

        public GestaoProcessoLogin GetProcessoByIdTask(int _CodigoProcesso) 
        {
            GestaoProcessoLogin _Result = null;
            DataTable _DataTable = new DataTable();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = " select cod_proc," +
                                   " descr_proc," +
                                   " cod_tipo_proc," +
                                   " cod_aplic," +
                                   " ativo," +
                                   " form," +
                                   " sequ_proc" +
                              " from ge_processo" +
                             " where cod_proc = " + _CodigoProcesso;

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, System.Data.CommandType.Text, null, ExecuteType.ExecuteDataTable);

                if (_DataTable.Rows.Count > 0)
                {
                    _Result = new GestaoProcessoLogin(_DataTable.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _DataTable.Dispose();
            }

            return _Result;
        }

        public DataTable RetornaNoDeAplicacoesNoMenuTask(string _Usuario, int _CodigoEmpresa)
        {
            DataTable _Result = null;
            List<DbParameter> _ParameterList = new List<DbParameter>();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_RetornaNoDeAplicacoesNoMenu]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@Usuario", System.Data.DbType.String, _Usuario));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoEmpresa", System.Data.DbType.Int32, _CodigoEmpresa));

            try
            {
                _Result = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, System.Data.CommandType.StoredProcedure, _ParameterList, ExecuteType.ExecuteDataTable);
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }

            return _Result;
        }

        public DataTable RetornaNoDeTiposDeProcessosNoMenuTask(int _CodigoAplicacao, int _CodigoEmpresa)
        {
            DataTable _Result = null;
            List<DbParameter> _ParameterList = new List<DbParameter>();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_RetornaNoDeTiposDeProcessosNoMenu]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoAplicacao", System.Data.DbType.Int32, _CodigoAplicacao));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoEmpresa", System.Data.DbType.Int32, _CodigoEmpresa));

            try
            {
                _Result = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, System.Data.CommandType.StoredProcedure, _ParameterList, ExecuteType.ExecuteDataTable);
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }

            return _Result;
        }

        public DataTable RetornaNoDeProcessosNoMenuTask(int _CodigoAplicacao, int _CodigoTipoDeProcesso, int _CodigoEmpresa)
        {
            DataTable _Result = null;
            List<DbParameter> _ParameterList = new List<DbParameter>();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Ge_RetornaNoDeProcessosNoMenu]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoAplicacao", System.Data.DbType.Int32, _CodigoAplicacao));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoTipoDeProcesso", System.Data.DbType.Int32, _CodigoTipoDeProcesso));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@CodigoEmpresa", System.Data.DbType.Int32, _CodigoEmpresa));

            try
            {
                _Result = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, System.Data.CommandType.StoredProcedure, _ParameterList, ExecuteType.ExecuteDataTable);
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }

            return _Result;
        }

        public int ModificaProcessoSessaoUsuario(string _Usuario, string _IdSession, DateTime _DateTimeSession, string _MachineName, string _MachineIP, int _LogonNumber)
        {
            int _Result = 0;
            List<DbParameter> _ParameterList = new List<DbParameter>();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "[dbo].[Modifica_Processo_Sessao_Usuario]";

            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@Usuario", System.Data.DbType.String, _Usuario));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@IdSession", System.Data.DbType.String, _IdSession));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@DateTimeSession", System.Data.DbType.DateTime, _DateTimeSession));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@MachineName", System.Data.DbType.String, _MachineName));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@MachineIP", System.Data.DbType.String, _MachineIP));
            _ParameterList.Add(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).CreateParameter("@LogonNumber", System.Data.DbType.Int32, _LogonNumber));

            try
            {
                _Result = Convert.ToInt32(DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, CommandType.StoredProcedure, _ParameterList, ExecuteType.ExecuteNonQuery));
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }

            return _Result;
        }

        public SessaoUsuarioLogin RetornaProcessoSessaoUsuario(string _Usuario)
        {
            SessaoUsuarioLogin _Result = null;
            DataTable _DataTable = new DataTable();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL =  " SELECT Usuario," +
                                   " IdSession," +
                                   " DateTimeSession," +
                                   " MachineName," +
                                   " MachineIP," +
                                   " LogonNumber" +
                              " FROM ge_sessao_usuario" +
                             " WHERE Usuario = " + "'" + _Usuario + "'";

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, System.Data.CommandType.Text, null, ExecuteType.ExecuteDataTable);

                if (_DataTable.Rows.Count > 0)
                {
                    _Result = new SessaoUsuarioLogin(_DataTable.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _DataTable.Dispose();
            }

            return _Result;
        }

        public string RetornaCaminhoDiretorioEmpresa(int _CodigoEmpresa)
        {
            string _Result = null;
            DataTable _DataTable = new DataTable();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = " SELECT dir_logo_empresa" +
                             " FROM ge_parametro" +
                            " WHERE id_tabela = " + _CodigoEmpresa;

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, System.Data.CommandType.Text, null, ExecuteType.ExecuteDataTable);

                if (_DataTable.Rows.Count > 0)
                {
                    _Result = _DataTable.Rows[0]["dir_logo_empresa"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _DataTable.Dispose();
            }

            return _Result;
        }
    }
}
