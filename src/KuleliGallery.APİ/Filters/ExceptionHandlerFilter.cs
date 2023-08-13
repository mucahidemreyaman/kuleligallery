using Kuleli.Shop.Application.Exceptions;
using Kuleli.Shop.Application.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace KuleliGallery.APİ.Filters
{
    public class ExceptionHandlerFilter : IExceptionFilter
    {
        //AOP (Aspect Oriented Programing)
        //Intercepter (Bolucu, Araya girici)
        //Tum actıon metodlar calisirken hata durumunda mutlaka buraya duser.
        //Bu yazılan sınıfın her action icin bir filtre olarak calısması isteniyorsa
        //servis registirasyon asamasında AddControllers kısmında (Program.cs) register edilir.

        public void OnException(ExceptionContext context)
        {
            var result = new Result<dynamic>()
            {
               
                Success = false

            };

            if (context.Exception is NotFoundException notFoundException)
            {
                result.Errors = new List<string> { notFoundException.Message };
            }

            else if (context.Exception is ValidateException validationException)
            {
                result.Errors.AddRange(validationException.ErrorMessages);
            }
           
            else 
            {
               result.Errors= new List<string>{context.Exception.InnerException != null? context
                   .Exception.InnerException.Message:
                   context.Exception.Message};
            }

            context.Result = new JsonResult(result);           
            context.HttpContext.Response.StatusCode = 400;
            context.ExceptionHandled = true;
        }

        public class Test : IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext context)
            {
                throw new NotImplementedException();
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                throw new NotImplementedException();
            }
        }
    }

}

