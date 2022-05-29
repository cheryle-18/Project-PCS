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
        int selected_dgv_idx;
        int edit_dgv_idx;
        bool isEditMode;
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

            FormCariBuku frm = new FormCariBuku("transaksi");
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
            isEditMode = false;
            edit_dgv_idx = -1;
            btnTambah.Text = "Tambah";
        }

        private void updateAutoIcrCart()
        {
            for (int i = 0; i < dgvCart.RowCount; i++)
            {
                dgvCart.Rows[i].Cells[0].Value = (i + 1);
            }
        }

        private void updateTotal()
        {
            //UPDATE TOTAL
            int total = 0;
            int sumQty = 0;
            for(int i = 0; i < dgvCart.RowCount; i++)
            {
                sumQty += Convert.ToInt32(dgvCart.Rows[i].Cells[4].Value.ToString());
                total += Convert.ToInt32(dgvCart.Rows[i].Cells[5].Value.ToString().Substring(3).Replace(".", String.Empty));
            }
            lbSubtotal.Text = (total).ToString("N0", new System.Globalization.CultureInfo("id-ID"));
            lbTotalQty.Text = sumQty + "";
            lbDisc.Text = nudPoint.Value.ToString();
            lbGrandTotal.Text = (total - Convert.ToInt32(nudPoint.Value)).ToString("N0", new System.Globalization.CultureInfo("id-ID"));
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            //ADD TO CHART
            //CHECK PASSED
            if(txtKodeBuku.Text != "-")
            {

                if(nudQTY.Value > 0)
                {

                    if (isEditMode)
                    {
                        //DELETE AT EDIT IDX
                        deleteDGVRow(edit_dgv_idx);
                    }

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
                    updateTotal();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            //CLEAR DGV
            dgvCart.Rows.Clear();
            updateTotal();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {

            deleteDGVRow(selected_dgv_idx);
            selected_dgv_idx = -1;
        }

        private void deleteDGVRow(int row)
        {
            if (row != -1)
            {
                dgvCart.Rows.RemoveAt(row);
                updateTotal();
                updateAutoIcrCart();
                dgvCart.ClearSelection();
            }
        }

        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selected_dgv_idx = dgvCart.CurrentCell.RowIndex;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(selected_dgv_idx != -1)
            {
                //MOVE TO TEXTBOX
                edit_dgv_idx = selected_dgv_idx;
                isEditMode = true;
                txtKodeBuku.Text = dgvCart.Rows[selected_dgv_idx].Cells[1].Value.ToString();
                txtJudulBuku.Text = dgvCart.Rows[selected_dgv_idx].Cells[2].Value.ToString();
                txtHargaBuku.Text = dgvCart.Rows[selected_dgv_idx].Cells[3].Value.ToString().Substring(3);
                nudQTY.Value = Convert.ToInt32(dgvCart.Rows[selected_dgv_idx].Cells[4].Value);
                btnTambah.Text = "Submit";
            }
            else
            {
                
            }
           
           
        }
    }
}
