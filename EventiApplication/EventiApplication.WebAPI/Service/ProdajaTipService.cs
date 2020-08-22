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
    public class ProdajaTipService :
        BaseCRUDService<Model.ProdajaTip, ProdajaTipSearchRequest, Database.ProdajaTip, ProdajaTipInsertRequest, ProdajaTipInsertRequest, object>
    {
        public ProdajaTipService(MojContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }

        public override List<Model.ProdajaTip> Get(ProdajaTipSearchRequest search)
        {
            if (search!=null && search.EventId != 0)   
            {
                var query = _ctx.ProdajaTip.AsQueryable();

                query = query.Where(p => p.EventId == search.EventId);

                if (!string.IsNullOrWhiteSpace(search.TipKarteNaziv))
                {
                    query = query.Where(p => p.TipKarte.Naziv.ToLower().StartsWith(search.TipKarteNaziv.ToLower()));
                }
                if (search.IsProdajaVecaOd0)
                {
                    query = query.Where(p => p.BrojProdatihKarataTip > 0);
                }
                List<Model.ProdajaTip> list = 
                    query
                    .Select(p => new Model.ProdajaTip
                    {
                        Id = p.Id,
                        TipKarteId = p.TipKarteId,
                        EventId = p.EventId,
                        TipKarteNaziv = p.TipKarte.Naziv,
                        BrojProdatihKarataTip = p.BrojProdatihKarataTip,
                        CijenaTip = p.CijenaTip,
                        PostojeSjedista = p.PostojeSjedista,
                        UkupnoKarataTip = p.UkupnoKarataTip,
                        EventNaziv = p.Event.Naziv
                    }).ToList();

                return list;
            }
            var empty = new List<Model.ProdajaTip>();
            return empty;
        }

        public override Model.ProdajaTip Delete(int id)
        {
            Database.ProdajaTip prodajaTip = _ctx.ProdajaTip.Find(id);

            if (prodajaTip.BrojProdatihKarataTip == 0)
            {
                _ctx.ProdajaTip.Remove(prodajaTip);
                _ctx.SaveChanges();

                return _mapper.Map<Model.ProdajaTip>(prodajaTip);
            }
            else
            {
                return null;
            }
        }
    }
}
