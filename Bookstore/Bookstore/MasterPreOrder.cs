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
        string arahOrderBy;
        string cari;
        string filterDari;
        string filterSampai;

        public MasterPreOrder(int role)
        {
            InitializeComponent();
            this.user_role = role;
            if(this.user_role == 1)
            {
                this.btnPOBaru.Visible = false;
            }

            btnDetail.Enabled = false;

            fullTableQuery = "select PO_ID, PO_INVOICE_NUMBER, PO_DATE, B_TITLE, concat('Rp ', format(PO_TOTAL,0,'de_DE')), concat('Rp ', format(PO_DOWN_PAYMENT,0,'de_DE')), (case when PO_M_ID is not null then M_NAME else 'Guest' end), (case when PO_STATUS=1 then 'Menunggu Buku' when PO_STATUS=2 then 'Siap Diproses' else 'Selesai' end) from pre_order join book on B_ID=PO_B_ID join member on M_ID=PO_M_ID";
            cari = "";
            filterDari = "";
            filterSampai = "";
            orderBy = "";
            arahOrderBy = "";

            loadDatabase();
            refreshDgv();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            int selectedIndex = dgPO.CurrentCell.RowIndex;
            if (selectedIndex == -1) return;
            taken = dtPO.Rows[selectedIndex];
            string poId = taken[0].ToString();

            FormDetailPreOrder frm = new FormDetailPreOrder(poId);
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

        public void loadDatabase()
        {
            query = fullTableQuery;
            if(cari!="" || (dtpDari.Value<dtpSampai.Value && filterDari!="" && filterSampai!=""))
            {
                query += " where ";
                if (cari != "")
                {
                    query = query + "lower(B_TITLE) LIKE '%" + cari + "%' OR lower(PO_ID) LIKE '%" + cari + "%' OR lower(PO_INVOICE_NUMBER) LIKE '%" + cari + "%' OR lower(M_NAME) LIKE '%" + cari + "%'";
                    if (dtpDari.Value < dtpSampai.Value)
                    {
                        query += " AND ";
                    }
                }
                if (dtpDari.Value < dtpSampai.Value)
                {
                    query = query + "PO_DATE >= STR_TO_DATE('" + filterDari + "', '%d-%m-%y') AND PO_DATE <= STR_TO_DATE('" + filterSampai + "', '%d-%m-%y')";
                }
            }
            if(orderBy!="" && arahOrderBy != "")
            {
                query += " order by " + orderBy + " " + arahOrderBy;
            }
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
            dgPO.Columns[3].HeaderText = "Judul Buku";
            dgPO.Columns[4].HeaderText = "Total";
            dgPO.Columns[5].HeaderText = "Uang Muka";
            dgPO.Columns[6].HeaderText = "Customer";
            dgPO.Columns[7].HeaderText = "Status";
        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            cari = tbCari.Text.ToLower();

            loadDatabase();
            refreshDgv();
        }

        private void dtpDari_ValueChanged(object sender, EventArgs e)
        {
            filterDari = dtpDari.Value.ToString("dd-MM-yy");

            loadDatabase();
            refreshDgv();
        }

        private void dtpSampai_ValueChanged(object sender, EventArgs e)
        {
            filterSampai = dtpSampai.Value.ToString("dd-MM-yy");

            loadDatabase();
            refreshDgv();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cmbSort.SelectedIndex;

            if (idx == 0)
            {
                orderBy = "PO_ID";
            }
            else if (idx == 1)
            {
                orderBy = "PO_INVOICE_NUMBER";
            }
            else if (idx == 2)
            {
                orderBy = "PO_DATE";
            }
            else if (idx == 3)
            {
                orderBy = "B_TITLE";
            }
            else if (idx == 4)
            {
                orderBy = "PO_TOTAL";
            }

            loadDatabase();
            refreshDgv();
        }

        private void rbAsc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAsc.Checked)
            {
                arahOrderBy = "ASC";
            }

            loadDatabase();
            refreshDgv();
        }

        private void rbDesc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDesc.Checked)
            {
                arahOrderBy = "DESC";
            }

            loadDatabase();
            refreshDgv();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbCari.Text = "";
            dtpDari.Value = DateTime.Now;
            dtpSampai.Value = DateTime.Now;
            cmbSort.SelectedIndex = -1;
            rbAsc.Checked = false;
            rbDesc.Checked = false;

            btnDetail.Enabled = false;

            cari = "";
            filterDari = "";
            filterSampai = "";
            orderBy = "";
            arahOrderBy = "";

            loadDatabase();
            refreshDgv();
        }

        private void dgPO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDetail.Enabled = true;
        }
    }
}
