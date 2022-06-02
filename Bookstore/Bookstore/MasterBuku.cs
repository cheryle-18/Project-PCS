using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;

namespace Bookstore
{
    public partial class MasterBuku : KryptonForm
    {
        //user_role = 0 (employee)
        //user_role = 1 (admin)
        private int user_role;
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private DataTable dt;
        private string command_querry = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',c.C_NAME AS 'Kategori',CONCAT('Rp.',FORMAT(b.B_PRICE,0)) AS 'Harga', b.B_STOCK AS 'Stok',b.B_STATUS AS 'Status' " +
                                   "FROM book b,publisher p, book_category bc,category c WHERE b.B_STATUS = 1 AND b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID; ";
        
        public MasterBuku(int role)
        {
            InitializeComponent();
            this.user_role = role;
            if(this.user_role == 0)
            {
                this.btnInsert.Visible = false;
            }
            refreshDgv(command_querry);
        }

        private void MasterBuku_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            Panel temp;
            int selected_row = dataGridView1.CurrentCell.RowIndex;
            string id_pilih = dataGridView1.Rows[selected_row].Cells[0].Value.ToString();
            if(user_role == 0)
            {
                FormDetailBuku frm = new FormDetailBuku(id_pilih);
                temp = (Panel)frm.Controls[0];
            }
            else
            {
                FormDetailBukuAdmin frm = new FormDetailBukuAdmin(id_pilih,"buku");
                temp = (Panel)frm.Controls[0];
              
            }
            temp.Width = panelBuku.Width;
            temp.Height = panelBuku.Height;
            this.panelBuku.Controls.Clear();
            this.panelBuku.Controls.Add(temp);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            FormBukuBaruAdmin frm = new FormBukuBaruAdmin();
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panelBuku.Width;
            temp.Height = panelBuku.Height;
            this.panelBuku.Controls.Clear();
            this.panelBuku.Controls.Add(temp);
        
        }

