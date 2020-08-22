using EventiApplication.Model.Request;
using EventiApplication.WebAPI.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace EventiApplication.WebAPI.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly ICRUDService<Model.Korisnik, KorisnikSearchRequest, KorisnikInsertRequest, KorisnikUpdateRequest, KorisnikPatchRequest> _userService;
        private readonly ICRUDService<Model.Administrator, AdministratorSearchRequest, AdministratorInsertRequest, AdministratorUpdateRequest, object> _adminService;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder,
            ISystemClock clock,
            ICRUDService<Model.Korisnik, KorisnikSearchRequest, KorisnikInsertRequest, KorisnikUpdateRequest, KorisnikPatchRequest> userService,
            ICRUDService<Model.Administrator,AdministratorSearchRequest, AdministratorInsertRequest, AdministratorUpdateRequest, object> adminService) 
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
            _adminService = adminService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing authorization header");
            }

            Model.Korisnik user = null;  
            Model.Administrator admin = null;  

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(":");
                var username = credentials[0];
                var password = credentials[1];
                user = _userService.Autentificiraj(username, password);
                admin = _adminService.Autentificiraj(username, password);
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid authorization header");
            }
            if(user==null && admin == null)
            {
                return AuthenticateResult.Fail("Invalid username or password");
            }

            List<Claim> claims = null;
            if (user != null)
            {
                claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Username),
                    new Claim(ClaimTypes.Name, user.Ime),
                    new Claim(ClaimTypes.Role, user.Uloga)
                };
            }
            else if(admin != null)
            {
                claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,admin.Username),
                    new Claim(ClaimTypes.Name, admin.Ime),
                    new Claim(ClaimTypes.Role, admin.Uloga)

                };
            }

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var princpal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(princpal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
