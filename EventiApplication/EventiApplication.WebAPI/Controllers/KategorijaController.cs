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
  
    public class KategorijaController : BaseController<Model.Kategorija, object, Database.Kategorija>  
    {
        public KategorijaController(IService<Model.Kategorija, object> service) : base(service)
        {
        }
    }
}