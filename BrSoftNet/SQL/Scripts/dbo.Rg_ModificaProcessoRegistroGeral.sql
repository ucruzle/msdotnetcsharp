CREATE PROCEDURE [dbo].[Rg_ModificaProcessoRegistroGeral]
(
	@XMLProcessoRegistroGeral xml,
	@ModifyType char(1) = 'N'
)
AS
BEGIN
  DECLARE
    @RegistrosGerais xml = NULL,
	@Enderecos xml = NULL,
	@Telefones xml = NULL,
	@Naturezas xml = NULL,
	@PessoasFisicasJuridicas xml = null,
    @IdEmpr int = 0,
	@IdRg int = 0;

    SELECT @RegistrosGerais = E.C.query('.') FROM @XMLProcessoRegistroGeral.nodes('/RegistroGeralProcessMapping/RgRegGerais') as E(C);
    SELECT @Enderecos = E.C.query('.') FROM @XMLProcessoRegistroGeral.nodes('/RegistroGeralProcessMapping/RgEnderecos') as E(C);
    SELECT @Telefones = E.C.query('.') FROM @XMLProcessoRegistroGeral.nodes('/RegistroGeralProcessMapping/RgTelefones') as E(C);
    SELECT @Naturezas = E.C.query('.') FROM @XMLProcessoRegistroGeral.nodes('/RegistroGeralProcessMapping/RgRegGeralNaturezas') as E(C);
    SELECT @PessoasFisicasJuridicas = E.C.query('.') FROM @XMLProcessoRegistroGeral.nodes('/RegistroGeralProcessMapping/RgFisicasJuridicas') as E(C);

	BEGIN TRY 
	BEGIN TRANSACTION
	  IF @ModifyType = 'I'
	    BEGIN
		  SET @IdEmpr = @RegistrosGerais.value('(/RgRegGerais/RgRegGeral/IdEmpr)[1]', 'int');

		  /* Gravar dados referentes ao cadastro de Registro Gerais de Parceiros de Negócio */

		  INSERT INTO rg_reg_geral(cod_empr, 
								   razao_social, 
								   tipo_rg, 
								   cod_status, 
								   data_hora, 
								   usuario, 
								   nome_fantasia, 
								   optante_simples) 
							SELECT E.C.value('IdEmpr[1]', 'int') as cod_empr,
								   E.C.value('RazaoSocial[1]', 'varchar(100)') as razao_social,
								   E.C.value('TipoRg[1]', 'char(1)') as tipo_rg,
								   E.C.value('IdStatus[1]', 'int') as cod_status,
								   E.C.value('DataHora[1]', 'datetime') as data_hora,
								   E.C.value('Usuario[1]', 'varchar(15)') as usuario,
								   E.C.value('NomeFantasia[1]', 'varchar(20)') as nome_fantasia,
								   E.C.value('OptanteSimples[1]', 'char(1)') as optante_simples
							  FROM @RegistrosGerais.nodes('/RgRegGerais/RgRegGeral') AS E(C)

		  SELECT @IdRg = SCOPE_IDENTITY(); /* Retorna o Identity da Tabela gerado */

		  /* Gravar dados referentes ao cadastro de Endereços e Localidades */

			INSERT INTO rg_endereco(cod_empr,
									cod_rg,
									endereco,
									nro_endereco,
									bairro,
									complemento,
									cep,
									cod_municipio,
									cx_postal,
									home_page,
									e_mail)
							 SELECT E.C.value('IdEmpr[1]', 'int') as cod_empr,
									@IdRg as cod_rg,
									E.C.value('Endereco[1]', 'varchar(40)') as endereco,
									E.C.value('Nro[1]', 'varchar(10)') as nro_endereco,
									E.C.value('Bairro[1]', 'varchar(30)') as bairro,
									E.C.value('Complemento[1]', 'varchar(40)') as complemento,
									E.C.value('CEP[1]', 'int') as cep,
									E.C.value('IdMunicipio[1]', 'int') as cod_municipio,
									E.C.value('CxPostal[1]', 'int') as cx_postal,
									E.C.value('HomePage[1]', 'varchar(60)') as home_page,
									E.C.value('EMail[1]', 'varchar(50)') as e_mail
							   FROM @Enderecos.nodes('/RgEnderecos/RgEndereco') AS E(C)

			/* Gravar dados referentes ao cadastro de Contatos de Telefones */

			INSERT INTO rg_telefone(cod_empr,
									cod_rg,
									seq_tel,
									cod_tipo_fone,
									ddd_fone,
									numero_fone,
									contato,
									e_mail,
									principal) 
							 SELECT E.C.value('IdEmpr[1]', 'int') as cod_empr,
									@IdRg as cod_rg,
									E.C.value('SeqTel[1]', 'int') as seq_tel,
									E.C.value('IdTipoFone[1]', 'int') as cod_tipo_fone,
									E.C.value('DDDFone[1]', 'char(4)') as ddd_fone,
									E.C.value('NroFone[1]', 'varchar(12)') as numero_fone,
									E.C.value('Contato[1]', 'varchar(30)') as contato,
									E.C.value('EMail[1]', 'varchar(60)') as e_mail,
									E.C.value('Principal[1]', 'char(1)') as principal
								FROM @Telefones.nodes('/RgTelefones/RgTelefone') AS E(C)

			/* Gravar dados referentes ao cadastro de Naturezas Gerais */

			INSERT INTO rg_reg_geral_natureza(cod_empr,
											  cod_rg,
											  cod_natureza,
											  cod_status_nat_rg,
											  data_hora,
											  usuario)
									   SELECT E.C.value('IdEmpr[1]', 'int') as cod_empr,
											  @IdRg as cod_rg,
											  E.C.value('IdNatureza[1]', 'int') as cod_natureza,
											  E.C.value('IdStatusNat[1]', 'int') as cod_status_nat_rg,
											  E.C.value('DataHora[1]', 'datetime') as data_hora,
											  E.C.value('Usuario[1]', 'varchar(15)') as usuario
										 FROM @Naturezas.nodes('/RgRegGeralNaturezas/RgRegGeralNatureza') AS E(C)

			/* Gravar dados referentes ao cadastro de pessoas físicas e jurídicas */

			INSERT INTO rg_fisica_juridica(cod_empr,
										   cod_rg,
										   num_cpf,
										   dig_cpf,
										   num_rg,
										   dig_rg,
										   dt_emissao_rg,
										   orgao_exp_rg,
										   insc_municipal,
										   cgc,
										   filial_cgc,
										   dig_cgc,
										   insc_estadual,
										   nro_banco,
										   nro_agencia,
										   dig_agencia,
										   nro_conta,
										   dig_conta,
										   cod_tipo_cta,
										   cei)
									SELECT E.C.value('IdEmpr[1]', 'int') as cod_empr,
								 		   @IdRg as cod_rg,
										   E.C.value('NroCPF[1]', 'int') as num_cpf,
										   E.C.value('DigCPF[1]', 'int') as dig_cpf,
										   E.C.value('NroRg[1]', 'varchar(20)') as num_rg,
										   E.C.value('DigRg[1]', 'varchar(2)') as dig_rg,
										   E.C.value('DtEmissao[1]', 'datetime') as dt_emissao_rg,
										   E.C.value('OrgaoExpRg[1]', 'varchar(10)') as orgao_exp_rg,
										   E.C.value('InscrMunicipal[1]', 'varchar(20)') as insc_municipal,
										   E.C.value('CGC[1]', 'int') as cgc,
										   E.C.value('FilialCGC[1]', 'int') as filial_cgc,
										   E.C.value('DigCGC[1]', 'int') as dig_cgc,
										   E.C.value('InscEstadual[1]', 'varchar(20)') as insc_estadual,
										   E.C.value('NroBanco[1]', 'int') as nro_banco,
										   E.C.value('NroAgencia[1]', 'int') as nro_agencia,
										   E.C.value('DigAgencia[1]', 'int') as dig_agencia,
										   E.C.value('NroConta[1]', 'int') as nro_conta,
										   E.C.value('DigConta[1]', 'int') as dig_conta,
										   E.C.value('IdTipoCta[1]', 'int') as cod_tipo_cta,
										   E.C.value('CEI[1]', 'varchar(20)') as cei
									  FROM @PessoasFisicasJuridicas.nodes('/RgFisicasJuridicas/RgFisicaJuridica') AS E(C)

		  SELECT @IdRg AS IdRg;
		END

	  IF @ModifyType = 'U'
		BEGIN
		  SET @IdEmpr = @RegistrosGerais.value('(/RgRegGerais/RgRegGeral/IdEmpr)[1]', 'int');
		  SET @IdRg = @RegistrosGerais.value('(/RgRegGerais/RgRegGeral/IdRg)[1]', 'int');

		  /* Altera dados referentes ao cadastro de Registro Gerais de Parceiros de Negócio */

		  UPDATE rg_reg_geral SET razao_social = RG.razao_social, 
								  tipo_rg = RG.tipo_rg, 
								  cod_status = RG.cod_status, 
								  data_hora = RG.data_hora, 
								  usuario = RG.usuario, 
								  nome_fantasia = RG.nome_fantasia, 
								  optante_simples = RG.optante_simples 
							 FROM rg_reg_geral 
			   INNER JOIN (SELECT E.C.value('IdEmpr[1]', 'int') as cod_empr,
								  E.C.value('IdRg[1]', 'int') as cod_rg,
								  E.C.value('RazaoSocial[1]', 'varchar(100)') as razao_social,
								  E.C.value('TipoRg[1]', 'char(1)') as tipo_rg,
								  E.C.value('IdStatus[1]', 'int') as cod_status,
								  E.C.value('DataHora[1]', 'datetime') as data_hora,
								  E.C.value('Usuario[1]', 'varchar(15)') as usuario,
								  E.C.value('NomeFantasia[1]', 'varchar(20)') as nome_fantasia,
								  E.C.value('OptanteSimples[1]', 'char(1)') as optante_simples
							 FROM @RegistrosGerais.nodes('/RgRegGerais/RgRegGeral') AS E(C)) AS RG 
							   ON rg_reg_geral.cod_empr = RG.cod_empr 
							  AND rg_reg_geral.cod_rg = RG.cod_rg;

		  /* Altera dados referentes ao cadastro de Endereços e Localidades */

		  UPDATE rg_endereco SET endereco = ED.endereco, 
							     nro_endereco = ED.nro_endereco, 
							     bairro = ED.bairro, 
							     complemento = ED.complemento, 
							     cep = ED.cep, 
							     cod_municipio = ED.cod_municipio, 
							     cx_postal = ED.cx_postal,
							     home_page = ED.home_page,
							     e_mail = ED.e_mail 
							FROM rg_endereco 
			  INNER JOIN (SELECT E.C.value('IdEmpr[1]', 'int') as cod_empr,
			 					 E.C.value('IdRg[1]', 'int') as cod_rg,
								 E.C.value('Endereco[1]', 'varchar(40)') as endereco,
								 E.C.value('Nro[1]', 'varchar(10)') as nro_endereco,
								 E.C.value('Bairro[1]', 'varchar(30)') as bairro,
								 E.C.value('Complemento[1]', 'varchar(40)') as complemento,
								 E.C.value('CEP[1]', 'int') as cep,
								 E.C.value('IdMunicipio[1]', 'int') as cod_municipio,
								 E.C.value('CxPostal[1]', 'int') as cx_postal,
								 E.C.value('HomePage[1]', 'varchar(60)') as home_page,
								 E.C.value('EMail[1]', 'varchar(50)') as e_mail
							FROM @Enderecos.nodes('/RgEnderecos/RgEndereco') AS E(C)) AS ED 
							  ON rg_endereco.cod_empr = ED.cod_empr 
							 AND rg_endereco.cod_rg = ED.cod_rg;

		  /* Altera dados referentes ao cadastro de Contatos de Telefones */

		  IF EXISTS (SELECT * FROM rg_telefone WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg)
	        BEGIN
			  DELETE FROM rg_telefone WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg;
			END

		  INSERT INTO rg_telefone(cod_empr,
								  cod_rg,
								  seq_tel,
								  cod_tipo_fone,
								  ddd_fone,
								  numero_fone,
								  contato,
								  e_mail,
								  principal) 
						   SELECT E.C.value('IdEmpr[1]', 'int') as cod_empr,
								  E.C.value('IdRg[1]', 'int') as cod_rg,
								  E.C.value('SeqTel[1]', 'int') as seq_tel,
								  E.C.value('IdTipoFone[1]', 'int') as cod_tipo_fone,
								  E.C.value('DDDFone[1]', 'char(4)') as ddd_fone,
								  E.C.value('NroFone[1]', 'varchar(12)') as numero_fone,
								  E.C.value('Contato[1]', 'varchar(30)') as contato,
								  E.C.value('EMail[1]', 'varchar(60)') as e_mail,
								  E.C.value('Principal[1]', 'char(1)') as principal
							 FROM @Telefones.nodes('/RgTelefones/RgTelefone') AS E(C)

		  /* Altera dados referentes ao cadastro de Naturezas Gerais */

		  IF EXISTS (SELECT * FROM rg_reg_geral_natureza WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg)
		    BEGIN
			  DELETE FROM rg_reg_geral_natureza WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg
			END

		  INSERT INTO rg_reg_geral_natureza(cod_empr,
											cod_rg,
											cod_natureza,
											cod_status_nat_rg,
											data_hora,
											usuario)
									 SELECT E.C.value('IdEmpr[1]', 'int') as cod_empr,
											E.C.value('IdRg[1]', 'int') as cod_rg,
											E.C.value('IdNatureza[1]', 'int') as cod_natureza,
											E.C.value('IdStatusNat[1]', 'int') as cod_status_nat_rg,
											E.C.value('DataHora[1]', 'datetime') as data_hora,
											E.C.value('Usuario[1]', 'varchar(15)') as usuario
									   FROM @Naturezas.nodes('/RgRegGeralNaturezas/RgRegGeralNatureza') AS E(C)

		  /* Altera dados referentes ao cadastro de pessoas físicas e jurídicas */

		  UPDATE rg_fisica_juridica SET num_cpf = FJ.num_cpf, 
										dig_cpf = FJ.dig_cpf, 
										num_rg = FJ.num_rg, 
										dig_rg = FJ.dig_rg, 
										dt_emissao_rg = FJ.dt_emissao_rg, 
										orgao_exp_rg = FJ.orgao_exp_rg, 
										insc_municipal = FJ.insc_municipal,
										cgc = FJ.cgc,
										filial_cgc = FJ.filial_cgc,
										dig_cgc = FJ.dig_cgc, 
										insc_estadual = FJ.insc_estadual, 
										nro_banco = FJ.nro_banco, 
										nro_agencia = FJ.nro_agencia, 
										dig_agencia = FJ.dig_agencia, 
										nro_conta = FJ.nro_conta,
										dig_conta = FJ.dig_conta,
										cod_tipo_cta = FJ.cod_tipo_cta,
										cei = FJ.cei  
								   FROM rg_fisica_juridica 
					 INNER JOIN (SELECT E.C.value('IdEmpr[1]', 'int') as cod_empr,
										E.C.value('IdRg[1]', 'int') as cod_rg,
										E.C.value('NroCPF[1]', 'int') as num_cpf,
										E.C.value('DigCPF[1]', 'int') as dig_cpf,
										E.C.value('NroRg[1]', 'varchar(20)') as num_rg,
										E.C.value('DigRg[1]', 'varchar(2)') as dig_rg,
										E.C.value('DtEmissao[1]', 'datetime') as dt_emissao_rg,
										E.C.value('OrgaoExpRg[1]', 'varchar(10)') as orgao_exp_rg,
										E.C.value('InscrMunicipal[1]', 'varchar(20)') as insc_municipal,
										E.C.value('CGC[1]', 'int') as cgc,
										E.C.value('FilialCGC[1]', 'int') as filial_cgc,
										E.C.value('DigCGC[1]', 'int') as dig_cgc,
										E.C.value('InscEstadual[1]', 'varchar(20)') as insc_estadual,
										E.C.value('NroBanco[1]', 'int') as nro_banco,
										E.C.value('NroAgencia[1]', 'int') as nro_agencia,
										E.C.value('DigAgencia[1]', 'int') as dig_agencia,
										E.C.value('NroConta[1]', 'int') as nro_conta,
										E.C.value('DigConta[1]', 'int') as dig_conta,
										E.C.value('IdTipoCta[1]', 'int') as cod_tipo_cta,
										E.C.value('CEI[1]', 'varchar(20)') as cei
								   FROM @PessoasFisicasJuridicas.nodes('/RgFisicasJuridicas/RgFisicaJuridica') AS E(C)) AS FJ 
									 ON rg_fisica_juridica.cod_empr = FJ.cod_empr 
									AND rg_fisica_juridica.cod_rg = FJ.cod_rg;
		  SELECT @IdRg AS IdRg;
		END

	  IF @ModifyType = 'D'
		BEGIN
		  SET @IdEmpr = @RegistrosGerais.value('(/RgRegGerais/RgRegGeral/IdEmpr)[1]', 'int');
		  SET @IdRg = @RegistrosGerais.value('(/RgRegGerais/RgRegGeral/IdRg)[1]', 'int');

		  DELETE FROM rg_fisica_juridica WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg    --Exclui dados referentes ao cadastro de pessoas físicas e jurídicas
		  DELETE FROM rg_reg_geral_natureza WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg --Exclui dados referentes ao cadastro de Naturezas Gerais
		  DELETE FROM rg_telefone WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg           --Exclui dados referentes ao cadastro de Contatos de Telefones  
		  DELETE FROM rg_endereco WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg           --Exclui dados referentes ao cadastro de Endereços e Localidades 
		  DELETE FROM rg_reg_geral WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg          --Exclui dados referentes ao cadastro de Registro Gerais de Parceiros de Negócio

		  SELECT @IdRg AS IdRg;
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
