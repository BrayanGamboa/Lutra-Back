namespace Lutra.Application.Shared;

public record CurrentUserContext(Guid UserId, IReadOnlyList<string> Roles)
{
    public bool HasRole(string role) =>
        Roles.Any(r => string.Equals(r, role, StringComparison.OrdinalIgnoreCase));
}
