using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DBProgrammingDemo9;
using EmployeeManagamentSystem.Pattern;

namespace EmployeeManagamentSystem
{
    public class EmployeeRepository
    {

        public DataTable GetEmployeesByDepartment(int departmentId)
        {
            string sqlString = @"
                                SELECT 
                                e.EmployeeID, 
                                e.FirstName, 
                                e.LastName, 
                                e.Email, 
                                e.DateOfBirth,  
                                e.EmploymentDate,   
                                e.SalaryBeforeTax,   
                                e.TaxAmount,  
                                e.SalaryAfterTax,   
                                e.UserID,
                                d.DepartmentName
                            FROM Employees e 
                            LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
                            WHERE e.DepartmentID = @DepartmentID 
                              AND e.IsDeleted = 0;";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@DepartmentID", departmentId)
            };
            return DataAccess.GetByParameter(sqlString, parameters);
        }

        public DataTable GetEmployees()
        {
            string sqlString = "SELECT EmployeeID, CONCAT(FirstName, ' ', LastName) AS EmployeeName FROM Employees WHERE IsDeleted = 0;";
            return DataAccess.GetData(sqlString);
        }
        public DataTable GetAllEmployees()
        {
            string sql = @"
                        SELECT 
                            e.EmployeeID, 
                            e.FirstName, 
                            e.LastName, 
                            e.Email, 
                            e.DateOfBirth,  
                            e.EmploymentDate,   
                            e.SalaryBeforeTax,   
                            e.TaxAmount,  
                            e.SalaryAfterTax,   
                            e.UserID,
                            d.DepartmentName
                        FROM Employees e 
                        LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
                        WHERE e.IsDeleted = 0;";
                            return DataAccess.GetData(sql);
        }

        public bool CreateEmployee(string firstName, string lastName, string email, DateTime dob, DateTime employmentDate, int departmentId)
        {
            string query = @"
            INSERT INTO Employees (FirstName, LastName, Email, DateOfBirth, EmploymentDate, DepartmentID)
            VALUES (@FirstName, @LastName, @Email, @DateOfBirth, @EmploymentDate, @DepartmentID)";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@Email", email),
                new SqlParameter("@DateOfBirth", dob),
                new SqlParameter("@EmploymentDate", employmentDate),
                new SqlParameter("@DepartmentID", departmentId),
            };

            try
            {
                // Assuming DataAccess is a helper class that sends the query to the database
                int rowsAffected = DataAccess.SendData(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public int UpdateEmployee(int employeeId, string firstName, string lastName, string email, DateTime dateOfBirth, DateTime employmentDate, int departmentId)
        {
            string sql = "UPDATE Employees SET DepartmentID = @DepartmentID, FirstName = @FirstName, LastName = @LastName, " +
                         "DateOfBirth = @DateOfBirth, EmploymentDate = @EmploymentDate, Email = @Email " +
                         "WHERE EmployeeID = @EmployeeID";

            var parameters = new Dictionary<string, object>
            {
                { "@DepartmentID", departmentId },
                { "@FirstName", firstName },
                { "@LastName", lastName },
                { "@Email", email },
                { "@DateOfBirth", dateOfBirth },
                { "@EmploymentDate", employmentDate },
                { "@EmployeeID", employeeId }
            };

            try
            {
                return DataAccess.UpdateData(sql, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the employee: {ex.Message}");
                return -1; // Return -1 or handle as per your needs
            }
        }

        public DataTable GetEmployeeById(int employeeId)
        {
            string sql = "SELECT * FROM Employees WHERE EmployeeId = @EmployeeId";
            SqlParameter[] parameters = { new SqlParameter("@EmployeeId", employeeId) };
            return DataAccess.GetByParameter(sql, parameters);
        }

        public int DeleteEmployee(int employeeId)
        {
            string sql = "UPDATE Employees SET IsDeleted = 1 WHERE EmployeeID = @EmployeeID;";
            SqlParameter[] parameters = { new SqlParameter("@EmployeeID", employeeId) };

            try
            {
                return DataAccess.SendData(sql, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the employee: {ex.Message}");
                return -1; 
            }
        }
    }
}
