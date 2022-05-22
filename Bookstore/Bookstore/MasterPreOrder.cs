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
    public partial class MasterPreOrder : Form
    {
        private int user_role;
        public MasterPreOrder(int role)
        {
            InitializeComponent();
            this.user_role = role;
            if(this.user_role == 1)
            {
                this.btnPOBaru.Visible = false;
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            FormDetailPreOrder frm = new FormDetailPreOrder();
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void btnPOBaru_Click(object sender, EventArgs e)
        {
            FormPreOrderBaru frm = new FormPreOrderBaru();
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void MasterPreOrder_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
