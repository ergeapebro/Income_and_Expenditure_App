using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppEntriPemasukanPengeluaran
{
    public partial class FrmEntriPemasukanPengeluaran : Form
    {
        public delegate void CreateEvent(Catatan ctt);
        public event CreateEvent onCreate;
        private Catatan ctt;
        
        // constructor default
        public FrmEntriPemasukanPengeluaran()
        {
            InitializeComponent();
            cmbDebitKredit.SelectedIndex = 0;
        }

        public FrmEntriPemasukanPengeluaran(string header, string noRekening, string nasabah)
            : this() // panggil constructor default
        {
            this.Text = header;
            lblHeader.Text = header;

            txtNoRekening.Text = noRekening;
            txtNasabah.Text = nasabah;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            ctt = new Catatan();

            ctt.noRekening = txtNoRekening.Text;
            ctt.Nama = txtNasabah.Text;
            ctt.Tanggal = dtpTanggal.Value;
            ctt.Nominal = Convert.ToInt32(txtNominal.Text);
            ctt.Jenis = cmbDebitKredit.SelectedIndex;

            if (ctt.Jenis == 0)
            {
                ctt.Debit = Convert.ToString(ctt.Nominal);
                ctt.Kredit = Convert.ToString(txtNominal.Text = "0");
            }
            else
            {
                ctt.Kredit = Convert.ToString(ctt.Nominal);
                ctt.Debit = Convert.ToString(txtNominal.Text = "0");
            }

            onCreate(ctt);

            txtNominal.Text = "0";
            cmbDebitKredit.SelectedIndex = 0;
            dtpTanggal.Value = DateTime.Today;
            
        }
        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
