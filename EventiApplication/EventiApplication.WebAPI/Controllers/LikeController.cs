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
   
    public class LikeController : BaseCRUDController<Model.Like, LikeSearchRequest, Database.Like, LikeInsertRequest, object, object> //ControllerBase
    {
        public LikeController(ICRUDService<Like, LikeSearchRequest, LikeInsertRequest, object, object> service) : base(service)
        { 
        }

        
    }
}