using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CROSS.DATABASE
{
    public interface IManagerDataBase
    {
        Task<Tuple<bool, string>> Check(string name);

        Task<bool> Execute(string name, string query);

        Task<bool> ExecuteStoredProcedure(string name, string query, List<SqlParameter> parameter);

        Task<DataTable> Select(string name, string query);

        Task<DataTable> SelectStoredProcedure(string name, string query, List<SqlParameter> parameter);
    }
}
