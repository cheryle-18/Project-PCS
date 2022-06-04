
namespace Bookstore
{
    partial class MasterMember
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMemberBaru = new System.Windows.Forms.Button();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.cmbArah = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCari = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgMember = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMember)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnMemberBaru);
            this.panel2.Controls.Add(this.btnDetail);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.cmbArah);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cmbSort);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbCari);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dgMember);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1050, 621);
            this.panel2.TabIndex = 19;
            // 
            // btnMemberBaru
            // 
            this.btnMemberBaru.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMemberBaru.BackColor = System.Drawing.Color.Navy;
            this.btnMemberBaru.FlatAppearance.BorderSize = 0;
            this.btnMemberBaru.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemberBaru.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberBaru.ForeColor = System.Drawing.Color.White;
            this.btnMemberBaru.Location = new System.Drawing.Point(687, 539);
            this.btnMemberBaru.Name = "btnMemberBaru";
            this.btnMemberBaru.Size = new System.Drawing.Size(182, 38);
            this.btnMemberBaru.TabIndex = 30;
            this.btnMemberBaru.Text = "Insert Member Baru";
            this.btnMemberBaru.UseVisualStyleBackColor = false;
            this.btnMemberBaru.Click += new System.EventHandler(this.btnMemberBaru_Click);
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetail.BackColor = System.Drawing.Color.Navy;
            this.btnDetail.FlatAppearance.BorderSize = 0;
            this.btnDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetail.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetail.ForeColor = System.Drawing.Color.White;
            this.btnDetail.Location = new System.Drawing.Point(885, 539);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(143, 38);
            this.btnDetail.TabIndex = 29;
            this.btnDetail.Text = "Lihat Detail";
            this.btnDetail.UseVisualStyleBackColor = false;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.Navy;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(932, 83);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(95, 30);
            this.btnReset.TabIndex = 25;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cmbArah
            // 
            this.cmbArah.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbArah.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArah.FormattingEnabled = true;
            this.cmbArah.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.cmbArah.Location = new System.Drawing.Point(798, 84);
            this.cmbArah.Name = "cmbArah";
            this.cmbArah.Size = new System.Drawing.Size(128, 33);
            this.cmbArah.TabIndex = 24;
            this.cmbArah.SelectedIndexChanged += new System.EventHandler(this.tbCari_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 25);
            this.label4.TabIndex = 23;
            this.label4.Text = "Cari Member :";
            // 
            // cmbSort
            // 
            this.cmbSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Items.AddRange(new object[] {
            "ID",
            "Nama",
            "Tanggal Lahir",
            "Alamat",
            "No Telepon",
            "Point",
            "Status"});
            this.cmbSort.Location = new System.Drawing.Point(624, 84);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(168, 33);
            this.cmbSort.TabIndex = 19;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.tbCari_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(455, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Urutkan Berdasarkan :";
            // 
            // tbCari
            // 
            this.tbCari.Location = new System.Drawing.Point(140, 84);
            this.tbCari.Name = "tbCari";
            this.tbCari.Size = new System.Drawing.Size(309, 30);
            this.tbCari.TabIndex = 15;
            this.tbCari.TextChanged += new System.EventHandler(this.tbCari_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 37);
            this.label3.TabIndex = 14;
            this.label3.Text = "Daftar Member";
            // 
            // dgMember
            // 
            this.dgMember.AllowUserToAddRows = false;
            this.dgMember.AllowUserToDeleteRows = false;
            this.dgMember.AllowUserToOrderColumns = true;
            this.dgMember.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMember.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMember.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMember.Location = new System.Drawing.Point(17, 128);
            this.dgMember.Name = "dgMember";
            this.dgMember.ReadOnly = true;
            this.dgMember.RowHeadersVisible = false;
            this.dgMember.RowHeadersWidth = 51;
            this.dgMember.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMember.Size = new System.Drawing.Size(1010, 403);
            this.dgMember.TabIndex = 1;
            this.dgMember.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMember_CellClick);
            this.dgMember.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgMember_CellFormatting);
            // 
            // MasterMember
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1042, 622);
            this.Controls.Add(this.panel2);
            this.Name = "MasterMember";
            this.Text = "MasterMember";
            this.Load += new System.EventHandler(this.MasterMember_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMember)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMemberBaru;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cmbArah;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCari;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgMember;
    }
}