using EmployeeManagamentSystem.Pattern.Report_Strategy;
using EmployeeManagamentSystem.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagamentSystem.Service
{
    public class DateRangeReportStrategy : IReportStrategy
    {
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;

        public DateRangeReportStrategy(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
        }

        public (string TextReport, string FilePath) GenerateReport(List<Employee> employees)
        {
            // Add debug information
            System.Windows.Forms.MessageBox.Show($"Starting report generation with {employees.Count} employees", "Debug");

            var filteredEmployees = employees
                .Where(e => e.EmploymentDate >= _startDate && e.EmploymentDate <= _endDate && !e.IsDeleted)
                .ToList();

            System.Windows.Forms.MessageBox.Show($"After filtering: {filteredEmployees.Count} employees", "Debug");

            var textReport = new StringBuilder();
            textReport.AppendLine($"Salary Report: {_startDate:d} to {_endDate:d}");
            textReport.AppendLine();

            foreach (var employee in filteredEmployees)
            {
                var (reportLine, _, _) = EmployeeProcessor.ProcessEmployee(employee);
                textReport.AppendLine(reportLine);
            }

            var totalSalary = filteredEmployees.Sum(e => e.SalaryAfterTax);
            var averageSalary = filteredEmployees.Any() ? totalSalary / filteredEmployees.Count : 0;

            textReport.AppendLine();
            textReport.AppendLine("Summary");
            textReport.AppendLine($"Total Employees: {filteredEmployees.Count}");
            textReport.AppendLine($"Total Salary (After Tax): ${totalSalary:F2}");
            textReport.AppendLine($"Average Salary (After Tax): ${averageSalary:F2}");

            var csv = new StringBuilder();
            csv.AppendLine($"Salary Report: {_startDate:d} to {_endDate:d}");
            csv.AppendLine();
            csv.AppendLine("\"Employee Name\",\"Type\",\"Department\",\"Salary Before Tax\",\"Tax Amount\",\"Salary After Tax\",\"Employment Date\"");

            foreach (var employee in filteredEmployees)
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
            csv.AppendLine($"\"Total Employees\",\"{filteredEmployees.Count}\"");
            csv.AppendLine($"\"Total Salary (After Tax)\",\"${totalSalary:F2}\"");
            csv.AppendLine($"\"Average Salary (After Tax)\",\"${averageSalary:F2}\"");

            // Create a more specific path to ensure it's in the right location
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(appDirectory, $"DateRangeReport_{_startDate:yyyyMMdd}_{_endDate:yyyyMMdd}.csv");

            try
            {
                File.WriteAllText(filePath, csv.ToString());
                System.Windows.Forms.MessageBox.Show($"File written to: {filePath}", "Debug");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error writing file: {ex.Message}", "Error");
                // Try writing to another location as fallback
                filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                                       $"DateRangeReport_{_startDate:yyyyMMdd}_{_endDate:yyyyMMdd}.csv");
                File.WriteAllText(filePath, csv.ToString());
                System.Windows.Forms.MessageBox.Show($"Fallback file written to: {filePath}", "Debug");
            }

            return (textReport.ToString(), filePath);
        }
    }
}
