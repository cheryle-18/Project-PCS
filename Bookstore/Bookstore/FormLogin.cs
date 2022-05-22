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
    }
}
