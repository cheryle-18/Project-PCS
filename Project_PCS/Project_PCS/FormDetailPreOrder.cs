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
    public partial class FormDetailPreOrder : Form
    {
        public FormDetailPreOrder()
        {
            InitializeComponent();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            this.Hide();
            MasterPreOrder frm = new MasterPreOrder();
            frm.ShowDialog();
            this.Close();
        }

        private void btnPOBaru_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormProsesPreOrder frm = new FormProsesPreOrder();
            frm.ShowDialog();
            this.Close();
        }
    }
}
