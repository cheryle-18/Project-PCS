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

        public void loadMember()
        {
            
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

                    lbDisc.Text = diskon.ToString("N0", new System.Globalization.CultureInfo("id-ID"));
                }
            }
            
        }

        private void nudPoint_KeyPress(object sender, KeyPressEventArgs e)
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

                    lbDisc.Text = diskon.ToString("N0", new System.Globalization.CultureInfo("id-ID"));
                }
            }
        }
    }
}
