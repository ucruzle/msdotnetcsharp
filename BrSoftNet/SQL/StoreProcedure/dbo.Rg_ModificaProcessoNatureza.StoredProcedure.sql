USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Rg_ModificaProcessoNatureza]    Script Date: 03/02/2015 10:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Rg_ModificaProcessoNatureza]
(
	@CodigoNatureza int,
	@DescricaoNatureza varchar(40),
	@ModifyType char(1) = 'N'
)
AS
BEGIN
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
				INSERT INTO rg_natureza(cod_natureza, descr_natureza) VALUES(@CodigoNatureza, @DescricaoNatureza);
			END

		  IF @ModifyType = 'U'
			BEGIN
				UPDATE rg_natureza SET descr_natureza = @DescricaoNatureza WHERE cod_natureza = @CodigoNatureza;
			END

		  IF @ModifyType = 'D'
			BEGIN
				DELETE FROM rg_natureza WHERE cod_natureza = @CodigoNatureza;
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
