using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBProgrammingDemo9;

namespace EmployeeManagamentSystem.Repository
{
    public class AttendanceRepository
    {
        public DataTable GetAttendanceData(int empId, int month, int year)
        {
            string sql = @"
            SELECT AttendanceID, CheckIn, CheckOut
            FROM [dbo].[Attendance]
            WHERE EmployeeID = @empId";

            if (month > 0 && year > 0)
            {
                sql += " AND MONTH(CheckIn) = @Month AND YEAR(CheckIn) = @Year";
            }
            else if (month > 0)
            {
                sql += " AND MONTH(CheckIn) = @Month AND YEAR(CheckIn) = @Year";
                year = DateTime.Now.Year;
            }
            else if (year > 0)
            {
                sql += " AND YEAR(CheckIn) = @Year";
            }

            sql += " ORDER BY CheckIn DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@empId", empId),
            new SqlParameter("@Month", month),
            new SqlParameter("@Year", year)
            };

            return DataAccess.GetByParameter(sql, parameters);
        }

        public int GetEmployeeId(int userId)
        {
            string sql = "SELECT EmployeeID FROM [dbo].[Employees] WHERE UserID = @UserID;";
            DataTable dt = DataAccess.GetByParameter(sql, new SqlParameter[] { new SqlParameter("@UserID", userId) });

            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
            }
            else
            {
                return 0;
            }
        }

        public string GetEmployeeName(int employeeID)
        {
            string sql = "SELECT FirstName, LastName FROM [dbo].[Employees] WHERE EmployeeID = @EmployeeID;";
            DataTable dt = DataAccess.GetByParameter(sql, new SqlParameter[] { new SqlParameter("@EmployeeID", employeeID) });

            if (dt.Rows.Count > 0)
            {
                string firstName = dt.Rows[0]["FirstName"].ToString();
                string lastName = dt.Rows[0]["LastName"].ToString();
                return $"{firstName} {lastName}";
            }
            else
            {
                //throw new Exception("Employee Name not found for Employee ID: " + employeeID);
                return null;
            }
        }

        public string InsertOrUpdateAttendance(int empId)
        {
            try
            {
                // Check if attendance already exists for today
                string checkSql = @"
                                SELECT AttendanceID, CheckIn, CheckOut
                                FROM [dbo].[Attendance]
                                WHERE EmployeeID = @empId
                                AND CONVERT(date, CheckIn) = CONVERT(date, GETDATE())";
                DataTable dt = DataAccess.GetByParameter(checkSql, new SqlParameter[] { new SqlParameter("@empId", empId) });

                if (dt.Rows.Count > 0)
                {
                    // Record exists for today
                    int attendanceId = Convert.ToInt32(dt.Rows[0]["AttendanceID"]);
                    var checkOut = dt.Rows[0]["CheckOut"];

                    if (checkOut == DBNull.Value || checkOut == null)
                    {
                        // Has checked in but not checked out - perform checkout
                        string updateSql = @"
                            UPDATE [dbo].[Attendance]
                            SET CheckOut = GETDATE()
                            WHERE AttendanceID = @attendanceId";
                        DataAccess.SendData(updateSql, new SqlParameter[] { new SqlParameter("@attendanceId", attendanceId) });
                        return "CHECKOUT"; 
                    }
                    else
                    {
                        return "COMPLETED"; 
                    }
                }
                else
                {
                    // No record exists for today - perform check-in
                    string insertSql = @"
                    INSERT INTO [dbo].[Attendance] (EmployeeID, CheckIn, CheckOut)
                    VALUES (@empId, GETDATE(), NULL)";
                    DataAccess.SendData(insertSql, new SqlParameter[] { new SqlParameter("@empId", empId) });
                    return "CHECKIN"; // Successfully checked in
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Attendance Error: " + ex.Message);
            }
        }

    }

}
