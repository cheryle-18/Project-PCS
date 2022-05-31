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
    public partial class FormMemberBaru : Form
    {
        public FormMemberBaru()
        {
            InitializeComponent();
        }

        private void btnMemberBaru_Click(object sender, EventArgs e)
        {
            MasterMember frm = new MasterMember(0);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (tbNama.Text==""||tbAlamat.Text==""||tbTelepon.Text=="")
            {
                MessageBox.Show("Semua Field Harus Terisi!");
            }
            else
            {
                string query = $"INSERT INTO MEMBER VALUE (@M_ID,@M_NAME,@M_BIRTHDATE,@M_ADDRESS,@M_TELP,'0','1');";
                MySqlCommand cmd = new MySqlCommand(query, Koneksi.getConn());
                cmd.Parameters.AddWithValue("@M_ID", tbID.Text);
                cmd.Parameters.AddWithValue("@M_NAME", tbNama.Text);
                cmd.Parameters.AddWithValue("@M_BIRTHDATE", dtpTanggalLahir.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@M_ADDRESS", tbAlamat.Text);
                cmd.Parameters.AddWithValue("@M_TELP", tbTelepon.Text);

                cmd.ExecuteNonQuery();

                MasterMember frm = new MasterMember(0);
                Panel temp = (Panel)frm.Controls[0];
                temp.Width = panel2.Width;
                temp.Height = panel2.Height;
                this.panel2.Controls.Clear();
                this.panel2.Controls.Add(temp);
            }
        }

        void generateID()
        {
            string query = $"SELECT generateIdMember()";
            MySqlCommand cmd = new MySqlCommand(query, Koneksi.getConn());
            string id = cmd.ExecuteScalar().ToString();
            tbID.Text = id;
        }

        private void tbUbah_TextChanged(object sender, EventArgs e)
        {
            generateID();
        }
    }
}
