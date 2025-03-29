using System.Windows.Forms;

namespace EmployeeManagamentSystem
{
    partial class frmEmployeeMaintenance
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
            components = new System.ComponentModel.Container();
            grpEmployees = new GroupBox();
            cboDepartments = new ComboBox();
            label7 = new Label();
            dtpEmployemntDate = new DateTimePicker();
            label6 = new Label();
            dtpDateOfBirth = new DateTimePicker();
            label5 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            txtFirstname = new TextBox();
            label3 = new Label();
            txtLastName = new TextBox();
            label2 = new Label();
            txtEmployeeID = new TextBox();
            label1 = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            prgBar = new ToolStripProgressBar();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            errProvider = new ErrorProvider(components);
            grpDepartment = new GroupBox();
            cboDepartmentFillter = new ComboBox();
            dgvEmployees = new DataGridView();
            grpEmployees.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errProvider).BeginInit();
            grpDepartment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // grpEmployees
            // 
            grpEmployees.Controls.Add(cboDepartments);
            grpEmployees.Controls.Add(label7);
            grpEmployees.Controls.Add(dtpEmployemntDate);
            grpEmployees.Controls.Add(label6);
            grpEmployees.Controls.Add(dtpDateOfBirth);
            grpEmployees.Controls.Add(label5);
            grpEmployees.Controls.Add(txtEmail);
            grpEmployees.Controls.Add(label4);
            grpEmployees.Controls.Add(btnSave);
            grpEmployees.Controls.Add(btnCancel);
            grpEmployees.Controls.Add(txtFirstname);
            grpEmployees.Controls.Add(label3);
            grpEmployees.Controls.Add(txtLastName);
            grpEmployees.Controls.Add(label2);
            grpEmployees.Controls.Add(txtEmployeeID);
            grpEmployees.Controls.Add(label1);
            grpEmployees.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpEmployees.Location = new Point(12, 12);
            grpEmployees.Name = "grpEmployees";
            grpEmployees.Size = new Size(1062, 439);
            grpEmployees.TabIndex = 1;
            grpEmployees.TabStop = false;
            grpEmployees.Text = "Employee Details";
            // 
            // cboDepartments
            // 
            cboDepartments.FormattingEnabled = true;
            cboDepartments.Location = new Point(538, 67);
            cboDepartments.Name = "cboDepartments";
            cboDepartments.Size = new Size(412, 39);
            cboDepartments.TabIndex = 35;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(538, 42);
            label7.Name = "label7";
            label7.Size = new Size(108, 23);
            label7.TabIndex = 32;
            label7.Text = "Department";
            // 
            // dtpEmployemntDate
            // 
            dtpEmployemntDate.CalendarFont = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpEmployemntDate.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpEmployemntDate.Location = new Point(538, 236);
            dtpEmployemntDate.Name = "dtpEmployemntDate";
            dtpEmployemntDate.Size = new Size(412, 38);
            dtpEmployemntDate.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(538, 210);
            label6.Name = "label6";
            label6.Size = new Size(155, 23);
            label6.TabIndex = 30;
            label6.Text = "Employment Date";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.CalendarFont = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpDateOfBirth.Font = new Font("Segoe UI", 13.8F);
            dtpDateOfBirth.Location = new Point(538, 141);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(412, 38);
            dtpDateOfBirth.TabIndex = 29;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(538, 115);
            label5.Name = "label5";
            label5.Size = new Size(115, 23);
            label5.TabIndex = 28;
            label5.Text = "Date of Birth";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(41, 313);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(398, 38);
            txtEmail.TabIndex = 27;
            txtEmail.Tag = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(41, 287);
            label4.Name = "label4";
            label4.Size = new Size(54, 23);
            label4.TabIndex = 26;
            label4.Text = "Email";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(44, 377);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 24;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(174, 377);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 23;
            btnCancel.Tag = "Cancel";
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtFirstname
            // 
            txtFirstname.Location = new Point(41, 141);
            txtFirstname.Multiline = true;
            txtFirstname.Name = "txtFirstname";
            txtFirstname.Size = new Size(398, 38);
            txtFirstname.TabIndex = 17;
            txtFirstname.Tag = "First Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(41, 115);
            label3.Name = "label3";
            label3.Size = new Size(97, 23);
            label3.TabIndex = 16;
            label3.Text = "First Name";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(41, 236);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(398, 38);
            txtLastName.TabIndex = 15;
            txtLastName.Tag = "Last Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(41, 199);
            label2.Name = "label2";
            label2.Size = new Size(94, 23);
            label2.TabIndex = 14;
            label2.Text = "Last Name";
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Location = new Point(41, 68);
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.ReadOnly = true;
            txtEmployeeID.Size = new Size(398, 38);
            txtEmployeeID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(41, 42);
            label1.Name = "label1";
            label1.Size = new Size(106, 23);
            label1.TabIndex = 0;
            label1.Text = "EmployeeID";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, prgBar, toolStripStatusLabel3 });
            statusStrip1.Location = new Point(0, 868);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1106, 26);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 20);
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(0, 20);
            // 
            // prgBar
            // 
            prgBar.Name = "prgBar";
            prgBar.Size = new Size(100, 18);
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(0, 20);
            // 
            // errProvider
            // 
            errProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errProvider.ContainerControl = this;
            // 
            // grpDepartment
            // 
            grpDepartment.Controls.Add(cboDepartmentFillter);
            grpDepartment.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDepartment.Location = new Point(25, 457);
            grpDepartment.Name = "grpDepartment";
            grpDepartment.Size = new Size(446, 77);
            grpDepartment.TabIndex = 6;
            grpDepartment.TabStop = false;
            grpDepartment.Text = "Choose A Department";
            // 
            // cboDepartmentFillter
            // 
            cboDepartmentFillter.FormattingEnabled = true;
            cboDepartmentFillter.Location = new Point(91, 33);
            cboDepartmentFillter.Name = "cboDepartmentFillter";
            cboDepartmentFillter.Size = new Size(322, 36);
            cboDepartmentFillter.TabIndex = 0;
            cboDepartmentFillter.SelectedIndexChanged += cboDepartmentFillter_SelectedIndexChanged;
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(25, 540);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.Size = new Size(1049, 325);
            dgvEmployees.TabIndex = 5;
            dgvEmployees.CellClick += dataGridView1_CellClick;
            // 
            // frmEmployeeMaintenance
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1106, 894);
            Controls.Add(grpDepartment);
            Controls.Add(dgvEmployees);
            Controls.Add(statusStrip1);
            Controls.Add(grpEmployees);
            Name = "frmEmployeeMaintenance";
            Tag = "Employee";
            Text = "Employee Maintenance";
            Load += frmEmployeeMaintenance_Load;
            grpEmployees.ResumeLayout(false);
            grpEmployees.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errProvider).EndInit();
            grpDepartment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpEmployees;
        private TextBox txtEmployeeID;
        private Label label1;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtFirstname;
        private Label label3;
        private TextBox txtLastName;
        private Label label2;
        private ComboBox cboDepartments;
        private Label label7;
        private DateTimePicker dtpEmployemntDate;
        private Label label6;
        private DateTimePicker dtpDateOfBirth;
        private Label label5;
        private TextBox txtEmail;
        private Label label4;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripProgressBar prgBar;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ErrorProvider errProvider;
        private GroupBox grpDepartment;
        private ComboBox cboDepartmentFillter;
        private DataGridView dgvEmployees;
        private ContextMenuStrip contextMenuStrip1;
    }
}