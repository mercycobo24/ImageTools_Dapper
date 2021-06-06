using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ISqlDapperDataAccess
    {
        Task<int> ExecuteCommand<T>(string storedProcedure, T parameters, CommandType cType = CommandType.StoredProcedure);
        Task<T> GetEntity<T, U>(string command, U parameters, CommandType cType = CommandType.StoredProcedure);
        Task<List<T>> LoadData<T, U>(string command, U parameters, CommandType cType = CommandType.StoredProcedure);
    }
}