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
    public partial class FormCariBuku : Form
    {
        public string book_id { get; set; }
        DataTable dtBuku;
        public FormCariBuku()
        {
            InitializeComponent();
            loadDGV();
            refreshGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btnPilih_Click(object sender, EventArgs e)
        {  
           if(this.book_id != null && this.book_id != "")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Belum ada buku yang terpilih!");
            }
        }

        private void FormCariBuku_Load(object sender, EventArgs e)
        {

        }

        private void loadDGV()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT book.`B_ID`,book.`B_TITLE`,book.`B_AUTHOR`,book.`B_PRICE`,(CASE WHEN book.`B_STATUS` = 1 THEN 'Tersedia' ELSE 'Tidak Tersedia' END) AS 'B_STATUS' FROM book;", Koneksi.getConn());
                dtBuku = new DataTable();
                adapter.Fill(dtBuku);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void refreshGridView()
        {
            dgvBuku.DataSource = dtBuku;
            dgvBuku.Columns["B_ID"].HeaderText = "ID Buku";
            dgvBuku.Columns["B_TITLE"].HeaderText = "Judul Buku";
            dgvBuku.Columns["B_AUTHOR"].HeaderText = "Penerbit Buku";
            dgvBuku.Columns["B_PRICE"].HeaderText = "Harga Buku";
            dgvBuku.Columns["B_STATUS"].HeaderText = "Status Buku";
            dgvBuku.ClearSelection();
        }

        private void dgvBuku_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ITEM SELECTED
            if(e.RowIndex != -1)
            {
                this.book_id = dgvBuku.Rows[dgvBuku.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT book.B_ID, book.`B_TITLE`, book.`B_AUTHOR`, book.`B_PRICE`,(CASE WHEN book.`B_STATUS` = 1 THEN 'Tersedia' ELSE 'Tidak Tersedia' END) AS 'B_STATUS' FROM book WHERE book.`B_ID` LIKE '%"+tbCari.Text+"%' OR book.B_TITLE LIKE '%"+tbCari.Text+"%' OR book.`B_AUTHOR` LIKE '%"+tbCari.Text+"%'; ", Koneksi.getConn());
                dtBuku = new DataTable();
                adapter.Fill(dtBuku);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            refreshGridView();
        }
    }
}
