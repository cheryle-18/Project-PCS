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
    public partial class FormPegawaiBaru : Form
    {
        public FormPegawaiBaru()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MasterPegawaiAdmin frm = new MasterPegawaiAdmin();
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (tbNama.Text == "" || tbAlamat.Text == "" || tbTelepon.Text == ""||tbUsername.Text==""||tbPassword.Text=="")
            {
                MessageBox.Show("Semua Field Harus Terisi!");
            }
            else
            {
                string query = $"INSERT INTO users VALUES(@u_id, @u_username, @u_password, '2', '1');";
                MySqlCommand cmd = new MySqlCommand(query, Koneksi.getConn());
                cmd.Parameters.AddWithValue("@u_id", tbUserId.Text);
                cmd.Parameters.AddWithValue("@u_username", tbUsername.Text);
                cmd.Parameters.AddWithValue("@u_password", tbPassword.Text);

                cmd.ExecuteNonQuery();

                query = $"INSERT INTO EMPLOYEE VALUE (@E_ID,@E_NAME,@E_BIRTHDATE,@E_ADDRESS,@E_TELP,@U_ID,'1');";
                cmd = new MySqlCommand(query, Koneksi.getConn());
                cmd.Parameters.AddWithValue("@E_ID", tbID.Text);
                cmd.Parameters.AddWithValue("@E_NAME", tbNama.Text);
                cmd.Parameters.AddWithValue("@E_BIRTHDATE", dtpTanggalLahir.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@E_ADDRESS", tbAlamat.Text);
                cmd.Parameters.AddWithValue("@E_TELP", tbTelepon.Text);
                cmd.Parameters.AddWithValue("@U_ID", tbUserId.Text);

                cmd.ExecuteNonQuery();


                MasterPegawaiAdmin frm = new MasterPegawaiAdmin();
                Panel temp = (Panel)frm.Controls[0];
                temp.Width = panel2.Width;
                temp.Height = panel2.Height;
                this.panel2.Controls.Clear();
                this.panel2.Controls.Add(temp);
            }
        }
        void generateID()
        {
            string query = $"SELECT generateIdUser()";
            MySqlCommand cmd = new MySqlCommand(query, Koneksi.getConn());
            string userId = cmd.ExecuteScalar().ToString();
            tbUserId.Text = userId;

            query = $"SELECT generateIdEmployee()";
            cmd = new MySqlCommand(query, Koneksi.getConn());
            string e_id= cmd.ExecuteScalar().ToString();
            tbID.Text = e_id;
        }

        private void FormPegawaiBaru_Load(object sender, EventArgs e)
        {

        }

        private void tbUbah_TextChanged(object sender, EventArgs e)
        {
            generateID();
        }
    }
}
