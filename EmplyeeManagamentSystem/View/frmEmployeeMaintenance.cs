using System.Data;

namespace EmployeeManagamentSystem
{
    public partial class frmEmployeeMaintenance : Form
    {
        private readonly EmployeeService _employeeService;
        private int currentEmployeeId;

        public frmEmployeeMaintenance()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
        }

        private void frmEmployeeMaintenance_Load(object sender, EventArgs e)
        {
            LoadFirstEmployee();
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
