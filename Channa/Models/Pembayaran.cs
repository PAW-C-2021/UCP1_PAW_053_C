using System;
using System.Collections.Generic;

namespace Channa.Models
{
    public partial class Pembayaran
    {
        public int IdPembayaran { get; set; }
        public int? IdTransaksi { get; set; }
        public int? IdPenjual { get; set; }
        public int? TotalPembayaran { get; set; }
        public DateTime? TanggalPembayaran { get; set; }
    }
}
