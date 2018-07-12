CREATE PROCEDURE [dbo].[Ge_RetornaEmpresaConsolidadRegistroGeralPorVinculo]
AS
BEGIN
	/* Select da tabela Ge_Empresa_Consolidada */
    SELECT empCo.cod_empr_consol AS cod_empr_consol,
		   empCo.descr_empr_consol AS descr_empr_consol,
		   empCo.ativa AS ativa	
	  FROM ge_empresa_consol AS empCo
		
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
INNER JOIN ge_empresa_consol AS empCo
		ON reg.cod_empr = empCo.cod_empr_consol
END		