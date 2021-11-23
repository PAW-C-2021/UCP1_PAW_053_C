using System;
using System.Collections.Generic;

namespace Channa.Models
{
    public partial class Ikan
    {
        public int IdIkan { get; set; }
        public string NamaIkan { get; set; }
        public int? StockIkan { get; set; }
        public int? HargaIkan { get; set; }
    }
}
