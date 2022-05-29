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
    public partial class FormLogin : KryptonForm
    {
        public static string us_id;
        public static int us_role;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //CHECK FOR USER ROLE
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM users WHERE users.`U_USERNAME` = @u_username AND users.`U_PASSWORD` = @u_password;",Koneksi.getConn());
            cmd.Parameters.AddWithValue("@u_username", username);
            cmd.Parameters.AddWithValue("@u_password", password);
            int data_found = Convert.ToInt32(cmd.ExecuteScalar());

            if (data_found != 0)
            {

                cmd = new MySqlCommand("SELECT users.U_ID,users.U_ROLE FROM users WHERE users.`U_USERNAME` = @u_username AND users.`U_PASSWORD` = @u_password;", Koneksi.getConn());
                cmd.Parameters.AddWithValue("@u_username", username);
                cmd.Parameters.AddWithValue("@u_password", password);
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    us_id = rd["U_ID"].ToString();
                    us_role = Convert.ToInt32(rd["U_ROLE"].ToString());
                }
                rd.Close();
                if (us_role == 1)
                {
                    //USER ROLE = ADMIN
                    this.Hide();
                    MasterUtamaAdmin frm = new MasterUtamaAdmin();
                    frm.ShowDialog();
                }
                else
                {
                    //USER ROLE = EMPLOYEE
                    this.Hide();
                    MasterUtamaPegawai frm = new MasterUtamaPegawai();
                    frm.ShowDialog();
                }
                
            }
            else
            {
                MessageBox.Show("Username/Password salah!");
            }
          
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            connectDB();   
        }

        private void connectDB()
        {
            //setup connections
            string server = "localhost";
            string db = "db_tokobuku";
            string user = "root";
    
            if(Koneksi.getConn().State == ConnectionState.Closed)
            {
                if (Koneksi.openConn(server, db, user))
                {
                    //successful
                }
                else
                {

                }
            }
          
            
        }


        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
