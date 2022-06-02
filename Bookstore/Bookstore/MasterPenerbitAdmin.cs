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
    public partial class MasterPenerbitAdmin : Form
    {
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private DataTable dt;
        private string command_querry = "SELECT P_ID AS 'Kode Penerbit',P_NAME AS 'Nama',P_ADDRESS AS 'Alamat',P_TELP AS 'Telp',P_STATUS AS 'Status' " +
                                   "FROM publisher WHERE P_STATUS = 1; ";
        public MasterPenerbitAdmin()
        {
            InitializeComponent();
            refreshDgv(command_querry);
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            int selected_row = dataGridView1.CurrentCell.RowIndex;
            string id_pilih = dataGridView1.Rows[selected_row].Cells[0].Value.ToString();
            FormDetailPenerbitAdmin frm = new FormDetailPenerbitAdmin(id_pilih);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
           
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            FormPenerbitBaru frm = new FormPenerbitBaru();
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MasterPenerbitAdmin_Load(object sender, EventArgs e)
        {

        }

        private void refreshDgv(string command)
        {
            try
            {
                da = new MySqlDataAdapter();
                cmd = new MySqlCommand(command, Koneksi.getConn());
                dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
                da.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private string search(string input)
        {
            string cmd = "";

            if (cmbSort.SelectedIndex > -1 && cmbArah.SelectedIndex > -1)
            {
                string order = "ASC";
                int kolom = 0;

                if (cmbArah.SelectedIndex == 0)
                {
                    order = "ASC";
                }
                else if (cmbArah.SelectedIndex == 1)
                {
                    order = "DESC";
                }
                if (cmbSort.SelectedIndex < 3)
                {
                    if (cmbSort.SelectedIndex == 0)
                    {
                        kolom = 1;
                    }
                    else if (cmbSort.SelectedIndex == 1)
                    {
                        kolom = 2;
                    }
                    else if (cmbSort.SelectedIndex == 2)
                    {
                        kolom = 5;
                    }

                    cmd = "SELECT P_ID AS 'Kode Penerbit',P_NAME AS 'Nama',P_ADDRESS AS 'Alamat',P_TELP AS 'Telp',P_STATUS AS 'Status' " +
                                   "FROM publisher " +
                                      $"WHERE P_STATUS = 1 AND P_NAME LIKE CONCAT('%','{input}','%') ORDER BY {kolom} {order}; ";
                }
            }
            else
            {
                cmd = "SELECT P_ID AS 'Kode Penerbit',P_NAME AS 'Nama',P_ADDRESS AS 'Alamat',P_TELP AS 'Telp',P_STATUS AS 'Status' " +
                                   "FROM publisher " +
                                      $"WHERE P_STATUS = 1 AND P_NAME LIKE CONCAT('%','{input}','%'); ";
            }
            return cmd;
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArah.SelectedIndex > -1 && cmbSort.SelectedIndex > -1)
            {
                string order = "ASC";
                int kolom = 0;
                string cmd = "";
                string keyword = "";
                if (tbCari.Text != "Kata Kunci")
                {
                    keyword = tbCari.Text;
                }

                if (cmbArah.SelectedIndex == 0)
                {
                    order = "ASC";
                }
                else if (cmbArah.SelectedIndex == 1)
                {
                    order = "DESC";
                }
                if (cmbSort.SelectedIndex < 3)
                {
                    if (cmbSort.SelectedIndex == 0)
                    {
                        kolom = 1;
                    }
                    else if (cmbSort.SelectedIndex == 1)
                    {
                        kolom = 2;
                    }
                    else if (cmbSort.SelectedIndex == 2)
                    {
                        kolom = 3;
                    }

                    cmd = "SELECT P_ID AS 'Kode Penerbit',P_NAME AS 'Nama',P_ADDRESS AS 'Alamat',P_TELP AS 'Telp',P_STATUS AS 'Status' " +
                                   "FROM publisher " +
                                      $"WHERE P_STATUS = 1 AND P_NAME LIKE CONCAT('%','{keyword}','%') ORDER BY {kolom} {order}; ";
                }

                refreshDgv(cmd);
            }

        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            if (tbCari.Text != "Kata Kunci")
            {
                string temp = search(tbCari.Text);
                refreshDgv(temp);
            }
        }

        private void cmbArah_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSort.SelectedIndex > -1 && cmbArah.SelectedIndex > -1)
            {
                string order = "ASC";
                int kolom = 0;
                string cmd = "";
                string keyword = "";
                if (tbCari.Text != "Kata Kunci")
                {
                    keyword = tbCari.Text;
                }
                if (cmbArah.SelectedIndex == 0)
                {
                    order = "ASC";
                }
                else if (cmbArah.SelectedIndex == 1)
                {
                    order = "DESC";
                }
                if (cmbSort.SelectedIndex < 3)
                {
                    if (cmbSort.SelectedIndex == 0)
                    {
                        kolom = 1;
                    }
                    else if (cmbSort.SelectedIndex == 1)
                    {
                        kolom = 2;
                    }
                    else if (cmbSort.SelectedIndex == 2)
                    {
                        kolom = 3;
                    }

                    cmd = "SELECT P_ID AS 'Kode Penerbit',P_NAME AS 'Nama',P_ADDRESS AS 'Alamat',P_TELP AS 'Telp',P_STATUS AS 'Status' " +
                                   "FROM publisher " +
                                      $"WHERE P_STATUS = 1 AND P_NAME LIKE CONCAT('%','{keyword}','%') ORDER BY {kolom} {order}; ";
                }
                refreshDgv(cmd);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbCari.Text = "Kata Kunci";
            cmbSort.SelectedIndex = -1;
            cmbArah.SelectedIndex = -1;
            refreshDgv(command_querry);
        }
    }
}
