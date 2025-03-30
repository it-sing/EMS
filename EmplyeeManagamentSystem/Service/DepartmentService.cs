using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagamentSystem
{
    public class DepartmentService
    {
        private DepartmentRepository _departmentRepository;

        public DepartmentService()
        {
            _departmentRepository = new DepartmentRepository();
        }
        public DataTable Departments => _departmentRepository.GetDepartments();

        public bool IsDepartmentName(string departmentName)
        {
            return _departmentRepository.IsDepartmentsName(departmentName);
        }
        public bool IsEmployeeManager(int employeeID)
        {
            return _departmentRepository.IsEmployeeManager(employeeID);
        }
        public bool IsDepartmentAssigned(int departmentId)
        {
            return _departmentRepository.IsDepartmentAssigned(departmentId);
        }

        // Get all departments
        public DataTable GetAllDepartments()
        {
            return _departmentRepository.GetAllDepartments();
        }

        // Get the first department ID
        public int GetFirstDepartmentId()
        {
            return _departmentRepository.GetFirstDepartmentId();
        }

        // Create a new department
        public bool CreateDepartment(string departmentName, string description)
        {
            int result = _departmentRepository.CreateDepartment(departmentName, description);
            return result == 1;
        }

        // Save department changes
        public bool SaveDepartmentChanges(int departmentId, string departmentName, string description)
        {
            int result = _departmentRepository.UpdateDepartment(departmentId, departmentName, description);
            return result == 1;
        }

        // Delete a department
        public bool DeleteDepartment(int departmentId)
        {
            int result = _departmentRepository.DeleteDepartment(departmentId);
            return result == 1;
        }
        public DataTable GetDepartments()
        {
            return _departmentRepository.GetAllDepartments();
        }

        public DataTable GetCurrentManager(int departmentID) => _departmentRepository.GetDepartmentCurrentManager(departmentID);
        public bool AssignManager(int departmentID, int? managerID) => _departmentRepository.UpdateManager(departmentID, managerID) == 2;
    }

}
