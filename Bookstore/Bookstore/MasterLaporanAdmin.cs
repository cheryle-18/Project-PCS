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
    public partial class MasterLaporanAdmin : Form
    {
        public MasterLaporanAdmin()
        {
            InitializeComponent();
        }

        private void MasterLaporanAdmin_Load(object sender, EventArgs e)
        {

        }

        private void passToReport(int selection)
        {
            FormViewLaporan frm = new FormViewLaporan(selection);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void btnLaporanPreOrderBuku_Click(object sender, EventArgs e)
        {
            passToReport(1);
        }

        private void btnLaporanBukuDiatasRataRata_Click(object sender, EventArgs e)
        {
            passToReport(2);
        }

        private void btnLaporanBukuDibawahRataRata_Click(object sender, EventArgs e)
        {
            passToReport(3);
        }

        private void btnLaporanMemberPalingSering_Click(object sender, EventArgs e)
        {
            passToReport(4);
        }

        private void btnLaporanPegawaiPalingSering_Click(object sender, EventArgs e)
        {
            passToReport(5);
        }
    }
}
