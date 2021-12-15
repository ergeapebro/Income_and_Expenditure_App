using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppEntriPemasukanPengeluaran
{
    public class Catatan
    {
        public string noRekening { get; set; }
        public string Nama { get; set; }
        public DateTime Tanggal { get; set; }
        public string Debit { get; set; }
        public string Kredit { get; set; }
        public int Nominal { get; set; }
        public int Jenis { get; set; }
    }
}
