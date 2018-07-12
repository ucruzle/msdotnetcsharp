/* TaskFindDataRgRegGeral */
DECLARE
  @IdEmpr INT = 0,
  @IdRg INT = 0;

  SET @IdEmpr = 0;
  SET @IdRg = 0;
		
		
SELECT RG.cod_empr, 
		RG.razao_social,
		RG.tipo_rg, 
		RG.cod_status, 
		RG.data_hora, 
		RG.usuario, 
		RG.nome_fantasia
   FROM rg_reg_geral AS RG
  WHERE RG.cod_empr = @IdEmpr 
	AND RG.cod_rg = @IdRg