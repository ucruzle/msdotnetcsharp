/* XTaskRgRegGeralModifyDataProcesses - rg_reg_geral */

DECLARE
    @AtualizaRegistroGeral xml = NULL,
	@RegistrosGerais xml = NULL,
	@Enderecos xml = NULL,
	@Telefones xml = NULL,
	@Naturezas xml = NULL,
	@PessoasFisicasJuridicas xml = null,
    @IdEmpr int = 0,
	@IdRg int = 0,
    @ModifyType char(1) = 'N'

  --SET @AtualizaRegistroGeral = '﻿﻿<RegistrosGerais xmlns:namespace="value">
		--							<RgRegGeral>
		--								<cod_empr>1</cod_empr>
		--								<cod_rg>1</cod_rg>
		--								<razao_social>SINDICATO T.M.M.C.S.M.P.G. DE SOROCABA E REGIÃO</razao_social>
		--								<tipo_rg>J</tipo_rg>
		--								<cod_status>1</cod_status>
		--								<data_hora>2010-06-13T18:20:00</data_hora>
		--								<usuario>DBA</usuario>
		--								<nome_fantasia>Sintramerpro</nome_fantasia>
		--								<optante_simples>N</optante_simples>
		--							</RgRegGeral>
		--						</RegistrosGerais>';

  --SELECT @RegistrosGerais = E.C.query('.') FROM @AtualizaRegistroGeral.nodes('/RegistrosGerais/RgRegGeral') as E(C);

  SET @AtualizaRegistroGeral = '﻿<RegistroGeralProcessMapping><RgRegGerais><RgRegGeral><IdEmpr>1</IdEmpr><IdRg>1</IdRg><RazaoSocial>SINDICATO T.M.M.C.S.M.P.G. DE SOROCABA E REGIÃO</RazaoSocial><TipoRg>J</TipoRg><IdStatus>1</IdStatus><DataHora>2010-06-13T18:20:00</DataHora><Usuario>DBA</Usuario><NomeFantasia>Sintramerpro</NomeFantasia><OptanteSimples>N</OptanteSimples></RgRegGeral></RgRegGerais><RgEnderecos><RgEndereco><IdEmpr>1</IdEmpr><IdRg>1</IdRg><Endereco>Rua: Humberto Notari</Endereco><Nro>364</Nro><Bairro>Jardim Gonçalves</Bairro><CEP>0</CEP><IdMunicipio>3</IdMunicipio><CxPostal>0</CxPostal><HomePage>www.luna_fabiano.com</HomePage><EMail>luna_fabiano@hotmail.com</EMail></RgEndereco></RgEnderecos><RgTelefones><RgTelefone><IdEmpr>1</IdEmpr><IdRg>1</IdRg><SeqTel>1</SeqTel><IdTipoFone>5</IdTipoFone><DDDFone>11</DDDFone><NroFone>3394-1207</NroFone><Contato>NENEM</Contato><EMail>nenem@nenem.com.br</EMail></RgTelefone><RgTelefone><IdEmpr>1</IdEmpr><IdRg>1</IdRg><SeqTel>2</SeqTel><IdTipoFone>5</IdTipoFone><DDDFone>11</DDDFone><NroFone>3394-1207</NroFone><Contato>NENEM</Contato><EMail>nenem@nenem.com.br</EMail></RgTelefone><RgTelefone><IdEmpr>1</IdEmpr><IdRg>1</IdRg><SeqTel>3</SeqTel><IdTipoFone>5</IdTipoFone><DDDFone>11</DDDFone><NroFone>3394-1207</NroFone><Contato>NENEM</Contato><EMail>nenem@nenem.com.br</EMail></RgTelefone></RgTelefones><RgRegGeralNaturezas><RgRegGeralNatureza><IdEmpr>1</IdEmpr><IdRg>1</IdRg><IdNatureza>1</IdNatureza><IdStatusNat>1</IdStatusNat><DataHora>2010-06-13T18:20:00</DataHora><Usuario>DBA</Usuario></RgRegGeralNatureza><RgRegGeralNatureza><IdEmpr>1</IdEmpr><IdRg>1</IdRg><IdNatureza>2</IdNatureza><IdStatusNat>1</IdStatusNat><DataHora>2010-06-13T18:20:00</DataHora><Usuario>DBA</Usuario></RgRegGeralNatureza><RgRegGeralNatureza><IdEmpr>1</IdEmpr><IdRg>1</IdRg><IdNatureza>1</IdNatureza><IdStatusNat>3</IdStatusNat><DataHora>2010-06-13T18:20:00</DataHora><Usuario>DBA</Usuario></RgRegGeralNatureza></RgRegGeralNaturezas><RgFisicasJuridicas><RgFisicaJuridica><IdEmpr>1</IdEmpr><IdRg>1</IdRg><NroCPF>164414498</NroCPF><DigCPF>3</DigCPF><NroRg>24400261</NroRg><DigRg>3</DigRg><DtEmissao>2012-01-15T00:00:00</DtEmissao><OrgaoExpRg>SSP/SP</OrgaoExpRg><InscrMunicipal>2020202</InscrMunicipal><CGC>164414498</CGC><FilialCGC>1</FilialCGC><DigCGC>73</DigCGC><InscEstadual>108.383.949.112</InscEstadual><NroBanco>0</NroBanco><NroAgencia>0</NroAgencia><DigAgencia>0</DigAgencia><NroConta>0</NroConta><DigConta>0</DigConta><IdTipoCta>0</IdTipoCta><CEI>1212121</CEI></RgFisicaJuridica></RgFisicasJuridicas></RegistroGeralProcessMapping>';

  SELECT @RegistrosGerais = E.C.query('.') FROM @AtualizaRegistroGeral.nodes('/RegistroGeralProcessMapping/RgRegGerais') as E(C);
  SELECT @Enderecos = E.C.query('.') FROM @AtualizaRegistroGeral.nodes('/RegistroGeralProcessMapping/RgEnderecos') as E(C);
  SELECT @Telefones = E.C.query('.') FROM @AtualizaRegistroGeral.nodes('/RegistroGeralProcessMapping/RgTelefones') as E(C);
  SELECT @Naturezas = E.C.query('.') FROM @AtualizaRegistroGeral.nodes('/RegistroGeralProcessMapping/RgRegGeralNaturezas') as E(C);
  SELECT @PessoasFisicasJuridicas = E.C.query('.') FROM @AtualizaRegistroGeral.nodes('/RegistroGeralProcessMapping/RgFisicasJuridicas') as E(C);

  SET @IdEmpr = @RegistrosGerais.value('(/RgRegGerais/RgRegGeral/IdEmpr)[1]', 'int');	
  
  SELECT E.C.value('IdEmpr[1]', 'int') as cod_empr,
	     E.C.value('IdRg[1]', 'int') as razao_social,
		 E.C.value('SeqTel[1]', 'int') as tipo_rg,
		 E.C.value('IdTipoFone[1]', 'int') as cod_status,
		 E.C.value('DDDFone[1]', 'char(4)') as data_hora,
		 E.C.value('NroFone[1]', 'varchar(12)') as usuario,
		 E.C.value('Contato[1]', 'varchar(30)') as nome_fantasia,
		 E.C.value('EMail[1]', 'varchar(60)') as optante_simples
	FROM @Telefones.nodes('/RgTelefones/RgTelefone') AS E(C)

	--<Telefone>
	--	<cod_empr>1</cod_empr>
	--	<cod_rg>1</cod_rg>
	--	<seq_tel>3</seq_tel>
	--	<cod_tipo_fone>5</cod_tipo_fone>
	--	<ddd_fone>11</ddd_fone>
	--	<numero_fone>3394-1207</numero_fone>
	--	<contato>NENEM</contato>
	--	<e_mail>nenem@nenem.com.br</e_mail>
	--</Telefone>

 -- SET @ModifyType = 'I';

	--IF @ModifyType = 'I'
 --   BEGIN
 --     INSERT INTO rg_reg_geral(cod_empr, 
	--                           razao_social, 
	--						   tipo_rg, 
	--						   cod_status, 
	--						   data_hora, 
	--						   usuario, 
	--						   nome_fantasia, 
	--						   optante_simples) 
 --                       SELECT E.C.value('cod_empr[1]', 'int') as cod_empr,
	--                           E.C.value('razao_social[1]', 'varchar(100)') as razao_social,
	--						   E.C.value('tipo_rg[1]', 'char(1)') as tipo_rg,
	--						   E.C.value('cod_status[1]', 'int') as cod_status,
	--						   E.C.value('data_hora[1]', 'datetime') as data_hora,
	--						   E.C.value('usuario[1]', 'varchar(15)') as usuario,
	--						   E.C.value('nome_fantasia[1]', 'varchar(20)') as nome_fantasia,
	--						   E.C.value('optante_simples[1]', 'char(1)') as optante_simples
	--                      FROM @RegistrosGerais.nodes('/RegistroGeral') AS E(C)

 --     SELECT SCOPE_IDENTITY() AS IdRg; /* Retorna o Identity da Tabela gerado */

	--  --SELECT * FROM rg_reg_geral WHERE cod_rg = 5054
 --   END

	--IF @ModifyType = 'U'
	--  BEGIN
	--    UPDATE rg_reg_geral SET razao_social = RG.razao_social, 
	--	                        tipo_rg = RG.tipo_rg, 
	--							cod_status = RG.cod_status, 
	--							data_hora = RG.data_hora, 
	--							usuario = RG.usuario, 
	--							nome_fantasia = RG.nome_fantasia, 
	--							optante_simples = RG.optante_simples 
	--					   FROM rg_reg_geral 
	--		 INNER JOIN (SELECT E.C.value('cod_empr[1]', 'int') as cod_empr,
	--							E.C.value('cod_rg[1]', 'int') as cod_rg,
	--							E.C.value('razao_social[1]', 'varchar(100)') as razao_social,
	--							E.C.value('tipo_rg[1]', 'char(1)') as tipo_rg,
	--							E.C.value('cod_status[1]', 'int') as cod_status,
	--							E.C.value('data_hora[1]', 'datetime') as data_hora,
	--							E.C.value('usuario[1]', 'varchar(15)') as usuario,
	--							E.C.value('nome_fantasia[1]', 'varchar(20)') as nome_fantasia,
	--							E.C.value('optante_simples[1]', 'char(1)') as optante_simples
	--					   FROM @RegistrosGerais.nodes('/RgRegGeral') AS E(C)) AS RG 
	--						 ON rg_reg_geral.cod_empr = RG.cod_empr 
	--						AND rg_reg_geral.cod_rg = RG.cod_rg
	--  END

	--IF @ModifyType = 'D'
	--  BEGIN
	--	SET @IdEmpr = @RegistrosGerais.value('(/RgRegGeral/cod_empr)[1]', 'int');
	--	SET @IdRg = @RegistrosGerais.value('(/RgRegGeral/cod_rg)[1]', 'int');

	--    DELETE FROM rg_reg_geral WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg
	--  END