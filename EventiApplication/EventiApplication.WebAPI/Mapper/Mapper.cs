using AutoMapper;
using EventiApplication.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventiApplication.WebAPI.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            
            CreateMap<Database.Event, Model.Event>();
            CreateMap<Database.Kategorija, Model.Kategorija>();
            CreateMap<EventInsertRequest, Database.Event>();

            CreateMap<Database.Grad, Model.Grad>();

            CreateMap<Database.TipProstoraOdrzavanja, Model.TipProstoraOdrzavanja>();
            
            CreateMap<Database.ProstorOdrzavanja, Model.ProstorOdrzavanja>();
            CreateMap<ProstorOdrzavanjaInsertRequest, Database.ProstorOdrzavanja>();

            CreateMap<Database.TipKarte, Model.TipKarte>();
            CreateMap<TipKarteInsertRequest, Database.TipKarte>();



            CreateMap<Database.ProdajaTip, Model.ProdajaTip>();
            CreateMap<ProdajaTipInsertRequest,Database.ProdajaTip>();

            CreateMap<Database.Organizator, Model.Organizator>();
            CreateMap<OrganizatorInsertRequest, Database.Organizator>();

            CreateMap<Database.Korisnik, Model.Korisnik>();
            CreateMap<KorisnikInsertRequest,Database.Korisnik>();

            CreateMap<Database.Administrator, Model.Administrator>();
            CreateMap<AdministratorInsertRequest,Database.Administrator>();

            CreateMap<Database.Kupovina, Model.Kupovina>();   //?

            CreateMap<Database.Like, Model.Like>();
            CreateMap<LikeInsertRequest, Database.Like>();

            CreateMap<Database.Ocjena, Model.Ocjena>();
            CreateMap<OcjenaInsertRequest, Database.Ocjena>();

            CreateMap<Database.Prijateljstvo, Model.Prijateljstvo>();
            CreateMap<PrijateljstvoInsertRequest, Database.Prijateljstvo>();

            CreateMap<Database.PozivNaEvent, Model.PozivNaEvent>();
            CreateMap<PozivNaEventInsertRequest, Database.PozivNaEvent>();

            CreateMap<Database.Recenzija, Model.Recenzija>();
            CreateMap<RecenzijaInsertRequest, Database.Recenzija>();

            CreateMap<Database.Karta, Model.Karta>();

        }
    }
}
