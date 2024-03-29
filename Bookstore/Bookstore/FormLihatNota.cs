﻿using System;
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
    public partial class FormLihatNota : Form
    {
        private int user_role;
        private string tr_id;
        public FormLihatNota(int role,string tr_id)
        {
            InitializeComponent();
            this.user_role = role;
            this.tr_id = tr_id;

            loadNota();
        }

        private void loadNota()
        {
            this.label3.Text = "NOTA TRANSAKSI";
            CrNotaTransaksi rep = new CrNotaTransaksi();
            rep.SetParameterValue("id_transaksi", tr_id);
            crNota.ReportSource = rep;
        }

        private void FormLihatNota_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormDetailTransaksi frm = new FormDetailTransaksi(user_role,tr_id);
            Panel temp = (Panel)frm.Controls[0];
            temp.Width = panel1.Width;
            temp.Height = panel1.Height;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(temp);
        }
    }
}
