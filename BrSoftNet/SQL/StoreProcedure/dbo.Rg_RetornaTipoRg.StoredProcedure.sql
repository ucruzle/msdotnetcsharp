USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Rg_RetornaTipoRg]    Script Date: 03/02/2015 10:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Rg_RetornaTipoRg]
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
					'RT.tipo_rg, 
					 RT.descr_tipo_rg 
				FROM rg_tipo_rg AS RT'

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
