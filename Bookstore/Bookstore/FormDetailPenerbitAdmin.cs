﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore
{
    public partial class FormDetailPenerbitAdmin : Form
    {
        string id_penerbit;
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private DataTable dt;
        private string command_querry;
        public FormDetailPenerbitAdmin(string id)
        {
            InitializeComponent();
            id_penerbit = id;
            command_querry = $"SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',GROUP_CONCAT(c.C_NAME SEPARATOR ',')AS 'Kategori',CONCAT('Rp ',FORMAT(b.B_PRICE,0, 'de_DE')) AS 'Harga', b.B_STOCK AS 'Stok', (CASE WHEN b.B_STATUS=1 THEN 'Tersedia' ELSE 'Tidak Tersedia' END) AS 'Status' FROM book b, publisher p, book_category bc,category c WHERE b.B_STATUS <> 2 AND b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND p.P_ID = '{id_penerbit}' GROUP BY b.`B_ID` ORDER BY b.B_ID ASC;";
            connects();
            refreshDgv(command_querry);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                int stat = 0;
                if (radAda.Checked)
                {
                    stat = 1;
                }
                string query = "UPDATE publisher " +
                                $"SET P_NAME = '{tbNama.Text}',P_ADDRESS = '{tbAlamat.Text}',P_TELP = '{tbTelp.Text}',P_STATUS = {stat} WHERE P_ID = '{id_penerbit}' ";
                cmd = new MySqlCommand(query, Koneksi.getConn());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Berhasil Update");

                MasterPenerbitAdmin frm = new MasterPenerbitAdmin();
                Panel temp = (Panel)frm.Controls[0];
                temp.Width = panel1.Width;
                temp.Height = panel1.Height;
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(temp);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Gagal Update \n"+ ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MasterPenerbitAdmin frm = new MasterPenerbitAdmin();
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel1.Width;
            temp.Height = panel1.Height;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(temp);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void connects()
        {
            try
            {
                dt = new DataTable();
                string query = $"SELECT P_ID,P_NAME,P_ADDRESS,P_TELP,P_STATUS FROM publisher WHERE P_ID = '{id_penerbit}';";
                cmd = new MySqlCommand(query, Koneksi.getConn());
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                tbKode.Text = dt.Rows[0][0].ToString();
                tbNama.Text = dt.Rows[0][1].ToString();
                tbAlamat.Text = dt.Rows[0][2].ToString();
                tbTelp.Text = dt.Rows[0][3].ToString();

                if (Convert.ToInt32(dt.Rows[0][4]) == 1)
                {
                    radAda.Checked = true;
                    radTAda.Checked = false;
                }
                else
                {
                    radAda.Checked = false;
                    radTAda.Checked = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void refreshDgv(string command)
        {
            try
            {
                da = new MySqlDataAdapter();
                cmd = new MySqlCommand(command, Koneksi.getConn());
                dt = new DataTable();
                da.SelectCommand = cmd;

                da.Fill(dt);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
                da.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArah.SelectedIndex > -1 && cmbSort.SelectedIndex > -1)
            {
                string order = "ASC";
                int kolom = 0;
                string cmd = "";
                if (cmbArah.SelectedIndex == 0)
                {
                    order = "ASC";
                }
                else if (cmbArah.SelectedIndex == 1)
                {
                    order = "DESC";
                }
                if (cmbSort.SelectedIndex < 3)
                {
                    if (cmbSort.SelectedIndex == 0)
                    {
                        kolom = 1;
                    }
                    else if (cmbSort.SelectedIndex == 1)
                    {
                        kolom = 2;
                    }
                    else if (cmbSort.SelectedIndex == 2)
                    {
                        kolom = 3;
                    }

                    cmd = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',GROUP_CONCAT(c.C_NAME SEPARATOR ',')AS 'Kategori',CONCAT('Rp ',FORMAT(b.B_PRICE,0, 'de_DE')) AS 'Harga', b.B_STOCK AS 'Stok', (CASE WHEN b.B_STATUS=1 THEN 'Tersedia' ELSE 'Tidak Tersedia' END) AS 'Status' " +
                                      "FROM book b,publisher p, book_category bc,category c " +
                                      $"WHERE b.B_STATUS = 1 AND b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND p.P_ID ='{id_penerbit}' GROUP BY b.`B_ID` ORDER BY {kolom} {order}; ";
                }
                else if (cmbSort.SelectedIndex >= 3)
                {
                    if (cmbSort.SelectedIndex == 3)
                    {
                        kolom = 6;
                        cmd = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',GROUP_CONCAT(c.C_NAME SEPARATOR ',')AS 'Kategori',CONCAT('Rp ',FORMAT(b.B_PRICE,0, 'de_DE')) AS 'Harga', b.B_STOCK AS 'Stok', (CASE WHEN b.B_STATUS=1 THEN 'Tersedia' ELSE 'Tidak Tersedia' END) AS 'Status' " +
                                  "FROM book b,publisher p, book_category bc,category c " +
                                  $"WHERE b.B_STATUS = 1 AND b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND p.P_ID ='{id_penerbit}' GROUP BY b.`B_ID` ORDER BY LENGTH(b.B_PRICE) {order}, b.B_PRICE {order}; ";
                    }
                    else if (cmbSort.SelectedIndex == 4)
                    {
                        kolom = 7;
                        cmd = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',GROUP_CONCAT(c.C_NAME SEPARATOR ',')AS 'Kategori',CONCAT('Rp ',FORMAT(b.B_PRICE,0, 'de_DE')) AS 'Harga', b.B_STOCK AS 'Stok', (CASE WHEN b.B_STATUS=1 THEN 'Tersedia' ELSE 'Tidak Tersedia' END) AS 'Status' " +
                                  "FROM book b,publisher p, book_category bc,category c " +
                                  $"WHERE b.B_STATUS = 1 AND b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND p.P_ID ='{id_penerbit}' GROUP BY b.`B_ID` ORDER BY LENGTH(b.B_STOCK) {order}, b.B_STOCK {order}; ";
                    }

                }

                refreshDgv(cmd);
            }
        }

        private void cmbArah_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSort.SelectedIndex > -1 && cmbArah.SelectedIndex > -1)
            {
                string order = "ASC";
                int kolom = 0;
                string cmd = "";                
                if (cmbArah.SelectedIndex == 0)
                {
                    order = "ASC";
                }
                else if (cmbArah.SelectedIndex == 1)
                {
                    order = "DESC";
                }
               if (cmbSort.SelectedIndex < 3)
                    {
                        if (cmbSort.SelectedIndex == 0)
                        {
                            kolom = 1;
                        }
                        else if (cmbSort.SelectedIndex == 1)
                        {
                            kolom = 2;
                        }
                        else if (cmbSort.SelectedIndex == 2)
                        {
                            kolom = 3;
                        }

                        cmd = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',GROUP_CONCAT(c.C_NAME SEPARATOR ',')AS 'Kategori',CONCAT('Rp ',FORMAT(b.B_PRICE,0, 'de_DE')) AS 'Harga', b.B_STOCK AS 'Stok', (CASE WHEN b.B_STATUS=1 THEN 'Tersedia' ELSE 'Tidak Tersedia' END) AS 'Status' " +
                                          "FROM book b,publisher p, book_category bc,category c " +
                                          $"WHERE b.B_STATUS = 1 AND b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND p.P_ID ='{id_penerbit}' GROUP BY b.`B_ID` ORDER BY {kolom} {order}; ";
                    }
                    else if (cmbSort.SelectedIndex >= 3)
                    {
                        if (cmbSort.SelectedIndex == 3)
                        {
                            kolom = 6;
                            cmd = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',GROUP_CONCAT(c.C_NAME SEPARATOR ',')AS 'Kategori',CONCAT('Rp ',FORMAT(b.B_PRICE,0, 'de_DE')) AS 'Harga', b.B_STOCK AS 'Stok', (CASE WHEN b.B_STATUS=1 THEN 'Tersedia' ELSE 'Tidak Tersedia' END) AS 'Status' " +
                                      "FROM book b,publisher p, book_category bc,category c " +
                                      $"WHERE b.B_STATUS = 1 AND b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND p.P_ID ='{id_penerbit}' GROUP BY b.`B_ID` ORDER BY LENGTH(b.B_PRICE) {order}, b.B_PRICE {order}; ";
                        }
                        else if (cmbSort.SelectedIndex == 4)
                        {
                            kolom = 7;
                            cmd = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',GROUP_CONCAT(c.C_NAME SEPARATOR ',')AS 'Kategori',CONCAT('Rp ',FORMAT(b.B_PRICE,0, 'de_DE')) AS 'Harga', b.B_STOCK AS 'Stok', (CASE WHEN b.B_STATUS=1 THEN 'Tersedia' ELSE 'Tidak Tersedia' END) AS 'Status' " +
                                      "FROM book b,publisher p, book_category bc,category c " +
                                      $"WHERE b.B_STATUS = 1 AND b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND p.P_ID ='{id_penerbit}' GROUP BY b.`B_ID` ORDER BY LENGTH(b.B_STOCK) {order}, b.B_STOCK {order}; ";
                        }

                    }

                refreshDgv(cmd);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbArah.SelectedIndex = -1;
            cmbSort.SelectedIndex = -1;
            refreshDgv(command_querry);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Panel temp;
            int selected_row = dataGridView1.CurrentCell.RowIndex;
            string id_pilih = dataGridView1.Rows[selected_row].Cells[0].Value.ToString();
            
            FormDetailBukuAdmin frm = new FormDetailBukuAdmin(id_pilih,id_penerbit);
            temp = (Panel)frm.Controls[0];
            temp.Width = panel1.Width;
            temp.Height = panel1.Height;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(temp);
        }
    }
}
