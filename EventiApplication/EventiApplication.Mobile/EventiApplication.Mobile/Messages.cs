using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Mobile
{
    public  class Messages
    {
        public static string Unauthorized { get; set; } = "Niste autentificirani, pogresno korisnicko ime ili lozinka ";

        public static string Forrbiden{ get; set; } = "Nemate pravo pristupa";

        public static string IntServerErr { get; set; } = "Greska na serveru";

        public static string BadRqst { get; set; } = "Neispravni podaci poslani";

        public static string ValErrObaveznoPolje { get; set; } = "Obavezno polje";
      
        public static string ValErrFormatTelefona { get; set; } = "U formatu 011222555";

        public static string ValErrFormatPostanskogBroja { get; set; } = "Samo brojevi, maksmalno 15";

        public static string ValErrFormatBrojaKartice { get; set; } = "Samo brojevi, minimalno 14, maksmalno 19";

        public static string ValErrEmailFormat { get; set; } = "U formatu text@nekiMail.com";

        public static string ValErrStavka { get; set; } = "Obavezan izbor";
        public static string ValErrMin2Karaktera { get; set; } = "Minimalno 2 karaktera";
 
        public static string ValErrPasswordDuzina { get; set; } = "Minimalno 8 karaktera, maksimalno 50";

        public static string ValErrPasswordFormat { get; set; } = "Potrebna kombinacija velikih i malih slova i brojeva";
        public static string ValErrPasswordConfirmation { get; set; } = "Potvrdite uneseni password";
        public static string ValErrTrenutniPassword { get; set; } = "Niste unijeli ispravan trenutni password";


        public static string UspjesnaRegistracija { get; set; } = "Uspjesna registracija";
        public static string NeuspjesnaRegistracija { get; set; } = "Neuspjesna registracija";

        public static string PromjenaUsername { get; set; } = "Promijenite korisnicko ime";

        public static string OcjenaUspjesnoSpasena { get; set; } = "Uspjesno spremljeno";
        public static string OcjenaUspjesnoIzmijenjena { get; set; } = "Uspjesno izmijenjeno";
        public static string OcjenaVecaOd0 { get; set; } = "Ako zelite ocijniti event, morate oznaciti barem 1 zvijezdicu";

        public static string NemoguceBrisanjeZahtijeva { get; set; } = "Ne mozete obrisati zahtjev";
        public static string ObrisanZahtjev { get; set; } = "Obrisan zahtjev";

        public static string ProblemBrisanjaZahtijeva { get; set; } = "Problem prilikom prihavatanja zahtjeva";
        public static string PrihvacenZahtjev { get; set; } = "Prihvacen zahtjev za prijateljstvo";
        public static string DodanoPrijateljstvo { get; set; } = "Poslan zahtjev za prijateljstvo";
        public static string ObrisanoPrijateljstvo { get; set; } = "Obrisano prijateljstvo";
        public static string NemaPrikazanihPrijatelja { get; set; } = "Pozvali ste sve svoje prijatelje, ili nemate prijatelja za poziv na event.";


    }
}
