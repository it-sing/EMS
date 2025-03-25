﻿using DBProgrammingDemo9;
using EmployeeManagamentSystem.Util;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EmployeeManagamentSystem
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void lnkLoginLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();

            this.Hide();
        }
        private bool IsUserNameExists(string userName)
        {
            string sql = "SELECT COUNT(*) FROM Users WHERE Username = @Username;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", userName)
            };

            DataTable dt = DataAccess.GetByParameter(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                int count = Convert.ToInt32(dt.Rows[0][0]);
                return count > 0;
            }
            return false;

        }

        private bool CreateAccount()
        {
            bool userCreated = false;

            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;
            DateTime createdAt = DateTime.Now;
            int roleID = 4;

            if (IsUserNameExists(username))
            {
                MessageBox.Show("Username already exists.");
                return false;
            }

            string sql = "INSERT INTO Users (Username, Password, Email, RoleID, CreatedAt) " +
                         "OUTPUT INSERTED.UserID " +
                         "VALUES (@Username, @Password, @Email, @RoleID, @CreatedAt)";

            SqlParameter[] parameters = {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password),  
                new SqlParameter("@Email", email),
                new SqlParameter("@RoleID", roleID),
                new SqlParameter("@CreatedAt", createdAt)
            };

            object result = DataAccess.SendAndReturnId(sql, parameters);

            if (result != null)
            {
                UIUtilities.CurrentUserID = Convert.ToInt32(result);
                userCreated = true;
            }
            else
            {
                MessageBox.Show("Account creation failed.");
            }

            return userCreated;
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    bool userCreated = CreateAccount();
                    if (userCreated)
                    {
                        DialogResult result = MessageBox.Show($"Welcome, waiting for approval from admin.", "Approval Pending", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (result == DialogResult.OK)
                        {
                            frmLogin frmLogin = new frmLogin();
                            frmLogin.Show();
                            this.Hide();
                            //Application.Exit();
                        }
                        //frmEmployeeSystemManager frmEmployeeSystemManager = new frmEmployeeSystemManager();
                        //frmEmployeeSystemManager.Show();
                        //this.Hide();
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

        private void cmbRoles_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            UIUtilities.ComboBoxValidating(sender, e, errProvider);
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