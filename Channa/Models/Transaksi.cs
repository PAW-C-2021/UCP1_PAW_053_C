using System;
using System.Collections.Generic;

namespace Channa.Models
{
    public partial class Transaksi
    {
        public int IdTransaksi { get; set; }
        public int? IdIkan { get; set; }
        public int? IdPembeli { get; set; }
        public int? JumlahTransaksi { get; set; }
        public DateTime? TanggalTransaksi { get; set; }
    }
}
