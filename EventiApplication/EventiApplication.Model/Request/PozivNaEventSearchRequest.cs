using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class PozivNaEventSearchRequest
    {
        public int KorisnikPozivalacId { get; set; }  // upuceni pozivi
        public int KorisnikPozvaniId { get; set; }   // primljeni pozivi

        public bool NoviPozivi { get; set; }
        public bool StariPozivi { get; set; }

        public bool PoslaniPozivi { get; set; }
        public bool DobijeniPozivi { get; set; }

        public bool OdbijeniPozivi { get; set; }
        public bool PrihvaceniPozivi { get; set; }
        public bool NeodgovoreniPozivi { get; set; }
    }
}
