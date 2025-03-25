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
        public DataTable GetAllDepartments()
        {
            return _departmentRepository.GetAllDepartments();
        }

        // Get the first department ID
        public int GetFirstDepartmentId()
        {
            return _departmentRepository.GetFirstDepartmentId();
        }

        // Get department details by ID
        public DataTable GetDepartmentDetails(int departmentId)
        {
            return _departmentRepository.GetDepartmentDetails(departmentId);
        }

        // Get navigation info (first, previous, next, last) for a department
        public DataTable GetNavigationInfo(int departmentId)
        {
            return _departmentRepository.GetNavigationInfo(departmentId);
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
        public bool AssignManager(int departmentID, int managerID) => _departmentRepository.UpdateManager(departmentID, managerID) == 2;
    }

}
