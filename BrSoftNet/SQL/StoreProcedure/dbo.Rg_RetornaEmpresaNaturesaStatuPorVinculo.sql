CREATE PROCEDURE [dbo].[Rg_RetornaEmpresaNaturesaStatuPorVinculo]
AS
BEGIN
	/* Select da tabela Ge_Empresa TABELA[0] */
    SELECT emp.cod_empr AS cod_empr,  
		   emp.descr_empr AS descr_empr,
		   emp.descr_empr_red AS descr_empr_red,
		   emp.cod_empr_consol AS cod_empr_consol,
		   emp.ativa AS ativa, 
		   emp.cod_rg AS cod_rg,
		   emp.host AS host, 
		   emp.port AS port,
		   emp.username AS username,
		   emp.senha AS senha,
		   emp.e_mail AS e_mail, 
		   emp.endereco_banco AS endereco_banco,
		   emp.versao AS versao
	  FROM ge_empresa AS emp
		
	/* Select da tabela Rg_Naturesa TABELA[1] */	
	SELECT funcionario.cod_natureza AS cod_nat_func,
		   funcionario.descr_natureza AS descr_nat_func
	  FROM rg_natureza AS funcionario
	  
	/* Select da tabela Rg_Naturesa TABELA[2] */  
	SELECT lider.cod_natureza AS cod_nat_func_lider,
		   lider.descr_natureza AS descr_nat_func_lider
	  FROM rg_natureza AS lider	 
	  
	/* Select da tabela Rg_Naturesa TABELA[3] */  
	SELECT cliente.cod_natureza AS cod_nat_cli,
		   cliente.descr_natureza AS descr_nat_cli	
   	  FROM rg_natureza AS cliente

	/* Select da tabela Rg_Naturesa TABELA[4] */
	SELECT fornecedor.cod_natureza AS cod_nat_fornec,
		   fornecedor.descr_natureza AS descr_nat_fornec
	  FROM rg_natureza AS fornecedor
	
	/* Select da tabela Rg_Naturesa TABELA[5] */	
	SELECT banco.cod_natureza AS cod_nat_banco,
		   banco.descr_natureza AS descr_nat_banco
	  FROM rg_natureza AS banco
	  
	/* Select da tabela Rg_Status TABELA[6] */  
	SELECT ativo.cod_status AS cod_status_ativo,
		   ativo.descr_status AS descr_status_ativo
	  FROM rg_status AS ativo 
	
	/* Select da tabela Rg_Status TABELA[7] */  
	SELECT inativo.cod_status AS cod_status_inativo,
		   inativo.descr_status AS descr_status_inativo
	  FROM rg_status AS inativo
	  
	/* Select da tabela Rg_Naturesa TABELA[8] */ 
	SELECT tomadora.cod_natureza AS cod_nat_tomadora,
		   tomadora.descr_natureza AS descr_nat_tomadora 
	  FROM rg_natureza AS tomadora 
	
	/* Select da tabela Rg_Naturesa TABELA[9] */   
	SELECT responsavel.cod_natureza AS cod_nat_resp,
		   responsavel.descr_natureza AS descr_nat_resp
	  FROM rg_natureza AS responsavel
	  
END		
		