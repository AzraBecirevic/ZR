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

    public class KartaController : BaseController<Model.Karta, KartaSearchRequest, Database.Karta>
    {
        public KartaController(IService<Karta, KartaSearchRequest> service) : base(service)
        {
        }
    }
}