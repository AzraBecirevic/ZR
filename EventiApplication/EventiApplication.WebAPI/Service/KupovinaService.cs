using AutoMapper;
using EventiApplication.Model;
using EventiApplication.Model.Request;
using EventiApplication.WebAPI.Database;
using EventiApplication.WebAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using QRCoder;
using System.Drawing;
using System.IO;

namespace EventiApplication.WebAPI.Service
{
    public class KupovinaService :
        BaseCRUDService<Model.Kupovina, KupovinaSearchRequest, Database.Kupovina, KupovinaInsertRequest, KupovinaInsertRequest, object>
    {
        public KupovinaService(MojContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }
        float CijenaTrenutneKupovine = 0;
        public override List<Model.Kupovina> Get(KupovinaSearchRequest search)
        {
            var query = _ctx.Kupovina.AsQueryable();

            if (search != null)
            {

                if (search.EventId != 0)
                {
                    query = query.Where(k => k.EventId == search.EventId);
                }
                if (search.KorisnikId != 0)
                {
                    query = query.Where(k => k.KorisnikId == search.KorisnikId);
                }
            }
            List<Model.Kupovina> list = query.Select(k => new Model.Kupovina
            {
                Id = k.Id,
                EventId = k.EventId,
                DatumEventa = k.Event.DatumOdrzavanja.ToShortDateString(),
                GradEventa = k.Event.ProstorOdrzavanja.Grad.Naziv,
                KorisnikId = k.KorisnikId,
                EventNaziv = k.Event.Naziv,
                BrojKupljenihKarata = _ctx.KupovinaTip.Where(x=>x.KupovinaId==k.Id).Sum(x=>x.BrojKarata),
                CijenaSvihKupljenihKarata = _ctx.KupovinaTip.Where(x => x.KupovinaId == k.Id).Sum(x => x.Cijena),  //?? cijena kao zbir ili je cijena 1 karte
                SlikaEventa=k.Event.Slika
            }).ToList();

            return list;
        }

        public override Model.Kupovina Insert(KupovinaInsertRequest request)
        {
            if (request == null)
            {
                throw new UserException("Problem prilikom obavljenja kupovine karte"); 
            }
            if (request.KorisnikId <= 0 || request.EventId <= 0 || request.ProdajaTipId <= 0 || request.ZeljeniBrKarata <= 0)
                throw new UserException("Problem prilikom obavljenja kupovine karte");

            Database.ProdajaTip prodaja = _ctx.ProdajaTip.Where(p => p.Id == request.ProdajaTipId).FirstOrDefault();

            // provjera da li postoji prodaja

            if (request.ZeljeniBrKarata > (prodaja?.UkupnoKarataTip - prodaja?.BrojProdatihKarataTip))
            {
                throw new UserException("Nema toliko karata u ponudi");  
            }

            Database.Kupovina k = _ctx.Kupovina.Where(k => k.EventId == request.EventId && k.KorisnikId == request.KorisnikId).SingleOrDefault();
          

            if (k == null)
            {
                k = new Database.Kupovina
                {
                    KorisnikId = request.KorisnikId,
                    EventId = request.EventId
                };

                _ctx.Kupovina.Add(k);
                
                // posto ne postpji kupovina, nema ni kupovinaTip
                KupovinaTip kupovinaTip = new KupovinaTip
                {
                    Kupovina = k, 
                    ProdajaTipId = prodaja.Id,
                    BrojKarata = request.ZeljeniBrKarata,
                    Cijena = prodaja.CijenaTip * request.ZeljeniBrKarata
                };
                _ctx.KupovinaTip.Add(kupovinaTip);
                _ctx.SaveChanges();
          
                SetujKarte(request.ZeljeniBrKarata, kupovinaTip, prodaja, request.EventId, request.KorisnikId);
                _ctx.SaveChanges();

              try
                {
                    PosaljiMail(request.KorisnikId, CijenaTrenutneKupovine, request.EventId);
                }
                catch(Exception ex)
                {

                }

                CijenaTrenutneKupovine = 0;

                return _mapper.Map<Model.Kupovina>(k); 
            }
            else
            {
                KupovinaTip kupovinaTip = _ctx.KupovinaTip.Where(x => x.KupovinaId == k.Id && x.ProdajaTipId==prodaja.Id).FirstOrDefault();

                if(kupovinaTip == null)
                {
                    kupovinaTip = new KupovinaTip
                    {
                        Kupovina =k,
                        ProdajaTipId = prodaja.Id,
                        BrojKarata = request.ZeljeniBrKarata,
                        Cijena = prodaja.CijenaTip * request.ZeljeniBrKarata
                    };
                    _ctx.KupovinaTip.Add(kupovinaTip);
                }
                else   //KupovinaTip postoji
                {
                    kupovinaTip.BrojKarata += request.ZeljeniBrKarata;
                    kupovinaTip.Cijena += request.ZeljeniBrKarata * prodaja.CijenaTip;
                }
                _ctx.SaveChanges();

                 SetujKarte(request.ZeljeniBrKarata, kupovinaTip, prodaja, request.EventId, request.KorisnikId);
                 _ctx.SaveChanges();

                try
                {
                    PosaljiMail(request.KorisnikId, CijenaTrenutneKupovine, request.EventId);
                }
                catch(Exception ex)
                {

                }
                

                CijenaTrenutneKupovine = 0;
                return _mapper.Map<Model.Kupovina>(k); 
               
            }
        }
        private void  SetujKarte(int ZeljeniBrKarata, Database.KupovinaTip kupovinaTip, Database.ProdajaTip prodaja, int eventId, int korinsikId)
        {
            for (int i = 0; i < ZeljeniBrKarata; i++)
            {

                Database.Karta karta = new Database.Karta
                {
                    KupovinaTip = kupovinaTip, 
                    Cijena = prodaja.CijenaTip,
                    DatumKupovine = DateTime.Now,
                    TipKarteId = prodaja.TipKarteId
                };

                CijenaTrenutneKupovine += karta.Cijena;
                _ctx.Karta.Add(karta);
               

                prodaja.BrojProdatihKarataTip++;

                if (prodaja.PostojeSjedista == true)
                {
                    Sjediste s = new Sjediste
                    {
                        Karta = karta,
                        BrojSjedista = prodaja.BrojProdatihKarataTip
                    };
                    _ctx.Sjediste.Add(s);
                }

                _ctx.SaveChanges();
                GenerisiQRCode(karta, eventId, korinsikId);
            }
        }

        private void GenerisiQRCode(Database.Karta karta, int eventId, int korisnikId)
        {
            Database.Korisnik korisnik = _ctx.Korisnik.Find(korisnikId);

            Database.Event Event = _ctx.Event.Find(eventId);

            if (korisnik == null || Event == null || karta ==null)
                return;

            QRCodeGenerator qr = new QRCodeGenerator();
            string text = Event.Id.ToString() + " - " + Event.Naziv + " - Broj karte: " + karta.Id + " - KorsnikId: " + korisnik.Id;
            QRCodeData data = qr.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(data);

            Bitmap qrCodeImage = qRCode.GetGraphic(20);

            MemoryStream ms = new MemoryStream();

            qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            byte[] imageBytes = ms.ToArray();
            karta.QrCode = imageBytes;

        }

        public void PosaljiMail(int korisnikId, float cijena, int eventId)
        {
            Database.Korisnik korisnik = _ctx.Korisnik.Find(korisnikId);

            Database.Event Event = _ctx.Event.Find(eventId);

            if (korisnik == null || Event == null)
                return;

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Event Atteder", "event.attender@gmail.com"));

            message.To.Add(new MailboxAddress(korisnik.Ime, korisnik.Email));


            message.Subject = "Uspješna kupovina karte";

            message.Body = new TextPart("plain")
            {
                Text = "Poštovani/a " + korisnik.Ime + " " + korisnik.Prezime + " uspješno ste obavili kupovinu " +
                "karte/karata za event " + Event.Naziv + ", " + "u iznosu od " + cijena + " KM. Hvala na povjerenju! "
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);

                client.Authenticate("event.attender@gmail.com", "Event123at");

                client.Send(message);
                client.Disconnect(true);
            }
        }

    }
}
