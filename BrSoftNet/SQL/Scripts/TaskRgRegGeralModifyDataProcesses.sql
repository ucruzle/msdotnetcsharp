/* TaskRgRegGeralModifyDataProcesses - rg_reg_geral */

DECLARE
    @IdEmpr int = 0,
	@IdRg int = 0,
    @RazaoSocial varchar(100) = '',
    @TipoRg varchar(100) = '',
    @IdStatus int = 0,
    @DataHora datetime = '01/01/0001 00:00:00',
    @Usuario varchar(15) = '',
	@NomeFantasia varchar(20) = '',
    @ModifyType char(1) = 'N'

  SET @IdEmpr = 0;
  SET @IdRg = 0;
  SET @RazaoSocial = '';
  SET @TipoRg = '';
  SET @IdStatus = 0;
  SET @DataHora = '01/01/0001 00:00:00';
  SET @Usuario = '';
  SET @NomeFantasia = '';
  SET @ModifyType = 'N';

	IF @ModifyType = 'I'
    BEGIN
      INSERT INTO rg_reg_geral(cod_empr, 
                               razao_social, 
		  				       tipo_rg, 
						       cod_status, 
						       data_hora, 
						       usuario, 
						       nome_fantasia) 
                       VALUES (@IdEmpr, 
					           @RazaoSocial, 
						       @TipoRg, 
						       @IdStatus, 
						       @DataHora, 
						       @Usuario, 
						       @NomeFantasia);
      SELECT SCOPE_IDENTITY() AS IdRg; /* Retorna o Identity da Tabela gerado */
    END

	IF @ModifyType = 'U'
	  BEGIN
	    UPDATE rg_reg_geral SET razao_social = @RazaoSocial, 
							    tipo_rg = @TipoRg, 
							    cod_status = @IdStatus, 
							    data_hora = @DataHora, 
							    usuario = @Usuario,
								nome_fantasia = @NomeFantasia 
					      WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg
	  END

	IF @ModifyType = 'D'
	  BEGIN
	    DELETE FROM rg_reg_geral WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg
	  END