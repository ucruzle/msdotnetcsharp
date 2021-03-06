USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Rg_ModificaProcessoTipoFone]    Script Date: 03/02/2015 10:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Rg_ModificaProcessoTipoFone]
(
	@IdTipoFone int,
	@DescrTipoFone varchar(30),
	@ModifyType char(1) = 'N'
)
AS
BEGIN
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
				INSERT INTO rg_tipo_fone(descr_tipo_fone) VALUES(@DescrTipoFone);
			END

		  IF @ModifyType = 'U'
			BEGIN
				UPDATE rg_tipo_fone SET descr_tipo_fone = @DescrTipoFone WHERE cod_tipo_fone = @IdTipoFone;
			END

		  IF @ModifyType = 'D'
			BEGIN
				DELETE FROM rg_tipo_fone WHERE cod_tipo_fone = @IdTipoFone;
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
