/* TaskRgTelefoneModifyDataProcesses - Rg_Telefone */

DECLARE
    @IdEmpr int = 0,
	@IdRg int = 0,
	@SeqTel int = 0,
	@IdTipoFone int = 0,
    @DDDFone varchar(4) = '',
    @NroFone varchar(12) = '',
	@Contato varchar(30) = '',
	@EMail varchar(50) = '',
    @ModifyType char(1) = 'N'

  SET @IdEmpr = 0;
  SET @IdRg = 0;
  SET @SeqTel = 0;
  SET @IdTipoFone = 0;
  SET @DDDFone = '';
  SET @NroFone = '';
  SET @Contato = '';
  SET @EMail = '';
  SET @ModifyType = 'N';

	IF @ModifyType = 'I'
    BEGIN
      INSERT INTO rg_telefone(cod_empr,
	                          cod_rg, 
                              seq_tel, 
		  				      cod_tipo_fone, 
						      ddd_fone, 
						      numero_fone, 
						      contato, 
						      e_mail) 
                      VALUES (@IdEmpr, 
					          @IdRg, 
						      @SeqTel, 
						      @IdTipoFone, 
						      @DDDFone, 
						      @NroFone, 
						      @Contato,
							  @EMail);
    END

	IF @ModifyType = 'U'
	  BEGIN
	    IF EXISTS (SELECT TL.* FROM rg_telefone AS TL WITH(NOLOCK) WHERE TL.cod_empr = @IdEmpr AND TL.cod_rg = @IdRg)
		  BEGIN
		    DELETE FROM rg_telefone WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg AND seq_tel = @SeqTel
	      END
		  
		INSERT INTO rg_telefone(cod_empr,
								cod_rg, 
								seq_tel, 
		  						cod_tipo_fone, 
								ddd_fone, 
								numero_fone, 
								contato, 
								e_mail) 
						VALUES (@IdEmpr, 
								@IdRg, 
								@SeqTel, 
								@IdTipoFone, 
								@DDDFone, 
								@NroFone, 
								@Contato,
								@EMail);
	  END

	IF @ModifyType = 'D'
	  BEGIN
	    DELETE FROM rg_telefone WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg AND seq_tel = @SeqTel
	  END