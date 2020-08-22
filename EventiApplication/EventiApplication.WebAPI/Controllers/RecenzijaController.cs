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
  
    public class RecenzijaController : BaseCRUDController<Model.Recenzija, RecenzijaSearchRequest, Database.Recenzija, RecenzijaInsertRequest, RecenzijaInsertRequest, object> // ControllerBase
    {
        public RecenzijaController(ICRUDService<Recenzija, RecenzijaSearchRequest, RecenzijaInsertRequest, RecenzijaInsertRequest, object> service) : base(service)
        {
        }
    }
}