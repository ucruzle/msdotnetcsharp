USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Ge_ModificaProcessoEmpresa]    Script Date: 03/02/2015 10:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ge_ModificaProcessoEmpresa]
(
	@CodigoEmpresa int,
	@DescricaoEmpresa varchar(100),
	@DescricaoEmpresaRed char(20),
	@CodigoEmpresaConsolidada int,
	@Ativa char(1),
	@CodigoRg int,
	@Host varchar(40),
	@Port int,
	@Username varchar(40),
	@Senha varchar(40),
	@Email varchar(40),
	@EnderecoBanco varchar(100),
	@Versao varchar(20),
	@ModifyType char(1) = 'N'	
)
AS
BEGIN
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
				INSERT INTO ge_empresa(descr_empr, descr_empr_red, cod_empr_consol, ativa, cod_rg, host, port, username, senha, e_mail, endereco_banco, versao)
					 VALUES(@DescricaoEmpresa, @DescricaoEmpresaRed, @CodigoEmpresaConsolidada, @Ativa, @CodigoRg, @Host, @Port, @Username, @Senha, @Email, @EnderecoBanco, @Versao)
			END

		  IF @ModifyType = 'U'
			BEGIN
				UPDATE ge_empresa SET descr_empr = @DescricaoEmpresa, descr_empr_red = @DescricaoEmpresa, cod_empr_consol = @CodigoEmpresaConsolidada, ativa = @Ativa, cod_rg = @CodigoRg, host = @Host, port = @Port, username = @Username, senha = @Senha, e_mail = @Email, endereco_banco = @EnderecoBanco, versao = @Versao WHERE cod_empr = @CodigoEmpresa
			END

		  IF @ModifyType = 'D'
			BEGIN
				DELETE FROM ge_empresa WHERE cod_empr = @CodigoEmpresa
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
