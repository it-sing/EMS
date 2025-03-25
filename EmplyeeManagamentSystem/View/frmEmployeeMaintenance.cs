using System.Data;
using EmployeeManagamentSystem.Util;

namespace EmployeeManagamentSystem
{
    public partial class frmEmployeeMaintenance : Form
    {
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;
        private int currentEmployeeId;

        public frmEmployeeMaintenance()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _departmentService = new DepartmentService();
        }
        private void frmEmployeeMaintenance_Load(object sender, EventArgs e)
        {
            LoadFirstEmployee();
            LoadDepartments();
            LoadViewEmployees();
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
        private void LoadViewEmployees()
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

        private void LoadFirstEmployee()
        {
            DataRow employee = _employeeService.GetEmployeeById(currentEmployeeId);
            if (employee != null)
            {
                // Populate form fields with employee data
                txtEmployeeID.Text = employee["EmployeeId"].ToString();
                txtFirstname.Text = employee["FirstName"].ToString();
                txtLastName.Text = employee["LastName"].ToString();
                txtEmail.Text = employee["Email"].ToString();
                dtpDateOfBirth.Value = (DateTime)employee["DateOfBirth"];
                dtpEmployemntDate.Value = (DateTime)employee["EmploymentDate"];
                cboDepartments.SelectedValue = employee["DepartmentID"];
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstname.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            DateTime dob = dtpDateOfBirth.Value;
            DateTime employmentDate = dtpEmployemntDate.Value;
            int departmentId = (int)cboDepartments.SelectedValue;

            //if (txtEmployeeID.Text != string.Empty)
            //{
            //    // Update existing employee
            //    bool success = _employeeService.UpdateEmployee(currentEmployeeId, firstName, lastName, email, dob, employmentDate, departmentId);
            //    if (success)
            //        MessageBox.Show("Employee updated successfully!");
            //}
            //else
            //{
            //    // Create new employee
            //    bool success = _employeeService.CreateEmployee(firstName, lastName, email, dob, employmentDate, departmentId);
            //    if (success)
            //        MessageBox.Show("Employee created successfully!");
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this Employee?", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (result == DialogResult.Yes)
            //{
            //    //bool success = _employeeService.DeleteEmployee(currentEmployeeId);
            //    if (success)
            //        MessageBox.Show("Employee deleted successfully!");
            //}
        }
    }
}
