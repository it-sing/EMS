using System.Data;
using EmployeeManagamentSystem.Util;

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
                GetRoles();
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
                if (cmbFilterByRoles.SelectedValue != null)
                {
                    string selectedRole = cmbFilterByRoles.SelectedValue.ToString();
                    if (string.IsNullOrEmpty(selectedRole) || selectedRole == "All Roles" || selectedRole == "")
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




        private void GetRoles()
        {
            DataTable dtRoles = _userService.GetRoles();

            if (dtRoles != null)
            {
                DataRow dr = dtRoles.NewRow();
                dr["RoleID"] = 01;
                dr["RoleName"] = "All Roles";
                dtRoles.Rows.InsertAt(dr, 0);
            }

            cmbFilterByRoles.DisplayMember = "RoleName";
            cmbFilterByRoles.ValueMember = "RoleName"; // Ensure it passes the role name, not ID
            cmbFilterByRoles.DataSource = dtRoles;
        }


        private void GetUsers(string filterByRole = null)
        {
            try
            {
                DataSet dtUsers = _userService.GetUsers(filterByRole);
                dgvUsers.DataSource = dtUsers.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
