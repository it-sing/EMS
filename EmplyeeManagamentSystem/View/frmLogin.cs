using DBProgrammingDemo9;
using EmployeeManagamentSystem.Util;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagamentSystem
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
           
        }
        private string GetRole(int userID)
        {
            string sql = "SELECT Role FROM Users WHERE UserID = @UserID";
            // Create parameter collection and add the UserID parameter
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userID)
            };
            DataTable dt = DataAccess.GetByparameter(sql, parameters);
            if (dt.Rows.Count == 1)
            {
                return dt.Rows[0]["Role"].ToString();
            }
            return string.Empty;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                string sql = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
                SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@Username", username),
                        new SqlParameter("@Password", password)
                    };
                DataTable dt = DataAccess.GetByparameter(sql, parameters);

                if (dt.Rows.Count == 1)
                {
                    int userID = Convert.ToInt32(dt.Rows[0]["UserID"]);

                    string role = GetRole(userID);

                    if (role == "4")
                    {

                        MessageBox.Show("Please waiting for admin approve!!", " ", MessageBoxButtons.OK);

                        // Show user dashboard
                        //UIUtilities.CurrentUserID = userID;
                        //frmNotification frmNotification = new frmNotification();
                        //frmNotification.Show();
                        //this.Hide();
                    }
                    else
                    {
                        // Show manager dashboard
                        UIUtilities.CurrentUserID = userID;
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
            //set default values
            txtUsername.Text = "admin";
            txtPassword.Text = "admin";
        }
    }
}
