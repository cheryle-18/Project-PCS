﻿
namespace Bookstore
{
    partial class FormCariPO
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
            this.label4 = new System.Windows.Forms.Label();
            this.tbCari = new System.Windows.Forms.TextBox();
            this.dgPO = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.btnPilih = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgPO)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 21);
            this.label4.TabIndex = 112;
            this.label4.Text = "Kata Kunci :";
            // 
            // tbCari
            // 
            this.tbCari.Location = new System.Drawing.Point(112, 74);
            this.tbCari.Name = "tbCari";
            this.tbCari.Size = new System.Drawing.Size(396, 29);
            this.tbCari.TabIndex = 111;
            this.tbCari.Text = "Kode / Nomor Nota Pre-Order";
            this.tbCari.TextChanged += new System.EventHandler(this.tbCari_TextChanged);
            // 
            // dgPO
            // 
            this.dgPO.AllowUserToAddRows = false;
            this.dgPO.AllowUserToDeleteRows = false;
            this.dgPO.AllowUserToResizeColumns = false;
            this.dgPO.AllowUserToResizeRows = false;
            this.dgPO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPO.Location = new System.Drawing.Point(21, 121);
            this.dgPO.Name = "dgPO";
            this.dgPO.ReadOnly = true;
            this.dgPO.RowHeadersVisible = false;
            this.dgPO.RowHeadersWidth = 51;
            this.dgPO.RowTemplate.Height = 24;
            this.dgPO.Size = new System.Drawing.Size(805, 429);
            this.dgPO.TabIndex = 110;
            this.dgPO.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPO_CellClick);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Navy;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(21, 560);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 38);
            this.button3.TabIndex = 109;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnPilih
            // 
            this.btnPilih.BackColor = System.Drawing.Color.Navy;
            this.btnPilih.FlatAppearance.BorderSize = 0;
            this.btnPilih.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPilih.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPilih.ForeColor = System.Drawing.Color.White;
            this.btnPilih.Location = new System.Drawing.Point(683, 560);
            this.btnPilih.Name = "btnPilih";
            this.btnPilih.Size = new System.Drawing.Size(143, 38);
            this.btnPilih.TabIndex = 108;
            this.btnPilih.Text = "Pilih";
            this.btnPilih.UseVisualStyleBackColor = false;
            this.btnPilih.Click += new System.EventHandler(this.btnPilih_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 30);
            this.label3.TabIndex = 107;
            this.label3.Text = "Cari Pre-Order";
            // 
            // FormCariPO
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(844, 611);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbCari);
            this.Controls.Add(this.dgPO);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnPilih);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormCariPO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCariPO";
            this.Load += new System.EventHandler(this.FormCariPO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCari;
        private System.Windows.Forms.DataGridView dgPO;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnPilih;
        private System.Windows.Forms.Label label3;
    }
}