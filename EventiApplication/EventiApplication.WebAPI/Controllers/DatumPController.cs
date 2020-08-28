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

    public class DatumPController : BaseController<Model.DatumP, DatumPSearchRequest, Database.Event>
    {
        public DatumPController(IService<DatumP, DatumPSearchRequest> service) : base(service)
        {
        }
    }
}