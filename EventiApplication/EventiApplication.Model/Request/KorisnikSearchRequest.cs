using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class KorisnikSearchRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public bool IsUserSearch { get; set; }
        public int IdKorisnikaPretrazitelja { get; set; }
    }
}
