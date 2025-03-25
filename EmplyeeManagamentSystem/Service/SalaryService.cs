using EmployeeManagamentSystem.Repositories;
using System;
using System.Data;

namespace EmployeeManagamentSystem.Services
{
    public class SalaryService
    {
        private readonly SalaryRepository _salaryRepository;
        private const decimal TAX_RATE = 0.15m;

        public SalaryService(SalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }

        public DataTable GetEmployees()
        {
            return _salaryRepository.GetEmployees();
        }

        public DataTable GetSalaryDetails(int employeeID)
        {
            return _salaryRepository.GetSalaryDetails(employeeID);
        }

        public bool UpdateSalary(int employeeID, decimal salaryBeforeTax)
        {
            decimal taxAmount = salaryBeforeTax * TAX_RATE;
            decimal salaryAfterTax = salaryBeforeTax - taxAmount;

            int rowsAffected = _salaryRepository.UpdateSalary(employeeID, salaryBeforeTax, taxAmount, salaryAfterTax);

            return rowsAffected == 1;
        }
    }
}
