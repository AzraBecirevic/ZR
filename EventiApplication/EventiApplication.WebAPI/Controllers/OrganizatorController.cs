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
    public class OrganizatorController : BaseCRUDController<Model.Organizator, OrganizatorSearchRequest, Database.Organizator, OrganizatorInsertRequest, OrganizatorInsertRequest, object>
    {
        public OrganizatorController(ICRUDService<Organizator, OrganizatorSearchRequest, OrganizatorInsertRequest, OrganizatorInsertRequest, object> service) : base(service)
        {
        }

        [HttpPost] 
        [Authorize(Roles = "Administrator")]
        public override Organizator Insert(OrganizatorInsertRequest request)
        {
            return base.Insert(request);
        }

        [HttpPut("{id}")] 
        [Authorize(Roles = "Administrator")]
        public override Organizator Update(int id, OrganizatorInsertRequest request)
        {
            return base.Update(id, request);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public override Organizator Delete(int id)
        {
            return base.Delete(id);
        }
    }
}