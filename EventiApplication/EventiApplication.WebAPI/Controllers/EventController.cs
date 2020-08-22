using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventiApplication.Model;
using EventiApplication.Model.Request;
using EventiApplication.WebAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventiApplication.WebAPI.Controllers
{
    
    public class EventController : BaseCRUDController<Model.Event, EventSearchRequest, Database.Event, EventInsertRequest, EventInsertRequest, object>
    {
        
        public EventController(ICRUDService<Event, EventSearchRequest, EventInsertRequest, EventInsertRequest, object> service) : base(service)
        {
        }


        [HttpPost] 
        [Authorize(Roles = "Administrator")]
        public override Event Insert(EventInsertRequest request)
        {
            return base.Insert(request);
        }
        [HttpPut("{id}")] 
        [Authorize(Roles = "Administrator")]
        public override Event Update(int id, EventInsertRequest request)
        {
            return base.Update(id, request);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public override Event Delete(int id)
        {
            return base.Delete(id);
        }

       

    }
}