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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            grpEmployees.FlatStyle = FlatStyle.Flat;
            grpEmployees.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpEmployees.Location = new Point(12, 12);
            grpEmployees.Name = "grpEmployees";
            grpEmployees.Size = new Size(1144, 474);
            grpEmployees.TabIndex = 1;
            grpEmployees.TabStop = false;
            // 
            // cboDepartments
            // 
            cboDepartments.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cboDepartments.ForeColor = Color.FromArgb(64, 64, 64);
            cboDepartments.FormattingEnabled = true;
            cboDepartments.IntegralHeight = false;
            cboDepartments.ItemHeight = 41;
            cboDepartments.Location = new Point(646, 68);
            cboDepartments.Name = "cboDepartments";
            cboDepartments.Size = new Size(412, 49);
            cboDepartments.TabIndex = 35;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(64, 64, 64);
            label7.Location = new Point(646, 42);
            label7.Name = "label7";
            label7.Size = new Size(108, 23);
            label7.TabIndex = 32;
            label7.Text = "Department";
            // 
            // dtpEmployemntDate
            // 
            dtpEmployemntDate.CalendarFont = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpEmployemntDate.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpEmployemntDate.Location = new Point(646, 245);
            dtpEmployemntDate.Name = "dtpEmployemntDate";
            dtpEmployemntDate.Size = new Size(412, 47);
            dtpEmployemntDate.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(64, 64, 64);
            label6.Location = new Point(646, 219);
            label6.Name = "label6";
            label6.Size = new Size(155, 23);
            label6.TabIndex = 30;
            label6.Text = "Employment Date";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.CalendarFont = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpDateOfBirth.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDateOfBirth.Location = new Point(646, 154);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(412, 47);
            dtpDateOfBirth.TabIndex = 29;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(64, 64, 64);
            label5.Location = new Point(646, 128);
            label5.Name = "label5";
            label5.Size = new Size(115, 23);
            label5.TabIndex = 28;
            label5.Text = "Date of Birth";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtEmail.ForeColor = Color.FromArgb(64, 64, 64);
            txtEmail.Location = new Point(41, 335);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(398, 50);
            txtEmail.TabIndex = 27;
            txtEmail.Tag = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(41, 309);
            label4.Name = "label4";
            label4.Size = new Size(54, 23);
            label4.TabIndex = 26;
            label4.Text = "Email";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(680, 335);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(141, 50);
            btnSave.TabIndex = 24;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.HotTrack;
            btnCancel.Location = new Point(869, 335);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(141, 50);
            btnCancel.TabIndex = 23;
            btnCancel.Tag = "Cancel";
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtFirstname
            // 
            txtFirstname.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtFirstname.ForeColor = Color.FromArgb(64, 64, 64);
            txtFirstname.Location = new Point(41, 154);
            txtFirstname.Multiline = true;
            txtFirstname.Name = "txtFirstname";
            txtFirstname.Size = new Size(398, 50);
            txtFirstname.TabIndex = 17;
            txtFirstname.Tag = "First Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(41, 128);
            label3.Name = "label3";
            label3.Size = new Size(97, 23);
            label3.TabIndex = 16;
            label3.Text = "First Name";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtLastName.ForeColor = Color.FromArgb(64, 64, 64);
            txtLastName.Location = new Point(41, 242);
            txtLastName.Multiline = true;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(398, 50);
            txtLastName.TabIndex = 15;
            txtLastName.Tag = "Last Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(41, 216);
            label2.Name = "label2";
            label2.Size = new Size(94, 23);
            label2.TabIndex = 14;
            label2.Text = "Last Name";
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtEmployeeID.ForeColor = Color.FromArgb(64, 64, 64);
            txtEmployeeID.Location = new Point(41, 68);
            txtEmployeeID.Multiline = true;
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.ReadOnly = true;
            txtEmployeeID.Size = new Size(398, 50);
            txtEmployeeID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
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
            statusStrip1.Location = new Point(0, 910);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1168, 26);
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
            grpDepartment.Location = new Point(12, 492);
            grpDepartment.Name = "grpDepartment";
            grpDepartment.Size = new Size(358, 97);
            grpDepartment.TabIndex = 6;
            grpDepartment.TabStop = false;
            grpDepartment.Text = "Choose Department";
            // 
            // cboDepartmentFillter
            // 
            cboDepartmentFillter.FormattingEnabled = true;
            cboDepartmentFillter.Location = new Point(16, 37);
            cboDepartmentFillter.Name = "cboDepartmentFillter";
            cboDepartmentFillter.Size = new Size(322, 36);
            cboDepartmentFillter.TabIndex = 0;
            cboDepartmentFillter.SelectedIndexChanged += cboDepartmentFillter_SelectedIndexChanged;
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvEmployees.ColumnHeadersHeight = 40;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEmployees.EnableHeadersVisualStyles = false;
            dgvEmployees.GridColor = Color.FromArgb(64, 64, 64);
            dgvEmployees.Location = new Point(12, 595);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.RowHeadersWidth = 61;
            dgvEmployees.RowTemplate.Height = 40;
            dgvEmployees.Size = new Size(1144, 310);
            dgvEmployees.TabIndex = 5;
            dgvEmployees.CellClick += dataGridView1_CellClick;
            dgvEmployees.CellContentClick += dgvEmployees_CellContentClick;
            // 
            // frmEmployeeMaintenance
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1168, 936);
            Controls.Add(grpDepartment);
            Controls.Add(dgvEmployees);
            Controls.Add(statusStrip1);
            Controls.Add(grpEmployees);
            Name = "frmEmployeeMaintenance";
            StartPosition = FormStartPosition.CenterParent;
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