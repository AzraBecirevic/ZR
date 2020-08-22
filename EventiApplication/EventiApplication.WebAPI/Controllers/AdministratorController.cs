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
 
    public class AdministratorController : BaseCRUDController<Model.Administrator, AdministratorSearchRequest, Database.Administrator, AdministratorInsertRequest, AdministratorUpdateRequest, object>
    {
        public AdministratorController(ICRUDService<Administrator, AdministratorSearchRequest, AdministratorInsertRequest, AdministratorUpdateRequest, object> service) : base(service)
        {
        }

        [HttpGet] 
        [Authorize(Roles = "Administrator")]
        public override List<Administrator> Get([FromQuery] AdministratorSearchRequest search)
        {
            return base.Get(search);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator")]
        public override Administrator GetById(int id)
        {
            return base.GetById(id);
        }

        [HttpPost] 
        [Authorize(Roles = "Administrator")]
        public override Administrator Insert(AdministratorInsertRequest request)
        {
            return base.Insert(request);
        }

        [HttpPut("{id}")] 
        [Authorize(Roles = "Administrator")]
        public override Administrator Update(int id, AdministratorUpdateRequest request)
        {
            return base.Update(id, request);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public override Administrator Delete(int id)
        {
            return base.Delete(id);
        }
    }
}