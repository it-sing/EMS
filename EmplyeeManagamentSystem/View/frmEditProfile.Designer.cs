namespace EmployeeManagamentSystem
{
    partial class frmEditProfile
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
            components = new System.ComponentModel.Container();
            grpEmployees = new GroupBox();
            btnSubmit = new Button();
            txtUsername = new TextBox();
            label7 = new Label();
            dtpEmployemntDate = new DateTimePicker();
            label6 = new Label();
            dtpDateOfBirth = new DateTimePicker();
            label5 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtFirstname = new TextBox();
            label3 = new Label();
            txtLastName = new TextBox();
            label2 = new Label();
            txtEmployeeID = new TextBox();
            label1 = new Label();
            errProvider = new ErrorProvider(components);
            grpEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errProvider).BeginInit();
            SuspendLayout();
            // 
            // grpEmployees
            // 
            grpEmployees.Controls.Add(btnSubmit);
            grpEmployees.Controls.Add(txtUsername);
            grpEmployees.Controls.Add(label7);
            grpEmployees.Controls.Add(dtpEmployemntDate);
            grpEmployees.Controls.Add(label6);
            grpEmployees.Controls.Add(dtpDateOfBirth);
            grpEmployees.Controls.Add(label5);
            grpEmployees.Controls.Add(txtEmail);
            grpEmployees.Controls.Add(label4);
            grpEmployees.Controls.Add(txtFirstname);
            grpEmployees.Controls.Add(label3);
            grpEmployees.Controls.Add(txtLastName);
            grpEmployees.Controls.Add(label2);
            grpEmployees.Controls.Add(txtEmployeeID);
            grpEmployees.Controls.Add(label1);
            grpEmployees.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpEmployees.ForeColor = Color.FromArgb(64, 64, 64);
            grpEmployees.Location = new Point(23, 12);
            grpEmployees.Name = "grpEmployees";
            grpEmployees.Size = new Size(1026, 630);
            grpEmployees.TabIndex = 2;
            grpEmployees.TabStop = false;
            grpEmployees.Text = "Profile Detail";
            grpEmployees.Enter += grpEmployees_Enter;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = SystemColors.HotTrack;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(441, 548);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(141, 50);
            btnSubmit.TabIndex = 34;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtUsername.ForeColor = Color.FromArgb(64, 64, 64);
            txtUsername.Location = new Point(41, 215);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new Size(398, 50);
            txtUsername.TabIndex = 33;
            txtUsername.Tag = "First Name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label7.Location = new Point(44, 183);
            label7.Name = "label7";
            label7.Size = new Size(104, 28);
            label7.TabIndex = 32;
            label7.Text = "Username";
            // 
            // dtpEmployemntDate
            // 
            dtpEmployemntDate.CalendarFont = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpEmployemntDate.Font = new Font("Segoe UI", 18F);
            dtpEmployemntDate.Location = new Point(598, 411);
            dtpEmployemntDate.Name = "dtpEmployemntDate";
            dtpEmployemntDate.Size = new Size(398, 47);
            dtpEmployemntDate.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(598, 380);
            label6.Name = "label6";
            label6.Size = new Size(175, 28);
            label6.TabIndex = 30;
            label6.Text = "Employment Date";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Font = new Font("Segoe UI", 18F);
            dtpDateOfBirth.Location = new Point(598, 312);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(398, 47);
            dtpDateOfBirth.TabIndex = 29;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(598, 281);
            label5.Name = "label5";
            label5.Size = new Size(129, 28);
            label5.TabIndex = 28;
            label5.Text = "Date of Birth";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtEmail.ForeColor = Color.FromArgb(64, 64, 64);
            txtEmail.Location = new Point(598, 215);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(398, 50);
            txtEmail.TabIndex = 27;
            txtEmail.Tag = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(598, 183);
            label4.Name = "label4";
            label4.Size = new Size(60, 28);
            label4.TabIndex = 26;
            label4.Text = "Email";
            // 
            // txtFirstname
            // 
            txtFirstname.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtFirstname.ForeColor = Color.FromArgb(64, 64, 64);
            txtFirstname.Location = new Point(41, 312);
            txtFirstname.Multiline = true;
            txtFirstname.Name = "txtFirstname";
            txtFirstname.Size = new Size(398, 50);
            txtFirstname.TabIndex = 17;
            txtFirstname.Tag = "First Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(41, 286);
            label3.Name = "label3";
            label3.Size = new Size(110, 28);
            label3.TabIndex = 16;
            label3.Text = "First Name";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtLastName.ForeColor = Color.FromArgb(64, 64, 64);
            txtLastName.Location = new Point(41, 411);
            txtLastName.Multiline = true;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(398, 50);
            txtLastName.TabIndex = 15;
            txtLastName.Tag = "Last Name";
            txtLastName.TextChanged += txtLastName_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(44, 385);
            label2.Name = "label2";
            label2.Size = new Size(108, 28);
            label2.TabIndex = 14;
            label2.Text = "Last Name";
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtEmployeeID.ForeColor = Color.FromArgb(64, 64, 64);
            txtEmployeeID.Location = new Point(41, 116);
            txtEmployeeID.Multiline = true;
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.ReadOnly = true;
            txtEmployeeID.Size = new Size(904, 50);
            txtEmployeeID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(44, 80);
            label1.Name = "label1";
            label1.Size = new Size(121, 28);
            label1.TabIndex = 0;
            label1.Text = "EmployeeID";
            // 
            // errProvider
            // 
            errProvider.ContainerControl = this;
            // 
            // frmEditProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 654);
            Controls.Add(grpEmployees);
            Name = "frmEditProfile";
            StartPosition = FormStartPosition.CenterParent;
            Tag = "Edit Profile";
            Text = "Edit Profile";
            Load += frmEditProfile_Load;
            grpEmployees.ResumeLayout(false);
            grpEmployees.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpEmployees;
        private DateTimePicker dtpEmployemntDate;
        private Label label6;
        private DateTimePicker dtpDateOfBirth;
        private Label label5;
        private TextBox txtEmail;
        private Label label4;
        private TextBox txtFirstname;
        private Label label3;
        private TextBox txtLastName;
        private Label label2;
        private TextBox txtEmployeeID;
        private Label label1;
        private TextBox txtUsername;
        private Label label7;
        private Button btnSubmit;
        private ErrorProvider errProvider;
    }
}