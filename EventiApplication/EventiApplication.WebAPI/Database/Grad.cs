using System;
using System.Collections.Generic;

namespace EventiApplication.WebAPI.Database
{
    public partial class Grad
    {
        public Grad()
        {
            Administrator = new HashSet<Administrator>();
            Korisnik = new HashSet<Korisnik>();
            Organizator = new HashSet<Organizator>();
            ProstorOdrzavanja = new HashSet<ProstorOdrzavanja>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int DrzavaId { get; set; }

        public virtual Drzava Drzava { get; set; }
        public virtual ICollection<Administrator> Administrator { get; set; }
        public virtual ICollection<Korisnik> Korisnik { get; set; }
        public virtual ICollection<Organizator> Organizator { get; set; }
        public virtual ICollection<ProstorOdrzavanja> ProstorOdrzavanja { get; set; }
     
    }
}
