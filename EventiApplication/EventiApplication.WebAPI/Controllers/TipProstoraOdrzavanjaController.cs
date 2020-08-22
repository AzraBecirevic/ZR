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
    public class TipProstoraOdrzavanjaController : BaseController<Model.TipProstoraOdrzavanja, object, Database.TipProstoraOdrzavanja>
    {
        public TipProstoraOdrzavanjaController(IService<Model.TipProstoraOdrzavanja, object> service) : base(service)
        {
        }
    }
}