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

                MySqlCommand cmd = new MySqlCommand("select M_NAME from member where M_ID=@m_id", Koneksi.getConn());
                cmd.Parameters.AddWithValue("@m_id", frm.member_id);
                tbNamaMember.Text = cmd.ExecuteScalar().ToString();
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

                tbKodeBuku.Text = "-";
                tbJudulBuku.Text = "-";
                tbHargaBuku.Text = "0";
                nudQty.Value = 0;
                dgCart.ClearSelection();
            }

            btnCancelEdit.Visible = false;
            btnTambah.Text = "Tambah";
            btnEdit.Enabled = false;
            btnHapus.Enabled = false;
        }

        private void tbDP_TextChanged(object sender, EventArgs e)
        {
            if (tbDP.Text != "")
            {
                try
                {
                    uangmuka = Convert.ToInt32(tbDP.Text);
                }
                catch
                {
                    MessageBox.Show("Uang muka minimal 50% dari subtotal!");
                }

                if(uangmuka > subtotal)
                {
                    MessageBox.Show("Uang muka melebihi subtotal!");
                }
                else
                {
                    grandtotal = uangmuka;
                    lbGrandTotal.Text = grandtotal.ToString("N0", new System.Globalization.CultureInfo("id-ID"));
                }
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

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            tbKodeBuku.Text = "-";
            tbJudulBuku.Text = "-";
            tbHargaBuku.Text = "0";
            nudQty.Value = 0;
            btnCancelEdit.Visible = false;
            btnTambah.Text = "Tambah";
            btnEdit.Enabled = false;
            btnHapus.Enabled = false;
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

            btnCancelEdit.Visible = true;
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if(cmbPembayaran.SelectedIndex < 0)
            {
                MessageBox.Show("Metode pembayaran belum dipilih!");
            }
            else if (subtotal <= 0)
            {
                MessageBox.Show("Belum ada buku terpilih!");
            }
            else if (uangmuka < Convert.ToInt32(subtotal/2))
            {
                MessageBox.Show("Uang muka minimal 50% dari subtotal!");
            }
            else
            {
                MySqlTransaction trans = Koneksi.getConn().BeginTransaction();
                try
                {
                    //get employee
                    MySqlCommand cmd = new MySqlCommand("SELECT E_ID FROM employee WHERE E_U_ID = @us_id;", Koneksi.getConn());
                    cmd.Parameters.AddWithValue("@us_id", FormLogin.us_id);
                    string emId = cmd.ExecuteScalar().ToString();

                    //generate id po
                    cmd = new MySqlCommand("select generateIdPO()", Koneksi.getConn());
                    string poId = cmd.ExecuteScalar().ToString();
                    string invoice = tbNota.Text;

                    //buku
                    string bookId = dgCart.Rows[0].Cells[0].Value.ToString();

                    //member
                    string memberId = null;
                    if (rbGuest.Checked)
                    {
                        memberId = null;
                    }
                    else if (rbMember.Checked)
                    {
                        memberId = tbKodeMember.Text;
                    }

                    //harga + pembayaran
                    int qty = Convert.ToInt32(lbTotalQty.Text);
                    string pembayaran = cmbPembayaran.Items[cmbPembayaran.SelectedIndex].ToString();

                    //insert
                    cmd = new MySqlCommand("insert into pre_order values(@po_id, @invoice, CURRENT_DATE, @b_id, @e_id, @m_id, @qty, @total, @downpayment, @method, @status)", Koneksi.getConn());
                    cmd.Parameters.AddWithValue("@po_id", poId);
                    cmd.Parameters.AddWithValue("@invoice", invoice);
                    cmd.Parameters.AddWithValue("@b_id", bookId);
                    cmd.Parameters.AddWithValue("@e_id", emId);
                    cmd.Parameters.AddWithValue("@m_id", memberId);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@total", subtotal);
                    cmd.Parameters.AddWithValue("@downpayment", uangmuka);
                    cmd.Parameters.AddWithValue("@method", pembayaran);
                    cmd.Parameters.AddWithValue("@status", 1);

                    cmd.ExecuteNonQuery();

                    //commit
                    trans.Commit();
                    MessageBox.Show("Pre-Order Berhasil!");

                    //kembali ke master
                    clearAll();

                    MasterPreOrder frm = new MasterPreOrder(0);
                    Panel temp = (Panel)frm.Controls[0];
                    temp.Width = panel2.Width;
                    temp.Height = panel2.Height;
                    this.panel2.Controls.Clear();
                    this.panel2.Controls.Add(temp);
                }
                catch (MySqlException ex)
                {
                    trans.Rollback();
                    MessageBox.Show(ex.Message);
                }
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
