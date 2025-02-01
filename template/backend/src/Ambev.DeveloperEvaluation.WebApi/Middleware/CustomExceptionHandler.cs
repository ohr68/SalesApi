using Ambev.DeveloperEvaluation.WebApi.Common;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Diagnostics;

namespace Ambev.DeveloperEvaluation.WebApi.Middleware;

/// <summary>
/// Defines how to handle exceptions properly and sets the correct status code to the response
/// </summary>
public class CustomExceptionHandler : IExceptionHandler
{
    private readonly Dictionary<Type, Func<HttpContext, Exception, Task>> _exceptionHandlers;
    
    ///<summary>
    /// Initializes a new instance of CustomExceptionHandler.
    /// Register known exception types and handlers.
    /// </summary>
    public CustomExceptionHandler()
    {
            _exceptionHandlers = new()
        {
            { typeof(NotFoundException), HandleNotFoundException },
            { typeof(UnauthorizedAccessException), HandleUnauthorizedAccessException },
        };
    }
    
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var exceptionType = exception.GetType();

        if (!_exceptionHandlers.TryGetValue(exceptionType, out var handler)) return false;
        await handler.Invoke(httpContext, exception);
        return true;
    }
    
    private async Task HandleNotFoundException(HttpContext httpContext, Exception ex)
    {
        var exception = (NotFoundException)ex;

        httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

        await httpContext.Response.WriteAsJsonAsync(new ApiResponse()
        {
            Success = false,
            Message = exception.Message,
            Errors = null
        });
    }
    
    private async Task HandleUnauthorizedAccessException(HttpContext httpContext, Exception ex)
    {
        httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;

        await httpContext.Response.WriteAsJsonAsync(new ApiResponse()
        {
            Success = false,
            Message = ex.Message,
            Errors = null
        });
    }

}