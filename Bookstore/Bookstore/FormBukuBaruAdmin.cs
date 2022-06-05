using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;

namespace Bookstore
{
    public partial class FormBukuBaruAdmin : Form
    {
        MySqlCommand command;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string idBuku;
        string bahasa, format, tempharga, navigasi;
        int harga;
        List<string> arrTemp;
        List<string> arrBC_ID;
        List<string> arrC_ID;
        List<string> arrIDPenerbit;
        public FormBukuBaruAdmin()
        {
            InitializeComponent();
            connects();
        }

        private void FormBukuBaruAdmin_Load(object sender, EventArgs e)
        {

        }
        
        private void generateIdBook()
        {
            string id_b = "";
            command = new MySqlCommand();
            command.CommandText = "generateIdBook";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = Koneksi.getConn();
            command.Parameters.Add(new MySqlParameter("idB", MySqlDbType.VarChar));
            command.Parameters["idB"].Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            id_b = command.Parameters["idB"].Value.ToString();

            tbKode.Text = id_b;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MasterBuku frm = new MasterBuku(1);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbAuthor.Text == "" || tbJudul.Text == "" || tbHarga.Text == "" || tbBahasa.Text == "" || tbFormat.Text == "" || cbPenerbit.SelectedIndex == -1 || chListKategori.CheckedItems.Count <= 0 && tbISBN10.Text == "" && tbISBN13.Text == "")
            {
                MessageBox.Show("Isi Semua Field");
            }
            else
            {
                try 
               {
                    byte[] img=null;
                    if (pictureBox2.Image !=null)
                    {
                        MemoryStream ms = new MemoryStream();
                        pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                        img = ms.ToArray();
                    }
     
                int stat = 0;
                if (radAda.Checked)
                {
                    stat = 1;
                }
                string tgl = tglTerbit.Text;
                string[] split = tgl.Split(' ');
                if (split[0] == "January")
                {
                    split[0] = "Januari";
                }
                else if (split[0] == "February")
                {
                    split[0] = "Februari";
                }
                else if (split[0] == "March")
                {
                    split[0] = "Maret";
                }
                else if (split[0] == "April")
                {
                    split[0] = "April";
                }
                else if (split[0] == "May")
                {
                    split[0] = "Mei";
                }
                else if (split[0] == "June")
                {
                    split[0] = "Juni";
                }
                else if (split[0] == "July")
                {
                    split[0] = "Juli";
                }
                else if (split[0] == "August")
                {
                    split[0] = "Agustus";
                }
                else if (split[0] == "September")
                {
                    split[0] = "September";
                }
                else if (split[0] == "October")
                {
                    split[0] = "Oktober";
                }
                else if (split[0] == "November")
                {
                    split[0] = "November";
                }
                else if (split[0] == "December")
                {
                    split[0] = "Desember";
                }

                tgl = split[0] + " - " + split[2];

                string query = "INSERT INTO book (`B_ID`, `B_TITLE`, `B_AUTHOR`, `B_P_ID`, `B_PUB_DATE`, `B_SYNOPSIS`, `B_PRICE`, `B_IMAGE`, `B_STOCK`, `B_LANGUAGE`, `B_FORMAT`, `B_ISBN10`, `B_ISBN13`, `B_STATUS`)" +
                               $" VALUES('{tbKode.Text}' , '{tbJudul.Text}', '{tbAuthor.Text}', '{arrIDPenerbit[cbPenerbit.SelectedIndex]}', '{tgl}', '{tbSynopsis.Text}', {harga}, @img, {numStok.Value},'{tbBahasa.Text}', '{tbFormat.Text}','{tbISBN10.Text}', '{tbISBN13.Text}', {stat})";
                command = new MySqlCommand(query, Koneksi.getConn());
                command.Parameters.Add("@img", MySqlDbType.Blob);
                    if (pictureBox2.Image==null)
                    {
                        command.Parameters["@img"].Value = null;
                    }
                    else
                    {
                        command.Parameters["@img"].Value = img;
                    }


                    command.ExecuteNonQuery();
                    string bc_id = "";
                for (int i = 0; i < chListKategori.CheckedItems.Count; i++)
                {
                    bc_id = generateBC_ID();
                    query = $"INSERT INTO `book_category` (`BC_ID`, `B_ID`, `C_ID`) VALUES('{bc_id}', '{tbKode.Text}', '{arrC_ID[chListKategori.CheckedIndices[i]]}'); ";
                    command = new MySqlCommand(query,Koneksi.getConn());
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Behasil Insert");

                MasterBuku frm = new MasterBuku(1);
                Panel temp = (Panel)frm.Controls[0];
                temp.Width = panel2.Width;
                temp.Height = panel2.Height;
                this.panel2.Controls.Clear();
                this.panel2.Controls.Add(temp);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }


        }

        private string generateBC_ID()
        {
            string id_bc = "";
            command = new MySqlCommand();
            command.CommandText = "generateIdBC";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = Koneksi.getConn();
            command.Parameters.Add(new MySqlParameter("idBC", MySqlDbType.VarChar));
            command.Parameters["idBC"].Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            id_bc = command.Parameters["idBC"].Value.ToString();

            return id_bc;
        }

        private void connects()
        {
            tglTerbit.Value = DateTime.Now;
            string query;
            string publisher = "";
            generateIdBook();
            arrIDPenerbit = new List<string>();
            arrC_ID = new List<string>();
            try
            {

                query = "SELECT P_ID,P_NAME FROM publisher;";
                command = new MySqlCommand(query, Koneksi.getConn());

                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    cbPenerbit.Items.Add(dr.GetString(1));
                    arrIDPenerbit.Add(dr.GetString(0));
                }

                for (int a = 0; a < cbPenerbit.Items.Count; a++)
                {
                    if (cbPenerbit.Items[a].ToString() == publisher)
                    {
                        cbPenerbit.SelectedIndex = a;
                    }

                }
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                query = $"SELECT C_ID,C_NAME FROM category;";
                command = new MySqlCommand(query, Koneksi.getConn());


                dr = command.ExecuteReader();
                bool cek;
                while (dr.Read())
                {
                    chListKategori.Items.Add(dr[1], false);
                    arrC_ID.Add(dr[0].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(opf.FileName);
            }
        }

        private void tbHarga_Leave(object sender, EventArgs e)
        {
            if (tempharga != tbHarga.Text)
            {
                try
                {
                    harga = Convert.ToInt32(tbHarga.Text);
                    //tbHarga.Text = string.Format("{0:#,##0.00}", double.Parse(tbHarga.Text));
                    tbHarga.Text = harga.ToString("N0", new System.Globalization.CultureInfo("id-ID"));
                }
                catch (Exception)
                {

                }

            }
        }
    }
}
