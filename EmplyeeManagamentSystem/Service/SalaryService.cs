// SalaryService.cs
using EmployeeManagamentSystem.Pattern.Salary;
using EmployeeManagamentSystem.Repositories;
using System;
using System.Data;

namespace EmployeeManagamentSystem.Services
{
    public class SalaryService
    {
        private readonly SalaryRepository _salaryRepository;

        public SalaryService(SalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }

        // Using Strategy Pattern to calculate salary
        public bool UpdateSalary(int employeeID, decimal salaryBeforeTax, ITaxCalculationStrategy taxCalculationStrategy)
        {
            decimal taxAmount = taxCalculationStrategy.CalculateTax(salaryBeforeTax);
            return _salaryRepository.UpdateSalary(employeeID, salaryBeforeTax, taxAmount);
        }
        public DataTable GetEmployees()
        {
            return _salaryRepository.GetEmployees();
        }

        public DataTable GetSalaryDetails(int employeeID)
        {
            return _salaryRepository.GetSalaryDetails(employeeID);
        }
    }
}
