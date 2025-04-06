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

        public string GetEmployeeName(int userID)
        {
            int employeeId = attendanceRepository.GetEmployeeId(userID);
            return attendanceRepository.GetEmployeeName(employeeId);
        }

        public int GetEmployeeId(int userID)
        {
            return attendanceRepository.GetEmployeeId(userID);
        }

        public DataTable GetAttendanceData(int userID, int month, int year)
        {
            int employeeID = attendanceRepository.GetEmployeeId(userID);
            return attendanceRepository.GetAttendanceData(employeeID, month, year);
        }

        public string CheckInOut(int userID)
        {
            int employeeID = attendanceRepository.GetEmployeeId(userID);
            return attendanceRepository.InsertOrUpdateAttendance(employeeID);
        }
    }

}
