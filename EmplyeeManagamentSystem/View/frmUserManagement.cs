using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EmployeeManagamentSystem.Pattern;
using EmployeeManagamentSystem.Pattern.User_Proxy;
using EmployeeManagamentSystem.Service;
using EmployeeManagamentSystem.Util;

namespace EmployeeManagamentSystem
{
    public partial class frmUserManagement : Form
    {
        private readonly IUserService _userService;
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;
        private readonly Dictionary<string, string> roleMap;

        public frmUserManagement()
        {
            InitializeComponent();
            errProvider = new ErrorProvider();

            // Use the proxy instead of direct service
            _userService = new UserServiceProxy();
            _employeeService = new EmployeeService();
            _departmentService = new DepartmentService();

            roleMap = new Dictionary<string, string>
            {
                { "1", "Admin" },
                { "2", "HR" },
                { "3", "Employee" },
                { "4", "Account" }
            };
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            try
            {
                GetRoles();
                GetUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFilterByRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbFilterByRoles.SelectedValue != null)
                {
                    string selectedRole = cmbFilterByRoles.SelectedValue.ToString();
                    if (string.IsNullOrEmpty(selectedRole) || selectedRole == "All Roles")
                    {
                        GetUsers(null);
                    }
                    else
                    {
                        GetUsers(selectedRole);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetUsers(string filterByRole = null)
        {
            try
            {
                DataSet dtUsers = _userService.GetUsers(filterByRole);
                dgvUsers.DataSource = dtUsers.Tables[0];

                if (!dgvUsers.Columns.Contains("Actions"))
                {
                    AddActionButtonColumn();
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handle specifically unauthorized access exceptions
                MessageBox.Show(ex.Message, "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetRoles()
        {
            try
            {
                DataTable dtRoles = _userService.GetRoles();

                if (dtRoles != null)
                {
                    // Optional: if you want to still show "All Roles" for later usage
                    DataRow dr = dtRoles.NewRow();
                    dr["RoleID"] = 0;
                    dr["RoleName"] = "All Roles";
                    dtRoles.Rows.InsertAt(dr, 0);
                }

                cmbFilterByRoles.DisplayMember = "RoleName";
                cmbFilterByRoles.ValueMember = "RoleName";
                cmbFilterByRoles.DataSource = dtRoles;

                // Make it unselected
                cmbFilterByRoles.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading Roles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddActionButtonColumn()
        {
            DataGridViewButtonColumn actionButtonColumn = new DataGridViewButtonColumn();
            actionButtonColumn.Name = "Actions";
            actionButtonColumn.HeaderText = "Actions";
            actionButtonColumn.Text = "Action";
            actionButtonColumn.UseColumnTextForButtonValue = true;
            dgvUsers.Columns.Add(actionButtonColumn);
            dgvUsers.CellClick += DgvUsers_CellClick;
        }

        private void DgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUsers.Columns[e.ColumnIndex].Name == "Actions")
            {
                int userID = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["UserID"].Value);
                string username = dgvUsers.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                string roleName = dgvUsers.Rows[e.RowIndex].Cells["RoleName"].Value.ToString();
                int? employeeId = null;

                if (dgvUsers.Rows[e.RowIndex].Cells["EmployeeID"].Value != DBNull.Value)
                {
                    employeeId = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["EmployeeID"].Value);
                }

                ContextMenuStrip actionMenu = new ContextMenuStrip();

                // Promote option
                if (roleName != "Guest")
                {
                    ToolStripMenuItem promoteOption = new ToolStripMenuItem("Promote");
                    promoteOption.DropDownItems.AddRange(new ToolStripMenuItem[]
                    {
                        new ToolStripMenuItem(roleMap["1"], null, (s, args) => PromoteUser(userID, "1")),
                        new ToolStripMenuItem(roleMap["2"], null, (s, args) => PromoteUser(userID, "2")),
                        new ToolStripMenuItem(roleMap["3"], null, (s, args) => PromoteUser(userID, "3")),
                        new ToolStripMenuItem(roleMap["4"], null, (s, args) => PromoteUser(userID, "4"))
                    });
                    actionMenu.Items.Add(promoteOption);
                }

                // Delete option
                if (roleName != "Admin")
                {
                    ToolStripMenuItem deleteOption = new ToolStripMenuItem("Delete");
                    deleteOption.Click += (s, args) =>
                    {
                        int empIdToDelete = employeeId ?? -1;
                        DeleteUser(userID, username, empIdToDelete);
                    };

                    actionMenu.Items.Add(deleteOption);
                }

                // Approve option
                if (roleName == "Guest")
                {
                    ToolStripMenuItem approveOption = new ToolStripMenuItem("Approve");
                    approveOption.Click += (s, args) => ApproveUser(userID);
                    actionMenu.Items.Add(approveOption);
                }

                // View Log option (new functionality enabled by the proxy)
                //ToolStripMenuItem viewLogOption = new ToolStripMenuItem("View Action Log");
                //viewLogOption.Click += (s, args) => ViewActionLog(userID);
                //actionMenu.Items.Add(viewLogOption);

                actionMenu.Show(Cursor.Position);
            }
        }

        private void PromoteUser(int userID, string newRole)
        {
            try
            {
                string roleName = roleMap.ContainsKey(newRole) ? roleMap[newRole] : newRole;
                _userService.PromoteUser(userID, newRole);

                // Refresh filtered user list automatically
                string selectedRole = cmbFilterByRoles.SelectedValue?.ToString();
                GetUsers(string.IsNullOrEmpty(selectedRole) || selectedRole == "All Roles" ? null : selectedRole);

            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error promoting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteUser(int userID, string username, int employeeId)
        {
            try
            {
                // First check if employee is a department manager
                if (_departmentService.IsEmployeeManager(employeeId))
                {
                    MessageBox.Show("Cannot delete this employee. They are assigned as a department manager.",
                        "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show($"Are you sure you want to delete user '{username}'?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool deleted = _userService.DeleteUser(userID);

                    if (deleted)
                    {
                        // Only attempt to delete employee record if user deletion was successful
                        if (employeeId > 0)
                        {
                            _employeeService.DeleteEmployee(employeeId);
                        }

                        //MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh filtered user list automatically
                        string selectedRole = cmbFilterByRoles.SelectedValue?.ToString();
                        GetUsers(string.IsNullOrEmpty(selectedRole) || selectedRole == "All Roles" ? null : selectedRole);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApproveUser(int userID)
        {
            try
            {
                _userService.ApproveUser(userID);
                //MessageBox.Show("User approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh filtered user list automatically
                string selectedRole = cmbFilterByRoles.SelectedValue?.ToString();
                GetUsers(string.IsNullOrEmpty(selectedRole) || selectedRole == "All Roles" ? null : selectedRole);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error approving user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}