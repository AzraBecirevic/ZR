using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public int? GradId { get; set; }
        public Grad Grad { get; set; }
        public string Adresa { get; set; }
        public string PostanskiBroj { get; set; }
      
        public string Email { get; set; }
        public string Username { get; set; }
        public bool IsAktivan { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public  string Uloga { get; set; }  
    }
}
