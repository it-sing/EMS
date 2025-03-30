using EmployeeManagamentSystem.Pattern;
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
                LoadViewDepartments();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvDepartments.Rows.Count) return; 

                string columnName = dgvDepartments.Columns[e.ColumnIndex].Name;

                if (columnName == "Delete")
                {
                    HandleDeleteDepartment(e.RowIndex);
                }
                else
                {
                    LoadDepartmentToForm(e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading department details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDepartmentToForm(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dgvDepartments.Rows.Count)
            {
                DataGridViewRow row = dgvDepartments.Rows[rowIndex];

                txtDepartmentID.Text = row.Cells["DepartmentId"].Value?.ToString();
                txtDepartmentName.Text = row.Cells["DepartmentName"].Value?.ToString();
                txtDescription.Text = row.Cells["Description"].Value?.ToString();
            }
        }

        private void HandleDeleteDepartment(int rowIndex)
        {
            int departmentId = Convert.ToInt32(dgvDepartments.Rows[rowIndex].Cells["DepartmentId"].Value);
            string departmentName = dgvDepartments.Rows[rowIndex].Cells["DepartmentName"].Value?.ToString();

            try
            {
                if (_departmentService.IsDepartmentAssigned(departmentId))
                {
                    MessageBox.Show("Cannot delete this department. The manager is assigned.", "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool success = _departmentService.DeleteDepartment(departmentId);

                if (success)
                {
                    LoadViewDepartments();
                    ClearControls(grpDepartments.Controls);
                    currentDepartmentId = 0;

                    // Prevent invalid row access after deletion
                    if (dgvDepartments.Rows.Count > 0)
                    {
                        dgvDepartments.ClearSelection();
                        dgvDepartments.CurrentCell = dgvDepartments.Rows[0].Cells[0]; // Select first row safely
                    }
                    else
                    {
                        ClearControls(grpDepartments.Controls); // Clear UI fields if no rows remain
                    }
                }
                else
                {
                    MessageBox.Show("Error deleting department. Please try again.", "Deletion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Deletion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AddDeleteButton()
        {
            if (!dgvDepartments.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.HeaderText = "Action";
                btnDelete.Name = "Delete";
                btnDelete.Text = "Delete";
                btnDelete.UseColumnTextForButtonValue = true;
                dgvDepartments.Columns.Add(btnDelete);
            }
        }

        private void LoadViewDepartments()
        {
            try
            {
                toolStripStatusLabel1.Text = "";

                DataTable dtDepartments = _departmentService.GetAllDepartments();
                dgvDepartments.DataSource = dtDepartments;

                if (!dgvDepartments.Columns.Contains("Delete"))
                {
                    AddDeleteButton();
                }
              
                dgvDepartments.Columns[0].HeaderText = "ID";
                dgvDepartments.AutoResizeColumns();
                toolStripStatusLabel1.Text = "Total Department: " + dgvDepartments.Rows.Count;

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
                ClearControls(grpDepartments.Controls);
                prgBar.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Helper Methods

        private void CreateDepartment()
        {
            string departmentName = txtDepartmentName.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(departmentName))
            {
                MessageBox.Show("Department name cannot be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_departmentService.IsDepartmentName(departmentName))
            {
                MessageBox.Show("Department name already exists. Please choose a different name.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = _departmentService.CreateDepartment(departmentName, description);

            if (success)
            {
                //MessageBox.Show("Department created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadViewDepartments(); // Refresh department list
                ClearControls(grpDepartments.Controls);
            }
            else
            {
                MessageBox.Show("Department creation failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveDepartmentChanges()
        {
            int departmentId = Convert.ToInt32(txtDepartmentID.Text);
            string departmentName = txtDepartmentName.Text;
            string description = txtDescription.Text;

            if (string.IsNullOrWhiteSpace(departmentName))
            {
                MessageBox.Show("Department name cannot be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_departmentService.IsDepartmentName(departmentName))
            {
                MessageBox.Show("Department name already exists. Please choose a different name.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = _departmentService.SaveDepartmentChanges(departmentId, departmentName, description);

            if (success)
            {       
                LoadViewDepartments(); // Refresh department list
                ClearControls(grpDepartments.Controls);
            }
            else
            {
                MessageBox.Show("Department update failed.");
            }
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
