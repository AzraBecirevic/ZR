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
    public class RecenzijaService : BaseCRUDService<Model.Recenzija, RecenzijaSearchRequest, Database.Recenzija, RecenzijaInsertRequest, RecenzijaInsertRequest, object>
    {
        public RecenzijaService(MojContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }

        public override List<Model.Recenzija> Get(RecenzijaSearchRequest search)
        {
            if (search != null && search.KupovinaId!=0)
            {
                var list = _ctx.Recenzija.Where(r => r.KupovinaId == search.KupovinaId).ToList();
                return _mapper.Map<List<Model.Recenzija>>(list);
            }
            return null;
       
        }
    }
}
