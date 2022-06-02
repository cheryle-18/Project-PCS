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
    public partial class MasterMember : Form
    {
        DataTable dtMember;
        private int user_role;
        public MasterMember(int role)
        {
            InitializeComponent();
            this.user_role = role;
            if(this.user_role == 1)
            {
                this.btnMemberBaru.Visible = false;
            }
            cmbArah.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            loadDatabase(tbCari.Text);
            refreshDgv();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            //FormDetailMember frm = new FormDetailMember(user_role);
            //Panel temp = (Panel)frm.Controls[0];
            //temp.Width = panel2.Width;
            //temp.Height = panel2.Height;
            //this.panel2.Controls.Clear();
            //this.panel2.Controls.Add(temp);
        }

        private void btnMemberBaru_Click(object sender, EventArgs e)
        {
            FormMemberBaru frm = new FormMemberBaru();
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void MasterMember_Load(object sender, EventArgs e)
        {

        }



        void loadDatabase(string name)
        {
            string[] arahs = { "asc", "desc" };
            string[] sorts = { "m_id", "m_name", "m_birthdate", "m_address", "m_telp", "m_point", "m_status"};
            string arah = arahs[cmbArah.SelectedIndex];
            string sort = $"order by {sorts[cmbSort.SelectedIndex]} {arah}";
            string query = $"SELECT m_id,m_name,m_birthdate,m_address,m_telp,m_point,CONVERT(m_status, CHAR) FROM MEMBER where M_NAME like '%{name}%' {sort}";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());

                dtMember = new DataTable();
                da.Fill(dtMember);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void refreshDgv()
        {
            //dgMember.DataSource = null;
            dgMember.DataSource = dtMember;
            dgMember.Columns[0].HeaderText = "ID";
            dgMember.Columns[1].HeaderText = "Nama";
            dgMember.Columns[2].HeaderText = "Tanggal Lahir";
            dgMember.Columns[3].HeaderText = "Alamat";
            dgMember.Columns[4].HeaderText = "No Telepon";
            dgMember.Columns[5].HeaderText = "Point";
            dgMember.Columns[6].HeaderText = "Status";
        }

        private void dgMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string m_id = dgMember.Rows[e.RowIndex].Cells[0].Value.ToString();
            //MessageBox.Show(m_id);
        }

        private void dgMember_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex==6)
            {
                if (Convert.ToInt32(e.Value) == 1)
                {
                    e.Value = "Aktif";
                }
                else
                {
                    e.Value = "Tidak Aktif";
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbArah.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            tbCari.Text = "";
        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            if (cmbSort.SelectedIndex != -1 && cmbArah.SelectedIndex != -1)
            {
                loadDatabase(tbCari.Text);
                refreshDgv();
            }
        }
    }
}
