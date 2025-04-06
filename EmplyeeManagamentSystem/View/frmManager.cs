using System;
using System.Data;
using System.Windows.Forms;
using EmployeeManagamentSystem.Pattern.Manager_Strategy;
using EmployeeManagamentSystem.Util;

namespace EmployeeManagamentSystem
{
    public partial class frmManager : Form
    {
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;
        private int selectedDepartmentID;
        private IManagerAssignmentStrategy _strategy;

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
                UIUtilities.BindComboBox(cboDepartments, dtDepartments, "DepartmentName", "DepartmentID");
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
                DataTable dt = _departmentService.GetCurrentManager(selectedDepartmentID);

                if (dt.Rows.Count > 0)
                {
                    object currentManager = dt.Rows[0]["CurrentManager"];
                    txtCurrentManager.Text = (currentManager == DBNull.Value || currentManager == null) ? "No Manager" : currentManager.ToString();
                }
                else
                {
                    txtCurrentManager.Text = "No Manager";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboDepartments.SelectedIndex == -1 || cboDepartments.SelectedValue == DBNull.Value)
                {
                    MessageBox.Show("Please select a department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int departmentID = Convert.ToInt32(cboDepartments.SelectedValue);
                int? newManagerID = cboNewManager.SelectedIndex != -1 && cboNewManager.SelectedValue != DBNull.Value
                    ? Convert.ToInt32(cboNewManager.SelectedValue)
                    : (int?)null;

                // Choose strategy dynamically
                _strategy = newManagerID == null ? new RemoveManagerStrategy() : new AssignManagerStrategy();

                // Execute the selected strategy

                if (_strategy.AssignManager(_departmentService, departmentID, newManagerID) > 0)
                {
                    LoadDepartmentCurrentManager();
                    //MessageBox.Show("Manager updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update manager", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
