--Método TaskGetProcessesByIdProcessType

		  select distinct
            upr.cod_proc as CodigoProcesso,
            pro.descr_proc as DescricaoProcesso
          from 
		    ge_usuario_processo as upr
 inner join ge_processo as pro
         on upr.cod_proc = pro.cod_proc
 inner join ge_tipo_processo as tpr
         on pro.cod_tipo_proc = tpr.cod_tipo_proc
 inner join ge_aplicacao as apl
         on apl.cod_aplic = pro.cod_aplic
      where tpr.cod_tipo_proc = 9 /* Consulta por tipo de processo especial */
   order by upr.cod_proc

          select distinct
            upr.cod_proc as CodigoProcesso,
            pro.descr_proc as DescricaoProcesso
          from 
		    ge_usuario_processo as upr
 inner join ge_processo as pro
         on upr.cod_proc = pro.cod_proc
 inner join ge_tipo_processo as tpr
         on pro.cod_tipo_proc = tpr.cod_tipo_proc
 inner join ge_aplicacao as apl
         on apl.cod_aplic = pro.cod_aplic
      where tpr.cod_tipo_proc = 10 /* Consulta por tipo de processo internet */
   order by upr.cod_proc

          select distinct
            upr.cod_proc as CodigoProcesso,
            pro.descr_proc as DescricaoProcesso
          from 
		    ge_usuario_processo as upr
 inner join ge_processo as pro
         on upr.cod_proc = pro.cod_proc
 inner join ge_tipo_processo as tpr
         on pro.cod_tipo_proc = tpr.cod_tipo_proc
 inner join ge_aplicacao as apl
         on apl.cod_aplic = pro.cod_aplic
   order by upr.cod_proc

--Método TaskModifyDataProcesses

  DECLARE
    @IdTabela int = 0,
    @DirLogoEmpresa varchar(100) = '',
    @DirPgmRelatorio varchar(100) = '',
    @DirRelatorio varchar(100) = '',
    @DirBackup varchar(100) = '',
    @DirScript varchar(100) = '',
    @DirImportacao varchar(100) = '',
    @DirExportacaoExcel varchar(100) = '',
	@IdTipoProcEsp int = 0,
	@IdTipoProcInt int = 0,
	@MostraFormMenu char(1) = '',
	@DirFoto varchar(100) = '',
	@DirServidor varchar(100) = '',
    @ModifyType char(1) = 'N'

  SET @IdTabela = 0;
  SET @DirLogoEmpresa = '';
  SET @DirPgmRelatorio = '';
  SET @DirRelatorio = '';
  SET @DirBackup = '';
  SET @DirScript = '';
  SET @DirImportacao = '';
  SET @DirExportacaoExcel = '';
  SET @ModifyType = 'N';
  
  IF @ModifyType = 'I'
    BEGIN
      INSERT INTO ge_parametro(dir_logo_empresa, 
                               dir_pgm_relatorio, 
		  				       dir_relatorio, 
						       dir_backup, 
						       dir_script, 
						       dir_importacao, 
						       dir_exportacao_excel,
							   cod_tipo_proc_esp,
							   cod_tipo_proc_int,
							   mostra_form_menu,
							   dir_foto,
							   dir_servidor) 
                        VALUES(@DirLogoEmpresa, 
					           @DirPgmRelatorio, 
						       @DirRelatorio, 
						       @DirBackup, 
						       @DirScript, 
						       @DirImportacao, 
						       @DirExportacaoExcel,
							   @IdTipoProcEsp,
							   @IdTipoProcInt,
							   @MostraFormMenu,
							   @DirFoto,
							   @DirServidor);
      SELECT SCOPE_IDENTITY(); /* Retorna o Identity da Tabela gerado */
    END

	IF @ModifyType = 'U'
	  BEGIN
	    UPDATE ge_parametro SET dir_logo_empresa = @DirLogoEmpresa, 
							    dir_pgm_relatorio = @DirPgmRelatorio, 
							    dir_relatorio = @DirRelatorio, 
							    dir_backup = @DirBackup, 
							    dir_script = @DirScript, 
							    dir_importacao = @DirImportacao, 
							    dir_exportacao_excel = @DirExportacaoExcel,
								cod_tipo_proc_esp = @IdTipoProcEsp,
								cod_tipo_proc_int = @IdTipoProcInt,
								mostra_form_menu = @MostraFormMenu,
								dir_foto = @DirFoto,
								dir_servidor = @DirServidor 
					      WHERE id_tabela = @IdTabela
	  END

	IF @ModifyType = 'D'
	  BEGIN
	    DELETE FROM ge_parametro WHERE id_tabela = @IdTabela
	  END

