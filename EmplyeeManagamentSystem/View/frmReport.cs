using EmployeeManagamentSystem.Service;
using EmployeeManagamentSystem.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagamentSystem.View
{
    public partial class frmReport : Form
    {
        private readonly SalaryReportForm _reportForm;

        public frmReport(SalaryReportForm reportForm)
        {
            InitializeComponent();
            _reportForm = reportForm;

            // Clear and set up DataGridView columns
            dgvAttendance.Columns.Clear();
            dgvAttendance.Columns.Add("Type", "Type");
            dgvAttendance.Columns.Add("EmployeeName", "Employee Name");
            dgvAttendance.Columns.Add("Department", "Department");
            dgvAttendance.Columns.Add("SalaryAfterTax", "Salary After Tax");
            dgvAttendance.Columns.Add("TaxAmount", "Tax Amount");
            dgvAttendance.Columns.Add("EmploymentDate", "Employment Date");

            this.Text = "Salary Report";
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Start Date must be less than or equal to End Date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //_reportForm.SetReportStrategy(new DateRangeReportStrategy(dateTimePicker1.Value, dateTimePicker2.Value));
                //var (textReport, _) = _reportForm.GenerateReport();
                var employees = _reportForm.GetEmployees();

                dgvAttendance.Rows.Clear();
                foreach (var employee in employees)
                {
                    var (_, csvRow, _) = EmployeeProcessor.ProcessEmployee(employee);
                    if (csvRow.HasValue)
                    {
                        var row = csvRow.Value;
                        dgvAttendance.Rows.Add(
                            row.Type,
                            row.Name,
                            row.Detail,
                            $"${row.SalaryAfterTax:F2}",
                            $"${row.TaxAmount:F2}",
                            row.EmploymentDate.ToString("yyyy-MM-dd")
                        );
                    }
                }

                dgvAttendance.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Start Date must be less than or equal to End Date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _reportForm.SetReportStrategy(new DateRangeReportStrategy(dateTimePicker1.Value, dateTimePicker2.Value));
                var (_, filePath) = _reportForm.GenerateReport();

                if (File.Exists(filePath))
                {
                    var result = MessageBox.Show($"CSV file generated at: {filePath}\n\nOpen file location?", "Export Successful", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        Process.Start("explorer.exe", $"/select,\"{filePath}\"");
                    }
                }
                else
                {
                    MessageBox.Show("CSV file was not created.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dgvAttendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }

}
