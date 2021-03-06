CREATE PROCEDURE [dbo].[Ge_RetornaNoDeAplicacoesNoMenu]
(
	@Usuario varchar(15),
	@CodigoEmpresa int
)
AS
BEGIN
    SELECT DISTINCT 
		   apl.cod_aplic as CodigoAplicacao,
		   apl.descr_aplic as DescricaoAplicacao 
	  FROM ge_processo as pro
INNER JOIN ge_aplicacao as apl
		ON pro.cod_aplic = apl.cod_aplic
INNER JOIN ge_usuario_processo as upr
		ON pro.cod_proc = upr.cod_proc
	 WHERE upr.cod_empr = @CodigoEmpresa
	   AND upr.usuario = @Usuario
	   
	UNION
	   
	SELECT DISTINCT 
		   apl.cod_aplic as CodigoAplicacao,
		   apl.descr_aplic as DescricaoAplicacao 
	  FROM ge_processo as pro
INNER JOIN ge_aplicacao as apl
		ON pro.cod_aplic = apl.cod_aplic
INNER JOIN ge_grupo_processo as gpr
		ON pro.cod_proc = gpr.cod_proc
	 WHERE gpr.cod_empr = @CodigoEmpresa
	   AND gpr.cod_grupo = (SELECT DISTINCT 
	                               p.cod_grupo 
	                          FROM ge_grupo_processo AS p 
	                    INNER JOIN ge_grupo AS g
	                            ON p.cod_grupo = g.cod_grupo
	                         WHERE p.cod_empr = @CodigoEmpresa)
END