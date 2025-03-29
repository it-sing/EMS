using System;
using System.Windows.Forms;
using EmployeeManagamentSystem.Service;
using EmployeeManagamentSystem.Util;

namespace EmployeeManagamentSystem
{
    public partial class frmLogin : Form
    {
        private LoginService _loginService;

        public frmLogin()
        {
            InitializeComponent();
            _loginService = new LoginService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                if (_loginService.ValidateUserCredentials(username, password, out int userID, out string role))
                {
                    if (role == "4")
                    {
                        MessageBox.Show("Please wait for admin approval.", " ", MessageBoxButtons.OK);
                    }
                    else
                    {
                        // Save the current user ID and show the manager dashboard
                        UIUtilities.CurrentUserID = userID;
                        UIUtilities.CurrentUserName = username;
                        UIUtilities.CurrentUserRole = role;


                        frmEmployeeSystemManager frmEmployeeSystemManager = new frmEmployeeSystemManager();
                        frmEmployeeSystemManager.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkRegisterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister frmRegister = new frmRegister();
            frmRegister.Show();
            this.Hide();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Set default values
            txtUsername.Text = "admin";
            txtPassword.Text = "admin";
        }
    }
}
