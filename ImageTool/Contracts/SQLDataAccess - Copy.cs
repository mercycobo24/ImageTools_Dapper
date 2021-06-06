using Dapper;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal static class SqlDapperDataAccessCopy
    {
      
        //public SqlDapperDataAccess(IConfiguration configuration)
        //{

        //    _connectionString = configuration.GetConnectionString("ImagesToolDBConnection");
        //}
        //public string GetConnectionString(string name)
        //{
        //    return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        //}

        public static async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
          //  string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionStringName))
            {
               var rows = await connection.QueryAsync<T>(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);

                return rows.ToList();
            }
        }

        public static async Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
          //  string connectionString = GetConnectionString(_connString);

            using (IDbConnection connection = new SqlConnection(connectionStringName))
            {
                await connection.ExecuteAsync(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);
            }
            
        }

        private static IDbConnection _connection;
        private static IDbTransaction _transaction;

        public static void StartTransaction(string connectionStringName)
        {
         //   string connectionString = GetConnectionString(connectionStringName);

            _connection = new SqlConnection(connectionStringName);
            _connection.Open();

            _transaction = _connection.BeginTransaction();
        }

        public static List<T> LoadDataInTransaction<T, U>(string storedProcedure, U parameters)
        {
            List<T> rows = _connection.Query<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction).ToList();

            return rows;
        }

        public static void SaveDataInTransaction<T>(string storedProcedure, T parameters)
        {
            _connection.Execute(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure, transaction: _transaction);
        }

        public static void CommitTransaction()
        {
            _transaction?.Commit();
            _connection?.Close();
        }

        public static void RollbackTransaction()
        {
            _transaction?.Rollback();
            _connection?.Close();
        }

        public static void Dispose()
        {
            CommitTransaction();
        }

        // Open connect/start transaction method
        // load using the transaction
        // save using the transaction
        // Close connection/stop transaction method
        // Dispose
    }

}
