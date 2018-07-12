CREATE PROCEDURE [dbo].[Ge_RetornaTipoProcessoAplicacaoPorVinculo]
AS
BEGIN
	/* Select da tabela ge_tipo_processo */
    SELECT tpPro.cod_tipo_proc AS cod_tipo_proc,
		   tpPro.descr_tipo_proc AS descr_tipo_proc,
		   tpPro.sequ_tipo_proc AS sequ_tipo_proc
	  FROM ge_tipo_processo AS tpPro
		
	/* Select da tabela Ge_Aplicacao */	
	SELECT apl.cod_aplic AS cod_aplic,
		   apl.descr_aplic AS descr_aplic,
		   apl.sigla_aplic AS sigla_aplic,
		   apl.sequ_aplic AS sequ_aplic,
		   apl.ativa AS ativa,
		   apl.form_aplic AS form_aplic
	  FROM ge_aplicacao AS apl 	
END	