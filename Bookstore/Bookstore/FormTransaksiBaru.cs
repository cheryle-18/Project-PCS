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
    public partial class FormTransaksiBaru : Form
    {
        public FormTransaksiBaru()
        {
            InitializeComponent();
            fillHeaderInfo();
            clearFields();
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            MasterTransaksi frm = new MasterTransaksi(0);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            MasterTransaksi frm = new MasterTransaksi(0);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void btnCariBuku_Click(object sender, EventArgs e)
        {

            FormCariBuku frm = new FormCariBuku();
            var result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.txtKodeBuku.Text = frm.book_id;
                MySqlCommand cmd = new MySqlCommand("SELECT book.`B_TITLE`,book.`B_PRICE` FROM book WHERE book.`B_ID` = @book_id", Koneksi.getConn());
                cmd.Parameters.AddWithValue("@book_id", frm.book_id);

                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    this.txtJudulBuku.Text = rd["B_TITLE"].ToString();
                    this.txtHargaBuku.Text = Convert.ToInt32(rd["B_PRICE"].ToString()).ToString("N0", new System.Globalization.CultureInfo("id-ID"));
                }
                rd.Close();
            }
        }

        private void btnCariMember_Click(object sender, EventArgs e)
        {

            FormCariMember frm = new FormCariMember();
            var result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.tbKodeMember.Text = frm.member_id;
                MySqlCommand cmd = new MySqlCommand("SELECT member.`M_NAME`,member.`M_POINT` FROM member WHERE member.`M_ID` = @member_id", Koneksi.getConn());
                cmd.Parameters.AddWithValue("@member_id", frm.member_id);

                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    this.txtNamaMember.Text = rd["M_NAME"].ToString();
                    this.lbPoinTersedia.Text = rd["M_POINT"].ToString();
                }
                rd.Close();
            }
        }

        private void rbMember_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMember.Checked)
            {
                nudPoint.Enabled = true;
                btnCariMember.Enabled = true;
            }
        }

        private void rbGuest_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGuest.Checked)
            {
                nudPoint.Enabled = false;
                btnCariMember.Enabled = false;
            }
        }

        private void FormTransaksiBaru_Load(object sender, EventArgs e)
        {
           
        }

        private void fillHeaderInfo()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT generateIDHtrans()", Koneksi.getConn());
            
            // GENERATE INVOICE NUMBER
            string id = cmd.ExecuteScalar().ToString();
            this.txtNota.Text = id;

        }

        private void clearFields()
        {
            txtKodeBuku.Text = "-";
            txtJudulBuku.Text = "-";
            txtHargaBuku.Text = "0";
            nudQTY.Value = 0;
            rbGuest.Checked = true;
            rbMember.Checked = false;
            tbKodeMember.Text = "-";
            txtNamaMember.Text = "-";
            lbPoinTersedia.Text = "0";
            nudPoint.Value = 0;
            nudPoint.Enabled = false;
            btnCariMember.Enabled = false;
            lbTanggal.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void updateAutoIcrCart()
        {
            for (int i = 0; i < dgvCart.RowCount; i++)
            {
                dgvCart.Rows[i].Cells[0].Value = (i + 1);
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            //ADD TO CHART
            //CHECK PASSED
            if(txtKodeBuku.Text != "-")
            {

                if(nudQTY.Value > 0)
                {
                    string book_code = txtKodeBuku.Text;
                    string book_title = txtJudulBuku.Text;
                    int bookPrice = Convert.ToInt32(txtHargaBuku.Text.Replace(".", String.Empty));
                    int qty = Convert.ToInt32(nudQTY.Value);
                    int subtotal = bookPrice * qty;

                    bool isExist = false;
                    for (int i = 0; i < dgvCart.RowCount; i++)
                    {
                        if (dgvCart.Rows[i].Cells[1].Value.ToString() == book_code)
                        {
                            isExist = true;
                            int newSum = Convert.ToInt32(dgvCart.Rows[i].Cells[4].Value.ToString()) + qty;
                            dgvCart.Rows[i].Cells[4].Value = newSum;
                            //SUBTOTAL
                            dgvCart.Rows[i].Cells[5].Value = "Rp " + (newSum * bookPrice).ToString("N0", new System.Globalization.CultureInfo("id-ID"));
                        }
                    }
                    if (!isExist)
                    {
                        dgvCart.Rows.Add("", book_code, book_title, "Rp " + txtHargaBuku.Text, qty, "Rp " + subtotal.ToString("N0", new System.Globalization.CultureInfo("id-ID")));
                        updateAutoIcrCart();
                    }

                    clearFields();
                }
                else
                {
                    MessageBox.Show("Quantity harus lebih dari 0!");
                }

            }
            else
            {
                MessageBox.Show("Silakan pilih buku terlebih dahulu!");
            }

        }
    }
}
