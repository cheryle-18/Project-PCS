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
    public partial class FormMemberBaru : Form
    {
        public FormMemberBaru()
        {
            InitializeComponent();
        }

        private void btnMemberBaru_Click(object sender, EventArgs e)
        {
            MasterMember frm = new MasterMember(0);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            MasterMember frm = new MasterMember(0);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }
    }
}