--Método TaskGetDataProcessesByFilter

	DECLARE
	  @IdCodigoParametroGerenciador int = 0,
	  @IdTipoProcessoEspecial int = 0,
	  @IdTipoProcessoInternet int = 0,
	  @IdTipoConsulta char(1) = 'N';

	  SET @IdCodigoParametroGerenciador = 0
	  SET @IdTipoProcessoEspecial = 0
	  SET @IdTipoProcessoInternet = 0

	  IF @IdTipoConsulta = 'C'
	    BEGIN
			  SELECT
				  id_tabela,
				  dir_logo_empresa, 
				  dir_pgm_relatorio, 
				  dir_relatorio, 
				  dir_backup, 
				  dir_script, 
				  dir_importacao, 
				  dir_exportacao_excel,
				  cod_tipo_proc_esp,
				  cod_tipo_proc_int,
				  mostra_form_menu,
				  dir_foto,
				  dir_servidor
				FROM
				  ge_parametro
			where id_tabela = @IdCodigoParametroGerenciador
		 order by id_tabela
		END

		IF @IdTipoConsulta = 'E'
	    BEGIN
			  SELECT
				  id_tabela,
				  dir_logo_empresa, 
				  dir_pgm_relatorio, 
				  dir_relatorio, 
				  dir_backup, 
				  dir_script, 
				  dir_importacao, 
				  dir_exportacao_excel
				  cod_tipo_proc_esp,
				  cod_tipo_proc_int,
				  mostra_form_menu,
				  dir_foto,
				  dir_servidor
				FROM
				  ge_parametro
			where cod_tipo_proc_esp = @IdTipoProcessoEspecial
		 order by id_tabela
		END

		IF @IdTipoConsulta = 'I'
	    BEGIN
			  SELECT
				  id_tabela,
				  dir_logo_empresa, 
				  dir_pgm_relatorio, 
				  dir_relatorio, 
				  dir_backup, 
				  dir_script, 
				  dir_importacao, 
				  dir_exportacao_excel
				  cod_tipo_proc_esp,
				  cod_tipo_proc_int,
				  mostra_form_menu,
				  dir_foto,
				  dir_servidor
				FROM
				  ge_parametro
			where cod_tipo_proc_int = @IdTipoProcessoInternet
		 order by id_tabela
		END

		IF @IdTipoConsulta = 'N'
	    BEGIN
			  SELECT TOP 100
				  id_tabela,
				  dir_logo_empresa, 
				  dir_pgm_relatorio, 
				  dir_relatorio, 
				  dir_backup, 
				  dir_script, 
				  dir_importacao, 
				  dir_exportacao_excel,
				  cod_tipo_proc_esp,
				  cod_tipo_proc_int,
				  mostra_form_menu,
				  dir_foto,
				  dir_servidor
				FROM
				  ge_parametro
		 order by id_tabela
		END

--IdTabela
--DirLogoEmpresa
--DirPgmRelatorio
--DirRelatorio
--DirBackup
--DirScript
--DirImportacao
--DirExportacaoExcel
--IdTipoProcEsp
--IdTipoProcInt
--MostraFormMenu
--DirFoto
--DirServidor

/* IMPORTANTE - CRIAR 3 TABELAS DE LOG */
--LogOperacoes - Operações transcionais de sucesso do sistema
--LogExcecoes - Operações de não sucesso no sistema, porém previstas e tratadas
--LogIncidentes - Operações de geração de erros e Bugs no sistemas, obtidas mediante tratamento de exceções			