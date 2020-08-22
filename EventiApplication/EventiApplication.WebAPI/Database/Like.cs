using System;
using System.Collections.Generic;

namespace EventiApplication.WebAPI.Database
{
    public partial class Like
    {
        public int Id { get; set; }
        public int KorisnikId { get; set; }
        public int EventId { get; set; }
        public DateTime DatumLajka { get; set; }

        public virtual Event Event { get; set; }
        public virtual Korisnik Korisnik { get; set; }
    }
}
