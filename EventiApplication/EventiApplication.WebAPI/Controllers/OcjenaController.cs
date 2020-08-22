using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventiApplication.Model;
using EventiApplication.Model.Request;
using EventiApplication.WebAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventiApplication.WebAPI.Controllers
{
    public class OcjenaController : BaseCRUDController<Model.Ocjena, OcjenaSearchRequest, Database.Ocjena, OcjenaInsertRequest, OcjenaInsertRequest, object> //ControllerBase
    {
        public OcjenaController(ICRUDService<Ocjena, OcjenaSearchRequest, OcjenaInsertRequest, OcjenaInsertRequest, object> service) : base(service)
        {
        }
    }
}