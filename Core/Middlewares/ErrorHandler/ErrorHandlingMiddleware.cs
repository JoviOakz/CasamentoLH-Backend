using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace CasamentoLH_Backend.Core.Middlewares.ErrorHandler;

public class ErrorHandlingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(context, ex);
        }
    }

    private static async Task HandleErrorAsync(HttpContext context, Exception exception)
    {
        var problemDetails = exception switch
        {
            AppException e => new ProblemDetails
            {
                Status = e.Status,
                Title = e.Title,
                Detail = e.Message,
                Type = e.Type
            },
            _ => new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Internal Server Error",
                Detail = "An unexpected error occurred.",
                Type = "https://example.com/problems/internal-server-error"
            }
        };

        context.Response.StatusCode = problemDetails.Status!.Value;
        context.Response.ContentType = "application/problem+json";

        var jsonResponse = JsonSerializer.Serialize(problemDetails);
        await context.Response.WriteAsync(jsonResponse);
    }
}
