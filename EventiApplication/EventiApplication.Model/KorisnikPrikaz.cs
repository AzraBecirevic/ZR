using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model
{
    public class KorisnikPrikaz
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public byte[] Slika { get; set; } = null;
        public bool IsVisibleSlika { get; set; }
        public string IconSource { get; set; }
        public bool IsVisbleIcon { get; set; }
    }
}
