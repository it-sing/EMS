using EmployeeManagamentSystem.Util;
using System;
using System.Data;
using System.Windows.Forms;

namespace EmployeeManagamentSystem
{
    public partial class frmEditProfile : Form
    {
        private UserService _userService;
        private int currentUserId = UIUtilities.CurrentUserID;

        public frmEditProfile()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void frmEditProfile_Load(object sender, EventArgs e)
        {
            try
            {
                GetCurrentUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetCurrentUser()
        {
            DataTable dtUser = _userService.GetUserDetails(currentUserId);
            if (dtUser.Rows.Count > 0)
            {
                DataRow dr = dtUser.Rows[0];
                txtEmployeeID.Text = dr["EmployeeID"].ToString();
                txtFirstname.Text = dr["FirstName"].ToString();
                txtLastName.Text = dr["LastName"].ToString();
                txtEmail.Text = dr["Email"].ToString();
                txtUsername.Text = dr["Username"].ToString();
                dtpDateOfBirth.Value = Convert.ToDateTime(dr["DateOfBirth"]);
                dtpEmployemntDate.Value = Convert.ToDateTime(dr["EmploymentDate"]);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    if (txtEmployeeID.Text != string.Empty)
                    {
                        SaveEmployeeChanges();
                    }
                    else
                    {
                        CreateEmployee();
                    }
                    GetCurrentUser();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateEmployee()
        {
            bool success = _userService.CreateUser(txtFirstname.Text, txtLastName.Text, txtEmail.Text, dtpDateOfBirth.Value, dtpEmployemntDate.Value, currentUserId);
            if (success)
            {
                MessageBox.Show("Employee Created Successfully");
            }
            else
            {
                MessageBox.Show("Employee Creation Failed");
            }
        }

        private void SaveEmployeeChanges()
        {
            bool success = _userService.SaveUserChanges(currentUserId, txtFirstname.Text, txtLastName.Text, txtEmail.Text, dtpDateOfBirth.Value, dtpEmployemntDate.Value);
            if (success)
            {
                MessageBox.Show("Employee Updated Successfully");
            }
            else
            {
                MessageBox.Show("Employee Update Failed");
            }
        }
    }
}
