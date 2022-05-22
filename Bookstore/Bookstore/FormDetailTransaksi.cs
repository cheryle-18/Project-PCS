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
    public partial class FormDetailTransaksi : Form
    {
        private int user_role;
        public FormDetailTransaksi(int role)
        {
            InitializeComponent();
            this.user_role = role;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MasterTransaksi frm = new MasterTransaksi(user_role);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel1.Width;
            temp.Height = panel1.Height;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(temp);
        }

        private void FormDetailTransaksi_Load(object sender, EventArgs e)
        {

        }

        private void btnLihatNota_Click(object sender, EventArgs e)
        {
            FormLihatNota frm = new FormLihatNota(user_role);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel1.Width;
            temp.Height = panel1.Height;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(temp);
        }
    }
}
