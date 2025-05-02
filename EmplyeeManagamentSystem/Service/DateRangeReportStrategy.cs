using EmployeeManagamentSystem.Pattern.Report_Strategy;
using EmployeeManagamentSystem.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;  // To use FolderBrowserDialog

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
            var filteredEmployees = employees
                .Where(e => e.EmploymentDate >= _startDate && e.EmploymentDate <= _endDate && !e.IsDeleted)
                .ToList();

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

            // Initialize FolderBrowserDialog to select folder
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select Folder to Save the Report"; // Set dialog description

                // Show dialog and check if the user selected a folder
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = folderDialog.SelectedPath;

                    // Construct the file name based on the selected date range
                    var fileName = $"DateRangeReport_{_startDate:yyyyMMdd}_{_endDate:yyyyMMdd}.csv";
                    string filePath = Path.Combine(folderPath, fileName); // Combine folder path and file name

                    // Create the CSV content
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

                    // Add summary at the end of the CSV
                    csv.AppendLine();
                    csv.AppendLine("\"Summary\",");
                    csv.AppendLine($"\"Total Employees\",\"{filteredEmployees.Count}\"");
                    csv.AppendLine($"\"Total Salary (After Tax)\",\"${totalSalary:F2}\"");
                    csv.AppendLine($"\"Average Salary (After Tax)\",\"${averageSalary:F2}\"");

                    try
                    {
                        // Save the CSV report to the selected folder and file path
                        File.WriteAllText(filePath, csv.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error writing file: {ex.Message}", "Error");
                    }

                    return (textReport.ToString(), filePath); // Return both text report and file path
                }
                else
                {
                    // If the user cancels folder selection, return with empty file path
                    return (textReport.ToString(), string.Empty);
                }
            }
        }
    }
}
