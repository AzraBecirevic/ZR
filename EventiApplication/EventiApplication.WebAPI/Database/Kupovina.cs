using System;
using System.Collections.Generic;

namespace EventiApplication.WebAPI.Database
{
    public partial class Kupovina
    {
        public Kupovina()
        {
            KupovinaTip = new HashSet<KupovinaTip>();
            Recenzija = new HashSet<Recenzija>();
        }

        public int Id { get; set; }
        public int KorisnikId { get; set; }
        public int EventId { get; set; }

        public virtual Event Event { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public virtual ICollection<KupovinaTip> KupovinaTip { get; set; }
        public virtual ICollection<Recenzija> Recenzija { get; set; }
    }
}
