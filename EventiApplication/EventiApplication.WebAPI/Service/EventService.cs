using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EventiApplication.Model;
using EventiApplication.Model.Request;
using EventiApplication.WebAPI.Database;
using EventiApplication.WebAPI.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace EventiApplication.WebAPI.Service
{                           
    public class EventService: BaseCRUDService<Model.Event, EventSearchRequest, Database.Event, EventInsertRequest, EventInsertRequest, object>
    {
        public EventService(MojContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }
  
        public override List<Model.Event> Get(EventSearchRequest search)
        {
            if (search != null)
            {
                var query = _ctx.Event.Include(e=>e.ProstorOdrzavanja).AsQueryable();

                if (search.IsOtkazan)
                    query = query.Where(e => e.IsOtkazan == true);
                if (search.IsOdobren)
                    query = query.Where(e => e.IsOdobren == true);
                if (search.Predstojeci)
                {
                    query = query.Where(e => e.IsOdobren == true && e.DatumOdrzavanja.CompareTo(DateTime.Now.AddDays(-1)) == 1 && e.IsOtkazan==false);
                }
               if (!string.IsNullOrWhiteSpace(search.PretragaNazivLokacija))
               {
                    query = query.Where(e => e.Naziv.ToLower().StartsWith(search.PretragaNazivLokacija.ToLower()) || e.ProstorOdrzavanja.Grad.Naziv.ToLower().StartsWith(search.PretragaNazivLokacija.ToLower()));
               }
                // gdje je datum odrzavanja veci od jucerasnjeg

                if (search.KategorijaId!=null && search.KategorijaId != 0)
                {
                    query = query.Where(e => e.KategorijaId == search.KategorijaId);
                }

                if (!string.IsNullOrWhiteSpace(search.Naziv))
                {
                    query = query.Where(e => e.Naziv.StartsWith(search.Naziv));
                }
                if (search.GradId!=0)
                {
                    query = query.Where(e => e.ProstorOdrzavanja.GradId == search.GradId);
                }
                if (search.OrganizatorId != 0)   
                {
                    query = query.Where(e => e.OrganizatorId == search.OrganizatorId);
                }
                if (search.IsGps)
                {
                    //?
                    query = query.Where(e=>e.DatumOdrzavanja.Date.CompareTo(search.TrenutniDatum.Date)==0);
                    // e => e.DatumOdrzavanja.CompareTo(search.TrenutniDatum) == 0
                    //? ili dan-dan, mjesec-mjesec zbog timespana
                    query = query.Where(e => e.DatumOdrzavanja.TimeOfDay > search.TrenutnoVrijeme);
                }
                var list = query.Select(e => new Model.Event
                {
                    AdministratorId = e.AdministratorId,
                    DatumOdrzavanja = e.DatumOdrzavanja,
                    Id = e.Id,
                    IsOdobren = e.IsOdobren,
                    IsOtkazan = e.IsOtkazan,
                    KategorijaId = e.KategorijaId ?? 0,
                    KategorijaNaziv = e.Kategorija.Naziv,
                    Naziv = e.Naziv,
                    Opis = e.Opis,
                    OrganizatorId = e.OrganizatorId,
                    ProstorOdrzavanjaGradAdresa = e.ProstorOdrzavanja.Naziv + " - " + e.ProstorOdrzavanja.Grad.Naziv + " - " + e.ProstorOdrzavanja.Adresa,
                    ProstorOdrzavanjaId = e.ProstorOdrzavanjaId,
                    Slika = e.Slika,
                    SlikaThumb = e.SlikaThumb,
                    VrijemeOdrzavanja = e.VrijemeOdrzavanja,
                    Adresa = e.ProstorOdrzavanja.Adresa,
                    Grad = e.ProstorOdrzavanja.Grad.Naziv,
                    DatumOdrz = e.DatumOdrzavanja.ToShortDateString(),
                }).OrderBy(x => x.DatumOdrzavanja).ToList();   
                if (search.IsPreporuka)
                {
                   
                    var preporuceniEventi = GetSlicneEvente(search.EventId);
                    return _mapper.Map<List<Model.Event>>(preporuceniEventi);
                }

                return list;
              
            }
            return base.Get(search);  

        }

        public override Model.Event GetById(int id)
        {
            
            Database.Event e = _ctx.Event.Include(x=>x.Kategorija).Include(x=>x.ProstorOdrzavanja)
                .Include(x=>x.ProstorOdrzavanja.Grad)
                .Where(x=>x.Id==id).FirstOrDefault();

            if (e != null)
            {
                Model.Event ev = new Model.Event
                {
                    AdministratorId = e.AdministratorId,
                    DatumOdrzavanja = e.DatumOdrzavanja,
                    Id = e.Id,
                    IsOdobren = e.IsOdobren,
                    IsOtkazan = e.IsOtkazan,
                    KategorijaId = e.KategorijaId ?? 0,
                    KategorijaNaziv = e.Kategorija.Naziv,
                    Naziv = e.Naziv,
                    Opis = e.Opis,
                    OrganizatorId = e.OrganizatorId,
                    ProstorOdrzavanjaGradAdresa = e.ProstorOdrzavanja.Naziv + " - " + e.ProstorOdrzavanja.Grad.Naziv + " - " + e.ProstorOdrzavanja.Adresa,
                    ProstorOdrzavanjaId = e.ProstorOdrzavanjaId,
                    Slika = e.Slika,
                    SlikaThumb = e.SlikaThumb,
                    VrijemeOdrzavanja = e.VrijemeOdrzavanja,
                    Adresa = e.ProstorOdrzavanja.Adresa,
                    Grad = e.ProstorOdrzavanja.Grad.Naziv
                };
                return ev;
            }
            return null;
        }

        public override Model.Event Delete(int id)
        {                                                                                  // ili any
            if (_ctx.ProdajaTip.Where(e => e.EventId == id && e.BrojProdatihKarataTip > 0).Count() > 0)
                 return null; 
            else
            {
                var entity = _ctx.Event.Find(id);
                _ctx.Event.Remove(entity);
                _ctx.SaveChanges();
                return _mapper.Map<Model.Event>(entity);
            }
        }

        //---------------------------------
         Dictionary<int, List<Database.Ocjena>> Eventi = new Dictionary<int, List<Database.Ocjena>>();
       

        public List<Database.Event> GetSlicneEvente(int eventId)
        {
            UcitajEvente(eventId);
            List<Database.Ocjena> ocjeneTrenutnogEventa = _ctx.Ocjena.Where(e => e.EventId == eventId).OrderBy(e => e.KorisnikId).ToList();

            List<Database.Ocjena> zajednickeOcjene1 = new List<Database.Ocjena>();
            List<Database.Ocjena> zajednickeOcjene2 = new List<Database.Ocjena>();

            List<Database.Event> preporuceniEventi = new List<Database.Event>();


            foreach (var e in Eventi)
            {
                foreach (Database.Ocjena o in ocjeneTrenutnogEventa)
                {
                    if (e.Value.Where(k => k.KorisnikId == o.KorisnikId).Count() > 0)
                    {
                        zajednickeOcjene1.Add(o);
                        zajednickeOcjene2.Add(e.Value.Where(k => k.KorisnikId == o.KorisnikId).FirstOrDefault());
                    }
                }

                double slicnost = GetSlicnost(zajednickeOcjene1, zajednickeOcjene2);
                if (slicnost > 0.7)
                    preporuceniEventi.Add(_ctx.Event.Where(m => m.Id == e.Key).FirstOrDefault());

                zajednickeOcjene1.Clear();
                zajednickeOcjene2.Clear();
            }

            return preporuceniEventi.Take(2).ToList();
        }

        private double GetSlicnost(List<Database.Ocjena> zajednickeOcjene1, List<Database.Ocjena> zajednickeOcjene2)
        {
            if (zajednickeOcjene1.Count != zajednickeOcjene2.Count)
            {
                return 0;
            }

            double brojnik = 0, nazivnik1 = 0, nazivnik2 = 0;

            for (int i = 0; i < zajednickeOcjene1.Count; i++)
            {
                brojnik += zajednickeOcjene1[i].OcjenaEventa * zajednickeOcjene2[i].OcjenaEventa;  
                nazivnik1 += zajednickeOcjene1[i].OcjenaEventa * zajednickeOcjene1[i].OcjenaEventa;  
                nazivnik2 += zajednickeOcjene2[i].OcjenaEventa * zajednickeOcjene2[i].OcjenaEventa; 
            }
            nazivnik1 = Math.Sqrt(nazivnik1);
            nazivnik2 = Math.Sqrt(nazivnik2);

            double nazivnik = nazivnik1 * nazivnik2;

            if (nazivnik == 0)
                return nazivnik;

            return brojnik / nazivnik;
        }

        private void UcitajEvente(int eventId)
        {
            List<Database.Event> aktivniEventi = _ctx.Event.Where(e => e.Id != eventId)
                .Where(e => e.IsOdobren == true && e.DatumOdrzavanja.CompareTo(DateTime.Now.AddDays(-1)) == 1 && e.IsOtkazan == false).ToList();

            List<Database.Ocjena> ocjene;

            foreach (var e in aktivniEventi)
            {
                ocjene = _ctx.Ocjena.Where(o => o.EventId == e.Id).OrderBy(o => o.KorisnikId).ToList();
                if (ocjene.Count() > 0)
                    Eventi.Add(e.Id, ocjene);
            }
        }

        //...........................

       /* public override Model.Event Insert(EventInsertRequest request)
        {
            var niz = request.VrijemeOdrzavanja.Split(":");
            DateTime datum = request.DatumOdrzavanja;
            int sati = int.Parse(niz[0]);
            int minute = int.Parse(niz[1]);
            request.DatumOdrzavanja = new DateTime(datum.Year, datum.Month, datum.Day, sati, minute, 0);
            return base.Insert(request);
        }*/
    }
}
