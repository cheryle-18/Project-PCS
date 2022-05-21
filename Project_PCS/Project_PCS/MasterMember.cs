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
    public partial class MasterMember : Form
    {
        public MasterMember()
        {
            InitializeComponent();
        }

        private void MasterMember_Load(object sender, EventArgs e)
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

        private void btnPreOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterPreOrder frm = new MasterPreOrder();
            frm.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MasterMember_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDetailMember frm = new FormDetailMember();
            frm.ShowDialog();
        }

        private void btnMemberBaru_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMemberBaru frm = new FormMemberBaru();
            frm.ShowDialog();
        }
    }
}
