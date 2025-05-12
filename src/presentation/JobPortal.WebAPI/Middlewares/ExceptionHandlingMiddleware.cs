using JobPortal.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.WebAPI.Middlewares
{
    public class ExceptionHandlingMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                var exceptionDetails = GetExceptionDetails(exception);

                var problemDetails = new ProblemDetails()
                {
                    Status = exceptionDetails.Status,
                    Type = exceptionDetails.Type,
                    Title = exceptionDetails.Title,
                    Detail = exceptionDetails.Detail,
                };

                if (exceptionDetails.Errors is not null)
                {
                    problemDetails.Extensions["errors"] = exceptionDetails.Errors;
                }

                context.Response.StatusCode = exceptionDetails.Status;

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }

        private static ExceptionDetails GetExceptionDetails(Exception exception)
        {
            return exception switch
            {
                ValidationException validationException => new ExceptionDetails(StatusCodes.Status400BadRequest, "ValidationFailure", "Validation error", "One or more validation errors has occured", validationException.Errors),
                _ => new ExceptionDetails(StatusCodes.Status500InternalServerError, "InternalServerError", "An error occurred", "An error occurred while processing your request", null)
            };
        }

        internal record ExceptionDetails(int Status, string Type, string Title, string Detail, IEnumerable<object>? Errors);
    }
}
