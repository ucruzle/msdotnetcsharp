CREATE PROCEDURE [dbo].[Ge_RetornaEmpresaRegistroGeralPorVinculo]
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
		
	/* Select da tabela Rg_Reg_Geral */	
	SELECT DISTINCT
		   reg.cod_empr AS cod_empr,
		   reg.cod_rg AS cod_rg,
		   reg.razao_social AS razao_social,
		   reg.tipo_rg AS tipo_rg,
		   reg.cod_status AS cod_status,
		   reg.data_hora AS data_hora,
		   reg.usuario AS usuario,
		   reg.nome_fantasia AS nome_fantasia,
		   reg.optante_simples AS optante_simples
	  FROM rg_reg_geral AS reg	 
INNER JOIN ge_empresa AS emp
		ON reg.cod_empr = emp.cod_empr
END		
		