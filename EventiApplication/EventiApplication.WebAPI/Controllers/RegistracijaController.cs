using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventiApplication.Model.Request;
using EventiApplication.WebAPI.Database;
using EventiApplication.WebAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventiApplication.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistracijaController : ControllerBase
    {

        ICRUDService<Model.Korisnik, KorisnikSearchRequest, KorisnikInsertRequest, KorisnikUpdateRequest, KorisnikPatchRequest> _service;
        private readonly MojContext _ctx;
        protected readonly IMapper _mapper;

        public RegistracijaController(ICRUDService<Model.Korisnik, KorisnikSearchRequest, KorisnikInsertRequest, KorisnikUpdateRequest, KorisnikPatchRequest> service, MojContext ctx, IMapper mapper)
        {
            _service = service;
            _ctx = ctx;
            _mapper = mapper;
        }

        [HttpPost]
        public Model.Korisnik Insert(KorisnikInsertRequest request)
        {
            return _service.Insert(request); 
        }
       [HttpGet]
       public List<Model.Grad> Get()
        {
            var gradovi = _ctx.Grad.ToList();
            return _mapper.Map<List<Model.Grad>>(gradovi);
        }
    }
}