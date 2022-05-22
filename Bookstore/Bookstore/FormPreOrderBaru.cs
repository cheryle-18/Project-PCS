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
    public partial class FormPreOrderBaru : Form
    {
        public FormPreOrderBaru()
        {
            InitializeComponent();
        }

        private void btnCariBuku_Click(object sender, EventArgs e)
        {
            FormCariBuku frm = new FormCariBuku();
            frm.ShowDialog();
        }

        private void btnCariMember_Click(object sender, EventArgs e)
        {
            FormCariMember frm = new FormCariMember();
            frm.ShowDialog();
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            
        }

        private void FormPreOrderBaru_Load(object sender, EventArgs e)
        {

        }
    }
}
