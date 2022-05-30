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
using MySql.Data.MySqlClient;

namespace Bookstore
{
    public partial class MasterTransaksi : KryptonForm
    {
        private int user_role;
        DataTable dtTransaksi;
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
            loadDGV();
            refreshGridView();
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

        private void MasterTransaksi_Load(object sender, EventArgs e)
        {

        }

        private void loadDGV()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT htrans_purchase.`HP_ID`,htrans_purchase.`HP_INVOICE_NUMBER`,htrans_purchase.`HP_DATE`,htrans_purchase.`HP_TOTAL_QTY`,htrans_purchase.HP_TOTAL,htrans_purchase.`HP_TOTAL_PAID`,(CASE WHEN member.`M_NAME` IS NULL THEN 'Non-Member' ELSE member.`M_NAME` END) AS M_NAME FROM htrans_purchase LEFT JOIN member ON htrans_purchase.`HP_M_ID` = member.`M_ID`; ", Koneksi.getConn());
                dtTransaksi = new DataTable();
                adapter.Fill(dtTransaksi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void refreshGridView()
        {
            dgvTransaksi.DataSource = dtTransaksi;
            dgvTransaksi.Columns["HP_ID"].HeaderText = "Kode Transaksi";
            dgvTransaksi.Columns["HP_INVOICE_NUMBER"].HeaderText = "Nomor Nota";
            dgvTransaksi.Columns["HP_DATE"].HeaderText = "Tanggal";
            dgvTransaksi.Columns["HP_TOTAL_QTY"].HeaderText = "Qty";
            dgvTransaksi.Columns["HP_TOTAL"].HeaderText = "Total";
            dgvTransaksi.Columns["HP_TOTAL_PAID"].HeaderText = "Total Paid";
            dgvTransaksi.Columns["M_NAME"].HeaderText = "Customer";
            dgvTransaksi.ClearSelection();
        }
    }
}
