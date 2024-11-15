using Bookify.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Api.Middleware;

public sealed class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exception occurred: {Message}", ex.Message);
            
            var exceptionDetails = GetExceptionDetails(ex);

            var problemDetails = new ProblemDetails
            {
                Status = exceptionDetails.Status,
                Type = exceptionDetails.Type,
                Title = exceptionDetails.Title,
                Detail = exceptionDetails.Detail,
            };
            
            if (exceptionDetails.Errors is not null)
            {
                problemDetails.Extensions.Add("errors", exceptionDetails.Errors);
            }

            context.Response.StatusCode = exceptionDetails.Status;
            
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }

    private static ExceptionDetails GetExceptionDetails(Exception ex)
    {
        return ex switch
        {
            ValidationException validationException => new ExceptionDetails(
                Status: StatusCodes.Status400BadRequest,
                Type: "ValidationFailure",
                Title: "Validation error",
                Detail: "One or more validation errors occurred",
                Errors: validationException.Errors
            ),
            _ => new ExceptionDetails(
                Status: StatusCodes.Status500InternalServerError,
                Type: "ServerError",
                Title: "Server error",
                Detail: "An unexpected error has occurred",
                Errors: null
            )
        };
    }
    
    internal record ExceptionDetails(
        int Status,
        string Type,
        string Title,
        string Detail,
        IEnumerable<object>? Errors);
}