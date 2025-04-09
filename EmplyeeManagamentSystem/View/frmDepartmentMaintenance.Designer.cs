using System.ComponentModel;

namespace EmployeeManagamentSystem
{
    partial class frmDepartmentMaintenance
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
            components = new Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            grpDepartments = new GroupBox();
            btnSave = new Button();
            btnCancel = new Button();
            txtDepartmentID = new TextBox();
            label3 = new Label();
            txtDescription = new TextBox();
            label2 = new Label();
            txtDepartmentName = new TextBox();
            label1 = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            prgBar = new ToolStripProgressBar();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            errProvider = new ErrorProvider(components);
            dgvDepartments = new DataGridView();
            label4 = new Label();
            grpDepartments.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((ISupportInitialize)errProvider).BeginInit();
            ((ISupportInitialize)dgvDepartments).BeginInit();
            SuspendLayout();
            // 
            // grpDepartments
            // 
            grpDepartments.Controls.Add(btnSave);
            grpDepartments.Controls.Add(btnCancel);
            grpDepartments.Controls.Add(txtDepartmentID);
            grpDepartments.Controls.Add(label3);
            grpDepartments.Controls.Add(txtDescription);
            grpDepartments.Controls.Add(label2);
            grpDepartments.Controls.Add(txtDepartmentName);
            grpDepartments.Controls.Add(label1);
            grpDepartments.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDepartments.ForeColor = Color.FromArgb(64, 64, 64);
            grpDepartments.Location = new Point(21, 12);
            grpDepartments.Name = "grpDepartments";
            grpDepartments.Size = new Size(651, 569);
            grpDepartments.TabIndex = 0;
            grpDepartments.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(30, 475);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(141, 50);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnCancel.ForeColor = SystemColors.HotTrack;
            btnCancel.Location = new Point(197, 475);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(141, 50);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtDepartmentID
            // 
            txtDepartmentID.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDepartmentID.ForeColor = Color.FromArgb(64, 64, 64);
            txtDepartmentID.Location = new Point(30, 79);
            txtDepartmentID.Multiline = true;
            txtDepartmentID.Name = "txtDepartmentID";
            txtDepartmentID.ReadOnly = true;
            txtDepartmentID.Size = new Size(564, 50);
            txtDepartmentID.TabIndex = 5;
            txtDepartmentID.Tag = "Department ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(30, 46);
            label3.Name = "label3";
            label3.Size = new Size(32, 28);
            label3.TabIndex = 4;
            label3.Text = "ID";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.ForeColor = Color.FromArgb(64, 64, 64);
            txtDescription.Location = new Point(30, 275);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(564, 166);
            txtDescription.TabIndex = 3;
            txtDescription.Tag = "Department Description";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(30, 244);
            label2.Name = "label2";
            label2.Size = new Size(115, 28);
            label2.TabIndex = 2;
            label2.Text = "Description";
            label2.Click += label2_Click;
            // 
            // txtDepartmentName
            // 
            txtDepartmentName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDepartmentName.ForeColor = Color.FromArgb(64, 64, 64);
            txtDepartmentName.Location = new Point(30, 180);
            txtDepartmentName.Multiline = true;
            txtDepartmentName.Name = "txtDepartmentName";
            txtDepartmentName.Size = new Size(564, 50);
            txtDepartmentName.TabIndex = 1;
            txtDepartmentName.Tag = "Department Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(30, 149);
            label1.Name = "label1";
            label1.Size = new Size(66, 28);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, prgBar, toolStripStatusLabel3 });
            statusStrip1.Location = new Point(0, 607);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1546, 26);
            statusStrip1.TabIndex = 1;
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
            // dgvDepartments
            // 
            dgvDepartments.AllowUserToAddRows = false;
            dgvDepartments.AllowUserToDeleteRows = false;
            dgvDepartments.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDepartments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDepartments.ColumnHeadersHeight = 40;
            dgvDepartments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDepartments.EnableHeadersVisualStyles = false;
            dgvDepartments.GridColor = Color.FromArgb(64, 64, 64);
            dgvDepartments.Location = new Point(687, 58);
            dgvDepartments.Name = "dgvDepartments";
            dgvDepartments.ReadOnly = true;
            dgvDepartments.RowHeadersWidth = 61;
            dgvDepartments.RowTemplate.Height = 40;
            dgvDepartments.Size = new Size(852, 523);
            dgvDepartments.TabIndex = 2;
            dgvDepartments.CellClick += dgvDepartments_CellClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(687, 17);
            label4.Name = "label4";
            label4.Size = new Size(179, 28);
            label4.TabIndex = 3;
            label4.Text = "View Department";
            // 
            // frmDepartmentMaintenance
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1546, 633);
            Controls.Add(label4);
            Controls.Add(dgvDepartments);
            Controls.Add(statusStrip1);
            Controls.Add(grpDepartments);
            Name = "frmDepartmentMaintenance";
            StartPosition = FormStartPosition.CenterParent;
            Tag = "Departments";
            Text = "Department Maintenance";
            Load += frmDepartmentMaintenance_Load;
            grpDepartments.ResumeLayout(false);
            grpDepartments.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((ISupportInitialize)errProvider).EndInit();
            ((ISupportInitialize)dgvDepartments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private GroupBox grpDepartments;
        private TextBox txtDepartmentName;
        private Label label1;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtDepartmentID;
        private Label label3;
        private TextBox txtDescription;
        private Label label2;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar prgBar;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ErrorProvider errProvider;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private DataGridView dgvDepartments;
        private Label label4;
    }
}