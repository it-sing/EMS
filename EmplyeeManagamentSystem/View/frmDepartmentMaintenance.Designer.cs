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
            grpDepartments = new GroupBox();
            btnDelete = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            btnAdd = new Button();
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
            grpDepartments.Controls.Add(btnDelete);
            grpDepartments.Controls.Add(btnSave);
            grpDepartments.Controls.Add(btnCancel);
            grpDepartments.Controls.Add(btnAdd);
            grpDepartments.Controls.Add(txtDepartmentID);
            grpDepartments.Controls.Add(label3);
            grpDepartments.Controls.Add(txtDescription);
            grpDepartments.Controls.Add(label2);
            grpDepartments.Controls.Add(txtDepartmentName);
            grpDepartments.Controls.Add(label1);
            grpDepartments.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDepartments.Location = new Point(25, 35);
            grpDepartments.Name = "grpDepartments";
            grpDepartments.Size = new Size(651, 536);
            grpDepartments.TabIndex = 0;
            grpDepartments.TabStop = false;
            grpDepartments.Text = "Department Details";
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(167, 443);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(296, 443);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(415, 443);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(40, 443);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtDepartmentID
            // 
            txtDepartmentID.Location = new Point(30, 72);
            txtDepartmentID.Name = "txtDepartmentID";
            txtDepartmentID.ReadOnly = true;
            txtDepartmentID.Size = new Size(564, 38);
            txtDepartmentID.TabIndex = 5;
            txtDepartmentID.Tag = "Department ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(30, 46);
            label3.Name = "label3";
            label3.Size = new Size(28, 23);
            label3.TabIndex = 4;
            label3.Text = "ID";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(30, 222);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(564, 200);
            txtDescription.TabIndex = 3;
            txtDescription.Tag = "Department Description";
            txtDescription.Validating += txt_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(30, 196);
            label2.Name = "label2";
            label2.Size = new Size(205, 23);
            label2.TabIndex = 2;
            label2.Text = "Department Description";
            // 
            // txtDepartmentName
            // 
            txtDepartmentName.Location = new Point(30, 146);
            txtDepartmentName.Name = "txtDepartmentName";
            txtDepartmentName.Size = new Size(564, 38);
            txtDepartmentName.TabIndex = 1;
            txtDepartmentName.Tag = "Department Name";
            txtDepartmentName.Validating += txt_Validating;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(30, 120);
            label1.Name = "label1";
            label1.Size = new Size(160, 23);
            label1.TabIndex = 0;
            label1.Text = "Department Name";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, prgBar, toolStripStatusLabel3 });
            statusStrip1.Location = new Point(0, 590);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1454, 26);
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
            dgvDepartments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDepartments.Location = new Point(710, 107);
            dgvDepartments.Name = "dgvDepartments";
            dgvDepartments.ReadOnly = true;
            dgvDepartments.RowHeadersWidth = 51;
            dgvDepartments.Size = new Size(717, 464);
            dgvDepartments.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(710, 47);
            label4.Name = "label4";
            label4.Size = new Size(213, 46);
            label4.TabIndex = 3;
            label4.Text = "Department";
            // 
            // frmDepartmentMaintenance
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1454, 616);
            Controls.Add(label4);
            Controls.Add(dgvDepartments);
            Controls.Add(statusStrip1);
            Controls.Add(grpDepartments);
            Name = "frmDepartmentMaintenance";
            StartPosition = FormStartPosition.CenterScreen;
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
        private Button btnDelete;
        private Button btnSave;
        private Button btnCancel;
        private Button btnAdd;
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