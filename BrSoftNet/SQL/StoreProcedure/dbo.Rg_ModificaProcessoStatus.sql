USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Rg_ModificaProcessoStatus]    Script Date: 04/28/2015 13:51:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Rg_ModificaProcessoStatus]
(
	@IdRgStatus int,
	@DescrStatus varchar(30),
	@ModifyType char(1) = 'N'
)
AS
BEGIN
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
				INSERT INTO rg_status(descr_status) VALUES (@DescrStatus);
			END

		  IF @ModifyType = 'U'
			BEGIN
				UPDATE rg_status SET descr_status = @DescrStatus WHERE cod_status = @IdRgStatus;
			END

		  IF @ModifyType = 'D'
			BEGIN
				DELETE FROM rg_status WHERE cod_status = @IdRgStatus;
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
