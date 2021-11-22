using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_097_C.Models
{
    public partial class Transaksi
    {
        public Transaksi()
        {
            Pembelis = new HashSet<Pembeli>();
        }

        public int IdTransaksi { get; set; }
        public int? IdTanah { get; set; }
        public DateTime? Tanggal { get; set; }

        public virtual Tanah IdTanahNavigation { get; set; }
        public virtual ICollection<Pembeli> Pembelis { get; set; }
    }
}
