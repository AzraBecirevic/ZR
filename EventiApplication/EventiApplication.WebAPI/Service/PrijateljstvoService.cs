using AutoMapper;
using EventiApplication.Model;
using EventiApplication.Model.Request;
using EventiApplication.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventiApplication.WebAPI.Service
{
    public class PrijateljstvoService :
        BaseCRUDService<Model.Prijateljstvo, PrijateljstvoSearchRequest, Database.Prijateljstvo, PrijateljstvoInsertRequest, PrijateljstvoInsertRequest, PrijateljstvoPatchRequest>
    {
        public PrijateljstvoService(MojContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }

        public override List<Model.Prijateljstvo> Get(PrijateljstvoSearchRequest search)
        {
            if (search != null)
            {
               
                if (search.KorisnikPosiljalacId != 0 && search.KorisnikPosiljalacId == search.KorisnikPrimalacId && search.IsPrihvaceno == true)
                {
                    // sva prijateljstva gdje je on posiljaoc ili primaoc koja su prihvacena
          

                    List<Database.Prijateljstvo> list = _ctx.Prijateljstvo.Include(p=>p.KorisnikPosiljalac).Include(p=>p.KorisnikPrimalac)
                      .Where(p => p.KorisnikPosiljalacId == search.KorisnikPosiljalacId || p.KorisnikPrimalacId == search.KorisnikPrimalacId)
                      .Where(p => p.IsPrihvaceno == true).ToList();


                    if (search.EventId != 0 && search.PozivalacId != 0)
                    {
                        List<Database.Prijateljstvo> pozvani = new List<Database.Prijateljstvo>();
                        foreach (var p in list)
                        {
                            if (_ctx.PozivNaEvent.Where(n => n.EventId == search.EventId && n.KorisnikPozivalacId == search.PozivalacId && (n.KorisnikPozvaniId == p.KorisnikPosiljalacId || n.KorisnikPozvaniId == p.KorisnikPrimalacId)).Any())
                            {
                                pozvani.Add(p); 
                            }
                        }
                        foreach (var p in pozvani)
                        {
                            list.Remove(p);
                        }
                    }

                    List<Model.Prijateljstvo> prijateljstva = new List<Model.Prijateljstvo>();
                    foreach(var p in list)
                    {
                        Model.Prijateljstvo prijateljstvo = new Model.Prijateljstvo
                        {
                            DatumSlanjaZahtjeva = p.DatumSlanjaZahtjeva.ToShortDateString(),
                            Id = p.Id,
                            KorisnikPosiljalacId = p.KorisnikPosiljalacId,
                            ImePrezimePosiljaoca = p.KorisnikPosiljalac.Ime + " " + p.KorisnikPosiljalac.Prezime,
                            KorisnikPrimalacId = p.KorisnikPrimalacId,
                            ImePrezimePrimaoca = p.KorisnikPrimalac.Ime + " " + p.KorisnikPrimalac.Prezime
                        };
                        prijateljstva.Add(prijateljstvo);
                    }
                   
                   
                    return prijateljstva;
                }
                else if(search.KorisnikPosiljalacId!=0 && search.IsPrihvaceno == false)
                {
                    var list = _ctx.Prijateljstvo.Where(p => p.KorisnikPosiljalacId == search.KorisnikPosiljalacId)
                       .Where(p => p.IsPrihvaceno == false);

                    List<Model.Prijateljstvo> prijateljstva = list.Select(p => new Model.Prijateljstvo
                    {
                        DatumSlanjaZahtjeva = p.DatumSlanjaZahtjeva.ToShortDateString(),
                        Id = p.Id,
                        KorisnikPosiljalacId = p.KorisnikPosiljalacId,
                        ImePrezimePosiljaoca = p.KorisnikPosiljalac.Ime + " " + p.KorisnikPosiljalac.Prezime,
                        KorisnikPrimalacId = p.KorisnikPrimalacId,
                        ImePrezimePrimaoca = p.KorisnikPrimalac.Ime + " " + p.KorisnikPrimalac.Prezime
                    }).ToList();
                    return prijateljstva;
                }

                else if(search.KorisnikPrimalacId!=0 && search.IsPrihvaceno == false)
                {
                    var list = _ctx.Prijateljstvo.Where(p => p.KorisnikPrimalacId == search.KorisnikPrimalacId)
                      .Where(p => p.IsPrihvaceno == false);

                    List<Model.Prijateljstvo> prijateljstva = list.Select(p => new Model.Prijateljstvo
                    {
                        DatumSlanjaZahtjeva = p.DatumSlanjaZahtjeva.ToShortDateString(),
                        Id = p.Id,
                        KorisnikPosiljalacId = p.KorisnikPosiljalacId,
                        ImePrezimePosiljaoca = p.KorisnikPosiljalac.Ime + " " + p.KorisnikPosiljalac.Prezime,
                        KorisnikPrimalacId = p.KorisnikPrimalacId,
                        ImePrezimePrimaoca = p.KorisnikPrimalac.Ime + " " + p.KorisnikPrimalac.Prezime
                    }).ToList();
                    return prijateljstva;
                }

            }
           
            return base.Get(search);
        }
                                                        
        public override Model.Prijateljstvo UpdateAttribute(PrijateljstvoPatchRequest request)
        {
            Database.Prijateljstvo prijateljstvo = _ctx.Prijateljstvo.Find(request.Id);

            if (prijateljstvo != null)
            {
                prijateljstvo.IsPrihvaceno = request.IsPrihvaceno;
                _ctx.SaveChanges();
                return _mapper.Map<Model.Prijateljstvo>(prijateljstvo);  
            }

            return null;
 
        }

        public override Model.Prijateljstvo Delete(int id)
        {
            Database.Prijateljstvo prijateljstvo = _ctx.Prijateljstvo.Find(id);
            if (prijateljstvo != null)
            {

                // medjusobni pozovi na evente
                var poziviPosiljaocaZahtjeva = _ctx.PozivNaEvent.Where(pe => pe.KorisnikPozivalacId == prijateljstvo.KorisnikPosiljalacId && pe.KorisnikPozvaniId == prijateljstvo.KorisnikPrimalacId);
                var poziviPrimaocaZahtjeva = _ctx.PozivNaEvent.Where(pe => pe.KorisnikPozivalacId == prijateljstvo.KorisnikPrimalacId && pe.KorisnikPozvaniId == prijateljstvo.KorisnikPosiljalacId);
               
                foreach(var p in poziviPosiljaocaZahtjeva)
                {
                    _ctx.PozivNaEvent.Remove(p);
                }
                foreach(var p in poziviPrimaocaZahtjeva)
                {
                    _ctx.PozivNaEvent.Remove(p);
                }
            
            }
            return base.Delete(id);
        }

    }
}
