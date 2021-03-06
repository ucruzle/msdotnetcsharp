CREATE PROCEDURE [dbo].[Ge_RetornaEmpresaAplicacao]
(
  @StrFilter VARCHAR(MAX) = '',
  @IsFilter bit = 0
)
AS
BEGIN
 DECLARE
  @StrQuery VARCHAR(MAX),
  @StrExc VARCHAR(MAX);

		  SET @StrQuery =
			  'emp.cod_empr as cod_empr,
			   emp.descr_empr as descr_empr,
			   apl.cod_aplic as cod_aplic,
			   apl.descr_aplic as descr_aplic
		  from ge_empresa_aplicacao as lnk
	inner join ge_aplicacao as apl
			on lnk.cod_aplic = apl.cod_aplic
	inner join ge_empresa as emp
			on lnk.cod_empr = emp.cod_empr'

 IF (@IsFilter <> 0) 
  BEGIN 
   SET @StrExc = 'SELECT DISTINCT ' + @StrQuery + @StrFilter
  END
 ELSE
  BEGIN 
   SET @StrExc = 'SELECT DISTINCT TOP 100 ' + @StrQuery
  END

 --PRINT (@StrExc)
 EXEC (@StrExc)
END