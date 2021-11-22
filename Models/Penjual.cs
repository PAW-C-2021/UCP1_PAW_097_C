using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_097_C.Models
{
    public partial class Penjual
    {
        public int IdPenjual { get; set; }
        public string NamaPenjual { get; set; }
        public string EmailPenjual { get; set; }
        public string AlamatPenjual { get; set; }
        public string NoHpPenjual { get; set; }
        public string TentangPenjual { get; set; }
        public int? IdTanah { get; set; }

        public virtual Tanah IdTanahNavigation { get; set; }
    }
}
