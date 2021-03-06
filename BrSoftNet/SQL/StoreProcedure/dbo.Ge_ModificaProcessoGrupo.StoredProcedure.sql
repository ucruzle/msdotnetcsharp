USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Ge_ModificaProcessoGrupo]    Script Date: 03/02/2015 10:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ge_ModificaProcessoGrupo]
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
				INSERT INTO ge_grupo(cod_grupo, descr_grupo) VALUES(@CodigoGrupo, @DescricaoGrupo);
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
GO
