using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model
{
    public class PrijateljstvoPrikaz
    {
        public int Id { get; set; }
        public byte[] Slika { get; set; } = null;
        public int IdPrijatelja { get; set; }
        public string ImePrezime { get; set; }
        public bool IsVisible { get; set; }
        public string IconSource { get; set; }
        public bool IconIsVisible{ get; set; }

    }
}
