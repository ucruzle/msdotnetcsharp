CREATE PROCEDURE [dbo].[Ge_RetornaLiberacaoUsuario]
AS
BEGIN
        /* Seleção de Empresas */
		select distinct 
			   upr.cod_empr as CodigoEmpresa, 
			   emp.descr_empr_red as NomeFantasia 
		  from ge_usuario_processo as upr 
	inner join ge_empresa as emp 
			on upr.cod_empr = emp.cod_empr 
	inner join rg_reg_geral as rgl 
			on emp.cod_rg = rgl.cod_rg 
		   and rgl.cod_status = 1 
		 order by upr.cod_empr
       
	   /* Seleções de Aplicações / Módulos */
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
   inner join (select distinct 
					  upr.cod_empr as CodigoEmpresa 
				 from ge_usuario_processo as upr 
		   inner join ge_empresa as emp 
	    		   on upr.cod_empr = emp.cod_empr 
		   inner join rg_reg_geral as rgl 
				   on emp.cod_rg = rgl.cod_rg 
				  and rgl.cod_status = 1) as emp
		   on upr.cod_empr = emp.CodigoEmpresa
	 order by pro.cod_aplic;
     
	   /* Seleções de Grupos */
	   select cod_grupo as CodigoGrupo
			  descr_grupo as DescricaoGrupo
		 from ge_grupo;
         
	   /* Seleções de Tipos de Processos */                                                                                                                                                                                            
	   select distinct 
			  tpr.cod_tipo_proc as cod_tipo_proc,
			  tpr.descr_tipo_proc as descr_tipo_proc,
			  tpr.sequ_tipo_proc as sequ_tipo_proc
		 from (select distinct 
					  pro.cod_aplic as CodigoAplicacao, 
					  pro.cod_tipo_proc as cod_tipo_proc 
				 from ge_usuario_processo as upr 
		   inner join ge_processo as pro 
				   on upr.cod_proc = pro.cod_proc 
		   inner join ge_tipo_processo as tpr 
				   on pro.cod_tipo_proc = tpr.cod_tipo_proc 
		   inner join ge_aplicacao as apl
				   on apl.cod_aplic = pro.cod_aplic 
		   inner join (select distinct 
							  upr.cod_empr as CodigoEmpresa										   
						 from ge_usuario_processo as upr 
				   inner join ge_empresa as emp 
	    				   on upr.cod_empr = emp.cod_empr 
				   inner join rg_reg_geral as rgl 
						   on emp.cod_rg = rgl.cod_rg 
						  and rgl.cod_status = 1) as emp
				   on upr.cod_empr = emp.CodigoEmpresa) as pro 
   inner join ge_tipo_processo as tpr 
		   on pro.cod_tipo_proc = tpr.cod_tipo_proc                         
	 order by tpr.cod_tipo_proc
END