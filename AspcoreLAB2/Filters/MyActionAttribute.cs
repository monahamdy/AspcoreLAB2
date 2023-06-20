
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspcoreLAB2.Filters
{
    public class MyActionAttribute : Attribute, IActionFilter
    {
        //after action execute 
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //model binding

        }
        //befor action execute
        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
