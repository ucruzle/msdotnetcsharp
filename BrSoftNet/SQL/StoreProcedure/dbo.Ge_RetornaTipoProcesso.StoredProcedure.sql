USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Ge_RetornaEmpresa]    Script Date: 04/02/2015 00:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ge_RetornaTipoProcesso]
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
				  'cod_tipo_proc
				  ,descr_tipo_proc
				  ,sequ_tipo_proc
				FROM ge_tipo_processo'

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