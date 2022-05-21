using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PCS
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text=="admin"&&tbPassword.Text=="admin")
            {
                this.Hide();
                MasterBukuAdmin frm = new MasterBukuAdmin();
                frm.ShowDialog();
            }
            else
            {
                this.Hide();
                MasterBuku frm = new MasterBuku();
                frm.ShowDialog();
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
