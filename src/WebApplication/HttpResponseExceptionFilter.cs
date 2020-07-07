using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebApplication
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            IsArgumentException(context);
            IsArgumentNullException(context);
            IsFormatException(context);

        }

        private static void IsArgumentException(ActionExecutedContext context)
        {
            if (!context.ExceptionHandled && context.Exception is ArgumentException exception)
            {
                context.Result = new ObjectResult(new { Message = exception.Message })
                {
                    StatusCode = 400,
                };
                context.ExceptionHandled = true;
                return;
            }
        }

        private static void IsArgumentNullException(ActionExecutedContext context)
        {
            if (!context.ExceptionHandled &&  context.Exception is ArgumentNullException exception)
            {
                context.Result = new ObjectResult(new { Message = exception.Message })
                {
                    StatusCode = 400,
                };
                context.ExceptionHandled = true;
                return;
            }
        }

        private static void IsFormatException(ActionExecutedContext context)
        {
            if (context.Exception is FormatException exception)
            {
                context.Result = new ObjectResult(new { Message = exception.Message })
                {
                    StatusCode = 400,
                };
                context.ExceptionHandled = true;
                return;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
