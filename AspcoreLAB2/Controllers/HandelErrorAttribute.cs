using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AspcoreLAB2.Controllers
{
    internal class HandelErrorAttribute : Attribute,IExceptionFilter
    {
       
            public void OnException(ExceptionContext context)
            {
                //ContentResult result= new ContentResult();
                //result.Content = "Sorry Try Again";
                ////context.Exception.Message
                //context.Result = result;//response exception throw
                ViewResult ressult = new ViewResult();
                ressult.ViewName = "Error";

                context.Result = ressult;
            }
        }
}