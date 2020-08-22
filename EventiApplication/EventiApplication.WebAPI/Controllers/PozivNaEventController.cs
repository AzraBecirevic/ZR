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
   
    public class PozivNaEventController : BaseCRUDController<Model.PozivNaEvent, PozivNaEventSearchRequest, Database.PozivNaEvent, PozivNaEventInsertRequest, object, PozivNaEventPatchRequest> //ControllerBase
    {
        public PozivNaEventController(ICRUDService<PozivNaEvent, PozivNaEventSearchRequest, PozivNaEventInsertRequest, object, PozivNaEventPatchRequest> service) : base(service)
        {
        }
    }
}