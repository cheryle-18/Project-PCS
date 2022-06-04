using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore
{
    public partial class FormDetailBuku : Form
    {
        MySqlCommand command;
        MySqlDataAdapter da;
        private string idBuku;
        public FormDetailBuku(string id)
        {
            InitializeComponent();
            idBuku = id;
            connects();
        }

        private void connects()
        {
<<<<<<< Updated upstream
            String query = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',c.C_NAME AS 'Kategori',CONCAT('Rp.', FORMAT(b.B_PRICE, 0)) AS 'Harga', b.B_STOCK AS 'Stok',b.B_STATUS AS 'Status',b.B_IMAGE AS 'image',b.B_SYNOPSIS as 'sinopsis',b.B_ISBN10 ,b.B_ISBN13,b.B_LANGUAGE,b.B_FORMAT,b.B_PUB_DATE " +
=======
            string query = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit',c.C_NAME AS 'Kategori',CONCAT('Rp ', FORMAT(b.B_PRICE, 0, 'de_DE')) AS 'Harga', b.B_STOCK AS 'Stok',b.B_STATUS AS 'Status',b.B_IMAGE AS 'image',b.B_SYNOPSIS as 'sinopsis',b.B_ISBN10 ,b.B_ISBN13,b.B_LANGUAGE,b.B_FORMAT,b.B_PUB_DATE " +
>>>>>>> Stashed changes
                                      "FROM book b,publisher p, book_category bc,category c " +
                                      $"WHERE b.B_ID = bc.B_ID AND bc.C_ID = c.C_ID AND b.B_P_ID = p.P_ID AND b.B_ID LIKE '{idBuku}';";

            command = new MySqlCommand(query, Koneksi.getConn());
            da = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            da.Fill(table);
            byte[] img;
            if (table.Rows[0][8].ToString()!="")
            {
                img= (byte[])table.Rows[0][8];
                MemoryStream ms = new MemoryStream(img);
                pictureBox2.Image = Image.FromStream(ms);
            }
            
            lbKode.Text = table.Rows[0][0].ToString();
            lbJudul.Text = table.Rows[0][1].ToString();
            lbAuthor.Text = table.Rows[0][2].ToString();
            lbPenerbit.Text = table.Rows[0][3].ToString();
            lbKategori.Text = table.Rows[0][4].ToString();
            lbHarga.Text = table.Rows[0][5].ToString();
            lbStok.Text = table.Rows[0][6].ToString();
            lbSynopsis.Text = table.Rows[0][9].ToString();
            lbIsbn10.Text = table.Rows[0][10].ToString();
            lbIsbn13.Text = table.Rows[0][11].ToString();
            lbBahasa.Text = table.Rows[0][12].ToString();
            lbFormat.Text = table.Rows[0][13].ToString();
            lbTanggal.Text = table.Rows[0][14].ToString();
           
            if(Convert.ToInt32(table.Rows[0][7]) == 1)
            {
                lbStatus.Text = "Tersedia";
                lbStatus.ForeColor = Color.Green;
            }
            else
            {
                lbStatus.Text = "Tidak Tersedia";
                lbStatus.ForeColor = Color.Red;
            }

            

            da.Dispose();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MasterBuku frm = new MasterBuku(0);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel1.Width;
            temp.Height = panel1.Height;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(temp);
        }

        private void FormDetailBuku_Load(object sender, EventArgs e)
        {
            
        }
    }
}
