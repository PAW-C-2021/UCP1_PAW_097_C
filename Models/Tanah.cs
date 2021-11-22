using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_097_C.Models
{
    public partial class Tanah
    {
        public Tanah()
        {
            Penjuals = new HashSet<Penjual>();
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdTanah { get; set; }
        public string JudulTanah { get; set; }
        public string AlamatTanah { get; set; }
        public string Status { get; set; }
        public int? Harga { get; set; }
        public int? Luas { get; set; }
        public byte[] Foto { get; set; }

        public virtual ICollection<Penjual> Penjuals { get; set; }
        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
