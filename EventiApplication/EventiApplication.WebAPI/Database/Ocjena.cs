using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventiApplication.WebAPI.Database
{
    public class Ocjena
    { 
        public int Id { get; set; }

        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public int OcjenaEventa { get; set; }
    }
}
