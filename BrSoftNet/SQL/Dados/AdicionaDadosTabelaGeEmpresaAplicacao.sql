
begin tran

		insert into ge_empresa_aplicacao(cod_empr, cod_aplic)
	    select 1 as cod_empr,
	           apl.cod_aplic as cod_aplic   
	      from ge_aplicacao as apl
	      
	      select * from ge_empresa_aplicacao
--commit
--rollback