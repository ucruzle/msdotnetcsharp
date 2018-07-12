ALTER PROCEDURE [dbo].[Rg_ModificaProcessoMunicipio]
(
	@CodigoMunicipio int,
	@Municipio varchar(40),
	@SiglaEstado char(2),
	@ModifyType char(1) = 'N'
)
AS
BEGIN
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
				INSERT INTO rg_municipio(municipio, sigla_estado) VALUES(@Municipio, @SiglaEstado)
			END

		  IF @ModifyType = 'U'
			BEGIN
				UPDATE rg_municipio SET municipio = @Municipio, sigla_estado = @SiglaEstado WHERE cod_municipio = @CodigoMunicipio
			END

		  IF @ModifyType = 'D'
			BEGIN
				DELETE FROM rg_municipio WHERE cod_municipio = @CodigoMunicipio
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
