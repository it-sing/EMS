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
            label1 = new Label();
            dgvUsers = new DataGridView();
            grpDepartment = new GroupBox();
            cmbFilterByRoles = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            grpDepartment.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(39, 20);
            label1.Name = "label1";
            label1.Size = new Size(92, 46);
            label1.TabIndex = 6;
            label1.Text = "User";
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(27, 148);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1042, 435);
            dgvUsers.TabIndex = 46;
            // 
            // grpDepartment
            // 
            grpDepartment.Controls.Add(cmbFilterByRoles);
            grpDepartment.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDepartment.Location = new Point(713, 36);
            grpDepartment.Name = "grpDepartment";
            grpDepartment.Size = new Size(356, 93);
            grpDepartment.TabIndex = 47;
            grpDepartment.TabStop = false;
            grpDepartment.Text = "Fillter By Role";
            // 
            // cmbFilterByRoles
            // 
            cmbFilterByRoles.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterByRoles.FormattingEnabled = true;
            cmbFilterByRoles.Location = new Point(18, 34);
            cmbFilterByRoles.Name = "cmbFilterByRoles";
            cmbFilterByRoles.Size = new Size(322, 36);
            cmbFilterByRoles.TabIndex = 0;
            cmbFilterByRoles.SelectedIndexChanged += cmbFilterByRoles_SelectedIndexChanged;
            // 
            // frmUserManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1105, 609);
            Controls.Add(grpDepartment);
            Controls.Add(dgvUsers);
            Controls.Add(label1);
            Name = "frmUserManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "User";
            Text = "UserManagement";
            Load += frmUserManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            grpDepartment.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private ErrorProvider errProvider;
        private DataGridView dgvUsers;
        private GroupBox grpDepartment;
        private ComboBox cmbFilterByRoles;
    }
}