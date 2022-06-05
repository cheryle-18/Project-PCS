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
        private int selected_idx_dgv;
        DataTable dtTransaksi;

        string fullTableQuery;
        string query;
        string orderBy;
        string arahOrderBy;
        string cari;
        string filterDari;
        string filterSampai;
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

            btnDetail.Enabled = false;

            fullTableQuery = "SELECT htrans_purchase.`HP_ID`,htrans_purchase.`HP_INVOICE_NUMBER`,DATE_FORMAT(htrans_purchase.`HP_DATE`,'%d/%m/%Y') AS HP_DATE,htrans_purchase.`HP_TOTAL_QTY`,CONCAT('Rp ',FORMAT(htrans_purchase.HP_TOTAL,0,'id_ID')) AS HP_TOTAL, CONCAT('Rp ',FORMAT(htrans_purchase.HP_TOTAL_PAID,0,'id_ID')) AS HP_TOTAL_PAID,htrans_purchase.HP_PAYMENT_METHOD,(CASE WHEN `member`.`M_NAME` IS NULL THEN 'Non-Member' ELSE `member`.`M_NAME` END) AS MEMBER_NAME FROM htrans_purchase LEFT JOIN `member` ON htrans_purchase.`HP_M_ID` = `member`.`M_ID`";
            cari = "";
            filterDari = "";
            filterSampai = "";
            orderBy = "";
            arahOrderBy = "";

            loadDGV();
            refreshGridView();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if(selected_idx_dgv != -1)
            {
                //GO TO DETAIL FORM
                string tr_id = dgvTransaksi.Rows[selected_idx_dgv].Cells[0].Value.ToString();
                FormDetailTransaksi frm = new FormDetailTransaksi(user_role,tr_id);
                Panel temp = (Panel)frm.Controls[0];
                temp.Width = panel2.Width;
                temp.Height = panel2.Height;
                this.panel2.Controls.Clear();
                this.panel2.Controls.Add(temp);
            }
            else
            {
                MessageBox.Show("Belum ada transaksi yang dipilih!");
            }
           

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
                query = fullTableQuery;
                if (cari != "" || (dtpDari.Value <= dtpSampai.Value && filterDari != "" && filterSampai != ""))
                {
                    query += " having ";
                    if (cari != "")
                    {
                        query = query + "lower(HP_ID) LIKE '%" + cari + "%' OR lower(HP_INVOICE_NUMBER) LIKE '%" + cari + "%' OR lower(HP_PAYMENT_METHOD) LIKE '%" + cari + "%' OR lower(MEMBER_NAME) LIKE '%" + cari + "%'";
                        if (dtpDari.Value <= dtpSampai.Value)
                        {
                            query += " AND ";
                        }
                    }
                    if (dtpDari.Value <= dtpSampai.Value)
                    {
                        query = query + "STR_TO_DATE(HP_DATE,'%d/%m/%Y') >= STR_TO_DATE('" + filterDari + "','%d/%m/%Y') AND STR_TO_DATE(HP_DATE,'%d/%m/%Y')  <= STR_TO_DATE('" + filterSampai+"','%d/%m/%Y')";

                    }
                }
                if (orderBy != "" && arahOrderBy != "")
                {
                    query += " order by " + orderBy + " " + arahOrderBy;
                }
                Console.WriteLine(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, Koneksi.getConn());
                dtTransaksi = new DataTable();
                adapter.Fill(dtTransaksi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"--"+query);
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
            dgvTransaksi.Columns["HP_PAYMENT_METHOD"].HeaderText = "Metode Pembayaran";
            dgvTransaksi.Columns["MEMBER_NAME"].HeaderText = "Customer";
            dgvTransaksi.ClearSelection();
        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            cari = tbCari.Text.ToLower();

            loadDGV();
            refreshGridView();
        }

        private void dtpDari_ValueChanged(object sender, EventArgs e)
        {
            filterDari = dtpDari.Value.ToString("dd/MM/yy");

            loadDGV();
            refreshGridView();
        }

        private void dtpSampai_ValueChanged(object sender, EventArgs e)
        {
            filterSampai = dtpSampai.Value.ToString("dd/MM/yy");

            loadDGV();
            refreshGridView();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cmbSort.SelectedIndex;

            if (idx == 0)
            {
                orderBy = "HP_ID";
            }
            else if (idx == 1)
            {
                orderBy = "HP_INVOICE_NUMBER";
            }
            else if (idx == 2)
            {
                orderBy = "HP_DATE";
            }
            else if (idx == 3)
            {
                orderBy = "HP_TOTAL_QTY";
            }
            else if (idx == 4)
            {
                orderBy = "HP_TOTAL";
            }

            loadDGV();
            refreshGridView();
        }

        private void rbAsc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAsc.Checked)
            {
                arahOrderBy = "ASC";
            }

            loadDGV();
            refreshGridView();
        }

        private void rbDesc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDesc.Checked)
            {
                arahOrderBy = "DESC";
            }
            loadDGV();
            refreshGridView();
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

            selected_idx_dgv = -1;
            dgvTransaksi.ClearSelection();
            cari = "";
            filterDari = "";
            filterSampai = "";
            orderBy = "";
            arahOrderBy = "";
            loadDGV();
            refreshGridView();

        }

        private void dgvTransaksi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //CHECK ROW INDEX = -1?

            if(e.RowIndex != -1)
            {
                btnDetail.Enabled = true;
                selected_idx_dgv = e.RowIndex;
            }
            
        }
    }
}
