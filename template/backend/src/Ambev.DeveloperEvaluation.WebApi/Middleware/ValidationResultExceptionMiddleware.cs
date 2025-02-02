using System.Text.Json;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Middleware;

/// <summary>
/// Middleware to capture ValidationResult custom exceptions
/// </summary>
public class ValidationResultExceptionMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// Initializes a new instance of ValidationResultExceptionMiddleware class
    /// </summary>
    /// <param name="next">Request delegate</param>
    public ValidationResultExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// This method is called when the http context call stack starts.
    /// </summary>
    /// <param name="context">the current http context</param>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationResultException ex)
        {
            await HandleValidationResultExceptionAsync(context, ex);
        }
    }

    private static Task HandleValidationResultExceptionAsync(HttpContext context, ValidationResultException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status400BadRequest;

        var response = new ApiResponse
        {
            Success = false,
            Message = "Validation Failed",
            Errors = exception.Errors
                .Select(error => error)
        };

        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response, jsonOptions));
    }
}