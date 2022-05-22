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
    public partial class FormDetailMember : Form
    {
        private int user_role;
        public FormDetailMember(int role)
        {
            InitializeComponent();
            this.user_role = role;
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            MasterMember frm;
            Panel temp;
            if(user_role == 0)
            {
                frm = new MasterMember(0);
            }
            else
            {
                frm = new MasterMember(1);
            }
      
            temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }
    }
}
