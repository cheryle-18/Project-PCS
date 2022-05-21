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
    public partial class FormPreOrderBaru : Form
    {
        public FormPreOrderBaru()
        {
            InitializeComponent();
        }

        private void btnCariMember_Click(object sender, EventArgs e)
        {
            FormCariMember frm = new FormCariMember();
            frm.ShowDialog();
        }

        private void btnCariBuku_Click(object sender, EventArgs e)
        {
            FormCariBuku frm = new FormCariBuku();
            frm.ShowDialog();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterTransaksi frm = new MasterTransaksi();
            frm.ShowDialog();
            this.Close();
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterTransaksi frm = new MasterTransaksi();
            frm.ShowDialog();
            this.Close();
        }
    }
}
