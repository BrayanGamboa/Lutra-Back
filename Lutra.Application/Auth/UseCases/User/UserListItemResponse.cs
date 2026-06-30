namespace Lutra.Application.Auth.UseCases.User;

public record UserListItemResponse(
    Guid UserId,
    string Username,
    string Email,
    string Name,
    string LastName,
    bool IsActive,
    IEnumerable<string> Roles)
{
    public static UserListItemResponse FromDomain(Domain.Auth.User user) =>
        new(
            user.UserId,
            user.Username,
            user.Email,
            user.Name,
            user.LastName,
            user.IsActive,
            user.RoleUsersDetails
                .Select(rud => rud.Role?.Name)
                .Where(n => n is not null)
                .Select(n => n!));
}
