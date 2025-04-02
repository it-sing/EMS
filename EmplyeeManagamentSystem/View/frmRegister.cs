using EmployeeManagamentSystem.Service;
using EmployeeManagamentSystem.Repository;

namespace EmployeeManagamentSystem
{
    public partial class frmRegister : Form
    {
        private readonly RegistrationFacade _registrationFacade;

        public frmRegister()
        {
            InitializeComponent();

            // Initialize the facade with service and repository
            _registrationFacade = new RegistrationFacade(new RegisterService(), new UserRepository());
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
                    bool userCreated = _registrationFacade.ValidateAndRegisterUser(txtUsername.Text, txtPassword.Text, txtEmail.Text);

                    if (userCreated)
                    {
                        MessageBox.Show("Welcome! Waiting for admin approval.", "Approval Pending", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
