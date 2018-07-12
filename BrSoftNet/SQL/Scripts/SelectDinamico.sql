		select 
		       COLUMN_NAME as Columns
		  from INFORMATION_SCHEMA.COLUMNS
	     where TABLE_NAME = 'ge_processo'
	  order by ORDINAL_POSITION
		
		
		select 
			   column_name as FieldName,	
		       (case 
					when column_name = 'cod_proc'      then 'CODIGO'
					when column_name = 'descr_proc'    then 'DESCRIÇÃO'
					when column_name = 'cod_tipo_proc' then 'TIPO DE PROCESSO'
					when column_name = 'cod_aplic'     then 'CODIGO APLICAÇÃO'
					when column_name = 'ativo'         then 'ATIVO'
					when column_name = 'form'          then 'FORMULÁRIO'
					when column_name = 'sequ_proc'     then 'SEQUÊNCIA DO PROCESSO'
			    end
			   ) as FieldLabel,
			   DATA_TYPE AS DataType,
			   CHARACTER_MAXIMUM_LENGTH as FieldWidth
		  from INFORMATION_SCHEMA.COLUMNS
	     where TABLE_NAME = 'ge_processo'
	  order by ORDINAL_POSITION

	  select
column_name + ' (' + data_type + case isnull(character_maximum_length,'') when '' then '' else '(' + cast (character_maximum_length AS varchar(6)) + ')' end + case is_nullable when 'YES' then ', null)' else ', not null)' end AS Columns
from information_schema.columns
where table_name = 'ge_processo'
order by ordinal_position

		  SELECT DISTINCT 
		         t.TABLE_NAME as TableName, 
				 c.COLUMN_NAME as ColumnName,
				 c.data_type as DataType,
				 c.CHARACTER_MAXIMUM_LENGTH as FieldWidth
			FROM INFORMATION_SCHEMA.TABLES t
	  INNER JOIN INFORMATION_SCHEMA.COLUMNS c
		      ON t.TABLE_NAME = c.TABLE_NAME
		   WHERE t.TABLE_NAME IN ('ge_grupo','ge_grupo_processo','ge_parametro')

  SELECT t.TABLE_NAME, c.COLUMN_NAME
  FROM INFORMATION_SCHEMA.TABLES t
  JOIN INFORMATION_SCHEMA.COLUMNS c
  ON t.TABLE_NAME = c.TABLE_NAME
  WHERE t.TABLE_NAME IN ('ge_grupo','ge_grupo_processo','ge_parametro')

  SELECT t.TABLE_NAME, c.COLUMN_NAME
  FROM INFORMATION_SCHEMA.TABLES t
  JOIN INFORMATION_SCHEMA.COLUMNS c
  ON t.TABLE_NAME = c.TABLE_NAME
  WHERE t.TABLE_NAME IN ('ge_grupo')