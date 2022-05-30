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
        string previous_book_code;
        bool isEditMode;
        public FormTransaksiBaru()
        {
            InitializeComponent();
            fillHeaderInfo();
            clearFields();
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {

            if (cmbPembayaran.SelectedIndex == -1)
            {
                //THROW ERROR
                MessageBox.Show("Belum ada metode pembayaran yang terpilih!");
            }
            else
            {
                //GET EMPLOYEE
                MySqlCommand cmd = new MySqlCommand("SELECT employee.`E_ID` FROM employee WHERE employee.`E_U_ID` = @us_id;", Koneksi.getConn());
                cmd.Parameters.AddWithValue("@us_id", FormLogin.us_id);
                string emp_id = (String)cmd.ExecuteScalar();

                //PAY!

                MySqlConnection conn = Koneksi.getConn();

                using (MySqlTransaction obTrans = conn.BeginTransaction())
                {

                    try
                    {
                        string payment_method = cmbPembayaran.Text;


                        cmd = new MySqlCommand("SELECT generateIdHtrans()", Koneksi.getConn());
                        string id_htrans = cmd.ExecuteScalar().ToString();

                        cmd = new MySqlCommand();
                        cmd.Connection = conn;

                        //CHECK MEMBER OR GUEST
                        int total_htrans;
                        int point_used;
                        int point_received;
                        string member_id = null;
                        if (rbGuest.Checked)
                        {
                            //GUEST
                            total_htrans = Convert.ToInt32(lbGrandTotal.Text.Replace(".", String.Empty));
                            point_used = 0;
                            point_received = 0;
                        }
                        else
                        {

                            point_used = Convert.ToInt32(nudPoint.Value);
                            total_htrans = Convert.ToInt32(lbGrandTotal.Text.Replace(".", String.Empty)) - point_used;
                            point_received = Convert.ToInt32(Math.Round(0.1 * total_htrans));
                            member_id = tbKodeMember.Text;
                        }

                        //TRANSACTION HEADER, ADD SOME PARAMETERS
                        cmd.CommandText = "INSERT INTO htrans_purchase(HP_ID,HP_INVOICE_NUMBER,HP_DATE,HP_TOTAL_QTY,HP_TOTAL,HP_TOTAL_PAID,HP_POINTS_USED,HP_POINTS_RECEIVED,HP_PAYMENT_METHOD,HP_E_ID,HP_M_ID,HP_STATUS) VALUES (@HP_ID,@HP_INVOICE_NUMBER,NOW(),@HP_TOTAL_QTY,@HP_TOTAL,@HP_TOTAL_PAID,@HP_POINTS_USED,@HP_POINTS_RECEIVED,@HP_PAYMENT_METHOD,@HP_E_ID,@HP_M_ID,1);";
                        cmd.Parameters.AddWithValue("@HP_ID", id_htrans);
                        cmd.Parameters.AddWithValue("@HP_INVOICE_NUMBER", txtNota.Text);
                        cmd.Parameters.AddWithValue("@HP_TOTAL_QTY", Convert.ToInt32(lbTotalQty.Text));
                        cmd.Parameters.AddWithValue("@HP_TOTAL", total_htrans);
                        cmd.Parameters.AddWithValue("@HP_TOTAL_PAID", total_htrans);
                        cmd.Parameters.AddWithValue("@HP_POINTS_USED", point_used);
                        cmd.Parameters.AddWithValue("@HP_POINTS_RECEIVED", point_received);
                        cmd.Parameters.AddWithValue("@HP_PAYMENT_METHOD", payment_method);
                        cmd.Parameters.AddWithValue("@HP_E_ID", emp_id);
                        cmd.Parameters.AddWithValue("HP_M_ID", member_id);

                        //NO RETURNING VALUES
                        cmd.ExecuteNonQuery();

                        //TRANSACTION DETAILS

                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO dtrans_purchase(DP_ID,DP_HP_ID,DP_B_ID,DP_QTY,DP_SUBTOTAL,DP_STATUS) VALUES (@DP_ID,@DP_HP_ID,@DP_B_ID,@DP_QTY,@DP_SUBTOTAL,1);";
                        cmd.Parameters.AddWithValue("@DP_ID", "");
                        cmd.Parameters.AddWithValue("@DP_HP_ID", id_htrans);
                        cmd.Parameters.AddWithValue("@DP_B_ID", "");
                        cmd.Parameters.AddWithValue("@DP_QTY", 0);
                        cmd.Parameters.AddWithValue("@DP_SUBTOTAL", 0);

                        MySqlCommand cmd_dtrans = new MySqlCommand();
                        cmd_dtrans.Connection = conn;

                        for (int i = 0; i < dgvCart.RowCount; i++)
                        {
                            cmd_dtrans.CommandText = "SELECT generateIdDtrans()";
                            string dtrans_id = (String)cmd_dtrans.ExecuteScalar();

                            cmd.Parameters["@DP_ID"].Value = dtrans_id;
                            cmd.Parameters["@DP_B_ID"].Value = dgvCart.Rows[i].Cells[1].Value.ToString();
                            cmd.Parameters["@DP_QTY"].Value = Convert.ToInt32(dgvCart.Rows[i].Cells[4].Value);
                            cmd.Parameters["@DP_SUBTOTAL"].Value = Convert.ToInt32(dgvCart.Rows[i].Cells[5].Value.ToString().Substring(3).Replace(".", String.Empty));
                            cmd.ExecuteNonQuery();

                        }

                        //UPDATE MEMBER
                        cmd.Parameters.Clear();
                        cmd.CommandText = "UPDATE member SET member.M_POINT = member.`M_POINT` - @point_used + @point_received WHERE member.`M_ID` = @member_id;";
                        cmd.Parameters.AddWithValue("@point_used", point_used);
                        cmd.Parameters.AddWithValue("@point_received", point_received);
                        cmd.Parameters.AddWithValue("@member_id", member_id);
                        cmd.ExecuteNonQuery();
                        //--------------------------------------


                        obTrans.Commit();
                        MessageBox.Show("Transaksi sukses!");
                        dgvCart.Rows.Clear();
                        clearFields();
                        updateTotal();

                        fillHeaderInfo();

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                        obTrans.Rollback();
                    }
                }

            }
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
                    this.nudPoint.Maximum = Convert.ToInt32(rd["M_POINT"].ToString());
                }
                rd.Close();
                btnUseAll.Enabled = true;
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
                btnUseAll.Enabled = false;
                this.lbPoinTersedia.Text = "0";
                nudPoint.Value = 0;
                this.tbKodeMember.Text = "-";
                this.txtNamaMember.Text = "-";
            }
        }

        private void FormTransaksiBaru_Load(object sender, EventArgs e)
        {
           
        }

        private void fillHeaderInfo()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT generateInvoiceTrans()", Koneksi.getConn());
            
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
            selected_dgv_idx = -1;
            previous_book_code = "";
            btnTambah.Text = "Tambah";
            btnCancelEdit.Visible = false;
            dgvCart.ClearSelection();
            btnUseAll.Enabled = false;
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
            for (int i = 0; i < dgvCart.RowCount; i++)
            {
                sumQty += Convert.ToInt32(dgvCart.Rows[i].Cells[4].Value.ToString());
                total += Convert.ToInt32(dgvCart.Rows[i].Cells[5].Value.ToString().Substring(3).Replace(".", String.Empty));
            }
            lbSubtotal.Text = (total).ToString("N0", new System.Globalization.CultureInfo("id-ID"));
            lbTotalQty.Text = sumQty + "";
            lbDisc.Text = nudPoint.Value.ToString();
            lbGrandTotal.Text = (total - Convert.ToInt32(nudPoint.Value)).ToString("N0", new System.Globalization.CultureInfo("id-ID"));

            if (sumQty == 0)
            {
                //DISABLE PAY BUTTON
                btnBayar.Enabled = false;
            }
            else
            {
                btnBayar.Enabled = true;
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            bool isAllowed = true;
            //ADD TO CHART
            //CHECK PASSED
            if (txtKodeBuku.Text != "-")
            {

                if (nudQTY.Value > 0)
                {

                    string book_code = txtKodeBuku.Text;
                    string book_title = txtJudulBuku.Text;
                    int bookPrice = Convert.ToInt32(txtHargaBuku.Text.Replace(".", String.Empty));
                    int qty = Convert.ToInt32(nudQTY.Value);
                    int subtotal = bookPrice * qty;

                    MySqlCommand cmd = new MySqlCommand("SELECT book.`B_STOCK` FROM book WHERE book.`B_ID` = @book_id;", Koneksi.getConn());
                    cmd.Parameters.AddWithValue("@book_id", book_code);
                    int stock = Convert.ToInt32(cmd.ExecuteScalar());

                    bool isExist = false;
                    for (int i = 0; i < dgvCart.RowCount; i++)
                    {
                        if (dgvCart.Rows[i].Cells[1].Value.ToString() == book_code && book_code != previous_book_code)
                        {
                            isExist = true;
                            int newSum = Convert.ToInt32(dgvCart.Rows[i].Cells[4].Value.ToString()) + qty;

                            if ((stock - newSum) < 0)
                            {
                                isAllowed = false;
                            }
                        }
                    }
                    if (!isExist)
                    {
                        //CHECK IF IT'S ALLOWED
                        if ((stock - qty) < 0)
                        {
                            isAllowed = false;
                        }

                    }
                    if (isAllowed)
                    {
                        if (isEditMode)
                        {
                            //DELETE AT EDIT IDX
                            deleteDGVRow(edit_dgv_idx);
                        }

                        isExist = false;
                        for (int i = 0; i < dgvCart.RowCount; i++)
                        {
                            if (dgvCart.Rows[i].Cells[1].Value.ToString() == book_code)
                            {
                                isExist = true;
                                int newSum = Convert.ToInt32(dgvCart.Rows[i].Cells[4].Value.ToString()) + qty;

                                //ALLOWED
                                dgvCart.Rows[i].Cells[4].Value = newSum;
                                //SUBTOTAL
                                dgvCart.Rows[i].Cells[5].Value = "Rp " + (newSum * bookPrice).ToString("N0", new System.Globalization.CultureInfo("id-ID"));

                            }
                        }
                        if (!isExist)
                        {
                            if (isEditMode)
                            {
                                dgvCart.Rows.Insert(edit_dgv_idx, "", book_code, book_title, "Rp " + txtHargaBuku.Text, qty, "Rp " + subtotal.ToString("N0", new System.Globalization.CultureInfo("id-ID")));
                            }
                            else
                            {
                                dgvCart.Rows.Add("", book_code, book_title, "Rp " + txtHargaBuku.Text, qty, "Rp " + subtotal.ToString("N0", new System.Globalization.CultureInfo("id-ID")));
                            }
                            dgvCart.ClearSelection();
                            updateAutoIcrCart();


                        }
                        clearFields();
                        updateTotal();
                    }
                    else
                    {
                        MessageBox.Show("Quantity telah melebihi stok, Silakan update quantity terlebih dahulu!");
                    }

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
            if (selected_dgv_idx != -1)
            {
                //MOVE TO TEXTBOX
                edit_dgv_idx = selected_dgv_idx;
                isEditMode = true;
                txtKodeBuku.Text = dgvCart.Rows[selected_dgv_idx].Cells[1].Value.ToString();
                txtJudulBuku.Text = dgvCart.Rows[selected_dgv_idx].Cells[2].Value.ToString();
                txtHargaBuku.Text = dgvCart.Rows[selected_dgv_idx].Cells[3].Value.ToString().Substring(3);
                nudQTY.Value = Convert.ToInt32(dgvCart.Rows[selected_dgv_idx].Cells[4].Value);
                btnTambah.Text = "Submit";
                previous_book_code = txtKodeBuku.Text;
                btnCancelEdit.Visible = true;
            }
            else
            {
                MessageBox.Show("Belum ada buku yang terpilih!");
            }


        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnUseAll_Click(object sender, EventArgs e)
        {
            this.nudPoint.Value = Convert.ToInt32(lbPoinTersedia.Text);
        }
    }
}