        private string search(string input)
        {
            string cmd="";

            if (cmbSort.SelectedIndex > -1 && cmbArah.SelectedIndex > -1)
            {
                    string order="ASC";
                    int kolom=0;

                    if (cmbArah.SelectedIndex==0)
                    {
                        order = "ASC";
                    }
                    else if (cmbArah.SelectedIndex==1)
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

                        cmd = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',c.C_NAME AS 'Kategori',CONCAT('Rp.',FORMAT(b.B_PRICE,0)) AS 'Harga', b.B_STOCK AS 'Stok',b.B_STATUS AS 'Status' " +
                                          "FROM book b,publisher p, book_category bc,category c " +
                                          $"WHERE b.B_STATUS = 1 AND b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND b.B_TITLE LIKE CONCAT('%','{input}','%') ORDER BY {kolom} {order}; ";
                }
                    else if (cmbSort.SelectedIndex >= 3)
                    {
                        if (cmbSort.SelectedIndex == 3)
                        {
                            kolom = 6;
                            cmd = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',c.C_NAME AS 'Kategori',CONCAT('Rp.', FORMAT(b.B_PRICE, 0)) AS 'Harga', b.B_STOCK AS 'Stok',b.B_STATUS AS 'Status' " +
                                      "FROM book b,publisher p, book_category bc,category c " +
                                      $"WHERE b.B_STATUS = 1 AND b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND b.B_TITLE LIKE CONCAT('%','{input}','%') ORDER BY LENGTH(b.B_PRICE) {order}, b.B_PRICE {order}; ";
                        }
                        else if (cmbSort.SelectedIndex == 4)
                        {
                            kolom = 7;
                            cmd = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',c.C_NAME AS 'Kategori',CONCAT('Rp.', FORMAT(b.B_PRICE, 0)) AS 'Harga', b.B_STOCK AS 'Stok',b.B_STATUS AS 'Status' " +
                                      "FROM book b,publisher p, book_category bc,category c " +
                                      $"WHERE b.B_STATUS = 1 AND b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND b.B_TITLE LIKE CONCAT('%','{input}','%') ORDER BY LENGTH(b.B_STOCK) {order}, b.B_STOCK {order}; ";
                        }

                    }
            }
            else
            {
                cmd = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',c.C_NAME AS 'Kategori',CONCAT('Rp.',FORMAT(b.B_PRICE,0)) AS 'Harga', b.B_STOCK AS 'Stok',b.B_STATUS AS 'Status' " +
                                      $"FROM book b,publisher p, book_category bc,category c WHERE b.B_STATUS = 1 AND b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND b.B_TITLE LIKE CONCAT('%','{input}','%'); ";
            }
                return cmd;
        }

        private void refreshDgv(string command)
        {
            try
            {
                conn = Koneksi.getConn();
                da = new MySqlDataAdapter();
                cmd = new MySqlCommand(command, conn);
                dt = new DataTable();
                da.SelectCommand = cmd;
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                da.Fill(dt);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
                da.Dispose();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCari.Text = "Kata Kunci";
            cmbSort.SelectedIndex = -1;
            cmbArah.SelectedIndex = -1;
            refreshDgv(command_querry);
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            if(txtCari.Text!="Kata Kunci")
            {
                string temp=search(txtCari.Text);
                refreshDgv(temp);
            }
        }

        private void cmbArah_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSort.SelectedIndex > -1 && cmbArah.SelectedIndex>-1)
            {
                string order = "ASC";
                int kolom = 0;
                string cmd="";
                string keyword = "";
                if(txtCari.Text!="Kata Kunci")
                {
                    keyword = txtCari.Text;
                }
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

                    cmd = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',c.C_NAME AS 'Kategori',CONCAT('Rp.',FORMAT(b.B_PRICE,0)) AS 'Harga', b.B_STOCK AS 'Stok',b.B_STATUS AS 'Status' " +
                                      "FROM book b,publisher p, book_category bc,category c " +
                                      $"WHERE b.B_STATUS = 1 AND b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND b.B_TITLE LIKE CONCAT('%','{keyword}','%') ORDER BY {kolom} {order}; ";
                }
                if (cmbSort.SelectedIndex >= 3)
                {
                    if (cmbSort.SelectedIndex == 3)
                    {
                        kolom = 6;
                        cmd = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',c.C_NAME AS 'Kategori',CONCAT('Rp.', FORMAT(b.B_PRICE, 0)) AS 'Harga', b.B_STOCK AS 'Stok',b.B_STATUS AS 'Status' " +
                                  "FROM book b,publisher p, book_category bc,category c " +
                                  $"WHERE b.B_STATUS = 1 AND b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND b.B_TITLE LIKE CONCAT('%','{keyword}','%') ORDER BY LENGTH(b.B_PRICE) {order}, b.B_PRICE {order}; ";
                    }
                    else if (cmbSort.SelectedIndex == 4)
                    {
                        kolom = 7;
                        cmd = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',c.C_NAME AS 'Kategori',CONCAT('Rp.', FORMAT(b.B_PRICE, 0)) AS 'Harga', b.B_STOCK AS 'Stok',b.B_STATUS AS 'Status' " +
                                  "FROM book b,publisher p, book_category bc,category c " +
                                  $"WHERE b.B_STATUS = 1 AND b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND b.B_TITLE LIKE CONCAT('%','{keyword}','%') ORDER BY LENGTH(b.B_STOCK) {order}, b.B_STOCK {order}; ";
                    }
                    
                }
                
                refreshDgv(cmd);
            }

        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbArah.SelectedIndex > -1 && cmbSort.SelectedIndex > -1)
            {
                string order = "ASC";
                int kolom = 0;
                string cmd = "";
                string keyword = "";
                if (txtCari.Text != "Kata Kunci")
                {
                    keyword = txtCari.Text;
                }

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

                    cmd = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',c.C_NAME AS 'Kategori',CONCAT('Rp.',FORMAT(b.B_PRICE,0)) AS 'Harga', b.B_STOCK AS 'Stok',b.B_STATUS AS 'Status' " +
                                      "FROM book b,publisher p, book_category bc,category c " +
                                      $"WHERE b.B_STATUS = 1 AND b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND b.B_TITLE LIKE CONCAT('%','{keyword}','%') ORDER BY {kolom} {order}; ";
                }
                if (cmbSort.SelectedIndex >= 3)
                {
                    if (cmbSort.SelectedIndex == 3)
                    {
                        kolom = 6;
                        cmd = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',c.C_NAME AS 'Kategori',CONCAT('Rp.', FORMAT(b.B_PRICE, 0)) AS 'Harga', b.B_STOCK AS 'Stok',b.B_STATUS AS 'Status' " +
                                  "FROM book b,publisher p, book_category bc,category c " +
                                  $"WHERE b.B_STATUS = 1 AND b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND b.B_TITLE LIKE CONCAT('%','{keyword}','%') ORDER BY LENGTH(b.B_PRICE) {order}, b.B_PRICE {order}; ";
                    }
                    else if (cmbSort.SelectedIndex == 4)
                    {
                        kolom = 7;
                        cmd = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',c.C_NAME AS 'Kategori',CONCAT('Rp.', FORMAT(b.B_PRICE, 0)) AS 'Harga', b.B_STOCK AS 'Stok',b.B_STATUS AS 'Status' " +
                                  "FROM book b,publisher p, book_category bc,category c " +
                                  $"WHERE b.B_STATUS = 1 AND b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND b.B_TITLE LIKE CONCAT('%','{keyword}','%') ORDER BY LENGTH(b.B_STOCK) {order}, b.B_STOCK {order}; ";
                    }

                }

                refreshDgv(cmd);
            }

        }
    }
}
