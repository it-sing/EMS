using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagamentSystem.Repository;

namespace EmployeeManagamentSystem.Service
{
    public class AttendanceService
    {
        private readonly AttendanceRepository attendanceRepository;

        public AttendanceService()
        {
            attendanceRepository = new AttendanceRepository();
        }

        public string GetEmployeeName(int employeeId)
        {
            return attendanceRepository.GetEmployeeName(employeeId);
        }

        public int GetEmployeeId(int userID)
        {
            return attendanceRepository.GetEmployeeId(userID);
        }

        public DataTable GetAttendanceData(int employeeID, int month, int year)
        {
            return attendanceRepository.GetAttendanceData(employeeID, month, year);
        }

        public string CheckInOut(int employeeID)
        {
            return attendanceRepository.InsertOrUpdateAttendance(employeeID);
        }
    }

}
