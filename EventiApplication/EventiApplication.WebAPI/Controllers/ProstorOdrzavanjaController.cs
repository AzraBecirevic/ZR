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
    public class ProstorOdrzavanjaController
        : BaseCRUDController<Model.ProstorOdrzavanja, ProstorOdrzavanjaSearchRequest, Database.ProstorOdrzavanja, ProstorOdrzavanjaInsertRequest, ProstorOdrzavanjaInsertRequest, object>
    {
        public ProstorOdrzavanjaController(ICRUDService<ProstorOdrzavanja, ProstorOdrzavanjaSearchRequest, ProstorOdrzavanjaInsertRequest, ProstorOdrzavanjaInsertRequest, object> service) : base(service)
        {
        }

        [HttpPost] 
        [Authorize(Roles = "Administrator")]
        public override ProstorOdrzavanja Insert(ProstorOdrzavanjaInsertRequest request)
        {
            return base.Insert(request);
        }

        [HttpPut("{id}")] 
        [Authorize(Roles = "Administrator")]
        public override ProstorOdrzavanja Update(int id, ProstorOdrzavanjaInsertRequest request)
        {
            return base.Update(id, request);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public override ProstorOdrzavanja Delete(int id)
        {
            return base.Delete(id);
        }
       
    }
}