USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Ge_ModificaProcessoEmpresaConsolidada]    Script Date: 03/02/2015 10:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ge_ModificaProcessoEmpresaConsolidada]
(
	@CodigoEmpresaConsolidada int,
	@DescricaoEmpresaConsolidada varchar(100),
	@AtivaEmpresaConsolidada char(1),
	@ModifyType char(1) = 'N'
)
AS
BEGIN
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
				INSERT INTO ge_empresa_consol(descr_empr_consol, ativa) VALUES(@DescricaoEmpresaConsolidada, @AtivaEmpresaConsolidada);
			END

		  IF @ModifyType = 'U'
			BEGIN
				UPDATE ge_empresa_consol
					SET descr_empr_consol = @DescricaoEmpresaConsolidada, 
						ativa = @AtivaEmpresaConsolidada
				WHERE cod_empr_consol = @CodigoEmpresaConsolidada;
			END

		  IF @ModifyType = 'D'
			BEGIN
				DELETE FROM ge_empresa_consol WHERE cod_empr_consol = @CodigoEmpresaConsolidada;
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
