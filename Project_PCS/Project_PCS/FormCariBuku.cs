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
    public partial class FormCariBuku : Form
    {
        public FormCariBuku()
        {
            InitializeComponent();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTransaksiBaru frm = new FormTransaksiBaru();
            frm.ShowDialog();
        }

        private void FormCariBuku_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btnPilih_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
