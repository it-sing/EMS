namespace EmployeeManagamentSystem
{
    partial class frmSplashScreen
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
            pgrLoadProgress = new ProgressBar();
            tmrProgressBar = new System.Windows.Forms.Timer(components);
            label2 = new Label();
            lblProgress = new Label();
            lblVersion = new Label();
            lblProductName = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pgrLoadProgress
            // 
            pgrLoadProgress.Location = new Point(75, 376);
            pgrLoadProgress.Name = "pgrLoadProgress";
            pgrLoadProgress.Size = new Size(501, 29);
            pgrLoadProgress.TabIndex = 1;
            // 
            // tmrProgressBar
            // 
            tmrProgressBar.Enabled = true;
            tmrProgressBar.Tick += tmrProgressBar_Tick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(206, 333);
            label2.Name = "label2";
            label2.Size = new Size(122, 28);
            label2.TabIndex = 2;
            label2.Text = "Loading.......";
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.BackColor = Color.Transparent;
            lblProgress.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProgress.ForeColor = Color.FromArgb(64, 64, 64);
            lblProgress.Location = new Point(334, 333);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(70, 28);
            lblProgress.TabIndex = 3;
            lblProgress.Text = "label3";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.BackColor = Color.Transparent;
            lblVersion.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVersion.ForeColor = Color.FromArgb(64, 64, 64);
            lblVersion.Location = new Point(271, 281);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(87, 25);
            lblVersion.TabIndex = 5;
            lblVersion.Text = "Version 1";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.BackColor = Color.Transparent;
            lblProductName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblProductName.ForeColor = SystemColors.HotTrack;
            lblProductName.Location = new Point(94, 32);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(458, 41);
            lblProductName.TabIndex = 4;
            lblProductName.Text = "Employee Management System";
            lblProductName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.EMS_1;
            pictureBox1.Location = new Point(44, 104);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(517, 156);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // frmSplashScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(616, 450);
            Controls.Add(pictureBox1);
            Controls.Add(lblVersion);
            Controls.Add(lblProductName);
            Controls.Add(lblProgress);
            Controls.Add(label2);
            Controls.Add(pgrLoadProgress);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmSplashScreen";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmSplashScreen";
            Load += frmSplashScreen_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ProgressBar pgrLoadProgress;
        private System.Windows.Forms.Timer tmrProgressBar;
        private Label label2;
        private Label lblProgress;
        private Label lblVersion;
        private Label lblProductName;
        private PictureBox pictureBox1;
    }
}