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
        public DataRow GetEmployeeById(int employeeId)
        {
            DataTable dt = _employeeRepository.GetEmployeeById(employeeId);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // Create a new employee
        //public bool CreateEmployee(string firstName, string lastName, string email, DateTime dateOfBirth, DateTime employmentDate, int departmentId, EmployeeRepository _employeeRepository)
        //{
        //    return _employeeRepository.CreateEmployee(firstName, lastName, email, dateOfBirth, employmentDate, departmentId);
        //}

        //// Update an existing employee
        //public bool UpdateEmployee(int employeeId, string firstName, string lastName, string email, DateTime dateOfBirth, DateTime employmentDate, int departmentId)
        //{
        //    return _employeeRepository.UpdateEmployee(employeeId, firstName, lastName, email, dateOfBirth, employmentDate, departmentId);
        //}

        // Delete an employee by ID
        //public bool DeleteEmployee(int employeeId)
        //{
        //    return _employeeRepository.DeleteEmployee(employeeId);
        //}
    }
}

