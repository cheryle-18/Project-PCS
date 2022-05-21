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
    public partial class FormDetailMember : Form
    {
        public FormDetailMember()
        {
            InitializeComponent();
        }

        private void FormDetailMember_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterMember frm = new MasterMember();
            frm.ShowDialog();
            this.Close();
        }
    }
}
