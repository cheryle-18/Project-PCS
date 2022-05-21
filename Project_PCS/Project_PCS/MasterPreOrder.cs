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
    public partial class MasterPreOrder : Form
    {
        public MasterPreOrder()
        {
            InitializeComponent();
        }

        private void MasterPreOrder_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin frm = new FormLogin();
            frm.ShowDialog();
        }

        private void btnBuku_MouseHover(object sender, EventArgs e)
        {
            btnBuku.BackColor = Color.White;
            btnBuku.ForeColor = Color.Navy;
        }

        private void btnBuku_MouseLeave(object sender, EventArgs e)
        {
            btnBuku.BackColor = Color.Navy;
            btnBuku.ForeColor = Color.White;
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

        private void btnBuku_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterBuku frm = new MasterBuku();
            frm.ShowDialog();
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterTransaksi frm = new MasterTransaksi();
            frm.ShowDialog();
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterMember frm = new MasterMember();
            frm.ShowDialog();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDetailPreOrder frm = new FormDetailPreOrder();
            frm.ShowDialog();
            this.Close();
        }

        private void btnPOBaru_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPreOrderBaru frm = new FormPreOrderBaru();
            frm.ShowDialog();
            this.Close();
        }
    }
}
