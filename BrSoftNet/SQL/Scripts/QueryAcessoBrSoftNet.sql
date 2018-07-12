
		declare @UserName char(20) = 'NOF',
				@Password char(10) = 'NOF',
				@Usuario char(20),
				@Senha char(10),								
				@CodigoEmpresa int;
			    
		set @Usuario = (select usuario from ge_usuario where usuario = @UserName and senha = @Password and ativo = 'S');
		set @Senha = (select senha from ge_usuario where usuario = @UserName and senha = @Password and ativo = 'S');		
		set @CodigoEmpresa = (select top 1 cod_empr from ge_usuario_processo where usuario = @Usuario);
		
		 select usuario as Usuario,       				
				nome as Nome,
				cod_empr as CodigoEmpresa,
				cod_rg as CodigoRegistroGeral,
				status_dba as StatusDba,
				ramal as Ramal
		   from ge_usuario
		  where usuario = @Usuario
			and senha = @Senha;			   
					
		select distinct 
			   upr.cod_empr as CodigoEmpresa,			       
			   emp.descr_empr_red as NomeFantasia 
		  from ge_usuario_processo as upr
	inner join ge_empresa as emp
			on upr.cod_empr = emp.cod_empr
	inner join rg_reg_geral as rgl                
			on emp.cod_rg = rgl.cod_rg			   
		   and rgl.cod_status = 1
		   and upr.usuario = @Usuario
		 order by upr.cod_empr

		 select distinct 			       
			    emp.descr_empr as RazaoSocial				   
		   from ge_empresa as emp			    
		  where emp.cod_empr = @CodigoEmpresa
		  
		/*Aplicações*/		  
		  
		select distinct
		       pro.cod_aplic as CodigoAplicacao,
			   apl.descr_aplic as DescricaoAplicacao			   
		  from ge_usuario_processo as upr
	inner join ge_processo as pro
	        on upr.cod_proc = pro.cod_proc
	inner join ge_tipo_processo as tpr
	        on pro.cod_tipo_proc = tpr.cod_tipo_proc
    inner join ge_aplicacao as apl
	        on apl.cod_aplic = pro.cod_aplic
     	 where upr.usuario = @Usuario	
		   and upr.cod_empr = @CodigoEmpresa	     
	  order by pro.cod_aplic
		       --tpr.sequ_tipo_proc,
			   --pro.sequ_proc		   

		/*Tipo Processo*/

		select distinct
		       pro.cod_tipo_proc as CodigoTipoProcesso,
			   tpr.descr_tipo_proc as DescricaoTipoProcesso			   	 
		  from ge_usuario_processo as upr
	inner join ge_processo as pro
	        on upr.cod_proc = pro.cod_proc
	inner join ge_tipo_processo as tpr
	        on pro.cod_tipo_proc = tpr.cod_tipo_proc
    inner join ge_aplicacao as apl
	        on apl.cod_aplic = pro.cod_aplic
     	 where apl.cod_aplic = 1
	  order by pro.cod_tipo_proc
		       --tpr.sequ_tipo_proc,
			   --pro.sequ_proc

		/*Processo*/

		select distinct
		       upr.cod_proc as CodigoProcesso,
			   pro.descr_proc as DescricaoProcesso			   
		  from ge_usuario_processo as upr
	inner join ge_processo as pro
	        on upr.cod_proc = pro.cod_proc
	inner join ge_tipo_processo as tpr
	        on pro.cod_tipo_proc = tpr.cod_tipo_proc
    inner join ge_aplicacao as apl
	        on apl.cod_aplic = pro.cod_aplic
     	 where tpr.cod_tipo_proc = 1
		   and pro.cod_aplic = 1
	  order by upr.cod_proc
		       --tpr.sequ_tipo_proc,
			   --pro.sequ_proc
		