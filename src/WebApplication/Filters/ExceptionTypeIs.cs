using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebApplication.Filters
{
    public static class ExceptionTypeIs
    {
        public static void ArgumentException(ActionExecutedContext context)
        {
            if (context.ExceptionHandled || !(context.Exception is ArgumentException exception))
            {
                return;
            }

            BadRequestContextResult(context, exception);
        }

        public static void ArgumentNullException(ActionExecutedContext context)
        {
            if (context.ExceptionHandled || !(context.Exception is ArgumentNullException exception))
            {
                return;
            }
            BadRequestContextResult(context, exception);
        }

        public static void FormatException(ActionExecutedContext context)
        {
            if (context.ExceptionHandled || !(context.Exception is FormatException exception))
            {
                return;
            }

            BadRequestContextResult(context, exception);
        }

        private static void BadRequestContextResult(ActionExecutedContext context, Exception exception)
        {
            context.Result = new ObjectResult(exception.Message)
            {
                StatusCode = 400,
            };
            context.ExceptionHandled = true;
            return;
        }
    }
}
