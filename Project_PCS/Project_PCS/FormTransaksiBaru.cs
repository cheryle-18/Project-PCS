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
    public partial class FormTransaksiBaru : Form
    {
        public FormTransaksiBaru()
        {
            InitializeComponent();
        }

        private void FormTransaksiBaru_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterTransaksi frm = new MasterTransaksi();
            frm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCariBuku frm = new FormCariBuku();
            frm.ShowDialog();
            this.Close();
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

        private void rbMember_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMember.Checked)
            {
                lbPoinTersedia.Text = "150";
                nudPoint.Enabled = true;
                btnCariMember.Enabled = true;
                lbDisc.Text = "100.000";
                lbGrandTotal.Text = "500.000";
                tbKodeMember.Text = "MEM025";
            }
        }

        private void rbGuest_CheckedChanged(object sender, EventArgs e)
        {
            lbPoinTersedia.Text = "-";
            nudPoint.Enabled = false;
            btnCariMember.Enabled = false;
            lbDisc.Text = "0";
            lbGrandTotal.Text = "600.000";
            tbKodeMember.Text = "";
        }
    }
}
