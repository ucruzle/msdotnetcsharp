USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Rg_ModificaProcessoTipoRg]    Script Date: 03/02/2015 10:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Rg_ModificaProcessoTipoRg]
(
	@TipoRg char(1),
	@DescrTipo varchar(30),
	@ModifyType char(1) = 'N'
)
AS
BEGIN
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
				INSERT INTO rg_tipo_rg(tipo_rg, descr_tipo_rg) VALUES(@TipoRg, @DescrTipo);
			END

		  IF @ModifyType = 'U'
			BEGIN
				UPDATE rg_tipo_rg SET descr_tipo_rg = @DescrTipo WHERE tipo_rg = @TipoRg;
			END

		  IF @ModifyType = 'D'
			BEGIN
				DELETE FROM rg_tipo_rg WHERE tipo_rg = @TipoRg;
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
