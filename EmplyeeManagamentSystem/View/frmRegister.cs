
using EmployeeManagamentSystem.Pattern.Register_Facade;
using EmployeeManagamentSystem.Service;

namespace EmployeeManagamentSystem
{
    public partial class frmRegister : Form
    {
        private readonly RegistrationFacade _registrationFacade;

        public frmRegister()
        {
            InitializeComponent();
            _registrationFacade = new RegistrationFacade();
        }
        private void lnkLoginLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    bool userCreated = _registrationFacade.ValidateUser(txtUsername.Text, txtPassword.Text, txtEmail.Text);
                    if (userCreated) {
                        _registrationFacade.CreateUser(txtUsername.Text, txtPassword.Text, txtEmail.Text);
                        MessageBox.Show("Registration successful! Please wait for admin approval.", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Hide();
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
