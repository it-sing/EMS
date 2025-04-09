namespace EmployeeManagamentSystem
{
    partial class frmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label3 = new Label();
            btnsignin = new Button();
            lnkRegisterLink = new LinkLabel();
            btnsignup = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(212, 42);
            label1.Name = "label1";
            label1.Size = new Size(203, 60);
            label1.TabIndex = 0;
            label1.Text = "SIGN IN ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(87, 153);
            label2.Name = "label2";
            label2.Size = new Size(104, 28);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.White;
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.ForeColor = Color.Gray;
            txtUsername.Location = new Point(80, 195);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(461, 46);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.ForeColor = Color.Gray;
            txtPassword.Location = new Point(80, 297);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(461, 45);
            txtPassword.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(87, 256);
            label3.Name = "label3";
            label3.Size = new Size(97, 28);
            label3.TabIndex = 3;
            label3.Text = "Password";
            // 
            // btnsignin
            // 
            btnsignin.BackColor = SystemColors.HotTrack;
            btnsignin.FlatStyle = FlatStyle.Flat;
            btnsignin.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnsignin.ForeColor = Color.White;
            btnsignin.Location = new Point(115, 445);
            btnsignin.Name = "btnsignin";
            btnsignin.Size = new Size(188, 46);
            btnsignin.TabIndex = 5;
            btnsignin.Text = "Sign in";
            btnsignin.UseVisualStyleBackColor = false;
            btnsignin.Click += btnLogin_Click;
            // 
            // lnkRegisterLink
            // 
            lnkRegisterLink.AutoSize = true;
            lnkRegisterLink.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lnkRegisterLink.LinkColor = SystemColors.HotTrack;
            lnkRegisterLink.Location = new Point(240, 388);
            lnkRegisterLink.Name = "lnkRegisterLink";
            lnkRegisterLink.Size = new Size(138, 23);
            lnkRegisterLink.TabIndex = 17;
            lnkRegisterLink.TabStop = true;
            lnkRegisterLink.Text = "Forgot Password";
            lnkRegisterLink.LinkClicked += lnkRegisterLink_LinkClicked;
            // 
            // btnsignup
            // 
            btnsignup.BackColor = Color.White;
            btnsignup.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnsignup.ForeColor = SystemColors.HotTrack;
            btnsignup.Location = new Point(322, 445);
            btnsignup.Name = "btnsignup";
            btnsignup.Size = new Size(188, 46);
            btnsignup.TabIndex = 18;
            btnsignup.Text = "Sign up";
            btnsignup.UseVisualStyleBackColor = false;
            btnsignup.Click += btnsignup_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(633, 553);
            Controls.Add(btnsignup);
            Controls.Add(lnkRegisterLink);
            Controls.Add(btnsignin);
            Controls.Add(txtPassword);
            Controls.Add(label3);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = Color.White;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login Form";
            Load += frmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label3;
        private Button btnsignin;
        private LinkLabel lnkRegisterLink;
        private Button btnsignup;
    }
}