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
    public partial class FrmNasabah : Form
    {
        private int totalDebit = 0;
        private int totalKredit = 0;

        private IList<Catatan> listOfCatatan = new List<Catatan>();
        

        public FrmNasabah()
        {
            InitializeComponent();
            InisialisasiListView();
        }

        // atur kolom listview
        private void InisialisasiListView()
        {            
            lvwHistoriPemasukanPengeluaran.View = View.Details;
            lvwHistoriPemasukanPengeluaran.FullRowSelect = true;
            lvwHistoriPemasukanPengeluaran.GridLines = true;

            lvwHistoriPemasukanPengeluaran.Columns.Add("No.", 40, HorizontalAlignment.Center);
            lvwHistoriPemasukanPengeluaran.Columns.Add("Tanggal", 100, HorizontalAlignment.Center);
            lvwHistoriPemasukanPengeluaran.Columns.Add("Debit", 100, HorizontalAlignment.Right);
            lvwHistoriPemasukanPengeluaran.Columns.Add("Kredit", 100, HorizontalAlignment.Right);
        }

        private void FrmEntri_Buat(Catatan ctt)
        {
            listOfCatatan.Add(ctt);
            int noUrut = lvwHistoriPemasukanPengeluaran.Items.Count + 1;

            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(ctt.Tanggal.ToShortDateString());
            item.SubItems.Add(ctt.Debit);
            item.SubItems.Add(ctt.Kredit);

            if (ctt.Jenis == 0)
            {
                item.SubItems.Add("0");
                totalDebit += ctt.Nominal;
            }
            else
            {
                item.SubItems.Add("0");
                totalKredit += ctt.Nominal;
            }

            lvwHistoriPemasukanPengeluaran.Items.Add(item);

            lblTotalDebit.Text = Convert.ToString(totalDebit);
            lblTotalKredit.Text = Convert.ToString(totalKredit);
        }

        private void btnInputPemasukanPengeluaran_Click(object sender, EventArgs e)
        {
            string header = "Entri Pemasukan/Pengeluaran";
            string noRekening = txtNoRekening.Text;
            string nasabah = txtNasabah.Text;

            FrmEntriPemasukanPengeluaran frmEntri = new FrmEntriPemasukanPengeluaran(header, noRekening, nasabah);
            frmEntri.onCreate += FrmEntri_Buat;
            frmEntri.ShowDialog();
        }

    }
}
