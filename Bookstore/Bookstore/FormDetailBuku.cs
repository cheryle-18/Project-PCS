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
        MySqlConnection connection;
        MySqlCommand command;
        MySqlDataAdapter da;
        public FormDetailBuku()
        {
            InitializeComponent();
            connection = Koneksi.getConn();
            fill_picture_box();
        }

        private void fill_picture_box()
        {
            String query = "SELECT * FROM db_tokobuku.book WHERE B_ID = 'BOOK0001';";
            command = new MySqlCommand(query, connection);
            da = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            da.Fill(table);
            byte[] img = (byte[])table.Rows[0][7];

            MemoryStream ms = new MemoryStream(img);
            pictureBox2.Image = Image.FromStream(ms);

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
