using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagamentSystem.Service
{
    public static class CsvGenerator
    {
        public static void CreateCsvFile(string filePath, string reportTitle, List<(string Name, string Type, string Detail, decimal SalaryBeforeTax, decimal TaxAmount, decimal SalaryAfterTax, DateTime EmploymentDate)> data, decimal totalSalary, int employeeCount, decimal avgSalary)
        {
            var csv = new StringBuilder();

            // Title
            csv.AppendLine($"\"{reportTitle}\"");
            csv.AppendLine(); // Empty line

            // Headers
            csv.AppendLine("\"Employee Name\",\"Type\",\"Department\",\"Salary Before Tax\",\"Tax Amount\",\"Salary After Tax\",\"Employment Date\"");

            // Data
            foreach (var item in data)
            {
                csv.AppendLine($"\"{item.Name}\",\"{item.Type}\",\"{item.Detail}\",\"${item.SalaryBeforeTax:F2}\",\"${item.TaxAmount:F2}\",\"${item.SalaryAfterTax:F2}\",\"{item.EmploymentDate:MM/dd/yyyy}\"");
            }

            // Summary
            csv.AppendLine(); // Empty line
            csv.AppendLine("\"Summary\",");
            csv.AppendLine($"\"Total Employees\",\"{employeeCount}\"");
            csv.AppendLine($"\"Total Salary (After Tax)\",\"${totalSalary:F2}\"");
            csv.AppendLine($"\"Average Salary (After Tax)\",\"${avgSalary:F2}\"");

            // Write to file
            File.WriteAllText(filePath, csv.ToString());
        }
    }
}
