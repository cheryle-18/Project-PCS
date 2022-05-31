using MySql.Data.MySqlClient;
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
    public partial class MasterPenerbitAdmin : Form
    {
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private DataTable dt;
        private string command_querry = "SELECT P_ID AS 'Kode Penerbit',P_NAME AS 'Nama',P_ADDRESS AS 'Alamat',P_TELP AS 'Telp',P_STATUS AS 'Status' " +
                                   "FROM publisher; ";
        public MasterPenerbitAdmin()
        {
            InitializeComponent();
            refreshDgv(command_querry);
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            FormDetailPenerbitAdmin frm = new FormDetailPenerbitAdmin();
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            FormPenerbitBaru frm = new FormPenerbitBaru();
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MasterPenerbitAdmin_Load(object sender, EventArgs e)
        {

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

        private string search(string input)
        {
            string cmd = "";

            if (cmbSort.SelectedIndex > -1 && cmbArah.SelectedIndex > -1)
            {
                string order = "ASC";
                int kolom = 0;

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
                                      $"WHERE b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND b.B_TITLE LIKE CONCAT('%','{input}','%') ORDER BY {kolom} {order}; ";
                }
                else if (cmbSort.SelectedIndex >= 3)
                {
                    if (cmbSort.SelectedIndex == 3)
                    {
                        kolom = 6;
                        cmd = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',c.C_NAME AS 'Kategori',CONCAT('Rp.', FORMAT(b.B_PRICE, 0)) AS 'Harga', b.B_STOCK AS 'Stok',b.B_STATUS AS 'Status' " +
                                  "FROM book b,publisher p, book_category bc,category c " +
                                  $"WHERE b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND b.B_TITLE LIKE CONCAT('%','{input}','%') ORDER BY LENGTH(b.B_PRICE) {order}, b.B_PRICE {order}; ";
                    }
                    else if (cmbSort.SelectedIndex == 4)
                    {
                        kolom = 7;
                        cmd = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',c.C_NAME AS 'Kategori',CONCAT('Rp.', FORMAT(b.B_PRICE, 0)) AS 'Harga', b.B_STOCK AS 'Stok',b.B_STATUS AS 'Status' " +
                                  "FROM book b,publisher p, book_category bc,category c " +
                                  $"WHERE b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND b.B_TITLE LIKE CONCAT('%','{input}','%') ORDER BY LENGTH(b.B_STOCK) {order}, b.B_STOCK {order}; ";
                    }

                }
            }
            else
            {
                cmd = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',c.C_NAME AS 'Kategori',CONCAT('Rp.',FORMAT(b.B_PRICE,0)) AS 'Harga', b.B_STOCK AS 'Stok',b.B_STATUS AS 'Status' " +
                                      $"FROM book b,publisher p, book_category bc,category c WHERE b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND b.B_TITLE LIKE CONCAT('%','{input}','%'); ";
            }
            return cmd;
        }
    }
}
