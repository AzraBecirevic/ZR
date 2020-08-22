using System;
using System.Collections.Generic;

namespace EventiApplication.WebAPI.Database
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Kupovina = new HashSet<Kupovina>();
            Like = new HashSet<Like>();
            PozivNaEventKorisnikPozivalac = new HashSet<PozivNaEvent>();
            PozivNaEventKorisnikPozvani = new HashSet<PozivNaEvent>();
            PrijateljstvoKorisnikPosiljalac = new HashSet<Prijateljstvo>();
            PrijateljstvoKorisnikPrimalac = new HashSet<Prijateljstvo>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public int? GradId { get; set; }
        public string Adresa { get; set; }
        public string PostanskiBroj { get; set; }
     
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }

        public bool IsAktivan { get; set; }
        public string Uloga { get; set; } = "Korisnik";

        public virtual Grad Grad { get; set; }
        public virtual ICollection<Kupovina> Kupovina { get; set; }
        public virtual ICollection<Like> Like { get; set; }
        public virtual ICollection<PozivNaEvent> PozivNaEventKorisnikPozivalac { get; set; }
        public virtual ICollection<PozivNaEvent> PozivNaEventKorisnikPozvani { get; set; }
        public virtual ICollection<Prijateljstvo> PrijateljstvoKorisnikPosiljalac { get; set; }
        public virtual ICollection<Prijateljstvo> PrijateljstvoKorisnikPrimalac { get; set; }
    }
}
