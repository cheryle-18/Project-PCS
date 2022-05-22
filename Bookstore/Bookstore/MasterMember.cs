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
    public partial class MasterMember : Form
    {
        private int user_role;
        public MasterMember(int role)
        {
            InitializeComponent();
            this.user_role = role;
            if(this.user_role == 1)
            {
                this.btnMemberBaru.Visible = false;
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            FormDetailMember frm = new FormDetailMember(user_role);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void btnMemberBaru_Click(object sender, EventArgs e)
        {
            FormMemberBaru frm = new FormMemberBaru();
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void MasterMember_Load(object sender, EventArgs e)
        {

        }
    }
}
