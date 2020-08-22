using AutoMapper;
using EventiApplication.Model;
using EventiApplication.Model.Request;
using EventiApplication.WebAPI.Database;
using EventiApplication.WebAPI.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EventiApplication.WebAPI.Service
{
    public class KorisnikService : BaseCRUDService<Model.Korisnik, KorisnikSearchRequest, Database.Korisnik, KorisnikInsertRequest, KorisnikUpdateRequest, KorisnikPatchRequest>
    {
        public KorisnikService(MojContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }

        public override List<Model.Korisnik> Get(KorisnikSearchRequest search)
        {
            if(search != null)
            {
                var query = _ctx.Korisnik.Include(k=>k.Grad).AsQueryable();

                if (!string.IsNullOrWhiteSpace(search.Username))
                {
                    query = query.Where(k => k.Username.Equals(search.Username));
                    var lista = query.ToList();
                    return _mapper.Map<List<Model.Korisnik>>(lista);
                }
                if (search.IsUserSearch)
                {                                     
                    query = query.Where(k => (k.Ime +" " +k.Prezime).ToLower().StartsWith(search.Ime.ToLower()) );
                    query = query.Where(k => k.Id != search.IdKorisnikaPretrazitelja);
                    
                    var lista = query.ToList();

                    var prijatelji = new List<Database.Korisnik>();

                    foreach (var k in lista)
                    {
                        if (_ctx.Prijateljstvo.Where(p => p.KorisnikPosiljalacId == search.IdKorisnikaPretrazitelja
                         && p.KorisnikPrimalacId == k.Id).Any())
                        {
                            prijatelji.Add(k);
                        }

                        if(_ctx.Prijateljstvo.Where(p=>p.KorisnikPrimalacId == search.IdKorisnikaPretrazitelja  
                        && p.KorisnikPosiljalacId == k.Id).Any())
                        {
                            prijatelji.Add(k);
                        }
                    }
                    foreach(var p in prijatelji)
                    {
                        lista.Remove(p);
                    }
                    return _mapper.Map<List<Model.Korisnik>>(lista);
                }

                if (!string.IsNullOrWhiteSpace(search.Ime))
                    query = query.Where(k => k.Ime.StartsWith(search.Ime));

                if (!string.IsNullOrWhiteSpace(search.Prezime))
                    query = query.Where(k => k.Prezime.StartsWith(search.Prezime));

                var list = query.ToList();

                return _mapper.Map<List<Model.Korisnik>>(list);
            }
            return base.Get(search);  
        }

        public override Model.Korisnik Insert(KorisnikInsertRequest request)
        {
            if (request != null)
            {
                if (request.Password != request.PasswordConfirmation)
                {
                    throw new UserException("Passwordi se ne slazu");
                }
                // provjera da li username vec postoji
                if (_ctx.Administrator.Where(a => a.Username == request.Username).Any())
                {
                    throw new UserException("Username je zauzet");
                }
                if(_ctx.Korisnik.Where(k=>k.Username == request.Username).Any())
                {
                    throw new UserException("Username je zauzet");

                }
                Database.Korisnik k = new Database.Korisnik
                    {
                        Adresa = request.Adresa,
                        Email = request.Email,
                        GradId = request.GradId,
                        Ime = request.Ime,
                        IsAktivan = true,
                        PostanskiBroj = request.PostanskiBroj,
                        Prezime = request.Prezime,
                        Telefon = request.Telefon,
                        Username = request.Username, 
                    };
                    if (request.Slika != null)   
                    {
                        k.Slika = request.Slika;
                        k.SlikaThumb = request.SlikaThumb;
                    }

                    k.PasswordSalt =Helper.HashHelper.GenerateSalt();
                    k.PasswordHash =Helper.HashHelper.GenerateHash(k.PasswordSalt, request.Password);

                    _ctx.Korisnik.Add(k);
                    _ctx.SaveChanges();
                    return _mapper.Map<Model.Korisnik>(k);
                
            }
            
            return null;  
        }
        public override Model.Korisnik Update(int id, KorisnikUpdateRequest request)
        {
            Database.Korisnik entity = _ctx.Korisnik.Find(id);

            if (entity != null)
            {
                if (request.Username != entity.Username)   // znaci da zeli promijeniti svoj username
                {
                    if (_ctx.Administrator.Where(a => a.Username == request.Username).Any())
                    {
                        throw new UserException("Username je zauzet");
                    }
                    if (_ctx.Korisnik.Where(k => k.Username == request.Username).Any())
                    {
                        throw new UserException("Username je zauzet");
                    }
                }
                entity.Adresa = request.Adresa;
                entity.Email = request.Email;
                entity.GradId = request.GradId;
                entity.Ime = request.Ime;
                entity.IsAktivan = true;
                entity.PostanskiBroj = request.PostanskiBroj;
                entity.Prezime = request.Prezime;
                entity.Telefon = request.Telefon;
                entity.Username = request.Username;

                if(request.Slika !=null)  
                {
                    entity.Slika = request.Slika;
                    entity.SlikaThumb = request.SlikaThumb;
                }

                if (!string.IsNullOrWhiteSpace(request.Password))  
                {
                    if (request.Password != request.PasswordConfirmation)
                    {
                        throw new UserException("Passwordi se ne slazu");
                    }

                    entity.PasswordSalt = Helper.HashHelper.GenerateSalt();
                    entity.PasswordHash = Helper.HashHelper.GenerateHash(entity.PasswordSalt, request.Password);
                }

                _ctx.SaveChanges();
                return _mapper.Map<Model.Korisnik>(entity);
            }
            return null;
        }

        public override Model.Korisnik Autentificiraj(string username, string password)
        {
            Database.Korisnik user = _ctx.Korisnik.Where(a => a.Username == username).FirstOrDefault();

            if (user != null)
            {
                if (user.PasswordHash == Helper.HashHelper.GenerateHash(user.PasswordSalt, password))
                    return _mapper.Map<Model.Korisnik>(user);
            }

            return null;
        }
     
        public override  Model.Korisnik UpdateAttribute( KorisnikPatchRequest request)
        {
            var entity = _ctx.Korisnik.Find(request.Id);

            if (entity != null)
            {

                entity.IsAktivan = request.IsAktivan;
            
                _ctx.SaveChanges();
                return _mapper.Map<Model.Korisnik>(entity);
            }
           
            return null;
            
        }
    }
}
