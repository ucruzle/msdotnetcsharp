USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Ge_RetornaProcesso]    Script Date: 03/02/2015 10:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ge_RetornaProcesso]
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
				  'cod_proc 
				  ,descr_proc 
				  ,cod_tipo_proc 
				  ,cod_aplic 
				  ,ativo 
				  ,form 
				  ,sequ_proc 
				FROM ge_processo'

	IF (@IsFilter <> 0) 
		BEGIN 
			SET @StrExc = 'SELECT DISTINCT ' + @StrQuery + @StrFilter
		END
	ELSE
		BEGIN 
			SET @StrExc = 'SELECT DISTINCT ' + @StrQuery
		END

	--PRINT (@StrExc)
	EXEC (@StrExc)
END
GO
