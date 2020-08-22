using System;
using System.Collections.Generic;

namespace EventiApplication.WebAPI.Database
{
    public partial class PozivNaEvent
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event  Event { get; set; }
        public int KorisnikPozivalacId { get; set; }
        public int KorisnikPozvaniId { get; set; }
        public bool IsPrihvacen { get; set; }
        public bool IsOdbijen { get; set; }

        public virtual Korisnik KorisnikPozivalac { get; set; }
        public virtual Korisnik KorisnikPozvani { get; set; }
    }
}
