using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EmployeeManagamentSystem.Util;

namespace EmployeeManagamentSystem
{
    public partial class frmUserManagement : Form
    {
        private readonly UserService _userService;
        private readonly Dictionary<string, string> roleMap;

        public frmUserManagement()
        {
            InitializeComponent();
            errProvider = new ErrorProvider();
            _userService = new UserService();

            roleMap = new Dictionary<string, string>
            {
                { "1", "Admin" },
                { "2", "Manager" },
                { "3", "Employee" }
            };
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            try
            {
                GetRoles();   // Load roles and select All Roles
                GetUsers();   // Show all users by default
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GetRoles()
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

            // ✅ Make it unselected
            cmbFilterByRoles.SelectedIndex = -1;  // <- This keeps it blank
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
                ContextMenuStrip actionMenu = new ContextMenuStrip();

                // Promote option
                if (roleName != "User")
                {
                    ToolStripMenuItem promoteOption = new ToolStripMenuItem("Promote");
                    promoteOption.DropDownItems.AddRange(new ToolStripMenuItem[]
                    {
                        new ToolStripMenuItem("Admin", null, (s, args) => PromoteUser(userID, "1")),
                        new ToolStripMenuItem("Manager", null, (s, args) => PromoteUser(userID, "2")),
                        new ToolStripMenuItem("Employee", null, (s, args) => PromoteUser(userID, "3"))
                    });
                    actionMenu.Items.Add(promoteOption);
                }

                // Delete option
                if (roleName != "Admin")
                {
                    ToolStripMenuItem deleteOption = new ToolStripMenuItem("Delete");
                    deleteOption.Click += (s, args) => DeleteUser(userID, username);
                    actionMenu.Items.Add(deleteOption);
                }

                // Approve option
                if (roleName == "User")
                {
                    ToolStripMenuItem approveOption = new ToolStripMenuItem("Approve");
                    approveOption.Click += (s, args) => ApproveUser(userID);
                    actionMenu.Items.Add(approveOption);
                }

                actionMenu.Show(Cursor.Position);
            }
        }

        private void PromoteUser(int userID, string newRole)
        {
            try
            {
                _userService.PromoteUser(userID, newRole);

                // Refresh filtered user list automatically
                string selectedRole = cmbFilterByRoles.SelectedValue?.ToString();
                GetUsers(string.IsNullOrEmpty(selectedRole) || selectedRole == "All Roles" ? null : selectedRole);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error promoting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteUser(int userID, string username)
        {
            try
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to delete user '{username}'?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _userService.DeleteUser(userID);

                    // Refresh filtered user list automatically
                    string selectedRole = cmbFilterByRoles.SelectedValue?.ToString();
                    GetUsers(string.IsNullOrEmpty(selectedRole) || selectedRole == "All Roles" ? null : selectedRole);
                }
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

                // Refresh filtered user list automatically
                string selectedRole = cmbFilterByRoles.SelectedValue?.ToString();
                GetUsers(string.IsNullOrEmpty(selectedRole) || selectedRole == "All Roles" ? null : selectedRole);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error approving user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
