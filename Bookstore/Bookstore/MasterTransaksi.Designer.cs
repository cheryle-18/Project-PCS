
namespace Bookstore
{
    partial class MasterTransaksi
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
            this.components = new System.ComponentModel.Container();
            this.kryptonPaletteForm = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbDesc = new System.Windows.Forms.RadioButton();
            this.rbAsc = new System.Windows.Forms.RadioButton();
            this.btnReset = new System.Windows.Forms.Button();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpSampai = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDari = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCari = new System.Windows.Forms.TextBox();
            this.btnTransBaru = new System.Windows.Forms.Button();
            this.btnDetail = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvTransaksi = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaksi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.rbDesc);
            this.panel2.Controls.Add(this.rbAsc);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.cmbSort);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtpSampai);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dtpDari);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tbCari);
            this.panel2.Controls.Add(this.btnTransBaru);
            this.panel2.Controls.Add(this.btnDetail);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dgvTransaksi);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1050, 621);
            this.panel2.TabIndex = 17;
            // 
            // rbDesc
            // 
            this.rbDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbDesc.AutoSize = true;
            this.rbDesc.Location = new System.Drawing.Point(817, 114);
            this.rbDesc.Name = "rbDesc";
            this.rbDesc.Size = new System.Drawing.Size(64, 24);
            this.rbDesc.TabIndex = 49;
            this.rbDesc.TabStop = true;
            this.rbDesc.Text = "Desc";
            this.rbDesc.UseVisualStyleBackColor = true;
            this.rbDesc.CheckedChanged += new System.EventHandler(this.rbDesc_CheckedChanged);
            // 
            // rbAsc
            // 
            this.rbAsc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbAsc.AutoSize = true;
            this.rbAsc.Location = new System.Drawing.Point(758, 114);
            this.rbAsc.Name = "rbAsc";
            this.rbAsc.Size = new System.Drawing.Size(54, 24);
            this.rbAsc.TabIndex = 48;
            this.rbAsc.TabStop = true;
            this.rbAsc.Text = "Asc";
            this.rbAsc.UseVisualStyleBackColor = true;
            this.rbAsc.CheckedChanged += new System.EventHandler(this.rbAsc_CheckedChanged);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.Navy;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(932, 73);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(95, 30);
            this.btnReset.TabIndex = 47;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cmbSort
            // 
            this.cmbSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Items.AddRange(new object[] {
            "Kode",
            "Invoice",
            "Tanggal",
            "Qty",
            "Total"});
            this.cmbSort.Location = new System.Drawing.Point(758, 75);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(168, 28);
            this.cmbSort.TabIndex = 46;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(589, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 20);
            this.label2.TabIndex = 45;
            this.label2.Text = "Urutkan Berdasarkan :";
            // 
            // dtpSampai
            // 
            this.dtpSampai.CustomFormat = "dd/MM/yyyy";
            this.dtpSampai.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSampai.Location = new System.Drawing.Point(367, 111);
            this.dtpSampai.Name = "dtpSampai";
            this.dtpSampai.Size = new System.Drawing.Size(200, 26);
            this.dtpSampai.TabIndex = 44;
            this.dtpSampai.ValueChanged += new System.EventHandler(this.dtpSampai_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(301, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 43;
            this.label6.Text = "sampai";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "Filter dari";
            // 
            // dtpDari
            // 
            this.dtpDari.CustomFormat = "dd/MM/yyyy";
            this.dtpDari.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDari.Location = new System.Drawing.Point(95, 111);
            this.dtpDari.Name = "dtpDari";
            this.dtpDari.Size = new System.Drawing.Size(200, 26);
            this.dtpDari.TabIndex = 41;
            this.dtpDari.ValueChanged += new System.EventHandler(this.dtpDari_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 40;
            this.label4.Text = "Cari :";
            // 
            // tbCari
            // 
            this.tbCari.Location = new System.Drawing.Point(64, 76);
            this.tbCari.Name = "tbCari";
            this.tbCari.Size = new System.Drawing.Size(503, 26);
            this.tbCari.TabIndex = 37;
            this.tbCari.TextChanged += new System.EventHandler(this.tbCari_TextChanged);
            // 
            // btnTransBaru
            // 
            this.btnTransBaru.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransBaru.BackColor = System.Drawing.Color.Navy;
            this.btnTransBaru.FlatAppearance.BorderSize = 0;
            this.btnTransBaru.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransBaru.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransBaru.ForeColor = System.Drawing.Color.White;
            this.btnTransBaru.Location = new System.Drawing.Point(735, 537);
            this.btnTransBaru.Name = "btnTransBaru";
            this.btnTransBaru.Size = new System.Drawing.Size(143, 38);
            this.btnTransBaru.TabIndex = 30;
            this.btnTransBaru.Text = "Transaksi Baru";
            this.btnTransBaru.UseVisualStyleBackColor = false;
            this.btnTransBaru.Click += new System.EventHandler(this.btnTransBaru_Click);
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetail.BackColor = System.Drawing.Color.Navy;
            this.btnDetail.FlatAppearance.BorderSize = 0;
            this.btnDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetail.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetail.ForeColor = System.Drawing.Color.White;
            this.btnDetail.Location = new System.Drawing.Point(884, 537);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(143, 38);
            this.btnDetail.TabIndex = 29;
            this.btnDetail.Text = "Lihat Detail";
            this.btnDetail.UseVisualStyleBackColor = false;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 30);
            this.label3.TabIndex = 14;
            this.label3.Text = "Daftar Transaksi";
            // 
            // dgvTransaksi
            // 
            this.dgvTransaksi.AllowUserToAddRows = false;
            this.dgvTransaksi.AllowUserToDeleteRows = false;
            this.dgvTransaksi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransaksi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransaksi.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvTransaksi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransaksi.Location = new System.Drawing.Point(17, 159);
            this.dgvTransaksi.Name = "dgvTransaksi";
            this.dgvTransaksi.ReadOnly = true;
            this.dgvTransaksi.RowHeadersVisible = false;
            this.dgvTransaksi.RowHeadersWidth = 51;
            this.dgvTransaksi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransaksi.Size = new System.Drawing.Size(1010, 355);
            this.dgvTransaksi.TabIndex = 1;
            this.dgvTransaksi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransaksi_CellClick);
            // 
            // MasterTransaksi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1042, 622);
            this.Controls.Add(this.panel2);
            this.Name = "MasterTransaksi";
            this.Palette = this.kryptonPaletteForm;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.Text = "MasterTransaksi";
            this.Load += new System.EventHandler(this.MasterTransaksi_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaksi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPaletteForm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpSampai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDari;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCari;
        private System.Windows.Forms.Button btnTransBaru;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvTransaksi;
        private System.Windows.Forms.RadioButton rbDesc;
        private System.Windows.Forms.RadioButton rbAsc;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}