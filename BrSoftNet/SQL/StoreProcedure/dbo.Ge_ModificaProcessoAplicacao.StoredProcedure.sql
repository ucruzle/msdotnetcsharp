USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Ge_ModificaProcessoAplicacao]    Script Date: 03/02/2015 10:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ge_ModificaProcessoAplicacao]
(
	@CodAplicacao int,
	@DescreciaoAplicacao varchar(40),
	@SiglaAplicacao char(2),
	@SequenciaAplicacao int,
	@AtivaAplicacao char(1),
	@FormAplicacao varchar(30),
	@ModifyType char(1) = 'N'
)
AS
BEGIN
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
				INSERT INTO ge_aplicacao(descr_aplic, sigla_aplic, sequ_aplic, ativa, form_aplic) VALUES(@DescreciaoAplicacao, @SiglaAplicacao, @SequenciaAplicacao, @AtivaAplicacao, @FormAplicacao);
			END

		  IF @ModifyType = 'U'
			BEGIN
				UPDATE ge_aplicacao
					SET descr_aplic = @DescreciaoAplicacao, 
						sigla_aplic = @SiglaAplicacao,
						sequ_aplic = @SequenciaAplicacao,
						ativa = @AtivaAplicacao,
						form_aplic = @FormAplicacao
				WHERE cod_aplic = @CodAplicacao;
			END

		  IF @ModifyType = 'D'
			BEGIN
				DELETE FROM ge_aplicacao WHERE cod_aplic = @CodAplicacao;
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
GO
