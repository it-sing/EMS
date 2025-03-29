using System.Data;
using System.Data.SqlClient;
using EmployeeManagementSystem.Pattern;

namespace DBProgrammingDemo9
{
    public class DataAccess
    {
        private static SqlConnection OpenConnection()
        {
            SqlConnection conn = DBConnectionSingleton.Instance.GetConnection();
            conn.Open();
            return conn;
        }

        public static DataTable GetData(string sql)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database connection error occurred.", ex);
            }
        }

        public static DataSet GetMultiData(string[] sqlStatements)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                {
                    DataSet ds = new DataSet();
                    for (int i = 0; i < sqlStatements.Length; i++)
                    {
                        using (SqlCommand cmd = new SqlCommand(sqlStatements[i], conn))
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds, $"Table{i}");
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

        public static DataSet GetBy(string sql, Dictionary<string, object> parameters = null)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        return ds;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error executing parameterized query.", ex);
            }
        }

        public static DataTable GetByParameter(string sql, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing query: {ex.Message}");
                return new DataTable();
            }
        }

        public static object GetValue(string sql)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error retrieving scalar value.", ex);
            }
        }

        public static int SendData(string sql, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error executing data modification command.", ex);
            }
        }
        public static int Send(string sql)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("Error executing data modification command.", ex);
            }
        }


        public static int UpdateData(string sql, Dictionary<string, object> parameters)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error updating data with parameters.", ex);
            }
        }

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
                    try
                    {
                        transaction.Rollback();
                    }
                    catch { /* Prevent secondary exceptions */ }
                    throw;
                }
            }
        }


        public static string SQLCleaner(string sql)
        {
            if (string.IsNullOrEmpty(sql))
                return sql;

            return sql.Replace(Environment.NewLine, " ")
                      .Replace("\t", " ")
                      .Trim()
                      .Replace("  ", " ");
        }

        public static string SQLFix(string sql)
        {
            return string.IsNullOrEmpty(sql) ? sql : sql.Replace("'", "''");
        }
    }
}
