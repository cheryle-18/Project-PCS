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
    public partial class FormCariPO : Form
    {
        DataTable dtPO;
        public string po_id { get; set; }
        string query;
        string where;

        public FormCariPO()
        {
            InitializeComponent();

            query = "select PO_ID, PO_INVOICE_NUMBER, B_TITLE, PO_QTY, CONCAT('Rp ', format(PO_TOTAL,0,'de_DE')), CONCAT('Rp ', format(PO_DOWN_PAYMENT,0,'de_DE')), M_NAME from pre_order join book on B_ID=PO_B_ID join member on M_ID=PO_M_ID where PO_STATUS=2";
            where = "";

            loadDatabase();
            refreshDgv();
        }

        public void loadDatabase()
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query+where, Koneksi.getConn());
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
            dgPO.Columns[2].HeaderText = "Judul Buku";
            dgPO.Columns[3].HeaderText = "Qty";
            dgPO.Columns[4].HeaderText = "Total";
            dgPO.Columns[5].HeaderText = "Uang Muka";
            dgPO.Columns[6].HeaderText = "Customer";

            //dgPO.Columns[3].Width = 70;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btnPilih_Click(object sender, EventArgs e)
        {
            if (this.po_id != null && this.po_id != "")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Belum ada pre order yang terpilih!");
            }
        }

        private void FormCariPO_Load(object sender, EventArgs e)
        {

        }

        private void dgPO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                this.po_id = dgPO.Rows[dgPO.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            string cari = tbCari.Text;
            where = " AND  PO_ID like '%" + cari + "%' OR PO_INVOICE_NUMBER like '%" + cari + "%'";

            loadDatabase();
            refreshDgv();
        }
    }
}
