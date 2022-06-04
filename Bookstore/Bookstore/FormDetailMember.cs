using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore
{
    public partial class FormDetailMember : Form
    {
        private string tr_id = "";
        private string m_id = "";
        private int user_role;
        DataTable dtDataMember;
        DataTable dtTransaksi;
        public FormDetailMember(int role,string m_id)
        {
            InitializeComponent();
            this.user_role = role;
            this.m_id = m_id;
            loadDatabase(m_id);
            refreshData();
            loadDatabaseTransaksi();
            refreshDgvTransaksi();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (tr_id == "")
            {
                try
                {
                    tr_id = dgTransaksi.Rows[0].Cells[0].Value.ToString();
                }
                catch (Exception)
                {

                }
            }
            if (tr_id != "")
            {
                FormDetailTransaksi frm = new FormDetailTransaksi(user_role, tr_id,m_id,true);
                Panel temp = (Panel)frm.Controls[0];
                temp.Width = panel2.Width;
                temp.Height = panel2.Height;
                this.panel2.Controls.Clear();
                this.panel2.Controls.Add(temp);
            }
        }
        void loadDatabase(string name)
        {
            string query = $"SELECT m_id,m_name,DATE_FORMAT(m_birthdate,'%d/%m/%Y'),m_address,m_telp,m_point,CONVERT(m_status, CHAR) FROM MEMBER where m_id = '{m_id}'";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());

                dtDataMember = new DataTable();
                da.Fill(dtDataMember);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void refreshData()
        {
            DataRow datamember = dtDataMember.Rows[0];
            //m_id,m_name,DATE_FORMAT(m_birthdate,'%e-%c-%Y'),m_address,m_telp,m_point,CONVERT(m_status, CHAR)
            //  0     1                     2                     3        4      5                6                         
            tbKode.Text = datamember[0].ToString();
            tbNama.Text = datamember[1].ToString();
            tbAlamat.Text = datamember[3].ToString();

            DateTime tanggalLahir;
            //MessageBox.Show(datamember[2].ToString());
            string tanggal = datamember[2].ToString();
            tanggalLahir = DateTime.ParseExact(tanggal, "dd/MM/yyyy", CultureInfo.CurrentCulture);
            dtpTanggalLahir.Value = tanggalLahir;
            tbTelepon.Text = datamember[4].ToString();
            tbJumlahPoin.Text = datamember[5].ToString();
            rbStatusNonAktif.Checked = true;
            if (datamember[6].ToString()=="1")
            {
                rbStatusAktif.Checked = true;
            }
        }

        private void btnSimpanPerubahan_Click(object sender, EventArgs e)
        {
            if (tbKode.Text == "" || tbNama.Text == "" || tbAlamat.Text == "" || tbTelepon.Text == "" || tbJumlahPoin.Text == "" || (!rbStatusAktif.Checked && !rbStatusNonAktif.Checked))
            {
                MessageBox.Show("Semua Field Harus Terisi!");
            }
            else
            {
                string query = $"UPDATE MEMBER SET M_NAME = @M_NAME, M_BIRTHDATE = @M_BIRTHDATE, M_ADDRESS = @M_ADDRESS, M_TELP = @M_TELP, M_STATUS = @M_STATUS WHERE M_ID = @M_ID;";
                MySqlCommand cmd = new MySqlCommand(query, Koneksi.getConn());
                cmd.Parameters.AddWithValue("@M_NAME", tbNama.Text);
                cmd.Parameters.AddWithValue("@M_BIRTHDATE", dtpTanggalLahir.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@M_ADDRESS", tbAlamat.Text);
                cmd.Parameters.AddWithValue("@M_TELP", tbTelepon.Text);
                cmd.Parameters.AddWithValue("@M_STATUS", Convert.ToInt32(rbStatusAktif.Checked));
                cmd.Parameters.AddWithValue("@M_ID", tbKode.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Simpan Perubahan Berhasil!");
            }
        }

        private void FormDetailMember_Load(object sender, EventArgs e)
        {

        }

        void loadDatabaseTransaksi()
        {
            string query = $"SELECT distinct htrans_purchase.`HP_ID`,htrans_purchase.`HP_INVOICE_NUMBER`,DATE_FORMAT(htrans_purchase.`HP_DATE`,'%d/%m/%Y') AS HP_DATE,htrans_purchase.`HP_TOTAL_QTY`,CONCAT('Rp ',FORMAT(htrans_purchase.HP_TOTAL,0,'id_ID')) AS HP_TOTAL, CONCAT('Rp ',FORMAT(htrans_purchase.HP_TOTAL_PAID,0,'id_ID')) AS HP_TOTAL_PAID,htrans_purchase.HP_PAYMENT_METHOD FROM htrans_purchase LEFT JOIN `member` ON htrans_purchase.`HP_M_ID` = '{m_id}'";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());

                dtTransaksi = new DataTable();
                da.Fill(dtTransaksi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void refreshDgvTransaksi()
        {
            dgTransaksi.DataSource = dtTransaksi;
            dgTransaksi.Columns["HP_ID"].HeaderText = "Kode Transaksi";
            dgTransaksi.Columns["HP_INVOICE_NUMBER"].HeaderText = "Nomor Nota";
            dgTransaksi.Columns["HP_DATE"].HeaderText = "Tanggal";
            dgTransaksi.Columns["HP_TOTAL_QTY"].HeaderText = "Qty";
            dgTransaksi.Columns["HP_TOTAL"].HeaderText = "Total";
            dgTransaksi.Columns["HP_TOTAL_PAID"].HeaderText = "Total Paid";
            dgTransaksi.Columns["HP_PAYMENT_METHOD"].HeaderText = "Metode Pembayaran";
            for (int i = 0; i < dgTransaksi.Columns.Count; i++)
            {
                dgTransaksi.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void dgTransaksi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tr_id = dgTransaksi.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                tr_id = "";
            }
        }
    }
}
