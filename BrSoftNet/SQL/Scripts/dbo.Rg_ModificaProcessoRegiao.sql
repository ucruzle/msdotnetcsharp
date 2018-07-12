CREATE PROCEDURE [dbo].[Rg_ModificaProcessoRegiao]
(
	@SiglaRegiao char(2),
	@DescrigaoRegiao varchar(20),
	@ModifyType char(1) = 'N'
)
AS
BEGIN
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
				INSERT INTO rg_regiao(sigla_regiao, descr_regiao) VALUES(@SiglaRegiao, @DescrigaoRegiao);
			END

		  IF @ModifyType = 'U'
			BEGIN
				UPDATE rg_regiao SET descr_regiao = @DescrigaoRegiao WHERE sigla_regiao = @SiglaRegiao;
			END

		  IF @ModifyType = 'D'
			BEGIN
				DELETE FROM rg_regiao WHERE sigla_regiao = @SiglaRegiao;
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