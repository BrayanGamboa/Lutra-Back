using Lutra.Domain.Shared;
using System.Net;
using System.Text.Json;
namespace Lutra.Api.Middleware;

public class GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (DomainException ex)
        {
            logger.LogWarning(ex, "Excepción de dominio: {Message}", ex.Message);
            await WriteErrorResponse(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (KeyNotFoundException ex)
        {
            logger.LogWarning(ex, "No encontrado: {Message}", ex.Message);
            await WriteErrorResponse(context, HttpStatusCode.NotFound, ex.Message);
        }
        catch (ForbiddenException ex)
        {
            logger.LogWarning(ex, "Prohibido: {Message}", ex.Message);
            await WriteErrorResponse(context, HttpStatusCode.Forbidden, ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            logger.LogWarning(ex, "No autorizado: {Message}", ex.Message);
            await WriteErrorResponse(context, HttpStatusCode.Unauthorized, "No autorizado");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error inesperado");
            await WriteErrorResponse(context, HttpStatusCode.InternalServerError, "Ocurrió un error inesperado");
        }
    }

    private static async Task WriteErrorResponse(HttpContext context, HttpStatusCode statusCode, string message)
    {
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";
        var error = new { code = (int)statusCode, message };
        await context.Response.WriteAsync(JsonSerializer.Serialize(error));
    }
}
