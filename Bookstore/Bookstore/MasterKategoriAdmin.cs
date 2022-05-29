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
    public partial class MasterKategoriAdmin : Form
    {
        DataTable dtCategory;
        public MasterKategoriAdmin()
        {
            InitializeComponent();
            loadDatabaseName(tbCari.Text);
            refreshDgv();
        }

        private void MasterKategoriAdmin_Load(object sender, EventArgs e)
        {

        }

        //void loadDatabase()
        //{
        //    string query = $"SELECT C_ID,C_NAME,CONVERT(C_STATUS, CHAR) FROM category";
        //    //query = $"SELECT C_ID,C_NAME,C_STATUS FROM category";
        //    try
        //    {
        //        MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());

        //        dtCategory = new DataTable();
        //        da.Fill(dtCategory);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        void loadDatabaseName(string name)
        {
            string arah = "asc";
            if (cmbArah.SelectedIndex == 1)
            {
                arah = "desc";
            }
            string sort = "";
            if (cmbSort.SelectedIndex == 0)
            {
                sort = "order by C_ID " + arah;
            }
            else if (cmbSort.SelectedIndex == 1)
            {
                sort = "order by C_NAME " + arah;
            }
            else if (cmbSort.SelectedIndex == 2)
            {
                sort = "order by C_STATUS " + arah;
            }
            string query = $"SELECT C_ID,C_NAME,CONVERT(C_STATUS, CHAR) FROM category where C_NAME like '%{name}%' {sort}";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());

                dtCategory = new DataTable();
                da.Fill(dtCategory);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void refreshDgv()
        {
            dgCategory.DataSource = null;
            dgCategory.DataSource = dtCategory;
            dgCategory.Columns[0].HeaderText = "ID";
            dgCategory.Columns[1].HeaderText = "Nama";
            dgCategory.Columns[2].HeaderText = "Status";
        }

        private void dgCategory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex==2)
            {
                //MessageBox.Show(e.Value.ToString());
                if (e.Value.ToString() == "1")
                {
                    e.Value = "Aktif";
                }
                else
                {
                    e.Value = "Non-Aktif";
                }
            }
        }

        void generateID()
        {
            string query = $"SELECT generateIdCategory()";
            MySqlCommand cmd = new MySqlCommand(query, Koneksi.getConn());
            string id = cmd.ExecuteScalar().ToString();
            tbID.Text = id;
        }

        private void tbNama_TextChanged(object sender, EventArgs e)
        {
            generateID();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (tbNama.Text==""||(!rbStatusAktif.Checked&&!rbStatusNonAktif.Checked))
            {
                MessageBox.Show("Harap Isi Semua Field!");
            }
            else
            {
                string query = $"insert into category values ('{tbID.Text}','{tbNama.Text}','{Convert.ToInt32(rbStatusAktif.Checked)}')";
                MySqlCommand cmd = new MySqlCommand(query, Koneksi.getConn());
                cmd.ExecuteNonQuery();
                loadDatabaseName(tbCari.Text);
                refreshDgv();
                generateID();
            }
        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            loadDatabaseName(tbCari.Text);
            refreshDgv();
        }
    }
}
