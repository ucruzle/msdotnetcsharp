CREATE PROCEDURE [dbo].[Ge_ModificaProcessoTipoProcesso]
(
	@CodigoTipoProcesso int,
	@DescricaoTipoProcesso varchar(30),
	@SequenciaTipoProcesso int,
	@ModifyType char(1) = 'N'	
)
AS
BEGIN
	DECLARE
		@IdTipoProcesso int = 0;
		
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
				INSERT INTO ge_tipo_processo(descr_tipo_proc, sequ_tipo_proc) VALUES(@DescricaoTipoProcesso, @SequenciaTipoProcesso)
				
				SELECT @IdTipoProcesso = SCOPE_IDENTITY(); /* Retorno do IDENTITY do ultimo registro da tabela ge_tipo_processo */
				
				SELECT @IdTipoProcesso AS CodigoTipoProcesso;
			END

		  IF @ModifyType = 'U'
			BEGIN
				SET @IdTipoProcesso = @CodigoTipoProcesso;
				
				UPDATE ge_tipo_processo SET descr_tipo_proc = @DescricaoTipoProcesso, 
											sequ_tipo_proc = @SequenciaTipoProcesso  
									  WHERE cod_tipo_proc = @CodigoTipoProcesso
									  
				SELECT @IdTipoProcesso AS CodigoTipoProcesso;					  
			END

		  IF @ModifyType = 'D'
			BEGIN
				SET @IdTipoProcesso = @CodigoTipoProcesso;
			
				DELETE FROM ge_tipo_processo WHERE cod_tipo_proc = @CodigoTipoProcesso
				
				SELECT @IdTipoProcesso AS CodigoTipoProcesso;
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
