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
    public partial class FormDetailTransaksi : Form
    {
        public FormDetailTransaksi()
        {
            InitializeComponent();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterTransaksi frm = new MasterTransaksi();
            frm.ShowDialog();
            this.Close();
        }

        private void FormDetailTransaksi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
