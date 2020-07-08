using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using WebApplication.Filters;

namespace WebApplication
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            ExceptionTypeIs.ArgumentException(context);
            ExceptionTypeIs.ArgumentNullException(context);
            ExceptionTypeIs.FormatException(context);
        }

        public void OnActionExecuting(ActionExecutingContext context) { }
    }
}
