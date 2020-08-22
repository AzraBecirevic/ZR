using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model
{
    public class Prijateljstvo
    {
        public int Id { get; set; }
        public int KorisnikPosiljalacId { get; set; }
        public string ImePrezimePosiljaoca { get; set; }

        public int KorisnikPrimalacId { get; set; }
        public string ImePrezimePrimaoca { get; set; }

        public byte[] Slika { get; set; } = null;  // trebaju 2 ili promoijeniti an apiu get
        public string DatumSlanjaZahtjeva { get; set; }
        public bool IsPrihvaceno { get; set; }

    }
}
