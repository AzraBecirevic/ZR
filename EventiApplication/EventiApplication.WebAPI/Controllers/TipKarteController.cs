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
    public class TipKarteController : BaseCRUDController<Model.TipKarte, object, Database.TipKarte, TipKarteInsertRequest, object, object>
    {
        public TipKarteController(ICRUDService<TipKarte, object, TipKarteInsertRequest, object, object> service) : base(service)
        {
        }
    }
}