using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DBProgrammingDemo9;
using System.Diagnostics;

namespace EmployeeManagamentSystem.Repository
{
    public class UserRepository
    {
        public string GetUserRole(int userID)
        {
            string sql = "SELECT Role FROM Users WHERE UserID = @UserID";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@UserID", userID)
            };
            DataTable dt = DataAccess.GetByParameter(sql, parameters);
            return dt.Rows.Count == 1 ? dt.Rows[0]["Role"].ToString() : string.Empty;
        }
        public DataTable GetUserByUsernameAndPassword(string username, string password)
        {
            string sql = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };
            return DataAccess.GetByParameter(sql, parameters);
        }

        public DataTable GetUserById(int userId)
        {
            string sql = $@"
                    SELECT
                    EmployeeID,
                    Employees.FirstName,
                    Employees.LastName,
                    Employees.Email,
                    Users.Username,
                    Employees.DateOfBirth,
                    Employees.EmploymentDate
                FROM Employees
                    INNER JOIN Users
                    ON Employees.UserID = Users.UserID
                WHERE Users.UserID = {userId};
                 ";

            return DataAccess.GetData(sql);
        }

        public int SaveEmployeeChanges(int userId, string firstName, string lastName, string email, DateTime dateOfBirth, DateTime employmentDate)
        {
            string query = @"
                UPDATE Employees 
                SET 
                    FirstName = @FirstName, 
                    LastName = @LastName, 
                    Email = @Email, 
                    DateOfBirth = @DateOfBirth, 
                    EmploymentDate = @EmploymentDate
                WHERE UserID = @UserID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@Email", email),
                new SqlParameter("@DateOfBirth", dateOfBirth),
                new SqlParameter("@EmploymentDate", employmentDate)
            };

            return DataAccess.SendData(query, parameters);
        }

        public int CreateEmployee(string firstName, string lastName, string email, DateTime dateOfBirth, DateTime employmentDate, int userId)
        {
            string query = @"
                INSERT INTO Employees (FirstName, LastName, Email, DateOfBirth, EmploymentDate, UserID)
                VALUES (@FirstName, @LastName, @Email, @DateOfBirth, @EmploymentDate, @UserID)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@Email", email),
                new SqlParameter("@DateOfBirth", dateOfBirth),
                new SqlParameter("@EmploymentDate", employmentDate),
                new SqlParameter("@UserID", userId)
            };

            return DataAccess.SendData(query, parameters);
        }
        public bool IsUserNameExists(string userName)
        {
            string sql = "SELECT COUNT(*) FROM Users WHERE Username = @Username;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", userName)
            };

            int count = (int)DataAccess.GetByParameter(sql, parameters).Rows[0][0];
            return count > 0;
        }

        public int CreateUser(string username, string password, string email, int roleId, DateTime createdAt)
        {
            string sql = "INSERT INTO Users (Username, Password, Email, RoleID, CreatedAt) " +
                         "OUTPUT INSERTED.UserID " +
                         "VALUES (@Username, @Password, @Email, @RoleID, @CreatedAt);";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password), // Password stored as plain text (not recommended)
                new SqlParameter("@Email", email),
                new SqlParameter("@RoleID", roleId),
                new SqlParameter("@CreatedAt", createdAt)
            };

            DataTable dt = DataAccess.GetByParameter(sql, parameters);

            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["UserID"]);

            return -1; // Indicate failure
        }
        public DataSet GetUsers(string filterByRole = null)
        {
            string sql = "SELECT U.UserID, U.Username, U.Email, R.RoleName, U.CreatedAt " +
                         "FROM Users U " +
                         "JOIN Roles R ON U.Role = R.RoleID " +
                         "WHERE U.IsDeleted = 0";

            if (!string.IsNullOrEmpty(filterByRole))
            {
                sql += " AND R.RoleName = @RoleName";
            }

            var parameters = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(filterByRole))
            {
                parameters.Add("@RoleName", filterByRole);
            }

            return DataAccess.GetBy(sql, parameters);
        }

        public int PromoteUser(int userID, string newRole)
        {
            string sql = "UPDATE Users SET Role = @RoleID WHERE UserID = @UserID";
            var parameters = new Dictionary<string, object>
        {
            { "@RoleID", newRole },
            { "@UserID", userID }
        };
            return DataAccess.UpdateData(sql, parameters);
        }

        public int DeleteUser(int userID)
        {
            string sql = "UPDATE Users SET IsDeleted = 1 WHERE UserID = @UserID";
            var parameters = new Dictionary<string, object>
        {
            { "@UserID", userID }
        };
            return DataAccess.UpdateData(sql, parameters);
        }

        public int ApproveUser(int userID)
        {
            string sql = "UPDATE Users SET Role = 3 WHERE UserID = @UserID";
            var parameters = new Dictionary<string, object>
        {
            { "@UserID", userID }
        };
            return DataAccess.UpdateData(sql, parameters);
        }

    }
}
