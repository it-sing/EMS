using EmployeeManagamentSystem.Pattern.Report_Strategy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagamentSystem.Util
{
    public class SalaryReportForm
    {
        private readonly EmployeeRepository _repository;
        private readonly List<Employee> _employees;
        private IReportStrategy _reportStrategy; // Non-nullable, initialized in constructor

        public SalaryReportForm(EmployeeRepository repository)
        {
            _repository = repository;
            _employees = new List<Employee>();
            _reportStrategy = new DefaultReportStrategy(); // Ensure initialization
        }

        public void SetReportStrategy(IReportStrategy reportStrategy)
        {
            _reportStrategy = reportStrategy ?? throw new ArgumentNullException(nameof(reportStrategy));
        }

        public (string TextReport, string FilePath) GenerateReport()
        {
            var employees = GetEmployees();
            return _reportStrategy.GenerateReport(employees);
        }

        public List<Employee> GetEmployees()
        {
            try
            {
                var dataTable = _repository.GetAllEmployees();
                var employees = new List<Employee>();

                foreach (DataRow row in dataTable.Rows)
                {
                    var employee = new Employee
                    {
                        EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                        FirstName = row["FirstName"] == DBNull.Value ? null : row["FirstName"].ToString(),
                        LastName = row["LastName"] == DBNull.Value ? null : row["LastName"].ToString(),
                        Email = row["Email"] == DBNull.Value ? null : row["Email"].ToString(),
                        DateOfBirth = row["DateOfBirth"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["DateOfBirth"]),
                        EmploymentDate = Convert.ToDateTime(row["EmploymentDate"]),
                        UserID = row["UserID"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["UserID"]),
                        SalaryBeforeTax = Convert.ToDecimal(row["SalaryBeforeTax"]),
                        TaxAmount = Convert.ToDecimal(row["TaxAmount"]),
                        SalaryAfterTax = Convert.ToDecimal(row["SalaryAfterTax"]),
                        DepartmentName = row["DepartmentName"] == DBNull.Value ? null : row["DepartmentName"].ToString(),
                        IsDeleted = false // Already filtered by WHERE IsDeleted = 0
                    };
                    employees.Add(employee);
                }

                return employees;
            }
            catch (Exception ex)
            {
                throw new Exception($"SalaryReportForm.GetEmployees failed: {ex.Message}", ex);
            }
        }
    }
}
