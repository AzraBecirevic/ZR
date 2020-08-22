using AutoMapper;
using EventiApplication.Model;
using EventiApplication.Model.Request;
using EventiApplication.WebAPI.Database;
using EventiApplication.WebAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EventiApplication.WebAPI.Service
{
    public class AdministratorService : BaseCRUDService<Model.Administrator, AdministratorSearchRequest, Database.Administrator, AdministratorInsertRequest, AdministratorUpdateRequest, object>
    {
        public AdministratorService(MojContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }

        public override List<Model.Administrator> Get(AdministratorSearchRequest search)
        {

            if (!string.IsNullOrWhiteSpace(search?.Username))
            {
                var list = _ctx.Administrator.Where(a => a.Username.ToLower().StartsWith(search.Username.ToLower())).ToList();
                return _mapper.Map<List<Model.Administrator>>(list);
            }

            return base.Get(search);
        }

        public override Model.Administrator Insert(AdministratorInsertRequest request)
        {
            if (request != null)
            {
                if (request.Password != request.PasswordConfirmation)
                {
                    throw new UserException("Passwordi se ne slazu");
                }
                if (_ctx.Administrator.Where(a => a.Username == request.Username).Any())
                {
                    throw new UserException("Username je zauzet");  
                }
                if (_ctx.Korisnik.Where(k => k.Username == request.Username).Any())
                {
                    throw new UserException("Username je zauzet");

                }
                Database.Administrator administrator = new Database.Administrator
                    {

                        Email = request.Email,
                        GradId = request.GradId,
                        Ime = request.Ime,
                        Prezime = request.Prezime,
                        Telefon = request.Telefon,
                        Username = request.Username,
                    };

                    administrator.PasswordSalt =Helper.HashHelper.GenerateSalt();
                    administrator.PasswordHash =Helper.HashHelper.GenerateHash(administrator.PasswordSalt, request.Password);

                    _ctx.Administrator.Add(administrator);
                    _ctx.SaveChanges();
                    return _mapper.Map<Model.Administrator>(administrator);

                
            }
            return null;
        }

        public override Model.Administrator Update(int id, AdministratorUpdateRequest request)
        {
            Database.Administrator entity = _ctx.Administrator.Find(id);
            
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

                entity.Email = request.Email;
                entity.GradId = request.GradId;
                entity.Ime = request.Ime;
                entity.Prezime = request.Prezime;
                entity.Telefon = request.Telefon;
                entity.Username = request.Username;  


                if (!string.IsNullOrWhiteSpace(request.Password))  // znaci da zeli promijeniti password
                {
                    if (request.Password != request.PasswordConfirmation)
                    {
                        throw new UserException("Passwordi se ne slazu");
                    }

                    entity.PasswordSalt = Helper.HashHelper.GenerateSalt();
                    entity.PasswordHash = Helper.HashHelper.GenerateHash(entity.PasswordSalt, request.Password);
                } 
              
                _ctx.SaveChanges();
                return _mapper.Map<Model.Administrator>(entity);
            }
            
            return null;
        }

        public override Model.Administrator Autentificiraj(string username, string password)
        {

            Database.Administrator admin = _ctx.Administrator.Where(a => a.Username == username).FirstOrDefault();

            if(admin != null)
            {
                if (admin.PasswordHash == Helper.HashHelper.GenerateHash(admin.PasswordSalt, password))
                    return _mapper.Map<Model.Administrator>(admin);
            }

            return null;
        }
    }
}
