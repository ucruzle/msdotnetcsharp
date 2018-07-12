CREATE PROCEDURE [dbo].[Modifica_Processo_Sessao_Usuario]
(
   @Usuario         Char(15),
   @IdSession       Char(18),
   @DateTimeSession DateTime,
   @MachineName     Char(50),
   @MachineIP       Char(50),
   @LogonNumber     Int     
)
AS
BEGIN
   BEGIN TRY 
		BEGIN TRANSACTION		  
	       IF EXISTS (SELECT * FROM ge_sessao_usuario WHERE Usuario = @Usuario)
	        BEGIN
			  DELETE FROM ge_sessao_usuario where Usuario = @Usuario;
			END
			
			INSERT INTO ge_sessao_usuario(Usuario, IdSession, DateTimeSession, MachineName, MachineIP, LogonNumber)
			                       VALUES(@Usuario, @IdSession, @DateTimeSession, @MachineName, @MachineIP, @LogonNumber);
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
END;