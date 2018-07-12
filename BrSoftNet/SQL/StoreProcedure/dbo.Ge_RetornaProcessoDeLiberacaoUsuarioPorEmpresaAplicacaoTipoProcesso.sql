CREATE PROCEDURE [dbo].[Ge_RetornaProcessoDeLiberacaoUsuarioPorEmpresaAplicacaoTipoProcesso]
(
	@CodigoEmpresa int = 0,
	@CodigoAplicacao int = 0,
	@Usuario varchar(15) = '',
	@TipoDeModificacao char(1) = 'N'
)
AS
BEGIN
	
	IF @TipoDeModificacao = 'I'
	  BEGIN
			  select distinct 
			   	     pro.cod_proc as cod_proc, 
					 pro.descr_proc as descr_proc, 
					 pro.cod_tipo_proc as cod_tipo_proc, 
					 pro.cod_aplic as cod_aplic, 
					 pro.ativo as ativo, 
					 pro.form as form, 
					 pro.sequ_proc as sequ_proc 
				from ge_processo as pro 
		  inner join ge_tipo_processo as tpr 
				  on pro.cod_tipo_proc = tpr.cod_tipo_proc 
		  inner join ge_aplicacao as apl 
				  on apl.cod_aplic = pro.cod_aplic
		  inner join ge_empresa_aplicacao as eap
		          on eap.cod_aplic = apl.cod_aplic
		  inner join ge_empresa as emp
		          on eap.cod_empr = emp.cod_empr
		       where emp.cod_empr = @CodigoEmpresa
		         and apl.cod_aplic = @CodigoAplicacao		   
			order by pro.cod_tipo_proc
	  END
	
	IF @TipoDeModificacao = 'U'
	  BEGIN
		      select distinct 
			   	     pro.cod_proc as cod_proc, 
					 pro.descr_proc as descr_proc, 
					 pro.cod_tipo_proc as cod_tipo_proc, 
					 pro.cod_aplic as cod_aplic, 
					 pro.ativo as ativo, 
					 pro.form as form, 
					 pro.sequ_proc as sequ_proc 
				from ge_usuario_processo as upr 
		  inner join ge_processo as pro 
				  on upr.cod_proc = pro.cod_proc 
		  inner join ge_tipo_processo as tpr 
				  on pro.cod_tipo_proc = tpr.cod_tipo_proc 
		  inner join ge_aplicacao as apl 
				  on apl.cod_aplic = pro.cod_aplic 
	      inner join ge_empresa_aplicacao as eap
		          on eap.cod_aplic = apl.cod_aplic
		  inner join ge_empresa as emp
		          on eap.cod_empr = emp.cod_empr
		       where emp.cod_empr = @CodigoEmpresa
		         and upr.usuario = @Usuario
		         and apl.cod_aplic = @CodigoAplicacao          		          
			order by pro.cod_tipo_proc
	  END
END