using System.Data;
using EmployeeManagamentSystem.Pattern;
using EmployeeManagamentSystem.Repository;
using Microsoft.VisualBasic.ApplicationServices;

namespace EmployeeManagamentSystem
{
    public class EmployeeService
    {
        private EmployeeRepository _employeeRepository;

        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }


        public DataTable Employees => _employeeRepository.GetAllEmployees();
        public DataTable GetEmployeesByDepartment(int departmentId)
        {
            return _employeeRepository.GetEmployeesByDepartment(departmentId);
        }
        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                // Perform the delete operation
                int rowsAffected = _employeeRepository.DeleteEmployee(employeeId);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Handle and log exception
                throw new Exception("Failed to delete employee.", ex);
            }
        }
        public int UpdateEmployee(int employeeId, string firstName, string lastName, string email, DateTime dateOfBirth, DateTime employmentDate, int departmentId)
        {
            return _employeeRepository.UpdateEmployee(employeeId, firstName, lastName, email, dateOfBirth, employmentDate, departmentId);
        }


        // for manager
        public DataTable GetEmployees() => _employeeRepository.GetEmployees();

    }
}

