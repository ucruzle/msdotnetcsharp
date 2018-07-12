CREATE PROCEDURE [dbo].[Rg_ModificaProcessoLogRegistroGeral]
(
	@IdEmpresa int,
	@IdRg int,
	@Usuario varchar(15),
	@DataHora datetime,
	@Acoes char(1),
	@Status char(1),
	@LogId uniqueidentifier,
	@Aplicacao varchar(50),
	@Metodos varchar(150),
	@Disparador varchar(250),
	@CadeiaExc varchar(500),
	@LinkAux varchar(400),
	@InfoChaves varchar(500),
	@Descricao varchar(300),
	@Mensagem varchar(500)
)
AS
BEGIN
	BEGIN TRY 
	BEGIN TRANSACTION
	  INSERT INTO rg_log_reg_geral(IdEmpresa,
								   IdRg,
								   usuario,
								   datahora,
								   acoes,
								   [status],
								   logid,
								   aplicacao,
								   metodos,
								   disparador,
								   cadeiaexc,
								   linkaux,
								   infochaves,
								   descricao,
								   mensagem)
						    VALUES(@IdEmpresa,
								   @IdRg,
								   @Usuario,
								   @DataHora,
								   @Acoes,
								   @Status,
								   @LogId,
								   @Aplicacao,
								   @Metodos,
								   @Disparador,
								   @CadeiaExc,
								   @LinkAux,
								   @InfoChaves,
								   @Descricao,
								   @Mensagem)
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


