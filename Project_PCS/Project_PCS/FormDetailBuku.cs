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
    public partial class FormDetailBuku : Form
    {
        public FormDetailBuku()
        {
            InitializeComponent();
        }

        private void FormDetailBuku_Load(object sender, EventArgs e)
        {
            pictureBox2.Load("https://embassybooks.in/image/catalog/Child/9781408855676.jpg");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterBuku frm = new MasterBuku();
            frm.ShowDialog();
            this.Close();
        }

        private void btnTransaksi_MouseHover(object sender, EventArgs e)
        {
            btnTransaksi.BackColor = Color.White;
            btnTransaksi.ForeColor = Color.Navy;
        }

        private void btnTransaksi_MouseLeave(object sender, EventArgs e)
        {
            btnTransaksi.BackColor = Color.Navy;
            btnTransaksi.ForeColor = Color.White;
        }

        private void btnPreOrder_MouseHover(object sender, EventArgs e)
        {
            btnPreOrder.BackColor = Color.White;
            btnPreOrder.ForeColor = Color.Navy;
        }

        private void btnPreOrder_MouseLeave(object sender, EventArgs e)
        {
            btnPreOrder.BackColor = Color.Navy;
            btnPreOrder.ForeColor = Color.White;
        }

        private void btnMember_MouseHover(object sender, EventArgs e)
        {
            btnMember.BackColor = Color.White;
            btnMember.ForeColor = Color.Navy;
        }

        private void btnMember_MouseLeave(object sender, EventArgs e)
        {
            btnMember.BackColor = Color.Navy;
            btnMember.ForeColor = Color.White;
        }

        private void btnLogout_MouseHover(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.White;
            btnLogout.ForeColor = Color.Navy;
        }

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.Navy;
            btnLogout.ForeColor = Color.White;
        }

        private void btnPreOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterPreOrder frm = new MasterPreOrder();
            frm.ShowDialog();
            this.Close();
        }

        private void FormDetailBuku_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
