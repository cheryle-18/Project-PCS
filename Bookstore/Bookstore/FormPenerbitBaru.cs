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
    public partial class FormPenerbitBaru : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;

        public FormPenerbitBaru()
        {
            InitializeComponent();
            conn = Koneksi.getConn();
            generateID();
        }

        private void generateID()
        {
            string id;
            cmd = new MySqlCommand();
            cmd.CommandText = "generateIdPenerbit";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            cmd.Parameters.Add(new MySqlParameter("idPenerbit",MySqlDbType.VarChar));
            cmd.Parameters["idPenerbit"].Direction = ParameterDirection.Output;
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            cmd.ExecuteNonQuery();
            conn.Close();
            id = cmd.Parameters["idPenerbit"].Value.ToString();

            tbKode.Text = id;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MasterPenerbitAdmin frm = new MasterPenerbitAdmin();
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbNama.Text != "" && tbAlamat.Text != "" && tbTelp.Text != "") {
                try {
                    string query = $"INSERT INTO publisher (`P_ID`,`P_NAME`,`P_ADDRESS`,`P_TELP`,`P_STATUS`) VALUES('{tbKode.Text}','{tbNama.Text}','{tbAlamat.Text}','{tbTelp.Text}',1) ;";
                    cmd = new MySqlCommand(query, conn);
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Berhasi Insert");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Gagal Insert\n" + ex.Message);
                }
            }
            MasterPenerbitAdmin frm = new MasterPenerbitAdmin();
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

    }
}
