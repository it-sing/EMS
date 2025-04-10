namespace EmployeeManagamentSystem.View
{
    partial class frmForgotPassword
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
            btnsignin = new Button();
            txtPassword = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnsubmit = new Button();
            SuspendLayout();
            // 
            // btnsignin
            // 
            btnsignin.BackColor = Color.White;
            btnsignin.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnsignin.ForeColor = SystemColors.HotTrack;
            btnsignin.Location = new Point(336, 409);
            btnsignin.Name = "btnsignin";
            btnsignin.Size = new Size(188, 46);
            btnsignin.TabIndex = 26;
            btnsignin.Text = "Sign in";
            btnsignin.UseVisualStyleBackColor = false;
            btnsignin.Click += btnsignin_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.ForeColor = Color.Gray;
            txtPassword.Location = new Point(94, 303);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(461, 45);
            txtPassword.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(94, 262);
            label3.Name = "label3";
            label3.Size = new Size(97, 28);
            label3.TabIndex = 22;
            label3.Text = "Password";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.ForeColor = Color.Gray;
            txtEmail.Location = new Point(94, 213);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(461, 46);
            txtEmail.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(105, 172);
            label2.Name = "label2";
            label2.Size = new Size(60, 28);
            label2.TabIndex = 20;
            label2.Text = "Email";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(129, 60);
            label1.Name = "label1";
            label1.Size = new Size(383, 60);
            label1.TabIndex = 19;
            label1.Text = "REST PASSWORD";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnsubmit
            // 
            btnsubmit.BackColor = SystemColors.HotTrack;
            btnsubmit.FlatStyle = FlatStyle.Flat;
            btnsubmit.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnsubmit.ForeColor = Color.White;
            btnsubmit.Location = new Point(114, 409);
            btnsubmit.Name = "btnsubmit";
            btnsubmit.Size = new Size(188, 46);
            btnsubmit.TabIndex = 27;
            btnsubmit.Text = "Submit";
            btnsubmit.UseVisualStyleBackColor = false;
            btnsubmit.Click += btnsubmit_Click;
            // 
            // frmForgotPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(649, 506);
            Controls.Add(btnsubmit);
            Controls.Add(btnsignin);
            Controls.Add(txtPassword);
            Controls.Add(label3);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmForgotPassword";
            Text = "Forgot Password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnsignin;
        private LinkLabel lnkRegisterLink;
        private TextBox txtPassword;
        private Label label3;
        private TextBox txtEmail;
        private Label label2;
        private Label label1;
        private Button btnsubmit;
    }
}