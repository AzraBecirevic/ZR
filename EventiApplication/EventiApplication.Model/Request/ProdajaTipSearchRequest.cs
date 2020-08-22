using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class ProdajaTipSearchRequest
    {
        public int EventId { get; set; }
        public string TipKarteNaziv { get; set; }
        public bool IsProdajaVecaOd0 { get; set; }
    }
}
