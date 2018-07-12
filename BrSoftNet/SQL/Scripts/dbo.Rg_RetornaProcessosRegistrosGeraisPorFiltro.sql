CREATE PROCEDURE [dbo].[Rg_RetornaProcessosRegistrosGeraisPorFiltro]
(
  @StrFilter VARCHAR(MAX) = '',
  @IsFilter bit = 0
)
AS
BEGIN
  DECLARE
	  @StrQuery VARCHAR(MAX),
	  @StrGroupOrder VARCHAR(MAX),
	  @StrExc VARCHAR(MAX);

	  --SET @StrFilter = ' WHERE RG.cod_empr = 1 AND RG.cod_rg = 1 ';															/* Filtro por RG */
	  --SET @StrFilter = ' WHERE RG.razao_social LIKE ''%SINDICATO T.M.M.C.S.M.P.G. DE SOROCABA E REGIÃO%'' ';					/* Filtro por Nome Razão Social */
	  --SET @StrFilter = ' WHERE ED.cod_municipio = 1 ';																		/* Filtro por Minicípio */
	  --SET @StrFilter = ' WHERE FJ.num_cpf = 164414498 AND FJ.dig_cpf = 3 ';													/* Filtro por CPF */
	  --SET @StrFilter = ' WHERE FJ.num_rg = ''24400261'' AND FJ.dig_rg = '''' ';												/* Filtro por Identidade */
	  --SET @StrFilter = ' WHERE FJ.cgc = 2558157 AND FJ.filial_cgc = 1 AND FJ.dig_cgc = 62 ';									/* Filtro por CNPJ */
	  --SET @StrFilter = ' WHERE FJ.insc_estadual = ''108.383.949.112'' ';														/* Filtro por Inscrição Estadual */
	  --SET @StrFilter = ' WHERE FJ.insc_municipal = '''' ';																	/* Filtro por Inscrição Municipal */
	  --SET @StrFilter = ' WHERE RG.usuario = ''DBA'' ';																		/* Filtro por Usuário */
	  --SET @StrFilter = ' WHERE UF.sigla_estado = ''SP'' ';																	/* Filtro por Estado */
	  --SET @StrFilter = ' WHERE ED.cep = 18100000 ';																			/* Filtro por CEP */
	  --SET @StrFilter = ' WHERE TE.ddd_fone = 11 AND TE.numero_fone = ''3394-1207'' ';											/* Filtro por Telefone / Fax */
	  --SET @StrFilter = ' WHERE RG.data_hora <= ''2010-07-27 14:32:07.000'' AND RG.data_hora >= ''2010-06-13 18:20:00.000'' ';	/* Filtro por Data de Inclusão */
	  --SET @StrFilter = ' WHERE RG.cod_status = 1 ';															                /* Filtro por Status */
	  --SET @StrFilter = ' WHERE RG.cod_status IN (SELECT cod_status FROM rg_status) ';							                /* Filtro por Status - Todos */
	  --SET @StrFilter = ' WHERE RG.tipo_rg = ''J'' ';            															    /* Filtro por Tipo Pessoa RG */
	  --SET @StrFilter = ' WHERE RG.tipo_rg IN (SELECT tipo_rg FROM rg_tipo_rg) ';												/* Filtro por Tipo Pessoa RG - Todos */
	  --SET @StrFilter = ' WHERE NA.cod_natureza = 3 ';															                /* Filtro por Natureza RG */
	  --SET @StrFilter = ' WHERE NA.cod_natureza IN (SELECT cod_natureza FROM rg_natureza) ';									/* Filtro por Natureza RG - Todos */

	  SET @StrQuery = 
					 'RG.cod_empr,
					  RG.cod_rg,
					  RG.razao_social,
					  RG.tipo_rg,
					  RG.cod_status,
					  RG.data_hora,
					  RG.usuario,
					  RG.nome_fantasia,
					  RG.optante_simples
				 FROM rg_reg_geral AS RG WITH(NOLOCK)
		   INNER JOIN rg_endereco AS ED WITH(NOLOCK) 
				   ON RG.cod_empr = ED.cod_empr 
				  AND RG.cod_rg = ED.cod_rg
		   INNER JOIN rg_telefone AS TE WITH(NOLOCK)
				   ON RG.cod_empr = TE.cod_empr
				  AND RG.cod_rg = TE.cod_rg
		   INNER JOIN rg_reg_geral_natureza AS NA WITH(NOLOCK)
				   ON RG.cod_empr = NA.cod_empr
				  AND RG.cod_rg = NA.cod_rg
		   INNER JOIN rg_fisica_juridica AS FJ WITH(NOLOCK)
				   ON RG.cod_empr = FJ.cod_empr
				  AND RG.cod_rg = FJ.cod_rg
		   INNER JOIN rg_municipio AS MU WITH(NOLOCK)
				   ON ED.cod_municipio = MU.cod_municipio
		   INNER JOIN rg_estado AS UF WITH(NOLOCK)
				   ON MU.sigla_estado = UF.sigla_estado' 

	  SET @StrGroupOrder = 
		   ' GROUP BY RG.cod_empr,
					  RG.cod_rg,
					  RG.razao_social,
					  RG.tipo_rg,
					  RG.cod_status,
					  RG.data_hora,
					  RG.usuario,
					  RG.nome_fantasia,
					  RG.optante_simples
			 ORDER BY RG.cod_empr,
					  RG.cod_rg,
					  RG.data_hora DESC';

	  IF (@IsFilter <> 0) 
		BEGIN 
		  SET @StrExc = 'SELECT DISTINCT ' + @StrQuery + @StrFilter + @StrGroupOrder 
		END
	  ELSE
		BEGIN 
		  SET @StrExc = 'SELECT DISTINCT TOP 100 ' + @StrQuery + @StrGroupOrder 
		END

	  --PRINT (@StrExc)
	  EXEC (@StrExc)
END