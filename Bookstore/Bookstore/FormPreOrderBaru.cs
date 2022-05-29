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
    public partial class FormPreOrderBaru : Form
    {
        string invoice;
        string tanggal;
        int harga;
        int subtotal;
        int uangmuka;
        int grandtotal;

        public FormPreOrderBaru()
        {
            InitializeComponent();
            loadHeader();

            rbGuest.Checked = true;
            btnCariMember.Enabled = false;

            harga = 0;
            subtotal = 0;
            grandtotal = 0;
            uangmuka = 0;

            //dgCart.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgCart.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgCart.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public void loadHeader()
        {
            MySqlCommand cmd = new MySqlCommand("select generateInvoicePO()", Koneksi.getConn());
            invoice = cmd.ExecuteScalar().ToString();
            tbNota.Text = invoice;

            tanggal = DateTime.Now.ToString("dd/MM/yyyy");
            lbTanggal.Text = tanggal;
        }

        private void btnCariBuku_Click(object sender, EventArgs e)
        {
            FormCariBuku frm = new FormCariBuku("preorder");
            var result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbKodeBuku.Text = frm.book_id;
                MySqlCommand cmd = new MySqlCommand("select B_TITLE, B_PRICE from book where B_ID=@book_id", Koneksi.getConn());
                cmd.Parameters.AddWithValue("@book_id", tbKodeBuku.Text);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tbJudulBuku.Text = reader[0].ToString();
                    harga = Convert.ToInt32(reader[1]);
                    tbHargaBuku.Text = harga.ToString("N0", new System.Globalization.CultureInfo("id-ID"));
                }
                reader.Close();
            }
        }

        private void btnCariMember_Click(object sender, EventArgs e)
        {
            FormCariMember frm = new FormCariMember();
            var result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbKodeMember.Text = frm.member_id;
            }
        }

        private void FormPreOrderBaru_Load(object sender, EventArgs e)
        {

        }

        private void rbGuest_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGuest.Checked)
            {
                btnCariMember.Enabled = false;
            }
        }

        private void rbMember_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMember.Checked)
            {
                btnCariMember.Enabled = true;
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (btnTambah.Text == "Edit")
            {
                dgCart.Rows.Clear();
            }

            if (tbKodeBuku.Text == "-")
            {
                MessageBox.Show("Belum ada buku yang dipilih");
            }
            else if (nudQty.Value <= 0)
            {
                MessageBox.Show("Qty harus lebih dari 0");
            }
            else
            {
                string bookId = tbKodeBuku.Text;
                string judul = tbJudulBuku.Text;
                int qty = Convert.ToInt32(nudQty.Value);
                subtotal = harga * qty;

                string dgvHarga = "Rp" + harga.ToString("N0", new System.Globalization.CultureInfo("id-ID"));
                string dgvSubtotal = "Rp" + subtotal.ToString("N0", new System.Globalization.CultureInfo("id-ID"));

                dgCart.Rows.Add(bookId, judul, dgvHarga, qty, dgvSubtotal);

                lbTotalQty.Text = qty.ToString();
                lbSubtotal.Text = subtotal.ToString("N0", new System.Globalization.CultureInfo("id-ID"));
                grandtotal = 0;
                lbGrandTotal.Text = grandtotal.ToString("N0", new System.Globalization.CultureInfo("id-ID"));
            }
        }

        private void tbDP_TextChanged(object sender, EventArgs e)
        {
            if (tbDP.Text != "")
            {
                uangmuka = Convert.ToInt32(tbDP.Text);
                grandtotal = uangmuka;
                lbGrandTotal.Text = grandtotal.ToString("N0", new System.Globalization.CultureInfo("id-ID"));
            }
        }

        public void clearAll()
        {
            dgCart.Rows.Clear();
            btnEdit.Enabled = false;
            btnHapus.Enabled = false;

            subtotal = 0;
            harga = 0;
            uangmuka = 0;
            grandtotal = 0;
            lbSubtotal.Text = "0";
            tbDP.Text = "0";
            lbGrandTotal.Text = "0";

            tbKodeBuku.Text = "-";
            tbJudulBuku.Text = "-";
            tbHargaBuku.Text = "0";
            nudQty.Value = 0;
        }

        private void dgCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.Enabled = true;
            btnHapus.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnTambah.Text = "Edit";

            tbKodeBuku.Text = dgCart.Rows[0].Cells[0].Value.ToString();
            tbJudulBuku.Text = dgCart.Rows[0].Cells[1].Value.ToString();
            tbHargaBuku.Text = harga.ToString("N0", new System.Globalization.CultureInfo("id-ID"));
            nudQty.Value = Convert.ToInt32(dgCart.Rows[0].Cells[3].Value);
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            MySqlTransaction trans = Koneksi.getConn().BeginTransaction();
            try
            {
                MySqlCommand cmd = new MySqlCommand("select generateIdPO()", Koneksi.getConn());
                string poId = cmd.ExecuteScalar().ToString();
                string invoice = tbNota.Text;

                string bookId = dgCart.Rows[0].Cells[0].Value.ToString();

                string memberId;
                if (rbGuest.Checked)
                {
                    memberId = "0";
                }
                else if (rbMember.Checked)
                {
                    memberId = tbKodeMember.Text;
                }

                string qty = lbTotalQty.Text;
                string total = subtotal.ToString();
                string downpayment = uangmuka.ToString();

                string pembayaran = cmbPembayaran.Items[cmbPembayaran.SelectedIndex].ToString();
            }
            catch (MySqlException ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            clearAll();

            MasterPreOrder frm = new MasterPreOrder(0);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }
    }
}
