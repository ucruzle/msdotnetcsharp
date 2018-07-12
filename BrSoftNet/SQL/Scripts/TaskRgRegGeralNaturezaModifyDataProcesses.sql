/* TaskRgRegGeralNaturezaModifyDataProcesses - Rg_Reg_Geral_Natureza */

DECLARE
    @IdEmpr int = 0,
	@IdRg int = 0,
	@IdNatureza int = 0,
	@IdStatusNatRg int = 0,
    @DataHora datetime = '01/01/0001 00:00:00',
    @Usuario varchar(15) = '',
    @ModifyType char(1) = 'N'

  SET @IdEmpr = 0;
  SET @IdRg = 0;
  SET @IdNatureza = 0;
  SET @IdStatusNatRg = 0;
  SET @DataHora = '01/01/0001 00:00:00';
  SET @Usuario = '';
  SET @ModifyType = 'N';

	IF @ModifyType = 'I'
    BEGIN
      INSERT INTO rg_reg_geral_natureza(cod_empr, 
                                        cod_rg, 
		  								cod_natureza, 
										cod_status_nat_rg, 
										data_hora, 
										usuario) 
								VALUES (@IdEmpr, 
										@IdRg, 
										@IdNatureza, 
										@IdStatusNatRg,
										@DataHora, 
										@Usuario);
    END

	IF @ModifyType = 'U'
	  BEGIN
	    IF EXISTS (SELECT NT.* FROM rg_reg_geral_natureza AS NT WITH(NOLOCK) WHERE NT.cod_empr = @IdEmpr AND NT.cod_rg = @IdRg)
		  BEGIN
	        DELETE FROM rg_reg_geral_natureza WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg AND cod_natureza = @IdNatureza
	      END

	    INSERT INTO rg_reg_geral_natureza(cod_empr, 
										  cod_rg, 
		  								  cod_natureza, 
										  cod_status_nat_rg, 
										  data_hora, 
										  usuario) 
								  VALUES (@IdEmpr, 
										  @IdRg, 
										  @IdNatureza, 
										  @IdStatusNatRg,
										  @DataHora, 
										  @Usuario);
	  END

	IF @ModifyType = 'D'
	  BEGIN
	    DELETE FROM rg_reg_geral_natureza WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg AND cod_natureza = @IdNatureza
	  END