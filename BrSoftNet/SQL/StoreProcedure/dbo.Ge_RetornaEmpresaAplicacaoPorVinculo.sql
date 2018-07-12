CREATE PROCEDURE [dbo].[Ge_RetornaEmpresaAplicacaoPorVinculo]
AS
BEGIN
	/* Select da tabela Ge_Empresa */
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
		
	/* Select da tabela Ge_Aplicacao */	
	SELECT apl.cod_aplic AS cod_aplic,
		   apl.descr_aplic AS descr_aplic,
		   apl.sigla_aplic AS sigla_aplic,
		   apl.sequ_aplic AS sequ_aplic,
		   apl.ativa AS ativa,
		   apl.form_aplic AS form_aplic
	  FROM ge_aplicacao AS apl 	
END		
		