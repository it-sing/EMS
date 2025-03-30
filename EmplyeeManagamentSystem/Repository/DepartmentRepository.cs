using System.Data;
using System.Data.SqlClient;
using DBProgrammingDemo9;
using EmployeeManagamentSystem.Pattern;


namespace EmployeeManagamentSystem
{
    public class DepartmentRepository
    {
        public DataTable GetDepartments()
        {
            string sqlString = "SELECT * FROM Departments";
            return DataAccess.GetData(sqlString);
        }
        public bool IsDepartmentsName(string departmentsName)
        {
            string sql = "SELECT COUNT(1) FROM Departments WHERE DepartmentName = @DepartmentName";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DepartmentName", departmentsName)
            };
            DataTable dt = DataAccess.GetByParameter(sql, parameters);
            return dt.Rows.Count == 1 && Convert.ToInt32(dt.Rows[0][0]) > 0;
        }
        public bool IsEmployeeManager(int employeeId)
        {
            string sql = "SELECT COUNT(1) FROM Departments WHERE ManagerID = @EmployeeID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EmployeeID", employeeId)
            };
            DataTable dt = DataAccess.GetByParameter(sql, parameters);
            return dt.Rows.Count == 1 && Convert.ToInt32(dt.Rows[0][0]) > 0;

        }
        public bool IsDepartmentAssigned(int departmentId)
        {
            string sql = "SELECT COUNT(*) FROM Employees WHERE DepartmentID = @DepartmentID";

            SqlParameter[] parameters = new SqlParameter[]
             {
                new SqlParameter("@DepartmentID", departmentId)
             };
            DataTable dt = DataAccess.GetByParameter(sql, parameters);
            return dt.Rows.Count == 1 && Convert.ToInt32(dt.Rows[0][0]) > 0;
        }
        public DataTable GetAllDepartments()
        {
            string sql = @"
                SELECT 
                    d.DepartmentID, 
                    d.DepartmentName, 
                    d.Description, 
                    COALESCE(e.FirstName + ' ' + e.LastName, ' ') AS ManagerName
                FROM Departments d
                LEFT JOIN Employees e ON d.ManagerID = e.EmployeeID;";
            return DataAccess.GetData(sql);
        }
        public int GetFirstDepartmentId()
        {
            string sql = "SELECT TOP 1 DepartmentID FROM Departments ORDER BY DepartmentID ASC";
            return (int)DataAccess.GetValue(sql);
        }
        public DataTable GetDepartmentDetails(int departmentId)
        {
            string sql = $"SELECT * FROM Departments WHERE DepartmentID = {departmentId}";
            return DataAccess.GetData(sql);
        }
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
                new SqlParameter("@DepartmentID", departmentId),
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
        public DataTable GetDepartmentCurrentManager(int departmentID)
        {
            string sqlString = @"SELECT (SELECT CONCAT(FirstName, ' ', LastName) FROM Employees WHERE EmployeeID = Departments.ManagerID) as CurrentManager FROM Departments WHERE DepartmentID = @DepartmentID;";
            SqlParameter[] parameters = { new SqlParameter("@DepartmentID", departmentID) };
            return DataAccess.GetByParameter(sqlString, parameters);
        }

        public int UpdateManager(int departmentID, int? managerID)
        {
            string sqlString = @"
                UPDATE Employees 
                SET DepartmentID = @DepartmentID 
                WHERE EmployeeID = @ManagerID;

                UPDATE Departments 
                SET ManagerID = @ManagerID 
                WHERE DepartmentID = @DepartmentID;
            ";

                    // Using DBNull.Value for null managerID
                    SqlParameter[] parameters =
                    {
                new SqlParameter("@DepartmentID", departmentID),
                new SqlParameter("@ManagerID", (object)managerID ?? DBNull.Value)  // If managerID is null, it will pass DBNull.Value
            };

            return DataAccess.SendData(sqlString, parameters);
        }



    }
}
