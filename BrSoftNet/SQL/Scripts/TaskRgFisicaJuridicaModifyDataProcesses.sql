/* TaskRgFisicaJuridicaModifyDataProcesses - rg_fisica_juridica */

DECLARE
    @IdEmpr int = 0,
	@IdRg int = 0,
	@CPF int = 0,
	@DigitoCPF int = 0,
	@RG int = 0,
	@DigitoRG int = 0,
	@DataEmissaoRg datetime = '01/01/0001 00:00:00',
    @OrgaoExpRg varchar(10) = '',
	@InscMunicipal varchar(20) = '',
	@CGC int = 0,
	@FilialCGC int = 0,
	@DigitoCGC int = 0,
	@InscEstadual varchar(20) = '',
	@NroBanco int = 0,
	@NroAgencia int = 0,
	@DigitoAgencia int = 0,
	@NroConta int = 0,
    @DigitoConta int = 0,
	@IdTipoCta int = 0,
	@Cei varchar(20) = '',
	@ModifyType char(1) = 'N'

  SET @IdEmpr = 0;
  SET @IdRg = 0;
  SET @CPF = 0;
  SET @DigitoCPF = 0;
  SET @RG = 0;
  SET @DigitoRG = 0;
  SET @DataEmissaoRg = '01/01/0001 00:00:00';
  SET @OrgaoExpRg = '';
  SET @InscMunicipal = '';
  SET @CGC = 0;
  SET @FilialCGC = 0;
  SET @DigitoCGC = 0;
  SET @InscEstadual = '';
  SET @NroBanco = 0;
  SET @NroAgencia = 0;
  SET @DigitoAgencia = 0;
  SET @NroConta = 0;
  SET @DigitoConta = 0;
  SET @IdTipoCta = 0;
  SET @Cei = '';
  SET @ModifyType = 'N';

	IF @ModifyType = 'I'
    BEGIN
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
							 VALUES (@IdEmpr,
								     @IdRg,
								     @CPF,
								     @DigitoCPF,
								     @RG,
									 @DigitoRG,
									 @DataEmissaoRg,
									 @OrgaoExpRg,
									 @InscMunicipal,
									 @CGC,
									 @FilialCGC,
									 @DigitoCGC,
									 @InscEstadual,
									 @NroBanco,
									 @NroAgencia,
									 @DigitoAgencia,
									 @NroConta,
									 @DigitoConta,
									 @IdTipoCta,
									 @Cei);
    END

	IF @ModifyType = 'U'
	  BEGIN
	    UPDATE rg_fisica_juridica SET num_cpf = @CPF, 
								      dig_cpf = @DigitoCPF, 
									  num_rg = @RG, 
									  dig_rg = @DigitoRG, 
									  dt_emissao_rg = @DataEmissaoRg,
									  orgao_exp_rg = @OrgaoExpRg,
									  insc_municipal = @InscMunicipal,
									  cgc = @CGC,
									  filial_cgc = @FilialCGC,
									  dig_cgc = @DigitoCGC,
									  insc_estadual = @InscEstadual,
									  nro_banco = @NroBanco,
									  nro_agencia = @NroAgencia,
									  dig_agencia = @DigitoAgencia,
									  nro_conta = @NroConta,
									  dig_conta = @DigitoConta,
									  cod_tipo_cta = @IdTipoCta,
									  cei = @Cei
								WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg
	  END

	IF @ModifyType = 'D'
	  BEGIN
	    DELETE FROM rg_fisica_juridica WHERE cod_empr = @IdEmpr AND cod_rg = @IdRg
	  END