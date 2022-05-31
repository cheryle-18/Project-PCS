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
    public partial class FormLihatNotaPO : Form
    {
        string poId;
        int userRole;
        public FormLihatNotaPO(string po_id, int role)
        {
            InitializeComponent();
            this.poId = po_id;
            this.userRole = role;
        }

        private void FormLihatNotaPO_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormDetailPreOrder frm = new FormDetailPreOrder(poId, userRole);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel1.Width;
            temp.Height = panel1.Height;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(temp);
        }
    }
}
