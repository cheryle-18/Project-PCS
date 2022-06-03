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
    public partial class FormViewLaporan : Form
    {
        private int mode;
        DateTime tglDari;
        DateTime tglSampai;

        public FormViewLaporan(int selection)
        {
            InitializeComponent();
            this.mode = selection;

            if(this.mode == 1)
            {
                dtpDari.Visible = false;
                dtpSampai.Visible = false;
                btnTampilkan.Visible = false;
                label5.Visible = false;
                label6.Visible = false;

                showLaporanBukuPreOrder();
                label3.Text = "Laporan Preorder Buku";
            }
            else if(this.mode == 2)
            {
                label3.Text = "Laporan Penjualan Buku diatas Rata-rata";
            }
            else if(this.mode == 3)
            {
                label3.Text = "Laporan Penjualan Buku dibawah Rata-rata";
            }
            else if(this.mode == 4)
            {
                label3.Text = "Laporan Member yang Paling Sering Membeli";
            }
            else if(this.mode == 5)
            {
                label3.Text = "Laporan Pegawai dengan Penjualan diatas Rata-rata";
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
           
            MySqlCommand check = new MySqlCommand(@"SELECT COUNT(*) FROM
            (SELECT book.`B_ID`, (CASE WHEN SUM(DP_QTY) IS NULL THEN 0 ELSE SUM(DP_QTY)END) AS TOTAL FROM book
            LEFT JOIN dtrans_purchase ON dtrans_purchase.`DP_B_ID` = book.`B_ID`
            LEFT JOIN htrans_purchase ON htrans_purchase.`HP_ID` = dtrans_purchase.`DP_HP_ID`
            WHERE htrans_purchase.`HP_DATE` IS NULL
            OR (htrans_purchase.`HP_DATE` >= STR_TO_DATE(@startDate, '%d/%m/%Y')
            AND htrans_purchase.`HP_DATE` <= STR_TO_DATE(@endDate, '%d/%m/%Y'))
            GROUP BY book.`B_ID`
            HAVING TOTAL <= @avg)X;", Koneksi.getConn());

            //FIND AVG
            MySqlCommand cmd = new MySqlCommand("SELECT (CASE WHEN SUM(DP_QTY)/COUNT(DP_B_ID) IS NULL THEN 0 ELSE SUM(DP_QTY)/COUNT(DP_B_ID) END) FROM dtrans_purchase JOIN htrans_purchase WHERE dtrans_purchase.`DP_HP_ID` = htrans_purchase.`HP_ID` AND htrans_purchase.`HP_DATE` >= STR_TO_DATE(@startDate,'%d/%m/%Y') AND htrans_purchase.`HP_DATE` <= STR_TO_DATE(@endDate,'%d/%m/%Y');", Koneksi.getConn());
            cmd.Parameters.AddWithValue("@startDate",dtpDari.Value.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@endDate", dtpSampai.Value.ToString("dd/MM/yyyy"));
            double avg = Convert.ToDouble(cmd.ExecuteScalar());

            check.Parameters.AddWithValue("@startDate",dtpDari.Value.ToString("dd/MM/yyyy"));
            check.Parameters.AddWithValue("@endDate",dtpSampai.Value.ToString("dd/MM/yyyy"));
            check.Parameters.AddWithValue("@avg", avg);

            int ct = Convert.ToInt32(check.ExecuteScalar());
            
            if(ct > 0)
            {
                CrPenjualanBukuDibawahRata rep = new CrPenjualanBukuDibawahRata();
                rep.SetParameterValue("average", avg);
                rep.SetParameterValue("startDate", dtpDari.Value);
                rep.SetParameterValue("endDate", dtpSampai.Value);
                crViewLaporan.ReportSource = rep;
            }
            else
            {
                CrKosongPenjualanDibawahRata rep = new CrKosongPenjualanDibawahRata();
                rep.SetParameterValue("average", avg);
                rep.SetParameterValue("startDate", dtpDari.Value);
                rep.SetParameterValue("endDate", dtpSampai.Value);
                crViewLaporan.ReportSource = rep;
            }

        }

        private void showLaporanBukuDiatasRata()
        {
            MySqlCommand check = new MySqlCommand(@"SELECT COUNT(*) FROM
            (SELECT book.`B_ID`, (CASE WHEN SUM(DP_QTY) IS NULL THEN 0 ELSE SUM(DP_QTY)END) AS TOTAL FROM book
            LEFT JOIN dtrans_purchase ON dtrans_purchase.`DP_B_ID` = book.`B_ID`
            LEFT JOIN htrans_purchase ON htrans_purchase.`HP_ID` = dtrans_purchase.`DP_HP_ID`
            WHERE htrans_purchase.`HP_DATE` IS NULL
            OR (htrans_purchase.`HP_DATE` >= STR_TO_DATE(@startDate, '%d/%m/%Y')
            AND htrans_purchase.`HP_DATE` <= STR_TO_DATE(@endDate, '%d/%m/%Y'))
            GROUP BY book.`B_ID`
            HAVING TOTAL >= @avg)X;", Koneksi.getConn());

            //FIND AVG
            MySqlCommand cmd = new MySqlCommand("SELECT SUM(DP_QTY)/COUNT(DP_B_ID) FROM dtrans_purchase;", Koneksi.getConn());
            double avg = Convert.ToDouble(cmd.ExecuteScalar());

            check.Parameters.AddWithValue("@startDate", dtpDari.Value.ToString("dd/MM/yyyy"));
            check.Parameters.AddWithValue("@endDate", dtpSampai.Value.ToString("dd/MM/yyyy"));
            check.Parameters.AddWithValue("@avg", avg);

            int ct = Convert.ToInt32(check.ExecuteScalar());
            if (ct > 0)
            {
                //SHOW CRYSTAL REPORT
                CrPenjualanBukuDiatasRata rep = new CrPenjualanBukuDiatasRata();
                rep.SetParameterValue("average", avg);
                rep.SetParameterValue("startDate", dtpDari.Value);
                rep.SetParameterValue("endDate", dtpSampai.Value);
                crViewLaporan.ReportSource = rep;
            }
            else
            {
                CrKosongPenjualanDiatasRata rep = new CrKosongPenjualanDiatasRata();
                rep.SetParameterValue("average", avg);
                rep.SetParameterValue("startDate", dtpDari.Value);
                rep.SetParameterValue("endDate", dtpSampai.Value);
                crViewLaporan.ReportSource = rep;
            }
        }

        public void showLaporanBukuPreOrder()
        {
            ReportPreOrder rep = new ReportPreOrder();
            crViewLaporan.ReportSource = rep;
        }

        public void showLaporanPenjualanPegawai()
        {
            ReportPenjualanPegawai rep = new ReportPenjualanPegawai();
            rep.SetParameterValue("tglDari", tglDari);
            rep.SetParameterValue("tglSampai", tglSampai);
            crViewLaporan.ReportSource = rep;
        }
        public void showLaporanMemberTerbanyakBeli()
        {
            MySqlCommand cmd;
            string id;
            cmd = new MySqlCommand("SELECT a.HP_M_ID FROM(SELECT HP_M_ID, SUM(HP_TOTAL_QTY) FROM htrans_purchase WHERE HP_M_ID IS NOT NULL GROUP BY HP_M_ID ORDER BY 2 DESC LIMIT 1) a; ",Koneksi.getConn());
            id = cmd.ExecuteScalar().ToString();
            ReportMemberTerbanyakBeli rep = new ReportMemberTerbanyakBeli();
            rep.SetParameterValue("idMember",id);
            rep.SetParameterValue("startDate", tglDari);
            rep.SetParameterValue("endDate", tglSampai);
            crViewLaporan.ReportSource = rep;
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            tglDari = dtpDari.Value;
            tglSampai = dtpSampai.Value;

            if (this.mode == 1)
            {
                showLaporanBukuPreOrder();
            }
            else if (this.mode == 2)
            {
                showLaporanBukuDiatasRata();
            }
            else if (this.mode == 3)
            {
                showLaporanBukuDibawahRata();
            }
            else if (this.mode == 4)
            {
                showLaporanMemberTerbanyakBeli();
            }
            else if (this.mode == 5)
            {
                showLaporanPenjualanPegawai();
            }
        }
    }
}
