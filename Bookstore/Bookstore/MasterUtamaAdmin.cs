using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;


namespace Bookstore
{
    public partial class MasterUtamaAdmin : KryptonForm
    {
        string nama;
        public MasterUtamaAdmin(string username)
        {
            InitializeComponent();
            nama = char.ToUpper(username[0])+username.Substring(1);
        }

        private void MasterUtamaAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void reAddControls(Form x)
        {
            Panel temp = (Panel)x.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Add(temp);
        }

        private void refreshButton()
        {
            this.panel2.Controls.Clear();
            btnBuku.BackColor = Color.MidnightBlue;
            btnBuku.ForeColor = Color.White;

            btnPenerbit.BackColor = Color.MidnightBlue;
            btnPenerbit.ForeColor = Color.White;

            btnPreOrder.BackColor = Color.MidnightBlue;
            btnPreOrder.ForeColor = Color.White;

            btnMember.BackColor = Color.MidnightBlue;
            btnMember.ForeColor = Color.White;

            btnTransaksi.BackColor = Color.MidnightBlue;
            btnTransaksi.ForeColor = Color.White;

            btnKategori.BackColor = Color.MidnightBlue;
            btnKategori.ForeColor = Color.White;

            btnPegawai.BackColor = Color.MidnightBlue;
            btnPegawai.ForeColor = Color.White;

            btnLaporan.BackColor = Color.MidnightBlue;
            btnLaporan.ForeColor = Color.White;
        }

        private void MasterUtamaAdmin_Load(object sender, EventArgs e)
        {
            //user_role = 1
            lbNama.Text = "Halo, "+nama;
            MasterBuku frm = new MasterBuku(1);
            reAddControls(frm);
        }

        private void btnPenerbit_Click(object sender, EventArgs e)
        {
            refreshButton();
            btnPenerbit.BackColor = Color.White;
            btnPenerbit.ForeColor = Color.MidnightBlue;

            MasterPenerbitAdmin frm = new MasterPenerbitAdmin();
            reAddControls(frm);
        }

        private void btnBuku_Click(object sender, EventArgs e)
        {
            refreshButton();
            btnBuku.BackColor = Color.White;
            btnBuku.ForeColor = Color.MidnightBlue;

            MasterBuku frm = new MasterBuku(1);
            reAddControls(frm);
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            refreshButton();
            btnKategori.BackColor = Color.White;
            btnKategori.ForeColor = Color.MidnightBlue;

            MasterKategoriAdmin frm = new MasterKategoriAdmin();
            reAddControls(frm);
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            refreshButton();
            btnTransaksi.BackColor = Color.White;
            btnTransaksi.ForeColor = Color.MidnightBlue;

            MasterTransaksi frm = new MasterTransaksi(1);
            reAddControls(frm);
        }

        private void btnPreOrder_Click(object sender, EventArgs e)
        {
            refreshButton();
            btnPreOrder.BackColor = Color.White;
            btnPreOrder.ForeColor = Color.MidnightBlue;

            MasterPreOrder frm = new MasterPreOrder(1);
            reAddControls(frm);
        }

        private void btnPegawai_Click(object sender, EventArgs e)
        {
            refreshButton();
            btnPegawai.BackColor = Color.White;
            btnPegawai.ForeColor = Color.MidnightBlue;

            MasterPegawaiAdmin frm = new MasterPegawaiAdmin();
            reAddControls(frm);
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            refreshButton();
            btnMember.BackColor = Color.White;
            btnMember.ForeColor = Color.MidnightBlue;

            MasterMember frm = new MasterMember(1);
            reAddControls(frm);
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            refreshButton();
            btnLaporan.BackColor = Color.White;
            btnLaporan.ForeColor = Color.MidnightBlue;

            MasterLaporanAdmin frm = new MasterLaporanAdmin();
            reAddControls(frm);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin frm = new FormLogin();
            frm.ShowDialog();
        }

     
    }
}
