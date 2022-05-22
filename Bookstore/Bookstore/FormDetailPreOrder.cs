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
    public partial class FormDetailPreOrder : Form
    {
        public FormDetailPreOrder()
        {
            InitializeComponent();
        }

        private void btnPOBaru_Click(object sender, EventArgs e)
        {
            FormProsesPreOrder frm = new FormProsesPreOrder();
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MasterPreOrder frm = new MasterPreOrder(0);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void FormDetailPreOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
