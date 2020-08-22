using System;
using System.Collections.Generic;

namespace EventiApplication.WebAPI.Database
{
    public partial class Organizator
    {
        public Organizator()
        {
            Event = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Telefon { get; set; }
        public int? GradId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public string Uloga { get; set; } = "Organizator";

        public virtual Grad Grad { get; set; }
        public virtual ICollection<Event> Event { get; set; }
    }
}
