namespace EmployeeManagamentSystem
{
    partial class frmAttendance
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
            pictureBoxQRCode = new PictureBox();
            grpDepartment = new GroupBox();
            cmbMonth = new ComboBox();
            dgvAttendance = new DataGridView();
            txtName = new TextBox();
            cmbYear = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQRCode).BeginInit();
            grpDepartment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxQRCode
            // 
            pictureBoxQRCode.Location = new Point(106, 225);
            pictureBoxQRCode.Name = "pictureBoxQRCode";
            pictureBoxQRCode.Size = new Size(164, 157);
            pictureBoxQRCode.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxQRCode.TabIndex = 0;
            pictureBoxQRCode.TabStop = false;
            // 
            // grpDepartment
            // 
            grpDepartment.Controls.Add(cmbYear);
            grpDepartment.Controls.Add(cmbMonth);
            grpDepartment.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDepartment.Location = new Point(543, 56);
            grpDepartment.Name = "grpDepartment";
            grpDepartment.Size = new Size(416, 82);
            grpDepartment.TabIndex = 49;
            grpDepartment.TabStop = false;
            grpDepartment.Text = "Fillter";
            // 
            // cmbMonth
            // 
            cmbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMonth.FormattingEnabled = true;
            cmbMonth.Location = new Point(18, 34);
            cmbMonth.Name = "cmbMonth";
            cmbMonth.Size = new Size(183, 36);
            cmbMonth.TabIndex = 0;
            cmbMonth.SelectedIndexChanged += cmbMonth_SelectedIndexChanged;
            // 
            // dgvAttendance
            // 
            dgvAttendance.AllowUserToAddRows = false;
            dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAttendance.Location = new Point(404, 159);
            dgvAttendance.Name = "dgvAttendance";
            dgvAttendance.ReadOnly = true;
            dgvAttendance.RowHeadersWidth = 51;
            dgvAttendance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAttendance.Size = new Size(555, 344);
            dgvAttendance.TabIndex = 48;
            // 
            // txtName
            // 
            txtName.Location = new Point(106, 388);
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(164, 27);
            txtName.TabIndex = 50;
            txtName.TextAlign = HorizontalAlignment.Center;
            // 
            // cmbYear
            // 
            cmbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYear.FormattingEnabled = true;
            cmbYear.Location = new Point(221, 33);
            cmbYear.Name = "cmbYear";
            cmbYear.Size = new Size(183, 36);
            cmbYear.TabIndex = 1;
            cmbYear.SelectedIndexChanged += cmbYear_SelectedIndexChanged;
            // 
            // frmAttendance
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(971, 515);
            Controls.Add(txtName);
            Controls.Add(grpDepartment);
            Controls.Add(dgvAttendance);
            Controls.Add(pictureBoxQRCode);
            Name = "frmAttendance";
            Text = "frmAttendance";
            Load += new EventHandler(frmAttendance_Load);
            FormClosing += FrmAttendance_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBoxQRCode).EndInit();
            grpDepartment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxQRCode;
        private GroupBox grpDepartment;
        private ComboBox cmbMonth;
        private DataGridView dgvAttendance;
        private TextBox txtEmployeeName;
        private TextBox txtName;
        private ComboBox cmbYear;
    }
}
