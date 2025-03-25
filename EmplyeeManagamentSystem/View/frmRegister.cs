using EmployeeManagamentSystem.Repository;

namespace EmployeeManagamentSystem
{
    public partial class frmRegister : Form
    {
        private readonly UserService _userService;

        public frmRegister()
        {
            InitializeComponent();
            _userService = new UserService(new UserRepository());
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
                    string username = txtUsername.Text;
                    string password = txtPassword.Text;
                    string email = txtEmail.Text;

                    bool userCreated = _userService.CreateAccount(username, password, email);

                    if (userCreated)
                    {
                        DialogResult result = MessageBox.Show("Welcome, waiting for approval from admin.", "Approval Pending", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (result == DialogResult.OK)
                        {
                            frmLogin frmLogin = new frmLogin();
                            frmLogin.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username already exists or account creation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
