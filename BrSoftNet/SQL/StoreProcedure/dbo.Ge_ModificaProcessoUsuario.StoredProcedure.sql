USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Ge_ModificaProcessoUsuario]    Script Date: 03/02/2015 10:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ge_ModificaProcessoUsuario]
(
	@Usuario varchar(15),
	@Nome varchar(40),
	@CodigoEmpresa int,
	@CodigoRG int,
	@StatusDBA char(1),
	@DataCadastro datetime,
	@Senha varchar(40),
	@Ramal char(15),
	@Ativo char(1),
	@ModifyType char(1) = 'N'	
)
AS
BEGIN
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
				INSERT INTO ge_usuario(usuario, nome, cod_empr, cod_rg, status_dba, dt_cadastro, senha, ramal, ativo, usuario_incl) VALUES(@Usuario, @Nome, @CodigoEmpresa, @CodigoRG, @StatusDBA, @DataCadastro, @Senha, @Ramal, @Ativo, '')
			END

		  IF @ModifyType = 'U'
			BEGIN
				UPDATE ge_usuario SET usuario = @Usuario, nome = @Nome, cod_empr = @CodigoEmpresa, cod_rg = @CodigoRG, status_dba = @StatusDBA, dt_cadastro = @DataCadastro, senha = @Senha, ramal = @Ramal, ativo = @Ativo, usuario_incl = '' WHERE usuario = @Usuario
			END

		  IF @ModifyType = 'D'
			BEGIN
				DELETE FROM ge_usuario WHERE usuario = @Usuario
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
