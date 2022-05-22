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
    public partial class MasterTransaksi : KryptonForm
    {
        private int user_role;
        public MasterTransaksi(int role)
        {
            InitializeComponent();
            this.user_role = role;
            if (user_role == 1)
            {
                //admin
                //can't create new transactions
                this.btnTransBaru.Visible = false;
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            FormDetailTransaksi frm = new FormDetailTransaksi(user_role);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);

        }

        private void btnTransBaru_Click(object sender, EventArgs e)
        {
            FormTransaksiBaru frm = new FormTransaksiBaru();
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }
    }
}
