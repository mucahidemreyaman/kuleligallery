using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace KuleliGallery.APİ.Filters
{
    public class ExceptionHandlerFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult((new { Error = context.Exception.Message}));
            context.HttpContext.Response.StatusCode = 400; 
            context.ExceptionHandled = true;
        }

    }

}

