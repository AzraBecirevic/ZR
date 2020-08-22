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
    public class LikeService : BaseCRUDService<Model.Like, LikeSearchRequest, Database.Like, LikeInsertRequest, object, object>
    {
        public LikeService(MojContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }
        public override List<Model.Like> Get(LikeSearchRequest search)
        {
            if (search != null)
            {
                var query = _ctx.Like.AsQueryable();

                if (search.EventId != 0)
                {
                    query = query.Where(l => l.EventId == search.EventId);
                }
                if (search.KorisnikId != 0)
                {
                    query = query.Where(l => l.KorisnikId == search.KorisnikId);
                }
                var list = query.ToList();

                return _mapper.Map<List<Model.Like>>(list);
            }
            return null;
        }
        public override Model.Like Insert(LikeInsertRequest request)
        {
            if (_ctx.Like.Where(l => l.KorisnikId == request.KorisnikId && l.EventId == request.EventId).Any())
                return null;
            var entity = _mapper.Map<Database.Like>(request);

            _ctx.Like.Add(entity);
            _ctx.SaveChanges();

            return _mapper.Map<Model.Like>(entity);
           
        }
    }
}
