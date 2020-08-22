using AutoMapper;
using EventiApplication.Model;
using EventiApplication.Model.Request;
using EventiApplication.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventiApplication.WebAPI.Service
{
    public class PozivNaEventService : BaseCRUDService<Model.PozivNaEvent, PozivNaEventSearchRequest, Database.PozivNaEvent, PozivNaEventInsertRequest, object, PozivNaEventPatchRequest>
    {
        public PozivNaEventService(MojContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }

        public override List<Model.PozivNaEvent> Get(PozivNaEventSearchRequest search)
        {
            var query = _ctx.PozivNaEvent.AsQueryable();
            if (search.PoslaniPozivi)
            {
                query = query.Where(p => p.KorisnikPozivalacId == search.KorisnikPozivalacId);
            }
            if (search.DobijeniPozivi)
            {
                query = query.Where(p => p.KorisnikPozvaniId == search.KorisnikPozvaniId);
            }
            if (search.NoviPozivi)
            {
                query = query.Where(p => p.Event.DatumOdrzavanja.CompareTo(DateTime.Now.AddDays(-1)) == 1);  
            }
            if (search.StariPozivi)
            {
                query = query.Where(p => p.Event.DatumOdrzavanja.CompareTo(DateTime.Now.AddDays(-1)) == -1);
            }
            if (search.OdbijeniPozivi)
            {
                query = query.Where(p => p.IsOdbijen == true);
            }
            if (search.PrihvaceniPozivi)
            {
                query = query.Where(p => p.IsPrihvacen == true);
            }
            if (search.NeodgovoreniPozivi)
            {
                query = query.Where(p => p.IsPrihvacen == false && p.IsOdbijen == false);
            }
            List<Model.PozivNaEvent> list = query.Select(p => new Model.PozivNaEvent
            {
                NazivEventa = p.Event.Naziv,
                EventId = p.EventId,
                IsOdbijen = p.IsOdbijen,
                IsPrihvacen = p.IsPrihvacen,
                IsNeodgovoren =(p.IsOdbijen==false && p.IsPrihvacen==false)?true:false,
                Id = p.Id,
                DatumEventa = p.Event.DatumOdrzavanja.ToShortDateString(),
                KorisnikPozivalacId = p.KorisnikPozivalacId,
                KorisnikPozivalacImePrezime = p.KorisnikPozivalac.Ime + " " + p.KorisnikPozivalac.Prezime,
                KorisnikPozvaniId = p.KorisnikPozvaniId,
                KorisnikPozvaniImePrezime = p.KorisnikPozvani.Ime + " " + p.KorisnikPozvani.Prezime
            }).ToList();

            return list;
        }
                                                       
        public override Model.PozivNaEvent UpdateAttribute( PozivNaEventPatchRequest request)
        {
            Database.PozivNaEvent poziv = _ctx.PozivNaEvent.Find(request.Id);
            if (poziv != null)
            {
                if (request.IsPrihvacen)
                {
                    poziv.IsPrihvacen = true;
                    poziv.IsOdbijen = false;
                }
                if(request.IsOdbijen)
                {
                    poziv.IsPrihvacen = false;
                    poziv.IsOdbijen = true;
                }
                _ctx.SaveChanges();

                return _mapper.Map<Model.PozivNaEvent>(poziv);

            }

            return null;
           
        }
    }

}
