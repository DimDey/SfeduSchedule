using System.Net;
using System.Text.Json;
using FluentValidation;
using SfeduSchedule.Application.Common.Exceptions;

namespace SfeduSchedule.WebApi.Middleware;

public class ExpectionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExpectionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExpectionAsync(context, exception);
        }
    }

    private Task HandleExpectionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = String.Empty;
        switch (exception)
        {
            case ValidationException validationException:
                code = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(validationException.Errors);
                break;
            case NotFoundException notFoundException:
                code = HttpStatusCode.NotFound;
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        if (result == string.Empty)
        {
            result = JsonSerializer.Serialize(new { message = exception.Message });
        }
        
        return context.Response.WriteAsync(result);
    }
}