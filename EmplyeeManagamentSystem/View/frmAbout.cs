namespace EmployeeManagamentSystem
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {

            lblCompany.Text = Application.CompanyName;
            lblVersion.Text = Application.ProductVersion;
            lblProductName.Text = Application.ProductName;
        }

        private void lblProductName_Click(object sender, EventArgs e)
        {

        }
    }
}
