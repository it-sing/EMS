using EmployeeManagamentSystem.Util;
using System;
using System.Data;
using System.Windows.Forms;

namespace EmployeeManagamentSystem
{
    public partial class frmViewEmployees : Form
    {
        private EmployeeService _employeeService;
        private DepartmentService _departmentService;

        public frmViewEmployees()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _departmentService = new DepartmentService();
        }

        private void LoadDepartments()
        {
            DataTable dtDepartments = _departmentService.Departments;
            // Insert a new row at the select index 1 that says "All Departments"
            DataRow dr = dtDepartments.NewRow();
            dr["DepartmentID"] = 0;
            dr["DepartmentName"] = "All Departments";
            dtDepartments.Rows.InsertAt(dr, 0);
            UIUtilities.BindComboBox(cboDepartment, dtDepartments, "DepartmentName", "DepartmentID");
        }

        private void frmViewEmployees_Load(object sender, EventArgs e)
        {
            try
            {
                toolStripStatusLabel1.Text = "";
                toolStripStatusLabel2.Text = "";
                LoadDepartments();

                DataTable dtEmployees = _employeeService.Employees;
                dgvEmployees.DataSource = dtEmployees;

                dgvEmployees.Columns[0].HeaderText = "Employee ID";
                dgvEmployees.AutoResizeColumns();

                toolStripStatusLabel1.Text = "Total Employees: " + dtEmployees.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                toolStripStatusLabel2.Text = "";

                if (cboDepartment.SelectedIndex == -1 || cboDepartment.SelectedValue == DBNull.Value)
                {
                    return;
                }

                int departmentId = Convert.ToInt32(cboDepartment.SelectedValue);
                DataTable dtEmployees = departmentId == 0
                    ? _employeeService.Employees
                    : _employeeService.GetEmployeesByDepartment(departmentId);

                dgvEmployees.DataSource = dtEmployees;

                dgvEmployees.Columns[0].HeaderText = "Employee ID";
                dgvEmployees.AutoResizeColumns();

                toolStripStatusLabel1.Text = "Total Employees: " + dtEmployees.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    return;
                }

                toolStripStatusLabel2.Text = "Record " + (e.RowIndex + 1) + " of " + dgvEmployees.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
