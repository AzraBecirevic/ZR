using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventiApplication.WebAPI.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventiApplication.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly MojContext _ctx; 

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, MojContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        { 
            DatabaseIncijalizacija();
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        private void DatabaseIncijalizacija()
        {
            if (_ctx.Korisnik.Count() > 0 || _ctx.Administrator.Count() > 0)
                return;

            string salt1 = Helper.HashHelper.GenerateSalt();
            string salt2 = Helper.HashHelper.GenerateSalt();
            string salt3 = Helper.HashHelper.GenerateSalt();


            Drzava drzava = new Drzava { Naziv = "BiH" };
            _ctx.Drzava.Add(drzava);  
            _ctx.SaveChanges();
           

            Grad grad = new Grad { Naziv = "Sarajevo", Drzava=drzava };
            _ctx.Grad.Add(grad);
            _ctx.SaveChanges();


            var korisnik1 = new Database.Korisnik
            {
                Ime = "Korisnik1",
                Adresa = "Adresa1",
                Email = "testiranjeslanjamaila@gmail.com",
                Grad = grad,
                IsAktivan = true,
                PasswordSalt = salt1,
                PasswordHash = Helper.HashHelper.GenerateHash(salt1, "test"),
                PostanskiBroj = "71000",
                Prezime = "Prezime1",
                Telefon = "061000111",
                Uloga = "Korisnik",
                Username = "mobile"
            };
            _ctx.Korisnik.Add(korisnik1);
            _ctx.SaveChanges();

            var korisnik2 = new Database.Korisnik
            {
                Ime = "Korisnik2",
                Adresa = "Adresa2",
                Email = "testiranjeslanjamaila@gmail.com",
                Grad=grad,
                IsAktivan = true,
                PasswordSalt = salt2,
                PasswordHash = Helper.HashHelper.GenerateHash(salt2, "password2"),
                PostanskiBroj = "71000",
                Prezime = "Prezime2",
                Telefon = "061000222",
                Uloga = "Korisnik",
                Username = "korisnik2"
            };


            
            _ctx.Korisnik.Add(korisnik2);
            _ctx.SaveChanges();



            Administrator administrator = new Administrator
            {
                Email = "admin1@mail.com",
                Grad=grad,
                Ime = "Admin1",
                Prezime = "Prezime1",
                PasswordSalt = salt3,
                PasswordHash = Helper.HashHelper.GenerateHash(salt3, "test"),
                Username = "desktop",
                Telefon = "061000333",
                Uloga = "Administrator"
            };
            _ctx.Administrator.Add(administrator);
       
            var org1 = new Organizator { 
                Naziv = "Org1", 
                Email = "org1@mail.com",
                Grad=grad,
                Telefon = "062222222", 
                Uloga = "..." 
            };
            var org2 = new Organizator { 
                Naziv = "Org2",
                Email = "org2@mail.com",
                Grad = grad,
                Telefon = "062555555", 
                Uloga = "..." 
            };
            var org3 = new Organizator { 
                Naziv = "Org3",
                Email = "org3@mail.com", 
                Grad=grad,
                Telefon = "062333333", 
                Uloga = "..." 
            };

            _ctx.Organizator.Add(org1);
            _ctx.Organizator.Add(org2);
            _ctx.Organizator.Add(org3);
            _ctx.SaveChanges();



            var tip1 = new TipProstoraOdrzavanja { Naziv = "Sala" };
            var tip2 = new TipProstoraOdrzavanja { Naziv = "Dvorana" };
            var tip3 = new TipProstoraOdrzavanja { Naziv = "Stadion" };
         

            _ctx.TipProstoraOdrzavanja.Add(tip1);
            _ctx.TipProstoraOdrzavanja.Add(tip2);
            _ctx.TipProstoraOdrzavanja.Add(tip3);
            _ctx.SaveChanges();

            var prostor1 = new ProstorOdrzavanja
            {

                Adresa = "Obala Kulina bana 9, Sarajevo",
                Grad=grad,
                Naziv = "Narodno pozorište Sarajevo",
                TipProstoraOdrzavanja=tip1
            };
           

            var prostor2 = new ProstorOdrzavanja
            {
                Adresa = "Alipašina bb, Sarajevo 71000",
                Grad=grad,
                Naziv = "Zetra",
               TipProstoraOdrzavanja=tip2
            };
           
            

            var prostor3 = new ProstorOdrzavanja
            {
                Adresa = "Zvornička 27 Sarajevo 71000",
                Grad=grad,
                Naziv = "Stadion Grbavica",
                TipProstoraOdrzavanja=tip3
            };

            _ctx.ProstorOdrzavanja.Add(prostor3);
            _ctx.ProstorOdrzavanja.Add(prostor2);
            _ctx.ProstorOdrzavanja.Add(prostor1);
            _ctx.SaveChanges();


            var kategorija1 = new Kategorija { Naziv = "Muzika" };
            var kategorija2 = new Kategorija { Naziv = "Kultura" };
            var kategorija3 = new Kategorija { Naziv = "Sport" };

            _ctx.Kategorija.Add(kategorija2);
            _ctx.Kategorija.Add(kategorija3);
            _ctx.Kategorija.Add(kategorija1);
            _ctx.SaveChanges();



            var event1 = new Database.Event
            {
                DatumOdrzavanja = DateTime.Now.AddDays(30),
                IsOdobren = true,
                IsOtkazan = false,
                Kategorija = kategorija2,
                Naziv = "Event1",
                Opis = "...",
                Organizator=org1,
                ProstorOdrzavanja=prostor1,
                VrijemeOdrzavanja = "20:00",
                Administrator=administrator,
                Slika = Helper.ImageHelper.ReadFile("Images/opera.jpg"),
                SlikaThumb = Helper.ImageHelper.ReadFile("Images/opera.jpg"),
            };
            _ctx.Event.Add(event1);
            _ctx.SaveChanges();


            var event2 = new Database.Event
            {
                DatumOdrzavanja = DateTime.Now.AddDays(30),
                IsOdobren = true,
                IsOtkazan = false,
                Kategorija = kategorija1,
                Naziv = "Event2",
                Opis = "...",
                Organizator=org2,
                ProstorOdrzavanja=prostor2,
                VrijemeOdrzavanja = "20:00",
                Administrator=administrator,
                Slika = Helper.ImageHelper.ReadFile("Images/koncert.jpg"),
                SlikaThumb = Helper.ImageHelper.ReadFile("Images/koncert.jpg")

            };
            _ctx.Event.Add(event2);
            _ctx.SaveChanges();

            var event3 = new Database.Event
            {
                DatumOdrzavanja = DateTime.Now.AddDays(30),
                IsOdobren = true,
                IsOtkazan = false,
                Kategorija = kategorija3,
                Naziv = "Event3",
                Opis = "...",
                Organizator=org3,
                ProstorOdrzavanja=prostor3,
                VrijemeOdrzavanja = "20:00",
                Administrator=administrator,
                Slika = Helper.ImageHelper.ReadFile("Images/fudbal.jpg"),
                SlikaThumb = Helper.ImageHelper.ReadFile("Images/fudbal.jpg")
            };
            _ctx.Event.Add(event3);
            _ctx.SaveChanges();




            var tipKarte1 = new TipKarte { Naziv = "VIP" };
            var tipKarte2 = new TipKarte { Naziv = "Parter" };
            var tipKarte3 = new TipKarte { Naziv = "Tribina" };
            var tipKarte4 = new TipKarte { Naziv = "Obicna" };

           
            _ctx.TipKarte.Add(tipKarte4);
            _ctx.TipKarte.Add(tipKarte3); 
            _ctx.TipKarte.Add(tipKarte2);
            _ctx.TipKarte.Add(tipKarte1);

            _ctx.SaveChanges();

            var prodajaTip1 = new ProdajaTip
            {
                Event = event1,
                TipKarte = tipKarte1,
                BrojProdatihKarataTip = 0,
                CijenaTip = 15,
                PostojeSjedista = true,
                UkupnoKarataTip = 100
            };
            var prodajaTip2 = new ProdajaTip
            {
                Event = event2,
                TipKarte = tipKarte2,
                BrojProdatihKarataTip = 0,
                CijenaTip = 10,
                PostojeSjedista = false,
                UkupnoKarataTip = 1000

            };
            _ctx.ProdajaTip.Add(prodajaTip1);
            _ctx.ProdajaTip.Add(prodajaTip2);


            _ctx.SaveChanges();

        }

    }
}
