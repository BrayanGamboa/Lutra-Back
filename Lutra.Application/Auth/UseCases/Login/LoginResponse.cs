using Lutra.Application.Auth.UseCases.RoleUsersDetail;

namespace Lutra.Application.Auth.UseCases.Login
{
    public record LoginResponse(string Token, RoleUsersDetailResponse User);
}
