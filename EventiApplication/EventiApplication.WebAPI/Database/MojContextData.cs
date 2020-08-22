using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EventiApplication.WebAPI.Database
{
    public partial class MojContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            string salt1 = Helper.HashHelper.GenerateSalt();
            string salt2 = Helper.HashHelper.GenerateSalt();
            string salt3 = Helper.HashHelper.GenerateSalt();
            string salt4 = Helper.HashHelper.GenerateSalt();
            string salt5 = Helper.HashHelper.GenerateSalt();



            modelBuilder.Entity<Drzava>().HasData(
              new Drzava { Id = 1, Naziv = "BiH" }
             );

            modelBuilder.Entity<Grad>().HasData(
                new Grad { Id = 1, Naziv = "Sarajevo", DrzavaId = 1 },
                new Grad { Id = 2, Naziv = "Mostar", DrzavaId = 1 }
                );
            modelBuilder.Entity<Korisnik>().HasData(
                new Database.Korisnik
                {
                    Id = 1,
                    Ime = "Korisnik1",
                    Adresa = "Adresa1",
                    Email = "testiranjeslanjamaila@gmail.com",
                    GradId = 1,
                    IsAktivan = true,
                    PasswordSalt = salt1,
                    PasswordHash = Helper.HashHelper.GenerateHash(salt1, "test"),
                    PostanskiBroj = "71000",
                    Prezime = "Prezime1",
                    Telefon = "061222333",
                    Uloga = "Korisnik",
                    Username = "mobile"
                },
                 new Database.Korisnik
                 {
                     Id = 2,
                     Ime = "Korisnik2",
                     Adresa = "Adresa2",
                     Email = "testiranjeslanjamaila@gmail.com",
                     GradId = 1,
                     IsAktivan = true,
                     PasswordSalt = salt2,
                     PasswordHash = Helper.HashHelper.GenerateHash(salt2, "password2"),
                     PostanskiBroj = "71000",
                     Prezime = "Prezime2",
                     Telefon = "062333444",
                     Uloga = "Korisnik",
                     Username = "Korisnik2"
                 },
                  new Database.Korisnik
                  {
                      Id = 3,
                      Ime = "Korisnik3",
                      Adresa = "Adresa3",
                      Email = "testiranjeslanjamaila@gmail.com",
                      GradId = 1,
                      IsAktivan = true,
                      PasswordSalt = salt4,
                      PasswordHash = Helper.HashHelper.GenerateHash(salt4, "password3"),
                      PostanskiBroj = "71000",
                      Prezime = "Prezime3",
                      Telefon = "062888999",
                      Uloga = "Korisnik",
                      Username = "Korisnik3"
                  },
                  new Database.Korisnik
                  {
                      Id = 4,
                      Ime = "Korisnik4",
                      Adresa = "Adresa4",
                      Email = "testiranjeslanjamaila@gmail.com",
                      GradId = 1,
                      IsAktivan = true,
                      PasswordSalt = salt5,
                      PasswordHash = Helper.HashHelper.GenerateHash(salt1, "password4"),
                      PostanskiBroj = "71000",
                      Prezime = "Prezime4",
                      Telefon = "061222333",
                      Uloga = "Korisnik",
                      Username = "Korisnik4"
                  },
                   new Database.Korisnik
                   {
                       Id = 5,
                       Ime = "Korisnik5",
                       Adresa = "Adresa5",
                       Email = "testiranjeslanjamaila@gmail.com",
                       GradId = 1,
                       IsAktivan = true,
                       PasswordSalt = salt5,
                       PasswordHash = Helper.HashHelper.GenerateHash(salt1, "password5"),
                       PostanskiBroj = "71000",
                       Prezime = "Prezime5",
                       Telefon = "061666333",
                       Uloga = "Korisnik",
                       Username = "Korisnik5"
                   }
                 );

            modelBuilder.Entity<Administrator>().HasData(
                new Administrator
                {
                    Id = 1,
                    Email = "admin1@mail.com",
                    GradId = 1,
                    Ime = "Admin1",
                    Prezime = "Prezime1",
                    PasswordSalt = salt3,
                    PasswordHash = Helper.HashHelper.GenerateHash(salt3, "test"),
                    Username = "desktop",
                    Telefon = "063444555",
                    Uloga = "Administrator"
                }
                );

            modelBuilder.Entity<Organizator>().HasData(
                new Organizator { Id = 1, Naziv = "Org1", Email = "org1@mail.com", GradId = 1, Telefon = "061222222", Uloga = "Organizator" },
                new Organizator { Id = 2, Naziv = "Org2", Email = "org2@mail.com", GradId = 1, Telefon = "061555555", Uloga = "Organizator" },
                new Organizator { Id = 3, Naziv = "Org3", Email = "org3@mail.com", GradId = 1, Telefon = "061333333", Uloga = "Organizator" }

                );

            modelBuilder.Entity<TipProstoraOdrzavanja>().HasData(
                 new TipProstoraOdrzavanja { Id = 1, Naziv = "Sala" },
                 new TipProstoraOdrzavanja { Id = 2, Naziv = "Dvorana" },
                 new TipProstoraOdrzavanja { Id = 3, Naziv = "Stadion" }
                );

            modelBuilder.Entity<ProstorOdrzavanja>().HasData(
                new ProstorOdrzavanja
                {
                    Id = 1,
                    Adresa = "Obala Kulina bana 9, Sarajevo",
                    GradId = 1,
                    Naziv = "Narodno pozorište Sarajevo",
                    TipProstoraOdrzavanjaId = 1
                },
                new ProstorOdrzavanja { Id = 2, Adresa = "Alipašina bb, Sarajevo 71000", GradId = 1, Naziv = "Zetra", TipProstoraOdrzavanjaId = 2 },
                new ProstorOdrzavanja
                {
                    Id = 3,
                    Adresa = "Zvornička 27 Sarajevo 71000",
                    GradId = 1,
                    Naziv = "Stadion Grbavica",
                    TipProstoraOdrzavanjaId = 3
                }
                );

            modelBuilder.Entity<Kategorija>().HasData(
                 new Kategorija { Id = 1, Naziv = "Muzika" },
                new Kategorija { Id = 2, Naziv = "Kultura" },
                new Kategorija { Id = 3, Naziv = "Sport" }
                );

            modelBuilder.Entity<Event>().HasData(
                  new Database.Event
                  {
                      Id = 1,
                      DatumOdrzavanja = DateTime.Now.AddDays(30),
                      IsOdobren = true,
                      IsOtkazan = false,
                      KategorijaId = 2,
                      Naziv = "Event1",
                      Opis = "...",
                      OrganizatorId = 1,
                      ProstorOdrzavanjaId = 1,
                      VrijemeOdrzavanja = "20:00",
                      AdministratorId = 1,
                      Slika = null,
                      SlikaThumb = null

                  },
                 new Database.Event
                 {
                     Id = 2,
                     DatumOdrzavanja = DateTime.Now.AddDays(30),
                     IsOdobren = true,
                     IsOtkazan = false,
                     KategorijaId = 1,
                     Naziv = "Event2",
                     Opis = "...",
                     OrganizatorId = 2,
                     ProstorOdrzavanjaId = 2,
                     VrijemeOdrzavanja = "20:00",
                     AdministratorId = 1,
                     Slika = null,
                     SlikaThumb = null

                 },
                new Database.Event
                {
                    Id = 3,
                    DatumOdrzavanja = DateTime.Now.AddDays(30),
                    IsOdobren = true,
                    IsOtkazan = false,
                    KategorijaId = 3,
                    Naziv = "Event3",
                    Opis = "...",
                    OrganizatorId = 1,
                    ProstorOdrzavanjaId = 3,
                    VrijemeOdrzavanja = "20:00",
                    AdministratorId = 1,
                    Slika = null,
                    SlikaThumb = null
                }
                );

            modelBuilder.Entity<TipKarte>().HasData(
                 new TipKarte { Id = 1, Naziv = "VIP" },
                 new TipKarte { Id = 2, Naziv = "Parter" },
                 new TipKarte { Id = 3, Naziv = "Tribina" },
                 new TipKarte { Id = 4, Naziv = "Obicna" }
                );

            modelBuilder.Entity<ProdajaTip>().HasData(
                new ProdajaTip
                {
                    Id = 1,
                    EventId = 1,
                    TipKarteId = 1,
                    BrojProdatihKarataTip = 0,
                    CijenaTip = 15,
                    PostojeSjedista = true,
                    UkupnoKarataTip = 100
                },
                  new ProdajaTip
                  {
                      Id = 2,
                      EventId = 2,
                      TipKarteId = 2,
                      BrojProdatihKarataTip = 1,
                      CijenaTip = 10,
                      PostojeSjedista = false,
                      UkupnoKarataTip = 1000
                  },
                  new ProdajaTip
                  {
                      Id = 3,
                      EventId = 3,
                      TipKarteId = 3,
                      BrojProdatihKarataTip = 0,
                      CijenaTip = 10,
                      PostojeSjedista = false,
                      UkupnoKarataTip = 1000
                  }
                );

            modelBuilder.Entity<Prijateljstvo>().HasData(
                new Prijateljstvo
                {
                    Id = 1,
                    DatumSlanjaZahtjeva = DateTime.Now,
                    IsPrihvaceno = true,
                    KorisnikPosiljalacId = 1,
                    KorisnikPrimalacId = 2
                },
                new Prijateljstvo
                {
                    Id = 2,
                    DatumSlanjaZahtjeva = DateTime.Now,
                    IsPrihvaceno = true,
                    KorisnikPosiljalacId = 3,
                    KorisnikPrimalacId = 1
                }
                );

            modelBuilder.Entity<PozivNaEvent>().HasData(
                new PozivNaEvent
                {
                    Id = 1,
                    EventId = 1,
                    IsOdbijen = false,
                    IsPrihvacen = false,
                    KorisnikPozivalacId = 2,
                    KorisnikPozvaniId = 1
                },
                new PozivNaEvent
                {
                    Id = 2,
                    EventId = 2,
                    IsOdbijen = false,
                    IsPrihvacen = false,
                    KorisnikPozivalacId = 1,
                    KorisnikPozvaniId = 2
                },
                new PozivNaEvent
                {
                    Id = 3,
                    EventId = 3,
                    IsOdbijen = false,
                    IsPrihvacen = true,
                    KorisnikPozivalacId = 3,
                    KorisnikPozvaniId = 1
                }
                );

            modelBuilder.Entity<Kupovina>().HasData(
                new Kupovina
                {
                    Id=1,
                    EventId=2,
                    KorisnikId=1
                }
                );
            modelBuilder.Entity<KupovinaTip>().HasData(
                new KupovinaTip
                {
                    Id=1,
                     KupovinaId=1,
                      ProdajaTipId=2,
                       BrojKarata=1,
                        Cijena=10
                         
                }
                );

            modelBuilder.Entity<Karta>().HasData(
                new Karta
                {
                    Id=1,
                     Cijena=10,
                      DatumKupovine=DateTime.Now,
                       KupovinaTipId=1, 
                        TipKarteId=2,
                        QrCode=null
                }
                );
        }
    }
}
