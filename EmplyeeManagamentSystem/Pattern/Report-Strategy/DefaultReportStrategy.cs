using EmployeeManagamentSystem.Service;
using EmployeeManagamentSystem.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagamentSystem.Pattern.Report_Strategy
{
    public class DefaultReportStrategy : IReportStrategy
    {
        public (string TextReport, string FilePath) GenerateReport(List<Employee> employees)
        {
            var activeEmployees = employees.Where(e => !e.IsDeleted).ToList();

            var textReport = new StringBuilder();
            textReport.AppendLine($"Complete Salary Report - Generated on {DateTime.Now:d}");
            textReport.AppendLine();

            foreach (var employee in activeEmployees)
            {
                var (reportLine, _, _) = EmployeeProcessor.ProcessEmployee(employee);
                textReport.AppendLine(reportLine);
            }

            var totalSalary = activeEmployees.Sum(e => e.SalaryAfterTax);
            var averageSalary = activeEmployees.Any() ? totalSalary / activeEmployees.Count : 0;

            textReport.AppendLine();
            textReport.AppendLine("Summary");
            textReport.AppendLine($"Total Employees: {activeEmployees.Count}");
            textReport.AppendLine($"Total Salary (After Tax): ${totalSalary:F2}");
            textReport.AppendLine($"Average Salary (After Tax): ${averageSalary:F2}");

            var csv = new StringBuilder();
            csv.AppendLine($"Salary Report - Generated on {DateTime.Now:d}");
            csv.AppendLine();
            csv.AppendLine("\"Employee Name\",\"Type\",\"Department\",\"Salary Before Tax\",\"Tax Amount\",\"Salary After Tax\",\"Employment Date\"");

            foreach (var employee in activeEmployees)
            {
                var (_, csvRow, _) = EmployeeProcessor.ProcessEmployee(employee);
                if (csvRow.HasValue)
                {
                    var row = csvRow.Value;
                    csv.AppendLine($"\"{row.Name}\",\"{row.Type}\",\"{row.Detail}\",\"${row.SalaryBeforeTax:F2}\",\"${row.TaxAmount:F2}\",\"${row.SalaryAfterTax:F2}\",\"{row.EmploymentDate:MM/dd/yyyy}\"");
                }
            }

            csv.AppendLine();
            csv.AppendLine("\"Summary\",");
            csv.AppendLine($"\"Total Employees\",\"{activeEmployees.Count}\"");
            csv.AppendLine($"\"Total Salary (After Tax)\",\"${totalSalary:F2}\"");
            csv.AppendLine($"\"Average Salary (After Tax)\",\"${averageSalary:F2}\"");

            var filePath = $"FullReport_{DateTime.Now:yyyyMMdd}.csv";
            File.WriteAllText(filePath, csv.ToString());

            return (textReport.ToString(), filePath);
        }
    }
}
