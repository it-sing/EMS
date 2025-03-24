using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagamentSystem.Pattern
{
    internal sealed class DBConnectionSingleton
    {
        private static readonly DBConnectionSingleton _instance = new DBConnectionSingleton();
        public static DBConnectionSingleton Instance => _instance;
        private static readonly string _connectionString = $"Server=DESKTOP-89B3HBK\\SQLEXPRESS;Database=HRManagement;User Id=sa;Password=admin;";
        private SqlConnection _connection;

        private DBConnectionSingleton()
        {
            _connection = new SqlConnection(_connectionString);
        }

        //public static DataConenetionSingleton Instance => _instance.Value;

        public SqlConnection GetConnection()
        {
            if (_connection.State == ConnectionState.Closed || _connection.State == ConnectionState.Broken)
            {
                _connection.Open();
            }
            return _connection;
        }
    }
}
