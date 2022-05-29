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
                    this.txtHargaBuku.Text = rd["B_PRICE"].ToString();
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
    }
}
