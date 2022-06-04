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
    public partial class MasterPegawaiAdmin : Form
    {
        private string e_id = "";
        DataTable dtPegawai;
        public MasterPegawaiAdmin()
        {
            InitializeComponent();
            cmbSort.Items.Clear();
            cmbSort.Items.Add("Kode Pegawai");
            cmbSort.Items.Add("Nama");
            cmbSort.Items.Add("Tanggal Lahir");
            cmbSort.Items.Add("Alamat");
            cmbSort.Items.Add("Telepon");
            cmbSort.Items.Add("ID User");
            cmbSort.Items.Add("Status");
            cmbSort.SelectedIndex = 0;
            cmbArah.SelectedIndex = 0;

            loadDatabase(tbCari.Text);
            refreshDgv();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (e_id == "")
            {
                try
                {
                    e_id = dgPegawai.Rows[0].Cells[0].Value.ToString();
                }
                catch (Exception)
                {

                }
            }
            if (e_id != "")
            {
                FormDetailPegawaiAdmin frm = new FormDetailPegawaiAdmin(e_id);
                Panel temp = (Panel)frm.Controls[0];
                temp.Width = panel2.Width;
                temp.Height = panel2.Height;
                this.panel2.Controls.Clear();
                this.panel2.Controls.Add(temp);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            FormPegawaiBaru frm = new FormPegawaiBaru();
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        void loadDatabase(string name)
        {
            string[] arahs = { "asc", "desc" };
            string[] sorts = { "E_ID", "E_NAME", "E_BIRTHDATE", "E_ADDRESS", "E_TELP", "E_U_ID", "E_STATUS" };
            string arah = arahs[cmbArah.SelectedIndex];
            string sort = $"order by {sorts[cmbSort.SelectedIndex]} {arah}";
            string query = $"SELECT E_ID, E_NAME, DATE_FORMAT(e_birthdate,'%d/%m/%Y'), E_ADDRESS, E_TELP, E_U_ID, CONVERT(e_status, CHAR) FROM employee where E_NAME like '%{name}%' {sort}";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());

                dtPegawai = new DataTable();
                da.Fill(dtPegawai);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void refreshDgv()
        {
            dgPegawai.DataSource = dtPegawai;
            dgPegawai.Columns[0].HeaderText = "Kode Pegawai";
            dgPegawai.Columns[1].HeaderText = "Nama";
            dgPegawai.Columns[2].HeaderText = "Tanggal Lahir";
            dgPegawai.Columns[3].HeaderText = "Alamat";
            dgPegawai.Columns[4].HeaderText = "Telepon";
            dgPegawai.Columns[5].HeaderText = "ID User";
            dgPegawai.Columns[6].HeaderText = "Status";
            for (int i = 0; i < dgPegawai.Columns.Count; i++)
            {
                dgPegawai.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void dgPegawai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                e_id = dgPegawai.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch (Exception)
            {

                e_id = "";
            }
        }

        private void dgPegawai_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6)
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

        private void MasterPegawaiAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
