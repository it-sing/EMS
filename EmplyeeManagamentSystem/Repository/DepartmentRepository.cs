﻿using System.Data;
using System.Data.SqlClient;
using DBProgrammingDemo9;
using EmployeeManagamentSystem.Pattern;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EmployeeManagamentSystem
{
    public class DepartmentRepository
    {
        public DataTable GetDepartments()
        {
            string sqlString = "SELECT * FROM Departments";
            return DataAccess.GetData(sqlString);
        }

        public DataTable GetAllDepartments()
        {
            string sql = "SELECT * FROM Departments";
            return DataAccess.GetData(sql);
        }
        public int GetFirstDepartmentId()
        {
            string sql = "SELECT TOP 1 DepartmentID FROM Departments ORDER BY DepartmentID ASC";
            return (int)DataAccess.GetValue(sql);
        }

        // Get the department details by ID
        public DataTable GetDepartmentDetails(int departmentId)
        {
            string sql = $"SELECT * FROM Departments WHERE DepartmentID = {departmentId}";
            return DataAccess.GetData(sql);
        }

        // Get navigation info (previous, next, first, last) for departments
        public DataTable GetNavigationInfo(int departmentId)
        {
            string sql = $@"
                SELECT
                    (SELECT TOP(1) DepartmentID FROM Departments ORDER BY DepartmentID ASC) AS FirstDepartmentId,
                    LEAD(DepartmentID) OVER(ORDER BY DepartmentID) AS NextDepartmentId,
                    LAG(DepartmentID) OVER(ORDER BY DepartmentID) AS PreviousDepartmentId,
                    (SELECT TOP(1) DepartmentID FROM Departments ORDER BY DepartmentID DESC) AS LastDepartmentId
                FROM Departments
                WHERE DepartmentID = {departmentId}";

            return DataAccess.GetData(sql);
        }

        // Create a new department
        public int CreateDepartment(string departmentName, string description)
        {
            string sql = $"INSERT INTO Departments (DepartmentName, Description) VALUES ('{departmentName}', '{description}')";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DepartmentName", departmentName),
                new SqlParameter("@Description", description),
            };
            return DataAccess.SendData(sql, parameters);
        }

        // Update an existing department
        public int UpdateDepartment(int departmentId, string departmentName, string description)
        {
            string sql = $@"
                UPDATE Departments 
                SET DepartmentName = '{departmentName}', Description = '{description}'
                WHERE DepartmentID = {departmentId}";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DepartmentName", departmentName),
                new SqlParameter("@Description", description),
            };

            return DataAccess.SendData(sql, parameters);
        }

        // Delete a department by ID
        public int DeleteDepartment(int departmentId)
        {
            string sql = $"DELETE FROM Departments WHERE DepartmentID = {departmentId}";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DepartmentID", departmentId),
            };
            return DataAccess.SendData(sql, parameters);
        }
        //public DataTable GetAllDepartments()
        //{
        //    string sql = "SELECT DepartmentID, DepartmentName FROM Departments;";
        //    return DataAccess.GetData(sql);
        //}

        public DataTable GetDepartmentCurrentManager(int departmentID)
        {
            string sql = $@"
            SELECT (SELECT CONCAT(FirstName, ' ', LastName) FROM Employees WHERE EmployeeID = Departments.ManagerID) AS CurrentManager
            FROM Departments WHERE DepartmentID = {departmentID};";
            return DataAccess.GetData(sql);
        }

        public int UpdateManager(int departmentID, int managerID)
        {
            string sql = $@"
            UPDATE Employees SET DepartmentID = {departmentID} WHERE EmployeeID = {managerID};
            UPDATE Departments SET ManagerID = {managerID} WHERE DepartmentID = {departmentID};";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DepartmentID", departmentID),
                new SqlParameter("@ManagerID", managerID),
            };
            return DataAccess.SendData(sql, parameters);
        }

    }
}
