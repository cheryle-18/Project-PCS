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
    public partial class MasterBuku : KryptonForm
    {
        //user_role = 0 (employee)
        //user_role = 1 (admin)
        private int user_role;
        public MasterBuku(int role)
        {
            InitializeComponent();
            this.user_role = role;
            if(this.user_role == 0)
            {
                this.btnInsert.Visible = false;
            }
        }

        private void MasterBuku_Load(object sender, EventArgs e)
        {

        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            Panel temp;
            if(user_role == 0)
            {
                FormDetailBuku frm = new FormDetailBuku();
                temp = (Panel)frm.Controls[0];
            }
            else
            {
                FormDetailBukuAdmin frm = new FormDetailBukuAdmin();
                temp = (Panel)frm.Controls[0];
              
            }
            temp.Width = panelBuku.Width;
            temp.Height = panelBuku.Height;
            this.panelBuku.Controls.Clear();
            this.panelBuku.Controls.Add(temp);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            FormBukuBaruAdmin frm = new FormBukuBaruAdmin();
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panelBuku.Width;
            temp.Height = panelBuku.Height;
            this.panelBuku.Controls.Clear();
            this.panelBuku.Controls.Add(temp);
        
        }
    }
}
