using AutoMapper;
using EventiApplication.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventiApplication.WebAPI.Service
{
    public class BaseService<TModel, TSearch, TDatabase> : IService<TModel, TSearch> where TDatabase: class
    {
        protected readonly MojContext _ctx;
        protected readonly IMapper _mapper;


        public BaseService(MojContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public virtual List<TModel> Get(TSearch search)
        {
            var list = _ctx.Set<TDatabase>().ToList();
            return _mapper.Map<List<TModel>>(list);
        }

        public virtual TModel GetById(int id)
        {
            var entity = _ctx.Set<TDatabase>().Find(id);
            return _mapper.Map<TModel>(entity);
        }
    }
}
