﻿using MySql.Data.MySqlClient;
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
    public partial class FormViewLaporan : Form
    {
        private int mode;
        public FormViewLaporan(int selection)
        {
            InitializeComponent();
            this.mode = selection;

            if(this.mode == 1)
            {

            }
            else if(this.mode == 2)
            {
                
            }
            else if(this.mode == 3)
            {
                showLaporanBukuDibawahRata();
            }
            else if(this.mode == 4)
            {

            }
            else if(this.mode == 5)
            {

            }

        }

        private void FormViewLaporan_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MasterLaporanAdmin frm = new MasterLaporanAdmin();
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel1.Width;
            temp.Height = panel1.Height;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(temp);
        }

        private void showLaporanBukuDibawahRata()
        {
            //SHOW CRYSTAL REPORT
            CrPenjualanBukuDibawahRata rep = new CrPenjualanBukuDibawahRata();

            //FIND AVG
            MySqlCommand cmd = new MySqlCommand("SELECT SUM(DP_QTY)/COUNT(DP_B_ID) FROM dtrans_purchase;",Koneksi.getConn());
            double avg = Convert.ToDouble(cmd.ExecuteScalar());
            rep.SetParameterValue("average", avg);
            crViewLaporan.ReportSource = rep;
        }
    }
}
