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
            //MessageBox.Show(currentUserId.ToString());
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
            //MessageBox.Show(currentUserId.ToString());
            DataTable dtUser = _userService.GetUserDetails(currentUserId);
            //MessageBox.Show(dtUser.Rows.Count.ToString());

            if (dtUser == null || dtUser.Rows.Count == 0)
            {
                //MessageBox.Show("No user found for the given ID.");
                return;
            }

            DataRow dr = dtUser.Rows[0];

            // Ensure to check if the data is null before setting it
            txtEmployeeID.Text = dr["EmployeeID"] != DBNull.Value ? dr["EmployeeID"].ToString() : string.Empty;
            txtFirstname.Text = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : string.Empty;
            txtLastName.Text = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : string.Empty;
            txtEmail.Text = dr["Email"] != DBNull.Value ? dr["Email"].ToString() : string.Empty;
            txtUsername.Text = dr["Username"] != DBNull.Value ? dr["Username"].ToString() : string.Empty;

            // Date parsing with null check
            dtpDateOfBirth.Value = dr["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(dr["DateOfBirth"]) : DateTime.Now;
            dtpEmployemntDate.Value = dr["EmploymentDate"] != DBNull.Value ? Convert.ToDateTime(dr["EmploymentDate"]) : DateTime.Now;
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
