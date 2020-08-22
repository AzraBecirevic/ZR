using System;
using System.Collections.Generic;

namespace EventiApplication.WebAPI.Database
{
    public partial class Prijateljstvo
    {
        public int Id { get; set; }
        public int KorisnikPosiljalacId { get; set; }
        public int KorisnikPrimalacId { get; set; }
        public DateTime DatumSlanjaZahtjeva { get; set; }
        public bool IsPrihvaceno { get; set; }

        public virtual Korisnik KorisnikPosiljalac { get; set; }
        public virtual Korisnik KorisnikPrimalac { get; set; }
    }
}
