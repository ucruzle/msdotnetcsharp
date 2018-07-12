CREATE PROCEDURE [dbo].[Ge_RetornaProcessoUsuarioGrupo]
AS
BEGIN
	/* Seleciona dados Empresas */
	
	SELECT emp.cod_empr AS cod_empr, 
		   emp.descr_empr AS descr_empr, 
		   emp.descr_empr_red AS descr_empr_red, 
		   emp.cod_empr_consol AS cod_empr_consol, 
		   emp.ativa AS ativa, 
		   emp.cod_rg AS cod_rg, 
		   emp.host AS host, 
		   emp.port AS port, 
		   emp.username AS username, 
		   emp.senha AS senha, 
		   emp.e_mail AS e_mail, 
		   emp.endereco_banco AS endereco_banco, 
		   emp.versao AS versao 
	  FROM ge_empresa AS emp
	
	/* Seleciona dados Usuario */
	
	SELECT usu.usuario AS usuario,
		   usu.nome AS nome,
		   usu.cod_empr AS cod_empr,
		   usu.cod_rg AS cod_rg,
		   usu.status_dba AS status_dba,
		   usu.dt_cadastro AS dt_cadastro,
		   usu.senha AS senha,
		   usu.ramal AS ramal,
		   usu.ativo AS ativo,
		   usu.usuario_incl AS usuario_incl
	  FROM ge_usuario AS usu
	
	/* Seleciona dados Processo */
	
	SELECT gru.cod_grupo AS cod_grupo, 
		   gru.descr_grupo AS descr_grupo
	  FROM ge_grupo AS gru
END