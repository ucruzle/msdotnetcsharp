USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Ge_ModificaProcessoGrupo]    Script Date: 04/28/2015 09:33:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Ge_ModificaProcessoGrupo]
(
	@CodigoGrupo int,
	@DescricaoGrupo varchar(40),
	@ModifyType char(1) = 'N'
)
AS
BEGIN
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
				INSERT INTO ge_grupo(descr_grupo) VALUES(@DescricaoGrupo);
			END

		  IF @ModifyType = 'U'
			BEGIN
				UPDATE ge_grupo	SET descr_grupo = @DescricaoGrupo	WHERE cod_grupo = @CodigoGrupo;
			END

		  IF @ModifyType = 'D'
			BEGIN
				DELETE FROM ge_grupo WHERE cod_grupo = @CodigoGrupo;
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
