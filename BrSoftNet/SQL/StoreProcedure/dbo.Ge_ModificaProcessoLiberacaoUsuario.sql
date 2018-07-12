CREATE PROCEDURE [dbo].[Ge_ModificaProcessoLiberacaoUsuario]
(
	@XMLProcessoUsuarioProcesso xml,
	@ModifyType char(1) = 'N'	   	
)
AS
BEGIN
	DECLARE
		@UsuarioProcesso xml = NULL;
		
	SELECT @UsuarioProcesso = E.C.query('.') FROM @XMLProcessoUsuarioProcesso.nodes('/UsuarioProcessoMapping/UsuariosProcessos') as E(C);
		
	BEGIN TRY 
		BEGIN TRANSACTION
		  IF @ModifyType = 'I'
			BEGIN
			
				/* Gravar dados referentes ao vínculo da empresa, procssos com o usuário */

			    INSERT INTO ge_usuario_processo(cod_empr, 
											    usuario, 
											    cod_proc) 
										 SELECT E.C.value('CodigoEmpresa[1]', 'int') as cod_empr,
											    E.C.value('Usuario[1]', 'varchar(15)') as usuario,
											    E.C.value('CodigoProcesso[1]', 'int') as cod_proc											    
										   FROM @UsuarioProcesso.nodes('/UsuariosProcessos/GeUsuarioProcesso') AS E(C)
			END

		  IF @ModifyType = 'U'
			BEGIN
				/* Exclui dados referentes ao vínculo da empresa, procssos com o usuário */
				
				DECLARE
				  @cod_empr int,
				  @usuario varchar(15),
				  @cod_proc int;
				  
				DECLARE usu_proc_cursor CURSOR FOR
				SELECT E.C.value('CodigoEmpresa[1]', 'int') as cod_empr,
				       E.C.value('Usuario[1]', 'varchar(15)') as usuario,
				       E.C.value('CodigoProcesso[1]', 'int') as cod_proc											    
			      FROM @UsuarioProcesso.nodes('/UsuariosProcessos/GeUsuarioProcesso') AS E(C)
			      
			    OPEN usu_proc_cursor /* Abrindo Cursor para leitura */
			    
			    FETCH NEXT FROM usu_proc_cursor INTO @cod_empr, @usuario, @cod_proc /* Lendo a próxima linha */
			    
			    WHILE @@FETCH_STATUS = 0 /* Percorrendo linhas do cursor (enquanto houverem) */
			      BEGIN
				    DELETE FROM ge_usuario_processo WHERE cod_empr = @cod_empr AND usuario = @usuario AND cod_proc = @cod_proc;
					FETCH NEXT FROM usu_proc_cursor INTO @cod_empr, @usuario, @cod_proc /* Lendo a próxima linha */
			      END
			    
			    CLOSE usu_proc_cursor; /* Fechando Cursor para leitura */
			    DEALLOCATE usu_proc_cursor; /* Desalocando o cursor */
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