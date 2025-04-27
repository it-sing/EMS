
namespace EmployeeManagamentSystem
{
    partial class frmEmployeeSystemManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeSystemManager));
            menuStrip = new MenuStrip();
            userToolStripMenuItem = new ToolStripMenuItem();
            employeesToolStripMenuItem = new ToolStripMenuItem();
            departmentsToolStripMenuItem = new ToolStripMenuItem();
            editProfileToolStripMenuItem = new ToolStripMenuItem();
            setManagerToolStripMenuItem = new ToolStripMenuItem();
            attendanceToolStripMenuItem = new ToolStripMenuItem();
            setSalaToolStripMenuItem = new ToolStripMenuItem();
            reportToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolStrip1 = new ToolStrip();
            employeesToolStripButton = new ToolStripButton();
            departmentToolStripButton = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            menuStrip.ImageScalingSize = new Size(40, 40);
            menuStrip.Items.AddRange(new ToolStripItem[] { userToolStripMenuItem, employeesToolStripMenuItem, departmentsToolStripMenuItem, editProfileToolStripMenuItem, setManagerToolStripMenuItem, attendanceToolStripMenuItem, setSalaToolStripMenuItem, reportToolStripMenuItem, logoutToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(30, 20, 100, 20);
            menuStrip.Size = new Size(1817, 82);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            menuStrip.ItemClicked += menuStrip_ItemClicked;
            menuStrip.MouseHover += toolStripMenuItem1_Click;
            // 
            // userToolStripMenuItem
            // 
            userToolStripMenuItem.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            userToolStripMenuItem.ForeColor = Color.FromArgb(64, 64, 64);
            userToolStripMenuItem.Name = "userToolStripMenuItem";
            userToolStripMenuItem.Size = new Size(88, 42);
            userToolStripMenuItem.Tag = "User";
            userToolStripMenuItem.Text = "User";
            userToolStripMenuItem.Click += ShowNewForm;
            // 
            // employeesToolStripMenuItem
            // 
            employeesToolStripMenuItem.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            employeesToolStripMenuItem.ForeColor = Color.FromArgb(64, 64, 64);
            employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            employeesToolStripMenuItem.Size = new Size(156, 42);
            employeesToolStripMenuItem.Tag = "Employees";
            employeesToolStripMenuItem.Text = "Employee";
            employeesToolStripMenuItem.Click += ShowNewForm;
            // 
            // departmentsToolStripMenuItem
            // 
            departmentsToolStripMenuItem.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            departmentsToolStripMenuItem.ForeColor = Color.FromArgb(64, 64, 64);
            departmentsToolStripMenuItem.Name = "departmentsToolStripMenuItem";
            departmentsToolStripMenuItem.Size = new Size(185, 42);
            departmentsToolStripMenuItem.Tag = "Departments";
            departmentsToolStripMenuItem.Text = "Department";
            departmentsToolStripMenuItem.Click += ShowNewForm;
            // 
            // editProfileToolStripMenuItem
            // 
            editProfileToolStripMenuItem.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            editProfileToolStripMenuItem.ForeColor = Color.FromArgb(64, 64, 64);
            editProfileToolStripMenuItem.Name = "editProfileToolStripMenuItem";
            editProfileToolStripMenuItem.Size = new Size(162, 42);
            editProfileToolStripMenuItem.Tag = "Edit Profile";
            editProfileToolStripMenuItem.Text = "EditProfile";
            editProfileToolStripMenuItem.Click += ShowNewForm;
            // 
            // setManagerToolStripMenuItem
            // 
            setManagerToolStripMenuItem.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            setManagerToolStripMenuItem.ForeColor = Color.FromArgb(64, 64, 64);
            setManagerToolStripMenuItem.Name = "setManagerToolStripMenuItem";
            setManagerToolStripMenuItem.Size = new Size(145, 42);
            setManagerToolStripMenuItem.Tag = "Manager";
            setManagerToolStripMenuItem.Text = "Manager";
            setManagerToolStripMenuItem.Click += ShowNewForm;
            // 
            // attendanceToolStripMenuItem
            // 
            attendanceToolStripMenuItem.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            attendanceToolStripMenuItem.ForeColor = Color.FromArgb(64, 64, 64);
            attendanceToolStripMenuItem.Name = "attendanceToolStripMenuItem";
            attendanceToolStripMenuItem.Size = new Size(177, 42);
            attendanceToolStripMenuItem.Tag = "Attendance";
            attendanceToolStripMenuItem.Text = "Attendance";
            attendanceToolStripMenuItem.Click += ShowNewForm;
            // 
            // setSalaToolStripMenuItem
            // 
            setSalaToolStripMenuItem.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            setSalaToolStripMenuItem.ForeColor = Color.FromArgb(64, 64, 64);
            setSalaToolStripMenuItem.Name = "setSalaToolStripMenuItem";
            setSalaToolStripMenuItem.Size = new Size(116, 42);
            setSalaToolStripMenuItem.Tag = "Salary";
            setSalaToolStripMenuItem.Text = "Payroll";
            setSalaToolStripMenuItem.Click += ShowNewForm;
            // 
            // reportToolStripMenuItem
            // 
            reportToolStripMenuItem.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            reportToolStripMenuItem.ForeColor = Color.FromArgb(64, 64, 64);
            reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            reportToolStripMenuItem.Size = new Size(117, 42);
            reportToolStripMenuItem.Tag = "Report";
            reportToolStripMenuItem.Text = "Report";
            reportToolStripMenuItem.Click += ShowNewForm;
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            logoutToolStripMenuItem.ForeColor = Color.FromArgb(64, 64, 64);
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(122, 42);
            logoutToolStripMenuItem.Tag = "Logout";
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Click += ShowNewForm;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 900);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(3, 0, 40, 0);
            statusStrip.Size = new Size(1817, 26);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.BackColor = Color.White;
            toolStripStatusLabel.ForeColor = Color.Black;
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(49, 20);
            toolStripStatusLabel.Text = "Status";
            toolStripStatusLabel.Click += toolStripStatusLabel_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { employeesToolStripButton, departmentToolStripButton, toolStripButton3 });
            toolStrip1.Location = new Point(0, 82);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(10, 5, 3, 5);
            toolStrip1.Size = new Size(1817, 37);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // employeesToolStripButton
            // 
            employeesToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            employeesToolStripButton.Image = (Image)resources.GetObject("employeesToolStripButton.Image");
            employeesToolStripButton.ImageTransparentColor = Color.Magenta;
            employeesToolStripButton.Name = "employeesToolStripButton";
            employeesToolStripButton.Size = new Size(29, 24);
            employeesToolStripButton.Tag = "Employees";
            employeesToolStripButton.Text = "toolStripButton2";
            employeesToolStripButton.ToolTipText = "Employee";
            employeesToolStripButton.Click += ShowNewForm;
            // 
            // departmentToolStripButton
            // 
            departmentToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            departmentToolStripButton.Image = Properties.Resources.icons8_department_24;
            departmentToolStripButton.ImageTransparentColor = Color.Magenta;
            departmentToolStripButton.Name = "departmentToolStripButton";
            departmentToolStripButton.Size = new Size(29, 24);
            departmentToolStripButton.Tag = "Departments";
            departmentToolStripButton.Text = "Departments";
            departmentToolStripButton.Click += ShowNewForm;
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(29, 24);
            toolStripButton3.Tag = "About";
            toolStripButton3.Text = "About";
            toolStripButton3.Click += ShowNewForm;
            // 
            // frmEmployeeSystemManager
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(1817, 926);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            ForeColor = Color.FromArgb(64, 64, 64);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(7, 11, 7, 11);
            Name = "frmEmployeeSystemManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employee System Manager";
            Load += frmEmployeeSystemManager_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripMenuItem employeesToolStripMenuItem;
        private ToolStripMenuItem departmentsToolStripMenuItem;
        private ToolStripMenuItem editProfileToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton departmentToolStripButton;
        private ToolStripButton employeesToolStripButton;
        private ToolStripButton toolStripButton3;
        private ToolStripMenuItem setManagerToolStripMenuItem;
        private ToolStripMenuItem setSalaToolStripMenuItem;
        private ToolStripMenuItem userToolStripMenuItem;
        private ToolStripMenuItem attendanceToolStripMenuItem;
        private ToolStripMenuItem reportToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
    }
}



