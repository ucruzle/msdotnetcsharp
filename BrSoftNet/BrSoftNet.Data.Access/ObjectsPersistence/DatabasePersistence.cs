using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Data.Access.Logic.Components.ObjectsPersistence
{
    public class DatabasePersistence : ObjectPersistenceFactory<DatabasePersistence>
    {
        public Object ExecuteCommand(String _CommandText, CommandType _CommandType, List<DbParameter> _ParameterList, ExecuteType _ExecuteType)
        {
            // Cria comando com os dados passado por parâmetro
            DbCommand _Command = CreateCommand(_CommandText, _CommandType, _ParameterList);

            // Cria objeto de retorno
            Object _ReturnObject = null;

            try
            {
                // Abre a Conexão com o banco de dados
                _Command.Connection.Open();

                switch (_ExecuteType)
                {
                    case ExecuteType.ExecuteNonQuery:
                        // Retorna o número de linhas afetadas
                        _ReturnObject = _Command.ExecuteNonQuery();
                        break;
                    case ExecuteType.ExecuteReader:
                        // Retorna um DbDataReader
                        _ReturnObject = _Command.ExecuteReader(CommandBehavior.CloseConnection);
                        break;
                    case ExecuteType.ExecuteScalar:
                        // Retorna um objeto
                        _ReturnObject = _Command.ExecuteScalar();
                        break;
                    case ExecuteType.ExecuteDataTable:
                        // Cria uma tabela
                        DataTable table = new DataTable();
                        // Executa o comando e salva os dados na tabela
                        DbDataReader reader = _Command.ExecuteReader();
                        table.Load(reader);
                        // Fecha o Reader
                        reader.Close();
                        // Retorna a tabela
                        _ReturnObject = table;
                        break;
                    case ExecuteType.ExecuteDataSet:
                        // Cria um novo Objeto DataSet
                        DataSet _DataSet = new DataSet();
                        // Cria um novo factories de acordo com o nome do provedor
                        DbProviderFactory factory = DbProviderFactories.GetFactory(ProviderType);
                        // Cria um novo object DbDataAdapter a partir da DbProviderFactory
                        DbDataAdapter _Adapter = factory.CreateDataAdapter();
                        _Adapter.SelectCommand = _Command;
                        _Adapter.Fill(_DataSet);
                        // Retorna o objeto DataSet
                        _ReturnObject = _DataSet;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_ExecuteType != ExecuteType.ExecuteReader)
                {
                    // Sempre fecha a conexão com o BD
                    _Command.Connection.Close();
                }
            }

            return _ReturnObject;
        }

        public DbCommand CreateCommand(String _CommandText, CommandType CommandType, List<DbParameter> _ParameterList)
        {
            // Cria um objeto específico de conexão de acordo com o nome do provedor
            DbConnection _Connection = CreateConnection();

            // Cria um objeto command específico de acordo com o nome do provedor
            DbCommand _Command = _Connection.CreateCommand();

            // Atribui o comando Text
            _Command.CommandText = _CommandText;
            // Atribui o tipo de comando
            _Command.CommandType = CommandType;

            // Se existir algum parâmetro ele adiciona
            // ao comando
            if (_ParameterList != null)
            {
                foreach (DbParameter param in _ParameterList)
                {
                    // Adicionando o parâmetro
                    _Command.Parameters.Add(param);
                }
            }

            // Retorna o comando criado
            return _Command;
        }

        public DbParameter CreateParameter(String _ParameterName, DbType _ParameterType, Object _ParameterValue)
        {
            // Cria um novo factories de acordo com o nome do provedor
            DbProviderFactory factory = DbProviderFactories.GetFactory(ProviderType);

            // Cria o Parâmetro e add seu valores
            DbParameter param = factory.CreateParameter();
            param.ParameterName = _ParameterName;
            param.DbType = _ParameterType;
            param.Value = _ParameterValue;

            // Retorna o Parâmetro criado
            return param;
        }

        public DbConnection CreateConnection()
        {
            // Cria um novo factories de acordo com o nome do provedor
            DbProviderFactory _Factory = DbProviderFactories.GetFactory(ProviderType);

            // Cria um objeto específico de conexão de acordo com o nome do provedor
            DbConnection _Connection = _Factory.CreateConnection();

            // Atribui a String de Conexão
            _Connection.ConnectionString = ConnectionString;

            return _Connection;
        }
    }
}
