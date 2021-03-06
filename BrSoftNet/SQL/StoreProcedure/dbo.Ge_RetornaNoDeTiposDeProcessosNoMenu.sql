CREATE PROCEDURE [dbo].[Ge_RetornaNoDeTiposDeProcessosNoMenu]
(
	@CodigoAplicacao int,
	@CodigoEmpresa int
)
AS
BEGIN
	SELECT DISTINCT 
		   tpr.cod_tipo_proc as CodigoTipoProcesso,
		   tpr.descr_tipo_proc as DescricaoTipoProcesso
	  FROM ge_processo as pro
INNER JOIN ge_tipo_processo as tpr
		ON pro.cod_tipo_proc = tpr.cod_tipo_proc
INNER JOIN ge_usuario_processo as upr
		ON pro.cod_proc = upr.cod_proc
	 WHERE pro.cod_aplic = @CodigoAplicacao
	 
	UNION
	 
    SELECT DISTINCT 
		   tpr.cod_tipo_proc as CodigoTipoProcesso,
		   tpr.descr_tipo_proc as DescricaoTipoProcesso
	  FROM ge_processo as pro
INNER JOIN ge_tipo_processo as tpr
		ON pro.cod_tipo_proc = tpr.cod_tipo_proc
INNER JOIN ge_grupo_processo as gpr
		ON pro.cod_proc = gpr.cod_proc
	 WHERE pro.cod_aplic = @CodigoAplicacao
	   AND gpr.cod_empr = @CodigoEmpresa
	   AND gpr.cod_grupo = (SELECT DISTINCT 
	                               p.cod_grupo 
	                          FROM ge_grupo_processo AS p 
	                    INNER JOIN ge_grupo AS g
	                            ON p.cod_grupo = g.cod_grupo
	                         WHERE p.cod_empr = @CodigoEmpresa)	 
END