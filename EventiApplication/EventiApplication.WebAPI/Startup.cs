using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventiApplication.Model.Request;
using EventiApplication.WebAPI.Database;
using EventiApplication.WebAPI.Filters;
using EventiApplication.WebAPI.Security;
using EventiApplication.WebAPI.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace EventiApplication.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(x => x.Filters.Add<ErrorFilter>()).AddNewtonsoftJson();  
            services.AddControllers(); 


            services.AddAuthentication("BasicAuthentication")
               .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            //services.AddSwaggerGen(c => {
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            //});

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });
            });
                                                 
         
            services.AddDbContext<MojContext>(options => options.UseSqlServer(Configuration.GetConnectionString("lokalni")));
            

            services.AddAutoMapper(typeof(Startup));


            services.AddScoped<ICRUDService<Model.Event, EventSearchRequest, EventInsertRequest, EventInsertRequest, object>, EventService>();

            services.AddScoped<IService<Model.Kategorija, object>, BaseService<Model.Kategorija, object, Database.Kategorija>>();

            services.AddScoped<ICRUDService<Model.ProstorOdrzavanja, ProstorOdrzavanjaSearchRequest, ProstorOdrzavanjaInsertRequest, 
                ProstorOdrzavanjaInsertRequest, object>, ProstorOdrzavanjaService>();

            services.AddScoped<IService<Model.TipProstoraOdrzavanja, object>, BaseService<Model.TipProstoraOdrzavanja, object, Database.TipProstoraOdrzavanja>>();

            services.AddScoped<IService<Model.Grad, object>, BaseService<Model.Grad, object, Database.Grad>>();

            services.AddScoped<ICRUDService<Model.ProdajaTip, ProdajaTipSearchRequest, ProdajaTipInsertRequest, ProdajaTipInsertRequest, object>,
                ProdajaTipService>();
            services.AddScoped<ICRUDService<Model.TipKarte, object, TipKarteInsertRequest, object, object>, TipKarteService>();

            services.AddScoped<ICRUDService<Model.Organizator,OrganizatorSearchRequest, OrganizatorInsertRequest, OrganizatorInsertRequest, object>,
                OrganizatorService>();

            services.AddScoped<ICRUDService<Model.Korisnik, KorisnikSearchRequest, KorisnikInsertRequest, KorisnikUpdateRequest, KorisnikPatchRequest>,
                KorisnikService>();

            services.AddScoped<ICRUDService<Model.Administrator, AdministratorSearchRequest, AdministratorInsertRequest, AdministratorUpdateRequest, object>
                , AdministratorService>();

            services.AddScoped<ICRUDService<Model.Kupovina, KupovinaSearchRequest, KupovinaInsertRequest, KupovinaInsertRequest, object>,
                KupovinaService>();

            services.AddScoped<ICRUDService<Model.Like, LikeSearchRequest, LikeInsertRequest, object, object>, LikeService>();

            services.AddScoped<ICRUDService<Model.Ocjena, OcjenaSearchRequest, OcjenaInsertRequest, OcjenaInsertRequest, object>, OcjenaService>();

            services.AddScoped<ICRUDService<Model.Prijateljstvo, PrijateljstvoSearchRequest, PrijateljstvoInsertRequest, PrijateljstvoInsertRequest, PrijateljstvoPatchRequest>, PrijateljstvoService>();

            services.AddScoped<ICRUDService<Model.PozivNaEvent, PozivNaEventSearchRequest, PozivNaEventInsertRequest, object, PozivNaEventPatchRequest>, PozivNaEventService>();

            services.AddScoped<ICRUDService<Model.Recenzija, RecenzijaSearchRequest, RecenzijaInsertRequest, RecenzijaInsertRequest, object>, RecenzijaService>();

            services.AddScoped<IService<Model.Karta, KartaSearchRequest>, KartaService>();
        } 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

           
        }
    }
}
