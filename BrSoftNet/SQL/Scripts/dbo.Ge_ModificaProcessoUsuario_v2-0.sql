CREATE PROCEDURE [dbo].[Ge_ModificaProcessoUsuario]
(
	@usuario varchar(15) = '',
	@nome varchar(40) = '',
	@cod_empr int = 0,
	@cod_rg int = 0,
	@status_dba char(1) = 'N',
    @dt_cadastro datetime = '01/01/0001 00:00:00',
	@senha varchar(40) = '',
	@ramal char(15) = '',
	@ativo char(1) = 'N',
	@usuario_incl varchar(15) = '',
	@ModifyType char(1) = 'N'	
)
AS
BEGIN
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
				INSERT INTO ge_usuario(usuario,
   									   nome,
									   cod_empr,
									   cod_rg,
									   status_dba,
									   dt_cadastro,
									   senha,
									   ramal,
									   ativo,
									   usuario_incl) 
								 VALUES(@usuario,
   									    @nome,
									    @cod_empr,
									    @cod_rg,
									    @status_dba,
									    @dt_cadastro,
									    @senha,
									    @ramal,
									    @ativo,
									    @usuario_incl)
			END

		  IF @ModifyType = 'U'
			BEGIN
				UPDATE ge_usuario SET nome = @nome,
									  cod_empr = @cod_empr,
									  cod_rg = @cod_rg,
									  status_dba = @status_dba,
									  dt_cadastro = @dt_cadastro,
									  senha = @senha,
									  ramal = @ramal,
									  ativo = @ativo,
									  usuario_incl = @usuario_incl
			END

		  IF @ModifyType = 'D'
			BEGIN
				DELETE FROM ge_usuario WHERE usuario = @usuario
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