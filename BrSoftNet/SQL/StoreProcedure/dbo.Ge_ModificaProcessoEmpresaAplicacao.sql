CREATE PROCEDURE [dbo].[Ge_ModificaProcessoEmpresaAplicacao]
(
	@CodigoEmpresa int,
	@CodigoAplicacao int,
	@DescricaoEmpresa varchar(100),
	@DescricaoAplicacao varchar(40),
	@ModifyType char(1) = 'N'	
)
AS
BEGIN
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
				INSERT INTO ge_empresa_aplicacao(cod_empr, cod_aplic) VALUES(@CodigoEmpresa, @CodigoAplicacao)
			END

		  IF @ModifyType = 'U'/*Não possui Update nesse processo*/
			BEGIN
				UPDATE ge_empresa_aplicacao SET cod_empr = @CodigoEmpresa, cod_aplic = @CodigoAplicacao WHERE cod_empr = @CodigoEmpresa and cod_aplic = @CodigoAplicacao
			END

		  IF @ModifyType = 'D'
			BEGIN
				DELETE FROM ge_empresa_aplicacao WHERE cod_empr = @CodigoEmpresa and cod_aplic = @CodigoAplicacao
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