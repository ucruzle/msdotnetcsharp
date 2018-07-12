/* TaskFindDataRgEndereco */
DECLARE
  @IdEmpr INT = 0,
  @IdRg INT = 0;

  SET @IdEmpr = 0;
  SET @IdRg = 0;

  SELECT ED.cod_empr,
	     ED.cod_rg, 
         ED.endereco, 
		 ED.nro_endereco, 
		 ED.bairro,
		 ED.complemento,
		 ED.cep, 
		 ED.cod_municipio, 
		 ED.cx_postal,
		 ED.home_page,
		 ED.e_mail
    FROM rg_endereco AS ED
   WHERE ED.cod_empr = @IdEmpr
     AND ED.cod_rg = @IdRg