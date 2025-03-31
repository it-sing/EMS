using System;
using System.Data.SqlClient;

namespace EmployeeManagementSystem.Pattern
{
    public sealed class DBConnectionSingleton
    {
        private static readonly Lazy<DBConnectionSingleton> _instance =
            new Lazy<DBConnectionSingleton>(() => new DBConnectionSingleton());

        public static DBConnectionSingleton Instance => _instance.Value;

        private static readonly string _connectionString =
            "Server=DESKTOP-89B3HBK\\SQLEXPRESS;Database=EMSDB;User Id=sa;Password=admin;";

        private DBConnectionSingleton() { }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
