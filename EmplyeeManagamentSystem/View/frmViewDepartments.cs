using System;
using System.Data;
using System.Windows.Forms;

namespace EmployeeManagamentSystem
{
    public partial class frmViewDepartments : Form
    {
        private readonly DepartmentService _departmentService;

        public frmViewDepartments()
        {
            InitializeComponent();
            _departmentService = new DepartmentService();
        }

        private void frmViewDepartments_Load(object sender, EventArgs e)
        {
            try
            {
                // Get the department data from the service
                DataTable dtDepartments = _departmentService.GetAllDepartments();
                dgvDepartments.DataSource = dtDepartments;

                // Customize column headers
                dgvDepartments.Columns[0].HeaderText = "Department ID";
                dgvDepartments.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
