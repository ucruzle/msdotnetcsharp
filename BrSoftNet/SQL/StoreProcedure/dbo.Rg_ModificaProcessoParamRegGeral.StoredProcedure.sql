USE [BrErpSindicatoV04]
GO
/****** Object:  StoredProcedure [dbo].[Rg_ModificaProcessoParamRegGeral]    Script Date: 03/02/2015 10:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Rg_ModificaProcessoParamRegGeral]
(
	@CodigoEmpresa int,
	@CodigoNatFunc int,
	@CodigoNatFuncLider int,
	@CodigoNatCliente int,
	@CodigoNatFornecedor int,
	@CodigoNatBanco int,
	@CodigoStatusAtivo int,
	@CodigoStatusInativo int,
	@PermiteCGCCPFZerado char(1),
	@CodigoNatTomadora int,
	@CodigoNatResp int,
	@PermiteCGCCPFDuplicado char(1),
	@ModifyType char(1) = 'N'
)
AS
BEGIN
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
				INSERT INTO rg_param_reg_geral(cod_empr, cod_nat_func, cod_nat_func_lider, cod_nat_cliente, cod_nat_fornec, cod_nat_banco, cod_status_ativo, cod_status_inativo, permite_cgc_cpf_zerado, cod_nat_tomadora, cod_nat_resp, permite_cgc_cpf_duplic) VALUES(@CodigoEmpresa, @CodigoNatFunc, @CodigoNatFuncLider, @CodigoNatCliente, @CodigoNatFornecedor, @CodigoNatBanco, @CodigoStatusAtivo, @CodigoStatusInativo, @PermiteCGCCPFZerado, @CodigoNatTomadora, @CodigoNatResp, @PermiteCGCCPFDuplicado)
			END

		  IF @ModifyType = 'U'
			BEGIN
				UPDATE rg_param_reg_geral SET cod_empr = @CodigoEmpresa, cod_nat_func = @CodigoNatFunc, cod_nat_func_lider = @CodigoNatFuncLider, cod_nat_cliente = @CodigoNatCliente, cod_nat_fornec = @CodigoNatFornecedor, cod_nat_banco = @CodigoNatBanco, cod_status_ativo = @CodigoStatusAtivo, cod_status_inativo = @CodigoStatusInativo, permite_cgc_cpf_zerado = @PermiteCGCCPFZerado, cod_nat_tomadora = @CodigoNatTomadora, cod_nat_resp = @CodigoNatResp, permite_cgc_cpf_duplic = @PermiteCGCCPFDuplicado WHERE cod_empr = @CodigoEmpresa
			END

		  IF @ModifyType = 'D'
			BEGIN
				DELETE FROM rg_param_reg_geral WHERE cod_empr = @CodigoEmpresa
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
