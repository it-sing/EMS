﻿namespace EmployeeManagamentSystem
{
    partial class frmAbout
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
            lblProductName = new Label();
            lblCompany = new Label();
            lblVersion = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.BackColor = Color.Transparent;
            lblProductName.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductName.ForeColor = SystemColors.HotTrack;
            lblProductName.Location = new Point(50, 31);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(628, 54);
            lblProductName.TabIndex = 0;
            lblProductName.Text = "Employee Management System ";
            // 
            // lblCompany
            // 
            lblCompany.AutoSize = true;
            lblCompany.BackColor = Color.White;
            lblCompany.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompany.ForeColor = SystemColors.HotTrack;
            lblCompany.Location = new Point(65, 386);
            lblCompany.Name = "lblCompany";
            lblCompany.Size = new Size(303, 46);
            lblCompany.TabIndex = 1;
            lblCompany.Text = "E7 G25 RUPP CSD";
            lblCompany.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.BackColor = Color.Transparent;
            lblVersion.FlatStyle = FlatStyle.Flat;
            lblVersion.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVersion.ForeColor = SystemColors.ControlDarkDark;
            lblVersion.Location = new Point(65, 97);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(94, 28);
            lblVersion.TabIndex = 2;
            lblVersion.Text = "Version 1";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.EMS_11;
            pictureBox1.Location = new Point(32, 163);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(456, 170);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // frmAbout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(837, 469);
            Controls.Add(pictureBox1);
            Controls.Add(lblVersion);
            Controls.Add(lblCompany);
            Controls.Add(lblProductName);
            ForeColor = Color.White;
            Name = "frmAbout";
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProductName;
        private Label lblCompany;
        private Label lblVersion;
        private PictureBox pictureBox1;
    }
}