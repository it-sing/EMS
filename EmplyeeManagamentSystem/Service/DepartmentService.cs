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

        // Create a new department
        public int CreateDepartment(string departmentName, string description)
        {
             return _departmentRepository.CreateDepartment(departmentName, description);

        }
        // Save department changes
        public int SaveDepartmentChanges(int departmentId, string departmentName, string description)
        {
            return _departmentRepository.UpdateDepartment(departmentId, departmentName, description);          
        }

        // Delete a department
        public bool DeleteDepartment(int departmentId)
        {
            int result = _departmentRepository.DeleteDepartment(departmentId);
            return result == 1;
        }
        public DataTable GetDepartments() => _departmentRepository.GetDepartments();

        public DataTable GetCurrentManager(int departmentID) => _departmentRepository.GetDepartmentCurrentManager(departmentID);

        public int AssignManager(int departmentID, int? managerID)
            => _departmentRepository.UpdateManager(departmentID, managerID);
    }

}
