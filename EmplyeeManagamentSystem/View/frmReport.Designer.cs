namespace EmployeeManagamentSystem.View
{
    partial class frmReport
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            grpDepartment = new GroupBox();
            label1 = new Label();
            dgvAttendance = new DataGridView();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            dateTimePicker1 = new DateTimePicker();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            dateTimePicker2 = new DateTimePicker();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            materialButton2 = new MaterialSkin.Controls.MaterialButton();
            grpDepartment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            SuspendLayout();
            // 
            // grpDepartment
            // 
            grpDepartment.Controls.Add(materialButton2);
            grpDepartment.Controls.Add(materialButton1);
            grpDepartment.Controls.Add(dateTimePicker2);
            grpDepartment.Controls.Add(materialLabel2);
            grpDepartment.Controls.Add(dateTimePicker1);
            grpDepartment.Controls.Add(materialLabel1);
            grpDepartment.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDepartment.ForeColor = Color.FromArgb(64, 64, 64);
            grpDepartment.Location = new Point(12, 72);
            grpDepartment.Name = "grpDepartment";
            grpDepartment.Size = new Size(1022, 82);
            grpDepartment.TabIndex = 50;
            grpDepartment.TabStop = false;
            grpDepartment.Text = "Filter";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(203, 60);
            label1.TabIndex = 51;
            label1.Text = "SIGN IN ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvAttendance
            // 
            dgvAttendance.AllowUserToAddRows = false;
            dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAttendance.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAttendance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAttendance.ColumnHeadersHeight = 40;
            dgvAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAttendance.GridColor = Color.FromArgb(64, 64, 64);
            dgvAttendance.Location = new Point(12, 160);
            dgvAttendance.Name = "dgvAttendance";
            dgvAttendance.ReadOnly = true;
            dgvAttendance.RowHeadersWidth = 61;
            dgvAttendance.RowTemplate.Height = 40;
            dgvAttendance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAttendance.Size = new Size(1022, 465);
            dgvAttendance.TabIndex = 52;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(22, 43);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(84, 19);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Start Date : ";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(112, 33);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 34);
            dateTimePicker1.TabIndex = 1;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(378, 43);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(77, 19);
            materialLabel2.TabIndex = 2;
            materialLabel2.Text = "End Date : ";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(461, 33);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 34);
            dateTimePicker2.TabIndex = 3;
            // 
            // materialButton1
            // 
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(728, 31);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(123, 36);
            materialButton1.TabIndex = 4;
            materialButton1.Text = "Show Report";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            // 
            // materialButton2
            // 
            materialButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton2.Depth = 0;
            materialButton2.HighEmphasis = true;
            materialButton2.Icon = null;
            materialButton2.Location = new Point(859, 31);
            materialButton2.Margin = new Padding(4, 6, 4, 6);
            materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton2.Name = "materialButton2";
            materialButton2.NoAccentTextColor = Color.Empty;
            materialButton2.Size = new Size(108, 36);
            materialButton2.TabIndex = 53;
            materialButton2.Text = "Export CSV";
            materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton2.UseAccentColor = false;
            materialButton2.UseVisualStyleBackColor = true;
            materialButton2.Click += materialButton2_Click;
            // 
            // frmReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1053, 637);
            Controls.Add(dgvAttendance);
            Controls.Add(label1);
            Controls.Add(grpDepartment);
            Name = "frmReport";
            Text = "frmReport";
            grpDepartment.ResumeLayout(false);
            grpDepartment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpDepartment;
        private Label label1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private DateTimePicker dateTimePicker1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private DataGridView dgvAttendance;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private DateTimePicker dateTimePicker2;
    }
}