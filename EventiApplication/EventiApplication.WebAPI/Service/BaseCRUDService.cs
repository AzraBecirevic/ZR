using AutoMapper;
using EventiApplication.Model.Request;
using EventiApplication.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventiApplication.WebAPI.Service
{
    public class BaseCRUDService<TModel, TSearch, TDatabase, TInsert, TUpdate, TPatch>
        : BaseService<TModel, TSearch, TDatabase>,
          ICRUDService<TModel, TSearch, TInsert, TUpdate, TPatch> where TDatabase: class
    {
        public BaseCRUDService(MojContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }

        public virtual TModel Autentificiraj(string username, string password)
        {
            throw new NotImplementedException(); 
        }

        public virtual TModel Delete(int id)
        {
            try
            {
                var entity = _ctx.Set<TDatabase>().Find(id);

                _ctx.Set<TDatabase>().Remove(entity);

                _ctx.SaveChanges();
                return _mapper.Map<TModel>(entity);  

            }
            catch
            {
                return default(TModel);
            }
        }

        public virtual TModel Insert(TInsert request)
        {

            var entity = _mapper.Map<TDatabase>(request);

            _ctx.Set<TDatabase>().Add(entity);
            _ctx.SaveChanges();

            return _mapper.Map<TModel>(entity);

        }

        public virtual bool IsLikean(TSearch request)
        {
            return false;
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            TDatabase entity = _ctx.Set<TDatabase>().Find(id);
            if(entity != null)
            {
                _ctx.Set<TDatabase>().Attach(entity);
                _ctx.Set<TDatabase>().Update(entity);

                _mapper.Map(request, entity);
              
                _ctx.SaveChanges();
            }
            return _mapper.Map<TModel>(entity);
        }
                                            
        public virtual TModel UpdateAttribute(TPatch request)  
        { 
            return default(TModel); 
        }

       
    }
}
