using System;
using System.Data.SqlClient;

namespace EmployeeManagamentSystem.Pattern
{
    internal sealed class DBConnectionSingleton
    {
        private static readonly Lazy<DBConnectionSingleton> _instance =
            new Lazy<DBConnectionSingleton>(() => new DBConnectionSingleton());

        public static DBConnectionSingleton Instance => _instance.Value;

        private static readonly string _connectionString =
            "Server=DESKTOP-89B3HBK\\SQLEXPRESS;Database=HRManagement;User Id=sa;Password=admin;";

        private DBConnectionSingleton() { }

        public SqlConnection GetConnection()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new Exception("Database connection string is not initialized.");
            }

            return new SqlConnection(_connectionString);
        }

    }
}
