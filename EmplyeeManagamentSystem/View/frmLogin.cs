using System;
using System.Windows.Forms;
using EmployeeManagamentSystem.Pattern.Login;
using EmployeeManagamentSystem.Service;
using EmployeeManagamentSystem.Util;

namespace EmployeeManagamentSystem
{
    public partial class frmLogin : Form
    {
        private readonly LoginFacade _loginFacade;

        public frmLogin()
        {
            InitializeComponent();
            _loginFacade = new LoginFacade(LoginService.Instance);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (_loginFacade.ProcessLogin(username, password, out int userId, out string role, out string message))
            {
                frmEmployeeSystemManager frm = (frmEmployeeSystemManager)LoginFormFactory.CreateEmployeeSystemManagerForm();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(message,
                    role == "5" ? " " : "Login Failed",
                    MessageBoxButtons.OK,
                    role == "5" ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
        }

        private void lnkRegisterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = LoginFormFactory.CreateRegisterForm();
            frm.Show();
            this.Hide();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "admin";
            txtPassword.Text = "admin";
        }
    }
}
