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
    public partial class FormProsesPreOrder : Form
    {
        string poId;
        string bookId;
        string memberId;
        int subtotal;
        int uangmuka;
        int diskon;
        int grandtotal;

        DataTable dtBuku;

        public FormProsesPreOrder(string poId)
        {
            InitializeComponent();
            this.poId = poId;

            diskon = 0;

            loadDetail();
            loadDgv();

            nudPoint.Controls[0].Visible = false;
        }

        public void loadDetail()
        {
            //detail PO
            MySqlCommand cmd = new MySqlCommand("select PO_INVOICE_NUMBER, date_format(PO_DATE, '%d/%m/%Y'), PO_B_ID, PO_M_ID, PO_QTY, PO_TOTAL, PO_DOWN_PAYMENT from pre_order where PO_ID=@po_id", Koneksi.getConn());
            cmd.Parameters.AddWithValue("@po_id", poId);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tbNotaPO.Text = reader[0].ToString();
                lbTanggal.Text = reader[1].ToString();
                bookId = reader[2].ToString();
                memberId = reader[3].ToString();
                lbTotalQty.Text = reader[4].ToString();

                subtotal = Convert.ToInt32(reader[5]);
                uangmuka = Convert.ToInt32(reader[6]);
            }
            reader.Close();

            lbSubtotal.Text = subtotal.ToString("N0", new System.Globalization.CultureInfo("id-ID"));
            lbDP.Text = uangmuka.ToString("N0", new System.Globalization.CultureInfo("id-ID"));

            grandtotal = subtotal - uangmuka;
            lbGrandTotal.Text = grandtotal.ToString("N0", new System.Globalization.CultureInfo("id-ID"));

            //nota transaksi
            cmd = new MySqlCommand("select generateInvoiceTrans()", Koneksi.getConn());
            tbNotaTrans.Text = cmd.ExecuteScalar().ToString();

            //load member
            if (memberId == "0")
            {
                rbGuest.Checked = true;
                nudPoint.Enabled = false;
            }
            else
            {
                rbMember.Checked = true;
                nudPoint.Enabled = true;
                tbKodeMember.Text = memberId;

                cmd = new MySqlCommand("select M_NAME, M_POINT from member where M_ID=@member_id", Koneksi.getConn());
                cmd.Parameters.AddWithValue("@member_id", memberId);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tbNamaMember.Text = reader[0].ToString();
                    lbPoinTersedia.Text = reader[1].ToString();
                }
                reader.Close();
            }
        }

        public void loadDgv()
        {
            string query = "select PO_B_ID, B_TITLE, CONCAT('Rp ', format(PO_TOTAL/PO_QTY, 0, 'de_DE')), PO_QTY, CONCAT('Rp ', format(PO_TOTAL, 0, 'de_DE')) from pre_order join book on B_ID=PO_B_ID where PO_ID='" + poId + "' AND B_ID='" + bookId + "'";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());
                dtBuku = new DataTable();
                da.Fill(dtBuku);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dgBuku.DataSource = dtBuku;
            dgBuku.Columns[0].HeaderText = "Kode Buku";
            dgBuku.Columns[1].HeaderText = "Judul Buku";
            dgBuku.Columns[2].HeaderText = "Harga";
            dgBuku.Columns[3].HeaderText = "Qty";
            dgBuku.Columns[4].HeaderText = "Subtotal";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCariPO frm = new FormCariPO();
            frm.ShowDialog();
        }

        private void FormProsesPreOrder_Load(object sender, EventArgs e)
        {

        }

        private void nudPoint_ValueChanged(object sender, EventArgs e)
        {
            if (nudPoint.Value > 0)
            {
                if(nudPoint.Value > Convert.ToInt32(lbPoinTersedia.Text))
                {
                    MessageBox.Show("Poin tidak cukup!");
                }
                else
                {
                    diskon = Convert.ToInt32(nudPoint.Value);

                    if(diskon > subtotal - uangmuka)
                    {
                        MessageBox.Show("Diskon melebihi total!");
                    }
                    else
                    {
                        lbDisc.Text = diskon.ToString("N0", new System.Globalization.CultureInfo("id-ID"));
                    }
                }
            }
            
        }

        private void nudPoint_KeyUp(object sender, KeyEventArgs e)
        {
            if (nudPoint.Value > 0)
            {
                if (nudPoint.Value > Convert.ToInt32(lbPoinTersedia.Text))
                {
                    MessageBox.Show("Poin tidak cukup!");
                }
                else
                {
                    diskon = Convert.ToInt32(nudPoint.Value);

                    if (diskon > subtotal - uangmuka)
                    {
                        MessageBox.Show("Diskon melebihi total!");
                    }
                    else
                    {
                        lbDisc.Text = diskon.ToString("N0", new System.Globalization.CultureInfo("id-ID"));

                        grandtotal = subtotal - uangmuka - diskon;
                        lbGrandTotal.Text = grandtotal.ToString("N0", new System.Globalization.CultureInfo("id-ID"));
                    }
                }
            }
        }

        private void btnPakaiSemua_Click(object sender, EventArgs e)
        {
            int pointAvail = Convert.ToInt32(lbPoinTersedia.Text);
            if(pointAvail <= (subtotal - uangmuka))
            {
                diskon = pointAvail;
            }
            else
            {
                diskon = (subtotal - uangmuka);
            }

            nudPoint.Value = diskon;
            lbDisc.Text = diskon.ToString("N0", new System.Globalization.CultureInfo("id-ID"));

            grandtotal = subtotal - uangmuka - diskon;
            lbGrandTotal.Text = grandtotal.ToString("N0", new System.Globalization.CultureInfo("id-ID"));
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            FormDetailPreOrder frm = new FormDetailPreOrder(poId);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (cmbPembayaran.SelectedIndex < 0)
            {
                MessageBox.Show("Metode pembayaran belum dipilih!");
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

                    //generate id htrans
                    cmd = new MySqlCommand("select generateIdHtrans()", Koneksi.getConn());
                    string htransId = cmd.ExecuteScalar().ToString();
                    string invoice = tbNotaTrans.Text;

                    //generate id dtrans
                    cmd = new MySqlCommand("select generateIdDtrans()", Koneksi.getConn());
                    string dtransId = cmd.ExecuteScalar().ToString();

                    //get member
                    string memberId = null;
                    if (rbGuest.Checked)
                    {
                        memberId = null;
                    }
                    else if (rbMember.Checked)
                    {
                        memberId = tbKodeMember.Text;
                    }

                    //qty + pembayaran
                    int qty = Convert.ToInt32(lbTotalQty.Text);
                    string pembayaran = cmbPembayaran.Items[cmbPembayaran.SelectedIndex].ToString();

                    //point
                    int pointAvail = Convert.ToInt32(lbPoinTersedia.Text);
                    int pointUsed = diskon;
                    int pointGet = 0;
                    if (grandtotal > 0)
                    {
                        pointGet = Convert.ToInt32(grandtotal * 0.05);
                    }

                    //insert htrans
                    cmd = new MySqlCommand("insert into htrans_purchase values(@hp_id, @invoice, CURRENT_DATE, @qty, @total, @totalpaid, @pointUsed, @pointGet, @method, @e_id, @m_id, 1)", Koneksi.getConn());
                    cmd.Parameters.AddWithValue("@hp_id", htransId);
                    cmd.Parameters.AddWithValue("@invoice", invoice);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@total", subtotal);
                    cmd.Parameters.AddWithValue("@totalpaid", grandtotal);
                    cmd.Parameters.AddWithValue("@pointUsed", diskon);
                    cmd.Parameters.AddWithValue("@pointGet", pointGet);
                    cmd.Parameters.AddWithValue("@method", pembayaran);
                    cmd.Parameters.AddWithValue("@e_id", emId);
                    cmd.Parameters.AddWithValue("@m_id", memberId);
                    cmd.ExecuteNonQuery();

                    //insert dtrans
                    cmd = new MySqlCommand("insert into dtrans_purchase values(@dp_id, @hp_id, @b_id, @qty, @total, 1)", Koneksi.getConn());
                    cmd.Parameters.AddWithValue("@dp_id", dtransId);
                    cmd.Parameters.AddWithValue("@hp_id", htransId);
                    cmd.Parameters.AddWithValue("@b_id", bookId);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@total", subtotal);
                    cmd.ExecuteNonQuery();

                    //update status PO
                    cmd = new MySqlCommand("update pre_order set PO_STATUS=3 where PO_ID=@po_id", Koneksi.getConn());
                    cmd.Parameters.AddWithValue("@po_id", poId);
                    cmd.ExecuteNonQuery();

                    //update poin member
                    int pointNew = pointAvail + (pointGet - pointUsed);
                    cmd = new MySqlCommand("update member set M_POINT=@point where M_ID=@m_id", Koneksi.getConn());
                    cmd.Parameters.AddWithValue("@point", pointNew);
                    cmd.Parameters.AddWithValue("@m_id", memberId);
                    cmd.ExecuteNonQuery();

                    //commit
                    trans.Commit();
                    MessageBox.Show("Transaksi Berhasil!");

                    //kembali ke detail

                    FormDetailPreOrder frm = new FormDetailPreOrder(poId);
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
    }
}
