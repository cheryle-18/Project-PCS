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
    public partial class FormDetailBukuAdmin : Form
    {
        public FormDetailBukuAdmin()
        {
            InitializeComponent();
        }

        private void MasterBuku_Load(object sender, EventArgs e)
        {
            pictureBox2.Load("https://embassybooks.in/image/catalog/Child/9781408855676.jpg");
            cbFormat.SelectedIndex = 0;
            cbBahasa.SelectedIndex = 1;
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
            MasterPreOrderAdmin frm = new MasterPreOrderAdmin();
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
            MasterTransaksiAdmin frm = new MasterTransaksiAdmin();
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

        private void btnKategori_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterKategoriAdmin frm = new MasterKategoriAdmin();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterBukuAdmin frm = new MasterBukuAdmin();
            frm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterBukuAdmin frm = new MasterBukuAdmin();
            frm.ShowDialog();
            this.Close();
        }
    }
}
