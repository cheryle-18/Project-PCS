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
    public partial class FormProsesPreOrder : Form
    {
        public FormProsesPreOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCariPO frm = new FormCariPO();
            frm.ShowDialog();
        }

        private void rbMember_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FormProsesPreOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
