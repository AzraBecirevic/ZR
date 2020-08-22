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
    public class ProstorOdrzavanjaService
        : BaseCRUDService<Model.ProstorOdrzavanja, ProstorOdrzavanjaSearchRequest, Database.ProstorOdrzavanja, ProstorOdrzavanjaInsertRequest, ProstorOdrzavanjaInsertRequest, object>
    {
        public ProstorOdrzavanjaService(MojContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }

        public override List<Model.ProstorOdrzavanja> Get(ProstorOdrzavanjaSearchRequest search)
        {
            var query = _ctx.ProstorOdrzavanja.Include(p => p.TipProstoraOdrzavanja).Include(p => p.Grad).AsQueryable();
            if(search!=null && !string.IsNullOrWhiteSpace(search.Naziv))
            {
                query = query.Where(p => p.Naziv.ToLower().StartsWith(search.Naziv.ToLower()));
            }
            var list = query.ToList( );

            return _mapper.Map<List<Model.ProstorOdrzavanja>>(list);
          
        }

        public override Model.ProstorOdrzavanja Delete(int id)
        {
            if (_ctx.Event.Where(e => e.ProstorOdrzavanjaId == id).Count() > 0)
                return null;

            var entity = _ctx.ProstorOdrzavanja.Find(id);
            if (entity != null)
            {
                _ctx.ProstorOdrzavanja.Remove(entity);
                _ctx.SaveChanges();
                return _mapper.Map<Model.ProstorOdrzavanja>(entity);
            }

            return null;
        }
    }
}
