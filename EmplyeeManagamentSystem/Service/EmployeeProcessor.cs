using EmployeeManagamentSystem.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagamentSystem.Service
{
    public static class EmployeeProcessor
    {
        public static (string ReportLine, (string Name, string Type, string Detail, decimal SalaryBeforeTax, decimal TaxAmount, decimal SalaryAfterTax, DateTime EmploymentDate)? CsvData, decimal Salary) ProcessEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return ("Warning: Null employee record detected\n", null, 0);
                }


                // Simulate employee type based on DepartmentID (replace with EmploymentType if available)
                bool isFullTime = employee.DepartmentID == 1;
                string type = isFullTime ? "Full-Time" : "Contract";
                string detail = employee.DepartmentName ?? $"Dept {employee.DepartmentID}"; // Use DepartmentName if available
                string name = $"{employee.FirstName} {employee.LastName}";
                string reportLine = $"{type}: {name} ({detail}) - ${employee.SalaryAfterTax:F2} (Tax: ${employee.TaxAmount:F2}) on {employee.EmploymentDate:d}\n";

                var csvData = (
                    Name: name,
                    Type: type,
                    Detail: detail,
                    SalaryBeforeTax: employee.SalaryBeforeTax,
                    TaxAmount: employee.TaxAmount,
                    SalaryAfterTax: employee.SalaryAfterTax,
                    EmploymentDate: employee.EmploymentDate
                );

                return (reportLine, csvData, employee.SalaryAfterTax);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error in ProcessEmployee: {ex.Message}", "Error");
                return ($"Error processing employee: {ex.Message}\n", null, 0);
            }
        }
    }
}
