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
    public partial class FormMemberBaru : Form
    {
        public FormMemberBaru()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterMember frm = new MasterMember();
            frm.ShowDialog();
        }

        private void FormMemberBaru_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnMemberBaru_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterMember frm = new MasterMember();
            frm.ShowDialog();
        }
    }
}
