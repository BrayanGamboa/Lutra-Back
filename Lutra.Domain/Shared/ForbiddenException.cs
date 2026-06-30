namespace Lutra.Domain.Shared;

public class ForbiddenException(string message = "No tiene permisos para acceder a este recurso.")
    : Exception(message);
