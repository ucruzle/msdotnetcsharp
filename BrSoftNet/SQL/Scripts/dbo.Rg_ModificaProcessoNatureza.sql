CREATE PROCEDURE [dbo].[Rg_ModificaProcessoNatureza]
(
	@CodigoNatureza int,
	@DescricaoNatureza varchar(40),
	@ModifyType char(1) = 'N'	
)
AS
BEGIN
	DECLARE
		@IdNatureza int = 0;

	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
				INSERT INTO rg_natureza(descr_natureza) VALUES(@DescricaoNatureza);
				SELECT @IdNatureza = SCOPE_IDENTITY(); /* Retorna o Identity da Tabela gerado */
				SELECT @IdNatureza AS CodigoNatureza;
			END

		  IF @ModifyType = 'U'
			BEGIN
				SET @IdNatureza = @CodigoNatureza;
				UPDATE rg_natureza SET descr_natureza = @DescricaoNatureza WHERE cod_natureza = @IdNatureza;
				SELECT @IdNatureza AS CodigoNatureza;
			END

		  IF @ModifyType = 'D'
			BEGIN
				SET @IdNatureza = @CodigoNatureza;
				DELETE FROM rg_natureza WHERE cod_natureza = @CodigoNatureza;
				SELECT @IdNatureza AS CodigoNatureza;
			END
		COMMIT TRANSACTION 
	END TRY 
	  BEGIN CATCH 
		DECLARE @ErrorMessage NVARCHAR(4000); 
		DECLARE @ErrorSeverity INT; 
		DECLARE @ErrorState INT;
		 
		 SELECT @ErrorMessage = ERROR_MESSAGE(), -- Message Text. 
	 			@ErrorState = ERROR_STATE();     -- State.
	 											 -- 16 Value Default references at property Severity	
		IF @@TRANCOUNT > 0 
			ROLLBACK TRANSACTION
			 
		RAISERROR (@ErrorMessage, 16, @ErrorState); 
	  END CATCH 
END