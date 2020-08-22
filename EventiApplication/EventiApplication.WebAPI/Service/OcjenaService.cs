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
    public class OcjenaService : BaseCRUDService<Model.Ocjena, OcjenaSearchRequest, Database.Ocjena, OcjenaInsertRequest, OcjenaInsertRequest, object>
    {
        public OcjenaService(MojContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }

        public override List<Model.Ocjena> Get(OcjenaSearchRequest search)
        {
            if (search != null)
            {
                var query = _ctx.Ocjena.AsQueryable();

                if (search.EventId != 0)
                {
                    query = query.Where(o => o.EventId == search.EventId);
                }
                if (search.KorisnikId != 0)
                {
                    query = query.Where(o => o.KorisnikId == search.KorisnikId);
                }

                var list = query.ToList();
                return _mapper.Map<List<Model.Ocjena>>(list);
            }

            return null;
         
        }

       
    }
}
