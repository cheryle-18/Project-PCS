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
    public partial class FormCariMember : Form
    {
        DataTable dtMember;
        public string member_id { get; set; }
        public FormCariMember()
        {
            InitializeComponent();
            loadDGV();
            refreshGridView();
        }

        private void btnPilih_Click(object sender, EventArgs e)
        {
            if (this.member_id != null && this.member_id != "")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Belum ada member yang terpilih!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void FormCariMember_Load(object sender, EventArgs e)
        {

        }

        private void loadDGV()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT member.M_ID,member.`M_NAME`,(CASE WHEN member.`M_STATUS` = 1 THEN 'Aktif' ELSE 'Non-Aktif'END) AS M_STATUS FROM member;", Koneksi.getConn());
                dtMember = new DataTable();
                adapter.Fill(dtMember);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void refreshGridView()
        {
            dgvMember.DataSource = dtMember;
            dgvMember.Columns["M_ID"].HeaderText = "ID Member";
            dgvMember.Columns["M_NAME"].HeaderText = "Nama Member";
            dgvMember.Columns["M_STATUS"].HeaderText = "Status Member";
            dgvMember.ClearSelection();
        }

        private void dgvMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                this.member_id = dgvMember.Rows[dgvMember.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT member.M_ID,member.`M_NAME`,(CASE WHEN member.`M_STATUS` = 1 THEN 'Aktif' ELSE 'Non-Aktif'END) AS M_STATUS FROM member WHERE member.`M_ID` LIKE '%" + tbCari.Text + "%' OR member.M_NAME LIKE '%" + tbCari.Text + "%';", Koneksi.getConn());
                dtMember = new DataTable();
                adapter.Fill(dtMember);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            refreshGridView();
        }
    }
}
