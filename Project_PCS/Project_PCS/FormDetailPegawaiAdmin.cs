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
    public partial class FormDetailPegawaiAdmin : Form
    {
        public FormDetailPegawaiAdmin()
        {
            InitializeComponent();
        }

        private void FormDetailPegawaiAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterPegawaiAdmin frm = new MasterPegawaiAdmin();
            frm.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterPegawaiAdmin frm = new MasterPegawaiAdmin();
            frm.ShowDialog();
        }

        private void btnBuku_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterBukuAdmin frm = new MasterBukuAdmin();
            frm.ShowDialog();
        }

        private void btnPenerbit_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterPenerbitAdmin frm = new MasterPenerbitAdmin();
            frm.ShowDialog();
        }
    }
}
