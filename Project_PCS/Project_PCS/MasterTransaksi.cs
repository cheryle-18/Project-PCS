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
    public partial class MasterTransaksi : Form
    {
        public MasterTransaksi()
        {
            InitializeComponent();
        }

        private void MasterTransaksi_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin frm = new FormLogin();
            frm.ShowDialog();
            this.Close();
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

        private void btnBuku_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterBuku frm = new MasterBuku();
            frm.ShowDialog();
        }

        private void btnPreOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterPreOrder frm = new MasterPreOrder();
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
            FormDetailTransaksi frm = new FormDetailTransaksi();
            frm.ShowDialog();
            
        }

        private void MasterTransaksi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnTransBaru_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTransaksiBaru frm = new FormTransaksiBaru();
            frm.ShowDialog();
        }
    }
}
