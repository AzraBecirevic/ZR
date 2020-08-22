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
    public class KorisnikController :
        BaseCRUDController<Model.Korisnik, KorisnikSearchRequest, Database.Korisnik, KorisnikInsertRequest, KorisnikUpdateRequest, KorisnikPatchRequest>
    {
        public KorisnikController(ICRUDService<Korisnik, KorisnikSearchRequest, KorisnikInsertRequest, KorisnikUpdateRequest, KorisnikPatchRequest> service) : base(service)
        {
        }
    }
}