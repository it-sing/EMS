using System.Diagnostics;
using System.Windows.Forms;

namespace EmployeeManagamentSystem
{
    partial class frmUserManagement
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
            dgvUsers = new DataGridView();
            grpDepartment = new GroupBox();
            cmbFilterByRoles = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            grpDepartment.SuspendLayout();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsers.ColumnHeadersHeight = 50;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.GridColor = Color.FromArgb(64, 64, 64);
            dgvUsers.Location = new Point(4, 174);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 60;
            dgvUsers.RowTemplate.Height = 40;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvUsers.Size = new Size(1388, 508);
            dgvUsers.TabIndex = 46;
            // 
            // grpDepartment
            // 
            grpDepartment.Controls.Add(cmbFilterByRoles);
            grpDepartment.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDepartment.ForeColor = Color.FromArgb(64, 64, 64);
            grpDepartment.Location = new Point(1000, 32);
            grpDepartment.Name = "grpDepartment";
            grpDepartment.Size = new Size(383, 97);
            grpDepartment.TabIndex = 47;
            grpDepartment.TabStop = false;
            grpDepartment.Text = "Fillter By Role";
            // 
            // cmbFilterByRoles
            // 
            cmbFilterByRoles.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterByRoles.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbFilterByRoles.FormattingEnabled = true;
            cmbFilterByRoles.Location = new Point(31, 42);
            cmbFilterByRoles.Name = "cmbFilterByRoles";
            cmbFilterByRoles.Size = new Size(322, 36);
            cmbFilterByRoles.TabIndex = 0;
            cmbFilterByRoles.SelectedIndexChanged += cmbFilterByRoles_SelectedIndexChanged;
            // 
            // frmUserManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1395, 682);
            Controls.Add(grpDepartment);
            Controls.Add(dgvUsers);
            Name = "frmUserManagement";
            StartPosition = FormStartPosition.CenterParent;
            Tag = "User";
            Text = "User Management";
            Load += frmUserManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            grpDepartment.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ErrorProvider errProvider;
        private DataGridView dgvUsers;
        private GroupBox grpDepartment;
        private ComboBox cmbFilterByRoles;
    }
}