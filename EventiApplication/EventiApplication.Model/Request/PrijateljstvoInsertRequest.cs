using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class PrijateljstvoInsertRequest
    { 
        public int KorisnikPosiljalacId { get; set; }
        public int KorisnikPrimalacId { get; set; }
        public DateTime DatumSlanjaZahtjeva { get; set; }
        public bool IsPrihvaceno { get; set; } // ili u update zbog prihvacanja prijateljstva?

    }
}
