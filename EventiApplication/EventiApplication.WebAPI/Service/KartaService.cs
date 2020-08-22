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
    public class KartaService : BaseService<Model.Karta, KartaSearchRequest, Database.Karta>
    {
        public KartaService(MojContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }
       
        public override List<Model.Karta> Get(KartaSearchRequest search)
         {
             if (search != null && search.KupovinaId!=0)
             {
                 List<Model.Karta> list = _ctx.Karta.Where(k => k.KupovinaTip.KupovinaId == search.KupovinaId)
                     .Select(k => new Model.Karta
                     {
                         Cijena = k.Cijena,
                         DatumKupovine = k.DatumKupovine.ToShortDateString(),
                         TipKarteNaziv = k.TipKarte.Naziv,
                         QrCode = k.QrCode
                     }).ToList();

                return list;
             }
             return null; 
         }
    }
}
