using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model
{
    public class Organizator
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Telefon { get; set; }
        public int? GradId { get; set; } 
        public  Grad Grad { get; set; }
        public string Email { get; set; }

        //public string Username { get; set; }
        //public string PasswordSalt { get; set; }
        //public string PasswordHash { get; set; }

    }
}
