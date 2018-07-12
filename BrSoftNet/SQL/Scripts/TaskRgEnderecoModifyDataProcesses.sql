/* TaskRgEnderecoModifyDataProcesses - rg_endereco */

DECLARE
    @IdEmpr int = 0,
	@IdRg int = 0,
    @Endereco varchar(40) = '',
    @NroEndereco varchar(10) = '',
	@Bairro varchar(30) = '',
	@Complemento varchar(40) = '',
    @CEP int = 0,
	@IdMunicipio int = 0,
	@CxPostal int = 0,
	@HomePage varchar(60) = '',
	@EMail varchar(50) = '',
    @ModifyType char(1) = 'N'

  SET @IdEmpr = 0;
  SET @IdRg = 0;
  SET @Endereco = '';
  SET @NroEndereco = '';
  SET @Bairro = '';
  SET @Complemento = '';
  SET @CEP = 0;
  SET @IdMunicipio = 0;
  SET @CxPostal = 0;
  SET @HomePage = '';
  SET @EMail = '';
  SET @ModifyType = 'N';

	IF @ModifyType = 'I'
    BEGIN
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
                      VALUES (@IdEmpr, 
					          @IdRg,
					          @Endereco, 
						      @NroEndereco,
							  @Bairro, 
						      @Complemento, 
						      @CEP, 
						      @IdMunicipio, 
						      @CxPostal,
							  @HomePage,
							  @EMail);
    END

	IF @ModifyType = 'U'
	  BEGIN
	    UPDATE rg_endereco SET endereco = @Endereco, 
							    nro_endereco = @NroEndereco, 
								bairro = @Bairro,
							    complemento = @Complemento, 
								cep = @CEP,
							    cod_municipio = @IdMunicipio, 
							    cx_postal = @CxPostal,
								home_page = @HomePage,
								e_mail = @EMail 
					      WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg
	  END

	IF @ModifyType = 'D'
	  BEGIN
	    DELETE FROM rg_endereco WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg
	  END