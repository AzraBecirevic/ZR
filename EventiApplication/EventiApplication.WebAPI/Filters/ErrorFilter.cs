using EventiApplication.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace EventiApplication.WebAPI.Filters
{
    public class ErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is UserException)     
            {
                context.ModelState.AddModelError("Greska", context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }                                                                
            else
            {
                context.ModelState.AddModelError("Greska", "Greska na serveru");
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }


            // context.Result = new JsonResult(context.ModelState);
            var list = context.ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(x => x.Key, y => y.Value.Errors.Select(z => z.ErrorMessage));

            context.Result = new JsonResult(list);
        }
    }
}
