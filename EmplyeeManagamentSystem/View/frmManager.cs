using EmployeeManagamentSystem.Util;
using EmployeeManagamentSystem;
using System.Data;

namespace EmployeeManagamentSystem
{
    public partial class frmManager : Form
    {
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;
        private int selectedDepartmentID;

        public frmManager()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _departmentService = new DepartmentService();
        }

        private void frmManager_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            LoadDepartments();
        }

        private void LoadEmployees()
        {
            try
            {
                DataTable dtEmployees = _employeeService.GetEmployees();
                UIUtilities.BindComboBox(cboNewManager, dtEmployees, "EmployeeName", "EmployeeID");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDepartments()
        {
            try
            {
                DataTable dtDepartments = _departmentService.GetDepartments();
                if (dtDepartments.Rows.Count > 0)
                    UIUtilities.BindComboBox(cboDepartments, dtDepartments, "DepartmentName", "DepartmentID");
                else
                    MessageBox.Show("No department found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDepartmentCurrentManager()
        {
            try
            {
                // Fetch current manager data for the selected department
                DataTable dt = _departmentService.GetCurrentManager(selectedDepartmentID);

                // Check if any data was returned
                if (dt.Rows.Count > 0)
                {
                    // Check if "CurrentManager" column has a value (is not DBNull)
                    var currentManager = dt.Rows[0]["CurrentManager"];
                    txtCurrentManager.Text = currentManager != DBNull.Value ? currentManager.ToString() : "No Manager";
                }
                else
                {
                    // No department manager information found, display "No Manager"
                    txtCurrentManager.Text = "No Manager";
                }
            }
            catch (Exception ex)
            {
                // Display any exceptions as an error message
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Check for valid department selection
                if (cboDepartments.SelectedIndex == -1 || cboDepartments.SelectedValue == DBNull.Value)
                {
                    MessageBox.Show("Please select a department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int departmentID = Convert.ToInt32(cboDepartments.SelectedValue);
                int? newManagerID = null;  // Default to null

                // Check if a manager is selected and assign the ID
                if (cboNewManager.SelectedIndex != -1 && cboNewManager.SelectedValue != DBNull.Value)
                {
                    newManagerID = Convert.ToInt32(cboNewManager.SelectedValue);
                }

                // Call the service to update the manager
                if (_departmentService.AssignManager(departmentID, newManagerID))
                {
                    LoadDepartmentCurrentManager();  // Reload the department's current manager
                }
                //else
                //{
                //    MessageBox.Show("Failed to update manager", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void cboDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboDepartments.SelectedIndex != -1 && cboDepartments.SelectedValue != DBNull.Value)
                {
                    selectedDepartmentID = Convert.ToInt32(cboDepartments.SelectedValue);
                    LoadDepartmentCurrentManager();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


}
