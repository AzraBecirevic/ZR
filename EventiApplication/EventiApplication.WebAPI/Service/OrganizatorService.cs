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
    public class OrganizatorService :
        BaseCRUDService<Model.Organizator, OrganizatorSearchRequest, Database.Organizator, OrganizatorInsertRequest, OrganizatorInsertRequest, object>
    {
        public OrganizatorService(MojContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }

        public override List<Model.Organizator> Get(OrganizatorSearchRequest search)
        {
            if (search != null)
            {
               
                if (!string.IsNullOrWhiteSpace(search.Naziv))
                {
                    var list = _ctx.Organizator.Where(o => o.Naziv.StartsWith(search.Naziv)).ToList();
                    return _mapper.Map<List<Model.Organizator>>(list);
                }
            }
            return base.Get(search);
        }

        public override Model.Organizator Delete(int id)
        {
            if (_ctx.Event.Where(e => e.OrganizatorId == id).Any())
                return null;    

            var entity = _ctx.Organizator.Find(id);
            _ctx.Organizator.Remove(entity);
            _ctx.SaveChanges();
            return _mapper.Map<Model.Organizator>(entity);
        }
    }
}
