CREATE PROCEDURE [dbo].[Ge_RetornaLiberacaoGrupoProcesso]
AS
BEGIN
        /* Seleção de Empresas */
		select distinct 
			   grp.cod_empr as CodigoEmpresa, 
			   emp.descr_empr_red as NomeFantasia 
		  from ge_grupo_processo as grp 
	inner join ge_empresa as emp 
			on grp.cod_empr = emp.cod_empr 
	inner join rg_reg_geral as rgl 
			on emp.cod_rg = rgl.cod_rg 
		   and rgl.cod_status = 1 
		 order by grp.cod_empr
       
	   /* Seleções de Aplicações / Módulos */
	   select distinct 
			  pro.cod_aplic as CodigoAplicacao, 
			  apl.descr_aplic as DescricaoAplicacao 
		 from ge_grupo_processo as grp 
   inner join ge_processo as pro 
		   on grp.cod_proc = pro.cod_proc 
   inner join ge_tipo_processo as tpr 
		   on pro.cod_tipo_proc = tpr.cod_tipo_proc 
   inner join ge_aplicacao as apl
		   on apl.cod_aplic = pro.cod_aplic 
   inner join (select distinct 
					  grp.cod_empr as CodigoEmpresa 
				 from ge_usuario_processo as grp 
		   inner join ge_empresa as emp 
	    		   on grp.cod_empr = emp.cod_empr 
		   inner join rg_reg_geral as rgl 
				   on emp.cod_rg = rgl.cod_rg 
				  and rgl.cod_status = 1) as emp
		   on grp.cod_empr = emp.CodigoEmpresa
	 order by pro.cod_aplic;
     
	   /* Seleções de Grupo */
	   select   cod_grupo,
				descr_grupo
		 from ge_grupo
         
	   /* Seleções de Tipos de Processos */                                                                                                                                                                                            
	   select distinct 
			  tpr.cod_tipo_proc as cod_tipo_proc,
			  tpr.descr_tipo_proc as descr_tipo_proc,
			  tpr.sequ_tipo_proc as sequ_tipo_proc
		 from (select distinct 
					  pro.cod_aplic as CodigoAplicacao, 
					  pro.cod_tipo_proc as cod_tipo_proc 
				 from ge_grupo_processo as grp 
		   inner join ge_processo as pro 
				   on grp.cod_proc = pro.cod_proc 
		   inner join ge_tipo_processo as tpr 
				   on pro.cod_tipo_proc = tpr.cod_tipo_proc 
		   inner join ge_aplicacao as apl
				   on apl.cod_aplic = pro.cod_aplic 
		   inner join (select distinct 
							  grp.cod_empr as CodigoEmpresa										   
						 from ge_usuario_processo as grp 
				   inner join ge_empresa as emp 
	    				   on grp.cod_empr = emp.cod_empr 
				   inner join rg_reg_geral as rgl 
						   on emp.cod_rg = rgl.cod_rg 
						  and rgl.cod_status = 1) as emp
				   on grp.cod_empr = emp.CodigoEmpresa) as pro 
   inner join ge_tipo_processo as tpr 
		   on pro.cod_tipo_proc = tpr.cod_tipo_proc                         
	 order by tpr.cod_tipo_proc
END