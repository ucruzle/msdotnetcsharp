CREATE PROCEDURE [dbo].[Rg_RetornaTipoFone]
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
					'TF.cod_tipo_fone,
					 TF.descr_tipo_fone
				FROM rg_tipo_fone TF'

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