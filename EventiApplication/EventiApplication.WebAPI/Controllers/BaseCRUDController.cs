using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventiApplication.Model.Request;
using EventiApplication.WebAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventiApplication.WebAPI.Controllers
{
   
    public class BaseCRUDController<TModel, TSearch, TDatabase, TInsert, TUpdate, TPatch>
        : BaseController<TModel, TSearch, TDatabase> where TDatabase : class
    {
        
        ICRUDService<TModel, TSearch, TInsert, TUpdate, TPatch> _service;    
        public BaseCRUDController(ICRUDService<TModel, TSearch, TInsert, TUpdate, TPatch> service) : base(service)
        {
            _service = service;
        }

        [HttpPost]
        public virtual TModel Insert(TInsert request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]    //?
        public virtual TModel Update(int id, TUpdate request)
        {
            return _service.Update(id, request);
        }

        [HttpDelete("{id}")]
        public virtual TModel Delete(int id)
        {
            return _service.Delete(id);
        }
        [HttpPatch]                      
        public virtual TModel UpdateAttribute( TPatch request)  //string //[FromBody] string
        {                                  
            return _service.UpdateAttribute( request);
        }
    }
}