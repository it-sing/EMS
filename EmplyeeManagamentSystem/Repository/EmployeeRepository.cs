using System.Data;
using DBProgrammingDemo9;
using System.Data.SqlClient;

namespace EmployeeManagamentSystem
{
    public class EmployeeRepository
    {
        public DataTable GetEmployees()
        {
            string sqlString = "SELECT * FROM Employees";
            return DataAccess.GetData(sqlString);
        }
        public DataTable GetEmployeesByDepartment(int departmentId)
        {
            string sqlString = "SELECT * FROM Employees WHERE DepartmentID = @DepartmentID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DepartmentID", departmentId)
            };
            return DataAccess.GetByParameter(sqlString, parameters);
        }
        // Get employee details by ID
        public DataTable GetEmployeeById(int employeeId)
        {
            string sql = $"SELECT * FROM Employees WHERE EmployeeId = {employeeId}";
            return DataAccess.GetData(sql);
        }

        // Get all employees
        public DataTable GetAllEmployees()
        {
            string sql = "SELECT * FROM Employees";
            return DataAccess.GetData(sql);
        }

        public int CreateEmployee(string firstName, string lastName, string email, DateTime dateOfBirth, DateTime employmentDate, int departmentId)
        {
            string query = @"
                INSERT INTO Employees (DepartmentID, FirstName, LastName, Email, DateOfBirth, EmploymentDate, UserID)
                VALUES (@DepartmentID, @FirstName, @LastName, @Email, @DateOfBirth, @EmploymentDate, @UserID)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DepartmentID", departmentId),
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@Email", email),
                new SqlParameter("@DateOfBirth", dateOfBirth),
                new SqlParameter("@EmploymentDate", employmentDate),
            };

            return DataAccess.SendData(query, parameters);
        }

        // Update an existing employee
        public int UpdateEmployee(int employeeId, string firstName, string lastName, string email, DateTime dateOfBirth, DateTime employmentDate, int departmentId)
        {
            string sql = $"UPDATE Employees SET DepartmentID = {departmentId}, " +
                         $"FirstName = '{firstName}', LastName = '{lastName}', DateOfBirth = '{dateOfBirth}', " +
                         $"EmploymentDate = '{employmentDate}', Email = '{email}' WHERE EmployeeID = {employeeId}";

            SqlParameter[] parameters = new SqlParameter[]
          {
                new SqlParameter("@DepartmentID", departmentId),
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@Email", email),
                new SqlParameter("@DateOfBirth", dateOfBirth),
                new SqlParameter("@EmploymentDate", employmentDate),
          };
            return DataAccess.SendData(sql, parameters);
        }


        // Delete an employee by ID
        //public bool DeleteEmployee(int employeeId)
        //{
        //    string sql = $"DELETE FROM Employees WHERE EmployeeID = {employeeId}";
        //    return DataAccess(sql) == 1;
        //}

    }
}
