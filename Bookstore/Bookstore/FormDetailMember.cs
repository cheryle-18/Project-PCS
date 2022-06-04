﻿using MySql.Data.MySqlClient;
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
    public partial class FormDetailMember : Form
    {
        private string m_id = "";
        private int user_role;
        DataTable dtDataMember;
        public FormDetailMember(int role,string m_id)
        {
            InitializeComponent();
            this.user_role = role;
            this.m_id = m_id;
            loadDatabase(m_id);
            refreshData();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            MasterMember frm;
            Panel temp;
            if(user_role == 0)
            {
                frm = new MasterMember(0);
            }
            else
            {
                frm = new MasterMember(1);
            }
      
            temp = (Panel)frm.Controls[0];
            temp.Width = panel2.Width;
            temp.Height = panel2.Height;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(temp);
        }
        void loadDatabase(string name)
        {
            string query = $"SELECT m_id,m_name,DATE_FORMAT(m_birthdate,'%e-%c-%Y'),m_address,m_telp,m_point,CONVERT(m_status, CHAR) FROM MEMBER where m_id = '{m_id}'";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());

                dtDataMember = new DataTable();
                da.Fill(dtDataMember);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void refreshData()
        {
            DataRow datamember = dtDataMember.Rows[0];
            //m_id,m_name,DATE_FORMAT(m_birthdate,'%e-%c-%Y'),m_address,m_telp,m_point,CONVERT(m_status, CHAR)
            //  0     1                     2                     3        4      5                6                         
            tbKode.Text = datamember[0].ToString();
            tbNama.Text = datamember[1].ToString();
            tbAlamat.Text = datamember[3].ToString();
            CultureInfo cultures = new CultureInfo("en-US");
            DateTime tanggalLahir = new DateTime();
            //MessageBox.Show(datamember[2].ToString());
            tanggalLahir = Convert.ToDateTime(datamember[2].ToString(), cultures);
            dtpTanggalLahir.Value = tanggalLahir;
            tbTelepon.Text = datamember[4].ToString();
            tbJumlahPoin.Text = datamember[5].ToString();
            rbStatusNonAktif.Checked = true;
            if (datamember[6].ToString()=="1")
            {
                rbStatusAktif.Checked = true;
            }
        }

        private void btnSimpanPerubahan_Click(object sender, EventArgs e)
        {
            if (tbKode.Text == "" || tbNama.Text == "" || tbAlamat.Text == "" || tbTelepon.Text == "" || tbJumlahPoin.Text == "" || (!rbStatusAktif.Checked && !rbStatusNonAktif.Checked))
            {
                MessageBox.Show("Semua Field Harus Terisi!");
            }
            else
            {
                string query = $"UPDATE MEMBER SET M_NAME = @M_NAME, M_BIRTHDATE = @M_BIRTHDATE, M_ADDRESS = @M_ADDRESS, M_TELP = @M_TELP, M_STATUS = @M_STATUS WHERE M_ID = @M_ID;";
                MySqlCommand cmd = new MySqlCommand(query, Koneksi.getConn());
                cmd.Parameters.AddWithValue("@M_NAME", tbNama.Text);
                cmd.Parameters.AddWithValue("@M_BIRTHDATE", dtpTanggalLahir.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@M_ADDRESS", tbAlamat.Text);
                cmd.Parameters.AddWithValue("@M_TELP", tbTelepon.Text);
                cmd.Parameters.AddWithValue("@M_STATUS", Convert.ToInt32(rbStatusAktif.Checked));
                cmd.Parameters.AddWithValue("@M_ID", tbKode.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Simpan Perubahan Berhasil!");
            }
        }
    }
}
