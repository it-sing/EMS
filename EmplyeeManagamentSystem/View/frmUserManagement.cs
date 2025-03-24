using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DBProgrammingDemo9;
using EmployeeManagamentSystem.Pattern;
namespace EmployeeManagamentSystem
{
    public partial class frmUserManagement : Form
    {

        public frmUserManagement()
        {
            InitializeComponent();
            errProvider = new ErrorProvider();
        }
        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            try
            {
                GetUsers();
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
                string selectedRole = cmbFilterByRoles.SelectedItem?.ToString();
                GetUsers(selectedRole);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetUsers(string filterByRole = null)
        {
            string sql = "SELECT U.UserID, U.Username, U.Email, R.RoleName, U.CreatedAt " +
                         "FROM Users U " +
                         "JOIN Roles R ON U.Role = R.RoleID " +
                         "WHERE U.IsDeleted = 0";
            if (!string.IsNullOrEmpty(filterByRole))
            {
                sql += " AND R.RoleName = @RoleName";
            }
            try
            {
                var parameters = new Dictionary<string, object>();
                if (!string.IsNullOrEmpty(filterByRole))
                {
                    parameters.Add("@RoleName", filterByRole);
                }

                DataSet dtUsers = DataAccess.GetBy(sql, parameters);

                //if (dtUsers.Tables.Count == 0 || dtUsers.Tables[0].Rows.Count == 0)
                //{
                //    MessageBox.Show("No users found in the database. Please add users first.");
                //    return;
                //}
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

                // Show a context menu with options
                ContextMenuStrip actionMenu = new ContextMenuStrip();

                // Promote option
                if (dgvUsers.Rows[e.RowIndex].Cells["RoleName"].Value.ToString() != "User")
                {
                    ToolStripMenuItem promoteOption = new ToolStripMenuItem("Promote");

                    // Add sub-items for each promotion option
                    ToolStripMenuItem promoteToAdmin = new ToolStripMenuItem("Admin");
                    promoteToAdmin.Click += (s, args) => { PromoteUser(userID, username, "1"); };
                    promoteOption.DropDownItems.Add(promoteToAdmin);

                    ToolStripMenuItem promoteToManager = new ToolStripMenuItem("Manager");
                    promoteToManager.Click += (s, args) => { PromoteUser(userID, username, "2"); };
                    promoteOption.DropDownItems.Add(promoteToManager);

                    ToolStripMenuItem promoteToEmployee = new ToolStripMenuItem("Employee");
                    promoteToEmployee.Click += (s, args) => { PromoteUser(userID, username, "3"); };
                    promoteOption.DropDownItems.Add(promoteToEmployee);

                    actionMenu.Items.Add(promoteOption);
                }

                // Delete option
                if (dgvUsers.Rows[e.RowIndex].Cells["RoleName"].Value.ToString() != "Admin")
                {
                    ToolStripMenuItem deleteOption = new ToolStripMenuItem("Delete");
                    deleteOption.Click += (s, args) => { DeleteUser(userID, username); };
                    actionMenu.Items.Add(deleteOption);
                }

                // Approve option
                if(dgvUsers.Rows[e.RowIndex].Cells["RoleName"].Value.ToString() == "User")
                {
                    ToolStripMenuItem approveOption = new ToolStripMenuItem("Approve");
                    approveOption.Click += (s, args) => { ApproveUser(userID, username); };
                    actionMenu.Items.Add(approveOption);
                }

                // Show the context menu at the position of the mouse
                actionMenu.Show(Cursor.Position);
            }
        }

        private void PromoteUser(int userID, string username, string newRole)
        {
            try
            {
                string sql = "UPDATE Users SET Role = @RoleID WHERE UserID = @UserID";
                var parameters = new Dictionary<string, object>
                {
                    { "@RoleID", newRole }, 
                    { "@UserID", userID }
                };

                int rowsAffected = DataAccess.UpdateData(sql, parameters);

                if (rowsAffected > 0)
                {
                    // Refresh the grid
                    GetUsers(cmbFilterByRoles.SelectedItem?.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteUser(int userID, string username)
        {
            try
            {
                // Confirm deletion
                DialogResult result = MessageBox.Show($"Are you sure you want to delete user '{username}'?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string sql = "UPDATE Users SET IsDeleted = 1 WHERE UserID = @UserID";
                    var parameters = new Dictionary<string, object>
                    {
                        { "@UserID", userID }
                    };

                    int rowsAffected = DataAccess.UpdateData(sql, parameters);

                    if (rowsAffected > 0)
                    {

                        // Refresh the grid
                        GetUsers(cmbFilterByRoles.SelectedItem?.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete user.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting user: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApproveUser(int userID, string username)
        {
            try
            {
                string sql = "UPDATE Users SET Role = 3 WHERE UserID = @UserID";
                var parameters = new Dictionary<string, object>
                 {
                     { "@UserID", userID }
                 };

                int rowsAffected = DataConnection.UpdateData(sql, parameters);

                if (rowsAffected > 0)
                {    
                    // Refresh the grid
                    GetUsers(cmbFilterByRoles.SelectedItem?.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error approving user: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}