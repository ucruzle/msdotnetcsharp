USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Rg_RetornaParamRegGeral]    Script Date: 03/02/2015 10:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Rg_RetornaParamRegGeral]
(
  @StrFilter VARCHAR(MAX) = '',
  @IsFilter bit = 0
)
AS
BEGIN
	DECLARE
		@StrQuery VARCHAR(MAX),
		@StrExc VARCHAR(MAX);

		SET @StrQuery =
				  'cod_empr 
				  ,cod_nat_func 
				  ,cod_nat_func_lider 
				  ,cod_nat_cliente 
				  ,cod_nat_fornec 
				  ,cod_nat_banco 
				  ,cod_status_ativo 
				  ,cod_status_inativo 
				  ,permite_cgc_cpf_zerado 
				  ,cod_nat_tomadora 
				  ,cod_nat_resp 
				  ,permite_cgc_cpf_duplic 
				FROM rg_param_reg_geral'

	IF (@IsFilter <> 0) 
		BEGIN 
			SET @StrExc = 'SELECT DISTINCT ' + @StrQuery + @StrFilter
		END
	ELSE
		BEGIN 
			SET @StrExc = 'SELECT DISTINCT TOP 100 ' + @StrQuery
		END

	--PRINT (@StrExc)
	EXEC (@StrExc)
END
GO
