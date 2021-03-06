USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Rg_ModificaProcessoEstado]    Script Date: 03/02/2015 10:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Rg_ModificaProcessoEstado]
(
	@SiglaEstado char(2),
	@DescrEstado varchar(30),
	@SiglaRegiao char(2),
	@ModifyType char(1) = 'N'	
)
AS
BEGIN
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
				INSERT INTO rg_estado(sigla_estado, descr_estado, sigla_regiao) VALUES(@SiglaEstado, @DescrEstado, @SiglaRegiao)
			END

		  IF @ModifyType = 'U'
			BEGIN
				UPDATE rg_estado SET descr_estado = @DescrEstado, sigla_regiao = @SiglaRegiao WHERE sigla_estado = @SiglaEstado
			END

		  IF @ModifyType = 'D'
			BEGIN
				DELETE FROM rg_estado WHERE sigla_estado = @SiglaEstado
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
