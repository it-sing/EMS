
using System.Data;

namespace EmployeeManagamentSystem
{
    public partial class frmUserManagement : Form
    {
        private readonly UserService _userService;

        public frmUserManagement()
        {
            InitializeComponent();
            errProvider = new ErrorProvider();
            _userService = new UserService();
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
                ContextMenuStrip actionMenu = new ContextMenuStrip();

                // Promote option
                if (dgvUsers.Rows[e.RowIndex].Cells["RoleName"].Value.ToString() != "User")
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
                if (dgvUsers.Rows[e.RowIndex].Cells["RoleName"].Value.ToString() != "Admin")
                {
                    ToolStripMenuItem deleteOption = new ToolStripMenuItem("Delete");
                    deleteOption.Click += (s, args) => DeleteUser(userID, username);
                    actionMenu.Items.Add(deleteOption);
                }

                // Approve option
                if (dgvUsers.Rows[e.RowIndex].Cells["RoleName"].Value.ToString() == "User")
                {
                    ToolStripMenuItem approveOption = new ToolStripMenuItem("Approve");
                    approveOption.Click += (s, args) => ApproveUser(userID, username);
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
                GetUsers(cmbFilterByRoles.SelectedItem?.ToString());
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
                    GetUsers(cmbFilterByRoles.SelectedItem?.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApproveUser(int userID, string username)
        {
            try
            {
                _userService.ApproveUser(userID);
                GetUsers(cmbFilterByRoles.SelectedItem?.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error approving user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}