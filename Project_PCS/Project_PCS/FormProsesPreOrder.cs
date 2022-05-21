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

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDetailPreOrder frm = new FormDetailPreOrder();
            frm.ShowDialog();
            this.Close();
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDetailPreOrder frm = new FormDetailPreOrder();
            frm.ShowDialog();
            this.Close();
        }
    }
}
