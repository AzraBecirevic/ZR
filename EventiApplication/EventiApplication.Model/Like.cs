using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model
{
    public class Like
    {
        public int Id { get; set; }
        public int KorisnikId { get; set; }
        public int EventId { get; set; }
        public DateTime DatumLajka { get; set; }
    }
}
