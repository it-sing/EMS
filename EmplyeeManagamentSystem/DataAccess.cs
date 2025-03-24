using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EmployeeManagamentSystem.Pattern;

namespace DBProgrammingDemo9
{
    internal class DataAccess
    {
        private static SqlConnection OpenConnection()
        {
            SqlConnection conn = DBConnectionSingleton.Instance.GetConnection();
            conn.Open();
            return conn;
        }

        // ✅ Fetches a DataTable from SQL Query
        public static DataTable GetData(string sql)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database connection error occurred. Please check your connection and try again.", ex);
            }
        }

        // ✅ Fetches a DataSet from multiple SQL Queries
        public static DataSet GetData(string[] sqlStatements)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                {
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand(string.Join(";", sqlStatements), conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            for (int i = 0; i < sqlStatements.Length; i++)
                            {
                                da.TableMappings.Add($"Table{i}", $"Data{i}");
                            }
                            da.Fill(ds);
                        }
                    }
                    return ds;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error executing multiple SQL statements.", ex);
            }
        }

        // ✅ Fetches a DataSet with Parameters
        public static DataSet GetBy(string sql, Dictionary<string, object> parameters = null)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error executing parameterized query.", ex);
            }
        }

        // ✅ Fetches a DataTable with SQL Parameters
        public static DataTable GetByParameter(string sql, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error executing query with SQL parameters.", ex);
            }
        }

        // ✅ Fetches a Single Value
        public static object GetValue(string sql)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error retrieving scalar value.", ex);
            }
        }

        // ✅ Executes INSERT, UPDATE, DELETE Queries
        public static int SendData(string sql)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error executing data modification command.", ex);
            }
        }

        // ✅ Updates Data with Parameters
        public static int UpdateData(string sql, Dictionary<string, object> parameters)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error updating data with parameters.", ex);
            }
        }

        // ✅ Executes Batch Queries with Transaction Support
        public static bool ExecuteTransaction(List<string> sqlStatements)
        {
            using (SqlConnection conn = OpenConnection())
            {
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    foreach (var sql in sqlStatements)
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, conn, transaction))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    return true;
                }
                catch (SqlException)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        // ✅ Sanitizes SQL (Removes extra spaces)
        public static string SQLCleaner(string sql)
        {
            if (string.IsNullOrEmpty(sql))
                return sql;

            return sql.Replace(Environment.NewLine, " ")
                     .Replace("\t", " ")
                     .Trim()
                     .Replace("  ", " ");
        }

        // ✅ Escapes Single Quotes in SQL Queries
        public static string SQLFix(string sql)
        {
            return string.IsNullOrEmpty(sql) ? sql : sql.Replace("'", "''");
        }
    }
}
