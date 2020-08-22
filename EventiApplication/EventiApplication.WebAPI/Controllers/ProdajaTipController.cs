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
    public class ProdajaTipController : BaseCRUDController<Model.ProdajaTip, ProdajaTipSearchRequest, Database.ProdajaTip, ProdajaTipInsertRequest, ProdajaTipInsertRequest, object>
    {
        public ProdajaTipController(ICRUDService<ProdajaTip, ProdajaTipSearchRequest, ProdajaTipInsertRequest, ProdajaTipInsertRequest, object> service) : base(service)
        {
        }

        [HttpPost] 
        [Authorize(Roles = "Administrator")]
        public override ProdajaTip Insert(ProdajaTipInsertRequest request)
        {
            return base.Insert(request);
        }
        [HttpPut("{id}")] 
        [Authorize(Roles = "Administrator")]
        public override ProdajaTip Update(int id, ProdajaTipInsertRequest request)
        {
            return base.Update(id, request);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public override ProdajaTip Delete(int id)
        {
            return base.Delete(id);
        }
    }
}