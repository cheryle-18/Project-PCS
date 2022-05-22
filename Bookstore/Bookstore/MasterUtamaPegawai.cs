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
    public partial class MasterUtamaPegawai : KryptonForm
    {
        public MasterUtamaPegawai()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void reAddControls(Form x)
        {
            Panel temp = (Panel)x.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Add(temp);
        }

        private void MasterPegawai_Load(object sender, EventArgs e)
        {
            //user role = 0
            MasterBuku frm = new MasterBuku(0);
            reAddControls(frm);

        }

        private void refreshButton()
        {
            this.panel2.Controls.Clear();
            btnBuku.BackColor = Color.MidnightBlue;
            btnBuku.ForeColor = Color.White;

            btnPreOrder.BackColor = Color.MidnightBlue;
            btnPreOrder.ForeColor = Color.White;

            btnMember.BackColor = Color.MidnightBlue;
            btnMember.ForeColor = Color.White;

            btnTransaksi.BackColor = Color.MidnightBlue;
            btnTransaksi.ForeColor = Color.White;
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            refreshButton();
            btnTransaksi.BackColor = Color.White;
            btnTransaksi.ForeColor = Color.MidnightBlue;

            MasterTransaksi frm = new MasterTransaksi(0);
            reAddControls(frm);
        }

        private void btnBuku_Click(object sender, EventArgs e)
        {
            refreshButton();
            btnBuku.BackColor = Color.White;
            btnBuku.ForeColor = Color.MidnightBlue;

            MasterBuku frm = new MasterBuku(0);
            reAddControls(frm);
        }

        private void btnPreOrder_Click(object sender, EventArgs e)
        {
            refreshButton();
            btnPreOrder.BackColor = Color.White;
            btnPreOrder.ForeColor = Color.MidnightBlue;

            MasterPreOrder frm = new MasterPreOrder(0);
            reAddControls(frm);
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            refreshButton();
            btnMember.BackColor = Color.White;
            btnMember.ForeColor = Color.MidnightBlue;

            MasterMember frm = new MasterMember(0);
            reAddControls(frm);
        }

        private void MasterUtamaPegawai_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin frm = new FormLogin();
            frm.ShowDialog();
        }
    }
}
