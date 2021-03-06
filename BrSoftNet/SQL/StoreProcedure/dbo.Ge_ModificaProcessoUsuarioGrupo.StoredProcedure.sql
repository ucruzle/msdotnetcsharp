USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Ge_ModificaProcessoUsuarioGrupo]    Script Date: 03/02/2015 10:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ge_ModificaProcessoUsuarioGrupo]
(
	@CodigoEmpresa int,
	@CodigoGrupo int,
	@Usuario varchar(15),
	@ModifyType char(1) = 'N'	
)
AS
BEGIN
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
				INSERT INTO ge_usuario_grupo(cod_empr, cod_grupo, usuario) VALUES(@CodigoEmpresa, @CodigoGrupo, @Usuario)
			END

		  IF @ModifyType = 'U'
			BEGIN
				UPDATE ge_usuario_grupo SET cod_empr = @CodigoEmpresa, cod_grupo = @CodigoGrupo, usuario = @Usuario WHERE cod_empr = @CodigoEmpresa and cod_grupo = @CodigoGrupo and usuario = @Usuario
			END

		  IF @ModifyType = 'D'
			BEGIN
				DELETE FROM ge_usuario_grupo WHERE cod_empr = @CodigoEmpresa and cod_grupo = @CodigoGrupo and usuario = @Usuario
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
