
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
            aboutToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolStrip1 = new ToolStrip();
            departmentToolStripButton = new ToolStripButton();
            employeesToolStripButton = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(40, 40);
            menuStrip.Items.AddRange(new ToolStripItem[] { userToolStripMenuItem, employeesToolStripMenuItem, departmentsToolStripMenuItem, editProfileToolStripMenuItem, setManagerToolStripMenuItem, attendanceToolStripMenuItem, setSalaToolStripMenuItem, reportToolStripMenuItem, aboutToolStripMenuItem, logoutToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(8, 3, 0, 3);
            menuStrip.Size = new Size(1283, 33);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            // 
            // userToolStripMenuItem
            // 
            userToolStripMenuItem.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            userToolStripMenuItem.ForeColor = Color.FromArgb(84, 84, 84);
            userToolStripMenuItem.Name = "userToolStripMenuItem";
            userToolStripMenuItem.Size = new Size(64, 27);
            userToolStripMenuItem.Tag = "User";
            userToolStripMenuItem.Text = "User";
            userToolStripMenuItem.Click += ShowNewForm;
            // 
            // employeesToolStripMenuItem
            // 
            employeesToolStripMenuItem.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            employeesToolStripMenuItem.ForeColor = Color.FromArgb(84, 84, 84);
            employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            employeesToolStripMenuItem.Size = new Size(107, 27);
            employeesToolStripMenuItem.Tag = "Employees";
            employeesToolStripMenuItem.Text = "Employee";
            employeesToolStripMenuItem.Click += ShowNewForm;
            // 
            // departmentsToolStripMenuItem
            // 
            departmentsToolStripMenuItem.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            departmentsToolStripMenuItem.ForeColor = Color.FromArgb(84, 84, 84);
            departmentsToolStripMenuItem.Name = "departmentsToolStripMenuItem";
            departmentsToolStripMenuItem.Size = new Size(125, 27);
            departmentsToolStripMenuItem.Tag = "Departments";
            departmentsToolStripMenuItem.Text = "Department";
            departmentsToolStripMenuItem.Click += ShowNewForm;
            // 
            // editProfileToolStripMenuItem
            // 
            editProfileToolStripMenuItem.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            editProfileToolStripMenuItem.ForeColor = Color.FromArgb(84, 84, 84);
            editProfileToolStripMenuItem.Name = "editProfileToolStripMenuItem";
            editProfileToolStripMenuItem.Size = new Size(116, 27);
            editProfileToolStripMenuItem.Tag = "Edit Profile";
            editProfileToolStripMenuItem.Text = "EditProfile";
            editProfileToolStripMenuItem.Click += ShowNewForm;
            // 
            // setManagerToolStripMenuItem
            // 
            setManagerToolStripMenuItem.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            setManagerToolStripMenuItem.ForeColor = Color.FromArgb(84, 84, 84);
            setManagerToolStripMenuItem.Name = "setManagerToolStripMenuItem";
            setManagerToolStripMenuItem.Size = new Size(100, 27);
            setManagerToolStripMenuItem.Tag = "Manager";
            setManagerToolStripMenuItem.Text = "Manager";
            setManagerToolStripMenuItem.Click += ShowNewForm;
            // 
            // attendanceToolStripMenuItem
            // 
            attendanceToolStripMenuItem.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            attendanceToolStripMenuItem.ForeColor = Color.FromArgb(84, 84, 84);
            attendanceToolStripMenuItem.Name = "attendanceToolStripMenuItem";
            attendanceToolStripMenuItem.Size = new Size(121, 27);
            attendanceToolStripMenuItem.Tag = "Attendance";
            attendanceToolStripMenuItem.Text = "Attendance";
            attendanceToolStripMenuItem.Click += ShowNewForm;
            // 
            // setSalaToolStripMenuItem
            // 
            setSalaToolStripMenuItem.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            setSalaToolStripMenuItem.ForeColor = Color.FromArgb(84, 84, 84);
            setSalaToolStripMenuItem.Name = "setSalaToolStripMenuItem";
            setSalaToolStripMenuItem.Size = new Size(84, 27);
            setSalaToolStripMenuItem.Tag = "Salary";
            setSalaToolStripMenuItem.Text = "Payroll";
            setSalaToolStripMenuItem.Click += ShowNewForm;
            // 
            // reportToolStripMenuItem
            // 
            reportToolStripMenuItem.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            reportToolStripMenuItem.ForeColor = Color.FromArgb(84, 84, 84);
            reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            reportToolStripMenuItem.Size = new Size(83, 27);
            reportToolStripMenuItem.Tag = "Report";
            reportToolStripMenuItem.Text = "Report";
            reportToolStripMenuItem.Click += ShowNewForm;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            aboutToolStripMenuItem.ForeColor = Color.FromArgb(84, 84, 84);
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(75, 27);
            aboutToolStripMenuItem.Tag = "About";
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += ShowNewForm;
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            logoutToolStripMenuItem.ForeColor = Color.FromArgb(84, 84, 84);
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(84, 27);
            logoutToolStripMenuItem.Tag = "Logout";
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Click += ShowNewForm;

            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 795);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 19, 0);
            statusStrip.Size = new Size(1283, 26);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(49, 20);
            toolStripStatusLabel.Text = "Status";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { departmentToolStripButton, employeesToolStripButton, toolStripButton3 });
            toolStrip1.Location = new Point(0, 33);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1283, 27);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
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
            // employeesToolStripButton
            // 
            employeesToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            employeesToolStripButton.Image = (Image)resources.GetObject("employeesToolStripButton.Image");
            employeesToolStripButton.ImageTransparentColor = Color.Magenta;
            employeesToolStripButton.Name = "employeesToolStripButton";
            employeesToolStripButton.Size = new Size(29, 24);
            employeesToolStripButton.Text = "toolStripButton2";
            employeesToolStripButton.Click += ShowNewForm;
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
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1283, 821);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 5, 4, 5);
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
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem setManagerToolStripMenuItem;
        private ToolStripMenuItem setSalaToolStripMenuItem;
        private ToolStripMenuItem userToolStripMenuItem;
        private ToolStripMenuItem attendanceToolStripMenuItem;
        private ToolStripMenuItem reportToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
    }
}



