using MySql.Data.MySqlClient;
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

        DataTable dtPO;
        DataRow taken;
        string fullTableQuery;
        string query;
        string orderBy;

        public MasterPreOrder(int role)
        {
            InitializeComponent();
            this.user_role = role;
            if(this.user_role == 1)
            {
                this.btnPOBaru.Visible = false;
            }

            fullTableQuery = "select PO_ID, PO_INVOICE_NUMBER, PO_DATE, PO_B_ID, PO_QTY, PO_TOTAL, PO_DOWN_PAYMENT, (case when PO_M_ID is not null then M_NAME else 'Guest' end) from pre_order join member on M_ID=PO_M_ID";
            orderBy = "";
            query = fullTableQuery;

            loadDatabase(query);
            refreshDgv();
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

        public void loadDatabase(string query)
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());

                dtPO = new DataTable();
                da.Fill(dtPO);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void refreshDgv()
        {
            dgPO.DataSource = dtPO;
            dgPO.Columns[0].HeaderText = "Kode PO";
            dgPO.Columns[1].HeaderText = "Nomor Nota";
            dgPO.Columns[2].HeaderText = "Tanggal PO";
            dgPO.Columns[3].HeaderText = "Kode Buku";
            dgPO.Columns[4].HeaderText = "Qty";
            dgPO.Columns[5].HeaderText = "Total";
            dgPO.Columns[6].HeaderText = "Uang Muka";
            dgPO.Columns[7].HeaderText = "Nama Member";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
