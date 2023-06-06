using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCDemo.Filtters
{
    public class HandelErrorAttribute : Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // context.Result = new ContentResult() { Content = "Some Error HAppne :)" };
            context.Result = new ViewResult() { ViewName = "Error" };//Shared
        }
    }
}
