using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Project_PCS
{
    public partial class MasterPreOrderAdmin : Form
    {
        public MasterPreOrderAdmin()
        {
            InitializeComponent();
        }

        private void MasterBuku_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin frm = new FormLogin();
            frm.ShowDialog();
            this.Close();
        }
        private void btn_MouseHover(object sender, EventArgs e)
        {
            Button btnTemp = (Button) sender;
            btnTemp.BackColor = Color.White;
            btnTemp.ForeColor = Color.Navy;
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btnTemp = (Button)sender;
            btnTemp.BackColor = Color.Navy;
            btnTemp.ForeColor = Color.White;
        }

        private void btnPreOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterPreOrder frm = new MasterPreOrder();
            frm.ShowDialog();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDetailBuku frm = new FormDetailBuku();
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
            MasterMemberAdmin frm = new MasterMemberAdmin();
            frm.ShowDialog();
        }

        private void MasterBuku_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnPenerbit_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterPenerbitAdmin frm = new MasterPenerbitAdmin();
            frm.ShowDialog();
        }

        private void btnBuku_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterBukuAdmin frm = new MasterBukuAdmin();
            frm.ShowDialog();
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterKategoriAdmin frm = new MasterKategoriAdmin();
            frm.ShowDialog();
        }

        private void btnTransaksi_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MasterTransaksiAdmin frm = new MasterTransaksiAdmin();
            frm.ShowDialog();
        }

        private void btnPegawai_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterPegawaiAdmin frm = new MasterPegawaiAdmin();
            frm.ShowDialog();
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterLaporanAdmin frm = new MasterLaporanAdmin();
            frm.ShowDialog();
        }
    }
}
