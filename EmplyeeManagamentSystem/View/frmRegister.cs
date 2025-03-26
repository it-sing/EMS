using DBProgrammingDemo9;
using EmployeeManagamentSystem.Util;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagamentSystem
{
    public partial class frmRegister : Form
    {
        private readonly UserService _userService;

        public frmRegister()
        {
            InitializeComponent();
            _userService = new UserService();
        }


        private void lnkLoginLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();

            this.Hide();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            try{


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtValidation(object sender)
        {
            TextBox txt = (TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
            {
                errProvider.SetError(txt, "This field is required.");
            }
            else
            {
                errProvider.SetError(txt, "");
            }
        }
        
      
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    bool userCreated = _userService.RegisterUser(txtUsername.Text, txtPassword.Text, txtEmail.Text);
                    if (userCreated)
                    {
                        MessageBox.Show("Welcome, waiting for approval from admin.", "Approval Pending", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        new frmLogin().Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            txtValidation(sender);
            if (sender == txtEmail)
            {
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    errProvider.SetError(txtEmail, "Invalid email address.");
                }
                else
                {
                    errProvider.SetError(txtEmail, "");
                }
            }
        }
    }
}