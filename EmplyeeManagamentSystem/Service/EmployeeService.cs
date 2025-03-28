using System.Data;

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

        public int DeleteEmployee(int employeeId)
        {
            return _employeeRepository.DeleteEmployee(employeeId);
        }

        public bool CreateEmployee(string firstName, string lastName, string email, DateTime dob, DateTime employmentDate, int departmentId)
        {
            // Call the repository method to save the employee to the database
            return _employeeRepository.CreateEmployee(firstName, lastName, email, dob, employmentDate, departmentId);
        }

        // Update an existing employee
        public int UpdateEmployee(int employeeId, string firstName, string lastName, string email, DateTime dateOfBirth, DateTime employmentDate, int departmentId)
        {
            return _employeeRepository.UpdateEmployee(employeeId, firstName, lastName, email, dateOfBirth, employmentDate, departmentId);
        }



    }
}

