using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventiApplication.Model;
using EventiApplication.WebAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventiApplication.WebAPI.Controllers
{
    public class GradController : BaseController<Model.Grad, object, Database.Grad>
    {
        public GradController(IService<Grad, object> service) : base(service)
        {
        }
    }
}