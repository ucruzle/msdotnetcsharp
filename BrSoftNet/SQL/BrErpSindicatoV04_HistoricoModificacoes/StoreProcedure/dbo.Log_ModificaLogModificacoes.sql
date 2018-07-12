CREATE PROCEDURE [dbo].[Log_ModificaLogModificacoes]
(
	@XMLChangeLog xml
)
AS
BEGIN
  DECLARE
    @ChangeHeaders xml = NULL,
	@ChangeItems xml = NULL,
    @IdChangeHeaders char(18) = '';	

    SELECT @ChangeHeaders = E.C.query('.') FROM @XMLChangeLog.nodes('/MappingExecuteChangeLog/ChangeHeaders') as E(C);
    SELECT @ChangeItems = E.C.query('.') FROM @XMLChangeLog.nodes('/MappingExecuteChangeLog/ChangeItems') as E(C);

	BEGIN TRY 
	  BEGIN TRANSACTION /* Inicia a transação para modificações da tabela CabecalhoModificacoes */
	  
	      /* Gravar dados referentes ao cadastro de Cabeçalho de Modificações */

		  INSERT INTO CabecalhoModificacoes(Id,
											CodigoRegistro, 
											NomeProcesso,
											TipoModificacao, 
											Usuario, 
											DataHora, 
											StatusExecucao) 
									 SELECT E.C.value('Id[1]', 'char(18)') as Id,
											E.C.value('CodigoRegistro[1]', 'int') as CodigoRegistro,
											E.C.value('NomeProcesso[1]', 'varchar(100)') as NomeProcesso,
											E.C.value('TipoModificacao[1]', 'char(1)') as TipoModificacao,
											E.C.value('Usuario[1]', 'char(20)') as Usuario,
											E.C.value('DataHora[1]', 'datetime') as DataHora,
											E.C.value('StatusExecucao[1]', 'char(1)') as StatusExecucao
									   FROM @ChangeHeaders.nodes('/ChangeHeaders/ChangesHeader') AS E(C)

		  /* Gravar dados referentes ao cadastro de Itens de Modificações */
		  
		  SET @IdChangeHeaders = @ChangeHeaders.value('(/ChangeHeaders/ChangesHeader/Id)[1]', 'char(18)');
		  
		  INSERT INTO ItensModificacoes(IdCabecalhoModificacoes,
										IdItem,
								        NomeTabela,
										NomeCampo,
										ValorAntigo,
										ValorNovo)
								 SELECT @IdChangeHeaders as IdCabecalhoModificacoes,
										E.C.value('IdItem[1]', 'int') as IdItem,
										E.C.value('NomeTabela[1]', 'varchar(30)') as NomeTabela,
										E.C.value('NomeCampo[1]', 'varchar(30)') as NomeCampo,
										E.C.value('ValorAntigo[1]', 'varchar(MAX)') as ValorAntigo,
										E.C.value('ValorNovo[1]', 'varchar(MAX)') as ValorNovo										
								   FROM @ChangeItems.nodes('/ChangeItems/ChangeItem') AS E(C)
			
	  COMMIT TRANSACTION /* Finaliza a transação para modificações da tabela ItensModificacoes */
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