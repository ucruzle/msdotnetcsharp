using BrSoftNet.App.Business.Processes.Manager.Entities;
using BrSoftNet.App.Business.Processes.Manager.Enumerators;
using Data.Access.Logic.Components.ObjectsPersistence;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace BrSoftNet.App.Business.Processes.Manager.Tasks
{
    public class ManagementParameterProcess : TaskFactory<ManagementParameterProcess>
    {
        public List<ProcessoGerenciador> TaskGetProcessesAll()
        {
            List<ProcessoGerenciador> _Result = new List<ProcessoGerenciador>();
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
                        " order by upr.cod_proc";

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, System.Data.CommandType.Text, null, ExecuteType.ExecuteDataTable);

                foreach (DataRow _Row in _DataTable.Rows)
                {
                    _Result.Add(new ProcessoGerenciador(_Row));
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
        public List<ProcessoGerenciador> TaskGetProcessesByIdProcessType(int _CodigoTipoProcesso)
        {
            List<ProcessoGerenciador> _Result = new List<ProcessoGerenciador>();
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
                           " where tpr.cod_tipo_proc = " + _CodigoTipoProcesso +
                        " order by upr.cod_proc";

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, System.Data.CommandType.Text, null, ExecuteType.ExecuteDataTable);

                foreach (DataRow _Row in _DataTable.Rows)
                {
                    _Result.Add(new ProcessoGerenciador(_Row));
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

        public List<ParametroGerenciador> TaskGetDataProcessesByFilter(int _CodigoParametroGerenciador, int _CodigoTipoProcessoEspecial, int _CodigoTipoProcessoInternet, string _TipoProcesso) 
        {
            List<ParametroGerenciador> _Result = new List<ParametroGerenciador>();
            DataTable _DataTable = new DataTable();
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "DECLARE" +
	                        " @IdCodigoParametroGerenciador int = 0," +
	                        " @IdTipoProcessoEspecial int = 0," +
	                        " @IdTipoProcessoInternet int = 0," +
	                        " @IdTipoConsulta char(1) = '" + _TipoProcesso + "'" +

	                        " SET @IdCodigoParametroGerenciador = "+ _CodigoParametroGerenciador +
	                        " SET @IdTipoProcessoEspecial = " + _CodigoTipoProcessoEspecial +
	                        " SET @IdTipoProcessoInternet = " + _CodigoTipoProcessoInternet +

	                        " IF @IdTipoConsulta = 'C'" +
	                          " BEGIN" +
			                        " SELECT" +
				                        " id_tabela," +
				                        " dir_logo_empresa," +
				                        " dir_pgm_relatorio," +
				                        " dir_relatorio," +
				                        " dir_backup," +
				                        " dir_script," +
				                        " dir_importacao," +
				                        " dir_exportacao_excel," +
				                        " cod_tipo_proc_esp," +
				                        " cod_tipo_proc_int," +
				                        " mostra_form_menu," +
				                        " dir_foto," +
				                        " dir_servidor" +
				                      " FROM" +
				                        " ge_parametro" +
                                  " where id_tabela = @IdCodigoParametroGerenciador" +
		                       " order by id_tabela" +
		                      " END" +

		                      " IF @IdTipoConsulta = 'E'" +
	                          " BEGIN" +
			                        " SELECT" +
				                        " id_tabela," +
				                        " dir_logo_empresa," +
				                        " dir_pgm_relatorio," + 
				                        " dir_relatorio," +
				                        " dir_backup," +
				                        " dir_script," +
				                        " dir_importacao," +
				                        " dir_exportacao_excel," +
				                        " cod_tipo_proc_esp," +
				                        " cod_tipo_proc_int," +
				                        " mostra_form_menu," +
				                        " dir_foto," +
				                        " dir_servidor" +
				                      " FROM" +
				                        " ge_parametro" +
			                      " where cod_tipo_proc_esp = @IdTipoProcessoEspecial" +
		                       " order by id_tabela" +
		                      " END" +

		                      " IF @IdTipoConsulta = 'I'" +
	                          " BEGIN" +
			                        " SELECT" +
				                        " id_tabela," +
				                        " dir_logo_empresa," + 
				                        " dir_pgm_relatorio," + 
				                        " dir_relatorio," + 
				                        " dir_backup," + 
				                        " dir_script," + 
				                        " dir_importacao," + 
				                        " dir_exportacao_excel," +
				                        " cod_tipo_proc_esp," +
				                        " cod_tipo_proc_int," +
				                        " mostra_form_menu," +
				                        " dir_foto," +
				                        " dir_servidor" +
				                      " FROM" +
				                        " ge_parametro" +
			                      " where cod_tipo_proc_int = @IdTipoProcessoInternet" +
		                       " order by id_tabela" +
		                      " END" +

		                      " IF @IdTipoConsulta = 'N'" +
	                          " BEGIN" +
			                        " SELECT TOP 100" +
				                        " id_tabela," +
				                        " dir_logo_empresa," + 
				                        " dir_pgm_relatorio," + 
				                        " dir_relatorio," + 
				                        " dir_backup," + 
				                        " dir_script," + 
				                        " dir_importacao," + 
				                        " dir_exportacao_excel," +
				                        " cod_tipo_proc_esp," +
				                        " cod_tipo_proc_int," +
				                        " mostra_form_menu," +
				                        " dir_foto," +
				                        " dir_servidor" +
				                      " FROM" +
				                        " ge_parametro" +
		                       " order by id_tabela" +
		                      " END";

            try
            {
                _DataTable = (DataTable)DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, System.Data.CommandType.Text, null, ExecuteType.ExecuteDataTable);

                foreach (DataRow _Row in _DataTable.Rows)
                {
                    _Result.Add(new ParametroGerenciador(_Row));
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

        public Object TaskModifyDataProcesses(int _IdTabela, string _DirLogoEmpresa, string _DirPgmRelatorio, string _DirRelatorio, string _DirBackup, string _DirScript, string _DirImportacao, string _DirExportacaoExcel, int _IdTipoProcEsp, int _IdTipoProcInt, string _MostraFormMenu, string _DirFoto, string _DirServidor, string _ModifyType) 
        {
            Object _Result = null;
            string _ConnectionString = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ConnectionString;
            string _ProviderName = ConfigurationManager.ConnectionStrings["BrErpSindicatoV04"].ProviderName;
            string _TSQL = "DECLARE" +
                              " @IdTabela int = 0," +
                              " @DirLogoEmpresa varchar(100) = ''," +
                              " @DirPgmRelatorio varchar(100) = ''," +
                              " @DirRelatorio varchar(100) = ''," +
                              " @DirBackup varchar(100) = ''," +
                              " @DirScript varchar(100) = ''," +
                              " @DirImportacao varchar(100) = ''," +
                              " @DirExportacaoExcel varchar(100) = ''," +
	                          " @IdTipoProcEsp int = 0," +
	                          " @IdTipoProcInt int = 0," +
	                          " @MostraFormMenu char(1) = ''," +
	                          " @DirFoto varchar(100) = ''," +
	                          " @DirServidor varchar(100) = ''," + 
                              " @ModifyType char(1) = 'N'" +

                            " SET @IdTabela = " + _IdTabela +
                            " SET @DirLogoEmpresa = '" + _DirLogoEmpresa + "'" +
                            " SET @DirPgmRelatorio = '" + _DirPgmRelatorio + "'" +
                            " SET @DirRelatorio = '" + _DirRelatorio + "'" +
                            " SET @DirBackup = '" + _DirBackup + "'" +
                            " SET @DirScript = '" + _DirScript + "'" +
                            " SET @DirImportacao = '" + _DirImportacao + "'" +
                            " SET @DirExportacaoExcel = '" + _DirExportacaoExcel + "'" +
                            " SET @IdTipoProcEsp = " + _IdTipoProcEsp +
                            " SET @IdTipoProcInt = " + _IdTipoProcInt +
                            " SET @MostraFormMenu = '" + _MostraFormMenu + "'" +
                            " SET @DirFoto = '" + _DirFoto + "'" +
                            " SET @DirServidor = '" + _DirServidor + "'" + 
                            " SET @ModifyType = '" + _ModifyType + "'" +
  
                            " IF @ModifyType = 'I'" +
                              " BEGIN" +
                                " INSERT INTO ge_parametro(dir_logo_empresa," + 
                                                         " dir_pgm_relatorio," + 
		  				                                 " dir_relatorio," + 
						                                 " dir_backup," + 
						                                 " dir_script," + 
						                                 " dir_importacao," + 
						                                 " dir_exportacao_excel," +
							                             " cod_tipo_proc_esp," +
							                             " cod_tipo_proc_int," +
							                             " mostra_form_menu," +
							                             " dir_foto," +
							                             " dir_servidor)" +
                                                  " VALUES(@DirLogoEmpresa," + 
					                                     " @DirPgmRelatorio," + 
						                                 " @DirRelatorio," + 
						                                 " @DirBackup," + 
						                                 " @DirScript," + 
						                                 " @DirImportacao," + 
						                                 " @DirExportacaoExcel," +
							                             " @IdTipoProcEsp," +
							                             " @IdTipoProcInt," +
							                             " @MostraFormMenu," +
							                             " @DirFoto," +
							                             " @DirServidor)" +
                                " SELECT SCOPE_IDENTITY()" + 
                              " END" +

	                          " IF @ModifyType = 'U'" +
	                            " BEGIN" +
	                              " UPDATE ge_parametro SET dir_logo_empresa = @DirLogoEmpresa," + 
							                              " dir_pgm_relatorio = @DirPgmRelatorio," + 
							                              " dir_relatorio = @DirRelatorio," + 
							                              " dir_backup = @DirBackup," + 
							                              " dir_script = @DirScript," + 
							                              " dir_importacao = @DirImportacao," + 
							                              " dir_exportacao_excel = @DirExportacaoExcel," +
								                          " cod_tipo_proc_esp = @IdTipoProcEsp," +
								                          " cod_tipo_proc_int = @IdTipoProcInt," +
								                          " mostra_form_menu = @MostraFormMenu," +
								                          " dir_foto = @DirFoto," +
								                          " dir_servidor = @DirServidor" + 
					                                " WHERE id_tabela = @IdTabela" +
	                            " END" +

	                          " IF @ModifyType = 'D'" +
	                            " BEGIN" +
	                              " DELETE FROM ge_parametro WHERE id_tabela = @IdTabela" +
	                            " END";

            try
            {
                _Result = DatabasePersistence.CreateInstance(_ConnectionString, _ProviderName).ExecuteCommand(_TSQL, System.Data.CommandType.Text, null, ExecuteType.ExecuteScalar);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Result;
        }

        public string FromToMostraMenuForm(MostraMenuFormType _MostraMenuFormType)
        {
            string _Result = string.Empty;

            switch (_MostraMenuFormType)
            {
                case MostraMenuFormType.MostraFormMenuHide:
                    _Result = "N";
                    break;
                case MostraMenuFormType.MostraFormMenuShow:
                    _Result = "S";
                    break;
            }

            return _Result;
        }

        public string FromToModificaParametroGerenciador(ModificaParametroGerenciadorType _ModificaParametroGerenciadorType)
        {
            string _Result = string.Empty;

            switch (_ModificaParametroGerenciadorType)
            {
                case ModificaParametroGerenciadorType.ParametroGerenciadorAdicionar:
                    _Result = "I";
                    break;
                case ModificaParametroGerenciadorType.ParametroGerenciadorAlterar:
                    _Result = "U";
                    break;
                case ModificaParametroGerenciadorType.ParametroGerenciadorExcluir:
                    _Result = "D";
                    break;
            }

            return _Result;
        }

        public string FromToConsultaParametroGerenciador(ConsultaParametroGerenciadorType _ConsultaParametroGerenciadorType) 
        {
            string _Result = string.Empty;

            switch (_ConsultaParametroGerenciadorType)
            {
                case ConsultaParametroGerenciadorType.ParametroGerenciadorConsultaCodigo:
                    _Result = "C";
                    break;
                case ConsultaParametroGerenciadorType.ParametroGerenciadorConsultaCodigoEsp:
                    _Result = "E";
                    break;
                case ConsultaParametroGerenciadorType.ParametroGerenciadorConsultaCodigoInt:
                    _Result = "I";
                    break;
                case ConsultaParametroGerenciadorType.ParametroGerenciadorConsultaPadrao:
                    _Result = "N";
                    break;
            }

            return _Result;
        }
    }
}
