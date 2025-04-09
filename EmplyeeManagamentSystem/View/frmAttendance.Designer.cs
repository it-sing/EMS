using System.Windows.Forms;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pictureBoxQRCode = new PictureBox();
            grpDepartment = new GroupBox();
            cmbYear = new ComboBox();
            cmbMonth = new ComboBox();
            dgvAttendance = new DataGridView();
            txtName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQRCode).BeginInit();
            grpDepartment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxQRCode
            // 
            pictureBoxQRCode.Location = new Point(106, 155);
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
            grpDepartment.ForeColor = Color.FromArgb(64, 64, 64);
            grpDepartment.Location = new Point(543, 54);
            grpDepartment.Name = "grpDepartment";
            grpDepartment.Size = new Size(416, 82);
            grpDepartment.TabIndex = 49;
            grpDepartment.TabStop = false;
            grpDepartment.Text = "Filter";
            // 
            // cmbYear
            // 
            cmbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYear.Font = new Font("Segoe UI", 12F);
            cmbYear.ForeColor = Color.FromArgb(64, 64, 64);
            cmbYear.FormattingEnabled = true;
            cmbYear.Location = new Point(221, 33);
            cmbYear.Name = "cmbYear";
            cmbYear.Size = new Size(183, 36);
            cmbYear.TabIndex = 1;
            cmbYear.SelectedIndexChanged += cmbYear_SelectedIndexChanged;
            // 
            // cmbMonth
            // 
            cmbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMonth.Font = new Font("Segoe UI", 12F);
            cmbMonth.ForeColor = Color.FromArgb(64, 64, 64);
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
            dgvAttendance.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAttendance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAttendance.ColumnHeadersHeight = 40;
            dgvAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAttendance.GridColor = Color.FromArgb(64, 64, 64);
            dgvAttendance.Location = new Point(404, 155);
            dgvAttendance.Name = "dgvAttendance";
            dgvAttendance.ReadOnly = true;
            dgvAttendance.RowHeadersWidth = 61;
            dgvAttendance.RowTemplate.Height = 40;
            dgvAttendance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAttendance.Size = new Size(555, 348);
            dgvAttendance.TabIndex = 48;
            // 
            // txtName
            // 
            txtName.BackColor = Color.White;
            txtName.Location = new Point(106, 318);
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(164, 27);
            txtName.TabIndex = 50;
            txtName.TextAlign = HorizontalAlignment.Center;
            // 
            // frmAttendance
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(971, 515);
            Controls.Add(txtName);
            Controls.Add(grpDepartment);
            Controls.Add(dgvAttendance);
            Controls.Add(pictureBoxQRCode);
            Name = "frmAttendance";
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmAttendance";
            FormClosing += FrmAttendance_FormClosing;
            Load += frmAttendance_Load;
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
