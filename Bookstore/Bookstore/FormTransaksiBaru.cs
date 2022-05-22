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
    public partial class FormTransaksiBaru : Form
    {
        public FormTransaksiBaru()
        {
            InitializeComponent();
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            MasterTransaksi frm = new MasterTransaksi(0);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            MasterTransaksi frm = new MasterTransaksi(0);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void btnCariBuku_Click(object sender, EventArgs e)
        {
            FormCariBuku frm = new FormCariBuku();
            frm.ShowDialog();
        }

        private void btnCariMember_Click(object sender, EventArgs e)
        {
            FormCariMember frm = new FormCariMember();
            frm.ShowDialog();
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
            if (rbGuest.Checked)
            {
                lbPoinTersedia.Text = "-";
                nudPoint.Enabled = false;
                btnCariMember.Enabled = false;
                lbDisc.Text = "0";
                lbGrandTotal.Text = "600.000";
                tbKodeMember.Text = "";
            }
        }

        private void FormTransaksiBaru_Load(object sender, EventArgs e)
        {

        }
    }
}
