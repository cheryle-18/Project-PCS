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
    public partial class FormDetailBukuAdmin : Form
    {
        MySqlCommand command;
        MySqlConnection connection;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string idBuku;
        string bahasa, format,tempharga,navigasi;
        int harga;
        List<string> arrTemp;
        List<string> arrBC_ID;
        List<string> arrC_ID;
        List<string> arrIDPenerbit;
        DataTable dtPenerbit;
        Random rnd=new Random();
        public FormDetailBukuAdmin(string id,string nav)
        {
            InitializeComponent();
            arrIDPenerbit = new List<string>();
            arrBC_ID = new List<string>();
            arrC_ID = new List<string>();
            connection = Koneksi.getConn();
            idBuku = id;
            navigasi = nav;
            connects();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
             if (navigasi == "buku")
             {
                 MasterBuku frm = new MasterBuku(1);
                 Panel temp = (Panel)frm.Controls[0];
                 temp.Width = panel1.Width;
                 temp.Height = panel1.Height;
                 this.panel1.Controls.Clear();
                 this.panel1.Controls.Add(temp);
             }
             else
             {
                 FormDetailPenerbitAdmin frm = new FormDetailPenerbitAdmin(navigasi);
                 Panel temp = (Panel)frm.Controls[0];
                 temp.Width = panel1.Width;
                 temp.Height = panel1.Height;
                 this.panel1.Controls.Clear();
                 this.panel1.Controls.Add(temp);
             }
            
        }

        private void FormDetailBukuAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                byte[] img = ms.ToArray();
                int stat = 0;
                if (radAda.Checked)
                {
                    stat = 1;
                }
                string tgl = tglTerbit.Text;
                string[] split = tgl.Split(' ');
                if (split[0]=="January")
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

                

                string query="UPDATE book"+
                               $" SET B_TITLE = '{tbJudul.Text}', B_AUTHOR = '{tbAuthor.Text}', B_P_ID = '{arrIDPenerbit[cbPenerbit.SelectedIndex]}', B_PUB_DATE = '{tgl}', B_SYNOPSIS = '{tbSynopsis.Text}', B_PRICE = {harga}, B_IMAGE = @img, B_STOCK = {numStok.Value}, B_LANGUAGE = '{tbBahasa.Text}', B_FORMAT = '{tbFormat.Text}',B_ISBN10 = '{tbIsbn10.Text}', B_ISBN13 = '{tbIsbn13.Text}', B_STATUS = {stat}"+
                               $" WHERE B_ID = '{idBuku}'";
                command = new MySqlCommand(query,connection);
                command.Parameters.Add("@img",MySqlDbType.Blob);
                command.Parameters["@img"].Value = img;
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.ExecuteNonQuery();
                connection.Close();
                if (chListKategori.CheckedItems.Count>arrBC_ID.Count)
                {
                    int selisih = chListKategori.CheckedItems.Count - arrBC_ID.Count;
                    int ctr=0;
                    for (int i = 0; i < arrBC_ID.Count; i++)
                    {
                        query = $"UPDATE book_category SET C_ID = '{arrC_ID[chListKategori.CheckedIndices[i]]}' WHERE BC_ID = '{arrBC_ID[i]}' ";
                        ctr++;
                        command.CommandText = query;
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    

                    for (int i=0;i<selisih;i++)
                    {
                        query=$"INSERT INTO book_category(BC_ID,B_ID,C_ID) VALUES('{generateBC_ID()}','{idBuku}','{arrC_ID[chListKategori.CheckedIndices[ctr]]}')";
                        ctr++;
                        command.CommandText = query;
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        command.ExecuteNonQuery();
                        connection.Close();
                    }


                }
                else if(chListKategori.CheckedItems.Count < arrBC_ID.Count)
                {
                    int selisih = arrBC_ID.Count - chListKategori.CheckedItems.Count;
                    query = $"DELETE FROM book_category WHERE B_ID = '{idBuku}' ORDER BY BC_ID DESC LIMIT {selisih}";
                    command.CommandText = query;
                    if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    command.ExecuteNonQuery();
                    connection.Close();
                    for (int i = 0; i < arrBC_ID.Count; i++)
                    {
                        query = $"UPDATE book_category SET C_ID = '{arrC_ID[chListKategori.CheckedIndices[i]]}' WHERE BC_ID = '{arrBC_ID[i]}' ";
                        command.CommandText = query;
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    
                }
                else
                {
                    for (int i=0;i<arrBC_ID.Count;i++)
                    {
                        query = $"UPDATE book_category SET C_ID = '{arrC_ID[chListKategori.CheckedIndices[i]]}' WHERE BC_ID = '{arrBC_ID[i]}' ";
                        command.CommandText = query;
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                
                

                MessageBox.Show("Berhasil Update");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string generateBC_ID()
        {
            string id_bc="";
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
        private void chListKategori_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            if (tempharga!=tbHarga.Text)
            {
                try
                {
                    harga = Convert.ToInt32(tbHarga.Text);
                    tbHarga.Text = string.Format("{0:#,##0.00}", double.Parse(tbHarga.Text));
                }
                catch (Exception)
                {

                }

            }
        }

        private void connects()
        {
            string query;
            string publisher="";
            dtPenerbit = new DataTable();            
            try
            {
                query = "SELECT b.B_ID AS 'Kode Buku',b.B_TITLE AS 'Judul Buku',b.B_AUTHOR AS 'Penulis',p.P_NAME AS 'Penerbit' , b.B_PRICE AS 'Harga', b.B_STOCK AS 'Stok',b.B_STATUS AS 'Status',b.B_IMAGE AS 'image',b.B_SYNOPSIS as 'sinopsis',b.B_ISBN10 ,b.B_ISBN13,b.B_LANGUAGE,b.B_FORMAT,b.B_PUB_DATE " +
                                      "FROM book b,publisher p " +
                                      $"WHERE  b.B_P_ID = p.P_ID AND b.B_ID LIKE '{idBuku}';";
                command = new MySqlCommand(query, connection);
                da = new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                da.Fill(table);
                byte[] img = (byte[])table.Rows[0][7];
                tbKode.Text = table.Rows[0][0].ToString();
                tbJudul.Text = table.Rows[0][1].ToString();
                tbAuthor.Text = table.Rows[0][2].ToString();
                tempharga = tbHarga.Text = string.Format("{0:#,##0.00}", double.Parse(table.Rows[0][4].ToString()));
                harga = Convert.ToInt32(table.Rows[0][4]);
                numStok.Value = Convert.ToInt32(table.Rows[0][5]);
                publisher = table.Rows[0][3].ToString();
                tbSynopsis.Text = table.Rows[0][8].ToString();
                tbBahasa.Text = table.Rows[0][11].ToString();
                tbFormat.Text = table.Rows[0][12].ToString();
                string tanggaltemp = table.Rows[0][13].ToString();
                var myDate = DateTime.ParseExact(tanggaltemp, "MMMM - yyyy",new System.Globalization.CultureInfo("id-ID"), System.Globalization.DateTimeStyles.None);
                tglTerbit.Value = myDate;
                MemoryStream ms = new MemoryStream(img);
                pictureBox2.Image = Image.FromStream(ms);

                if (Convert.ToInt32(table.Rows[0][6]) == 1)
                {
                    radAda.Checked = true;
                    radTAda.Checked = false;
                }
                else
                {
                    radAda.Checked = false;
                    radTAda.Checked = true;
                }

                tbIsbn10.Text = table.Rows[0][9].ToString();
                tbIsbn13.Text = table.Rows[0][10].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {

                query = "SELECT P_ID,P_NAME FROM publisher;";
                command = new MySqlCommand(query, connection);

                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    cbPenerbit.Items.Add(dr.GetString(1));
                    arrIDPenerbit.Add(dr.GetString(0));
                }
                connection.Close();

                for (int a = 0; a < cbPenerbit.Items.Count; a++)
                {
                    if (cbPenerbit.Items[a].ToString() == publisher)
                    {
                        cbPenerbit.SelectedIndex = a;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            try
            {

                query = $"SELECT c.C_NAME,bc.BC_ID FROM book_category bc,category c WHERE c.C_ID = bc.C_ID AND bc.B_ID='{idBuku}';";
                command = new MySqlCommand(query, connection);
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                dr = command.ExecuteReader();
                arrTemp = new List<string>();
                while (dr.Read())
                {
                    arrTemp.Add(dr[0].ToString());  
                    arrBC_ID.Add(dr[1].ToString());  
                }
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                query = $"SELECT C_ID,C_NAME FROM category;";
                command = new MySqlCommand(query, connection);
                
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                dr = command.ExecuteReader();
                bool cek;
                while (dr.Read())
                {
                    cek = false;
                    for (int i = 0;i<arrTemp.Count;i++)
                    {
                        if (arrTemp[i] == dr[1].ToString())
                        {
                            cek = true;
                            chListKategori.Items.Add(dr[1],true);
                        }
                    }

                    if (!cek)
                    {
                        chListKategori.Items.Add(dr[1],false);
                    }
                    arrC_ID.Add(dr[0].ToString());
                }
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
            da.Dispose(); 
        }


    }
}
