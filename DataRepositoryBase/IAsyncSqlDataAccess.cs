using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepositoryBase;

public interface IAsyncSqlDataAccess
{
    Task DeleteAsync<T>(string storedProcedure,
                                    int Id,
                                    string connectionId = "Default");

    Task DeleteAsync<T, U>(string storedProcedure,
                                    U parameters,
                                    string connectionId = "Default");

    Task<IEnumerable<T>> GetAsyncUsingSqlString<T, U>(string SqlString,
                                    U parameters,
                                    string connectionId = "Default");

    Task<IEnumerable<T>> GetAsyncUsingStoredProcedure<T, U>(string storedProcedure,
                                    U parameters,
                                    string conectionId = "Default");

    Task<IEnumerable<T>> InsertAsync<T>(string storedProcedure,
                                    object rowModel,
                                    string connectionId = "Default");

    Task<IEnumerable<T>> UpdateAsync<T>(string storedProcedure,
                                    Dictionary<string, object> parameters,
                                    object rowModel,
                                    string connectionId = "Default");
}
