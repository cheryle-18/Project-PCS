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
    public partial class FormDetailPreOrder : Form
    {
        string poId;
        string bookId;
        string custType;
        string memberId;
        int userRole;
        string invoice;

        DataTable dtBuku;

        public FormDetailPreOrder(string poId, int role)
        {
            InitializeComponent();

            this.poId = poId;
            this.userRole = role;
            if (userRole == 1)
            {
                btnProses.Visible = false;
            }

            bookId = "";
            custType = "";
            memberId = "";

            MySqlCommand cmd = new MySqlCommand("select (case when PO_STATUS is not null then PO_STATUS end) as status from pre_order where PO_ID=@po_id", Koneksi.getConn());
            cmd.Parameters.AddWithValue("@po_id", poId);
            int status = Convert.ToInt32(cmd.ExecuteScalar());
            if (status == 2)
            {
                btnProses.Visible = true;
            }
            else
            {
                btnProses.Visible = false;
            }

            loadDetails();
            loadDgv();
        }

        public void loadDetails()
        {
            lbKodePO.Text = poId;

            //Detail PO
            MySqlCommand cmd = new MySqlCommand("select PO_INVOICE_NUMBER, PO_B_ID, concat('Rp ', format(PO_TOTAL,0,'de_DE')), concat('Rp ', format(PO_DOWN_PAYMENT,0,'de_DE')), PO_QTY, (case when PO_STATUS=1 then 'Menunggu Buku' when PO_STATUS=2 then 'Siap Diproses' else 'Selesai' end) as status, date_format(PO_DATE, '%d/%m/%Y'), (case when PO_M_ID is null then 'Non-Member' else PO_M_ID end) as jenis, E_NAME from pre_order join book on B_ID=PO_B_ID left join member on M_ID=PO_M_ID join employee on E_ID=PO_E_ID where PO_ID=@po_id", Koneksi.getConn());
            cmd.Parameters.AddWithValue("@po_id", poId);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                invoice = reader.GetString(0);
                lbNota.Text = reader.GetString(0);

                bookId = reader.GetString(1);
                lbKodeBuku.Text = bookId;

                lbTotal.Text = reader.GetString(2);
                lbDP.Text = reader.GetString(3);
                lbQty.Text = reader.GetString(4);
                lbStatus.Text = reader.GetString(5);
                lbTanggal.Text = reader.GetString(6);

                memberId = reader.GetString(7);
                if (memberId == "Non-Member")
                {
                    custType = "Non-Member";
                }
                else
                {
                    custType = "Member";
                }
                lbJenis.Text = custType;

                lbNamaPeg.Text = reader.GetString(8);
            }
            reader.Close();

            //Detail Customer
            if (custType == "Non-Member")
            {
                lbNama.Text = "-";
                lbTelp.Text = "-";
            }
            else if (custType == "Member")
            {
                cmd = new MySqlCommand("select M_NAME, M_TELP from member where M_ID=@m_id", Koneksi.getConn());
                cmd.Parameters.AddWithValue("@m_id", memberId);
                MySqlDataReader reader2 = cmd.ExecuteReader();
                while (reader2.Read())
                {
                    lbNama.Text = reader2.GetString(0);
                    lbTelp.Text = reader2.GetString(1);
                }
                reader2.Close();
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

        private void btnProses_Click(object sender, EventArgs e)
        {
            FormProsesPreOrder frm = new FormProsesPreOrder(poId);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MasterPreOrder frm = new MasterPreOrder(0);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void FormDetailPreOrder_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLihatNota_Click(object sender, EventArgs e)
        {
            FormLihatNotaPO frm = new FormLihatNotaPO(poId, userRole, invoice, lbNama.Text);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }
    }
}
