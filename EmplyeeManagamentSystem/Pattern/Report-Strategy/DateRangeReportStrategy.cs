using ClosedXML.Excel;
using EmployeeManagamentSystem.Pattern.Report_Strategy;
using EmployeeManagamentSystem.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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

            var textReport = new System.Text.StringBuilder();
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
            textReport.AppendLine($"Total Salary (After Tax): {totalSalary:F2}");
            textReport.AppendLine($"Average Salary (After Tax): {averageSalary:F2}");

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select Folder to Save the Report";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = folderDialog.SelectedPath;
                    string fileName = $"DateRangeReport_{_startDate:yyyyMMdd}_{_endDate:yyyyMMdd}.xlsx";
                    string filePath = Path.Combine(folderPath, fileName);

                    try
                    {
                        var workbook = new XLWorkbook();
                        var worksheet = workbook.Worksheets.Add("Salary Report");

                        // Title
                        worksheet.Cell(1, 1).Value = $"Salary Report: {_startDate:d} to {_endDate:d}";
                        worksheet.Range(1, 1, 1, 7).Merge().Style.Font.SetBold().Font.FontSize = 14;

                        // Headers
                        worksheet.Cell(3, 1).Value = "Employee Name";
                        worksheet.Cell(3, 2).Value = "Type";
                        worksheet.Cell(3, 3).Value = "Department";
                        worksheet.Cell(3, 4).Value = "Salary Before Tax";
                        worksheet.Cell(3, 5).Value = "Tax Amount";
                        worksheet.Cell(3, 6).Value = "Salary After Tax";
                        worksheet.Cell(3, 7).Value = "Employment Date";
                        worksheet.Range(3, 1, 3, 7).Style.Font.SetBold();

                        // Data
                        int row = 4;
                        foreach (var employee in filteredEmployees)
                        {
                            var (_, csvRow, _) = EmployeeProcessor.ProcessEmployee(employee);
                            if (csvRow.HasValue)
                            {
                                var data = csvRow.Value;
                                worksheet.Cell(row, 1).Value = data.Name;
                                worksheet.Cell(row, 2).Value = data.Type;
                                worksheet.Cell(row, 3).Value = data.Detail;
                                worksheet.Cell(row, 4).Value = data.SalaryBeforeTax;
                                worksheet.Cell(row, 5).Value = data.TaxAmount;
                                worksheet.Cell(row, 6).Value = data.SalaryAfterTax;
                                worksheet.Cell(row, 7).Value = data.EmploymentDate.ToString("MM/dd/yyyy");
                                row++;
                            }
                        }

                        // Summary
                        row += 2;
                        worksheet.Cell(row, 1).Value = "Summary";
                        worksheet.Cell(row, 1).Style.Font.SetBold();

                        row++;
                        worksheet.Cell(row, 1).Value = "Total Employees";
                        worksheet.Cell(row, 2).Value = filteredEmployees.Count;

                        row++;
                        worksheet.Cell(row, 1).Value = "Total Salary (After Tax)";
                        worksheet.Cell(row, 2).Value = totalSalary;

                        row++;
                        worksheet.Cell(row, 1).Value = "Average Salary (After Tax)";
                        worksheet.Cell(row, 2).Value = averageSalary;

                        // Apply border to the data range
                        var lastDataRow = row - 5;
                        var dataRange = worksheet.Range(3, 1, lastDataRow, 7);
                        dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                        // Auto-fit columns
                        worksheet.Columns().AdjustToContents();

                        // Save file
                        workbook.SaveAs(filePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error writing Excel file: {ex.Message}", "Error");
                    }

                    return (textReport.ToString(), filePath);
                }
                else
                {
                    return (textReport.ToString(), string.Empty);
                }
            }
        }
    }
}
