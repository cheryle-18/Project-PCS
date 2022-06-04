using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore
{
    public partial class FormDetailPegawaiAdmin : Form
    {
        private string e_id = "";
        DataTable dtDataPegawai;
        public FormDetailPegawaiAdmin(string e_id)
        {
            InitializeComponent();
            this.e_id = e_id;
            loadDatabase(e_id);
            refreshData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MasterPegawaiAdmin frm = new MasterPegawaiAdmin();
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MasterPegawaiAdmin frm = new MasterPegawaiAdmin();
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        void loadDatabase(string name)
        {
            string query = $"SELECT E_ID, E_NAME, DATE_FORMAT(e_birthdate,'%d/%m/%Y'), E_ADDRESS, E_TELP, E_U_ID, CONVERT(e_status, CHAR) FROM employee where e_id = '{e_id}'";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());

                dtDataPegawai= new DataTable();
                da.Fill(dtDataPegawai);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void refreshData()
        {
            DataRow datamember = dtDataPegawai.Rows[0];
            //E_ID, E_NAME, DATE_FORMAT(e_birthdate,'%e-%c-%Y'), E_ADDRESS, E_TELP, E_U_ID, CONVERT(e_status, CHAR)
            //  0     1                     2                       3          4      5                6                         
            tbKode.Text = datamember[0].ToString();
            tbNama.Text = datamember[1].ToString();
            tbAlamat.Text = datamember[3].ToString();
            DateTime tanggalLahir;
            string tanggal = datamember[2].ToString();
            tanggalLahir = DateTime.ParseExact(tanggal, "dd/MM/yyyy",CultureInfo.CurrentCulture);
            dtpTanggalLahir.Value = tanggalLahir;
            tbTelepon.Text = datamember[4].ToString();
            tbUserId.Text = datamember[5].ToString();
            rbStatusNonAktif.Checked = true;
            if (datamember[6].ToString() == "1")
            {
                rbStatusAktif.Checked = true;
            }
        }

        private void btnSimpanPerubahan_Click(object sender, EventArgs e)
        {
            if (tbKode.Text == "" || tbNama.Text == "" || tbAlamat.Text == "" || tbUserId.Text == "" || tbTelepon.Text == "" || (!rbStatusAktif.Checked && !rbStatusNonAktif.Checked))
            {
                MessageBox.Show("Semua Field Harus Terisi!");
            }
            else
            {
                string query = $"UPDATE employee SET E_NAME = @E_NAME, E_BIRTHDATE = @E_BIRTHDATE, E_ADDRESS = @E_ADDRESS, E_TELP = @E_TELP, E_STATUS = @E_STATUS WHERE E_ID = @E_ID;";
                MySqlCommand cmd = new MySqlCommand(query, Koneksi.getConn());
                cmd.Parameters.AddWithValue("@E_NAME", tbNama.Text);
                cmd.Parameters.AddWithValue("@E_BIRTHDATE", dtpTanggalLahir.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@E_ADDRESS", tbAlamat.Text);
                cmd.Parameters.AddWithValue("@E_TELP", tbTelepon.Text);
                cmd.Parameters.AddWithValue("@E_STATUS", Convert.ToInt32(rbStatusAktif.Checked));
                cmd.Parameters.AddWithValue("@E_ID", tbKode.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Simpan Perubahan Berhasil!");
            }
        }
    }
}
