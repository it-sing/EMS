using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagamentSystem.View
{
    public partial class frmForgotPassword : Form
    {
        private readonly Service.ForgotPasswordService forgotPasswordService;
        public frmForgotPassword()
        {
            InitializeComponent();
            forgotPasswordService = new Service.ForgotPasswordService();

        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    MessageBox.Show("Please enter your email address.");
                    return;
                }
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Please enter your new password.");
                    return;
                }
                if (forgotPasswordService.ResetPassword(txtEmail.Text, txtPassword.Text) > 0)
                {
                    this.Close();
                    frmLogin frmLogin = new frmLogin();
                    frmLogin.Show();
                }
                else
                {
                    MessageBox.Show("Email not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void btnsignin_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Hide();

        }
    }
}
