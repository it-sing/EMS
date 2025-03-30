using EmployeeManagamentSystem.Util;

namespace EmployeeManagamentSystem
{
    public partial class frmEmployeeSystemManager : Form
    {
        public frmEmployeeSystemManager()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            object tag = null;
            if (sender is ToolStripMenuItem)
            {
                tag = ((ToolStripMenuItem)sender).Tag;
            }
            else if (sender is ToolStripButton)
            {
                tag = ((ToolStripButton)sender).Tag;
            }
            //MessageBox.Show(tag.ToString());

            Form? childForm = null;


            switch (tag.ToString())
            {
                case "User":
                    childForm = new frmUserManagement();
                    break;
                case "Employees":
                    childForm = new frmEmployeeMaintenance();
                    break;
                case "Departments":
                    childForm = new frmDepartmentMaintenance();
                    break;
                case "Edit Profile":
                    childForm = new frmEditProfile();
                    break;
                case "About":
                    childForm = new frmAbout();
                    break;
                case "Salary":
                    childForm = new frmSalaries();
                    break;
                case "Manager":
                    childForm = new frmManager();
                    break;
                case "Attendance":
                    childForm = new frmAttendance();
                    break;
                case "Report":
                    childForm = new frmReport();
                    break;
                case "Logout":
                    DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        foreach (Form child in this.MdiChildren)
                        {
                            child.Close();
                        }

                        // Close the main form and open the login form
                        this.Close();
                        childForm = new frmLogin();
                    }
                    else
                    {
                        return;
                    }
                    break;



                default:
                    MessageBox.Show($"I was called by {sender}");
                    break;


            }
            if (childForm != null)
            {
                // Check if the form is already open
                foreach (Form frm in this.MdiChildren)
                {
                    if (frm.Text == childForm.Text)
                    {
                        frm.Activate();
                        return;
                    }
                }

                // Assign MDI parent only for specific forms
                if (childForm is frmEditProfile ||
                    childForm is frmAbout)
                    //childForm is frmViewDepartments ||
                    //childForm is frmViewEmployees)
                {
                    childForm.MdiParent = this;
                }

                // Ensure the form is initialized before calling Show()
                if (!childForm.IsHandleCreated)
                {
                    childForm.Show();
                }

                childForm.Location = new Point(0, 0);
                toolStripStatusLabel.Text = childForm.Text + " is showing";
            }
            else
            {
                MessageBox.Show("Error: The form is null!", "Null Reference", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void frmEmployeeSystemManager_Load(object sender, EventArgs e)
        {
            try
            {
                Authorization.SetFormAccessCurrentUser();

                if (!Authorization.ShowEmployeeEditorForm())
                {
                    employeesToolStripMenuItem.Visible = false;
                }

                if (!Authorization.ShowDepartmentEditorForm())
                {
                    departmentsToolStripMenuItem.Visible = false;
                }

                if (!Authorization.ShowEditProfileForm())
                {
                    editProfileToolStripMenuItem.Visible = false;
                }

                if (!Authorization.ShowManagerForm())
                {
                    setManagerToolStripMenuItem.Visible = false;
                }

                if (!Authorization.ShowSalaryForm())
                {
                    setSalaToolStripMenuItem.Visible = false;
                }

                if (!Authorization.ShowUserForm())
                {
                    userToolStripMenuItem.Visible = false;
                }
                if (!Authorization.ShowAttendanceForm())
                {
                    attendanceToolStripMenuItem.Visible = false;
                }
                if (!Authorization.ShowReportForm())
                {
                    reportToolStripMenuItem.Visible = false;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
