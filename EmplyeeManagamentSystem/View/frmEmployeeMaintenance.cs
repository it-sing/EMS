using System.Data;
using System.Windows.Forms;
using EmployeeManagamentSystem.Util;

namespace EmployeeManagamentSystem
{
    public partial class frmEmployeeMaintenance : Form
    {
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;
        private int currentEmployeeId;
        private readonly DepartmentRepository departmentRepository = new DepartmentRepository();

        public frmEmployeeMaintenance()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _departmentService = new DepartmentService();

        }
        private void frmEmployeeMaintenance_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            LoadViewEmployees();
            LoadDepartment();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if valid row and column clicked
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dgvEmployees.Columns[e.ColumnIndex].Name;

                if (columnName == "Delete")
                {
                    HandleDeleteEmployee(e.RowIndex);
                }
                else
                {
                    LoadEmployeeToForm(e.RowIndex);
                }
            }
        }
        private void LoadEmployeeToForm(int rowIndex)
        {
            DataGridViewRow row = dgvEmployees.Rows[rowIndex];
            txtEmployeeID.Text = row.Cells["EmployeeID"].Value?.ToString();
            txtFirstname.Text = row.Cells["FirstName"].Value?.ToString();
            txtLastName.Text = row.Cells["LastName"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            dtpDateOfBirth.Text = row.Cells["DateOfBirth"].Value?.ToString();
            dtpEmployemntDate.Text = row.Cells["EmploymentDate"].Value?.ToString();
            cboDepartments.Text = row.Cells["DepartmentName"].Value?.ToString();
        }

        private void HandleDeleteEmployee(int rowIndex)
        {
            int employeeId = Convert.ToInt32(dgvEmployees.Rows[rowIndex].Cells["EmployeeID"].Value);
            string employeeName = dgvEmployees.Rows[rowIndex].Cells["FirstName"].Value?.ToString();

            DialogResult result = MessageBox.Show($"Are you sure you want to delete {employeeName}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (_departmentService.IsEmployeeManager(employeeId))
                {
                    MessageBox.Show("Cannot delete this employee. They are assigned as a department manager.", "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int isDeleted = _employeeService.DeleteEmployee(employeeId);
                if (isDeleted > 0)
                {
                    //MessageBox.Show("Employee deleted successfully.");
                    LoadViewEmployees(); // Refresh
                }
                else
                {
                    MessageBox.Show("Error deleting employee.");
                }
            }
        }


        private void AddDeleteButton()
        {
            if (!dgvEmployees.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.HeaderText = "Action";
                btnDelete.Name = "Delete";
                btnDelete.Text = "Delete";
                btnDelete.UseColumnTextForButtonValue = true;
                dgvEmployees.Columns.Add(btnDelete);
            }
        }



        // for filtering employees by department
        private void LoadDepartments()
        {
            DataTable dtDepartments = _departmentService.Departments;
            // Insert a new row at the select index 1 that says "All Departments"
            DataRow dr = dtDepartments.NewRow();
            dr["DepartmentID"] = 0;
            dr["DepartmentName"] = "All Departments";
            dtDepartments.Rows.InsertAt(dr, 0);
            UIUtilities.BindComboBox(cboDepartmentFillter, dtDepartments, "DepartmentName", "DepartmentID");

        }

        // for update employee
        private void LoadDepartment()
        {
            DataTable dtDepartments = _departmentService.Departments;
            UIUtilities.BindComboBox(cboDepartments, dtDepartments, "DepartmentName", "DepartmentID");

        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                toolStripStatusLabel2.Text = "";

                if (cboDepartmentFillter.SelectedIndex == -1 || cboDepartmentFillter.SelectedValue == DBNull.Value)
                {
                    return;
                }

                int departmentId = Convert.ToInt32(cboDepartmentFillter.SelectedValue);
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
        private void LoadViewEmployees()
        {
            try
            {
                toolStripStatusLabel1.Text = "";
                toolStripStatusLabel2.Text = "";
                LoadDepartments();
                DataTable dtEmployees = _employeeService.Employees;
                dgvEmployees.DataSource = dtEmployees;

                if (!dgvEmployees.Columns.Contains("Delete"))
                {
                    AddDeleteButton();
                }

                dgvEmployees.Columns[0].HeaderText = "Employee ID";
                dgvEmployees.AutoResizeColumns();
                toolStripStatusLabel1.Text = "Total Employees: " + dtEmployees.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtEmployeeID.Text = "";
            txtFirstname.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            dtpDateOfBirth.Value = DateTime.Now;
            dtpEmployemntDate.Value = DateTime.Now;
            cboDepartments.SelectedIndex = 0;
        }

        // for update employee
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeID.Text))
            {
                MessageBox.Show("Please select an employee to update.");
                return;
            }

            int employeeId = int.Parse(txtEmployeeID.Text);
            string firstName = txtFirstname.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            DateTime dob = dtpDateOfBirth.Value;
            DateTime employmentDate = dtpEmployemntDate.Value;

            // Fetch the selected department ID
            if (cboDepartments.SelectedValue == null)
            {
                MessageBox.Show("Please select a department.");
                return;
            }

            int departmentId;
            if (!int.TryParse(cboDepartments.SelectedValue.ToString(), out departmentId))
            {
                MessageBox.Show("Invalid department selected.");
                return;
            }

            // Get the department name for display (optional)
            string departmentName = cboDepartments.Text;

            int isUpdated = _employeeService.UpdateEmployee(employeeId, firstName, lastName, email, dob, employmentDate, departmentId);

            if (isUpdated > 0)
            {
                MessageBox.Show("Employee updated successfully.");
                btnCancel_Click(sender, e);
                LoadViewEmployees();
            }
            else
            {
                MessageBox.Show("Error while updating employee.");
            }
        }

    }
}