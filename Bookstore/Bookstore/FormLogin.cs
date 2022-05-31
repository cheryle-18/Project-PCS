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
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
            {
                this.Hide();
                MasterUtamaAdmin frm = new MasterUtamaAdmin();
                frm.ShowDialog();
            }
            else
            {
                this.Hide();
                MasterUtamaPegawai frm = new MasterUtamaPegawai();
                frm.ShowDialog();
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
            string password = "mysql";
    
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
