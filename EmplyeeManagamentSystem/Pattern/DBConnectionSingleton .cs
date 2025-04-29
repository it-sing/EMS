using System;
using System.Data.SqlClient;

namespace EmployeeManagementSystem.Pattern
{
    public sealed class DBConnectionSingleton
    {
        private static readonly DBConnectionSingleton _instance = new DBConnectionSingleton();

        private static readonly string _connectionString =
            "Server=DESKTOP-89B3HBK\\SQLEXPRESS;Database=EMSDB;User Id=sa;Password=admin;";

        private DBConnectionSingleton() { }

        public static DBConnectionSingleton Instance => _instance;

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}