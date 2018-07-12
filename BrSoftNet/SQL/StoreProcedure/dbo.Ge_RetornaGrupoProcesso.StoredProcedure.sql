CREATE PROCEDURE [dbo].[Ge_RetornaGrupoProcesso]
(
  @StrFilter VARCHAR(MAX) = '',
  @IsFilter bit = 0
)
AS
BEGIN
	DECLARE
		@StrQuery VARCHAR(MAX),
		@StrGroupOrder VARCHAR(MAX),
		@StrExc VARCHAR(MAX);

		SET @StrQuery = 'emp.cod_empr as CodigoEmpresa,					  
						 emp.descr_empr as DescricaoEmpresa,
						 apl.cod_aplic as CodigoAplicacao, 
						 apl.descr_aplic as DescricaoAplicacao,
						 grp.cod_grupo as cod_grupo,
						 gru.descr_grupo as descr_grupo,						 
						 tpr.cod_tipo_proc as codigoTipoProcesso,
						 tpr.descr_tipo_proc as DescricaoTipoProcesso,
						 pro.cod_proc as CodigoProcesso,
						 pro.descr_proc as DescricaoProcesso 
					from ge_grupo_processo as grp
			  inner join ge_empresa as emp
			   	      on grp.cod_empr = emp.cod_empr
			  inner join ge_grupo as gru
			          on grp.cod_grupo = gru.cod_grupo 
			  inner join ge_processo as pro 
					  on grp.cod_proc = pro.cod_proc 
			  inner join ge_tipo_processo as tpr 
					  on pro.cod_tipo_proc = tpr.cod_tipo_proc 
			  inner join ge_aplicacao as apl
					  on apl.cod_aplic = pro.cod_aplic '
					  
		SET @StrGroupOrder = 'group by emp.cod_empr,					  
							  emp.descr_empr,
							  apl.cod_aplic, 
							  apl.descr_aplic,
							  grp.cod_grupo,
							  gru.descr_grupo,
							  tpr.cod_tipo_proc,
							  tpr.descr_tipo_proc,
							  pro.cod_proc,
							  pro.descr_proc
					 order by emp.cod_empr,					  
							  apl.cod_aplic, 
							  grp.cod_grupo,
							  tpr.cod_tipo_proc,
							  pro.cod_proc'

	IF (@IsFilter <> 0) 
		BEGIN 
			SET @StrExc = 'SELECT DISTINCT ' + @StrQuery + @StrFilter + @StrGroupOrder
		END
	ELSE
		BEGIN 
			SET @StrExc = 'SELECT DISTINCT TOP 100 ' + @StrQuery + @StrGroupOrder
		END

	--PRINT (@StrExc)
	EXEC (@StrExc)
END
