using System.ComponentModel;

namespace EmployeeManagamentSystem
{
    partial class frmRegister
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
            btnsignup = new Button();
            txtEmail = new TextBox();
            label3 = new Label();
            txtUsername = new TextBox();
            label2 = new Label();
            txtPassword = new TextBox();
            label4 = new Label();
            errProvider = new ErrorProvider(components);
            label1 = new Label();
            btnsignin = new Button();
            ((ISupportInitialize)errProvider).BeginInit();
            SuspendLayout();
            // 
            // btnsignup
            // 
            btnsignup.BackColor = SystemColors.HotTrack;
            btnsignup.FlatStyle = FlatStyle.Flat;
            btnsignup.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnsignup.ForeColor = Color.White;
            btnsignup.Location = new Point(176, 528);
            btnsignup.Name = "btnsignup";
            btnsignup.Size = new Size(180, 46);
            btnsignup.TabIndex = 11;
            btnsignup.Text = "Sign up";
            btnsignup.UseVisualStyleBackColor = false;
            btnsignup.Click += btnLogin_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(146, 307);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(461, 46);
            txtEmail.TabIndex = 10;
            txtEmail.Tag = "Email";
            txtEmail.Validating += txt_Validating;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(164, 265);
            label3.Name = "label3";
            label3.Size = new Size(60, 28);
            label3.TabIndex = 9;
            label3.Text = "Email";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(146, 206);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(461, 46);
            txtUsername.TabIndex = 8;
            txtUsername.Tag = "Username";
            txtUsername.Validating += txt_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(157, 164);
            label2.Name = "label2";
            label2.Size = new Size(104, 28);
            label2.TabIndex = 7;
            label2.Text = "Username";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(146, 416);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(461, 46);
            txtPassword.TabIndex = 13;
            txtPassword.Tag = "Password";
            txtPassword.Validating += txt_Validating;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(164, 375);
            label4.Name = "label4";
            label4.Size = new Size(97, 28);
            label4.TabIndex = 12;
            label4.Text = "Password";
            // 
            // errProvider
            // 
            errProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errProvider.ContainerControl = this;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(277, 53);
            label1.Name = "label1";
            label1.Size = new Size(201, 60);
            label1.TabIndex = 17;
            label1.Text = "SIGN UP";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnsignin
            // 
            btnsignin.BackColor = Color.White;
            btnsignin.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnsignin.ForeColor = SystemColors.HotTrack;
            btnsignin.Location = new Point(400, 528);
            btnsignin.Name = "btnsignin";
            btnsignin.Size = new Size(180, 46);
            btnsignin.TabIndex = 18;
            btnsignin.Text = "Sign in";
            btnsignin.UseVisualStyleBackColor = false;
            btnsignin.Click += btnSignIn_Click;
            // 
            // frmRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(754, 635);
            Controls.Add(btnsignin);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(label4);
            Controls.Add(btnsignup);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Name = "frmRegister";
            Text = "Register";
            ((ISupportInitialize)errProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button btnsignup;
        private TextBox txtEmail;
        private Label label3;
        private TextBox txtUsername;
        private Label label2;
        private TextBox txtPassword;
        private Label label4;
        private ErrorProvider errProvider;
        private Label label1;
        private Button btnsignin;
    }
}