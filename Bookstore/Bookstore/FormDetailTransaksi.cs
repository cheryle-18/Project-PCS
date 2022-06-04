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
    public partial class FormDetailTransaksi : Form
    {
        private int user_role;
        private string tr_id;
        DataTable dtTransaksi;
        public FormDetailTransaksi(int role,string tr_id)
        {
            InitializeComponent();
            this.user_role = role;
            this.tr_id = tr_id;
            loadHeaderInfo();
            
            loadDGV();
            refreshGridView();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MasterTransaksi frm = new MasterTransaksi(user_role);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel1.Width;
            temp.Height = panel1.Height;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(temp);
        }

        private void FormDetailTransaksi_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLihatNota_Click(object sender, EventArgs e)
        {
            FormLihatNota frm = new FormLihatNota(user_role,tr_id);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel1.Width;
            temp.Height = panel1.Height;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(temp);
        }

        private void loadHeaderInfo()
        {
            //GET DB
            MySqlCommand cmd = new MySqlCommand("SELECT HP_ID,HP_INVOICE_NUMBER,HP_DATE,HP_TOTAL_QTY,HP_TOTAL,HP_TOTAL_PAID,HP_POINTS_USED,HP_POINTS_RECEIVED,HP_PAYMENT_METHOD,HP_E_ID, (CASE WHEN HP_M_ID IS NULL THEN 'Non-Member' ELSE 'Member' END) AS HP_TYPEM_ID, HP_M_ID FROM htrans_purchase WHERE HP_ID = @htrans_id", Koneksi.getConn());
            cmd.Parameters.AddWithValue("htrans_id", tr_id);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblKode.Text = dr["HP_ID"].ToString();
                lblNomorNota.Text = dr["HP_INVOICE_NUMBER"].ToString();
                lblTanggal.Text = Convert.ToDateTime(dr["HP_DATE"]).ToString("dd/MM/yyyy");
                lblQty.Text = dr["HP_TOTAL_QTY"].ToString();
                lblMetode.Text = dr["HP_PAYMENT_METHOD"].ToString();
                lblTotal.Text = "Rp " + Convert.ToInt32(dr["HP_TOTAL"]).ToString("N0",new System.Globalization.CultureInfo("id-ID"));
                lblPaid.Text = "Rp " + Convert.ToInt32(dr["HP_TOTAL_PAID"]).ToString("N0", new System.Globalization.CultureInfo("id-ID"));
                lblPoinDigunakan.Text = dr["HP_POINTS_USED"].ToString();
                lblPoinDiterima.Text = dr["HP_POINTS_RECEIVED"].ToString();
                lblPegawai.Text = dr["HP_E_ID"].ToString();
                lblJenisCustomer.Text = dr["HP_TYPEM_ID"].ToString();
                lblMember.Text = dr["HP_M_ID"].ToString() == "" ? "-" : dr["HP_M_ID"].ToString();

            }
            dr.Close();

        }

        private void loadDGV()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT DP_ID, DP_B_ID, book.`B_TITLE`, CONCAT('Rp ',FORMAT(book.`B_PRICE`,0,'id_ID')) AS B_PRICE, DP_QTY, CONCAT('Rp ',FORMAT(DP_SUBTOTAL,0,'id_ID')) AS DP_SUBTOTAL FROM dtrans_purchase JOIN book ON dtrans_purchase.`DP_B_ID` = book.`B_ID` WHERE DP_HP_ID = '"+tr_id+"';", Koneksi.getConn());
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
            dgvDetail.DataSource = dtTransaksi;
            dgvDetail.Columns["DP_ID"].HeaderText = "Kode Detail Transaksi";
            dgvDetail.Columns["DP_B_ID"].HeaderText = "Kode Buku";
            dgvDetail.Columns["B_TITLE"].HeaderText = "Judul Buku";
            dgvDetail.Columns["B_PRICE"].HeaderText = "Harga Buku";
            dgvDetail.Columns["DP_QTY"].HeaderText = "Qty";
            dgvDetail.Columns["DP_SUBTOTAL"].HeaderText = "Subtotal";
            dgvDetail.ClearSelection();
        }
    }
}
