using Dapper;
using ImageTool.Infrastructure;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public  class SqlDapperDataAccess :ISqlDapperDataAccess
    {
       private readonly  string _connectionString;

        public SqlDapperDataAccess(IOptions<ConnectionConfig> configuration)
        {
            _connectionString = configuration.Value.DBConnection;
        }
     


        public  async Task<List<T>> LoadData<T, U>(string command, U parameters, CommandType cType = CommandType.StoredProcedure)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            var rows = await connection.QueryAsync<T>(command, parameters, commandType: cType);

            return rows.ToList();
        }

        public  async Task<T> GetEntity<T, U>(string command, U parameters, CommandType cType = CommandType.StoredProcedure)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var entiry = await connection.QueryFirstOrDefaultAsync<T>(command, parameters, commandType: cType);

                return entiry;
            }
        }

      
        //public  async Task ExecuteCommand<T>(string storedProcedure, T parameters,  CommandType cType = CommandType.StoredProcedure)
        //{
        //  //  string connectionString = GetConnectionString(_connString);

        //    using (IDbConnection connection = new SqlConnection(_connectionString))
        //    {
        //        await connection.ExecuteAsync(storedProcedure, parameters,
        //            commandType: CommandType.StoredProcedure);
        //    }
            
        //}

        public async Task<int>  ExecuteCommand<T>(string storedProcedure, T parameters, CommandType cType)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
              return   await connection.ExecuteAsync(storedProcedure, parameters, commandType: cType);
            }
        }
        private  IDbConnection _connection;
        private  IDbTransaction _transaction;

        public  void StartTransaction()
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();

            _transaction = _connection.BeginTransaction();
        }

        public  List<T> LoadDataInTransaction<T, U>(string storedProcedure, U parameters)
        {
            List<T> rows = _connection.Query<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction).ToList();

            return rows;
        }

        public  void SaveDataInTransaction<T>(string storedProcedure, T parameters)
        {
            _connection.Execute(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure, transaction: _transaction);
        }

        public  void CommitTransaction()
        {
            _transaction?.Commit();
            _connection?.Close();
        }

        public  void RollbackTransaction()
        {
            _transaction?.Rollback();
            _connection?.Close();
        }

        public  void Dispose()
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
