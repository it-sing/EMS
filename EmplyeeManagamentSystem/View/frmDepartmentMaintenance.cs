using EmployeeManagamentSystem.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace EmployeeManagamentSystem
{
    public partial class frmDepartmentMaintenance : Form
    {
        private readonly DepartmentService _departmentService;
        private int currentDepartmentId = 0;
        private int firstDepartmentId = 0;
        private int lastDepartmentId = 0;
        private int? previousDepartmentId;
        private int? nextDepartmentId;

        public frmDepartmentMaintenance()
        {
            InitializeComponent();
            _departmentService = new DepartmentService();
        }

        #region Event Listeners

        private void frmDepartmentMaintenance_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFirstDepartment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Adding a new Department";
            toolStripStatusLabel2.Text = "";

            ClearControls(grpDepartments.Controls);

            btnSave.Text = "Create";

            btnAdd.Enabled = false;
            btnDelete.Enabled = false;

            NavigationState(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this Department?", "Delete Department", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool success = _departmentService.DeleteDepartment(currentDepartmentId);
                    if (success)
                    {
                        MessageBox.Show("Department deleted successfully.");
                        LoadFirstDepartment();
                    }
                    else
                    {
                        MessageBox.Show("Department deletion failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ProgressBar();

                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    if (txtDepartmentID.Text != string.Empty)
                    {
                        SaveDepartmentChanges();
                    }
                    else
                    {
                        CreateDepartment();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDepartmentDetails();
                btnSave.Text = "Save";
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                toolStripStatusLabel2.Text = string.Empty;
                prgBar.Value = 0;
                NavigationState(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Helper Methods

        private void LoadFirstDepartment()
        {
            currentDepartmentId = _departmentService.GetFirstDepartmentId();
            LoadDepartmentDetails();
        }

        private void LoadDepartmentDetails()
        {
            var departmentData = _departmentService.GetDepartmentDetails(currentDepartmentId);
            txtDepartmentID.Text = departmentData.Rows[0]["DepartmentId"].ToString();
            txtDepartmentName.Text = departmentData.Rows[0]["DepartmentName"].ToString();
            txtDescription.Text = departmentData.Rows[0]["Description"].ToString();

            var navigationInfo = _departmentService.GetNavigationInfo(currentDepartmentId);
            firstDepartmentId = Convert.ToInt32(navigationInfo.Rows[0]["FirstDepartmentId"]);
            previousDepartmentId = navigationInfo.Rows[0]["PreviousDepartmentId"] != DBNull.Value ? Convert.ToInt32(navigationInfo.Rows[0]["PreviousDepartmentId"]) : (int?)null;
            nextDepartmentId = navigationInfo.Rows[0]["NextDepartmentId"] != DBNull.Value ? Convert.ToInt32(navigationInfo.Rows[0]["NextDepartmentId"]) : (int?)null;
            lastDepartmentId = Convert.ToInt32(navigationInfo.Rows[0]["LastDepartmentId"]);

            toolStripStatusLabel1.Text = $"Displaying Department {currentDepartmentId}";
            NextPreviousButtonManagement();
        }

        private void CreateDepartment()
        {
            string departmentName = txtDepartmentName.Text;
            string description = txtDescription.Text;
            bool success = _departmentService.CreateDepartment(departmentName, description);

            if (success)
            {
                MessageBox.Show("Department created successfully.");
                LoadFirstDepartment();
            }
            else
            {
                MessageBox.Show("Department creation failed.");
            }
        }

        private void SaveDepartmentChanges()
        {
            string departmentName = txtDepartmentName.Text;
            string description = txtDescription.Text;
            bool success = _departmentService.SaveDepartmentChanges(currentDepartmentId, departmentName, description);

            if (success)
            {
                MessageBox.Show("Department updated successfully.");
                LoadFirstDepartment();
            }
            else
            {
                MessageBox.Show("Department update failed.");
            }
        }

        private void NavigationState(bool enableState)
        {
            // Enable or disable navigation buttons (not implemented in this example)
        }

        private void NextPreviousButtonManagement()
        {
            // Enable or disable previous/next buttons (not implemented in this example)
        }

        private void ProgressBar()
        {
            this.toolStripStatusLabel3.Text = "Processing...";
            prgBar.Value = 0;
            this.statusStrip1.Refresh();

            while (prgBar.Value < prgBar.Maximum)
            {
                Thread.Sleep(10);
                prgBar.Value += 1;
            }

            prgBar.Value = 100;
            this.toolStripStatusLabel3.Text = "Processed";
        }

        private void ClearControls(Control.ControlCollection controls)
        {
            foreach (Control ctl in controls)
            {
                switch (ctl)
                {
                    case TextBox txt:
                        txt.Clear();
                        break;
                    case CheckBox chk:
                        chk.Checked = false;
                        break;
                    case GroupBox gB:
                        ClearControls(gB.Controls);
                        break;
                }
            }
        }

        #endregion
    }
}
