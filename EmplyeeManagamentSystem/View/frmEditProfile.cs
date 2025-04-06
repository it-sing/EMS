using EmployeeManagamentSystem.Util;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

            if (dtUser == null || dtUser.Rows.Count == 0)
            {
                return;
            }

            DataRow dr = dtUser.Rows[0];

            txtEmployeeID.Text = dr["EmployeeID"] != DBNull.Value ? dr["EmployeeID"].ToString() : string.Empty;
            txtFirstname.Text = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : string.Empty;
            txtLastName.Text = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : string.Empty;
            txtEmail.Text = dr["Email"] != DBNull.Value ? dr["Email"].ToString() : string.Empty;
            txtUsername.Text = dr["Username"] != DBNull.Value ? dr["Username"].ToString() : string.Empty;

            dtpDateOfBirth.Value = dr["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(dr["DateOfBirth"]) : DateTime.Now;
            dtpEmployemntDate.Value = dr["EmploymentDate"] != DBNull.Value ? Convert.ToDateTime(dr["EmploymentDate"]) : DateTime.Now;
        }

        //1. Factory Method for Creating User Actions
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                
                    if (!string.IsNullOrEmpty(txtEmployeeID.Text))
                    {
                        _userService.ExecuteUserAction("update",
                            txtFirstname.Text,
                            txtLastName.Text,
                            txtEmail.Text,
                            dtpDateOfBirth.Value,
                            dtpEmployemntDate.Value,
                            currentUserId);
                    }
                    else
                    {
                        _userService.ExecuteUserAction("create",
                            txtFirstname.Text,
                            txtLastName.Text,
                            txtEmail.Text,
                            dtpDateOfBirth.Value,
                            dtpEmployemntDate.Value,
                            currentUserId); 
                    }

                    GetCurrentUser();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
