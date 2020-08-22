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
  
    public class PrijateljstvoController :
        BaseCRUDController<Model.Prijateljstvo, PrijateljstvoSearchRequest, Database.Prijateljstvo, PrijateljstvoInsertRequest, PrijateljstvoInsertRequest, PrijateljstvoPatchRequest> //ControllerBase
    {
        public PrijateljstvoController(ICRUDService<Prijateljstvo, PrijateljstvoSearchRequest, PrijateljstvoInsertRequest, PrijateljstvoInsertRequest, PrijateljstvoPatchRequest> service) : base(service)
        {
        }
    }
}