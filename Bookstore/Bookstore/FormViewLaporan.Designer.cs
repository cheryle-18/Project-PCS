
namespace Bookstore
{
    partial class FormViewLaporan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnMemberBaru = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.crViewLaporan = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnMemberBaru);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1041, 617);
            this.panel1.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BackColor = System.Drawing.Color.Navy;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(875, 553);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(153, 38);
            this.btnBack.TabIndex = 52;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnMemberBaru
            // 
            this.btnMemberBaru.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMemberBaru.BackColor = System.Drawing.Color.Navy;
            this.btnMemberBaru.FlatAppearance.BorderSize = 0;
            this.btnMemberBaru.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemberBaru.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberBaru.ForeColor = System.Drawing.Color.White;
            this.btnMemberBaru.Location = new System.Drawing.Point(764, 83);
            this.btnMemberBaru.Name = "btnMemberBaru";
            this.btnMemberBaru.Size = new System.Drawing.Size(153, 28);
            this.btnMemberBaru.TabIndex = 50;
            this.btnMemberBaru.Text = "Tampilkan";
            this.btnMemberBaru.UseVisualStyleBackColor = false;
            this.btnMemberBaru.Click += new System.EventHandler(this.btnMemberBaru_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1035, 37);
            this.label3.TabIndex = 49;
            this.label3.Text = "Laporan <Nama Laporan>";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(539, 83);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(219, 29);
            this.dateTimePicker2.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(468, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 21);
            this.label6.TabIndex = 47;
            this.label6.Text = "sampai";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(117, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 21);
            this.label5.TabIndex = 46;
            this.label5.Text = "Tampilkan dari";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(244, 83);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(218, 29);
            this.dateTimePicker1.TabIndex = 45;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.crViewLaporan);
            this.panel2.Location = new System.Drawing.Point(65, 147);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(895, 376);
            this.panel2.TabIndex = 14;
            // 
            // crViewLaporan
            // 
            this.crViewLaporan.ActiveViewIndex = -1;
            this.crViewLaporan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crViewLaporan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crViewLaporan.Cursor = System.Windows.Forms.Cursors.Default;
            this.crViewLaporan.Location = new System.Drawing.Point(0, 0);
            this.crViewLaporan.Name = "crViewLaporan";
            this.crViewLaporan.Size = new System.Drawing.Size(895, 376);
            this.crViewLaporan.TabIndex = 0;
            // 
            // FormViewLaporan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1040, 603);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormViewLaporan";
            this.Text = "FormViewLaporan";
            this.Load += new System.EventHandler(this.FormViewLaporan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crViewLaporan;
        private System.Windows.Forms.Button btnMemberBaru;
        private System.Windows.Forms.Button btnBack;
    }
}