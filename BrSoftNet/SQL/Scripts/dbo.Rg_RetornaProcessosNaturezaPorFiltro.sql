CREATE PROCEDURE [dbo].[Rg_RetornaProcessosNaturezaPorFiltro]
(
	@StrFilter VARCHAR(MAX) = '',
	@IsFilter bit = 0
)
AS
BEGIN
	DECLARE
		@StrQuery VARCHAR(MAX),
		@StrExc VARCHAR(MAX);

	SET @StrQuery = ' NA.cod_natureza,
					  NA.descr_natureza
				 FROM rg_natureza NA'

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