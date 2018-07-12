CREATE PROCEDURE [dbo].[Rg_RetornaRegistroGeral]
(
  @IdEmpr int = 0,
  @IdRg int = 0
)
AS
BEGIN
  SELECT RG.cod_empr,
         RG.cod_rg, 
		 RG.razao_social, 
		 RG.tipo_rg, 
		 RG.cod_status, 
		 RG.data_hora, 
		 RG.usuario, 
		 RG.nome_fantasia, 
		 RG.optante_simples
	FROM rg_reg_geral AS RG
   WHERE RG.cod_empr = @IdEmpr
	 AND RG.cod_rg = @IdRg

  SELECT ED.cod_empr,
		 ED.cod_rg,
		 ED.endereco,
		 ED.nro_endereco,
		 ED.bairro,
		 ED.complemento,
		 ED.cep,
		 ED.cod_municipio,
		 ED.cx_postal,
		 ED.home_page,
		 ED.e_mail
    FROM rg_endereco AS ED
   WHERE ED.cod_empr = @IdEmpr
	 AND ED.cod_rg = @IdRg

  SELECT TE.cod_empr,
		 TE.cod_rg,
		 TE.seq_tel,
		 TE.cod_tipo_fone,
		 TE.ddd_fone,
		 TE.numero_fone,
		 TE.contato,
		 TE.e_mail,
		 TE.principal
    FROM rg_telefone AS TE
   WHERE TE.cod_empr = @IdEmpr
	 AND TE.cod_rg = @IdRg

  SELECT GN.cod_empr,
		 GN.cod_rg,
		 GN.cod_natureza,
		 GN.cod_status_nat_rg,
		 GN.data_hora,
		 GN.usuario
    FROM rg_reg_geral_natureza AS GN
   WHERE GN.cod_empr = @IdEmpr
	 AND GN.cod_rg = @IdRg

  SELECT FJ.cod_empr,
		 FJ.cod_rg,
		 FJ.num_cpf,
		 FJ.dig_cpf,
		 FJ.num_rg,
		 FJ.dig_rg,
		 FJ.dt_emissao_rg,
		 FJ.orgao_exp_rg,
		 FJ.insc_municipal,
		 FJ.cgc,
		 FJ.filial_cgc,
		 FJ.dig_cgc,
		 FJ.insc_estadual,
		 FJ.nro_banco,
		 FJ.nro_agencia,
		 FJ.dig_agencia,
		 FJ.nro_conta,
		 FJ.dig_conta,
		 FJ.cod_tipo_cta,
		 FJ.cei
    FROM rg_fisica_juridica AS FJ
   WHERE FJ.cod_empr = @IdEmpr
	 AND FJ.cod_rg = @IdRg
END