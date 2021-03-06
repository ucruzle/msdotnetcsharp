USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Ge_RetornaEmpresa]    Script Date: 03/02/2015 10:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ge_RetornaEmpresa]
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
				  ,descr_empr 
				  ,descr_empr_red 
				  ,cod_empr_consol 
				  ,ativa 
				  ,cod_rg 
				  ,host 
				  ,port 
				  ,username 
				  ,senha 
				  ,e_mail 
				  ,endereco_banco 
				  ,versao 
				FROM ge_empresa'

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
