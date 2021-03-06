USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Ge_RetornaUsuario]    Script Date: 03/02/2015 10:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ge_RetornaUsuario]
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
				  'usuario 
				  ,nome 
				  ,cod_empr 
				  ,cod_rg 
				  ,status_dba 
				  ,dt_cadastro 
				  ,senha 
				  ,ramal 
				  ,ativo 
				  ,usuario_incl 
				FROM ge_usuario'

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
