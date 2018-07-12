CREATE PROCEDURE [dbo].[Ge_ModificaProcessoGrupoProcesso]
(
	@XMLProcessoGrupoProcesso xml,
	@ModifyType char(1) = 'N'	   	
)
AS
BEGIN
	DECLARE
		@GrupoProcesso xml = NULL;
		
	SELECT @GrupoProcesso = E.C.query('.') FROM @XMLProcessoGrupoProcesso.nodes('/GrupoProcessoMapping/GrupoProcessos') as E(C);
		
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
			
				/* Gravar dados referentes ao vínculo da empresa, procssos com o grupo */

			    INSERT INTO ge_grupo_processo(cod_empr, 
											    cod_grupo, 
											    cod_proc) 
										 SELECT E.C.value('CodigoEmpresa[1]', 'int') as cod_empr,
											    E.C.value('CodigoGrupo[1]', 'int') as cod_grupo,
											    E.C.value('CodigoProcesso[1]', 'int') as cod_proc											    
										   FROM @GrupoProcesso.nodes('/GrupoProcessos/GeGrupoProcesso') AS E(C)
			END

		  IF @ModifyType = 'U'
			BEGIN
				/* Exclui dados referentes ao vínculo da empresa, procssos com o grupo */
				
				DECLARE
				  @cod_empr int,
				  @cod_grupo int,
				  @cod_proc int;
				  
				DECLARE grp_proc_cursor CURSOR FOR
				SELECT E.C.value('CodigoEmpresa[1]', 'int') as cod_empr,
				       E.C.value('CodigoGrupo[1]', 'int') as cod_grupo,
				       E.C.value('CodigoProcesso[1]', 'int') as cod_proc											    
			      FROM @GrupoProcesso.nodes('/GrupoProcessos/GeGrupoProcesso') AS E(C)
			      
			    OPEN grp_proc_cursor
			    
			    FETCH NEXT FROM grp_proc_cursor
			    INTO @cod_empr, @cod_grupo, @cod_proc
			    
			    WHILE @@FETCH_STATUS = 0
			      BEGIN
				    DELETE FROM ge_grupo_processo WHERE cod_empr = @cod_empr AND cod_grupo = @cod_grupo AND cod_proc = @cod_proc;
			      END
			    
			    CLOSE grp_proc_cursor;
			    DEALLOCATE grp_proc_cursor;
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