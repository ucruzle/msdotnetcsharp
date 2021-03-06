USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Ge_ModificaProcessoProcesso]    Script Date: 04/28/2015 09:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Ge_ModificaProcessoProcesso]
(
	@CodigoProcesso int,
	@DescricaoProcesso varchar(40),
	@CodigoTipoProcesso int,
	@CodigoAplicacao int,
	@Ativo char(1),
	@Form varchar(30),
	@SequenciaProcesso int,
	@ModifyType char(1) = 'N'	
)
AS
BEGIN
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
				INSERT INTO ge_processo(descr_proc, cod_tipo_proc, cod_aplic, ativo, form) VALUES(@DescricaoProcesso, @CodigoTipoProcesso, @CodigoAplicacao, @Ativo, @Form)
			END

		  IF @ModifyType = 'U'
			BEGIN
				UPDATE ge_processo SET descr_proc = @DescricaoProcesso, cod_tipo_proc = @CodigoTipoProcesso, cod_aplic = @CodigoAplicacao, ativo = @Ativo, form = @Form WHERE cod_proc = @CodigoProcesso
			END

		  IF @ModifyType = 'D'
			BEGIN
				DELETE FROM ge_processo WHERE cod_proc = @CodigoProcesso
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
